namespace CSharpProjectManager.BusinessLogic.BMain;



using CSharpProjectManager.UI;
using System;
using System.Diagnostics;



public class RespondAftDoll
{
    private string[] aCmd;
    private List<string> sCmd; // till -> ||, &&, >, >>
    private List<string> cmdCombiner;

    private ManagerCmd managerCmd;
    private AccountCmd accCmd;
    private UserCmd userCmd;



    public RespondAftDoll(string[] aCmd)
    {
        this.aCmd = aCmd;
        sCmd = new List<string>();
        cmdCombiner = new List<string>();
    }



    public void SplitCmds() //here also key word and variable are separated by comma
    {
        string singleCmd = "";
        int startInd = 0;


        for (int i = 0; i < aCmd.Length; i++)
        {
            if (aCmd[i] == "||" || aCmd[i] == "&&" || aCmd[i] == ">" || aCmd[i] == ">>" || i == aCmd.Length - 1)
            {
                if(i != aCmd.Length - 1)
                {
                    cmdCombiner.Add(aCmd[i]);
                }
                else
                {
                    i++;
                }
                for (int j = startInd; j < i; j++) //one command
                {
                    if (aCmd[j][0] == '$')
                    {
                        singleCmd += ",";
                    }
                    else if(j > startInd)
                    {
                        if ((aCmd[j - 1][0] == '$') && aCmd[j][0] != '$')
                        {
                            singleCmd += ",";
                        }
                    }

                    singleCmd += aCmd[j];
                }
                sCmd.Add(singleCmd);
                startInd = i + 1;
            }
            singleCmd = "";
        }
    }
    public void CmdScope()
    {
        if (UMain.BeforeDoll == $"{ManagerCmd.Username}@SHEBA:/$")
        {

        }
        else if (UMain.BeforeDoll == $"{ManagerCmd.Username}@SHEBA:/manager$")
        {
            managerCmd = new ManagerCmd(GetAllSCmd(), GetAllCmdComb());
            managerCmd.StartExecCmd();
        }
        else if(UMain.BeforeDoll == $"{ManagerCmd.Username}@SHEBA:/user$")
        {
            accCmd = new AccountCmd(GetAllSCmd(), GetAllCmdComb());
            accCmd.StartExecCmd();
        }
        else if (UMain.BeforeDoll == $"{ManagerCmd.Username}@SHEBA:/app$")
        {
            userCmd = new UserCmd(GetAllSCmd(), GetAllCmdComb());
            userCmd.StartExecCmd();
        }
        else if (UMain.BeforeDoll == $"{ManagerCmd.Username}@SHEBA:/bank$")
        {

        }
    }



    public string[] GetAllSCmd()
    {
        return sCmd.ToArray();
    }
    public string[] GetAllCmdComb()
    {
        return cmdCombiner.ToArray();
    }
}