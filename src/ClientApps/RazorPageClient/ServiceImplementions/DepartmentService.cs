﻿using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPageClient.Services;
using RazorPageClient.ViewModels.DepartmentsViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RazorPageClient.ServiceImplementions
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient _httpClient;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Not applicable for constructor")]
        public DepartmentService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("EmployeeManagementApi");
        }

        private static JsonSerializerOptions JsonSerializerOptions => new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<List<CountryDetailsViewModel>> GetDepartmentListAsync()
        {
            using HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, "department/get-department-list");
            HttpResponseMessage response = await _httpClient.SendAsync(httpRequestMessage);
            if (response.IsSuccessStatusCode)
            {
                string repsonseString = await response.Content.ReadAsStringAsync();

                List<CountryDetailsViewModel> departments = JsonSerializer.Deserialize<List<CountryDetailsViewModel>>(repsonseString, JsonSerializerOptions);
                return departments;
            }

            throw new ApplicationException($"{response.ReasonPhrase}: The status code is: {(int)response.StatusCode}");
        }

        public async Task<SelectList> GetDepartmentSelectListAsync(int? selectedDepartment)
        {
            using HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, $"department/get-department-select-list?selectedDepartment={selectedDepartment}");
            HttpResponseMessage response = await _httpClient.SendAsync(httpRequestMessage);
            if (response.IsSuccessStatusCode)
            {
                string repsonseString = await response.Content.ReadAsStringAsync();

                List<SelectListItem> departments = JsonSerializer.Deserialize<List<SelectListItem>>(repsonseString, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });

                return new SelectList(departments, "Value", "Text");
            }

            throw new ApplicationException($"{response.ReasonPhrase}: The status code is: {(int)response.StatusCode}");
        }

        public async Task CreateDepartmentAsync(CreateCountryViewModel createDepartmentViewModel)
        {
            string jsonStringBody = JsonSerializer.Serialize(createDepartmentViewModel);
            using StringContent stringContent = new StringContent(jsonStringBody, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("department/create-department", stringContent);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"{response.ReasonPhrase}: The status code is: {(int)response.StatusCode}");
            }
        }

        public async Task<CountryDetailsViewModel> GetDepartmentAsync(int departmentId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"department/get-department/{departmentId}");
            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                CountryDetailsViewModel departmentDetailsViewModel = JsonSerializer.Deserialize<CountryDetailsViewModel>(jsonString, JsonSerializerOptions);
                return departmentDetailsViewModel;
            }

            throw new ApplicationException($"{response.ReasonPhrase}: The status code is: {(int)response.StatusCode}");
        }

        public async Task UpdateDepartmentAsync(UpdateCountryViewModel updateDepartmentViewModel)
        {
            string jsonString = JsonSerializer.Serialize(updateDepartmentViewModel);
            using StringContent stringContent = new StringContent(jsonString, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync("department/update-department", stringContent);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"{response.ReasonPhrase}: The status code is: {(int)response.StatusCode}");
            }
        }

        public async Task DeleteDepartmentAsync(int departmentId)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"department/delete-department/{departmentId}");

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"{response.ReasonPhrase}: The status code is: {(int)response.StatusCode}");
            }
        }
    }
}
