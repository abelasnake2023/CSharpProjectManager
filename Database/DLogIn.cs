namespace CSharpProjectManager.Database;



using ALib.Database.ALibSqlServer;
using System.Data.SqlClient;
using System.Diagnostics;



public class DLogIn
{
    public DLogIn()
    {

    }

    public static bool ValidUser(string username, string password, out string reason)
    {
        object[,] param = new object[2, 3]
        {
            { "@username", "varchar", username },
            { "@password", "varchar", password }
        };

        try
        {
            ALibDataReader reader = new ALibDataReader();
            object[,]result = reader.ExecuteTableValuedFunction("SearchManager", "*", param);

            reason = (string)result[0, 1];
            return (bool)result[0, 0];
        }
        catch(SqlException es)
        {
            reason = "Error!";
            Debug.WriteLine(es.Message);
        }
        catch(Exception e)
        {
            reason = "Error!";
            Debug.WriteLine(e.Message);
        }

        reason = "Error!";
        return false;
    }
}