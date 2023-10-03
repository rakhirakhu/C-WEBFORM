using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;

namespace logerror
{
    public partial class signupform : Form
    {
        private object getStudentsdetail;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-KIR58TR\SQLEXPRESS01;Initial Catalog=formerror;Integrated Security=True");
        public int studentid;
        private object id;

        public signupform()
        {
            InitializeComponent();
        }

        private void signupform_Load(object sender, EventArgs e)
        {
            GetStudentRecord();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void GetStudentRecord()
        {
            SqlCommand cmd = new SqlCommand("select * from loginerror", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO loginerror VALUES(@name,@dob,@age,@gender,@phone,@address,@state,@email,@password,@confirmpassword)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@age", textBox2.Text);
                string gender = "";
                if (radioButton1.Checked)
                {
                    gender = "Male";
                }
                else if (radioButton2.Checked)
                {
                    gender = "Female";
                }
                else if (radioButton3.Checked)
                {
                    gender = "Other";
                }
                else
                {
                    MessageBox.Show("Please select a gender.");
                    return;
                }

                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@phone", textBox3.Text);
                cmd.Parameters.AddWithValue("@address", textBox4.Text);
                cmd.Parameters.AddWithValue("@state", comboBox1.Text);
                cmd.Parameters.AddWithValue("@email", textBox5.Text);
                cmd.Parameters.AddWithValue("@password", textBox6.Text);
                cmd.Parameters.AddWithValue("@confirmpassword", textBox7.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("new student add is successfully saved", "saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetStudentRecord();
                resetform();
            }
        }


        private bool IsValid()
        {


            if (textBox1.Text == string.Empty)
            {
                MessageBox.Show("Name Is Required", "failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
            return true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            resetform();
        }

        private void resetform()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox1.Focus();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            studentid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            radioButton1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            radioButton2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            radioButton3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[9].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[10].Value.ToString();


        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (studentid > 0)
            {
                SqlCommand cmd = new SqlCommand("UPDATE loginerror SET name=@name,dob=@dob,age=@age,gender=@gender,phone=@phone,address=@address,state=@state,email=@email,password=@password,confirmpassword=@confirmpassword WHERE studentId=@studentId", con);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@dob", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@age", textBox2.Text);
                string gender = "";
                if (radioButton1.Checked)
                {
                    gender = "Male";
                }
                else if (radioButton2.Checked)
                {
                    gender = "Female";
                }
                else if (radioButton3.Checked)
                {
                    gender = "Other";
                }
                else
                {
                    MessageBox.Show("Please select a gender.");
                    return;
                }

                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@phone", textBox3.Text);
                cmd.Parameters.AddWithValue("@address", textBox4.Text);
                cmd.Parameters.AddWithValue("@state", comboBox1.Text);
                cmd.Parameters.AddWithValue("@email", textBox5.Text);
                cmd.Parameters.AddWithValue("@password", textBox6.Text);
                cmd.Parameters.AddWithValue("@confirmpassword", textBox7.Text);
                cmd.Parameters.AddWithValue("@studentId", this.studentid);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show(" student update successfully saved", "saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetStudentRecord();
                resetform();
            }
            else
            {
                MessageBox.Show(" select student for update", "saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (studentid > 0)
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM loginerror WHERE  studentId=@studentId", con);

                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("@studentId", this.studentid);


                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show(" student update successfully saved", "saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetStudentRecord();
                resetform();
            }
            else
            {

                MessageBox.Show("Name Is Required", "failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form = new Form1();
            form.ShowDialog();
            this.Close();
        }
    }
}

