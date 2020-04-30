using EmployeeManagement.Application.Dtos.StudentDtos;
using EmployeeManagement.Application.Services;
using EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TanvirArjel.EFCore.GenericRepository.Services;

namespace EmployeeManagement.Application.ServiceImplementations
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<StudentDetailsDto>> GetStudentListAsync()
        {
            Expression<Func<Student, StudentDetailsDto>> selectExpression = e => new StudentDetailsDto
            {
                StudentId = e.StudentId,
                StudentName = e.StudentName,
                CountryId = e.CountryId,
                CountryName = e.Country.CountryName,
                DateOfBirth = e.DateOfBirth,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                SpokenLanguage = e.SpokenLanguage,
                IsActive = e.IsActive,
                CreatedAtUtc = e.CreatedAtUtc,
                LastModifiedAtUtc = e.LastModifiedAtUtc
            };

            List<StudentDetailsDto> studentDetailsDtos = await _unitOfWork.Repository<Student>()
                .GetProjectedEntityListAsync(selectExpression);

            return studentDetailsDtos;
        }

        public async Task<StudentDetailsDto> GetStudentDetailsAsync(int studentId)
        {
            Expression<Func<Student, StudentDetailsDto>> selectExpression = e => new StudentDetailsDto
            {
                StudentId = e.StudentId,
                StudentName = e.StudentName,
                CountryId = e.CountryId,
                CountryName = e.Country.CountryName,
                DateOfBirth = e.DateOfBirth,
                Email = e.Email,
                PhoneNumber = e.PhoneNumber,
                SpokenLanguage = e.SpokenLanguage,
                IsActive = e.IsActive,
                CreatedAtUtc = e.CreatedAtUtc,
                LastModifiedAtUtc = e.LastModifiedAtUtc
            };

            StudentDetailsDto studentDetailsDto = await _unitOfWork.Repository<Student>()
                .GetProjectedEntityByIdAsync(studentId, selectExpression);

            return studentDetailsDto;
        }

        public async Task CreateStudentAsync(CreateStudentDto createStudentDto)
        {
            if (createStudentDto == null)
            {
                throw new ArgumentNullException(nameof(createStudentDto));
            }

            Student studentToBeCreated = new Student()
            {
                StudentName = createStudentDto.StudentName,
                CountryId = createStudentDto.CountryId,
                DateOfBirth = createStudentDto.DateOfBirth,
                Email = createStudentDto.Email,
                PhoneNumber = createStudentDto.PhoneNumber,
                SpokenLanguage = createStudentDto.SpokenLanguage
            };
            await _unitOfWork.Repository<Student>().InsertEntityAsync(studentToBeCreated);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateStudentAsync(UpdateStudentDto updateStudentDto)
        {
            try
            {
                if (updateStudentDto == null)
                {
                    throw new ArgumentNullException(nameof(updateStudentDto));
                }

                Student studenteToBeUpdated = await _unitOfWork.Repository<Student>().GetEntityByIdAsync(updateStudentDto.StudentId);
                if (studenteToBeUpdated != null)
                {
                    studenteToBeUpdated.StudentName = updateStudentDto.StudentName;
                    studenteToBeUpdated.CountryId = updateStudentDto.CountryId;
                    studenteToBeUpdated.DateOfBirth = updateStudentDto.DateOfBirth;
                    studenteToBeUpdated.Email = updateStudentDto.Email;
                    studenteToBeUpdated.PhoneNumber = updateStudentDto.PhoneNumber;
                    studenteToBeUpdated.SpokenLanguage = updateStudentDto.SpokenLanguage;

                    _unitOfWork.Repository<Student>().UpdateEntity(studenteToBeUpdated);
                    await _unitOfWork.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteStudent(int studentId)
        {
            Student studenteToBeDeleted = await _unitOfWork.Repository<Student>().GetEntityByIdAsync(studentId);
            if (studenteToBeDeleted != null)
            {
                _unitOfWork.Repository<Student>().DeleteEntity(studenteToBeDeleted);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}
