using AutoMapper;
using EmployeeManagement.Api.ApiModels.StudentModels;
using EmployeeManagement.Application.Dtos.StudentDtos;
using EmployeeManagement.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<List<StudentDetailsModel>> GetStudentList()
        {
            List<StudentDetailsDto> studentDetailsDtoList = await _studentService.GetStudentListAsync();
            List<StudentDetailsModel> studentList = _mapper.Map<List<StudentDetailsModel>>(studentDetailsDtoList);
            return studentList;
        }

        // GET: api/Student/5
        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetStudentDetails(int studentId)
        {
            StudentDetailsDto studentDetailsDto = await _studentService.GetStudentDetailsAsync(studentId);
            StudentDetailsModel studentDetailsModel = _mapper.Map<StudentDetailsModel>(studentDetailsDto);
            return Ok(studentDetailsModel);
        }

        // POST: api/Student
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentModel createStudentModel)
        {
            CreateStudentDto createStudentDto = _mapper.Map<CreateStudentDto>(createStudentModel);
            await _studentService.CreateStudentAsync(createStudentDto);
            return Ok();
        }

        // PUT: api/Student/5
        [HttpPut]
        public async Task<IActionResult> UpdateStudent([FromBody] UpdateStudentModel updateStudentModel)
        {
            UpdateStudentDto updateStudentDto = _mapper.Map<UpdateStudentDto>(updateStudentModel);
            await _studentService.UpdateStudentAsync(updateStudentDto);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{studentId}")]
        public async Task<IActionResult> DeleteStudent(int studentId)
        {
            await _studentService.DeleteStudent(studentId);
            return Ok();
        }
    }
}
