using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BAL
/// </summary>
public class BAL
{
    SqlConnection con = new SqlConnection(@"Server=0213f5ee-3206-46a1-8a29-a3ea00be4fc9.sqlserver.sequelizer.com;Database=db0213f5ee320646a18a29a3ea00be4fc9;User ID=cwkjakaqcmzqzawb;Password=mZj2eiWJ2z5eA8uZmPVmDXKDNrzpknmpJqMDNgb6fWDHC5nfhcBqnPGwoMnURGyM");
    SqlCommand cmd;
    SqlDataAdapter da;
    DataTable dt;
    
    public BAL()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable GetAll()
    {
        cmd = new SqlCommand("person_all", con);
        cmd.CommandType = CommandType.StoredProcedure;
        da = new SqlDataAdapter(cmd);
        dt = new DataTable();
        da.Fill(dt);
        return dt;
    }

    public void Insert(DAL data)
    {
        cmd = new SqlCommand("person_insert", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@fname", data.FirstName);
        cmd.Parameters.AddWithValue("@lname", data.LastName);
        cmd.Parameters.AddWithValue("@city", data.City);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public void Delete(DAL data)
    {
        cmd = new SqlCommand("person_delete", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id",data.ID);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }

    public void Update(DAL data)
    {
        cmd = new SqlCommand("person_update", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id", data.ID);
        cmd.Parameters.AddWithValue("@fname", data.FirstName);
        cmd.Parameters.AddWithValue("@lname", data.LastName);
        cmd.Parameters.AddWithValue("@city", data.City);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
}