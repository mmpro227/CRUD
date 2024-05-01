using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LoginRegistration
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=DESKTOP-L2J9UQN\\SQLEXPRESS;Initial Catalog=MyDB;Integrated Security=True;Encrypt=False";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string Name= txtName.Text;
            string Age= txtAge.Text;
            string query = "insert into Details(Name, Age) values('"+Name+"', '"+Age+"')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data has been saved");



        }
    }
}
