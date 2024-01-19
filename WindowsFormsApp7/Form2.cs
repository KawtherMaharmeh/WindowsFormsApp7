using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{

    public partial class Form2 : Form
    {
        string data = "Data Source = DESKTOP-IV0INRN\\SQLEXPRESS; Initial Catalog = employee; Integrated Security= True;";

        public Form2()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(data);
            con.Open();
            SqlCommand command = new SqlCommand("Insert into information values(@EmpID, @EmpName, @EmpSalary)", con);
            command.Parameters.AddWithValue("@EmpID", int.Parse(txtId.Text));
            command.Parameters.AddWithValue("@EmpName", txtId.Text);
            command.Parameters.AddWithValue("@EmpSalary", int.Parse(txtSalaary.Text));
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("add successfully");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(data);
            connection.Open();
            SqlCommand command = new SqlCommand("Update information Set EmpName=@EmpName, EmpSalary=@EmpSalary Where EmpID=@EmpID", connection);
            command.Parameters.AddWithValue("@EmpName", txtName.Text);
            command.Parameters.AddWithValue("@EmpSalary", int.Parse(txtSalaary.Text));
            command.Parameters.AddWithValue("@EmpID", int.Parse(txtId.Text));
            command.ExecuteNonQuery ();
            connection.Close();
            MessageBox.Show("update is successfully");

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(data);
            SqlCommand command = new SqlCommand("Delete information Where EmpID=@EmpID", connection);
            command.Parameters.AddWithValue("@EmpID", int.Parse(txtId.Text));
            connection.Open();
            command.ExecuteNonQuery ();
            connection.Close();
            MessageBox.Show("delete is successfully");

        }

        private void button1_Click(object sender, EventArgs e)
        {

            dg.DataSource = getdata();
        }
        DataTable getdata()
        {
            SqlConnection connection = new SqlConnection(data);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from information", connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }
    }
}
