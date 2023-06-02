﻿using BLL;
using BLL.FunctionClasses.Master.MFG;
using BLL.FunctionClasses.Transaction;
using BLL.FunctionClasses.Transaction.MFG;
using BLL.PropertyClasses.Report;
using BLL.PropertyClasses.Transaction;
using DERP.Class;
using DERP.Master;
using DERP.Master.MFG;
using DERP.Report;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DREP.Master;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static DERP.Class.Global;

namespace DERP.Transaction.MFG
{
    public partial class FrmMFGAssortFirst : DevExpress.XtraEditors.XtraForm
    {
        #region Data Member

        BLL.BeginTranConnection Conn;
        BLL.FormEvents objBOFormEvents;
        BLL.FormPer ObjPer;
        BLL.Validation Val;
        DataTable m_dtbSubProcess = new DataTable();
        DataTable m_dtbColor = new DataTable();
        MFGAssortFirst objAssortFirst;
        MFGProcessReceive objProcessReceive;
        MfgRoughSieve objRoughSieve;
        MfgRoughClarityMaster objClarity;
        //DataTable DTab_KapanWiseData = new DataTable();

        public New_Report_DetailProperty ObjReportDetailProperty;
        private List<Control> _tabControls = new List<Control>();
        Control _NextEnteredControl = new Control();
        FillCombo ObjFillCombo = new FillCombo();
        DataTable DtControlSettings;
        DataTable dtTemp;
        DataTable m_dtbParam;
        DataTable m_dtCut;
        DataTable m_DtProcess;
        DataTable m_dtbKapan;
        DataTable m_dtOutstanding;
        DataTable DtAssortment = new DataTable();
        DataTable DTabQuality = new DataTable();

        Int64 m_numForm_id;
        Int64 IntRes;
        Int64 Receive_IntRes;
        Int64 Lot_SrNo = 0;
        int m_IsLot;

        string StrListTempPurity = string.Empty;

        #endregion

        #region Constructor
        public FrmMFGAssortFirst()
        {
            InitializeComponent();

            objBOFormEvents = new BLL.FormEvents();
            ObjPer = new BLL.FormPer();
            Val = new BLL.Validation();

            objAssortFirst = new MFGAssortFirst();
            objRoughSieve = new MfgRoughSieve();
            objClarity = new MfgRoughClarityMaster();
            ObjReportDetailProperty = new New_Report_DetailProperty();
            objProcessReceive = new MFGProcessReceive();
            DtControlSettings = new DataTable();
            dtTemp = new DataTable();
            m_dtbParam = new DataTable();
            m_dtCut = new DataTable();
            m_DtProcess = new DataTable();
            m_dtOutstanding = new DataTable();
            m_dtbKapan = new DataTable();
            m_numForm_id = 0;
            m_IsLot = 0;
        }
        public void ShowForm()
        {
            ObjPer.FormName = this.Name.ToUpper();
            m_numForm_id = ObjPer.form_id;
            if (ObjPer.CheckPermission() == false)
            {
                Global.Message(BLL.GlobalDec.gStrPermissionViwMsg);
                return;
            }
            Val.frmGenSet(this);
            AttachFormEvents();
            if (Global.HideFormControls(Val.ToInt(ObjPer.form_id), this) != "")
            {
                Global.Message("Select First User Setting...Please Contact to Administrator...");
                return;
            }

            ControlSettingDT(Val.ToInt(ObjPer.form_id), this);
            AddGotFocusListener(this);
            // AddKeyPressListener(this);
            this.KeyPreview = true;

            TabControlsToList(this.Controls);
            _tabControls = _tabControls.OrderBy(x => x.TabIndex).ToList();
            this.Show();
        }
        private void AttachFormEvents()
        {
            objBOFormEvents.CurForm = this;
            objBOFormEvents.FormKeyPress = true;
            objBOFormEvents.FormKeyDown = true;
            objBOFormEvents.FormResize = true;
            objBOFormEvents.FormClosing = true;
            objBOFormEvents.ObjToDispose.Add("");
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }
        #endregion

        #region Events
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ObjPer.SetFormPer();
                if (ObjPer.AllowUpdate == false || ObjPer.AllowInsert == false)
                {
                    Global.Message(BLL.GlobalDec.gStrPermissionInsUpdMsg);
                    return;
                }
                List<ListError> lstError = new List<ListError>();
                Dictionary<Control, string> rtnCtrls = new Dictionary<Control, string>();
                rtnCtrls = Global.CheckCompulsoryControls(Val.ToInt(ObjPer.form_id), this);
                if (rtnCtrls.Count > 0)
                {
                    foreach (KeyValuePair<Control, string> entry in rtnCtrls)
                    {
                        if (entry.Key is DevExpress.XtraEditors.LookUpEdit || entry.Key is DevExpress.XtraEditors.DateEdit || entry.Key is DevExpress.XtraEditors.TextEdit)
                        {
                            lstError.Add(new ListError(13, entry.Value));
                        }
                    }
                    rtnCtrls.First().Key.Focus();
                    BLL.General.ShowErrors(lstError);
                    Cursor.Current = Cursors.Arrow;
                    return;
                }
                //string Str = "";
                //if (Val.DBDate(BLL.GlobalDec.gStrServerDate) != Val.DBDate(dtpReceiveDate.Text))
                //{
                //    Str = GlobalDec.CheckLockIsOpenOrNot(Val.DBDate(dtpReceiveDate.Text), Val.DBTime(DateTime.Now.ToShortTimeString())); //Val.GetFullTime12());
                //    if (Str != "YES")
                //    {
                //        if (Str != "")
                //        {
                //            Global.Message(Str);
                //            return;
                //        }
                //        else
                //        {
                //            Global.Message("You Are Not Suppose to Make Entry On Different Date");
                //            return;
                //        }
                //    }
                //    else
                //    {
                //        dtpReceiveDate.Enabled = true;
                //        dtpReceiveDate.Visible = true;
                //    }
                //}

                //if (Val.ToDecimal(lblOsCarat.Text) != Val.ToDecimal(txtTotal.Text))
                //{
                //    Global.Message("Entry Carat Not match O/s Carat");
                //    return;
                //}

                if (Val.ToDecimal(txtCarat.Text) != Val.ToDecimal(txtTotal.Text))
                {
                    Global.Message("Entry Carat Not match O/s Carat");
                    return;
                }

                //btnSave.Enabled = false;

