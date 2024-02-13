using ALib.BusinessLogic;
using ALib.Networking;
using ALibWinForms.Ui;
using CSharpProjectManager.Database.DMain;
using CSharpProjectManager.UI;
using System.Drawing;
using System.Windows.Forms;

namespace CSharpProjectManager.BusinessLogic.BMain;



public class ExecAccountCmd
{
    public static void Create(string cmd)
    {
        string password = cmd.Substring(cmd.IndexOf('$') + 1);
        if (password != ManagerCmd.Password)
        {
            UMain.NLAftPrintAftDol("Incorrect Password!");
        }
        else
        {
            ExecuteCreateCmd();
        }
    }
    private static bool ExecuteCreateCmd()
    {
        object[] args = new object[19];
        bool isValid = false;

        UMain.NLBefAftPrintAftDol("Press `q`/`Q` to exit!", 2, 2);


        //______________________________CREDENTIALS______________________________
        UMain.NLBefAftPrintAftDol("_________________________________________________________________________");
        // Accept First Name
        UMain.OnlyPrintAftDol("First Name: ");
        isValid = false;
        while (!isValid)
        {
            args[0] = UMain.SLReadLine().Trim();
            string fName = Validity.FormatName(args[0].ToString(), out isValid);
            if (args[0].ToString().Trim() == "q" || args[0].ToString().Trim() == "Q")
            {
                return false;
            }
            if (!isValid)
            {
                UMain.NLAftPrintAftDol("Wrong Format For Name!\nInsert again!");
            }
            else
            {
                isValid = true;
                args[0] = fName;
            }
        }

        // Accept Middle Name
        UMain.OnlyPrintAftDol("Middle Name: ");
        isValid = false;
        while (!isValid)
        {
            args[1] = UMain.SLReadLine().Trim();
            string mName = Validity.FormatName(args[1].ToString(), out isValid);
            if (args[1].ToString().Trim() == "q" || args[1].ToString().Trim() == "Q")
            {
                return false;
            }
            if (!isValid)
            {
                UMain.NLAftPrintAftDol("Wrong Format For Name!\nInsert again!");
            }
            else
            {
                isValid = true;
                args[1] = mName;
            }
        }

        // Accept Last Name
        UMain.OnlyPrintAftDol("Last Name: ");
        isValid = false;
        while (!isValid)
        {
            args[2] = UMain.SLReadLine().Trim();
            string lName = Validity.FormatName(args[2].ToString(), out isValid);
            if (args[2].ToString().Trim() == "q" || args[2].ToString().Trim() == "Q")
            {
                return false;
            }
            if (!isValid)
            {
                UMain.NLAftPrintAftDol("Wrong Format For Name!\nInsert again!");
            }
            else
            {
                isValid = true;
                args[2] = lName;
            }
        }

        // Accept Date of birth
        UMain.OnlyPrintAftDol("Format(0000-00-00) -> Date of Birth: ");
        isValid = false;
        string age = "";
        while (!isValid)
        {
            try
            {
                args[3] = DateOnly.Parse(UMain.SLReadLine().Trim());
                string detail = Validity.AgeGroup(DateOnly.Parse(args[3].ToString().Trim()), out age);

                if (args[3].ToString().Trim() == "q" || args[3].ToString().Trim() == "Q")
                {
                    return false;
                }

                if (detail == "Invalid Dob")
                {
                    isValid = false;
                    UMain.NLAftPrintAftDol("Inserting Future Date is invalid!\nInsert again valid Date of Birth!");
                }
                else if (detail == "Below 18")
                {
                    isValid = false;
                    UMain.NLAftPrintAftDol("Below 18, You need to be above 18.\nInsert again valid Date of Birth!");
                }
                else
                {
                    isValid = true;
                    UMain.NLAftPrintAftDol($"Valid Date of birth. Age: {age}.");
                }
            }
            catch
            {
                isValid = false;
                UMain.NLAftPrintAftDol("Wrong Format!\nInsert again!");
            }
        }









        //______________________________Location______________________________
        //Accepting Region
        UMain.NLAftPrintAftDol("_________________________________________________________________________");
        bool acceptCity = true;
        UMain.NLAftPrintAftDol("Region: ");
        isValid = false;
        while (!isValid)
        {
            UMain.NLAftPrintAftDol("1. Addis Ababa");
            UMain.NLAftPrintAftDol("2. Dire Dawa");
            UMain.NLAftPrintAftDol("3. Oromia");
            UMain.NLAftPrintAftDol("4. Amhara");
            UMain.NLAftPrintAftDol("5. Tigray");
            UMain.NLAftPrintAftDol("6. Afar");
            UMain.NLAftPrintAftDol("7. Somali");
            UMain.NLAftPrintAftDol("8. Benishangul-Gumuz");
            UMain.NLAftPrintAftDol("9. Southern Nations, Nationalities and Peoples(SNNPR)");
            UMain.NLAftPrintAftDol("10. Gambella");
            UMain.NLAftPrintAftDol("11. Harari");
            UMain.NLAftPrintAftDol("12. Sidama(the new Region)");
            UMain.NLAftPrintAftDol("13. South West Ethiopia(the new Region)");
            args[4] = UMain.SLReadLine().Trim();


            if (args[4].ToString().Trim() == "q" || args[4].ToString().Trim() == "Q")
            {
                return false;
            }

            try
            {
                int choice = 0;
                choice = Convert.ToInt32(args[4].ToString().Trim());

                if (choice < 1 || choice > 13)
                {
                    isValid = false;
                    UMain.NLAftPrintAftDol("Please your choice must be from 1 - 13.\nInsert again!");
                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            acceptCity = false;
                            args[4] = "Addis Ababa";
                            break;
                        case 2:
                            acceptCity = false;
                            args[4] = "Dire Dawa";
                            break;
                        case 3:
                            args[4] = "Oromia";
                            break;
                        case 4:
                            args[4] = "Amhara";
                            break;
                        case 5:
                            args[4] = "Tigray";
                            break;
                        case 6:
                            args[4] = "Afar";
                            break;
                        case 7:
                            args[4] = "Somali";
                            break;
                        case 8:
                            args[4] = "Benishangul-Gumuz";
                            break;
                        case 9:
                            args[4] = "Southern Nations, Nationalities and Peoples(SNNPR)";
                            break;
                        case 10:
                            args[4] = "Gambella";
                            break;
                        case 11:
                            args[4] = "Harari";
                            break;
                        case 12:
                            args[4] = "Sidama(the new Region)";
                            break;
                        case 13:
                            args[4] = "South West Ethiopia(the new Region)";
                            break;
                    }
                    isValid = true;
                }
            }
            catch (Exception ex)
            {
                isValid = false;
                UMain.NLAftPrintAftDol("Please your choice must be from 1 - 13.\nInsert again!");
            }
        }

