using ALib.BusinessLogic;
using ALib.Networking;
using ALibWinForms.Ui;
using ALibWinForms.Ui.Photo;
using ALibWinForms.Ui.Video;
using CSharpProjectManager.Database.DMain;
using CSharpProjectManager.UI;
using System.Xml.Serialization;

namespace CSharpProjectManager.BusinessLogic.BMain;

public class ExecUserCmd
{
    public static void PostVideo(string cmd)
    {
        string videoFilePath = cmd.Substring(cmd.IndexOf('$') + 1);
        byte[] videoByteArray = VideoConverter.ConvertVideoToByteArray(videoFilePath);

        if(videoByteArray != null )
        {
            ExecPostVideo(videoByteArray);
        }
        else
        {
            UMain.NLAftPrintAftDol("File not video!\nError!");
        }
    }
    private static bool ExecPostVideo(byte[] videoByte)
    {
        object[] args = new object[3];
        byte[] photoByte = null;
        double videoSize = 0;
        int videoId = 0;
        bool isValid = false;

        UMain.NLBefAftPrintAftDol("Press `q`/`Q` to exit!", 2, 2);


        UMain.NLBefAftPrintAftDol("_________________________________________________________________________");
        // Accept thumbnail
        UMain.OnlyPrintAftDol("Thumbnail photo(file path): ");
        isValid = false;
        while (!isValid)
        {
            args[0] = UMain.SLReadLine().Trim();

            if (args[0].ToString().Trim() == "q" || args[0].ToString().Trim() == "Q")
            {
                return false;
            }

            photoByte = PhotoConverter.ConvertImageFileToByteArray(args[0].ToString());

            if (photoByte == null)
            {
                isValid = false;
                UMain.NLAftPrintAftDol("Not photo!\nInsert again!");
            }
            else
            {
                isValid = true;
                args[0] = photoByte;
            }
        }



        // Upload video to database
        UMain.OnlyPrintAftDol("Upload video To Database? y/n: ");
        isValid = false;
        args[1] = UMain.SLReadLine().Trim();
        while (!isValid)
        {
            if (args[1].ToString().Trim() == "q" || args[1].ToString().Trim() == "Q")
            {
                return false;
            }
            else if (args[1].ToString().Trim() == "y" || args[1].ToString().Trim() == "Y")
            {
                // Calculate size in bytes
                long sizeInBytes = videoByte.Length;
                // Convert to megabytes
                videoSize = (double)sizeInBytes / (1024 * 1024);

                bool videoUploaded = DManagerCmd.UploadVideoToDb(videoByte, photoByte, videoSize, out videoId);

                if (videoUploaded)
                {
                    UMain.NLAftPrintAftDol("Video uploaded to Database successfully!");
                    isValid = true;
                }
                else
                {
                    UMain.NLAftPrintAftDol("Unable to upload video to Database!\nTry again? y/n");
                    char choice = UMain.SLReadLine().Trim().ElementAt(0);

                    if(choice == 'y' || choice == 'Y')
                    {
                        isValid = false;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }



        // Upload the video to the app from the database
        UMain.OnlyPrintAftDol("Upload video To App? y/n: ");
        isValid = false;
        args[2] = UMain.SLReadLine().Trim();
        while(!isValid)
        {
            if (args[2].ToString().Trim() == "q" || args[2].ToString().Trim() == "Q")
            {
                return false;
            }
            else if (args[2].ToString().Trim() == "y" || args[2].ToString().Trim() == "Y")
            {

                isValid = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        return false;
    }

    public static void DelVideo(string cmd)
    {

    }
/*    private static bool ExecDelVideo()
    {

    }*/
}