using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperAdventure
{
   [XmlRoot("hero")]
    public class Hero
    {
        [XmlElement("firstname")]
        public string FirstName { get; set; }
        [XmlElement("title")]
        public string Title { get; set; }
        [XmlElement("town")]
        public Town town { get; set; }
        [XmlElement("mindamage")]
        public int MinDamage { get; set; }
        [XmlElement("maxdamage")]
        public int MaxDamage { get; set; }
        [XmlElement("currenthealth")]
        public int CurrentHealth { get; set; }
        [XmlElement("maxhealth")]
        public int MaxHealth { get; set; }
        [XmlElement("coins")]
        public int Coins { get; set; }
        public int ID { get; set; }
        public static int HeroCounter;

        public string FullName()
        {
            return FirstName + " " + Title;
        }
        public Hero()
        {
            Title = "the Peasant";
            MinDamage = 1;
            MaxDamage = 3;
            MaxHealth = 20;
            CurrentHealth = MaxHealth;
            Coins = 0;
            ID = HeroCounter++;
        }
    }
}
