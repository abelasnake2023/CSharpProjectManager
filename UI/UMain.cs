namespace CSharpProjectManager.UI;



using CSharpProjectManager.BusinessLogic.BMain;
using System;
using System.Diagnostics;



public class UMain
{
    private static string beforeDollStr;
    private static string afterDollStr;
    private static string[] afterDollMultStr;



    public UMain()
    {
        Console.Clear();
        Console.Title = $"${ManagerCmd.Username}@SHEBA";
        Console.ForegroundColor = ConsoleColor.Green;
        Console.BackgroundColor = ConsoleColor.Black;
    }



    public static string BeforeDoll
    {
        set { beforeDollStr = value; }
        get { return beforeDollStr; }
    }
    public static string AfterDoll
    {
        set { afterDollStr = value; }
        get { return afterDollStr; }
    }



    public static void SetAfterDollMultStr(string[] multLine)
    {
        Array.Clear(UMain.afterDollMultStr, 0, UMain.afterDollMultStr.Length);
        UMain.afterDollMultStr = multLine;
    }
    public static string[] GetAfterDollMultLine()
    {
        return UMain.afterDollMultStr;
    }
    public static string[] GetExecutableStr()
    {
        string eStr = afterDollStr.Trim();

        string[] execWords = eStr.Split();
        List<string> ridOutWSpace = new List<string>();

        foreach (string word in execWords)
        {
            if (!string.IsNullOrWhiteSpace(word))
            {
                ridOutWSpace.Add(word);
            }
        }

        return ridOutWSpace.ToArray();
    }
    public static string[][] GetExecutableMultStr()
    {
        string[][] execMult = new string[UMain.afterDollMultStr.Length][];

        for(int i = 0; i < UMain.afterDollMultStr.Length; i++)
        {
            string eStr = UMain.afterDollMultStr[i].Trim();

            string[] execWords = eStr.Split();
            List<string> ridOutWSpace = new List<string>();

            foreach (string word in execWords)
            {
                if (!string.IsNullOrWhiteSpace(word))
                {
                    ridOutWSpace.Add(word);
                }
            }

            for(int j = 0; j < ridOutWSpace.Count; j++)
            {
                execMult[i] = ridOutWSpace.ToArray();
            }
        }

        return execMult;
    }



    public static void NLBefPrintAftDol(string str, byte amountNewLine = 1)
    {
        for(byte i = 0; i < amountNewLine; i++)
        {
            Console.Write("\n");
        }
        Console.Write(str);
        PutStrInAfterDoll(str);
    }
    public static void NLAftPrintAftDol(string str, byte amountNewLine = 1)
    {
        Console.Write(str);
        for (byte i = 0; i < amountNewLine; i++)
        {
            Console.Write("\n");
        }
        afterDollStr = str;
        PutStrInAfterDoll(str);
    }
    public static void NLBefAftPrintAftDol(string str, byte numNewLineBef = 1, byte numNewLineAft = 1)
    {
        for (byte i = 0; i < numNewLineBef; i++)
        {
            Console.Write("\n");
        }
        Console.Write(str);
        for (byte i = 0; i < numNewLineAft; i++)
        {
            Console.Write("\n");
        }
        PutStrInAfterDoll(str);
    }
    public static void OnlyPrintAftDol(string str)
    {
        Console.Write(str);
        PutStrInAfterDoll(str);
    }
    private static void PutStrInAfterDoll(string str)
    {
        int startingIndex = 0;
        List<string> multLine = new List<string>();

        for(int i = 0; i < str.Length; i++)
        {
            if (str[i] == '\n' || str[i].ToString() == Environment.NewLine || i == (str.Length - 1))
            {
                multLine.Add(str.Substring(startingIndex, (i - startingIndex) + 1));
                startingIndex = i + 1;
            }
        }

        UMain.afterDollMultStr = multLine.ToArray();

        if(UMain.afterDollMultStr.Length == 1)
        {
            UMain.afterDollStr = str;
        }
        else
        {
            UMain.afterDollStr = str.Substring(0, UMain.afterDollMultStr[0].Length);
        }
    }



    public static void MLReadLine(string readLineDel)
    {
        string str = "";
        AfterDoll = "";
        while((str = Console.ReadLine()) != readLineDel)
        {
            AfterDoll += str + "\n";
        }
    }
    public static string SLReadLine()
    {
        AfterDoll = Console.ReadLine();
        return AfterDoll;
    }
    public static string ReadPassword()
    {
        // Use a StringBuilder to store the password characters
        var passwordBuilder = new System.Text.StringBuilder();

        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey(true); // true means don't display the pressed key

            if (key.Key == ConsoleKey.Backspace && passwordBuilder.Length > 0)
            {
                passwordBuilder.Remove(passwordBuilder.Length - 1, 1);
            }
            else if (key.Key != ConsoleKey.Enter)
            {
                passwordBuilder.Append(key.KeyChar);
            }
        } while (key.Key != ConsoleKey.Enter);

        AfterDoll = passwordBuilder.ToString();
        passwordBuilder.Clear();

        Console.WriteLine();
        return AfterDoll;
    }



    public static void PrintBefDol(string str)
    {
        Console.Write(str + " ");
        BeforeDoll = str;
    }
}