        //Accept City
        if (acceptCity)
        {
            isValid = false;
            UMain.OnlyPrintAftDol("City: ");
            while (!isValid)
            {
                args[5] = UMain.SLReadLine().Trim();
                if (args[5].ToString().Trim() == "q" || args[5].ToString().Trim() == "Q")
                {
                    return false;
                }
                if (args[5].ToString().Trim().Length == 0)
                {
                    isValid = false;
                    UMain.NLAftPrintAftDol("You need to insert your City!\nInsert again!");
                }
                else
                {
                    isValid = true;
                }
            }
        }
        else
        {
            args[5] = args[4];
        }

        //Accept Sub City
        UMain.OnlyPrintAftDol("Sub City: ");
        isValid = false;
        while (!isValid)
        {
            args[6] = UMain.SLReadLine().Trim();
            if (args[6].ToString().Trim() == "q" || args[6].ToString().Trim() == "Q")
            {
                return false;
            }
            if (args[6].ToString().Trim().Length == 0)
            {
                isValid = false;
                UMain.NLAftPrintAftDol("You need to insert your Sub City!\nInsert again!");
            }
            else
            {
                isValid = true;
            }
        }

        //Accept Woreda
        UMain.OnlyPrintAftDol("Woreda: ");
        isValid = false;
        while (!isValid)
        {
            args[7] = UMain.SLReadLine().Trim();
            if (args[7].ToString().Trim() == "q" || args[7].ToString().Trim() == "Q")
            {
                return false;
            }
            if (args[7].ToString().Trim().Length == 0 || !Validity.IsOnlyDigit(args[7].ToString().Trim()))
            {
                isValid = false;
                UMain.NLAftPrintAftDol("Woreda is must and it should be number!\nInsert again!");
            }
            else
            {
                isValid = true;
            }
        }

