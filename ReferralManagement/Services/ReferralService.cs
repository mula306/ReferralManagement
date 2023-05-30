using Newtonsoft.Json;
using ReferralManagement.Model;
using System.Net.Http.Headers;
using System.Text;

namespace ReferralManagement.Services
{
    public class ReferralService : IReferralService
    {
        private readonly HttpClient _client;

        public ReferralService(HttpClient client, IApiConfigurationService apiConfigurationService)
        {
            _client = client;
            _client.BaseAddress = new Uri(apiConfigurationService.GetBaseUri());
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private async Task<T> SendRequestAsync<T>(string endpoint)
        {
            var response = await _client.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content);
            }
            else
            {
                // Log the error response here
                Console.WriteLine($"Error: {response.StatusCode} when accessing {endpoint}");
                return default;
            }
        }

        public async Task<List<Referral>> GetReferrals()
        {
            var endpoint = $"/api/Referral/";
            return await SendRequestAsync<List<Referral>>(endpoint);
        }

        public async Task<Referral> GetReferralById(int id)
        {
            var endpoint = $"/api/Referral/{id}";
            var patientList = await SendRequestAsync<Referral>(endpoint);
            return patientList;
        }

        public async Task AddReferral(Referral referral)
        {
            var endpoint = $"/api/Referral";
            var patientJson = JsonConvert.SerializeObject(referral);
            var httpContent = new StringContent(patientJson, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(endpoint, httpContent);

            if (!response.IsSuccessStatusCode)
            {
                // Handle error response here or throw an exception
            }
        }

        public async Task UpdateReferral(Referral referral)
        {
            var endpoint = $"/api/Referral/{referral.ReferralId}";
            var patientJson = JsonConvert.SerializeObject(referral);
            var httpContent = new StringContent(patientJson, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(endpoint, httpContent);

            if (!response.IsSuccessStatusCode)
            {
                // Handle error response here or throw an exception
            }
        }
    }
}
