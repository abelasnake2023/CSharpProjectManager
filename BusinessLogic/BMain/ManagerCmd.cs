namespace CSharpProjectManager.BusinessLogic.BMain;



using System;
using System.Diagnostics;

public class ManagerCmd
{
    private static string username;
    private static string password;
    private static string[] allKeyWord;
    private string[] splitedCmd;
    private string[] allComb;
    private string[] splitedCmdOutput;



    static ManagerCmd()
    {
        allKeyWord = new string[100];
        


        allKeyWord[0] = "create"; //create
        allKeyWord[1] = "del"; //delete
        allKeyWord[2] = "alt"; //update
        allKeyWord[3] = "ban"; //ban
        allKeyWord[4] = "view"; //view
        allKeyWord[5] = "link"; //link user with manager
        allKeyWord[6] = "findaccNum"; //find by account number
        allKeyWord[7] = "findfName"; //find by first name
        allKeyWord[8] = "findmName"; //find by middle name
        allKeyWord[9] = "findlName"; //find by last name
        allKeyWord[10] = "finddob"; //find by date of birth
        allKeyWord[11] = "findage"; //find by age
        allKeyWord[12] = "findregion"; //find by region
        allKeyWord[13] = "findcity"; //find by city
        allKeyWord[14] = "findsubCity"; //find by sub-city
        allKeyWord[15] = "findworeda"; //find by woreda
        allKeyWord[16] = "findkebele"; //find by kebele
        allKeyWord[17] = "findhNum"; //find by house number
        allKeyWord[18] = "findphone"; //find by phone number
        allKeyWord[19] = "findemail"; // find by email
        allKeyWord[20] = "findidentity"; //find by identity
        allKeyWord[21] = "findsalary gr"; //find salary greater than
        allKeyWord[22] = "findsalary ls"; //find salary less than
        allKeyWord[23] = "findsalary eq"; //find salary equals to
        allKeyWord[24] = "findskill"; //find by skill
        allKeyWord[25] = "findedu"; //find by education
        allKeyWord[26] = "findbanOn"; //find by banned on 
        allKeyWord[27] = "findbanEnd"; //find by banned end
        allKeyWord[28] = "findcOn"; //find by created on
        allKeyWord[29] = "findfAlt"; //find by first update
        allKeyWord[30] = "findlAlt"; //find by last update
        allKeyWord[31] = "findbal gr"; //find by balance greater than
        allKeyWord[32] = "findbal ls"; //find by balance less than
        allKeyWord[33] = "findbal eq"; //find balance equals to
        allKeyWord[34] = "-s"; //search that start with
        allKeyWord[35] = "-m"; //search in the middle
        allKeyWord[36] = "-e"; //search that end
        allKeyWord[37] = "-a"; //search any where
    } //All the possible keyword for Manager cmd
    public ManagerCmd(string[] allCmd, string[] allComb)
    {
        this.splitedCmd = allCmd;
        this.splitedCmdOutput = new string[splitedCmd.Length];
        this.allComb = allComb;
    }



    public static string Username
    {
        set { ManagerCmd.username = value; }
        get { return username; }
    }
    public static string Password
    {
        set { ManagerCmd.password = value; }
        get { return password; }
    }



    public void StartExecCmd()
    {
        bool invalidCmd = false;


        for (int i = 0; i < this.splitedCmd.Length; i++)
        {
            RespondSingleCmd(splitedCmd[i]);
        }
    }

    private bool RespondSingleCmd(string singleCmd)
    {
        bool firstKeyWordValid = false;

        int iniKwordLen = singleCmd.IndexOf(',');

        if (iniKwordLen < 0) 
        {
            return false;
        }

        string firstKeyWord = singleCmd.Substring(0, iniKwordLen);
        for(int i = 0; i < allKeyWord.Length; i++)
        {
            if (allKeyWord[i] == firstKeyWord)
            {
                firstKeyWordValid = true;
                CallTheCmdFunc(i, singleCmd);
                break;
            }
        }
        
        return firstKeyWordValid;
    }

