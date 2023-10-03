using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace logerror
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-KIR58TR\SQLEXPRESS01;Initial Catalog=formerror;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Please enter  email and password.");
                    return;
                }

                string s = "select email,password from loginerror WHERE email=@email AND password=@password";
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.Parameters.AddWithValue("@email", textBox1.Text);
                cmd.Parameters.AddWithValue("@password", textBox2.Text);

                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        MessageBox.Show("Login successful");
                    }
                    else
                    {
                        MessageBox.Show("Invalid email or password. Please try again.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();

            }
        }

      

       

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {

                MessageBox.Show("saved");

            }
            else
            {

                MessageBox.Show("");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            signupform form = new signupform();
            form.ShowDialog();
            this.Close();
        }
    }


    
}
