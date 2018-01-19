using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

/**
 * CIS 484-Lab 1
 * Author: Andrea Derflinger 
 * Date: 1/19/2018
 * Honor Pledge: This work and I comply with the JMU Honor Code.
**/


public partial class _Default : System.Web.UI.Page
{
    public static Employee[] addEmployee = new Employee[3];

    public static int next = 0;
    public string name = "Andrea Derflinger";

    protected void Page_Load(object sender, EventArgs e)
    {
        selectSkills();
        clearLabel();
         
  
        
    }
    protected void InsertBtn_Click(object sender, EventArgs e)
    {

        
        DateTime currentDate = DateTime.Now;
        DateTime check = DateTime.Parse(txtDOB.Value).AddYears(18);
        DateTime oldcheck = DateTime.Parse(txtDOB.Value).AddYears(65);
        bool working = true;
        string country = txtCountry.Value;
        // Checks Validation for the following if statements. If any of them return false, the employee will not be added to the array.

                //Checks if the termination date has nothing in it
                if (txtTerm.Value != "")
                {
                   
                
                    if (compareDates(DateTime.Parse(txtHire.Value), DateTime.Parse(txtTerm.Value)) == false)
                    {
                        working = false;
                        Label.Text += "Termination Date exceeds Hire Date";

                    }
                }
                // Checks if the birthdate is over 18
                if (check.Date >= currentDate.Date)
                {
                    working = false;
                    Label.Text += "Invalid Birth Day- Please make sure you are over 18.";

                }
                // Checks if the birthdate is under 65
                if (oldAge(DateTime.Parse(txtDOB.Value)) >= 65)
                {
                     working = false;
                     Label.Text += "Invalid Birth Day- You must be younger than 65";
                }
                // Compare if the Name or EmployeeID have been inserted
                if (compareName(txtFirstName.Value, txtLastName.Value) == false && compareID(txtEmployeeID.Value) == false)
                {
                    working = false;
                    Label.Text += "Name or ID already exist";
                }
                // Checks if Manager ID exists
                if (txtManager.Value != "")
                {
                     if (findManagerID(int.Parse(txtManager.Value))==false)
                     {
                        working = false;
                        Label.Text += "Manager ID does not exist";
                     }
                }
                // Checks if State is a valid state
                if (txtState.Value != "")
                {
                     if (findState(txtState.Value) == false)
                     {
                        working = false;
                        Label.Text += "Enter a valid state";
                     }
                }
                // Checks if country is set to US
                if (country.ToUpper() != "US")
                {
                   working = false;
                   Label.Text += "Please make the country US";
                }
        // If all validation are working then the Employee will be added to the array
        if (working == true)
        {
            string MI;
            string State;
            DateTime Term;
            int managerID;


            if (txtMI.Value == "")
            {
                MI = "NULL";
            }
            else
            {
                MI = txtMI.Value;
            }

            if (txtState.Value == "")
            {
                State = "NULL";
            }
            else
            {
                State = txtState.Value;
            }

            if (txtTerm.Value == "")
            {
                Term = DateTime.MinValue;

            }
            else
            {
                Term = DateTime.Parse(txtTerm.Value);
            }

            if (String.IsNullOrEmpty(txtManager.Value))
            {
                managerID = -1;
            }
            else
            {
                managerID = int.Parse(txtManager.Value);
            }

            //Add Employee
            addEmployee[next++] = new Employee(int.Parse(txtEmployeeID.Value), txtFirstName.Value, txtLastName.Value, MI, DateTime.Parse(txtDOB.Value), txtHouseNumber.Value, txtStreet.Value, txtCity.Value,
                              State, txtCountry.Value, txtZip.Value, DateTime.Parse(txtHire.Value), Term, managerID, double.Parse(txtSalary.Value), name, DateTime.Now);
            Label.Text += "Employee has been inserted!";

            // Enabled 
            if (next == 3)
            {
                InsertBtn.Enabled = false;
            }

        }    
       
         
    }
    // Find the state in an array
    private bool findState(string state)
    {
        string[] states = new string[] {"AK","AL","AR","AS","AZ","CA","CO","CT",
                      "DC","DE","FL","GA","GU","HI","IA","ID","IL","IN","KS","KY",
                      "LA","MA","MD","ME","MI","MN","MO","MS","MT","NC","ND","NE",
                      "NH","NJ","NM","NV","NY","OH","OK","OR","PA","PR","RI","SC",
                      "SD","TN","TX","UT","VA","VI","VT","WA","WI","WV","WY" };
        bool fstate = false;
        for (int i = 0; i < states.Length; i++)
        {
           
            string array = states[i];

            if (state == array)
            {
                fstate = true;
                return fstate;
            }

        }
        return fstate;
    }

    // Compare Termination  and Hire Date
    private bool compareDates(DateTime hiredate, DateTime termdate)
    {
        bool dateCompare = false;
        if(termdate > hiredate)
        {
            
            dateCompare = true;
            return dateCompare;
        }

        return dateCompare;
    }
 
 

    private void clearLabel()
    {
        Label.Text = "";
    }

