using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.accountClasses
{
    class Information
    {
        //geter and setter p-roperties for our applications

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }

        static string myconnstr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        //Selecting Data from Database

        public DataTable Select()
        {
            //Step 1: Database Connection

            SqlConnection con = new SqlConnection(myconnstr);

            DataTable dt = new DataTable();

            try
            {
                //Step 2: writing sql query

                string sql = "SELECT * FROM information";

                //creating scmd using sql and con
                SqlCommand scmd = new SqlCommand(sql, con);

                //creating dataAdapter using scmd
                SqlDataAdapter dataAdapter = new SqlDataAdapter(scmd);

                con.Open();
                dataAdapter.Fill(dt);



            }catch(Exception ex){


            }finally{

                con.Close();
            }

            return dt;

        }


        //Inserting data to our database

       public bool Insert(Information i)
        {
            //creating a default return typ and setting it's value to false

            bool isSuccess = false;

            //step1: connecting database
            SqlConnection con = new SqlConnection(myconnstr);
           // Console.WriteLine(con);
            try
            {
                //Step 2: Creating a sql query for inserting data

                String sql = "INSERT INTO information(Name,Email,Phone,Gender) VALUES (@Name,@Email,@Phone,@Gender)";

                //Console.WriteLine(sql);

               // Console.WriteLine(i.Name);
               // Console.WriteLine(i.Email);
               // Console.WriteLine(i.Phone);
               // Console.WriteLine(i.Gender);


                //Creating a sql scmd usinf sql and con

                SqlCommand scmd = new SqlCommand(sql, con);

                //Creating a papameter to add values

                scmd.Parameters.AddWithValue("Name",i.Name);
                scmd.Parameters.AddWithValue("Email", i.Email);
                scmd.Parameters.AddWithValue("@Phone", i.Phone);
                scmd.Parameters.AddWithValue("@Gender", i.Gender);

                //Connection open hear

                con.Open();

                int rows = scmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;
                }else
                {
                    isSuccess = false;
                }


            }catch(Exception ex)
            {

            }finally{

                con.Close();
            }

            return isSuccess;

        }

        //Update data for our applications

        public bool Update(Information i)
        {
            bool isSuccess = false;
           

            SqlConnection con = new SqlConnection(myconnstr);
            try {

                String sql = "UPDATE information SET Name=@Name,Email=@Email,Phone=@Phone,Gender=@Gender WHERE Email=@Email";

                SqlCommand scmd = new SqlCommand(sql, con);
                scmd.Parameters.AddWithValue("@Name", i.Name);
                scmd.Parameters.AddWithValue("@Email", i.Email);
                scmd.Parameters.AddWithValue("@Phone", i.Phone);
                scmd.Parameters.AddWithValue("@Gender", i.Gender);

                con.Open();

                int rows = scmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            } catch (Exception e) {
            } finally {
                con.Close();
            }

            return isSuccess;
        }
        //***********************************************


        //Delete method

        public bool Delete(Information i)
        {
            bool isSuccess = false;

            SqlConnection con = new SqlConnection(myconnstr);

            try
            {

                String sql = "DELETE FROM information WHERE Email=@Email";

                SqlCommand scmd = new SqlCommand(sql, con);
                scmd.Parameters.AddWithValue("@Email", i.Email);

                con.Open();

                int rows = scmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception e)
            {
            }
            finally
            {
                con.Close();
            }


            return isSuccess;

        }

        
    }
}