        //Accept House number
        UMain.OnlyPrintAftDol("House Number: ");
        isValid = false;
        while (!isValid)
        {
            args[8] = UMain.SLReadLine().Trim();
            if (args[8].ToString().Trim() == "q" || args[8].ToString().Trim() == "Q")
            {
                return false;
            }
            if (args[8].ToString().Trim().Length == 0 || !Validity.IsOnlyDigit(args[8].ToString().Trim()))
            {
                isValid = false;
                UMain.NLAftPrintAftDol("House Number is must and it should be number!\nInsert again!");
            }
            else
            {
                isValid = true;
            }
        }








        //______________________________IDENTITY______________________________
        //Accept Phone Number
        UMain.NLBefAftPrintAftDol("_________________________________________________________________________");
        UMain.OnlyPrintAftDol("Phone Number: ");
        isValid = false;
        string phoneNumProperFormat = "";
        while (!isValid)
        {
            args[9] = UMain.SLReadLine().Trim();
            isValid = Validity.IsEthPhoneNumber(args[9].ToString().Trim(), out phoneNumProperFormat);
            if (args[9].ToString().Trim() == "q" || args[9].ToString().Trim() == "Q")
            {
                return false;
            }
            if (!isValid)
            {
                UMain.NLAftPrintAftDol("Invalid, Not Ethiopian Phone Number!\nInsert again!");
            }
            else
            {
                args[9] = phoneNumProperFormat.Trim();
                isValid = true;
            }
        }

        //Accept Email
        UMain.OnlyPrintAftDol("Gmail: ");
        isValid = false;
        while (!isValid)
        {
            args[10] = UMain.SLReadLine().Trim();
            string detail = "";
            isValid = Validity.IsGmail(args[10].ToString().Trim(), out detail);
            if (args[10].ToString().Trim() == "q" || args[10].ToString().Trim() == "Q")
            {
                return false;
            }
            if (!isValid)
            {
                UMain.NLAftPrintAftDol($"{detail}\nInsert again!");
            }
            else
            {
                string veriNum = ALibGMail.GenerateVerificationCode(6);
                string[] emailBody = new string[5]
                {
                    $"Dear {args[0].ToString()},",
                    $"\nYour code is: {veriNum}. Use it to create your Neser account.",
                    $"\nIf you didn't request this, simply ignore this message.",
                    $"\nYours,",
                    $"Neser Bank"
                };

                bool emailSent = ALibGMail.SendEmail("abelasnake", "CSharpProject2024", args[10].ToString().Trim(),
                    $"Your Code - {veriNum}", emailBody, out detail);
                if (!emailSent)
                {
                    isValid = false;
                    UMain.NLAftPrintAftDol("Unable to send message to " + args[10].ToString().Trim());
                    UMain.NLAftPrintAftDol(detail);
                    UMain.NLAftPrintAftDol("Please try again!");
                }
                else
                {
                    UMain.OnlyPrintAftDol("Please enter the verification code that is sent to your email: ");
                    string enteredVeriNum = UMain.SLReadLine();

                    if (enteredVeriNum == veriNum)
                    {
                        isValid = true;
                    }
                    else
                    {
                        isValid = false;
                        UMain.NLAftPrintAftDol("Security alert, the verification number you entered is not the verification number " +
                            "sent to " + args[10].ToString().Trim() + "!\nEnter again your own Gmail account!");
                    }
                }
            }
        }

