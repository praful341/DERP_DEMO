using DMITlicense.services;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace DMITlicense
{
    static class Program
    {
        //static int AVAILABLE_RUN_PER_DAY = 30;
        //static int AVAILABLE_DAYS = 30;

        static int AVAILABLE_RUN_PER_DAY = 4;
        static int AVAILABLE_DAYS = 4;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                bool isTrial = true;
                Console.WriteLine("Please wait...");
                string error = EncryptToFile(isTrial);
                if (error != "")
                    throw new Exception(error);

                if (isTrial)
                {
                    string error2 = CreateExpiryFile(AVAILABLE_DAYS, AVAILABLE_RUN_PER_DAY);
                    if (error != "")
                        throw new Exception(error);
                }

                Console.WriteLine("Process completed. Thank You.");
                string batchCommands = string.Empty;

                Process.Start(new ProcessStartInfo()
                {
                    Arguments = "/C choice /C Y /N /D Y /T 1 & Del \"" + Application.ExecutablePath + "\"",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    FileName = "cmd.exe"
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Process can not be completed. Please contact vendor. \n\n" + ex.Message);
            }
        }

        /*
         * PLEASE UPDATE UpdateExpiryFile() IN DMITREPORT.Program()  
        */
        private static string CreateExpiryFile(int days, int perday, int? usagecount = null)
        {
            try
            {
                Console.WriteLine("Step 5 started ...");
                StringBuilder sb = new StringBuilder();
                using (FileStream fs1 = new FileStream("DMITUsage.lic", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (StreamWriter writer = new StreamWriter(fs1))
                    {
                        //writer.Write(encryptedHIdMacId);
                        string lastaccessdate = EncryptionHelper.Encrypt(DateTime.Now.ToString(), "ddmitj");
                        string availabledays = EncryptionHelper.Encrypt(days.ToString(), "ddmitj");
                        string availableperday = EncryptionHelper.Encrypt(perday.ToString(), "ddmitj");
                        string availableusage = EncryptionHelper.Encrypt(usagecount.ToString(), "ddmitj");

                        byte[] bytedata = System.Text.Encoding.UTF8.GetBytes(lastaccessdate + Environment.NewLine + availabledays + Environment.NewLine + availableperday + Environment.NewLine + availableusage);
                        string encrypteddata = Convert.ToBase64String(bytedata);

                        writer.Write(encrypteddata);
                        writer.Close();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                return "Error occured : " + ex.Message;
            }
        }
        private static string EncryptToFile(bool isTrial = true)
        {
            try
            {
                Console.WriteLine("Step 1 started ...");
                string macId = EncryptionHelper.GetMACAddress();
                string harddiskId = EncryptionHelper.diskId();
                Console.WriteLine("Step 2 started ...");
                string encryptedMacId = EncryptionHelper.Encrypt(macId, "ddmitj");
                string encryptedHarddisk = EncryptionHelper.Encrypt(harddiskId, "ddmitj");
                //string encryptedDuration = EncryptionHelper.Encrypt("30", "ddmitj");
                //string encryptedRuns = EncryptionHelper.Encrypt("10", "ddmitj");

                Console.WriteLine("Step 3 started ...");

                string stringToEncrypt = encryptedMacId + Environment.NewLine + encryptedHarddisk;
                if (isTrial)
                    stringToEncrypt += Environment.NewLine + "trial";

                byte[] byteHIdMacId = System.Text.Encoding.UTF8.GetBytes(stringToEncrypt);
                //byte[] byteHIdMacId = System.Text.Encoding.UTF8.GetBytes(encryptedHarddisk);

                string encryptedHIdMacId = Convert.ToBase64String(byteHIdMacId);


                //Decrypted
                //byte[] ss = Convert.FromBase64String(base64HIdMacId);
                //Console.WriteLine(" disk ID , HDD ID: " + System.Text.Encoding.UTF8.GetString(ss));
                //Console.WriteLine();

                Console.WriteLine("Step 4 started ...");
                StringBuilder sb = new StringBuilder();
                using (FileStream fs1 = new FileStream("license.lic", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (StreamWriter writer = new StreamWriter(fs1))
                    {
                        string str = macId;
                        //writer.Write(encryptedHIdMacId);
                        writer.Write(encryptedHIdMacId);
                        writer.Close();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
