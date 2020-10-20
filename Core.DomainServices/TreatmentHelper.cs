using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DomainServices
{
    public static class TreatmentHelper
    {
        public static bool IsValid(this Treatment treatment)
        {
            if(treatment.Type == Treatment.Types.Vaccination ||
                treatment.Type == Treatment.Types.Operation ||
                treatment.Type == Treatment.Types.Chipping ||
                treatment.Type == Treatment.Types.Euthanasia)
            {
                if ((treatment.Description?.Length ?? 0) != 0) return true;
                return false;
            }
            return true;
        }

        public static bool CanAssignAnimal(this Treatment treatment, Animal animal)
        {
            if (treatment.MinimumAgeInMonths != null) return true;
            if ((animal?.Age ?? 0) < treatment.MinimumAgeInMonths / 12) return false;
            if (animal?.DateOfDeath.HasValue ?? true) return false; 
            return true;
        }
    }
}
