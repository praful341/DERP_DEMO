using MBDataLib;
using System;
using System.Collections;

namespace DERP.Report.Barcode_Print
{

    public class BarcodePrint
    {
        public class Pkt
        {
            public string KapanNo = string.Empty;
            public string SrNo = "0";
            public string Date = string.Empty;
            public Int64 LotId = 0;
            public bool RBar = false;
            public int pcs = 0;
            public decimal carat = 0;

            public Pkt(string pStrKapan, string pIntSrNo, string pStrDate, int pIntLotId, int pIntPc, decimal pDecCarat, bool pBoolRBar)
            {
                this.KapanNo = pStrKapan;
                this.SrNo = pIntSrNo;
                this.Date = pStrDate;
                this.LotId = pIntLotId;
                this.RBar = pBoolRBar;
                this.pcs = pIntPc;
                this.carat = pDecCarat;
            }
        }

        // Comment By Praful On 06042021

        //private string _mStrBarPos = "O0215";

        //private string _StrPrnLast = "";

        //private string _StrPrnFirst = "";

        //private string _StrBarCode = "";
        //private int IntIndex = 0;

        // End By Praful On 06042021

        private ArrayList _Pkt = new ArrayList();
        public void AddPkt(string pStrKapan, string pIntSrNo, string pStrDate, int pIntLotId, int pIntPc, decimal pDecCarat, bool pBoolRBar)
        {
            this._Pkt.Add(new BarcodePrint.Pkt(pStrKapan, pIntSrNo, pStrDate, pIntLotId, pIntPc, pDecCarat, pBoolRBar));
        }
        public void PrintTSC()
        {
            string pStrFileName = System.Windows.Forms.Application.StartupPath + @"\Output2.txt";//Global.gStrVersion + "\\Output2.txt";
            Printing.FileOpen(pStrFileName);
            BarcodePrint.Pkt[] array = new BarcodePrint.Pkt[this._Pkt.Count];
            for (int i = 0; i < this._Pkt.Count; i++)
            {
                array[i] = (BarcodePrint.Pkt)this._Pkt[i];
            }
            BarcodePrint.Pkt[] array2 = array;
            for (int j = 0; j < array2.Length; j++)
            {
                BarcodePrint.Pkt pkt = array2[j];


                // Comment By Praful On 06042021

                //string text;

                //{
                //    text = "";
                //}

                //string text2 = "";
                //string text3 = "";
                //string text4 = "";
                //string text7 = "";

                // End By  Praful On 06042021

                string carat = pkt.carat.ToString("#.000");



                //bool flag = false;

                Printing.PrintLine("<xpml><page quantity='0' pitch='15.0 mm'></xpml>I8,A");
                Printing.PrintLine("ZN");
                Printing.PrintLine("q304");
                Printing.PrintLine("O");
                Printing.PrintLine("JF");
                Printing.PrintLine("KIZZQ0");
                Printing.PrintLine("KI9+0.0");
                Printing.PrintLine("ZT");
                Printing.PrintLine("Q120,25");
                Printing.PrintLine("Arglabel 150 31");
                Printing.PrintLine("exit");
                Printing.PrintLine("KI80");
                Printing.PrintLine("<xpml></page></xpml><xpml><page quantity='1' pitch='15.0 mm'></xpml>N");
                Printing.PrintLine("B275,106,2,1,2,4,45,N,\"" + pkt.LotId + "\"");
                Printing.PrintLine("A275,55,2,3,1,1,N,\"" + pkt.LotId + "\"");
                Printing.PrintLine("A275,29,2,2,1,1,N,\"" + pkt.Date + "\"");
                Printing.PrintLine("A93,104,2,1,1,1,N,\"" + pkt.KapanNo + "\"");
                Printing.PrintLine("A61,85,2,3,1,1,N,\"" + pkt.SrNo + "\"");
                Printing.PrintLine("A93,56,2,3,1,1,N,\"" + carat + "\"");
                Printing.PrintLine("A93,29,2,3,1,1,N,\"" + pkt.pcs + "\"");
                Printing.PrintLine("P1");
                Printing.PrintLine("<xpml></page></xpml><xpml><end/></xpml>");

                //this._StrPrnLast = "";
                //this._StrBarCode = "";
                //this._StrPrnFirst = "";

                //{



                //    this._StrPrnLast = string.Concat(new string[]
                //        {
                //            " [Crt:",
                //            //pkt.pDecCarat,
                //            " ",
                //            text4,
                //            "]",
                //            text7,
                //            text,
                //            "[",
                //            text2,
                //            "][",
                //            text3,
                //            "]"
                //        });


                //    this._StrBarCode = string.Concat(new string[]
                //        {
                //            //pkt.L_Code,
                //            "/",
                //            pkt.SrNo,
                //            "/",
                //            //pkt.Tag
                //        });

                //}

                //Printing.PrintLine("BARCODE 425,147,\"128M\",56,0,180,2,4,\"" + this._StrBarCode + "\"");
                ////Printing.PrintLine("CODEPAGE 1252");
                ////Printing.PrintLine("TEXT 412,75,\"ROMAN.TTF\",180,1,12,\"" + pkt.L_Code + "\"");
                ////Printing.PrintLine("TEXT 411,37,\"ROMAN.TTF\",180,1,12,\"" + pkt.SrNo + "\"");
                ////Printing.PrintLine("TEXT 275,37,\"ROMAN.TTF\",180,1,12,\"" + pkt.Tag + "\"");
                ////Printing.PrintLine("TEXT 197,37,\"ROMAN.TTF\",180,1,12,\"" + pkt.weight + "\"");
                //Printing.PrintLine("PRINT 1,1");

            }
            Printing.FileClose();
            if (BLL.GlobalDec.gEmployeeProperty.branch_id == 1)
                Printing.PrintBarcode(pStrFileName, "PRINTFIB.bat");
            else if (BLL.GlobalDec.gEmployeeProperty.branch_id == 9)
                Printing.PrintBarcode(pStrFileName, "PRINTSIB.bat");
        }

        public void PrintTSC1(string pStrFileName)
        {
            if (BLL.GlobalDec.gEmployeeProperty.branch_id == 1)
                Printing.PrintBarcode(pStrFileName, "PRINTFIB.bat");
            else if (BLL.GlobalDec.gEmployeeProperty.branch_id == 9)
                Printing.PrintBarcode(pStrFileName, "PRINTSIB.bat");
        }
    }
}
