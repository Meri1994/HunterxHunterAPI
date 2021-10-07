using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utility;

namespace HunterxHunterAPI.Models
{
    public class Personaggi : Entity
    {
        public Personaggi(int id, string name, int power, DateTime dob) : base(id)
        {
            Name = name;
            Power = power;
            Dob = dob;
        }

        public string Name { get; set; }

        public int Power { get; set; }
        public DateTime Dob { get; set; }

        public Personaggi() { }



    }
}
