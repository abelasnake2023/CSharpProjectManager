namespace CSharpProjectManager.Database.DMain;

using ALib.Database.ALibSqlServer;
using ALibWinForms.Ui;
using ALibWinForms.Ui.Photo;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;

public class DManagerCmd
{
    public DManagerCmd()
    {

    }


    public static bool CreateMan(object[] values, out string detail)
    {
        object[,] param = new object[21, 3]
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
            { "@salContEnd", "DateTime", values[20] }
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
}