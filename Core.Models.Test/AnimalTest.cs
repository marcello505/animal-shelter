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
            sut.DateOfBirth = new DateTime(1998, 11, 30);
            //Assert
            Assert.Equal(21, sut.Age);
        }
    }
}
