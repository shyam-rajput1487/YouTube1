using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace WebFormCrudApp1
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=DESKTOP-Q6DM7AN\\SQLEXPRESS;Initial Catalog=SM;Integrated Security=True;TrustServerCertificate=True";
        public Form1()
        {
            InitializeComponent();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnShow(object sender, EventArgs e)
        {
            //1. Address of sql server and database name
        
            //2. Stablish Connection
            SqlConnection con=new SqlConnection(connectionString);

            //3. Open Connection
            con.Open();

            //4.prepare sql Query
            string query = "select *from stu";
            SqlCommand cmd = new SqlCommand(query, con);

            //5. Esecute query C# sqlcommand class
            var reader =cmd.ExecuteReader();
            reader.Read();
            //var Sid = reader["Sid"];
            //var Name = reader["Name"];
            //var Age = reader["age"];

            //dataGridView1.AutoGenerateColumns = false;

            // Add columns programmatically
            //dataGridView1.Columns.Add("Sid", "ID");
            //dataGridView1.Columns.Add("Name", "Name");
            //dataGridView1.Columns.Add("age", "Age");
           
            //while (reader.Read())
            //{
            //    dataGridView1.Rows.Add(reader["Sid"], reader["Name"], reader["Age"]);
            //}

            dataGridView1.Rows.Clear();
            while (reader.Read())
            {
                dataGridView1.Rows.Add(reader["Sid"], reader["Name"], reader["age"]);
            }

            //label4.Text = $"Hello, {Name}! Welcome to Windows Forms.";
            //6.close
            con.Close();       
        }

        private void Insert(object sender, EventArgs e)
        {
            //1. Address of sql server and database name
            //string connectionString = "Data Source=DESKTOP-Q6DM7AN\\SQLEXPRESS;Initial Catalog=SM;Integrated Security=True;TrustServerCertificate=True";

            //2.Establish Connection 
            SqlConnection con = new SqlConnection(connectionString);

            //3.open connection
            con.Open();

            //4. Prapare Query 
            int SId = Convert.ToInt32(txtId.Text);
            string Name = txtName.Text;
            int Age = Convert.ToInt32(txtAge.Text);
            string Query = "insert into stu(SId,Name,Age)  values(" + SId + ",'" + Name + "','" + Age + "')";
            //string Query = "delete from stu where sid="+SId+" ";

            //5. Execute query 
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();
            //6. Close Connection
            con.Close();
            MessageBox.Show("Data are inserted");
        }

        private void Delete(object sender, EventArgs e)
        {   //1. Address of sql server and database name
            //string connectionString = "Data Source=DESKTOP-Q6DM7AN\\SQLEXPRESS;Initial Catalog=SM;Integrated Security=True;TrustServerCertificate=True";
           
            //2. Stablish connection
           SqlConnection con=new SqlConnection(connectionString);
            
            //3. Open connection 
            con.Open();

            //4. Prepare Query
            string stuId=txtId.Text;
            string query = "delete from stu where sid="+stuId+"";

            //5. Execute query
            SqlCommand cmd=new SqlCommand(query, con);
            cmd.ExecuteNonQuery();

            //6. Connection close
            con.Close();
            MessageBox.Show("Data are Delete");
        }

        private void update(object sender, EventArgs e)
        {
            //1. Address of sql server and database name
            //string connectionString = "Data Source=DESKTOP-Q6DM7AN\\SQLEXPRESS;Initial Catalog=SM;Integrated Security=True;TrustServerCertificate=True";
            
            //2. Stablish connection 
            SqlConnection con = new SqlConnection(connectionString);
            
            //3. Open connection
            con.Open();
            
            //4. Prepare query 
            string stuId = txtId.Text;
            string stuName = txtName.Text;
            string stuAge = txtAge.Text;
            string Query = "update stu set sid=" + stuId + ",name='" + stuName + "',age=" + stuAge + " where sid=" + stuId + "";
            
            //5. Execute query
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();

            //6. Close connection
            con.Close();
            MessageBox.Show("data has been submitted");          
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            //1. Address of sql server and database name
            //string connectionString = "Data Source=DESKTOP-Q6DM7AN\\SQLEXPRESS;Initial Catalog=SM;Integrated Security=True;TrustServerCertificate=True";
            //2. stablish connection 
            SqlConnection con = new SqlConnection(connectionString);
            //3. Open Connection 
            con.Open();

            //4. Prepare query
            string stuId = txtId.Text;
            string query = "select name,age from stu where sid=" + stuId + "";
            //5. Execute query
            SqlCommand cmd = new SqlCommand(query, con);
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtName.Text = reader["Name"].ToString();
                txtAge.Text = reader["Age"].ToString();
            }

            //6 close connection
            con.Close() ;
            MessageBox.Show("data has been submitted");
            
        }

        private void dataGridView1_CellContentClick(object sender,DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==3 && e.RowIndex > -1)
            {
                txtSid.HeaderText = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
           
        }
    }
}
