using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace GothicNpcs
{
    /// <summary>
    /// Interaction logic for Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void Insert_npc(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = null;
            string connectionString = @"Data Source=DESKTOP-G79GNH6;Database=GOTHIC;User ID=bepis; Password=diego ;";

            connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "insert into MyrtanaNpcs(npcId, npcName, believs, townRole, npcLevel ) values(@npcId, @npcName, @believs, @townRole, @npcLevel  )";

            cmd.Parameters.AddWithValue("@npcId", npcId.Text);
            cmd.Parameters.AddWithValue("@npcName", name.Text);
            cmd.Parameters.AddWithValue("@believs", believs.Text);
            cmd.Parameters.AddWithValue("@townRole", npcRole.Text);
            cmd.Parameters.AddWithValue("@npcLevel", npcLevel.Text);
            





            cmd.ExecuteNonQuery();
            MessageBox.Show("Success");
        }

        private void Insert_image(object sender, RoutedEventArgs e)
        {

        }
    }
}
