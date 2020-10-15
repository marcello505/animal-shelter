﻿using Core.DomainServices;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure
{
    public class CageSqlRepository : ICageRepository
    {
        private AnimalShelterSqlContext _context;
        public CageSqlRepository()
        {
            _context = new AnimalShelterSqlContext();
        }

        public void Add(Cage cage)
        {
            _context.Cages.Add(cage);
            _context.SaveChanges();
        }

        public Cage Get(int id)
        {
            var animalRepository = new AnimalSqlRepository();
            var result = _context.Cages.SingleOrDefault(c => c.Id == id);
            if (result != null) result.AddAnimalToCage(animalRepository.GetByCageId(id));
            return result;
        }

        public IEnumerable<Cage> GetAll()
        {
            var animalRepository = new AnimalSqlRepository();
            var result = _context.Cages;
            foreach(Cage item in result)
            {
                item.AddAnimalToCage(animalRepository.GetByCageId(item.Id));
            }
            return result;
        }
    }
}
