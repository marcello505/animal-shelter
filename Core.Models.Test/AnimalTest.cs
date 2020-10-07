using System;
using Xunit;

namespace Core.Models.Test
{
    public class AnimalTest
    {
        [Fact]
        public void EstimatedAgeSetsAge()
        {
            //Arrange
            Animal sut = new Animal();
            //Act
            sut.EstimatedAge = 20;
            //Assert
            Assert.Equal(20, sut.Age);
        }
        
        [Fact]
        public void DateOfBirthSetsAge()
        {
            //Arrange
            Animal sut = new Animal();
            //Act
            sut.DateOfBirth = DateTime.Today.AddYears(-21);
            //Assert
            Assert.Equal(21, sut.Age);
        }

        [Fact]
        public void EstimatedAgeAndDateOfBirthBothSetRetrunsError()
        {
            //Arrange
            Animal sut = new Animal();
            //Act
            sut.DateOfBirth = DateTime.Today.AddYears(-1);
            sut.EstimatedAge = 1;
            //Assert
            Assert.Throws<InvalidOperationException>(() => sut.Age);
        }

        [Fact]
        public void EstimatedAgeOrDateOfBirthMustBeFilled()
        {
            //Arrange
            Animal sut = new Animal();
            //Act
            //Blank
            //Assert
            Assert.Throws<InvalidOperationException>(() => sut.Age);
        }
    }
}
