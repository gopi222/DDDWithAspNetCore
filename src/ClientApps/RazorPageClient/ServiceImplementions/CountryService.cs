using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPageClient.Services;
using RazorPageClient.ViewModels.CountryViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RazorPageClient.ServiceImplementions
{
    public class CountryService : ICountryService
    {
        private readonly HttpClient _httpClient;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Not applicable for constructor")]
        public CountryService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("EmployeeManagementApi");
        }

        private static JsonSerializerOptions JsonSerializerOptions => new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<List<CountryDetailsViewModel>> GetCountryListAsync()
        {
            using HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "country/get-country-list");
            HttpResponseMessage response = await _httpClient.SendAsync(httpRequestMessage);
            if (response.IsSuccessStatusCode)
            {
                string repsonseString = await response.Content.ReadAsStringAsync();

                List<CountryDetailsViewModel> countrys = JsonSerializer.Deserialize<List<CountryDetailsViewModel>>(repsonseString, JsonSerializerOptions);
                return countrys;
            }

            throw new ApplicationException($"{response.ReasonPhrase}: The status code is: {(int)response.StatusCode}");
        }

        public async Task<SelectList> GetCountrySelectListAsync(int? selectedCountry)
        {
            using HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"country/get-country-select-list?selectedCountry={selectedCountry}");
            HttpResponseMessage response = await _httpClient.SendAsync(httpRequestMessage);
            if (response.IsSuccessStatusCode)
            {
                string repsonseString = await response.Content.ReadAsStringAsync();

                List<SelectListItem> countrys = JsonSerializer.Deserialize<List<SelectListItem>>(repsonseString, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });

                return new SelectList(countrys, "Value", "Text");
            }

            throw new ApplicationException($"{response.ReasonPhrase}: The status code is: {(int)response.StatusCode}");
        }

        public async Task CreateCountryAsync(CreateCountryViewModel createCountryViewModel)
        {
            string jsonStringBody = JsonSerializer.Serialize(createCountryViewModel);
            using StringContent stringContent = new StringContent(jsonStringBody, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("country/create-country", stringContent);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"{response.ReasonPhrase}: The status code is: {(int)response.StatusCode}");
            }
        }

        public async Task<CountryDetailsViewModel> GetCountryAsync(int countryId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"country/get-country/{countryId}");
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                CountryDetailsViewModel countryDetailsViewModel = JsonSerializer.Deserialize<CountryDetailsViewModel>(jsonString, JsonSerializerOptions);
                return countryDetailsViewModel;
            }

            throw new ApplicationException($"{response.ReasonPhrase}: The status code is: {(int)response.StatusCode}");
        }

        public async Task UpdateCountryAsync(UpdateCountryViewModel updateCountryViewModel)
        {
            string jsonString = JsonSerializer.Serialize(updateCountryViewModel);
            using StringContent stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync("country/update-country", stringContent);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"{response.ReasonPhrase}: The status code is: {(int)response.StatusCode}");
            }
        }

        public async Task DeleteCountryAsync(int countryId)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"country/delete-country/{countryId}");

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"{response.ReasonPhrase}: The status code is: {(int)response.StatusCode}");
            }
        }
    }
}
