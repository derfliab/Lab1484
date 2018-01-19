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

public class Skill
{
    int skillID;
    string skillName;
    string skillDescription;
    string lastUpdatedBy;
    DateTime lastUpdated;

    public Skill(int skillID, string skillName, string skillDescription, string LastUpdatedBy, DateTime LastUpdated)
    {
        SkillID = skillID;
        SkillName = skillName;
        SkillDescription = skillDescription;
        LastUpdatedBy = lastUpdatedBy;
        LastUpdated = lastUpdated;
    }

    public int SkillID
    {
        get { return skillID; }
        private set { skillID = value; }
    }

    public string SkillName
    {
        get { return skillName; }
        private set { skillName = value; }
    }

    public string SkillDescription
    {
        get { return skillDescription; }
        private set { skillDescription = value; }
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
