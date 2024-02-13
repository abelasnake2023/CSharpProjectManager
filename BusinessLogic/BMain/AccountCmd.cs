namespace CSharpProjectManager.BusinessLogic.BMain;



using System;



public class AccountCmd
{
    private static string[] allKeyWord;
    private string[] splitedCmd;
    private string[] allComb;
    private string[] splitedCmdOutput;

    static AccountCmd()
    {
        allKeyWord = new string[100];



        allKeyWord[0] = "create"; //create
        allKeyWord[1] = "del"; //delete
        allKeyWord[2] = "alt"; //update
        allKeyWord[3] = "view"; //view
    }

    public AccountCmd(string[] allCmd, string[] allComb)
    {
        this.splitedCmd = allCmd;
        this.splitedCmdOutput = new string[splitedCmd.Length];
        this.allComb = allComb;
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
        for (int i = 0; i < allKeyWord.Length; i++)
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
            ExecAccountCmd.Create(singleCmd);
        }
        else if (i == 1)
        {
            ExecAccountCmd.Del(singleCmd);
        }
        else if (i == 2)
        {
            ExecAccountCmd.Alt(singleCmd);
        }
        else if (i == 3)
        {
            ExecAccountCmd.View(singleCmd);
        }
    }
}