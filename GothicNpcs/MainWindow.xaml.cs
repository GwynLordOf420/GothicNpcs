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
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace GothicNpcs
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<npcs1> gnpcList = null;
        public MainWindow()
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
            if (gnpcList.Count == 0)
            {
                gnpcList.Add(new npcs1(1, "Necromancer", "Xardas", "Beliar", 20, "C:\\Users\\CUNTCRUSHER\\Desktop\\obrazy\\Yuri_portrait.jpg"));
                gnpcList.Add(new npcs1(2, "Water Mage", "Vatras", "Adanos", 25, "C:\\Users\\CUNTCRUSHER\\Desktop\\obrazy\\Yuri_portrait.jpg"));
                gnpcList.Add(new npcs1(3, "Fire Mage", "Pyrokar", "Innos", 23, "C:\\Users\\CUNTCRUSHER\\Desktop\\obrazy\\Yuri_portrait.jpg"));
            }
            lNpcs.ItemsSource = gnpcList;

        }

        private void _this_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var serializer = new XmlSerializer(gnpcList.GetType());
            using (var writer = XmlWriter.Create("npcList.xml"))
            {
                serializer.Serialize(writer, gnpcList);
            }
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            Window1 dodaj = new Window1();
            dodaj.Show();
        }

        public void DanePlik_Click(object sender, RoutedEventArgs e)
        {
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
            lNpcs.ItemsSource = gnpcList;
        }

        private void Edycja(object sender, RoutedEventArgs e)
        {
            Window2 win2 = new Window2(SzukaneId.Text);
            win2.Show();
        }

        private void Baza(object sender, RoutedEventArgs e)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=DESKTOP-G79GNH6;Database=GOTHIC;User ID=bepis; Password=diego ;";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            MessageBox.Show("Connection established");
            //cnn.Close();

            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";

            sql = "Select * From MyrtanaNpcs";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Output = Output + dataReader.GetValue(0) + "-" + dataReader.GetValue(1) + "-" + dataReader.GetValue(2) + "-" + dataReader.GetValue(3) + "-" + dataReader.GetValue(4) + "\n";
            }
            MessageBox.Show(Output);
            dataReader.Close();
            command.Dispose();
            cnn.Close();
        }

        private void Insert(object sender, RoutedEventArgs e)
        {
            Window3 win3 = new Window3();
            win3.Show();
        }
    }
}
