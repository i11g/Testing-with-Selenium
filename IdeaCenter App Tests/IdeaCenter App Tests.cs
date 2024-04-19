using IdeaCenter_App_Tests.Models;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;
using System.Text.Json;

namespace IdeaCenter_App_Tests
{
    public class IdeaCenter_App_Tests 
    {
        private RestClient client;
        private const string BASEURL = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:84";
        private const string EMAIL = "iv@test.com";
        private const string PASSWORD = "123456";

        private string lastID;

       [OneTimeSetUp]

       public void Setup()
        {
            string jwtToken = GETJwtToken(EMAIL, PASSWORD);

            var options = new RestClientOptions(BASEURL)
            {
                Authenticator = new JwtAuthenticator(jwtToken)
            };

            client =new RestClient(options);

        }
        
        private string GETJwtToken(string email, object password)
        {
            RestClient tempAuth = new RestClient(BASEURL);

            var request = new RestRequest("/api/User/Authentication");
            request.AddJsonBody(new
            {
                email,
                password

            });

            var response = tempAuth.Execute(request, Method.Post);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = JsonSerializer.Deserialize<JsonElement>(response.Content);
                var token = content.GetProperty("accessToken").GetString();
                if (string.IsNullOrEmpty(token))
                {
                    throw new InvalidOperationException("Toekn is null or empty");
                }
                return token;
            }
            else
            {
                throw new InvalidOperationException($"Authentication failed: {response.StatusCode}");
            }

        }

        [Order(1)]
        [Test]
        public void Create_New_Idea_With_Required_Fileds_Should_Create_New_Idea ()
        {
            //Arrange 

            var newIdea = new IdeaDTO
            {
                Title = "New created Idea",
                Description = "The idea was created last summer",
                Url = ""
            };

            var request = new RestRequest("/api/Idea/Create", Method.Post);
            request.AddJsonBody(newIdea);

            //Act
            var response = client.Execute(request);
            
           //Assert

          Assert.That(response.StatusCode,Is.EqualTo(HttpStatusCode.OK));
          var content = JsonSerializer.Deserialize<ApiResponseDTO>(response.Content);
           Assert.That(content.Msg, Is.EqualTo("Successfully created!"));

        }

        [Order(2)]
        [Test] 
        public void Get_All_Ideas_Should_Return_List_With_All_Ideas ()
        {
            //Arrange 

            var request = new RestRequest("/api/Idea/All", Method.Get);

            //Act
            var response = client.Execute(request);

            var content=JsonSerializer.Deserialize<List<ApiResponseDTO>>(response.Content);
            lastID = content.LastOrDefault().IdeaID;

            //Assert 

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(content.Count, Is.GreaterThan(0));

        }

        

    }
}