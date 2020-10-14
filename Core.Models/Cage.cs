using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class Cage
    {
        [Key]
        public int Id { get; set; }

        private int _MaximumAnimals { get; set; }
        [Required]
        public int MaximumAnimals {
            get 
            {
                return _MaximumAnimals;
            }
            set
            {
                if (value < 0) _MaximumAnimals = 0;
                _MaximumAnimals = value;
            }
        }

        //Kooi logica.
        //Als je de lijst aanvraagt dan krijg je een ReadOnlyCollection terug, sinds je niet direct dingen in de lijst mag aanpassen.
        //Dit moet via de method AddAnimalToCage.
        private IList<Animal> _Animals { get; set; }
        public ReadOnlyCollection<Animal> Animals => (ReadOnlyCollection<Animal>)_Animals;
        public bool AddAnimalToCage(Animal animal)
        {
            if (_Animals == null) _Animals = new List<Animal>();

            if(_Animals.Count < MaximumAnimals)
            {
                //Als er animals in de kooi zitten, kijk of het geslacht en diersoort hetzelfde is.
                if(_Animals.Count != 0 && _Animals.Any(a => a.Gender == animal.Gender && a.DogOrCat == animal.DogOrCat))
                {
                    _Animals.Add(animal);
                    return true;
                }
                //Als de kooi leeg is, voeg het dier toe.
                else if(_Animals.Count == 0)
                {
                    _Animals.Add(animal);
                    return true;
                }
            }

            return false;
        }
        public bool AddAnimalToCage(IEnumerable<Animal> animals)
        {
            var result = true;
            foreach(Animal item in animals)
            {
                result = AddAnimalToCage(item);
            }
            return result;
        }

    }
}
