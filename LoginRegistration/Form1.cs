using System.Data;
using System.Data.SqlClient;

namespace LoginRegistration
{
    public partial class Form1 : Form
    {
        
        string connectionString = @"Data Source=DESKTOP-L2J9UQN\SQLEXPRESS;Initial Catalog=MyDB;Integrated Security=True;Encrypt=False";
        public Form1()
        {
            InitializeComponent();
           
            
        }

        private void btnSubmit_Click(object sender, EventArgs e)

       
        {
            if (txtUsername.Text == "" || txtPassword.Text == "")
                MessageBox.Show("Please fill it");
            else if (txtPassword.Text != txtConfirmPassword.Text)
                MessageBox.Show("Password do not matched");
            else
            {



                using (SqlConnection sqlCon = new SqlConnection(connectionString))

                {
                    sqlCon.Open();
                    SqlCommand sqlCmd = new SqlCommand("UserAdd", sqlCon);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Username", txtUsername.Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Password", txtPassword.Text.Trim());
                    sqlCmd.ExecuteNonQuery();

                    MessageBox.Show("Registration is successful");

                    clear();

                  
                }
            }


        }
        void clear()
        {
            txtFirstName.Text = txtLastName.Text = txtUsername.Text = txtPassword.Text = txtConfirmPassword.Text=" ";

        }
    }
}
