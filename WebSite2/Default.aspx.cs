using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class _Default : System.Web.UI.Page
{
    public static Employee[] addEmployee = new Employee[3];

    public static int next = 0;
    public string name = "Andrea Derflinger";
    protected void Page_Load(object sender, EventArgs e)
    {
        /**{
            try
            {
                System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
                sc.ConnectionString = @"Server =Localhost           :;Database=Lab1;Trusted_Connection=Yes;";
            }
            catch (Exception)
            {
                resultmessage.Text = "Error Clearing Database.";
            }
        }
        **/
    }
    protected void InsertBtn_Click(object sender, EventArgs e)
    {
        addEmployee[next++] = new Employee(int.Parse(txtEmployeeID.Value),txtFirstName.Value, txtLastName.Value, txtMI.Value, DateTime.Parse(txtDOB.Value), txtHouseNumber.Value, txtStreet.Value, txtCity.Value, stateSelect.Value, txtCountry.Value, txtZip.Value,
          DateTime.Parse(txtHire.Value), DateTime.Parse(txtTerm.Value), int.Parse(txtManager.Value), double.Parse(txtSalary.Value), name, DateTime.Now);

    }

    protected void ClearBtn_Click(object sender, EventArgs e)
    {
        txtEmployeeID.Value = "";
        txtFirstName.Value = "";
        txtLastName.Value = "";
        txtMI.Value = "";
        txtDOB.Value = "";
        skillsSelect.Value = "";
        txtHouseNumber.Value = "";
        txtStreet.Value = "";
        txtCity.Value = "";
        stateSelect.Value = "";
        txtCountry.Value = "";
        txtZip.Value = "";
        txtHire.Value = "";
        txtTerm.Value = "";
        txtSalary.Value = "";
        txtManager.Value = "";
    }
    protected void EmployeeCommitBtn_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < next; i++)
        {
            EmployeeCommitInsert(addEmployee[i]);
        }
    }
    private void EmployeeCommitInsert(Employee e)
    {

        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = @"Server =Localhost           :;Database=Lab1;Trusted_Connection=Yes;";

        sc.Open();

        System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
        insert.Connection = sc;

        insert.CommandText = "insert into [dbo].[EMPLOYEE] values (" + e.EmployeeID + ", '" + e.FName + "', '" + e.LName + "', '" + e.MI + "', '" + "', '" + e.HouseNum + "', '" + e.Street +
            "', '" + e.CityCountry + "', '" + e.State + "', '" + e.Country + "', '" + e.Zip + "', '"  + e.DOB + "', '" + e.HireDate + "', '" + e.TermDate + "', " + e.Salary + ", " + e.ManagerID + ", '" + e.LastUpdatedBy + "', '" + e.LastUpdated + "')";

        insert.ExecuteNonQuery();
        sc.Close();

    }


    protected void ExitBtn_Click(object sender, EventArgs e)
    {

    }

}