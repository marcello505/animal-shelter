//using Core.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Xunit;

//namespace Infrastructure.Tests
//{
//    public class AnimalSqlRepositoryTest : IDisposable
//    {
//        private readonly string CLEAN_UP_STRING = "TESTRECORDSAFE2DELETE";
//        private AnimalSqlRepository _context;

//        public AnimalSqlRepositoryTest()
//        {
//            _context = new AnimalSqlRepository();
//        }

//        [Fact]
//        public void GetAllReturnsTreatments()
//        {
//            //Arrange
//            var sut = _context.GetAll();
//            //Act
//            var result = sut.Where(a => a.Treatments.Any()).Count();
//            //Assert
//            Assert.True(result > 0);

//        }

//        [Fact]
//        public void AddWithTreatmentsWorks()
//        {
//            //Arrange
//            var sut = new Animal() {
//                Name = CLEAN_UP_STRING, Adoptable = true, Breed = "Lapjeskat", SafeForKids = true, EstimatedAge = 18, ReasonForLeavingOwner = "Kattekwaad", Gender = "f", DogOrCat = "cat", Description = "Vrouwlijke lapjeskat", DateOfArrival = DateTime.Today };
//            sut.Treatments = new List<Treatment>() { new Treatment() { Description = CLEAN_UP_STRING, TreatmentDoneBy = "Marcello", Type = Treatment.Types.Sterilization, DateOfTreatment = DateTime.Today } };
//            //Act
//            _context.Add(sut);
//            //Assert
//            Assert.Contains(new AnimalSqlRepository().GetAll(), a => a.Name == CLEAN_UP_STRING);

//        }

//        public void Dispose()
//        {
//            _context = new AnimalSqlRepository();
//            _context.Delete(_context.GetAll().Where(a => a.Name == CLEAN_UP_STRING));
//        }
//    }
//}