        //Accept 3 x 4 photo
        UMain.OnlyPrintAftDol("Photo(3x4) from file: ");
        isValid = false;
        while (!isValid)
        {
            args[11] = UMain.SLReadLine().Trim();

            if (args[11].ToString().Trim() == "Q" || args[11].ToString().Trim() == "q")
            {
                return false;
            }

            Image image = null;
            float centiHeight = 0;
            float centiWidth = 0;
            try
            {
                image = Image.FromFile(args[11].ToString().Trim());
                centiHeight = ScreenProp.VertCenti(image.Height);
                centiWidth = ScreenProp.HoriCenti(image.Width);

                if (centiHeight <= 0 || centiWidth <= 0)
                {
                    isValid = false;
                    UMain.NLAftPrintAftDol("Image can't be loaded!\nPlease insert again!");
                }
                else if (centiHeight > 4.5 || centiHeight < 3.5 || centiWidth > 3.5 || centiWidth < 2.5)
                {
                    UMain.NLAftPrintAftDol($"Image size = {centiWidth}x{centiHeight}, it's better if you " +
                        $"Insert 3x4 photo. Insert again(optional) y/n? ");
                    char choice = UMain.SLReadLine().Trim().ElementAt(0);

                    if (choice == 'Y' || choice == 'y')
                    {
                        isValid = false;
                    }
                    else
                    {
                        isValid = true;
                        args[11] = image;
                    }
                }
                else
                {
                    isValid = true;
                    args[11] = image;
                }
            }
            catch
            {
                isValid = false;
                UMain.NLAftPrintAftDol("Not Image!\nPlease insert again!");
            }
        }









        //______________________________Account State______________________________
        //Accept Initial Balance(birr)
        UMain.NLBefAftPrintAftDol("_________________________________________________________________________");
        UMain.OnlyPrintAftDol("Initial Balance(birr): ");
        isValid = false;
        while (!isValid)
        {
            args[12] = UMain.SLReadLine().Trim();
            isValid = Validity.IsOnlyDigit(args[12].ToString().Trim());
            if (args[12].ToString().Trim() == "q" || args[12].ToString().Trim() == "Q")
            {
                return false;
            }
            if (!isValid || args[12].ToString().Trim().Length == 0)
            {
                UMain.NLAftPrintAftDol("Invalid, Money should be number!\nInsert again!");
            }
            else
            {
                int money = 0;
                money = int.Parse(args[12].ToString().Trim());

                if(money < 50)
                {
                    isValid = false;
                    UMain.NLAftPrintAftDol("Invalid: Initial Balance must be at least 50 birr." +
                        "\nInsert again!\n");
                }
                else
                {
                    isValid = true;
                }
            }
        }

