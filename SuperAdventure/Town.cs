using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SuperAdventure
{
    [XmlRoot("town")]
    public class Town
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("id")]
        public byte ID { get; set; }
        [XmlArray("startdescription")]
        public string[] StartDescription = new string[2];
        [XmlArray("menudescription")]
        public string[] MenuDescription = new string[2];
    }
}
