using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    DAL d = new DAL();
    BAL b = new BAL();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillGrid();
        }
    }

    private void FillGrid()
    {
        GridView1.DataSource = b.GetAll();
        GridView1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        d.FirstName = txtfname.Text;
        d.LastName = txtlname.Text;
        d.City = txtcity.Text;
        b.Insert(d);
        FillGrid();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        d.ID = Convert.ToInt16(GridView1.DataKeys[e.RowIndex].Value);
        b.Delete(d);
        FillGrid();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        FillGrid();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        FillGrid();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        d.ID = Convert.ToInt16(GridView1.DataKeys[e.RowIndex].Value);
        d.FirstName = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox1")).Text;
        d.LastName = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox2")).Text;
        d.City = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("TextBox3")).Text;
        b.Update(d);
        GridView1.EditIndex = -1;
        FillGrid();
    }
}