namespace CSharpProjectManager.BusinessLogic.BMain;



using ALib.BusinessLogic;
using CSharpProjectManager.Database.DMain;
using CSharpProjectManager.UI;
using ALib.Networking;
using System.Drawing;
using System.Windows.Forms;
using ALibWinForms.Ui;
using System.Linq.Expressions;
using System.Xml.Serialization;

public class ExecManagerCmd
{
    public static string[] Create(string cmd) // Implementation for creating
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
    public static bool ExecuteCreateCmd()
    {
        object[] args = new object[21];
        bool isValid = false;

        UMain.NLBefAftPrintAftDol("Press `q`/`Q` to exit!", 2, 2);


        //______________________________CREDENTIALS______________________________
        UMain.NLBefAftPrintAftDol("_________________________________________________________________________");
        // Accept First Name
        UMain.OnlyPrintAftDol("First Name: ");
        isValid = false;
        while (!isValid)
        {
            args[13] = UMain.SLReadLine().Trim();
            string fName = Validity.FormatName(args[13].ToString(), out isValid);
            if (args[13].ToString().Trim() == "q" || args[13].ToString().Trim() == "Q")
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
                args[13] = fName;
            }
        }

        // Accept Middle Name
        UMain.OnlyPrintAftDol("Middle Name: ");
        isValid = false;
        while (!isValid)
        {
            args[14] = UMain.SLReadLine().Trim();
            string mName = Validity.FormatName(args[14].ToString(), out isValid);
            if (args[14].ToString().Trim() == "q" || args[14].ToString().Trim() == "Q")
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
                args[14] = mName;
            }
        }

        // Accept Last Name
        UMain.OnlyPrintAftDol("Last Name: ");
        isValid = false;
        while (!isValid)
        {
            args[15] = UMain.SLReadLine().Trim();
            string lName = Validity.FormatName(args[15].ToString(), out isValid);
            if (args[15].ToString().Trim() == "q" || args[15].ToString().Trim() == "Q")
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
                args[15] = lName;
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
                args[0] = DateOnly.Parse(UMain.SLReadLine().Trim());
                string detail = Validity.AgeGroup(DateOnly.Parse(args[0].ToString().Trim()), out age);

                if (args[0].ToString().Trim() == "q" || args[0].ToString().Trim() == "Q")
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
                else if (detail == "Old")
                {
                    isValid = false;
                    UMain.NLAftPrintAftDol("Above 64, You need to be below 65.\nInsert again valid Date of Birth!");
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

        // Accept New Manager Username
        UMain.OnlyPrintAftDol("Manager Username: ");
        isValid = false;
        while (!isValid)
        {
            args[16] = UMain.SLReadLine().Trim();
            isValid = Validity.IsTypeOfALibUsername(args[16].ToString().Trim());

            if (args[16].ToString().Trim() == "q" || args[16].ToString().Trim() == "Q")
            {
                return false;
            }

            string details = "";
            if (!isValid)
            {
                isValid = false;
                UMain.NLAftPrintAftDol("Username must greater than 4 character and less than 51 character.\n" +
                    "Insert again valid username!");
            }
            else if (!DManagerCmd.UniqueManager(args[16].ToString().Trim(), out details))
            {
                isValid = false;
                UMain.NLAftPrintAftDol(details + "\nInsert again unique username!");
            }
            else
            {
                isValid = true;
            }
        }

        // Accept Manager Password
        UMain.OnlyPrintAftDol("Manager Password: ");
        isValid = false;
        while (!isValid)
        {
            args[17] = UMain.ReadPassword();
            isValid = Validity.IsTypeOfALibPassword(args[17].ToString());
            if (args[17].ToString().Trim() == "q" || args[17].ToString().Trim() == "Q")
            {
                return false;
            }
            if (!isValid)
            {
                string generatedPassword = Validity.GenerateALibPassword();
                UMain.NLAftPrintAftDol("Generated Strong Password: " + generatedPassword);
                UMain.NLAftPrintAftDol("Week password!\n" +
                    "Password must consist all type of character -> Upper case letter, Lower case letter, Digit, Special Character, and shouldn't consist white space." +
                    "\n1. Use the Generated Password above?\n2. Insert your own password? ");
                char choice = '0';
                while (choice != '1' && choice != '2')
                {
                    choice = UMain.SLReadLine().Trim().ElementAt(0);

                    if (choice == '1')
                    {
                        args[17] = generatedPassword;
                        isValid = true;
                    }
                    else if (choice == '2')
                    {
                        isValid = false;
                        UMain.NLAftPrintAftDol("Make sure you put strong password!");
                    }
                    else
                    {
                        isValid = false;
                        UMain.NLAftPrintAftDol("Choose only 1 or 2.\nInsert again valid choice!");
                    }
                }
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
        while (!isValid)
        {
            args[10] = UMain.SLReadLine().Trim();
            isValid = Validity.IsEthPhoneNumber(args[10].ToString().Trim());
            if (args[10].ToString().Trim() == "q" || args[10].ToString().Trim() == "Q")
            {
                return false;
            }
            if (!isValid)
            {
                UMain.NLAftPrintAftDol("Invalid, Not Ethiopian Phone Number!\nInsert again!");
            }
            else
            {
                isValid = true;
            }
        }

        //Accept Email
        UMain.OnlyPrintAftDol("Gmail: ");
        isValid = false;
        while (!isValid)
        {
            args[11] = UMain.SLReadLine().Trim();
            string detail = "";
            isValid = Validity.IsGmail(args[11].ToString().Trim(), out detail);
            if (args[11].ToString().Trim() == "q" || args[11].ToString().Trim() == "Q")
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
                    $"Dear {args[13].ToString()},",
                    $"\nYour code is: {veriNum}. Use it to create your manager account.",
                    $"\nIf you didn't request this, simply ignore this message.",
                    $"\nYours,",
                    $"Neser Bank"
                };

                bool emailSent = ALibGMail.SendEmail("abelasnake", "CSharpProject2024", args[11].ToString().Trim(),
                    $"Your Code - {veriNum}", emailBody, out detail);
                if (!emailSent)
                {
                    isValid = false;
                    UMain.NLAftPrintAftDol("Unable to send message to " + args[11].ToString().Trim());
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
                            "sent to " + args[11].ToString().Trim() + "!\nEnter again your own Gmail account!");
                    }
                }
            }
        }

        //Accept 3 x 4 photo
        UMain.OnlyPrintAftDol("Photo(3x4) from file: ");
        isValid = false;
        while (!isValid)
        {
            args[12] = UMain.SLReadLine().Trim();

            if (args[12].ToString().Trim() == "Q" || args[12].ToString().Trim() == "q")
            {
                return false;
            }

            Image image = null;
            float centiHeight = 0;
            float centiWidth = 0;
            try
            {
                image = Image.FromFile(args[12].ToString().Trim());
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
                        args[12] = image;
                    }
                }
                else
                {
                    isValid = true;
                    args[12] = image;
                }
            }
            catch
            {
                isValid = false;
                UMain.NLAftPrintAftDol("Not Image!\nPlease insert again!");
            }
        }







        //______________________________Location______________________________
        //Accepting Region
        UMain.NLAftPrintAftDol("_________________________________________________________________________");
        bool acceptCity = true;
        UMain.NLAftPrintAftDol("Region: ");
        isValid = false;
        while(!isValid)
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
            args[5] = UMain.SLReadLine().Trim();


            if (args[5].ToString().Trim() == "q" || args[5].ToString().Trim() == "Q")
            {
                return false;
            }

            try
            {
                int choice = 0;
                choice = Convert.ToInt32(args[5].ToString().Trim());

                if(choice < 1 || choice > 13)
                {
                    isValid = false;
                    UMain.NLAftPrintAftDol("Please your choice must be from 1 - 13.\nInsert again!");
                }
                else
                {
                    switch(choice)
                    {
                        case 1:
                            acceptCity = false;
                            args[5] = "Addis Ababa";
                            break;
                        case 2:
                            acceptCity = false;
                            args[5] = "Dire Dawa";
                            break;
                        case 3:
                            args[5] = "Oromia";
                            break;
                        case 4:
                            args[5] = "Amhara";
                            break;
                        case 5:
                            args[5] = "Tigray";
                            break;
                        case 6:
                            args[5] = "Afar";
                            break;
                        case 7:
                            args[5] = "Somali";
                            break;
                        case 8:
                            args[5] = "Benishangul-Gumuz";
                            break;
                        case 9:
                            args[5] = "Southern Nations, Nationalities and Peoples(SNNPR)";
                            break;
                        case 10:
                            args[5] = "Gambella";
                            break;
                        case 11:
                            args[5] = "Harari";
                            break;
                        case 12:
                            args[5] = "Sidama(the new Region)";
                            break;
                        case 13:
                            args[5] = "South West Ethiopia(the new Region)";
                            break;
                    }
                    isValid = true;
                }
            }
            catch(Exception ex)
            {
                isValid = false;
                UMain.NLAftPrintAftDol("Please your choice must be from 1 - 13.\nInsert again!");
            }
        }
        
        //Accept City
        if(acceptCity)
        {
            isValid = false;
            UMain.OnlyPrintAftDol("City: ");
            while(!isValid)
            {
                args[6] = UMain.SLReadLine().Trim();
                if (args[6].ToString().Trim() == "q" || args[6].ToString().Trim() == "Q")
                {
                    return false;
                }
                if (args[6].ToString().Trim().Length == 0)
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
            args[6] = args[5];
        }

        //Accept Sub City
        UMain.OnlyPrintAftDol("Sub City: ");
        isValid = false;
        while(!isValid)
        {
            args[7] = UMain.SLReadLine().Trim();
            if (args[7].ToString().Trim() == "q" || args[7].ToString().Trim() == "Q")
            {
                return false;
            }
            if (args[7].ToString().Trim().Length == 0)
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
        while(!isValid)
        {
            args[8] = UMain.SLReadLine().Trim();
            if (args[8].ToString().Trim() == "q" || args[8].ToString().Trim() == "Q")
            {
                return false;
            }
            if (args[8].ToString().Trim().Length == 0 || !Validity.IsOnlyDigit(args[8].ToString().Trim()))
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
            args[9] = UMain.SLReadLine().Trim();
            if (args[9].ToString().Trim() == "q" || args[9].ToString().Trim() == "Q")
            {
                return false;
            }
            if (args[9].ToString().Trim().Length == 0 || !Validity.IsOnlyDigit(args[9].ToString().Trim()))
            {
                isValid = false;
                UMain.NLAftPrintAftDol("House Number is must and it should be number!\nInsert again!");
            }
            else
            {
                isValid = true;
            }
        }






        
        //______________________________Salary______________________________
        UMain.NLAftPrintAftDol("_________________________________________________________________________");
        //Accept Salary
        UMain.OnlyPrintAftDol("Salary: ");
        isValid = false;
        while (!isValid)
        {
            args[18] = UMain.SLReadLine().Trim();
            if (args[18].ToString().Trim() == "q" || args[18].ToString().Trim() == "Q")
            {
                return false;
            }
            if (args[18].ToString().Trim().Length == 0 || !Validity.IsOnlyDigit(args[18].ToString().Trim()))
            {
                isValid = false;
                UMain.NLAftPrintAftDol("Invalid Salary!\nInsert again!");
            }
            else
            {
                isValid = true;
            }
        }

        UMain.OnlyPrintAftDol("Format(0000-00-00) -> Salary Start Date: ");
        //Accept Salary start Date
        isValid = false;
        string salaryStartDate = "";
        while (!isValid)
        {
            try
            {
                args[19] = DateOnly.Parse(UMain.SLReadLine().Trim());
                string detail = Validity.AgeGroup(DateOnly.Parse(args[19].ToString().Trim()), out salaryStartDate);

                if (args[19].ToString().Trim() == "q" || args[19].ToString().Trim() == "Q")
                {
                    return false;
                }

                if (detail != "Invalid Dob")
                {
                    isValid = false;
                    UMain.NLAftPrintAftDol("Inserting Past Date is invalid!\nInsert again valid Date when the Salary payment start!");
                }
                else
                {
                    isValid = true;
                }
            }
            catch
            {
                isValid = false;
                UMain.NLAftPrintAftDol("Wrong Format!\nInsert again!");
            }
        }

        //Accept Salary end Date
        UMain.OnlyPrintAftDol("Format(0000-00-00) -> Salary Contract End Date: ");
        isValid = false;
        string salaryEndDate = "";
        while (!isValid)
        {
            try
            {
                args[20] = DateOnly.Parse(UMain.SLReadLine().Trim());
                string detail = Validity.AgeGroup(DateOnly.Parse(args[20].ToString().Trim()), out salaryEndDate);

                if (args[20].ToString().Trim() == "q" || args[20].ToString().Trim() == "Q")
                {
                    return false;
                }

                bool Date2AftDate1 = DateOnly.Parse(args[19].ToString().Trim()) > DateOnly.Parse(args[20].ToString().Trim());
                if (Date2AftDate1)
                {
                    isValid = false;
                    UMain.NLAftPrintAftDol("Contract end After the payment start, not before!\nInsert again valid Date when the contract on the salary end!");
                }
                else 
                {
                    isValid = true;
                }
            }
            catch
            {
                isValid = false;
                UMain.NLAftPrintAftDol("Wrong Format!\nInsert again!");
            }
        }







        //______________________________Skill______________________________
        //Accept skill
        UMain.NLAftPrintAftDol("_________________________________________________________________________");
        isValid = false;
        UMain.OnlyPrintAftDol("Skill: ");
        isValid = false;
        while (!isValid)
        {
            args[1] = UMain.SLReadLine().Trim();

            if (args[1].ToString().Trim() == "Q" || args[1].ToString().Trim() == "q")
            {
                return false;
            }
            if (args[1].ToString().Trim().Length == 0)
            {
                isValid = false;
                UMain.NLAftPrintAftDol("Skill can't be left null!\nInsert again skill!");
            }
            else
            {
                isValid = true;
            }
        }

        //Accept skill type
        UMain.OnlyPrintAftDol("Skill Type: ");
        isValid = false;
        while (!isValid)
        {
            args[2] = UMain.SLReadLine().Trim();

            if (args[2].ToString().Trim() == "Q" || args[2].ToString().Trim() == "q")
            {
                return false;
            }
            if (args[2].ToString().Trim().Length == 0)
            {
                isValid = false;
                UMain.NLAftPrintAftDol("Skill type can't be left null!\nInsert again skill type!");
            }
            else
            {
                isValid = true;
            }
        }

        //Accept Certificate photo
        UMain.OnlyPrintAftDol("Certificate photo file: ");
        isValid = false;
        while (!isValid)
        {
            args[3] = UMain.SLReadLine().Trim();

            if (args[3].ToString().Trim() == "Q" || args[3].ToString().Trim() == "q")
            {
                return false;
            }

            Image image = null;
            float centiHeight = 0;
            float centiWidth = 0;
            try
            {
                image = Image.FromFile(args[3].ToString().Trim());
                centiHeight = ScreenProp.VertCenti(image.Height);
                centiWidth = ScreenProp.HoriCenti(image.Width);

                if (centiHeight <= 0 || centiWidth <= 0)
                {
                    isValid = false;
                    UMain.NLAftPrintAftDol("Image can't be loaded!\nPlease insert again!");
                }
                else
                {
                    isValid = true;
                    args[3] = image;
                }
            }
            catch
            {
                isValid = false;
                UMain.NLAftPrintAftDol("Not Image!\nPlease insert again!");
            }
        }

        //Accept year experience(optional)
        UMain.OnlyPrintAftDol("Year experience is optional, do you want to insert? y/n: ");
        char choiceY = '\0';
        choiceY = UMain.SLReadLine().Trim().ElementAt(0);
        if(choiceY == 'y' || choiceY == 'Y')
        {
            isValid = false;
            UMain.OnlyPrintAftDol("Year experience: ");
            while (!isValid)
            {
                args[4] = UMain.SLReadLine().Trim();

                if (args[4].ToString().Trim().Length == 0 || !Validity.IsOnlyDigit(args[4].ToString().Trim()) ||
                    Convert.ToInt32(args[4].ToString().Trim()) < 0)
                {
                    isValid = false;
                    UMain.NLAftPrintAftDol("Invalid value for year experience, please insert again!");
                }
                else
                {
                    isValid = true;
                }
            }
        }
        else
        {
            args[4] = null;
        }









        //______________________________Save Changes______________________________        
        UMain.NLAftPrintAftDol("_________________________________________________________________________");
        UMain.OnlyPrintAftDol("Save Changes? y/n: ");
        string saveChange = UMain.SLReadLine();
        string savedDetail = "";
        if (saveChange.Trim() == "Y" || saveChange.Trim() == "y")
        {
            bool reason = DManagerCmd.CreateMan(args, out savedDetail);

            if(reason)
            {
                UMain.NLAftPrintAftDol("Manager created Successfully!");
                UMain.NLAftPrintAftDol("Press any key to continue...");
                Console.ReadKey();
                Console.WriteLine();
                return true;
            }

            UMain.NLAftPrintAftDol("Couldn't create the manager!");
            UMain.NLAftPrintAftDol(savedDetail);
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