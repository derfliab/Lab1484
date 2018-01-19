using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 

/**
 * CIS 484-Lab 1
 * Author: Andrea Derflinger 
 * Date: 1/19/2018
 * Honor Pledge: This work and I comply with the JMU Honor Code.
**/
public class Project
{
    int projectID;
    string projectName;
    string projectDescription;
    string lastUpdatedBy;
    DateTime lastUpdated;

    public Project(int projectID, string projectName, string projectDescription, string LastUpdatedBy, DateTime LastUpdated)
    {
        ProjectID = projectID;
        SkillName = projectName;
        SkillDescription = projectDescription;
        LastUpdatedBy = lastUpdatedBy;
        LastUpdated = lastUpdated;
    }

    public int ProjectID
    {
        get { return projectID; }
        private set { projectID = value; }
    }

    public string SkillName
    {
        get { return projectName; }
        private set { projectName = value; }
    }

    public string SkillDescription
    {
        get { return projectDescription; }
        private set { projectDescription = value; }
    }

    public string LastUpdatedBy
    {
        get { return lastUpdatedBy; }
        private set { lastUpdatedBy = value; }
    }

    public DateTime LastUpdated
    {
        get { return lastUpdated; }
        private set { lastUpdated = value; }
    }
}
