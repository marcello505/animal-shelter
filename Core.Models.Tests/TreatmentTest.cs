using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Core.DomainServices;
using Xunit.Sdk;

namespace Core.Models.Test
{
    public class TreatmentTest
    {
        //BR_4-1
        [Fact]
        public void SomeTreatmentsRequireDescriptions()
        {
            //Arrange
            var sut1 = new Treatment();
            var sut2 = new Treatment();
            var sut3 = new Treatment();
            var sut4 = new Treatment();

            //Act
            sut1.Type = Treatment.Types.Chipping;
            sut2.Type = Treatment.Types.Vaccination;
            sut3.Type = Treatment.Types.Operation;
            sut4.Type = Treatment.Types.Euthanasia;

            //Assert
            Assert.False(sut1.IsValid());
            Assert.False(sut2.IsValid());
            Assert.False(sut3.IsValid());
            Assert.False(sut4.IsValid());
        }

        //BR_4-2
        [Fact]
        public void SomeTreatmentsDontNeedDescriptions()
        {
            //Arrange
            var sut1 = new Treatment();
            var sut2 = new Treatment();

            //Act
            sut1.Type = Treatment.Types.Sterilization;
            sut2.Type = Treatment.Types.Castration;

            //Assert
            Assert.True(sut1.IsValid());
            Assert.True(sut2.IsValid());
        }

        //BR_3
        [Fact]
        public void AnimalsThatHavePassedCantReceiveTreatment()
        {
            //Arrange
            var sut = new Treatment();
            var animal = new Animal();

            //Act
            animal.DateOfDeath = DateTime.Today;

            //Assert
            Assert.False(sut.CanAssignAnimal(animal));
        }
    }
}
