using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurgasCitizens
{
    public class Citizen
    {
        private TypeOfCitizen type;
        private string title;
        private int age;
        private int level;
        private bool adidas;

        public Citizen()
        {

        }
        
        public Citizen(int age, bool adidas)
        {
            this.Adidas = adidas;
            this.Age = age;
        }

        public TypeOfCitizen Type {
           get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }

        public int Level
        {
            get
            {
                return this.level;
            }
            set
            {
                if(Adidas == true)
                {
                    this.level = 100;
                }
                else
                {
                    this.level = 15;
                }
            }
        }

        public int Age { get; set; }

        public bool Adidas { get; set; }

    }
}
