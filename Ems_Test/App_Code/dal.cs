using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for dal
/// </summary>
public class dal
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["empcs"].ConnectionString);
    public dal()
    {

    }
    public SqlDataReader displayAllEmployees()
    {
        con.Close();
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from VWEMPLOYEE";
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();

            return dr;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void sp_delete(int @EmployeeId)
    {

        con.Close();
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandText = "EXECUTE SP_Delete @EmployeeId";
            SqlParameter param = new SqlParameter("@EmployeeId", EmployeeId);
            cmd.Parameters.Add(param);
            cmd.ExecuteNonQuery();

        }
        catch (Exception)
        {
            throw;
        }


    }

    public SqlDataReader displaygender()
    {
        con.Close();
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "EXECUTE displaygender";
            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();

            return dr;
        }
        catch (Exception)
        {
            throw;
        }


    }
    //return int value of selected gender type
    public int getGender(string gender)
    {
        con.Close();

        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "EXECUTE getGender @gender";
        cmd.Connection = con;
        int genderv = (int)cmd.ExecuteNonQuery();
        return genderv;
    }

    // return int value of selected EmployeeType
    public int getEmployeeType(string EmployeeType)
    {
        con.Close();

        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        SqlCommand cmd = con.CreateCommand();
        cmd.CommandText = "EXECUTE getEmployeeType @EmployeeType";
        cmd.Connection = con;
        int dodata = cmd.ExecuteNonQuery();

        //string foo = dr["EmployeeTypeID"].ToString() ;
        // int data = Convert.ToInt32(foo);
        return dodata;

    }
    public SqlDataReader displayEmployeeType()
    {
        con.Close();
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "EXECUTE displayEmployeeType";


            cmd.Connection = con;
            SqlDataReader dr = cmd.ExecuteReader();

            return dr;
        }
        catch (Exception)
        {
            throw;
        }
    }
    public void insertEmployee(String FirstName, String Surname, int EmployeeTypeID, int GenderID, int Age, String Address, String Position, string ContactNumber)
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }


            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Execute insertEmployee @FirstName,@Surname,@EmployeeTypeID,@GenderID,@Age,@Address,@Position,@ContactNumber";
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 40).Value = FirstName;
            cmd.Parameters.Add("@Surname", SqlDbType.VarChar, 50).Value = Surname;
            cmd.Parameters.Add("@EmployeeTypeID", SqlDbType.Int).Value = EmployeeTypeID;
            cmd.Parameters.Add("@GenderID", SqlDbType.Int).Value = GenderID;
            cmd.Parameters.Add("@Age", SqlDbType.Int).Value = Age;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar, 40).Value = Address;
            cmd.Parameters.Add("@Position", SqlDbType.VarChar, 40).Value = Position;
            cmd.Parameters.Add("@ContactNumber", SqlDbType.VarChar, 50).Value = ContactNumber;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void UpdateEmployee(String FirstName, String Surname, int EmployeeTypeID, int GenderID, int Age, String Address, String Position, string ContactNumber)
    {
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }


            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "Execute UpdateEmployee @FirstName,@Surname,@EmployeeTypeID,@GenderID,@Age,@Address,@Position,@ContactNumber";
            cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 40).Value = FirstName;
            cmd.Parameters.Add("@Surname", SqlDbType.VarChar, 50).Value = Surname;
            cmd.Parameters.Add("@EmployeeTypeID", SqlDbType.Int).Value = EmployeeTypeID;
            cmd.Parameters.Add("@GenderID", SqlDbType.Int).Value = GenderID;
            cmd.Parameters.Add("@Age", SqlDbType.Int).Value = Age;
            cmd.Parameters.Add("@Address", SqlDbType.VarChar, 40).Value = Address;
            cmd.Parameters.Add("@Position", SqlDbType.VarChar, 40).Value = Position;
            cmd.Parameters.Add("@ContactNumber", SqlDbType.VarChar, 50).Value = ContactNumber;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        catch (Exception)
        {
            throw;
        }
    }

}





    