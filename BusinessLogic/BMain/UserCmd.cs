﻿namespace CSharpProjectManager.BusinessLogic.BMain;

public class UserCmd
{
    private static string[] allKeyWord;
    private string[] splitedCmd;
    private string[] allComb;
    private string[] splitedCmdOutput;

    static UserCmd()
    {
        allKeyWord = new string[100];

        allKeyWord[0] = "postvideo"; //post video
        allKeyWord[1] = "deletevideo"; //delete video
    }

    public UserCmd(string[] allCmd, string[] allComb)
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
    }
}
