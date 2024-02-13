namespace CSharpProjectManager.Database.DMain;

using ALib.Database.ALibSqlServer;
using ALibWinForms.Ui;
using ALibWinForms.Ui.Photo;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

public class DManagerCmd
{
    public DManagerCmd()
    {

    }


    public static bool CreateMan(object[] values, out string detail)
    {
        object[,] param = new object[22, 3]
        {
            { "@dob", "DateTime", values[0] },
            { "@skills", "varchar", values[1] },
            { "@skillType", "varchar", values[2] },
            { "@certificate", "varbinary", PhotoConverter.ConvertImageToByteArray((Image)values[3]) },
            { "@yearExpSkill", "int", values[4] },
            { "@region", "varchar", values[5] },
            { "@city", "varchar", values[6] },
            { "@subCity", "varchar", values[7] },
            { "@woreda", "int", values[8] },
            { "@hNum", "int", values[9] },
            { "@phone", "varchar", values[10] },
            { "@email", "varchar", values[11] },
            { "@mPhoto", "varbinary", PhotoConverter.ConvertImageToByteArray((Image)values[12]) },
            { "@mFName", "varchar", values[13] },
            { "@mMName", "varchar", values[14] },
            { "@mLName", "varchar", values[15] },
            { "@mUName", "varchar", values[16] },
            { "@mPassword", "varchar", values[17] },
            { "@salary", "Decimal", values[18] },
            { "@salStart", "DateTime", values[19] },
            { "@salContEnd", "DateTime", values[20] },
            { "@manManId", "int", values[21] }
        };


        try
        {
            ALibDataReader reader = new ALibDataReader();
            reader.ExecuteStoredProcedure("CreateManager", param, 60);

            detail = "Manager created successfully!";
            return true;
        }
        catch(SqlException ex)
        {
            if (ex.Number == -2) // SQL Server command timeout error
            {
                detail = "Unable to establish a connection to the database. Please try again later or contact support.";
            }
            else if (ex.Number == 53) // SQL Server connection failure error
            {
                detail = "Connection failed!";
            }
            else
            {
                detail = "An error occurred while processing your request. Please try again or contact support.";
            }

            return false;
        }
        catch(Exception ex)
        {
            detail = "An error occurred while processing your request. Please try again or contact support.";
            return false;
        }
    }
    public static bool UniqueManager(string username, out string details)
    {
        object[,] param = new object[1, 3]
        {
            { "@username", "varchar", username.Trim() }
        };

        try
        {
            ALibDataReader reader = new ALibDataReader();
            object isUnique = reader.ExecuteScalarFunction("dbo.IsManUNameUnique", param, 30);
            if ((bool)isUnique == null)
            {
                details = "Username is unique.";
            }
            else
            {
                details = "Username is not unique.";
            }
            return (bool)isUnique;
        }
        catch(SqlException es)
        {
            Debug.WriteLine("Error: " + es.Message);
            details = "Connection error.";
            return false;
        }
        catch (Exception ex)
        {
            details = "Unkown error.";
            Debug.WriteLine("Error: " + ex.Message);
            return false;
        }
    }
    public static int GetManagerIdByUserName(string username)
    {
        username = username.Trim();

        object[,] param = new object[1, 3]
        {
            { "@username", "varchar", username }
        };

        try
        {
            ALibDataReader reader = new ALibDataReader();
            int mId = (int)reader.ExecuteScalarFunction("dbo.GetManagerIdByUsername", param, 15);

            return mId;
        }
        catch(SqlException es)
        {
            return 0;
        }
        catch(Exception ex)
        {
            return 0;
        }
    }
    public static bool IsUniqueAccNum(string accNum)
    {
        accNum = accNum.Trim();

        object[,] param = new object[1, 3]
        {
            { "@accNum", "varchar", accNum }
        };

        try
        {
            ALibDataReader reader = new ALibDataReader();
            bool isUnique = (bool)reader.ExecuteScalarFunction("dbo.IsUniqueAccNum", param, 60);

            if(isUnique)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch
        {
            return false;
        }
    }
    public static string CreateAccAndGetAccNum(object[] values, out string detail)
    {
        object[,] param = new object[20, 5]
        {
                    { "@aFName", "varchar", values[0], false, 0 },
                    { "@aMName", "varchar", values[1], false, 0 },
                    { "@aLName", "varchar", values[2], false, 0 },
                    { "@dob", "DateTime", values[3], false, 0 },
                    { "@region", "varchar", values[4], false, 0 },
                    { "@city", "varchar", values[5], false, 0 },
                    { "@subCity", "varchar", values[6], false, 0 },
                    { "@woreda", "int", values[7], false, 0 },
                    { "@hNum", "int", values[8], false, 0 },
                    { "@phone", "varchar", values[9], false, 0 },
                    { "@email", "varchar", values[10], false, 0 },
                    { "@mPhoto", "varbinary", PhotoConverter.ConvertImageToByteArray((Image)values[11]), false, 0 },
                    { "@iBalance", "Decimal", values[12], false, 0 },
                    { "@ban", "bit", values[13], false, 0 },
                    { "@active", "bit", values[14], false, 0 },
                    { "@aType", "varchar", values[15], false, 0 },
                    { "@sourceOfIncome", "varchar", values[16], false, 0 },
                    { "@loan", "bit", values[17], false, 0 },
                    { "@mId", "int", values[18], false, 0 },
                    { "@accNum", "varchar", "", true, 13}
        };

        try
        {
            ALibDataReader reader = new ALibDataReader();
            object[] o = reader.ExecuteStoredProcedureWithOutPutParam("CreateAccount", param, 20);

            detail = "Account created successfully!";
            return o[0].ToString(); // returning the account number
        }
        catch (SqlException ex)
        {
            if (ex.Number == -2) // SQL Server command timeout error
            {
                detail = "Unable to establish a connection to the database. Please try again later or contact support.";
            }
            else if (ex.Number == 53) // SQL Server connection failure error
            {
                detail = "Connection failed!";
            }
            else
            {
                detail = "An error occurred while processing your request. Please try again or contact support.";
            }

            return null;
        }
        catch (Exception ex)
        {
            detail = "An error occurred while processing your request. Please try again or contact support.";
            return null;
        }
    }
    public static bool UploadVideoToDb(byte[] videoByte, byte[] thumbnail, double size, out int videoId)
    {
        object[,] param = new object[4, 5]
        {
            { "@video", "varbinary", videoByte, false, 0 },
            { "@thumbnail", "varbinary", thumbnail, false, 0 },
            { "@size", "decimal", size, false, 0 },
            { "@id", "int", -1, true, "Not needed" }
        };

        try
        {
            ALibDataReader reader = new ALibDataReader();
            object[] vId = reader.ExecuteStoredProcedureWithOutPutParam("CVideoApp", param);

            videoId = (int)vId[0];
            return true;
        }
        catch (SqlException ex)
        {
            videoId = -1;
            return false;
        }
        catch (Exception ex)
        {
            videoId = -1;
            return false;
        }
    }
}