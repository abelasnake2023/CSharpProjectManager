namespace CSharpProjectManager;

using CSharpProjectManager.BusinessLogic.BMain;
using CSharpProjectManager.Database.DMain;
using CSharpProjectManager.UI;
using System;



public class Program
{
    private static Program program;
    private UMain umain;



    public Program()
    {
    }



    public static void Main()
    {
        program = new Program();
        program.ControlProgram();

        Environment.Exit(0);
    }

    public void ControlProgram()
    {
        //Log in start
        bool validUser = ULogIn.AcceptDetail();
        if (validUser)
        {
            UMain.BeforeDoll = $"{ManagerCmd.Username}@SHEBA:/$";
            UMain.AfterDoll = "";
            umain = new UMain();
        }
        //Log in end

        //Main window start
        RespondAftDoll rAftDoll;
        RespondBefDoll rBefDoll;

        while (UMain.AfterDoll != "exit")
        {
            UMain.PrintBefDol(UMain.BeforeDoll);
            UMain.SLReadLine();


            rBefDoll = new RespondBefDoll(UMain.GetExecutableStr());
            rBefDoll.ChangeTextBefDol();


            rAftDoll = new RespondAftDoll(UMain.GetExecutableStr());
            rAftDoll.SplitCmds();
            rAftDoll.CmdScope();
        }
        //Main window end
    }
}