        //Accepting Ban
        UMain.NLAftPrintAftDol("Ban: ");
        isValid = false;
        while (!isValid)
        {
            UMain.NLAftPrintAftDol("1. Ban");
            UMain.NLAftPrintAftDol("2. Permit");
            args[13] = UMain.SLReadLine().Trim();


            if (args[13].ToString().Trim() == "q" || args[13].ToString().Trim() == "Q")
            {
                return false;
            }

            try
            {
                int choice = 0;
                choice = Convert.ToInt32(args[13].ToString().Trim());

                if (choice < 1 || choice > 2)
                {
                    isValid = false;
                    UMain.NLAftPrintAftDol("Please, your choice must be 1 or 2.\nInsert again!");
                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            args[13] = true;
                            break;
                        case 2:
                            args[13] = false;
                            break;
                    }
                    isValid = true;
                }
            }
            catch (Exception ex)
            {
                isValid = false;
                UMain.NLAftPrintAftDol("Please, your choice must be 1 or 2.\nInsert again!");
            }
        }

        //Accepting Active/inActive
        UMain.NLAftPrintAftDol("Active: ");
        isValid = false;
        while (!isValid)
        {
            UMain.NLAftPrintAftDol("1. Active");
            UMain.NLAftPrintAftDol("2. InActive");
            args[14] = UMain.SLReadLine().Trim();


            if (args[14].ToString().Trim() == "q" || args[14].ToString().Trim() == "Q")
            {
                return false;
            }

            try
            {
                int choice = 0;
                choice = Convert.ToInt32(args[14].ToString().Trim());

                if (choice < 1 || choice > 2)
                {
                    isValid = false;
                    UMain.NLAftPrintAftDol("Please, your choice must be 1 or 2.\nInsert again!");
                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            args[14] = true;
                            break;
                        case 2:
                            args[14] = false;
                            break;
                    }
                    isValid = true;
                }
            }
            catch (Exception ex)
            {
                isValid = false;
                UMain.NLAftPrintAftDol("Please, your choice must be 1 or 2.\nInsert again!");
            }
        }

        //Accept Account Type
        UMain.NLAftPrintAftDol("Account Type: ");
        isValid = false;
        while (!isValid)
        {
            UMain.NLAftPrintAftDol("1. Saving");
            UMain.NLAftPrintAftDol("2. Checking");
            args[15] = UMain.SLReadLine().Trim();


            if (args[15].ToString().Trim() == "q" || args[15].ToString().Trim() == "Q")
            {
                return false;
            }

            try
            {
                int choice = 0;
                choice = Convert.ToInt32(args[15].ToString().Trim());

                if (choice < 1 || choice > 2)
                {
                    isValid = false;
                    UMain.NLAftPrintAftDol("Please, your choice must be 1 or 2.\nInsert again!");
                }
                else
                {
                    switch (choice)
                    {
                        case 1:
                            args[15] = "Saving";
                            break;
                        case 2:
                            args[15] = "Checking";
                            break;
                    }
                    isValid = true;
                }
            }
            catch (Exception ex)
            {
                isValid = false;
                UMain.NLAftPrintAftDol("Please, your choice must be 1 or 2.\nInsert again!");
            }
        }

        //Accept Source of Income
        UMain.NLAftPrintAftDol("Source of Income -> less than 100 character or can be left null.");
        UMain.NLAftPrintAftDol("Use `$end` as a delimiter to terminate the input!");
        UMain.MLReadLine("$end");
        if(UMain.AfterDoll.Length > 100)
        {
            UMain.AfterDoll = UMain.AfterDoll.Substring(0, 100);
        }
        args[16] = UMain.AfterDoll;
        if (args[16].ToString().Trim() == "q" || args[16].ToString().Trim() == "Q")
        {
            args[16] = null;
            return false;
        }

        //While creating account loan is not allowed so loan will be false
        args[17] = false;

        //Assign it's manager Id for the new manager
        args[18] = DManagerCmd.GetManagerIdByUserName(ManagerCmd.Username);







        //______________________________Save Changes______________________________        
        UMain.NLAftPrintAftDol("_________________________________________________________________________");
        UMain.OnlyPrintAftDol("Save Changes? y/n: ");
        string saveChange = UMain.SLReadLine();
        string savedDetail = "";
        if (saveChange.Trim() == "Y" || saveChange.Trim() == "y")
        {
            string accountNumber = DManagerCmd.CreateAccAndGetAccNum(args, out savedDetail);

            if (accountNumber != null)
            {
                // Display Account Number
                UMain.NLAftPrintAftDol(savedDetail);
                UMain.NLBefAftPrintAftDol("Account Number: " + accountNumber, 2, 2);
                
                UMain.NLBefAftPrintAftDol("Press any key to continue...");
                Console.ReadKey();
                Console.WriteLine();
                return true;
            }
            else
            {
                UMain.NLAftPrintAftDol("Couldn't create the Account!");
                UMain.NLAftPrintAftDol(savedDetail);
            }

            return false;
        }
        else
        {
            return false;
        }
    }
    public static void Del(string cmd)// Implementation for deleting
    {

    }
    public static void Alt(string cmd)// Implementation for updating
    {

    }
    public static void View(string cmd)// Implementation for viewing
    {

    }
}