namespace CSharpProjectManager.BusinessLogic.BMain;



using CSharpProjectManager.UI;
using System;



public class RespondBefDoll
{
    private string[] allCmds;



    public RespondBefDoll(string[] allCmds)
    {
        this.allCmds = allCmds;
    }



    public void ChangeTextBefDol()
    {
        if(allCmds.Length == 2)
        {
            if (allCmds[0] == "cd" && allCmds[1] == "manager")
            {
                UMain.BeforeDoll = $"{ManagerCmd.Username}@SHEBA:/manager$";
            }
            else if (allCmds[0] == "cd" && allCmds[1] == "user")
            {
                UMain.BeforeDoll = $"{ManagerCmd.Username}@SHEBA:/user$";
            }
            else if (allCmds[0] == "cd" && allCmds[1] == "app")
            {
                UMain.BeforeDoll = $"{ManagerCmd.Username}@SHEBA:/app$";
            }
            else if (allCmds[0] == "cd" && allCmds[1] == "bank")
            {
                UMain.BeforeDoll = $"{ManagerCmd.Username}@SHEBA:/bank$";
            }
            else if (allCmds[0] == "cd" && allCmds[1] == "/")
            {
                UMain.BeforeDoll = $"{ManagerCmd.Username}@SHEBA:/$";
            }
            else if (allCmds[0] == "cd" && allCmds[1] == "..")
            {
                UMain.BeforeDoll = $"{ManagerCmd.Username}@SHEBA:/$";
            }
        }
    }
}