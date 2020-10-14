using System;
using System.Collections.Generic;
using Xunit;

namespace Core.Models.Test
{
    public class AnimalTest
    {
        //BR_5-1
        [Fact]
        public void EstimatedAgeSetsAge()
        {
            //Arrange
            var sut = new Animal();
            sut.EstimatedAge = 20;
            
            //Act
            var result = sut.Age;
            
            //Assert
            Assert.Equal(20, result);
        }
        
        //BR_5-2
        [Fact]
        public void DateOfBirthSetsAge()
        {
            //Arrange
            var sut = new Animal();
            sut.DateOfBirth = DateTime.Today.AddYears(-21);
            
            //Act
            var result = sut.Age;
            
            //Assert
            Assert.Equal(21, result);
        }

        //BR_5-3
        [Fact]
        public void EstimatedAgeAndDateOfBirthBothSetRetrunsError()
        {
            //Arrange
            var sut = new Animal();
            
            //Act
            sut.DateOfBirth = DateTime.Today.AddYears(-1);
            sut.EstimatedAge = 1;
            
            //Assert
            Assert.Throws<InvalidOperationException>(() => sut.Age);
        }

        //BR_5-4
        [Fact]
        public void EstimatedAgeOrDateOfBirthMustBeFilled()
        {
            //Arrange
            var sut = new Animal();
            
            //Assert
            Assert.Throws<InvalidOperationException>(() => sut.Age);
        }

        [Fact]
        public void CastratedOrSterilizedGetterWorks()
        {
            //Arrange
            var sut = new Animal();
            var treatment = new Treatment();
            treatment.Type = Treatment.Types.Castration;
            sut.Treatments = new List<Treatment>()
            {
                treatment
            };
            
            //Act
            var result = sut.CastratedOrSterilized;
            
            //Assert
            Assert.True(result);
        }
        
        [Fact]
        public void CastratedOrSterilizedGetterReturnsFalseWithDifferentTreatments()
        {
            //Arrange
            var sut = new Animal();
            var treatment = new Treatment();
            treatment.Type = Treatment.Types.Operation;
            sut.Treatments = new List<Treatment>()
            {
                treatment
            };
            
            //Act
            var result = sut.CastratedOrSterilized;
            
            //Assert
            Assert.False(result);
        }
        
        [Fact]
        public void CastratedOrSterilizedGetterReturnsFalseByDefault()
        {
            //Arrange
            var sut = new Animal();
            
            //Act
            var result = sut.CastratedOrSterilized;
            
            //Assert
            Assert.False(result);
        }
        
        [Fact]
        public void CastratedOrSterilizedGetterReturnsTrueAfterSet()
        {
            //Arrange
            var sut = new Animal();
            sut.CastratedOrSterilized = true;
            
            //Act
            var result = sut.CastratedOrSterilized;
            
            //Assert
            Assert.True(result);
        }
    }
}
