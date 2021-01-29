using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xaml;
using System.Xml.Serialization;

namespace GothicNpcs
{
    public class npcs1
    {
        [XmlAttribute("id")]
        public int npcId { get; set; }
        [XmlElement("townRole")]
        public string townRole { get; set; }
        [XmlElement("Name")]
        public string npcName { get; set; }
        [XmlElement("Believs")]
        public string believs { get; set; }
        [XmlElement("Level")]
        public int npcLevel { get; set; }
        [XmlElement("Image")]
        public string image { get; set; }

        public npcs1(int gnpcId, string gnpcRole, string gnpcName, string gbelievs, int gnpcLevel, string gimage)
        {
            npcId = gnpcId;
            npcName = gnpcName;
            believs = gbelievs;
            townRole = gnpcRole;
            npcLevel = gnpcLevel;
            image = gimage;
        }

        public npcs1()
        {
            npcId = 0;
            npcName = "Xardas";
            believs = "Beliar";
            townRole = "Necromancer";
            npcLevel = 21;
            image = "C:\\Users\\CUNTCRUSHER\\Desktop\\obrazy\\Yuri_portrait.jpg";
        }
    }
}
