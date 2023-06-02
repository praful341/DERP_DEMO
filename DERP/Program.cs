using DERP.services;
using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace DERP
{
    static class Program
    {
        static int AVAILABLE_RUN_PER_DAY = 2;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new FrmLogin());
        //}

        [STAThread]
        static void Main()
        {
            //string resource1 = "DERP.DataLayerDMIT.dll";
            //string resource2 = "DERP.itextsharp.dll";

            //EmbeddedAssembly.Load(resource1, "DataLayerDMIT.dll");
            //EmbeddedAssembly.Load(resource2, "itextsharp.dll");

            //AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
            //// AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve1);

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //try
            //{
            //    FileInfo licenseFile = new FileInfo("license.lic");
            //    if (licenseFile.Exists)
            //    {
            //        ////if (DMITReport.Properties.Settings.Default.MAC == "")
            //        //{
            //        //    DMITReport.Properties.Settings.Default.MAC = EncryptionHelper.Encrypt(EncryptionHelper.GetMACAddress(), "ddmitj");
            //        //    ConfigurationManager.RefreshSection(DMITReport.Properties.Settings.Default.MAC);
            //        //    DMITReport.Properties.Settings.Default.Save();
            //        //}
            //        //for resetting 
            //        string[] CommandLineArgs = Environment.CommandLine.Split(' ');
            //        //if (CommandLineArgs.Length == 2)
            //        {
            //            if (CommandLineArgs[CommandLineArgs.Length - 1] == "qwerty")
            //            {
            //                DERP.Properties.Settings.Default.DID = "";
            //                DERP.Properties.Settings.Default.Password = "dmit";
            //                ConfigurationManager.RefreshSection(DERP.Properties.Settings.Default.Password);
            //                DERP.Properties.Settings.Default.Save();
            //                return;
            //            }
            //        }
            //        if (DERP.Properties.Settings.Default.DID == "")
            //        {
            //            var diskId = EncryptionHelper.diskId();
            //            DERP.Properties.Settings.Default.DID = EncryptionHelper.Encrypt(diskId, "ddmitj");
            //            ConfigurationManager.RefreshSection(DERP.Properties.Settings.Default.DID);
            //            DERP.Properties.Settings.Default.Save();
            //        }

            //        string license = File.ReadAllText("license.lic");

            //        //decrypt content of file

            //        byte[] ss = Convert.FromBase64String(license);
            //        string str = System.Text.Encoding.UTF8.GetString(ss);
            //        string[] strArray = str.Split('\n');
            //        if (strArray.Length < 2)
            //            throw new Exception();

            //        string enctryptedMAC = strArray[0].Trim();
            //        string enctryptedDeviceID = strArray[1].Trim();

            //        //if (EncryptionHelper.Encrypt(EncryptionHelper.GetMACAddress(), "ddmitj") != license)
            //        if (EncryptionHelper.Encrypt(EncryptionHelper.GetMACAddress(), "ddmitj") != enctryptedMAC || DERP.Properties.Settings.Default.DID != enctryptedDeviceID)
            //        {
            //            throw new Exception();
            //        }
            //        else
            //        {
            //            //CHECK VALIDITY
            //            // Check date difference. 
            //            /*     
            //             *     int availabe_days = 30;
            //             *     int available_run_per_day = 10;
            //             *     IF (available_days == 0 || available_run_per_day == 0) THEN
            //             *           SOFTWARE EXPIRED
            //             *     ELSE
            //             *           IF (last_access_date != current_date) THEN
            //             *                  available_days = available_days - 1;
            //             *           ELSE
            //             *                  available_run_per_day = available_run_per_day - 1
            //             *           END
            //             *     END
            //             */

            //            /*
            //             * Check if need to check validity of software or not. 
            //             * 3rd line of license file is expiry duration and 
            //             * 4th is available run allowed per day.
            //             * 
            //             */
            //            if (strArray.Length == 3)
            //            {
            //                //get last access date. store new last access date
            //                int duration = 0, run_per_day = 0;
            //                DateTime lastAcessDT = DateTime.MinValue;

            //                if (!File.Exists("DMITUsage.lic"))
            //                    throw new Exception();

            //                string licenseTrial = File.ReadAllText("DMITUsage.lic");

            //                //decrypt content of file

            //                byte[] ssTrial = Convert.FromBase64String(licenseTrial);
            //                string strTrial = System.Text.Encoding.UTF8.GetString(ssTrial);
            //                string[] strTrialArray = strTrial.Split('\n');
            //                // string a = EncryptionHelper.Decrypt("yhiJfmZPKoL8by4btWuvRQ==", "ddmitj");
            //                //if (strArray.Length < 6)
            //                //  throw new Exception();

            //                if (DateTime.TryParse(EncryptionHelper.Decrypt(strTrialArray[0], "ddmitj"), out lastAcessDT) && int.TryParse(EncryptionHelper.Decrypt(strTrialArray[1], "ddmitj"), out duration) && int.TryParse(EncryptionHelper.Decrypt(strTrialArray[2], "ddmitj"), out run_per_day))
            //                {
            //                    if (duration <= 0)
            //                    {
            //                        MessageBox.Show("Your trial period expired.");
            //                        throw new Exception();
            //                    }
            //                    if (run_per_day == 1)
            //                    {
            //                        duration = duration - 1;
            //                        run_per_day = AVAILABLE_RUN_PER_DAY;
            //                    }

            //                    int updatedduration = duration;
            //                    int updatedPerDay = run_per_day;

            //                    if (lastAcessDT.Day != DateTime.Now.Day || lastAcessDT.Month != DateTime.Now.Month || lastAcessDT.Year != DateTime.Now.Year)
            //                    {
            //                        UpdateExpiryFile(duration - 1, AVAILABLE_RUN_PER_DAY);
            //                    }
            //                    else
            //                    {
            //                        UpdateExpiryFile(duration, run_per_day - 1);
            //                    }
            //                }
            //                else
            //                {
            //                    throw new Exception();
            //                }
            //            }
            //        }
            //    }
            //    else
            //    {
            //        throw new Exception();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ShowErrorResponse();
            //    return;
            //}
            Application.Run(new FrmLogin());
        }
        private static void ShowErrorResponse()
        {
            (new AboutBox()).ShowDialog();
        }
        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return EmbeddedAssembly.Get(args.Name);
        }

        private static string UpdateExpiryFile(int days, int perday)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                using (FileStream fs1 = new FileStream("DMITUsage.lic", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (StreamWriter writer = new StreamWriter(fs1))
                    {
                        //writer.Write(encryptedHIdMacId);
                        string lastaccessdate = EncryptionHelper.Encrypt(DateTime.Now.ToString(), "ddmitj");
                        string availabledays = EncryptionHelper.Encrypt(days.ToString(), "ddmitj");
                        string availableperday = EncryptionHelper.Encrypt(perday.ToString(), "ddmitj");

                        byte[] bytedata = System.Text.Encoding.UTF8.GetBytes(lastaccessdate + Environment.NewLine + availabledays + Environment.NewLine + availableperday);
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
    }
}
