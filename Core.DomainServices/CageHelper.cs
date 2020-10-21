using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DomainServices
{
    public static class CageHelper
    {
        public static int CalculateFreeSpots(this IEnumerable<Cage> cages)
        {
            var result = 0;
            foreach(var item in cages)
            {
                result += item.CalculateFreeSpots();
            }
            return result;
        }
        public static int CalculateFreeSpots(this Cage cage)
        {
            return cage.MaximumAnimals - cage.Animals.Count;
        }
    }
}
