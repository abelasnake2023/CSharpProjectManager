namespace CSharpProjectManager.BusinessLogic.BMain;

using CSharpProjectManager.UI;
using System.Diagnostics;



public class ExecManagerCmd
{
    public static string[] Create(string cmd) // Implementation for creating, return false if password is incorrect
    {
        string[] output = new string[1] { "Valid Password" };

        string password = cmd.Substring(cmd.IndexOf('$') + 1);
        if(password != ManagerCmd.Password)
        {
            output[0] = "Invalid Password!";
            return output;
        }

        ExecuteCreateCmd();
        
        return output;
    }
    public static void ExecuteCreateCmd()
    {
        UMain.OnlyPrintAftDol("Account Number: ");
        UMain.NLAftPrintAftDol("000004494949494949");
    }

    public static void Del(string cmd)// Implementation for deleting
    {
        
    }

    public static void Alt(string cmd)// Implementation for updating
    {
        
    }

    public static void Ban(string cmd)// Implementation for banning
    {
        
    }

    public static void View(string cmd)// Implementation for viewing
    {
        
    }

    public static void Link(string cmd)// Implementation for linking user with manager
    {
        
    }

    public static void Find_accNum(string cmd)// Implementation for finding by account number
    {
        
    }

    public static void Find_fName(string cmd)// Implementation for finding by first name
    {
        
    }

    public static void Find_mName(string cmd)// Implementation for finding by middle name
    {
        
    }

    public static void Find_lName(string cmd)// Implementation for finding by last name
    {
        
    }

    public static void Find_dob(string cmd)// Implementation for finding by date of birth
    {
        
    }

    public static void Find_age(string cmd)// Implementation for finding by age
    {
        
    }

    public static void Find_region(string cmd)// Implementation for finding by region
    {

    }

    public static void Find_city(string cmd)// Implementation for finding by city
    {
        
    }

    public static void Find_subCity(string cmd)// Implementation for finding by sub-city
    {
        
    }

    public static void Find_woreda(string cmd)// Implementation for finding by woreda
    {
        
    }

    public static void Find_kebele(string cmd)// Implementation for finding by kebele
    {
        
    }

    public static void Find_hNum(string cmd)// Implementation for finding by house number
    {
        
    }

    public static void Find_phone(string cmd)// Implementation for finding by phone number
    {
        
    }

    public static void Find_email(string cmd)// Implementation for finding by email
    {
        
    }

    public static void Find_identity(string cmd)// Implementation for finding by identity
    {
        
    }

    public static void Find_salary_gr(string cmd)// Implementation for finding salary greater than
    {
        
    }

    public static void Find_salary_ls(string cmd)// Implementation for finding salary less than
    {
        
    }

    public static void Find_salary_eq(string cmd)// Implementation for finding salary equals to
    {
        
    }

    public static void Find_skill(string cmd)// Implementation for finding by skill
    {
        
    }

    public static void Find_edu(string cmd)// Implementation for finding by education
    {
        
    }

    public static void Find_banOn(string cmd)// Implementation for finding by banned on
    {
        
    }

    public static void Find_banEnd(string cmd)// Implementation for finding by banned end
    {
        
    }

    public static void Find_cOn(string cmd)// Implementation for finding by created on
    {
        
    }

    public static void Find_fAlt(string cmd)// Implementation for finding by first update
    {
       
    }

    public static void Find_lAlt(string cmd)// Implementation for finding by last update
    {
        
    }

    public static void Find_bal_gr(string cmd)// Implementation for finding by balance greater than
    {
        
    }

    public static void Find_bal_ls(string cmd)// Implementation for finding by balance less than
    {
        
    }

    public static void Find_bal_eq(string cmd)// Implementation for finding balance equals to
    {
        
    }
}