using Core.DomainServices;
using Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.Models
{
    public static class ViewModelHelpers
    {
        public static List<AnimalViewModel> ToViewModel(this IEnumerable<Animal> animals)
        {
            var result = new List<AnimalViewModel>();

            foreach(var animal in animals)
            {
                result.Add(animal.ToViewModel());
            }
            return result;
        }
        public static AnimalViewModel ToViewModel(this Animal animal)
        {
            var result = new AnimalViewModel
            {
                Id = animal.Id,
                Name = animal.Name,
                Age = animal.Age.Value,
                Description = animal.Description,
                DogOrCat = animal.DogOrCat,
                Breed = animal.Breed,
                Gender = animal.Gender,
                DateOfArrival = animal.DateOfArrival,
                CastratedOrSterilized = animal.CastratedOrSterilized,
                SafeForKids = animal.SafeForKids,
                Adoptable = animal.Adoptable,
            };

            if (animal.Treatments != null)
            {
                var stringToBuild = new StringBuilder();
                foreach(Treatment treatment in animal.Treatments)
                    {
                        stringToBuild.Append(treatment.Type.ToString());
                        stringToBuild.Append(";");
                    }
                result.Treatments = stringToBuild.ToString();
            }

            return result;
        }

        public static List<CageViewModel> ToViewModel(this IEnumerable<Cage> cages)
        {
            var result = new List<CageViewModel>();

            foreach(var cage in cages)
            {
                result.Add(cage.ToViewModel());
            }
            return result;
        }
        public static CageViewModel ToViewModel(this Cage cage)
        {
            var result = new CageViewModel
            {
                Id = cage.Id,
                MaximumAnimals = cage.MaximumAnimals
            };

            if (cage.Animals != null)
            {
                var stringToBuild = new StringBuilder();
                foreach(var item in cage.Animals)
                {
                    stringToBuild.Append(item.Name);
                    stringToBuild.Append(";");
                }
                result.Animals = stringToBuild.ToString();
            }

            return result;
        }

        public static Animal ToDomainModel(this NewAnimalViewModel newAnimal)
        {
            var result = new Animal
            {
                Id = newAnimal.Id,
                Name = newAnimal.Name,
                DateOfBirth = newAnimal.DateOfBirth,
                EstimatedAge = newAnimal.EstimatedAge,
                Description = newAnimal.Description,
                DogOrCat = newAnimal.DogOrCat,
                Breed = newAnimal.Breed,
                Gender = newAnimal.Gender,
                ImageURL = newAnimal.ImageURL,
                DateOfArrival = newAnimal.DateOfArrival,
                DateOfAdoption = newAnimal.DateOfAdoption,
                DateOfDeath = newAnimal.DateOfDeath,
                CastratedOrSterilized = newAnimal.CastratedOrSterilized,
                SafeForKids = newAnimal.SafeForKids,
                ReasonForLeavingOwner = newAnimal.ReasonForLeavingOwner,
                Adoptable = newAnimal.Adoptable,
                AdoptedBy = newAnimal.AdoptedBy,
                CageId = newAnimal.CageId
            };
            return result;
        }

        public static Cage ToDomainModel(this NewCageViewModel newCage)
        {
            var result = new Cage
            {
                MaximumAnimals = newCage.MaximumAnimals
            };
            return result;
        }

        public static void FindFreeCages(this ICollection<SelectListItem> freeCages, ICageRepository context)
        {
            var stringToBuild = new StringBuilder();
            foreach(var cage in context.GetAllFreeCages())
            {
                stringToBuild.Clear();
                stringToBuild.Append("Id: ").Append(cage.Id).Append(" Spots left: ").Append(cage.MaximumAnimals - cage.Animals.Count);

                freeCages.Add(new SelectListItem { Value = cage.Id.ToString(), Text = stringToBuild.ToString() });
            }
        }
    }
}
