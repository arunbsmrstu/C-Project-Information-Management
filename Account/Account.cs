using Account.accountClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Account
{
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
        }

        Information i = new Information();


        // for add data
        private void button1_Click(object sender, EventArgs e)
        {
            //Get the values from input fields 

            i.Name = textboxName.Text;
            i.Email = textboxEmail.Text;
            i.Phone = textboxPhone.Text;
            i.Gender = comboboxGender.Text;

           // Console.WriteLine(i.Name);
          //  Console.WriteLine(i.Email);
          //  Console.WriteLine(i.Phone);
         //   Console.WriteLine(i.Gender);

            bool success = i.Insert(i);



           if (success == true)
           {
               MessageBox.Show("Data is Inserted");
                Clear();
           }
           else
            {
               MessageBox.Show("Data is not Inserted");
           }


            //Load data in our dataTable

            DataTable dt = i.Select();
            dataView.DataSource = dt;


        }


        //for update oparetion
        private void button2_Click(object sender, EventArgs e)
        {
            //Get the values from input fields 

            i.Name = textboxName.Text;
            i.Email = textboxEmail.Text;
            i.Phone = textboxPhone.Text;
            i.Gender = comboboxGender.Text;


            bool success = i.Update(i);



            if (success == true)
            {
                MessageBox.Show("Data is Updated");
                Clear();
            }
            else
            {
                MessageBox.Show("Data is not Updated");
            }


            //Load data in our dataTable

            DataTable dt = i.Select();
            dataView.DataSource = dt;



        }

        private void label4_Click(object sender, EventArgs e)
        {

        }


        //for select oparetion
        private void Account_Load(object sender, EventArgs e)
        {
            //Load data in our dataTable

            DataTable dt = i.Select();
            dataView.DataSource = dt;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        

        private void dataView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the data from DataGrid view and load the text boxes 

            int rowIndex = e.RowIndex;

            textboxName.Text = dataView.Rows[rowIndex].Cells[0].Value.ToString();
            textboxEmail.Text = dataView.Rows[rowIndex].Cells[1].Value.ToString();
            textboxPhone.Text = dataView.Rows[rowIndex].Cells[2].Value.ToString();
            comboboxGender.Text = dataView.Rows[rowIndex].Cells[3].Value.ToString();
        }


        //for delete oparetion
        private void button3_Click(object sender, EventArgs e)
        {

            //Get the values from input fields 

            i.Name = textboxName.Text;
            i.Email = textboxEmail.Text;
            i.Phone = textboxPhone.Text;
            i.Gender = comboboxGender.Text;


            bool success = i.Delete(i);



            if (success == true)
            {
                MessageBox.Show("Data is Deleted");
                Clear();
            }
            else
            {
                MessageBox.Show("Data is not Dewleted");
            }


            //Load data in our dataTable

            DataTable dt = i.Select();
            dataView.DataSource = dt;

        }

        //for clear
        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }


        //for search

        static string myconnstr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            //get the value from text box

            string keyword = textSearch.Text;

            SqlConnection scon = new SqlConnection(myconnstr);

            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM information WHERE Name LIKE '%" + keyword + "%' OR Email LIKE '%"+keyword+"%' OR Phone LIKE '%"+keyword+"%' OR Gender LIKE '%"+keyword+"%'", scon);

            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataView.DataSource = dt;

        }

        //Method to cleart the field

        public void Clear()
        {

            textboxName.Text = " ";
            textboxEmail.Text = " ";
            textboxPhone.Text = " ";
            comboboxGender.Text = " ";
            
        }
    }
}