                if (!ValidateDetails())
                {
                    return;
                }
                DialogResult result = MessageBox.Show("Do you want to save Assort First Receive data?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result != DialogResult.Yes)
                {
                    btnSave.Enabled = true;
                    return;
                }

                DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
                backgroundWorker_AssortFirstReceive.RunWorkerAsync();

                btnSave.Enabled = true;
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            //grdProcessReceive.DataSource = null;
            //btnSearch_Click(null, null);
            ClearDetails();
            panelControl1.Enabled = true;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_Print_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable DTab_IssueJanged = objAssortFirst.Print_Semi_1(Val.ToInt32(lueKapan.EditValue), Val.ToInt32(lueCutNo.EditValue), Val.ToInt32(lueProcess.EditValue), Val.ToInt32(lueSubProcess.EditValue), Val.ToString(ListQuality.Text), Val.ToString(lueSieve.Text), Val.ToInt64(lblLotSRNo.Text), Val.ToInt64(RBtnType.EditValue));

                FrmReportViewer FrmReportViewer = new FrmReportViewer();
                FrmReportViewer.DS.Tables.Add(DTab_IssueJanged);
                FrmReportViewer.GroupBy = "";
                FrmReportViewer.RepName = "";
                FrmReportViewer.RepPara = "";
                this.Cursor = Cursors.Default;
                FrmReportViewer.AllowSetFormula = true;

                if (RBtnType.EditValue.ToString() == "1")
                {
                    FrmReportViewer.ShowForm("CrtPolishGrading_Semi1", 120, FrmReportViewer.ReportFolder.ACCOUNT);
                    //FrmReportViewer.ShowForm("CrtPolishGrading_Semi1_New", 120, FrmReportViewer.ReportFolder.ACCOUNT);
                }
                else
                {
                    FrmReportViewer.ShowForm("CrtPolishGrading_Semi1_Mumbai", 120, FrmReportViewer.ReportFolder.ACCOUNT);
                }

                DTab_IssueJanged = null;
                FrmReportViewer.DS.Tables.Clear();
                FrmReportViewer.DS.Clear();
                FrmReportViewer = null;
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                return;
            }
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            try
            {
                dgvAssortFirst.Columns.Clear();

                //MFGJangedIsuRecAssortment objMFGJangedIsuRec = new MFGJangedIsuRecAssortment();
                //MFGProcessIssueProperty objMFGProcessIssueProperty = new MFGProcessIssueProperty();
                ////objMFGProcessIssueProperty.rough_cut_id = Val.ToInt(lueCutNo.EditValue);
                ////objMFGProcessIssueProperty.kapan_id = Val.ToInt(lueKapan.EditValue);
                //objMFGProcessIssueProperty.rough_cut_id = Val.ToInt(0);
                //objMFGProcessIssueProperty.kapan_id = Val.ToInt(0);
                //objMFGProcessIssueProperty.flag = Val.ToInt(1);
                //objMFGProcessIssueProperty.process_id = Val.ToInt(lueProcess.EditValue);
                //objMFGProcessIssueProperty.sub_process_id = Val.ToInt(lueSubProcess.EditValue);
                //objMFGProcessIssueProperty.temp_sieve_name = Val.ToString("");
                //objMFGProcessIssueProperty.temp_purity_name = Val.ToString("");
                //objMFGProcessIssueProperty.from_date = Val.DBDate(dtpReceiveDate.Text);
                //objMFGProcessIssueProperty.to_date = Val.DBDate(dtpReceiveDate.Text);

                //if (RBtnType.EditValue.ToString() == "1")
                //{
                //    objMFGProcessIssueProperty.location_id = Val.ToInt32(1);
                //}
                //else
                //{
                //    objMFGProcessIssueProperty.location_id = Val.ToInt32(2);
                //}

                //DtAssortment = objMFGJangedIsuRec.GetPendingStock(objMFGProcessIssueProperty);

                FrmMFGAssortmentFirstStock FrmAssortmentFirstStock = new FrmMFGAssortmentFirstStock();
                FrmAssortmentFirstStock.FrmMFGAssortFirst = this;
                FrmAssortmentFirstStock.DTab = DtAssortment;
                FrmAssortmentFirstStock.ShowForm(this, Val.ToInt32(RBtnType.EditValue));
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
            }
        }
        private void btnPopUpStock_Click(object sender, EventArgs e)
        {
            try
            {
                if (Validate_PopUp())
                {
                    DataTable DTab_Stock = Global.GetStockCutwise(Val.ToInt(lueKapan.EditValue), Val.ToInt(lueCutNo.EditValue), Val.ToInt32(0));

                    FrmMFGAssortmentConfirm FrmMFGAssortmentConfirm = new FrmMFGAssortmentConfirm();
                    FrmMFGAssortmentConfirm.FrmMFGAssortFirst = this;
                    FrmMFGAssortmentConfirm.DTab = DTab_Stock;
                    FrmMFGAssortmentConfirm.ShowForm(this);
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
            }
        }
        private void RBtnType_EditValueChanged(object sender, EventArgs e)
        {
            if (RBtnType.EditValue.ToString() == "1")
            {
                lueSieve.SetEditValue("13,16");

                m_dtbColor = (((DataTable)lueColor.Properties.DataSource).Copy());
                string Color = string.Empty;

                foreach (DataRow DR in m_dtbColor.Rows)
                {
                    if (DR["color_name"].ToString() == "WHITE" || DR["color_name"].ToString() == "NATTS" || DR["color_name"].ToString() == "LB" || DR["color_name"].ToString() == "LC"
                        || DR["color_name"].ToString() == "MEL" || DR["color_name"].ToString() == "CVD" || DR["color_name"].ToString() == "-70"
                        || DR["color_name"].ToString() == "BROKEN" || DR["color_name"].ToString() == "+6.5"
                        || DR["color_name"].ToString() == "AT"
                        || DR["color_name"].ToString() == "FANCY"
                        //|| DR["color_name"].ToString() == "NOLB"
                        //|| DR["color_name"].ToString() == "ATLB"
                        //|| DR["color_name"].ToString() == "NWLB"
                        || DR["color_name"].ToString() == "G"
                        || DR["color_name"].ToString() == "N.O"
                        || DR["color_name"].ToString() == "LB"
                        //|| DR["color_name"].ToString() == "ATLC"
                        //|| DR["color_name"].ToString() == "NWLC"
                        //|| DR["color_name"].ToString() == "W"
                        //|| DR["color_name"].ToString() == "GAA"
                        //|| DR["color_name"].ToString() == "LCH"
                        //|| DR["color_name"].ToString() == "LCI"
                        //|| DR["color_name"].ToString() == "LBGH"
                        )
                    {
                        Color = Color + "," + DR["color_id"];
                        lueColor.SetEditValue(Color);
                    }
                }
            }
            else
            {
                lueSieve.SetEditValue("17,13,16");

                m_dtbColor = (((DataTable)lueColor.Properties.DataSource).Copy());
                string Color = string.Empty;

                foreach (DataRow DR in m_dtbColor.Rows)
                {
                    if (DR["color_name"].ToString() == "W"
                        || DR["color_name"].ToString() == "GAA"
                        || DR["color_name"].ToString() == "LCH"
                        || DR["color_name"].ToString() == "LCI"
                        || DR["color_name"].ToString() == "LBGH"
                        || DR["color_name"].ToString() == "BROKEN"
                        )
                    {
                        Color = Color + "," + DR["color_id"];
                        lueColor.SetEditValue(Color);
                    }
                }
            }
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (GlobalDec.gEmployeeProperty.user_name != "RIKITA")
            {
                Global.Message("Don't have permission...Please Contact to Administrator...");
                return;
            }


            if (Val.ToInt(lblLotSRNo.Text) != 0)
            {
                DialogResult result = MessageBox.Show("Do you want to Delete Semi 1 data?", "Confirmation", MessageBoxButtons.YesNoCancel);
                if (result != DialogResult.Yes)
                {
                    btnSave.Enabled = true;
                    return;
                }
                IntRes = 0;
                MFGProcessReceive MFGProcessReceive = new MFGProcessReceive();
                MFGAssortFirst MFGAssortReceive = new MFGAssortFirst();
                MFGProcessReceiveProperty objMFGProcessReceiveProperty = new MFGProcessReceiveProperty();

                objMFGProcessReceiveProperty.manager_id = Val.ToInt(0);
                objMFGProcessReceiveProperty.employee_id = Val.ToInt(0);
                objMFGProcessReceiveProperty.process_id = Val.ToInt(lueProcess.EditValue);
                objMFGProcessReceiveProperty.sub_process_id = Val.ToInt(lueSubProcess.EditValue);
                objMFGProcessReceiveProperty.kapan_id = Val.ToInt(lueKapan.EditValue);
                objMFGProcessReceiveProperty.lot_id = Val.ToInt64(txtLotId.Text);
                objMFGProcessReceiveProperty.rough_cut_id = Val.ToInt(lueCutNo.EditValue);
                objMFGProcessReceiveProperty.temp_quality_name = ListQuality.Text.ToString();
                objMFGProcessReceiveProperty.temp_sieve_name = lueSieve.Text.ToString();
                objMFGProcessReceiveProperty.flag = Val.ToInt(0);
                objMFGProcessReceiveProperty.Del_lot_srno = Val.ToInt64(lblLotSRNo.Text);
                objMFGProcessReceiveProperty.assort_total_carat = Val.ToDecimal(txtCarat.Text);
                objMFGProcessReceiveProperty.form_id = m_numForm_id;

                IntRes = MFGAssortReceive.GetDeleteFinalLot_ID(objMFGProcessReceiveProperty, DLL.GlobalDec.EnumTran.Continue, Conn);

                if (IntRes > 0)
                {
                    Global.Confirm("Semi 1 Data Deleted Succesfully");
                    ClearDetails();
                    btnSave.Enabled = true;
                }
                else
                {
                    Global.Confirm("Error In Semi 1 Data");
                    btnSave.Enabled = true;
                }
            }
            else
            {
                Global.Confirm("Not Selected Any Data are Deleted..");
                btnSave.Enabled = true;
                return;
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                RBtnType.Enabled = false;
                if (!ValidateDetails())
                {
                    return;
                }
                dtTemp = new DataTable();
                dgvAssortFirst.Columns.Clear();
                lblLotSRNo.Text = "0";
                txtCVD.Text = "0";
                txtBroken.Text = "0";
                txtBGhat.Text = "0";
                txtSeventy.Text = "0";

                DataTable dtnew = objAssortFirst.AssortFirstGetData(Val.ToString(lueColor.EditValue), Val.ToString(lueSieve.EditValue), Val.ToInt32(lueKapan.EditValue), Val.ToInt32(lueCutNo.EditValue), Val.ToInt32(lueProcess.EditValue), Val.ToInt32(lueSubProcess.EditValue), Val.ToString(ListQuality.Text), Val.ToString(lueSieve.Text), Val.ToInt64(0), Val.ToInt64(RBtnType.EditValue));

                //DataTable dtnew = objAssortFirst.AssortFirstGetData(Val.ToString(lueColor.EditValue), Val.ToString(lueSieve.EditValue));
                if (dtnew.Rows.Count > 0)
                {
                    pivot pt = new pivot(dtnew);
                    //dtTemp = pt.PivotDataSuperPlus(new string[] { "color_id", "color" }, new string[] { "carat", "per(%)" }, new AggregateFunction[] { AggregateFunction.Sum, AggregateFunction.Sum }, new string[] { "sieve" });
                    dtTemp = pt.PivotDataSuperPlusAssortment(new string[] { "color_id", "color" }, new string[] { "carat" }, new AggregateFunction[] { AggregateFunction.Sum, AggregateFunction.Sum }, new string[] { "sieve" });

                    DataColumn Total = new System.Data.DataColumn("Total", typeof(System.Decimal));
                    dtTemp.Columns.Add(Total);

                    if (Val.ToString(lueSieve.Text) == "-00")
                    {
                        foreach (DataRow Drw in dtTemp.Rows)
                        {
                            Drw["Total"] = Val.ToDecimal(Drw["17_-00_carat"]);
                            //Total_carat += Val.ToDecimal(Drw["13_-2_carat"]) + Val.ToDecimal(Drw["16_+2_carat"]);
                        }
                    }
                    else if (Val.ToString(lueSieve.Text) == "-2")
                    {
                        foreach (DataRow Drw in dtTemp.Rows)
                        {
                            Drw["Total"] = Val.ToDecimal(Drw["13_-2_carat"]);
                            //Total_carat += Val.ToDecimal(Drw["13_-2_carat"]) + Val.ToDecimal(Drw["16_+2_carat"]);
                        }
                    }
                    else if (Val.ToString(lueSieve.Text) == "+2")
                    {
                        foreach (DataRow Drw in dtTemp.Rows)
                        {
                            Drw["Total"] = Val.ToDecimal(Drw["16_+2_carat"]);

                        }
                    }
                    else if (Val.ToString(lueSieve.Text) == "-2, +2")
                    {
                        foreach (DataRow Drw in dtTemp.Rows)
                        {
                            Drw["Total"] = Val.ToDecimal(Drw["13_-2_carat"]) + Val.ToDecimal(Drw["16_+2_carat"]);

                        }
                    }
                    else if (Val.ToString(lueSieve.Text) == "-2, +2, -00")
                    {
                        foreach (DataRow Drw in dtTemp.Rows)
                        {
                            Drw["Total"] = Val.ToDecimal(Drw["13_-2_carat"]) + Val.ToDecimal(Drw["16_+2_carat"]) + Val.ToDecimal(Drw["17_-00_carat"]);

                        }
                    }

                    //foreach (DataRow Drw in dtTemp.Rows)
                    //{
                    //    Drw["Total"] = Val.ToDecimal(Drw["13_-2_carat"]) + Val.ToDecimal(Drw["16_+2_carat"]);

                    //}

                    if (Val.ToDecimal(dtnew.Rows[0]["assort_total_carat"]) > 0)
                    {
                        txtCarat.Text = Val.ToDecimal(dtnew.Rows[0]["assort_total_carat"]).ToString();
                    }
                    else
                    {
                        //txtCarat.Text = "0";
                    }

                    grdAssortFirst.DataSource = dtTemp;

                    dgvAssortFirst.Columns["color_id"].Visible = false;
                    dgvAssortFirst.Columns["color"].OptionsColumn.ReadOnly = true;
                    dgvAssortFirst.Columns["color"].OptionsColumn.AllowFocus = false;
                    dgvAssortFirst.Columns["Total"].OptionsColumn.ReadOnly = true;
                    dgvAssortFirst.Columns["Total"].OptionsColumn.AllowFocus = false;
                    //dgvAssortFirst.Columns["Total%"].OptionsColumn.ReadOnly = true;
                    //dgvAssortFirst.Columns["Total%"].OptionsColumn.AllowFocus = false;

                    dgvAssortFirst.Columns[1].Caption = "#";

                    dgvAssortFirst.Columns["color"].Fixed = FixedStyle.Left;
                    for (int i = 0; i <= dtTemp.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j <= dtTemp.Columns.Count - 1; j++)
                        {
                            //if (dtTemp.Columns[j].ToString().Contains("per(%)"))
                            //{
                            //    dgvAssortFirst.Columns[j].OptionsColumn.AllowEdit = false;

                            //    string[] col = dtTemp.Columns[j].ToString().Split('_');
                            //    string currcol = "";
                            //    currcol = "%";
                            //    dgvAssortFirst.Columns[j].Caption = currcol;
                            //}
                            if (dtTemp.Columns[j].ToString().Contains("carat"))
                            {
                                string[] col = dtTemp.Columns[j].ToString().Split('_');
                                string currcol = "";
                                currcol = col[1];
                                dgvAssortFirst.Columns[j].Caption = currcol;
                            }
                            //if (dtTemp.Columns[j].ToString().Contains("Total%"))
                            //{
                            //    dgvAssortFirst.Columns[j].Caption = "%";
                            //}
                        }
                    }

                    for (int i = 0; i <= dtTemp.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j <= dtTemp.Columns.Count - 1; j++)
                        {
                            if (dtTemp.Columns[j].ToString().Contains("carat"))
                            {
                                string carat = dtTemp.Columns[j].ToString();
                                GridColumn column1 = dgvAssortFirst.Columns[carat];
                                dgvAssortFirst.Columns[carat].SummaryItem.DisplayFormat = "{0:n3}";
                                column1.SummaryItem.SummaryType = SummaryItemType.Sum;
                            }

                            if (dtTemp.Columns[j].ToString().Contains("per(%)"))
                            {
                                string Per = dtTemp.Columns[j].ToString();
                                GridColumn column2 = dgvAssortFirst.Columns[Per];
                                dgvAssortFirst.Columns[Per].SummaryItem.DisplayFormat = " {0:n2}";
                                column2.SummaryItem.SummaryType = SummaryItemType.Custom;
                            }
                            if (dtTemp.Columns[j].ColumnName.Contains("Total"))
                            {
                                string total = dtTemp.Columns[j].ToString();
                                GridColumn column4 = dgvAssortFirst.Columns[total];
                                dgvAssortFirst.Columns[total].SummaryItem.DisplayFormat = "{0:n3}";
                                column4.SummaryItem.SummaryType = SummaryItemType.Sum;
                            }

                        }
                        break;
                    }
                }

                if (dtnew.Rows[0]["assort_total_carat"].ToString() != "0")
                {
                    //txtCarat.Text = dtnew.Rows[0]["assort_total_carat"].ToString();
                    txtBGhat.Text = Val.ToString(Val.ToDecimal(dtnew.Rows[0]["bghat"]));
                }


                //if (txtCarat.Text.ToString() == "" || txtCarat.Text.ToString() == "0")
                //{
                //    grdAssortFirst.DataSource = null;
                //    Global.Message("Carat cannot be blank.");
                //    return;
                //}

                //txtCarat.Text = Val.ToString(Total_carat);
                //txtAGhat.Text = Val.ToString(Val.ToDecimal(dtnew.Rows[0]["aghat"]));

                CalculateTotal();
                dgvAssortFirst.OptionsView.ShowFooter = true;
                dgvAssortFirst.BestFitColumns();
                panelControl1.Enabled = true;
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
            }
        }
        private void lueCutNo_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                //MFGProcessReceive objProcessRecieve = new MFGProcessReceive();

                //m_dtOutstanding = Global.GetStockCutwise(Val.ToInt(lueKapan.EditValue), Val.ToInt(lueCutNo.EditValue));

                //if (m_dtOutstanding.Rows.Count > 0)
                //{
                //    m_kapan_id = Val.ToInt(m_dtOutstanding.Rows[0]["kapan_id"]);
                //    //lblOsPcs.Text = Val.ToString(Val.ToDecimal(m_dtOutstanding.Rows[0]["balance_pcs"]));
                //    //lblOsCarat.Text = Val.ToString(Val.ToDecimal(m_dtOutstanding.Rows[0]["balance_carat"]));
                //    //m_balcarat = Val.ToDecimal(m_dtOutstanding.Rows[0]["balance_carat"]);
                //    //txtLotId.Text = Val.ToString(Val.ToInt(m_dtOutstanding.Rows[0]["lot_id"]));
                //}
                //else
                //{
                //    return;
                //}

            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                return;
            }
        }
        private void lueKapan_EditValueChanged(object sender, EventArgs e)
        {
            if (m_IsLot == 0)
            {
                m_dtbParam = new DataTable();
                if (lueKapan.Text.ToString() != "")
                {
                    m_dtbParam = Global.GetRoughKapanWise_Data(Val.ToInt(lueKapan.EditValue));
                    //if (m_dtbParam.Rows.Count == 0)
                    //{
                    //    m_dtbParam = DTab_KapanWiseData;
                    //}
                }
                lueCutNo.Properties.DataSource = m_dtbParam;
                lueCutNo.Properties.ValueMember = "rough_cut_id";
                lueCutNo.Properties.DisplayMember = "rough_cut_no";
            }
        }
        private void txtBGhat_EditValueChanged(object sender, EventArgs e)
        {
            //if (Val.ToDecimal(lblOsCarat.Text) > 0 && Val.ToDecimal(txtBGhat.Text) > 0)
            //{
            //    txtBGhatPer.Text = Val.ToString(Math.Round((Val.ToDecimal(txtBGhat.Text) * 100) / Val.ToDecimal(lblOsCarat.Text), 2));
            //}
            //else
            //{
            //    txtBGhatPer.Text = "0";
            //}
            if (Val.ToDecimal(txtCarat.Text) > 0 && Val.ToDecimal(txtBGhat.Text) > 0)
            {
                txtBGhatPer.Text = Val.ToString(Math.Round((Val.ToDecimal(txtBGhat.Text) * 100) / Val.ToDecimal(txtCarat.Text), 2));
            }
            else
            {
                txtBGhatPer.Text = "0";
            }
            CalculateTotal();
        }
        private void txtAGhat_EditValueChanged(object sender, EventArgs e)
        {
            //if (Val.ToDecimal(lblOsCarat.Text) > 0 && Val.ToDecimal(txtAGhat.Text) > 0)
            //{
            //    txtAGhatPer.Text = Val.ToString(Math.Round((Val.ToDecimal(txtAGhat.Text) * 100) / Val.ToDecimal(lblOsCarat.Text), 2));
            //}
            //else
            //{
            //    txtAGhatPer.Text = "0";
            //}
            //if (Val.ToDecimal(txtCarat.Text) > 0 && Val.ToDecimal(txtAGhat.Text) > 0)
            //{
            //    txtAGhatPer.Text = Val.ToString(Math.Round((Val.ToDecimal(txtAGhat.Text) * 100) / Val.ToDecimal(txtCarat.Text), 2));
            //}
            //else
            //{
            //    txtAGhatPer.Text = "0";
            //}
            if (Val.ToDecimal(txtCarat.Text) > 0 && Val.ToDecimal(txtAGhat.Text) > 0)
            {
                txtAGhatPer.Text = Val.ToString(Math.Round((Val.ToDecimal(txtAGhat.Text) * 100) / Val.ToDecimal(txtCarat.Text), 2));
            }
            else
            {
                txtAGhatPer.Text = "0";
            }
            CalculateTotal();

        }
        private void txtTotal_EditValueChanged(object sender, EventArgs e)
        {
            if (Val.ToDecimal(txtCarat.Text) > 0 && Val.ToDecimal(txtTotal.Text) > 0)
            {
                txtTotalPer.Text = Val.ToString(Math.Round((Val.ToDecimal(txtTotal.Text) * 100) / Val.ToDecimal(txtCarat.Text), 2));
            }
            else
            {
                txtTotalPer.Text = "0";
            }
        }
        private void lueProcess_EditValueChanged(object sender, EventArgs e)
        {
            if (lueProcess.EditValue != System.DBNull.Value)
            {
                if (m_dtbSubProcess.Rows.Count > 0)
                {
                    DataTable dtbdetail = m_dtbSubProcess;

                    string strFilter = string.Empty;

                    if (lueProcess.Text != "")
                        strFilter = "process_id = " + lueProcess.EditValue;


                    dtbdetail.DefaultView.RowFilter = strFilter;
                    dtbdetail.DefaultView.ToTable();

                    DataTable dtb = dtbdetail.DefaultView.ToTable();

                    lueSubProcess.Properties.DataSource = dtb;
                    lueSubProcess.Properties.ValueMember = "sub_process_id";
                    lueSubProcess.Properties.DisplayMember = "sub_process_name";
                    lueSubProcess.EditValue = System.DBNull.Value;
                }
            }
        }
        private void grdProcessReceive_ProcessGridKey(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    (grdAssortFirst.FocusedView as ColumnView).FocusedRowHandle++;
                    e.Handled = true;
                }
            }
            catch { }
        }
        private void lueClarity_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmColorMaster frmColor = new FrmColorMaster();
                frmColor.ShowDialog();
                Global.LOOKUPRoughShade(lueColor);
            }
        }
        private void lueSieve_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmMfgRoughSieve frmRoughSieve = new FrmMfgRoughSieve();
                frmRoughSieve.ShowDialog();
                Global.LOOKUPRoughSieve(lueSieve);
            }
        }
        private void dgvProcessReceive_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            try
            {
                DataTable dtAmount = new DataTable();
                dtAmount = (DataTable)grdAssortFirst.DataSource;
                string[] col = e.Column.FieldName.Split('_');
                string currcol = "";
                if (col.Length > 3 && e.Column.FieldName.Contains("_") && col != null)
                {
                    currcol = col[0] + "_" + col[1];
                }
                decimal carat = 0;
                decimal total = 0;
                decimal perTotal = 0;
                string colname = "";
                for (int i = 0; i <= dtAmount.Rows.Count - 1; i++)
                {
                    for (int j = 0; j <= dtAmount.Columns.Count - 1; j++)
                    {

                        if (dtAmount.Columns[j].ToString().Contains("carat") && dtAmount.Columns[j].ColumnName.Contains(currcol))
                        {
                            perTotal = 0;
                            carat = Val.ToDecimal(dtAmount.Rows[i][j]);
                            total += carat;
                            perTotal = carat;
                            //Total_Amount = Total_Amount + Val.ToDecimal(dtAmount.Rows[i][j]);
                            colname = currcol;
                        }
                        //if (dtAmount.Columns[j].ToString().Contains("per(%)") && dtAmount.Columns[j].ColumnName.Contains(colname))
                        //{
                        //    //if (Val.ToDecimal(lblOsCarat.Text) > 0)
                        //    //{
                        //    //    Percent = (perTotal * 100) / Val.ToDecimal(lblOsCarat.Text);
                        //    //    dtAmount.Rows[i][j] = Math.Round(Percent, 2).ToString();
                        //    //}
                        //    //else
                        //    //{
                        //    //    dtAmount.Rows[i][j] = 0;
                        //    //}
                        //    if (Val.ToDecimal(txtCarat.Text) > 0)
                        //    {
                        //        Percent = (perTotal * 100) / Val.ToDecimal(txtCarat.Text);
                        //        dtAmount.Rows[i][j] = Math.Round(Percent, 2).ToString();
                        //    }
                        //    else
                        //    {
                        //        dtAmount.Rows[i][j] = 0;
                        //    }

                        //}

                        //if (dtAmount.Columns[j].ToString().Contains("carat"))
                        //{
                        //    carat = dtAmount.AsEnumerable().Sum(x => Val.ToDecimal(x[dtAmount.Columns[j]]));
                        //}

                        if (dtAmount.Columns[j].ColumnName.Contains("Total"))
                        {
                            dtAmount.Rows[i][j] = Math.Round(total, 3).ToString();

                            //perTotal = carat;
                            //colname = currcol;
                            //break;
                        }
                        //if (dtAmount.Columns[j].ColumnName.Contains("Total%"))
                        //{
                        //    //if (Val.ToDecimal(lblOsCarat.Text) > 0)
                        //    //{
                        //    //    Percent = (total * 100) / Val.ToDecimal(lblOsCarat.Text);
                        //    //    dtAmount.Rows[i][j] = Math.Round(Percent, 2).ToString();
                        //    //}
                        //    //else
                        //    //{
                        //    //    dtAmount.Rows[i][j] = 0;
                        //    //}
                        //    //break;
                        //    if (Val.ToDecimal(txtCarat.Text) > 0)
                        //    {
                        //        Percent = (total * 100) / Val.ToDecimal(txtCarat.Text);
                        //        dtAmount.Rows[i][j] = Math.Round(Percent, 2).ToString();
                        //    }
                        //    else
                        //    {
                        //        dtAmount.Rows[i][j] = 0;
                        //    }
                        //    break;
                        //}

                    }
                    total = 0;
                    //GridColumn column4 = dgvAssortFirst.Columns["Total"];
                    //decimal TotalSumm = Val.ToDecimal(column4.SummaryText);
                    //txtTotal.Text = Val.ToString(Val.ToDecimal(txtCVD.Text) + Val.ToDecimal(txtSeventy.Text) + Val.ToDecimal(txtsix.Text) + Val.ToDecimal(txtBroken.Text) + Val.ToDecimal(txtBGhat.Text) + Val.ToDecimal(txtAGhat.Text) + TotalSumm);
                    //txtAGhat.Text = Val.ToString(Val.ToDecimal(lblOsCarat.Text) - (Val.ToDecimal(txtCVD.Text) + Val.ToDecimal(txtSeventy.Text) + Val.ToDecimal(txtsix.Text) + Val.ToDecimal(txtBroken.Text) + Val.ToDecimal(txtBGhat.Text) + TotalSumm));
                    dtAmount.AcceptChanges();
                    CalculateTotal();
                    dgvAssortFirst.BestFitColumns();
                }
                //CalculateTotal();
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
            }
        }
        private void dgvProcessReceive_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;

                if (view.FocusedColumn.FieldName.Contains("carat"))
                {
                    double carat = 0.000;
                    if (!double.TryParse(e.Value as string, out carat))
                    {
                        e.Valid = false;
                        e.ErrorText = "Input string was not in a correct format.";
                    }
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                return;
            }
        }
        private void lueProcess_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmProcessMaster frmProcess = new FrmProcessMaster();
                frmProcess.ShowDialog();
                Global.LOOKUPProcess(lueProcess);
            }
        }
        private void lueSubProcess_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                FrmMfgSubProcessMaster frmSubProcess = new FrmMfgSubProcessMaster();
                frmSubProcess.ShowDialog();
                Global.LOOKUPSubProcess(lueSubProcess);
                m_dtbSubProcess = (((DataTable)lueSubProcess.Properties.DataSource).Copy());
            }
        }
        private void FrmMFGAssortFirst_Load(object sender, EventArgs e)
        {
            try
            {
                m_dtbKapan = Global.GetKapanAll_Assort();

                lueKapan.Properties.DataSource = m_dtbKapan;
                lueKapan.Properties.ValueMember = "kapan_id";
                lueKapan.Properties.DisplayMember = "kapan_no";

                m_dtCut = Global.GetRoughCutAll();
                lueCutNo.Properties.DataSource = m_dtCut;
                lueCutNo.Properties.ValueMember = "rough_cut_id";
                lueCutNo.Properties.DisplayMember = "rough_cut_no";

                dtpReceiveDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpReceiveDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
                dtpReceiveDate.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpReceiveDate.Properties.CharacterCasing = CharacterCasing.Upper;
                dtpReceiveDate.EditValue = DateTime.Now;

                DTabQuality = ObjFillCombo.FillCmb(FillCombo.TABLE.Quality_Master);
                DTabQuality.DefaultView.Sort = "quality_name";
                DTabQuality = DTabQuality.DefaultView.ToTable();

                ListQuality.Properties.DataSource = DTabQuality;
                ListQuality.Properties.DisplayMember = "quality_name";
                ListQuality.Properties.ValueMember = "quality_id";

                Global.LOOKUPSieve(lueSieve);

                Global.LOOKUPProcess(lueProcess);

                // Add By Praful On 29072021

                //DTab_KapanWiseData = Global.GetRoughStockWise(Val.ToInt(0), Val.ToInt32(0));

                // End By Praful On 29072021

                lueProcess.Text = "ASSORTMENT";

                Global.LOOKUPSubProcess(lueSubProcess);
                Global.LOOKUPRoughShade(lueColor);

                m_dtbSubProcess = (((DataTable)lueSubProcess.Properties.DataSource).Copy());

                lueProcess_EditValueChanged(null, null);

                if (RBtnType.EditValue.ToString() == "1")
                {
                    lueSieve.SetEditValue("13,16");

                    m_dtbColor = (((DataTable)lueColor.Properties.DataSource).Copy());
                    string Color = string.Empty;

                    foreach (DataRow DR in m_dtbColor.Rows)
                    {
                        if (DR["color_name"].ToString() == "WHITE" || DR["color_name"].ToString() == "NATTS" || DR["color_name"].ToString() == "LB" || DR["color_name"].ToString() == "LC"
                         || DR["color_name"].ToString() == "MEL" || DR["color_name"].ToString() == "CVD" || DR["color_name"].ToString() == "-70"
                         || DR["color_name"].ToString() == "BROKEN" || DR["color_name"].ToString() == "+6.5"
                         || DR["color_name"].ToString() == "AT"
                         || DR["color_name"].ToString() == "FANCY"
                         //|| DR["color_name"].ToString() == "NOLB"
                         //|| DR["color_name"].ToString() == "ATLB"
                         //|| DR["color_name"].ToString() == "NWLB"
                         || DR["color_name"].ToString() == "G"
                         || DR["color_name"].ToString() == "N.O"
                         || DR["color_name"].ToString() == "LB"
                         //|| DR["color_name"].ToString() == "ATLC"
                         //|| DR["color_name"].ToString() == "NWLC"
                         //|| DR["color_name"].ToString() == "W"
                         //|| DR["color_name"].ToString() == "GAA"
                         //|| DR["color_name"].ToString() == "LCH"
                         //|| DR["color_name"].ToString() == "LCI"
                         //|| DR["color_name"].ToString() == "LBGH"
                         )
                        {
                            Color = Color + "," + DR["color_id"];
                            lueColor.SetEditValue(Color);
                        }
                    }
                }
                else
                {
                    lueSieve.SetEditValue("17,13,16");

                    m_dtbColor = (((DataTable)lueColor.Properties.DataSource).Copy());
                    string Color = string.Empty;

                    foreach (DataRow DR in m_dtbColor.Rows)
                    {
                        if (DR["color_name"].ToString() == "W"
                            || DR["color_name"].ToString() == "GAA"
                            || DR["color_name"].ToString() == "LCH"
                            || DR["color_name"].ToString() == "LCI"
                            || DR["color_name"].ToString() == "LBGH"
                            || DR["color_name"].ToString() == "BROKEN"
                            )
                        {
                            Color = Color + "," + DR["color_id"];
                            lueColor.SetEditValue(Color);
                        }
                    }
                }

                //lueColor.SetEditValue("WHITE");

                lueSubProcess.Text = "SEMI-1";

                m_dtbParam = Global.GetRoughCutAll();
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                return;
            }
        }
        private void backgroundWorker_AssortFirstReceive_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                MFGProcessReceive MFGProcessReceive = new MFGProcessReceive();
                MFGAssortFirst MFGAssortReceive = new MFGAssortFirst();
                MFGProcessReceiveProperty objMFGProcessReceiveProperty = new MFGProcessReceiveProperty();

                if (txtCarat.Text.ToString() == "" || txtCarat.Text.ToString() == "0")
                {
                    grdAssortFirst.DataSource = null;
                    Global.Message("Carat cannot be blank.");
                    return;
                }

                Conn = new BeginTranConnection(true, false);

                DataTable m_DTab = new DataTable();
                ArrayList MyArrayList = new ArrayList();

                IntRes = 0;
                Receive_IntRes = 0;
                Int64 NewHistory_Union_Id = 0;
                Int64 NewIssue_Union_Id = 0;
                int NewIssueId = 0;
                Lot_SrNo = 0;
                try
                {
                    if (lblLotSRNo.Text.ToString() == "0")
                    {
                        objMFGProcessReceiveProperty.lot_id = Val.ToInt64(txtLotId.Text);
                        objMFGProcessReceiveProperty.flag_update = Val.ToInt(0);
                        int Lot_Flag = MFGAssortReceive.GetUpdateLot_ID_Flag(objMFGProcessReceiveProperty, DLL.GlobalDec.EnumTran.Continue, Conn);
                    }

                    //DataTable dtIssueDet = MFGProcessReceive.ProcessIssue_GetData(Val.ToInt64(txtLotId.Text), "CHIPIYO");
                    objMFGProcessReceiveProperty.manager_id = Val.ToInt(0);
                    objMFGProcessReceiveProperty.employee_id = Val.ToInt(0);
                    objMFGProcessReceiveProperty.process_id = Val.ToInt(lueProcess.EditValue);
                    objMFGProcessReceiveProperty.sub_process_id = Val.ToInt(lueSubProcess.EditValue);
                    objMFGProcessReceiveProperty.Issue_id = Val.ToInt(NewIssueId);
                    objMFGProcessReceiveProperty.kapan_id = Val.ToInt(lueKapan.EditValue);
                    objMFGProcessReceiveProperty.lot_id = Val.ToInt64(txtLotId.Text);
                    //objMFGProcessReceiveProperty.lot_id = Val.ToInt(0);
                    objMFGProcessReceiveProperty.rough_cut_id = Val.ToInt(lueCutNo.EditValue);
                    objMFGProcessReceiveProperty.temp_quality_name = ListQuality.Text.ToString();//StrListTempPurity; // Val.Trim(ListQuality.Text);
                    objMFGProcessReceiveProperty.temp_sieve_name = lueSieve.Text.ToString();
                    //DataTable DTCheckEntry = new DataTable();
                    //DTCheckEntry = MFGAssortReceive.CheckEntry(objMFGProcessReceiveProperty, DLL.GlobalDec.EnumTran.Continue, Conn);
                    objMFGProcessReceiveProperty.flag = Val.ToInt(0);
                    //objMFGProcessReceiveProperty.Del_lot_srno = Val.ToInt64(lblLotSRNo.Text);

                    if (Val.ToInt64(lblLotSRNo.Text) > 0)
                    {
                        Lot_SrNo = Val.ToInt64(lblLotSRNo.Text);
                        objMFGProcessReceiveProperty.Del_lot_srno = Val.ToInt64(lblLotSRNo.Text);
                        int Lot_Delete = MFGAssortReceive.GetDeleteLot_ID(objMFGProcessReceiveProperty, DLL.GlobalDec.EnumTran.Continue, Conn);
                    }

                    m_DTab = (DataTable)grdAssortFirst.DataSource;

                    DataTable dtbDetail = m_DTab.Copy();
                    decimal Carat = 0;

                    for (int i = 0; i <= dtTemp.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j <= dtTemp.Columns.Count - 1; j++)
                        {
                            if (dtTemp.Columns[j].ToString().Contains("carat"))
                            {
                                if (Val.ToDecimal(dtTemp.Rows[i][j]) != 0)
                                {
                                    Carat = Carat + Val.ToDecimal(dtTemp.Rows[i][j]);
                                }
                            }
                        }
                    }

                    for (int i = dtbDetail.Columns.Count - 1; i >= 2; i--)
                    {
                        string strNew = Val.ToString(dtbDetail.Columns[i]);
                        string str = strNew.Substring(strNew.LastIndexOf("_") + 1);

                        dtbDetail.Columns[Val.ToString(dtbDetail.Columns[i])].ColumnName = strNew.Split('_')[0] + "_" + str;
                    }

                    if (dtbDetail.Rows.Count > 0)
                    {
                        for (int i = dtbDetail.Columns.Count - 1; i >= 2; i--)
                        {
                            if (Val.ToString(dtbDetail.Columns[i]) == Val.ToString(dtbDetail.Columns[i]).Split('_')[0] + "_carat")
                            {
                                foreach (DataRow Drw in dtbDetail.Rows)
                                {
                                    objMFGProcessReceiveProperty.lot_id = Val.ToInt64(txtLotId.Text);
                                    //objMFGProcessReceiveProperty.lot_id = Val.ToInt(0);
                                    objMFGProcessReceiveProperty.rough_cut_id = Val.ToInt(lueCutNo.EditValue);
                                    objMFGProcessReceiveProperty.receive_date = Val.DBDate(dtpReceiveDate.Text);
                                    objMFGProcessReceiveProperty.color_id = Val.ToInt(Drw["color_id"]);
                                    objMFGProcessReceiveProperty.rough_sieve_id = Val.ToInt(Val.ToString(dtbDetail.Columns[i]).Split('_')[0]);
                                    objMFGProcessReceiveProperty.carat = Val.ToDecimal(Drw[Val.ToString(objMFGProcessReceiveProperty.rough_sieve_id) + "_" + "carat"]);
                                    //objMFGProcessReceiveProperty.percentage = Val.ToDecimal(Drw[Val.ToString(objMFGProcessReceiveProperty.rough_sieve_id) + "_" + "per(%)"]);
                                    objMFGProcessReceiveProperty.rate = Val.ToDecimal(0);
                                    //if (Val.ToDecimal(m_rate) != 0)
                                    //{
                                    //    objMFGProcessReceiveProperty.amount = Val.ToDecimal(m_rate * objMFGProcessReceiveProperty.carat);
                                    //}
                                    //objMFGProcessReceiveProperty.amount = Val.ToDecimal(0);
                                    objMFGProcessReceiveProperty.union_id = IntRes;
                                    objMFGProcessReceiveProperty.receive_union_id = Receive_IntRes;
                                    objMFGProcessReceiveProperty.form_id = m_numForm_id;
                                    objMFGProcessReceiveProperty.history_union_id = NewHistory_Union_Id;
                                    objMFGProcessReceiveProperty.lot_srno = Lot_SrNo;
                                    objMFGProcessReceiveProperty.temp_quality_name = ListQuality.Text.ToString();
                                    objMFGProcessReceiveProperty.assort_total_carat = Val.ToDecimal(txtCarat.Text);
                                    objMFGProcessReceiveProperty.temp_sieve_name = lueSieve.Text.ToString();
                                    //if (objMFGProcessReceiveProperty.carat == 0)
                                    //    continue;

                                    if (RBtnType.EditValue.ToString() == "1")
                                    {
                                        objMFGProcessReceiveProperty.location_id = Val.ToInt32(1);
                                    }
                                    else
                                    {
                                        objMFGProcessReceiveProperty.location_id = Val.ToInt32(2);
                                    }

                                    objMFGProcessReceiveProperty.issue_union_id = NewIssue_Union_Id;

                                    objMFGProcessReceiveProperty = MFGAssortReceive.Save(objMFGProcessReceiveProperty, DLL.GlobalDec.EnumTran.Continue, Conn);
                                    IntRes = objMFGProcessReceiveProperty.union_id;
                                    Receive_IntRes = objMFGProcessReceiveProperty.receive_union_id;
                                    NewHistory_Union_Id = Val.ToInt64(objMFGProcessReceiveProperty.history_union_id);
                                    NewIssueId = Val.ToInt(objMFGProcessReceiveProperty.Issue_id);
                                    Lot_SrNo = Val.ToInt64(objMFGProcessReceiveProperty.lot_srno);
                                    NewIssue_Union_Id = Val.ToInt64(objMFGProcessReceiveProperty.issue_union_id);
                                }
                            }
                        }
                        int ColorId = 0;
                        if (Val.ToDecimal(txtBGhat.Text) != 0)
                        {
                            ColorId = objAssortFirst.GetColorId("B.GHAT");
                            objMFGProcessReceiveProperty.color_id = Val.ToInt(ColorId);
                            objMFGProcessReceiveProperty.rough_sieve_id = Val.ToInt(0);
                            objMFGProcessReceiveProperty.percentage = Val.ToDecimal(txtBGhatPer.Text);
                            objMFGProcessReceiveProperty.carat = Val.ToDecimal(txtBGhat.Text);
                            objMFGProcessReceiveProperty.lot_srno = Lot_SrNo;
                            objMFGProcessReceiveProperty = MFGAssortReceive.Save(objMFGProcessReceiveProperty, DLL.GlobalDec.EnumTran.Continue, Conn);
                            IntRes = objMFGProcessReceiveProperty.union_id;

                            Receive_IntRes = objMFGProcessReceiveProperty.receive_union_id;
                            NewHistory_Union_Id = Val.ToInt64(objMFGProcessReceiveProperty.history_union_id);
                            NewIssueId = Val.ToInt(objMFGProcessReceiveProperty.Issue_id);
                            Lot_SrNo = Val.ToInt64(objMFGProcessReceiveProperty.lot_srno);
                        }
                        if (Val.ToDecimal(txtAGhat.Text) != 0)
                        {
                            ColorId = objAssortFirst.GetColorId("A.GHAT");
                            objMFGProcessReceiveProperty.color_id = Val.ToInt(ColorId);
                            objMFGProcessReceiveProperty.rough_sieve_id = Val.ToInt(0);
                            objMFGProcessReceiveProperty.percentage = Val.ToDecimal(txtAGhatPer.Text);
                            objMFGProcessReceiveProperty.carat = Val.ToDecimal(txtAGhat.Text);
                            objMFGProcessReceiveProperty.lot_srno = Lot_SrNo;
                            objMFGProcessReceiveProperty = MFGAssortReceive.Save(objMFGProcessReceiveProperty, DLL.GlobalDec.EnumTran.Continue, Conn);
                            IntRes = objMFGProcessReceiveProperty.union_id;

                            Receive_IntRes = objMFGProcessReceiveProperty.receive_union_id;
                            NewHistory_Union_Id = Val.ToInt64(objMFGProcessReceiveProperty.history_union_id);
                            NewIssueId = Val.ToInt(objMFGProcessReceiveProperty.Issue_id);
                            Lot_SrNo = Val.ToInt64(objMFGProcessReceiveProperty.lot_srno);
                        }

                    }
                    Conn.Inter1.Commit();
                }
                catch (Exception ex)
                {
                    IntRes = -1;
                    Conn.Inter1.Rollback();
                    Conn = null;
                    General.ShowErrors(ex.ToString());
                    return;
                }
            }
            catch (Exception ex)
            {
                IntRes = -1;
                Conn.Inter1.Rollback();
                Conn = null;
                Global.Message(ex.ToString());
                if (ex.InnerException != null)
                {
                    Global.Message(ex.InnerException.ToString());
                }
            }
        }
        private void backgroundWorker_AssortFirstReceive_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (IntRes > 0)
                {
                    if (Global.Confirm("Semi - 1 Data Save Succesfully.... " + "\n Are You Sure To Print ?", "DERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        try
                        {
                            btnClear_Click(null, null);
                            lblLotSRNo.Text = Lot_SrNo.ToString();
                            btn_Print_Click(null, null);
                            lblLotSRNo.Text = "0";
                        }
                        catch (Exception ex)
                        {
                            Global.Message(ex.ToString());
                            return;
                        }
                    }
                    else
                    {
                        btnClear_Click(null, null);
                    }
                }
                else
                {
                    Global.Confirm("Semi - 1 Data");
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                Global.Message(ex.InnerException.ToString());
            }
        }
        private void txtCarat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as DevExpress.XtraEditors.TextEdit).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        #region GridEvents
        private void dgvProcessReceive_CustomSummaryCalculate(object sender, CustomSummaryEventArgs e)
        {
            try
            {
                DataTable dtAmount = new DataTable();
                dtAmount = (DataTable)grdAssortFirst.DataSource;

                decimal percentage = 0;
                decimal totcarat = 0;
                string column = "";
                for (int j = 0; j <= dtAmount.Columns.Count - 1; j++)
                {
                    if (dtAmount.Columns[j].ToString().Contains("per(%)"))
                    {
                        column = dtAmount.Columns[j].ToString();

                    }
                    if (dtAmount.Columns[j].ColumnName.Contains("carat"))
                    {
                        totcarat = dtAmount.AsEnumerable().Sum(x => Val.ToDecimal(x[dtAmount.Columns[j]]));
                    }
                    //if (totcarat > 0 && Val.ToDecimal(lblOsCarat.Text) > 0)
                    //{
                    //    if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName == column)
                    //    {
                    //        percentage = Math.Round(totcarat * 100 / Val.ToDecimal(lblOsCarat.Text), 3);
                    //        if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                    //            e.TotalValue = percentage;
                    //        column = "";
                    //        totcarat = 0;
                    //    }
                    //}
                    if (totcarat > 0 && Val.ToDecimal(txtCarat.Text) > 0)
                    {
                        if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName == column)
                        {
                            percentage = Math.Round(totcarat * 100 / Val.ToDecimal(txtCarat.Text), 3);
                            if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                                e.TotalValue = percentage;
                            column = "";
                            totcarat = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
            }
        }
        #endregion

        #endregion

        #region Functions
        private bool ValidateDetails()
        {
            bool blnFocus = false;
            List<ListError> lstError = new List<ListError>();
            try
            {
                if (lueCutNo.Text == string.Empty)
                {
                    lstError.Add(new ListError(12, "Cut No"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        lueCutNo.Focus();
                    }
                }
                if (lueSieve.EditValue.ToString() == string.Empty)
                {
                    lstError.Add(new ListError(12, "Rough Sieve"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        lueSieve.Focus();
                    }
                }

                if (lueProcess.Text == "")
                {
                    lstError.Add(new ListError(13, "Process"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        lueProcess.Focus();
                    }
                }
                if (lueSubProcess.Text == "")
                {
                    lstError.Add(new ListError(13, "Sub Process"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        lueSubProcess.Focus();
                    }
                }

                if (ListQuality.Text.ToString() == "")
                {
                    lstError.Add(new ListError(13, "Purity"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        ListQuality.Focus();
                    }
                }
                if (txtCarat.Text.ToString() == "" || txtCarat.Text.ToString() == "0")
                {
                    lstError.Add(new ListError(12, "Carat"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtCarat.Focus();
                    }
                }



                if (RBtnType.SelectedIndex == 0)
                {
                    if (GlobalDec.gEmployeeProperty.department_name != "ASSORTMENT")
                    {
                        lstError.Add(new ListError(5, "Department Not In Surat Location..Please Select Correct Department"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                        }
                    }
                }
                else
                {
                    if (GlobalDec.gEmployeeProperty.department_name != "MUMBAI ASSORTMENT")
                    {
                        lstError.Add(new ListError(5, "Department Not In Mumbai Location..Please Select Correct Department"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                        }
                    }
                }

                // Add By Praful On 17072020
                //DataTable DTab_Data = (DataTable)grdAssortFirst.DataSource;                
            }
            catch (Exception ex)
            {
                lstError.Add(new ListError(ex));
            }
            return (!(BLL.General.ShowErrors(lstError)));
        }
        private void AddGotFocusListener(Control ctrl)
        {
            foreach (Control c in ctrl.Controls)
            {
                c.GotFocus += new EventHandler(Control_GotFocus);
                if (c.Controls.Count > 0)
                {
                    AddGotFocusListener(c);
                }
            }
        }
        private void AddKeyPressListener(Control ctrl)
        {
            foreach (Control c in ctrl.Controls)
            {
                c.KeyPress += new KeyPressEventHandler(Control_KeyPress);
                if (c.Controls.Count > 0)
                {
                    AddKeyPressListener(c);
                }
            }
        }
        private void Control_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!((Control)sender).Name.ToString().Trim().Equals(string.Empty))
            {
                _NextEnteredControl = (Control)sender;
                if ((Control)sender is LookUpEdit)
                {
                    if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    {
                        SendKeys.Send("{TAB}");
                    }
                }
                if ((Control)sender is CheckedComboBoxEdit)
                {
                    if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    {
                        SendKeys.Send("{TAB}");
                    }
                }
                if ((Control)sender is ButtonEdit)
                {
                    if (e.KeyChar == Convert.ToChar(Keys.Enter))
                    {
                        SendKeys.Send("{TAB}");
                    }
                }
            }
        }
        private void Control_GotFocus(object sender, EventArgs e)
        {
            if (!((Control)sender).Name.ToString().Trim().Equals(string.Empty))
            {
                _NextEnteredControl = (Control)sender;
                if ((Control)sender is LookUpEdit)
                {
                    ((LookUpEdit)(Control)sender).ShowPopup();
                }
                else if ((Control)sender is CheckedComboBoxEdit)
                {
                    ((CheckedComboBoxEdit)(Control)sender).ShowPopup();
                }
            }
        }
        private void TabControlsToList(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control.TabStop)
                    _tabControls.Add(control);
                if (control.HasChildren)
                    TabControlsToList(control.Controls);
            }
        }
        private void ControlSettingDT(int FormCode, Form pForm)
        {
            BLL.Validation Val = new BLL.Validation();
            Single_Setting ObjSingleSettings = new Single_Setting();
            Single_SettingProperty Property = new Single_SettingProperty();

            Property.role_id = Val.ToInt(BLL.GlobalDec.gEmployeeProperty.role_id);
            Property.form_id = Val.ToInt(FormCode);
            DataTable DtColSetting = ObjSingleSettings.GetData(Property);

            DataTable DtFilterColSetting = (from DataRow dr in DtColSetting.Rows
                                            where Val.ToBooleanToInt(dr["is_control"]) == 1
                                            && dr["column_type"].ToString() != "LABEL"
                                            select dr).CopyToDataTable();
            DevExpress.XtraLayout.LayoutControl l = new DevExpress.XtraLayout.LayoutControl();
            l.OptionsFocus.EnableAutoTabOrder = false;

            if (DtFilterColSetting.Rows.Count > 0)
            {
                DtControlSettings = DtFilterColSetting;
                foreach (Control item1 in pForm.Controls)
                {
                    ControllSettings(item1, DtFilterColSetting);
                }
            }
        }
        private static void ControllSettings(Control item2, DataTable DTab)
        {
            BLL.Validation Val = new BLL.Validation();

            //else
            {
                var VarControlSetting = (from DataRow dr in DTab.Rows
                                         where dr["column_name"].ToString() == item2.Name.ToString()
                                         select dr);

                if (VarControlSetting.Count() > 0)
                {
                    DataRow DRow = VarControlSetting.CopyToDataTable().Rows[0];
                    if (item2.Name.ToString() == Val.ToString(DRow["column_name"]))
                    {
                        if (!(item2 is TextEdit))
                        {
                            if (!(item2 is DateTimePicker))
                            {
                                if (!(item2 is DevExpress.XtraEditors.TextEdit))
                                {
                                    item2.Text = (Val.ToBooleanToInt(DRow["is_compulsory"]).Equals(0) ? Val.ToString(DRow["caption"]) : "* " + Val.ToString(DRow["caption"]));
                                }
                            }
                        }
                        if (Val.ToInt(DRow["tab_index"]) >= 0)
                        {
                            if (item2.CanSelect)
                                item2.TabStop = true;
                        }
                        else
                            item2.TabStop = false;
                        if (Val.ToBooleanToInt(DRow["is_visible"]).Equals(1))
                        {
                            item2.Visible = true;
                            item2.TabStop = true;
                        }
                        else
                        {
                            item2.Visible = false;
                            item2.TabStop = false;
                        }

                        item2.TabIndex = Val.ToInt(DRow["tab_index"]);
                        if (item2.TabIndex == 1)
                        {
                            item2.Select();
                            item2.Focus();
                        }
                        if (Val.ToBooleanToInt(DRow["is_editable"]).Equals(1))
                        {
                            item2.Enabled = true;
                        }
                        else
                        {
                            item2.Enabled = false;
                        }
                    }
                }
                else
                {
                    item2.TabStop = false;
                }
            }
            if (item2.Controls.Count > 0)
            {
                foreach (Control item1 in item2.Controls)
                {
                    ControllSettings(item1, DTab);
                }
            }
        }
        private void Export(string format, string dlgHeader, string dlgFilter)
        {
            try
            {
                SaveFileDialog svDialog = new SaveFileDialog();
                svDialog.DefaultExt = format;
                svDialog.Title = dlgHeader;
                svDialog.FileName = "Report";
                svDialog.Filter = dlgFilter;
                if ((svDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK))
                {
                    string Filepath = svDialog.FileName;

                    switch (format)
                    {
                        case "pdf":
                            dgvAssortFirst.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            dgvAssortFirst.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            dgvAssortFirst.ExportToXlsx(Filepath);
                            break;
                        case "rtf":
                            dgvAssortFirst.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            dgvAssortFirst.ExportToText(Filepath);
                            break;
                        case "html":
                            dgvAssortFirst.ExportToHtml(Filepath);
                            break;
                        case "csv":
                            dgvAssortFirst.ExportToCsv(Filepath);
                            break;
                    }

                    if (format.Equals(Exports.xlsx.ToString()))
                    {
                        if (Global.Confirm("Export Done\n\nYou Want To Open Excel File ?", "DERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(Filepath);
                        }
                    }
                    else if (format.Equals(Exports.pdf.ToString()))
                    {
                        if (Global.Confirm("Export Done\n\nYou Want To Open PDF File ?", "DERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(Filepath);
                        }
                    }
                    else
                    {
                        if (Global.Confirm("Export Done\n\nYou Want To Open File ?", "DERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(Filepath);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.Message.ToString(), "Error in Export");
            }
        }
        public void CalculateTotal()
        {
            decimal TotalSumm = 0;
            if (dgvAssortFirst.DataSource != null)
            {
                TotalSumm = Val.ToDecimal(dgvAssortFirst.Columns["Total"].SummaryText);
                txtAGhat.Text = Val.ToString(Val.ToDecimal(txtCarat.Text) - (Val.ToDecimal(TotalSumm) + Val.ToDecimal(txtBGhat.Text)));
                txtTotal.Text = Val.ToString((Val.ToDecimal(TotalSumm) + Val.ToDecimal(txtBGhat.Text) + Val.ToDecimal(txtAGhat.Text)));
            }
        }
        private bool Validate_PopUp()
        {
            bool blnFocus = false;
            List<ListError> lstError = new List<ListError>();

            try
            {
                if (lueKapan.Text == "")
                {
                    lstError.Add(new ListError(13, "Kapan No"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        lueKapan.Focus();
                    }
                }
                if (lueCutNo.Text == "")
                {
                    lstError.Add(new ListError(13, "Cut No"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        lueCutNo.Focus();
                    }
                }
            }

            catch (Exception ex)
            {
                lstError.Add(new ListError(ex));
            }
            return (!(BLL.General.ShowErrors(lstError)));
        }
        public void GetStockPendingData(DataTable Stock_Data)
        {
            try
            {
                DataTable DTab_Stk = Stock_Data.Copy();

                //decimal carat = Val.ToInt64(DTab_Stk.Compute("Sum(carat)", string.Empty));


                //decimal Total_carat = 0;
                //ListQuality.SetEditValue(0);
                //lueSieve.SetEditValue(0);

                //lblLotSRNo.Text = Val.ToString(Val.ToDecimal(DTab_Stk.Rows[0]["lot_srno"]));
                lueKapan.EditValue = Val.ToInt64(DTab_Stk.Rows[0]["kapan_id"]);
                lueCutNo.EditValue = Val.ToInt64(DTab_Stk.Rows[0]["rough_cut_id"]);
                txtCarat.Text = Val.ToDecimal(DTab_Stk.Rows[0]["carat"]).ToString();
                txtLotId.Text = Val.ToInt64(DTab_Stk.Rows[0]["lot_id"]).ToString();
                //dtpReceiveDate.Text = Val.DBDate(DTab_Stk.Rows[0]["receive_date"].ToString());

                string quality_name = Val.ToString(DTab_Stk.Rows[0]["quality_name"]);
                //string rough_clarity_name = Val.ToString(DTab_Stk.Rows[0]["rough_clarity_name"]);

                //ListQuality.Text = Val.ToString(DTab_Stk.Rows[0]["temp_quality_name"]);
                string purity_name = string.Empty;
                DataTable DeTemp = new DataTable();
                var temp1 = quality_name;
                string StrTransactionType = "";
                string[] array = temp1.Split(',');
                if (!string.IsNullOrEmpty(temp1))
                {
                    foreach (var item in array)
                    {
                        StrTransactionType += "'" + item + "',";
                    }
                    StrTransactionType = StrTransactionType.Remove(StrTransactionType.Length - 1);
                }

                if (StrTransactionType.Length > 0)
                    DeTemp = DTabQuality.Select("quality_name in (" + StrTransactionType + ")").CopyToDataTable();

                if (DeTemp.Rows.Count > 0)
                {
                    foreach (DataRow Dr in DeTemp.Rows)
                    {
                        purity_name += "" + Dr["quality_id"] + ",";
                    }
                }
                ListQuality.SetEditValue(purity_name);
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
            }
        }
        public void GetStockData(DataTable Stock_Data)
        {
            try
            {
                DataTable DTab_Stk = Stock_Data.Copy();

                //decimal carat = Val.ToInt64(DTab_Stk.Compute("Sum(carat)", string.Empty));


                //decimal Total_carat = 0;
                ListQuality.SetEditValue(0);
                lueSieve.SetEditValue(0);

                lblLotSRNo.Text = Val.ToString(Val.ToDecimal(DTab_Stk.Rows[0]["lot_srno"]));
                lueKapan.EditValue = Val.ToInt64(DTab_Stk.Rows[0]["kapan_id"]);
                lueCutNo.EditValue = Val.ToInt64(DTab_Stk.Rows[0]["rough_cut_id"]);
                txtCarat.Text = Val.ToDecimal(DTab_Stk.Rows[0]["assort_total_carat"]).ToString();
                dtpReceiveDate.Text = Val.DBDate(DTab_Stk.Rows[0]["receive_date"].ToString());
                txtLotId.Text = Val.ToInt64(DTab_Stk.Rows[0]["lot_id"]).ToString();

                if (Val.ToInt32(DTab_Stk.Rows[0]["location_id"]) == 1)
                {
                    RBtnType.SelectedIndex = 0;
                }
                else
                {
                    RBtnType.SelectedIndex = 1;
                }

                if (Val.ToString(DTab_Stk.Rows[0]["temp_sieve_name"]) == "-00")
                {
                    lueSieve.SetEditValue("17");
                }
                if (Val.ToString(DTab_Stk.Rows[0]["temp_sieve_name"]) == "-2")
                {
                    lueSieve.SetEditValue("13");
                }
                else if (Val.ToString(DTab_Stk.Rows[0]["temp_sieve_name"]) == "+2")
                {
                    lueSieve.SetEditValue("16");
                }
                else if (Val.ToString(DTab_Stk.Rows[0]["temp_sieve_name"]) == "-2, +2")
                {
                    lueSieve.SetEditValue("13,16");
                }
                else if (Val.ToString(DTab_Stk.Rows[0]["temp_sieve_name"]) == "-2, +2, -00")
                {
                    lueSieve.SetEditValue("13,16,17");
                }

                ListQuality.Text = Val.ToString(DTab_Stk.Rows[0]["temp_quality_name"]);
                string purity_name = string.Empty;
                DataTable DeTemp = new DataTable();
                var temp1 = ListQuality.Text.ToString().Replace(", ", ",");
                string StrTransactionType = "";
                string[] array = temp1.Split(',');
                if (!string.IsNullOrEmpty(temp1))
                {
                    foreach (var item in array)
                    {
                        StrTransactionType += "'" + item + "',";
                    }
                    StrTransactionType = StrTransactionType.Remove(StrTransactionType.Length - 1);
                }

                if (StrTransactionType.Length > 0)
                    DeTemp = DTabQuality.Select("quality_name in (" + StrTransactionType + ")").CopyToDataTable();

                if (DeTemp.Rows.Count > 0)
                {
                    foreach (DataRow Dr in DeTemp.Rows)
                    {
                        purity_name += "" + Dr["quality_id"] + ",";
                    }
                }
                ListQuality.SetEditValue(purity_name);

                dtTemp = new DataTable();
                dgvAssortFirst.Columns.Clear();
                DataTable dtnew = objAssortFirst.AssortFirstGetData(Val.ToString(lueColor.EditValue), Val.ToString(lueSieve.EditValue), Val.ToInt32(lueKapan.EditValue), Val.ToInt32(lueCutNo.EditValue), Val.ToInt32(lueProcess.EditValue), Val.ToInt32(lueSubProcess.EditValue), Val.ToString(ListQuality.Text), Val.ToString(lueSieve.Text), Val.ToInt64(lblLotSRNo.Text), Val.ToInt64(RBtnType.EditValue));

                //DataTable dtnew = objAssortFirst.AssortFirstGetData(Val.ToString(lueColor.EditValue), Val.ToString(lueSieve.EditValue));
                if (dtnew.Rows.Count > 0)
                {
                    pivot pt = new pivot(dtnew);
                    //dtTemp = pt.PivotDataSuperPlus(new string[] { "color_id", "color" }, new string[] { "carat", "per(%)" }, new AggregateFunction[] { AggregateFunction.Sum, AggregateFunction.Sum }, new string[] { "sieve" });
                    dtTemp = pt.PivotDataSuperPlusAssortment(new string[] { "color_id", "color" }, new string[] { "carat" }, new AggregateFunction[] { AggregateFunction.Sum, AggregateFunction.Sum }, new string[] { "sieve" });

                    DataColumn Total = new System.Data.DataColumn("Total", typeof(System.Decimal));
                    dtTemp.Columns.Add(Total);

                    if (Val.ToString(lueSieve.Text) == "-00")
                    {
                        foreach (DataRow Drw in dtTemp.Rows)
                        {
                            Drw["Total"] = Val.ToDecimal(Drw["17_-00_carat"]);
                        }
                    }
                    else if (Val.ToString(lueSieve.Text) == "-2")
                    {
                        foreach (DataRow Drw in dtTemp.Rows)
                        {
                            Drw["Total"] = Val.ToDecimal(Drw["13_-2_carat"]);
                        }
                    }
                    else if (Val.ToString(lueSieve.Text) == "+2")
                    {
                        foreach (DataRow Drw in dtTemp.Rows)
                        {
                            Drw["Total"] = Val.ToDecimal(Drw["16_+2_carat"]);

                        }
                    }
                    else if (Val.ToString(lueSieve.Text) == "-2, +2")
                    {
                        foreach (DataRow Drw in dtTemp.Rows)
                        {
                            Drw["Total"] = Val.ToDecimal(Drw["13_-2_carat"]) + Val.ToDecimal(Drw["16_+2_carat"]);

                        }
                    }
                    else if (Val.ToString(lueSieve.Text) == "-2, +2, -00")
                    {
                        foreach (DataRow Drw in dtTemp.Rows)
                        {
                            Drw["Total"] = Val.ToDecimal(Drw["13_-2_carat"]) + Val.ToDecimal(Drw["16_+2_carat"]) + Val.ToDecimal(Drw["17_-00_carat"]);

                        }
                    }

                    if (Val.ToDecimal(dtnew.Rows[0]["assort_total_carat"]) > 0)
                    {
                        txtCarat.Text = Val.ToDecimal(dtnew.Rows[0]["assort_total_carat"]).ToString();
                    }
                    else
                    {
                        txtCarat.Text = "0";
                    }

                    grdAssortFirst.DataSource = dtTemp;

                    dgvAssortFirst.Columns["color_id"].Visible = false;
                    dgvAssortFirst.Columns["color"].OptionsColumn.ReadOnly = true;
                    dgvAssortFirst.Columns["color"].OptionsColumn.AllowFocus = false;
                    dgvAssortFirst.Columns["Total"].OptionsColumn.ReadOnly = true;
                    dgvAssortFirst.Columns["Total"].OptionsColumn.AllowFocus = false;

                    dgvAssortFirst.Columns[1].Caption = "#";

                    dgvAssortFirst.Columns["color"].Fixed = FixedStyle.Left;
                    for (int i = 0; i <= dtTemp.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j <= dtTemp.Columns.Count - 1; j++)
                        {
                            if (dtTemp.Columns[j].ToString().Contains("carat"))
                            {
                                string[] col = dtTemp.Columns[j].ToString().Split('_');
                                string currcol = "";
                                currcol = col[1];
                                dgvAssortFirst.Columns[j].Caption = currcol;
                            }
                        }
                    }

                    for (int i = 0; i <= dtTemp.Rows.Count - 1; i++)
                    {
                        for (int j = 0; j <= dtTemp.Columns.Count - 1; j++)
                        {
                            if (dtTemp.Columns[j].ToString().Contains("carat"))
                            {
                                string carat = dtTemp.Columns[j].ToString();
                                GridColumn column1 = dgvAssortFirst.Columns[carat];
                                dgvAssortFirst.Columns[carat].SummaryItem.DisplayFormat = "{0:n3}";
                                column1.SummaryItem.SummaryType = SummaryItemType.Sum;
                            }

                            if (dtTemp.Columns[j].ToString().Contains("per(%)"))
                            {
                                string Per = dtTemp.Columns[j].ToString();
                                GridColumn column2 = dgvAssortFirst.Columns[Per];
                                dgvAssortFirst.Columns[Per].SummaryItem.DisplayFormat = " {0:n2}";
                                column2.SummaryItem.SummaryType = SummaryItemType.Custom;
                            }
                            if (dtTemp.Columns[j].ColumnName.Contains("Total"))
                            {
                                string total = dtTemp.Columns[j].ToString();
                                GridColumn column4 = dgvAssortFirst.Columns[total];
                                dgvAssortFirst.Columns[total].SummaryItem.DisplayFormat = "{0:n3}";
                                column4.SummaryItem.SummaryType = SummaryItemType.Sum;
                            }

                        }
                        break;
                    }
                }

                if (dtnew.Rows[0]["assort_total_carat"].ToString() != "0")
                {
                    txtBGhat.Text = Val.ToString(Val.ToDecimal(dtnew.Rows[0]["bghat"]));
                }
                else
                {
                    decimal TotalSumm = 0;
                    txtBGhat.Text = Val.ToString(Val.ToDecimal(dtnew.Rows[0]["bghat"]));
                    GridColumn Total = dgvAssortFirst.Columns["Total"];
                    TotalSumm = Val.ToDecimal(Total.SummaryText) + Val.ToDecimal(dtnew.Rows[0]["bghat"]) + Val.ToDecimal(dtnew.Rows[0]["aghat"]);
                    txtCarat.Text = Val.ToString(TotalSumm);
                }

                CalculateTotal();
                dgvAssortFirst.OptionsView.ShowFooter = true;
                dgvAssortFirst.BestFitColumns();
                panelControl1.Enabled = true;
                btnSearch.Enabled = false;
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
            }
        }
        private bool ClearDetails()
        {
            bool blnReturn = true;
            try
            {
                dtpReceiveDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpReceiveDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
                dtpReceiveDate.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpReceiveDate.Properties.CharacterCasing = CharacterCasing.Upper;
                dtpReceiveDate.EditValue = DateTime.Now;

                //lueKapan.EditValue = System.DBNull.Value;
                //lueCutNo.EditValue = System.DBNull.Value;
                //for (int i = 0; i < ListQuality.Properties.Items.Count; i++)
                //    ListQuality.Properties.Items[i].CheckState = CheckState.Unchecked;
                grdAssortFirst.DataSource = null;
                dgvAssortFirst.Columns.Clear();
                txtCarat.Text = "0";
                txtCVD.Text = "0";
                txtSeventy.Text = "0";
                txtsix.Text = "0";
                txtAGhat.Text = "0";
                txtBGhat.Text = "0";
                txtBroken.Text = "0";
                txtLotId.Text = "0";
                txtTotal.Text = "0";

                txtCarat.Text = "0";
                lblLotSRNo.Text = "0";
                btnSearch.Enabled = true;
                //RBtnType.SelectedIndex = 0;
                RBtnType.Enabled = true;
                lueKapan.Focus();
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                blnReturn = false;
            }
            return blnReturn;
        }

        #endregion

        #region Export Grid
        private void MNExportExcel_Click(object sender, EventArgs e)
        {
            //Global.Export("xlsx", dgvRoughClarityMaster);
            Export("xlsx", "Export to Excel", "Excel files 97-2003 (Excel files 2007(*.xlsx)|*.xlsx|All files (*.*)|*.*");
        }
        private void MNExportPDF_Click(object sender, EventArgs e)
        {
            // Global.Export("pdf", dgvRoughClarityMaster);
            Export("pdf", "Export Report to PDF", "PDF (*.PDF)|*.PDF");
        }
        private void MNExportTEXT_Click(object sender, EventArgs e)
        {
            Export("txt", "Export to Text", "Text files (*.txt)|*.txt|All files (*.*)|*.*");
        }

        private void MNExportHTML_Click(object sender, EventArgs e)
        {
            Export("html", "Export to HTML", "Html files (*.html)|*.html|Htm files (*.htm)|*.htm");
        }

        private void MNExportRTF_Click(object sender, EventArgs e)
        {
            Export("rtf", "Export to RTF", "Word (*.doc) |*.doc;*.rtf|(*.txt) |*.txt|(*.*) |*.*");
        }

        private void MNExportCSV_Click(object sender, EventArgs e)
        {
            Export("csv", "Export Report to CSVB", "csv (*.csv)|*.csv");
        }
        #endregion

        #region Key Press Event

        private void txtBGhat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as DevExpress.XtraEditors.TextEdit).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
        private void txtBGhatPer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as DevExpress.XtraEditors.TextEdit).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
        private void txtAGhat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as DevExpress.XtraEditors.TextEdit).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
        private void txtAGhatPer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as DevExpress.XtraEditors.TextEdit).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as DevExpress.XtraEditors.TextEdit).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }
        private void txtTotalPer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.' && (sender as DevExpress.XtraEditors.TextEdit).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        #endregion

        private void txtLotId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