    // Compare the first name and last name entered to the names entered in the array
    private bool compareName(string firstName, string lastName)
    {

        bool nameValidate = true;

        for (int i=0; i < next; i++)
        {
            
            string fullName = firstName.ToUpper() + lastName.ToUpper();
            string array = addEmployee[i].FName.ToUpper() + addEmployee[i].LName.ToUpper();
            
            if (fullName == array )
            {
                nameValidate = false;
                return nameValidate;
                 
                 
            }

             
        }
        return nameValidate;
       
    }

    // Compare the ManagerID given to the EmployeeIDs in the array
    private bool findManagerID(int managerID)
    {
        bool findManager = false; 
        for (int i=0; i<next; i++)
        {
            int array = addEmployee[i].EmployeeID;
            int currentID = managerID;

            if (array == currentID)
            {
                findManager = true;
                return findManager;
            }

        }
        return findManager;
    }

    // Compare EmployeeID given to EmployeeID in the array
    private bool compareID(string employeeID)
    {

        bool idValidate = true;

        for (int i = 0; i < next; i++)
        {

            int insertID = int.Parse(txtEmployeeID.Value);
            int array = addEmployee[i].EmployeeID;

            if (insertID == array)
            {
                idValidate = false;
                return idValidate;


            }


        }
        return idValidate;

    }

    //Find if the employee is older than 65
    private int oldAge (DateTime dob)
    {
        int age = 0;
        age = (DateTime.Today.Year - dob.Year);
        return age;
    }

    // Clear Button
    protected void ClearBtn_Click(object sender, EventArgs e)
    {
        txtEmployeeID.Value = "";
        txtFirstName.Value = "";
        txtLastName.Value = "";
        txtMI.Value = "";
        txtDOB.Value = "";
        txtHouseNumber.Value = "";
        txtStreet.Value = "";
        txtCity.Value = "";
        txtState.Value = "";
        txtCountry.Value = "";
        txtZip.Value = "";
        txtHire.Value = "";
        txtTerm.Value = "";
        txtSalary.Value = "";
        txtManager.Value = "";
    }

    //Employee Commit Button
    protected void EmployeeCommitBtn_Click(object sender, EventArgs e)
    {
        deleteAll();
        for (int i = 0; i < next; i++)
        {
            EmployeeCommitInsert(addEmployee[i]);
        }
        next = 0;
        Array.Clear(addEmployee, 0, addEmployee.Length);

    }

    //Employee Commit Insert
    private void EmployeeCommitInsert(Employee e)
    {
        
        try
        {
            
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = @"Server =Localhost ;Database=Lab1;Trusted_Connection=Yes;";

            sc.Open();

            System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
            insert.Connection = sc;


            insert.CommandText += "insert into [dbo].[EMPLOYEE] values (" + e.EmployeeID + ", '" + e.FName + "', '" + e.LName;
            if (e.MI == "NULL")
            {
                insert.CommandText += "', " + e.MI + ", '";
            }
            else
            {
                insert.CommandText += "', '" + e.MI + "', '";
            }
            insert.CommandText += e.HouseNum + "', '" + e.Street + "', '" + e.CityCountry;
            if (e.State == "NULL")
            {
                insert.CommandText += "', " + e.State + ", '";
            }
            else
            {
                insert.CommandText += "', '" + e.State + "', '";
            }
            insert.CommandText += e.Country + "', '" + e.Zip + "', '" + e.DOB + "', '" + e.HireDate;
            if (e.TermDate == DateTime.MinValue)
            {
                insert.CommandText += "', NULL, ";
            }
            else
            {
                insert.CommandText += "', '" + e.TermDate + "', ";
            }
            insert.CommandText += e.Salary;
            if (e.ManagerID == -1)
            {
                insert.CommandText += ", NULL, '";
            }
            else
            {
                insert.CommandText += ", " + e.ManagerID + ", '";
            }
            insert.CommandText += e.LastUpdatedBy + "', '" + e.LastUpdated + "')";
            

            Label.Text += "Employees have been committed!";
            insert.ExecuteNonQuery();
            sc.Close();

            
        }
        catch (Exception a)
        {
            Label.Text += "Error";
            Label.Text += a.Message;
        }
    }

    // Delete all data in the Database
    private void deleteAll()
    {
        System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
        sc.ConnectionString = @"Server =Localhost ;Database=Lab1;Trusted_Connection=Yes;";
        System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
        insert.Connection = sc;
        sc.Open();
        insert.CommandText = "DELETE FROM [dbo].[EMPLOYEE]";
        SqlDataReader data = insert.ExecuteReader();
        sc.Close();


    }

    //Upload skills from the databse into the skills dropdown
    private void selectSkills()
    {
 
        try
        {
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection();
            sc.ConnectionString = @"Server =Localhost ;Database=Lab1;Trusted_Connection=Yes;";
            System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
            insert.CommandText = "select SkillName from [dbo].[SKILL]";
            insert.Connection = sc;
            sc.Open();
            DropDownSkill.DataSource = insert.ExecuteReader();
            DropDownSkill.DataTextField = "SkillName";
            DropDownSkill.DataBind();
            sc.Close();
        }
        catch (Exception s)
        {
            Label.Text += "Skill Error";
            Label.Text += s.Message;
        }
            

        
         
    }
    
    //Exit Button
    protected void ExitBtn_Click(object sender, EventArgs e)
    {
        
        Environment.Exit(0);
         
    }

}