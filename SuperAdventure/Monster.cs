using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Security.Cryptography;

namespace SuperAdventure
{
    [XmlRoot("monster")]
    public abstract class Monster
    {
        public static int MonsterCounter;
        [XmlElement("id")]
        public int ID { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("maxhealth")]
        public int MaxHealth { get; set; }
        [XmlElement("currenthealth")]
        public int CurrentHealth { get; set; }
        [XmlElement("mindamage")]
        public int MinDamage { get; set; }
        [XmlElement("maxdamage")]
        public int MaxDamage { get; set; }
        public int Attack()
        {
            Random random = new Random();
            return random.Next(MinDamage, MaxDamage);
        }
        public Monster()
        {
            ID = ++MonsterCounter;
        }
    }
    [XmlRoot("skeleton")]
    public class Skeleton : Monster
    {
        public Skeleton()
        {
            Name = "Skeleton";
            MaxDamage = 2;
            MinDamage = 1;
            MaxHealth = 12;
            CurrentHealth = MaxHealth;
        } 
    }
    [XmlRoot("orc")]
    public class Orc : Monster
    {
        public Orc()
        {
            Name = "Orc";
            MaxDamage = 3;
            MinDamage = 1;
            MaxHealth = 16;
            CurrentHealth = MaxHealth;
        }
    }
}
