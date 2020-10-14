using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Core.Models.Test
{
    public class CageTest
    {
        //BR_1
        [Fact]
        public void MaximumAnimalsPropertyWorks()
        {
            //Arrange
            var animal1 = new Mock<Animal>();
            var animal2 = new Mock<Animal>();
            var sut = new Cage();
            bool result;

            //Act
            sut.MaximumAnimals = 1;
            sut.AddAnimalToCage(animal1.Object);
            result = sut.AddAnimalToCage(animal2.Object);

            //Assert
            Assert.False(result);
        }

        //BR_2
        [Fact]
        public void NonSterilizedAnimalsOfDifferentGendersCantBeTogether()
        {
            //Arrange
            var animal1 = new Animal();
            var animal2 = new Animal();
            var sut = new Cage();
            bool result;

            animal1.Gender = "f";
            animal2.Gender = "m";
            animal1.CastratedOrSterilized = false;
            animal2.CastratedOrSterilized = false;

            //Act
            sut.MaximumAnimals = 2;
            sut.AddAnimalToCage(animal1);
            result = sut.AddAnimalToCage(animal2);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void NormalBehaviorWorks()
        {
            //Arrange
            var animal1 = new Animal();
            var animal2 = new Animal();
            var sut = new Cage();
            bool result;

            animal1.Gender = "f";
            animal2.Gender = "f";
            animal1.CastratedOrSterilized = true;
            animal2.CastratedOrSterilized = true;
            animal1.DogOrCat = "dog";
            animal2.DogOrCat = "dog";

            //Act
            sut.MaximumAnimals = 2;
            sut.AddAnimalToCage(animal1);
            result = sut.AddAnimalToCage(animal2);

            //Assert
            Assert.True(result);
        }

    }
}
