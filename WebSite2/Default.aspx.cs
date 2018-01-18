using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;



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
            bool working = true;
                if (txtTerm.Value != "")
                {
                   
                
                    if (compareDates(DateTime.Parse(txtHire.Value), DateTime.Parse(txtTerm.Value)) == false)
                    {
                        working = false;
                        Label.Text += "Termination Date exceeds Hire Date";

                    }
                }
                if (check.Date >= currentDate.Date)
                {
                    working = false;
                    Label.Text += "Invalid Birth Day- Please make sure you are over 18.";

                }
                if (compareName(txtFirstName.Value, txtLastName.Value) == false && compareID(txtEmployeeID.Value) == false)
                {
                    working = false;
                    Label.Text += "Name or ID already exist";
                }
                if (txtManager.Value != "")
                {
                     if (findManagerID(int.Parse(txtManager.Value))==false)
                     {
                        working = false;
                        Label.Text += "Manager ID does not exist";
                     }
                 }
                if (findState(txtState.Value)==false)
                {
                    working = false;
                    Label.Text += "Enter a valid state";
                }
                if (txtCountry.Value != "US")
                {
                    working = false;
            Label.Text += "Please make the country US";
                }
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


            addEmployee[next++] = new Employee(int.Parse(txtEmployeeID.Value), txtFirstName.Value, txtLastName.Value, MI, DateTime.Parse(txtDOB.Value), txtHouseNumber.Value, txtStreet.Value, txtCity.Value,
                              State, txtCountry.Value, txtZip.Value, DateTime.Parse(txtHire.Value), Term, managerID, double.Parse(txtSalary.Value), name, DateTime.Now);
            Label.Text += "Employee has been inserted!";


            if (next == 3)
            {
                InsertBtn.Enabled = false;
            }

        }    
       
         
    }
    private bool findState(string state)
    {
        string[] states = new string[] {"AK","AL","AR","AS","AZ","CA","CO","CT",
                      "DC","DE","FL","GA","GU","HI","IA",
                      "ID",
                      "IL",
                      "IN",
                      "KS",
                      "KY",
                      "LA",
                      "MA",
                      "MD",
                      "ME",
                      "MI",
                      "MN",
                      "MO",
                      "MS",
                      "MT",
                      "NC",
                      "ND",
                      "NE",
                      "NH",
                      "NJ",
                      "NM",
                      "NV",
                      "NY",
                      "OH",
                      "OK",
                      "OR",
                      "PA",
                      "PR",
                      "RI",
                      "SC",
                      "SD",
                      "TN",
                      "TX",
                      "UT",
                      "VA",
                      "VI",
                      "VT",
                      "WA",
                      "WI",
                      "WV",
                      "WY" };
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

    private bool findManagerID(int managerID)
    {
        bool findManager = false; 
        for (int i=0; i<next; i++)
        {
            int array = addEmployee[i].ManagerID;
            int currentID = managerID;

            if (array == currentID)
            {
                findManager = true;
                return findManager;
            }

        }
        return findManager;
    }

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
    
    protected void ExitBtn_Click(object sender, EventArgs e)
    {
        
        Environment.Exit(0);
         
    }

}