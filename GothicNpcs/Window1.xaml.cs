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
using System.Xml.Serialization;


namespace GothicNpcs
{
    /// <summary>
    /// Logika interakcji dla klasy Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private string where;
        private List<npcs1> gnpcList = null;

        public Window1()
        {
            InitializeComponent();
            InitBinding();
        }

        private void InitBinding()
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
                MessageBox.Show("No image to load", "Warning", MessageBoxButton.OK);
            }

            Image image = new Image();
            BitmapImage bitmapImage = new BitmapImage(new Uri("C:\\Users\\CUNTCRUSHER\\Desktop\\obrazy\\Yuri_portrait.jpg"));
            Show_Image.Source = bitmapImage;
        }

        private void DodajStudenta_Click(object sender, RoutedEventArgs e)
        {


            var serializer = new XmlSerializer(gnpcList.GetType());
            gnpcList.Add(new npcs1(gnpcList.Count + 1, numerindeks.Text, imie.Text, nazwisko.Text, Convert.ToInt16(wiek.Text), where));
            using (var writer = XmlWriter.Create("npcList.xml"))
            {
                serializer.Serialize(writer, gnpcList);
            }
            MessageBox.Show("Added.");
        }

        public void WstawObraz_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files(*.jpg; *.jpeg; *.gif; *.png; *.bmp;)|*.jpg; *.jpeg; *.png; *.gif; *.bmp;";

            if (openFileDialog.ShowDialog() == true)
            {
                where = openFileDialog.FileName;
                Uri fileUri = new Uri(openFileDialog.FileName);
                Show_Image.Source = new BitmapImage(fileUri);
            }

        }
    }
}
