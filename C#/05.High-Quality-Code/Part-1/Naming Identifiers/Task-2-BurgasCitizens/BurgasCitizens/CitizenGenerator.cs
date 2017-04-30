using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgasCitizens
{
    public class CitizenGenerator
    {
        public static Citizen Create(int age)
        {
            var citizen = new Citizen();
            citizen.Age = age;

            if (age % 2 == 0)
            {
                citizen.Title = "The Batka";
                citizen.Type = TypeOfCitizen.GymAddictedIndividual;
            }
            else
            {
                citizen.Title = "The Queen";
                citizen.Type = TypeOfCitizen.BeautifulWoman;
            }

            return citizen;
        }
    }
}
