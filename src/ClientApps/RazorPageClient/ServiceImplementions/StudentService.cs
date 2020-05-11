using RazorPageClient.Services;
using RazorPageClient.ViewModels.StudentViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RazorPageClient.ServiceImplementions
{
    public class StudentService : IStudentService
    {
        private readonly HttpClient _httpClient;

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "Not applicable here")]
        public StudentService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("EmployeeManagementApi");
        }

        private static JsonSerializerOptions JsonSerializerOptions => new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<List<StudentDetailsViewModel>> GetStudentListAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("student/get-student-list");
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                List<StudentDetailsViewModel> employees = JsonSerializer.Deserialize<List<StudentDetailsViewModel>>(responseString, JsonSerializerOptions);
                return employees;
            }

            throw new ApplicationException($"{response.ReasonPhrase}: The status code is: {(int)response.StatusCode}");
        }

        public async Task<StudentDetailsViewModel> GetStudentDetailsAsync(int studentId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"student/get-student-details/{studentId}");
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                if (string.IsNullOrWhiteSpace(responseString))
                {
                    return null;
                }

                StudentDetailsViewModel student = JsonSerializer.Deserialize<StudentDetailsViewModel>(responseString, JsonSerializerOptions);
                return student;
            }

            throw new ApplicationException($"{response.ReasonPhrase}: The status code is: {(int)response.StatusCode}");
        }

        public async Task CreateStudentAsync(CreateStudentViewModel createStudentViewModel)
        {
            string jsonStringBody = JsonSerializer.Serialize(createStudentViewModel);
            using StringContent content = new StringContent(jsonStringBody, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("student/create-student", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"{response.ReasonPhrase}: The status code is: {(int)response.StatusCode}");
            }
        }

        public async Task UpdateStudentAsync(UpdateStudentViewModel updateStudentViewModel)
        {
            string jsonStringBody = JsonSerializer.Serialize(updateStudentViewModel);
            using StringContent content = new StringContent(jsonStringBody, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync("student/update-student", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"{response.ReasonPhrase}: The status code is: {(int)response.StatusCode}");
            }
        }

        public async Task DeleteStudent(int studentId)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"student/delete-student/{studentId}");

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"{response.ReasonPhrase}: The status code is: {(int)response.StatusCode}");
            }
        }
    }
}
