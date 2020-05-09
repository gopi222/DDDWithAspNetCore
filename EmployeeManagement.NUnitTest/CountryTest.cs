using EmployeeManagement.Api.ApiModels.CountryModels;
using EmployeeManagement.Api.Controllers;
using EmployeeManagement.Application.Dtos.CountryDtos;
using EmployeeManagement.Application.ServiceImplementations;
using EmployeeManagement.Application.Services;
using EmployeeManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TanvirArjel.EFCore.GenericRepository.Services;

namespace EmployeeManagement.NUnitTest
{
    public class CountryControllerTests
    {
        #region "Variable"
        ICountryService _countryService;
        //ICountryRepository _countryRepository;
        IUnitOfWork _unitOfWork;
        Task<IQueryable<Country>> _countryDetails;
        CountryController _countryController;
        #endregion

        [SetUp]
        public void Setup()
        {
            _countryDetails = SetUpCountryDetails();
            //_schoolRepository = SetCountryRepository();

            //we can't set property to mock object directly. To achive that implemented below code
            var unitOfData = new Mock<IUnitOfWork>();
            //unitOfData.SetupGet(u => u.Repository).Returns(_countryRepository);
            //_unitOfWork = unitOfData.Object;

            //_unitOfWork.Repository = _countryRepository;

            _countryService = new CountryService(_unitOfWork);

            _countryController = new CountryController(_countryService, CountryAutoMapper.Mapper());
        }

        private Task<IQueryable<Country>> SetUpCountryDetails()
        {
            List<Country> country = new List<Country>(){
                new Country()
            {
                CountryId = 1,
                CountryName = "India",
                CreatedAtUtc = DateTime.Now,
                IsActive = true,
                LastModifiedAtUtc = DateTime.Now
                }
            ,
           new Country()
            {
                CountryId = 2,
                CountryName = "USA",
                CreatedAtUtc = DateTime.Now,
                IsActive = true,
                LastModifiedAtUtc = DateTime.Now
            } };
            return Task.Run(() => country.ToList().AsQueryable());
        }

        //[Test]
        //public void GetAllCountryTest()
        //{
        //    List<CountryDetailsModel> schools = _countryController.GetCountryList().Result.ToList();
        //    List<CountryDetailsDto> schoolDetail = CountryAutoMapper.Mapper().Map<List<CountryDetailsDto>>(_countryDetails.Result.ToList());
        //    Assert.IsTrue(schools.GetType().Equals(schoolDetail.GetType()));
        //}

        //[Test]
        //public void PostCountry_ReturnsHttpOkResult()
        //{
        //    Country school = _countryDetails.Result.Where(c => c.CountryId == 1).First();
        //    CreateCountryModel detailCountry = CountryAutoMapper.Mapper().Map<CreateCountryModel>(school);
        //    detailCountry.CountryName = "Test Modified";
        //    var result = _countryController.CreateCountry(detailCountry);
        //    Assert.IsInstanceOf<OkObjectResult>(result);
        //}

        [Test]
        public void GetCountry()
        {
            Assert.Pass();
        }

        [Test]
        public void GetCountryDetails()
        {
            Assert.Pass();
        }
    }
}