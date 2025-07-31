using NUnit.Framework;
using RestSharp;
using System.Threading.Tasks;
using ReqResApiTests_NUnit.Clients;
using System.Net;

namespace ReqResApiTests_NUnit.Tests
{
    public class UserTests : BaseApiClient
    {
        [Test]
        public async Task GetUsers_ShouldReturnSuccess()
        {
            var request = CreateRequest("api/users?page=2", Method.Get);
            var response = await Client.ExecuteAsync(request);
            Assert.That(response.IsSuccessful, Is.True);
        }

        [Test]
        public async Task GetSingleUser_ShouldReturnSuccess()
        {
            var request = CreateRequest("api/users/2", Method.Get);
            var response = await Client.ExecuteAsync(request);
            Assert.That(response.IsSuccessful, Is.True);
        }

        [Test]
        public async Task CreateUser_ShouldReturnCreated()
        {
            var request = CreateRequest("api/users", Method.Post);
            request.AddJsonBody(new { name = "morpheus", job = "leader" });
            var response = await Client.ExecuteAsync(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
        }

        [Test]
        public async Task UpdateUser_ShouldReturnSuccess()
        {
            var request = CreateRequest("api/users/2", Method.Put);
            request.AddJsonBody(new { name = "morpheus", job = "zion resident" });
            var response = await Client.ExecuteAsync(request);
            Assert.That(response.IsSuccessful, Is.True);
        }

        [Test]
        public async Task DeleteUser_ShouldReturnNoContent()
        {
            var request = CreateRequest("api/users/2", Method.Delete);
            var response = await Client.ExecuteAsync(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
        }
    }
}
