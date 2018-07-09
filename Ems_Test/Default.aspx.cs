using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    dal da = new dal();
    void BindGridViewData()
    {
        if (!Page.IsPostBack)
        {
            GridView1.DataSource = da.displayAllEmployees();
            GridView1.DataBind();
            
        }


    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {

            
            Gender.DataSource = da.displaygender();
            Gender.DataTextField = "Gender";
            Gender.DataValueField = "GenderID";
            Gender.DataBind();


            EmployeeType.DataSource = da.displayEmployeeType();
            EmployeeType.DataTextField = "EmployeeType";
            EmployeeType.DataValueField = "EmployeeTypeID";
            EmployeeType.DataBind();


           GridView1.DataSource = da.displayAllEmployees();
           GridView1.DataBind();

        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
                //int found = dla.verify(txtContactNumber.Text);
        //if (found == 0)

        //call insEmployee Method and pass data

        da.insertEmployee(FirstName.Text, surname.Text,Convert.ToInt32(EmployeeType.SelectedValue),Convert.ToInt32(Gender.SelectedValue), Convert.ToInt32(Age.Text), Address.Text, Position.Text, ContactNumber.Text);
        //dla.insertEmployee(FirstName.Text, surname.Text, dla.getEmployeeType(EmployeeType.SelectedValue), dla.getGender(Gender.SelectedValue), Convert.ToInt32(Age.Text), Address.Text, Position.Text, ContactNumber.Text);
        //display success message to user

        lblmsg.Text = "Employee" + " " + FirstName.Text + " " + surname.Text + " " + "added successfully!";
        //Clear form data
        FirstName.Text = string.Empty;
        Age.Text = string.Empty;
        surname.Text = string.Empty;
        Address.Text = string.Empty;
        EmployeeType.SelectedIndex = 0;
        ContactNumber.Text = string.Empty;
        Gender.SelectedIndex = 0;

        GridView1.DataSource = da.displayAllEmployees();
        GridView1.DataBind();
    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "EditRow")
        {
            int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).NamingContainer).RowIndex;
            GridView1.EditIndex = rowIndex;

            GridView1.DataSource = da.displayAllEmployees();
            GridView1.DataBind();
        }
        else if (e.CommandName == "DeleteRow")
        {   
            da.sp_delete(Convert.ToInt32(e.CommandArgument));
         
            GridView1.DataSource = da.displayAllEmployees();
            GridView1.DataBind();
        }
     


    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}