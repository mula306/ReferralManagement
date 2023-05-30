using Newtonsoft.Json;
using System.Net.Http.Headers;
using ReferralManagement.Model;
using System.Text;

namespace ReferralManagement.Services
{
    public class PatientService : IPatientService
    {
        private readonly HttpClient _client;

        public PatientService(HttpClient client, IApiConfigurationService apiConfigurationService)
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

        public async Task<List<Patient>> GetPatients()
        {
            var endpoint = $"/api/Patient/";
            return await SendRequestAsync<List<Patient>>(endpoint);
        }

        public async Task<Patient> GetPatientById(int id)
        {
            var endpoint = $"/api/Patient/{id}";
            var patientList = await SendRequestAsync<Patient>(endpoint);
            return patientList;
        }

        public async Task UpdatePatient(Patient patient)
        {
            var endpoint = $"/api/Patient/{patient.PatientId}";
            var patientJson = JsonConvert.SerializeObject(patient);
            var httpContent = new StringContent(patientJson, Encoding.UTF8, "application/json");
            var response = await _client.PutAsync(endpoint, httpContent);

            if (!response.IsSuccessStatusCode)
            {
                // Handle error response here or throw an exception
            }
        }


    }
}