    private void CallTheCmdFunc(int i, string singleCmd)
    {
        if (i == 0)
        {
            ExecManagerCmd.Create(singleCmd);
        }
        else if (i == 1)
        {
            ExecManagerCmd.Del(singleCmd);
        }
        else if (i == 2)
        {
            ExecManagerCmd.Alt(singleCmd);
        }
        else if (i == 3)
        {
            ExecManagerCmd.Ban(singleCmd);
        }
        else if (i == 4)
        {
            ExecManagerCmd.View(singleCmd);
        }
        else if (i == 5)
        {
            ExecManagerCmd.Link(singleCmd);
        }
        else if (i == 6)
        {
            ExecManagerCmd.Find_accNum(singleCmd);
        }
        else if (i == 7)
        {
            ExecManagerCmd.Find_fName(singleCmd);
        }
        else if (i == 8)
        {
            ExecManagerCmd.Find_mName(singleCmd);
        }
        else if (i == 9)
        {
            ExecManagerCmd.Find_lName(singleCmd);
        }
        else if (i == 10)
        {
            ExecManagerCmd.Find_dob(singleCmd);
        }
        else if (i == 11)
        {
            ExecManagerCmd.Find_age(singleCmd);
        }
        else if (i == 12)
        {
            ExecManagerCmd.Find_region(singleCmd);
        }
        else if (i == 13)
        {
            ExecManagerCmd.Find_city(singleCmd);
        }
        else if (i == 14)
        {
            ExecManagerCmd.Find_subCity(singleCmd);
        }
        else if (i == 15)
        {
            ExecManagerCmd.Find_woreda(singleCmd);
        }
        else if (i == 16)
        {
            ExecManagerCmd.Find_kebele(singleCmd);
        }
        else if (i == 17)
        {
            ExecManagerCmd.Find_hNum(singleCmd);
        }
        else if (i == 18)
        {
            ExecManagerCmd.Find_phone(singleCmd);
        }
        else if (i == 19)
        {
            ExecManagerCmd.Find_email(singleCmd);
        }
        else if (i == 20)
        {
            ExecManagerCmd.Find_identity(singleCmd);
        }
        else if (i == 21)
        {
            ExecManagerCmd.Find_salary_gr(singleCmd);
        }
        else if (i == 22)
        {
            ExecManagerCmd.Find_salary_ls(singleCmd);
        }
        else if (i == 23)
        {
            ExecManagerCmd.Find_salary_eq(singleCmd);
        }
        else if (i == 24)
        {
            ExecManagerCmd.Find_skill(singleCmd);
        }
        else if (i == 25)
        {
            ExecManagerCmd.Find_edu(singleCmd);
        }
        else if (i == 26)
        {
            ExecManagerCmd.Find_banOn(singleCmd);
        }
        else if (i == 27)
        {
            ExecManagerCmd.Find_banEnd(singleCmd);
        }
        else if (i == 28)
        {
            ExecManagerCmd.Find_cOn(singleCmd);
        }
        else if (i == 29)
        {
            ExecManagerCmd.Find_fAlt(singleCmd);
        }
        else if (i == 30)
        {
            ExecManagerCmd.Find_lAlt(singleCmd);
        }
        else if (i == 31)
        {
            ExecManagerCmd.Find_bal_gr(singleCmd);
        }
        else if (i == 32)
        {
            ExecManagerCmd.Find_bal_ls(singleCmd);
        }
        else if (i == 33)
        {
            ExecManagerCmd.Find_bal_eq(singleCmd);
        }
        else if (i == 34)
        {
        }
        else if (i == 35)
        {
        }
        else if (i == 36)
        {
        }
        else if (i == 37)
        {
        }
        else if (i == 38)
        {
        }
        else if (i == 39)
        {
        }
        else if (i == 40)
        {
        }
    }
}