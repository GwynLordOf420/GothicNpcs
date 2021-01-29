using Microsoft.Win32;
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
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace GothicNpcs
{
    /// <summary>
    /// Logika interakcji dla klasy Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private List<npcs1> gnpcList = null;
        private string NumerId;
        private string where;

        public Window2(string text)
        {
            string id = text;
            NumerId = text;
            InitializeComponent();
            InitBinding(id);
        }

        private void InitBinding(string id)
        {
            gnpcList = new List<npcs1>();
            try
            {
                using (var reader = new StreamReader("npcList.xml"))
                {
                    XmlSerializer deserializer = new XmlSerializer(typeof(List<npcs1>),
                        new XmlRootAttribute("ArrayOfNpcs1"));
                    gnpcList = (List<npcs1>)deserializer.Deserialize(reader);
                }
            }
            catch
            {
                MessageBox.Show("No image to load.", "Warning", MessageBoxButton.OK);
            }
            npcs1 gfnpc = gnpcList.Find(oElement => oElement.npcId == Convert.ToInt32(NumerId));
            npcId.Text = Convert.ToString(gfnpc.npcId);
            Name.Text = gfnpc.npcName;
            Believs.Text = gfnpc.believs;
            Level.Text = Convert.ToString(gfnpc.npcLevel);
            NpcRole.Text =gfnpc.townRole;
            NumerId = id;
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            NpcRole.IsEnabled = true;
            Name.IsEnabled = true;
            Believs.IsEnabled = true;
            Level.IsEnabled = true;
            insert.IsEnabled = true;

        }

        private void Save(object sender, RoutedEventArgs e)
        {
            npcs1 gfnpc = gnpcList.Find(oElement => oElement.npcId == Convert.ToInt32(NumerId));
            gfnpc.townRole = NpcRole.Text;
            gfnpc.npcName = Name.Text;
            gfnpc.believs = Believs.Text;
            gfnpc.npcLevel = Convert.ToInt16(Level.Text);
            gfnpc.image = where;

            MessageBox.Show("New data has been stored");

            var serializer = new XmlSerializer(gnpcList.GetType());
            using (var writer = XmlWriter.Create("npcList.xml"))
            {
                serializer.Serialize(writer, gnpcList);
            }
        }

        private void Insert_image(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files(*.jpg; *.jpeg; *.gif; *.png; *.bmp;)|*.jpg; *.jpeg; *.png; *.gif; *.bmp;";

            if (openFileDialog.ShowDialog() == true)
            {
                where = openFileDialog.FileName;
                Uri fileUri = new Uri(openFileDialog.FileName);
                ShowImage.Source = new BitmapImage(fileUri);
            }


        }
    }
}
