﻿using BLL;
using BLL.FunctionClasses.Master;
using BLL.FunctionClasses.Transaction;
using BLL.FunctionClasses.Utility;
using BLL.PropertyClasses.Transaction;
using DERP.Class;
using DERP.Master;
using DevExpress.XtraEditors;
using DREP.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using static DERP.Class.Global;

namespace DREP.Transaction
{
    public partial class FrmSaleReturn : DevExpress.XtraEditors.XtraForm
    {
        #region Data Member

        BLL.BeginTranConnection Conn;
        BLL.FormEvents objBOFormEvents;
        BLL.FormPer ObjPer;
        BLL.Validation Val;

        Control _NextEnteredControl;
        private List<Control> _tabControls;
        public delegate void SetControlValueCallback(Control oControl, string propName, object propValue);

        SaleReturn objSaleReturn;
        UserAuthentication objUserAuthentication;
        AssortMaster objAssort;
        SieveMaster objSieve;
        RateMaster objRate;

        DataTable DtControlSettings;
        DataTable m_dtbAssorts;
        DataTable m_dtbSieve;
        DataTable m_dtbSaleReturnDetails;
        DataTable m_dtbCurrency;
        DataTable m_dtbDetails;
        DataTable m_opDate;

        int m_SaleReturn_detail_id;
        int m_srno;
        int m_update_srno;
        int m_numForm_id;
        int IntRes;

        decimal m_numTotalCarats;
        decimal m_numcarat;
        decimal m_current_rate;
        decimal m_current_amount;

        bool m_blnadd;
        bool m_blnsave;
        bool m_blncheckevents;


        #endregion

        #region Constructor
        public FrmSaleReturn()
        {
            InitializeComponent();

            objBOFormEvents = new BLL.FormEvents();
            ObjPer = new BLL.FormPer();
            Val = new BLL.Validation();

            _NextEnteredControl = new Control();
            _tabControls = new List<Control>();

            objSaleReturn = new SaleReturn();
            objUserAuthentication = new UserAuthentication();
            objAssort = new AssortMaster();
            objSieve = new SieveMaster();
            objRate = new RateMaster();

            DtControlSettings = new DataTable();
            m_dtbAssorts = new DataTable();
            m_dtbSieve = new DataTable();
            m_dtbSaleReturnDetails = new DataTable();
            m_dtbCurrency = new DataTable();
            m_dtbDetails = new DataTable();
            m_opDate = new DataTable();

            m_SaleReturn_detail_id = 0;
            m_srno = 0;
            m_update_srno = 0;
            m_numForm_id = 0;
            IntRes = 0;

            m_numTotalCarats = 0;
            m_numcarat = 0;
            m_current_rate = 0;
            m_current_amount = 0;

            m_blnadd = new bool();
            m_blnsave = new bool();
            m_blncheckevents = new bool();
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
            if (Global.CheckDefault() == 0)
            {
                Global.Message("Please Check User Default Setting");
                this.Close();
                return;
            }
            Val.frmGenSet(this);
            AttachFormEvents();

            // for Dynamic Setting By Praful On 01022020

            if (Global.HideFormControls(Val.ToInt(ObjPer.form_id), this) != "")
            {
                Global.Message("Select First User Setting...Please Contact to Administrator...");
                return;
            }

            ControlSettingDT(Val.ToInt(ObjPer.form_id), this);
            AddGotFocusListener(this);
            this.KeyPreview = true;

            TabControlsToList(this.Controls);
            _tabControls = _tabControls.OrderBy(x => x.TabIndex).ToList();

            // End for Dynamic Setting By Praful On 01022020

            this.Show();
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
        private void Control_GotFocus(object sender, EventArgs e)
        {
            if (!((Control)sender).Name.ToString().Trim().Equals(string.Empty))
            {
                _NextEnteredControl = (Control)sender;
                if ((Control)sender is LookUpEdit)
                {
                    ((LookUpEdit)(Control)sender).ShowPopup();
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

        private void AttachFormEvents()
        {
            objBOFormEvents.CurForm = this;
            objBOFormEvents.FormKeyPress = true;
            objBOFormEvents.FormKeyDown = true;
            objBOFormEvents.FormResize = true;
            objBOFormEvents.FormClosing = true;
            objBOFormEvents.ObjToDispose.Add(objSaleReturn);
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);

        }

        #endregion

        #region Events
        private void FrmSaleReturn_Load(object sender, EventArgs e)
        {
            try
            {
                if (!LoadDefaults())
                {
                    btnAdd.Enabled = false;
                    btnClear.Enabled = false;
                    btnSave.Enabled = false;
                }
                else
                {
                    ClearDetails();
                    ttlbSaleReturn.SelectedTabPage = tblSaleReturndetail;
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                return;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (AddInGrid())
            {
                lueAssortName.EditValue = DBNull.Value;
                lueSieveName.EditValue = DBNull.Value;
                lueSubSieveName.EditValue = DBNull.Value;
                txtPcs.Text = string.Empty;
                txtCarat.Text = string.Empty;
                txtRate.Text = string.Empty;
                txtAmount.Text = string.Empty;
                lueAssortName.Focus();
                lueAssortName.ShowPopup();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
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

            btnSave.Enabled = false;

            m_blnsave = true;
            m_blnadd = false;
            if (!ValidateDetails())
            {
                m_blnsave = false;
                btnSave.Enabled = true;
                return;
            }

            DialogResult result = MessageBox.Show("Do you want to save data?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result != DialogResult.Yes)
            {
                btnSave.Enabled = true;
                return;
            }

            DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;

            panelProgress.Visible = true;
            backgroundWorker_SaleReturn.RunWorkerAsync();

            btnSave.Enabled = true;
        }
        private void btnClear_Click_1(object sender, EventArgs e)
        {
            ClearDetails();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!PopulateDetails())
                return;
        }
        private void txtCarat_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtAmount.Text = string.Format("{0:0.00}", Val.ToDecimal(txtCarat.Text) * Val.ToDecimal(txtRate.Text));
                m_current_amount = Val.ToDecimal(txtCarat.Text) * Val.ToDecimal(m_current_rate);
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                return;
            }
        }
        private void txtRate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                txtAmount.Text = string.Format("{0:0.00}", Val.ToDecimal(txtCarat.Text) * Val.ToDecimal(txtRate.Text));
                //m_current_amount = Val.ToDecimal(txtAmount.Text);
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                return;
            }
        }
        private void lueAssortName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (lueAssortName.ItemIndex != -1 && lueSieveName.ItemIndex != -1)
                {
                    BranchTransfer objBranch = new BranchTransfer();
                    string p_numStockRate = string.Empty;
                    p_numStockRate = objBranch.GetLetestPrice(Val.ToInt(lueAssortName.EditValue), Val.ToInt(lueSieveName.EditValue));

                    txtRate.Text = Val.ToString(p_numStockRate);
                    m_current_rate = Val.ToDecimal(p_numStockRate);
                }
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private void txtTermDays_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtpSaleReturnDate.Text.Length <= 0 || dtpSaleReturnDate.Text == "")
                {
                    txtTermDays.Text = "";
                    dtpDueDate.EditValue = null;
                }
                else
                {
                    Double Days = Val.ToDouble(txtTermDays.Text) + Val.ToDouble(txtAddOnDays.Text);
                    DateTime Date = Convert.ToDateTime(dtpSaleReturnDate.EditValue).AddDays(Val.ToDouble(Days));
                    dtpDueDate.EditValue = Val.DBDate(Date.ToShortDateString());
                }
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private void txtAddOnDays_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtpSaleReturnDate.Text.Length <= 0 || dtpSaleReturnDate.Text == "")
                {
                    txtAddOnDays.Text = "";
                    dtpDueDate.EditValue = null;
                }
                else
                {
                    Double Days = Val.ToDouble(txtTermDays.Text) + Val.ToDouble(txtAddOnDays.Text);
                    DateTime Date = Convert.ToDateTime(dtpSaleReturnDate.EditValue).AddDays(Val.ToDouble(Days));
                    dtpDueDate.EditValue = Val.DBDate(Date.ToShortDateString());
                }
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private void lueSieveName_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                Global.LOOKUPSubSieve(lueSubSieveName, Val.ToInt(lueSieveName.EditValue));
                lueAssortName_EditValueChanged(null, null);
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                return;
            }
        }
        private void txtDiscountPer_EditValueChanged(object sender, EventArgs e)
        {

            try
            {
                if (!m_blncheckevents)
                {
                    decimal Dis_amt = Math.Round(Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) * Val.ToDecimal(txtDiscountPer.Text) / 100, 0);
                    txtDiscountAmt.Text = Dis_amt.ToString();
                    decimal Net_Amount = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmt.Text)) + Val.ToDecimal(txtInterestAmt.Text) + Val.ToDecimal(txtShippingCharge.Text), 0);
                    txtNetAmount.Text = Net_Amount.ToString();
                }
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private void txtDiscountAmt_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) != 0)
                {
                    if (!m_blncheckevents)
                    {
                        decimal Dis_Per = Math.Round(Val.ToDecimal(txtDiscountAmt.Text) / Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) * 100, 3);
                        txtDiscountPer.Text = Dis_Per.ToString();
                        decimal Net_Amount = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmt.Text)) + Val.ToDecimal(txtInterestAmt.Text) + Val.ToDecimal(txtShippingCharge.Text), 0);
                        txtNetAmount.Text = Net_Amount.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private void txtBrokeragePer_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!m_blncheckevents)
                {
                    decimal Brokerage_amt = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmt.Text)) * Val.ToDecimal(txtBrokeragePer.Text) / 100, 0);
                    txtBrokerageAmt.Text = Brokerage_amt.ToString();
                }
                //decimal Brokerage_amt = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmt.Text)) * Val.ToDecimal(txtBrokeragePer.Text) / 100, 0);
                //txtBrokerageAmt.Text = Brokerage_amt.ToString();
                //decimal Net_Amount = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmt.Text)) + Val.ToDecimal(txtInterestAmt.Text) - Val.ToDecimal(txtBrokerageAmt.Text) - Val.ToDecimal(txtShippingCharge.Text), 0);
                //txtNetAmount.Text = Net_Amount.ToString();
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private void txtBrokerageAmt_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) != 0)
                {
                    if (!m_blncheckevents)
                    {
                        decimal Brokarage_Per = Math.Round(Val.ToDecimal(txtBrokerageAmt.Text) / (Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmt.Text)) * 100, 3);
                        txtBrokeragePer.Text = Brokarage_Per.ToString();
                        //decimal Net_Amount = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmt.Text)) + Val.ToDecimal(txtInterestAmt.Text) - Val.ToDecimal(txtBrokerageAmt.Text) - Val.ToDecimal(txtShippingCharge.Text), 0);
                        //txtNetAmount.Text = Net_Amount.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private void txtInterestPer_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!m_blncheckevents)
                {
                    decimal Interest_amt = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmt.Text)) * Val.ToDecimal(txtInterestPer.Text) / 100, 0);
                    txtInterestAmt.Text = Interest_amt.ToString();
                    decimal Net_Amount = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmt.Text)) + Val.ToDecimal(txtInterestAmt.Text) + Val.ToDecimal(txtShippingCharge.Text), 0);
                    txtNetAmount.Text = Net_Amount.ToString();
                }
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private void txtInterestAmt_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) != 0)
                {
                    if (!m_blncheckevents)
                    {
                        decimal interest_Per = Math.Round(Val.ToDecimal(txtInterestAmt.Text) / (Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmt.Text)) * 100, 3);
                        txtInterestPer.Text = interest_Per.ToString();
                        decimal Net_Amount = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) - Val.ToDecimal(txtDiscountAmt.Text)) + Val.ToDecimal(txtInterestAmt.Text) + Val.ToDecimal(txtShippingCharge.Text), 0);
                        txtNetAmount.Text = Net_Amount.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private void txtShippingCharge_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) != 0)
                {
                    decimal Shipping_Charge = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) + Val.ToDecimal(txtInterestAmt.Text)) - (Val.ToDecimal(txtDiscountAmt.Text)) + Val.ToDecimal(txtShippingCharge.Text), 0);
                    txtNetAmount.Text = Shipping_Charge.ToString();
                }
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
        private void txtDiscountPer_KeyDown(object sender, KeyEventArgs e)
        {
            m_blncheckevents = false;
        }
        private void txtDiscountAmt_KeyDown(object sender, KeyEventArgs e)
        {
            m_blncheckevents = false;
        }
        private void txtBrokeragePer_KeyDown(object sender, KeyEventArgs e)
        {
            m_blncheckevents = false;
        }
        private void txtBrokerageAmt_KeyDown(object sender, KeyEventArgs e)
        {
            m_blncheckevents = false;
        }
        private void txtInterestPer_KeyDown(object sender, KeyEventArgs e)
        {
            m_blncheckevents = false;
        }
        private void txtInterestAmt_KeyDown(object sender, KeyEventArgs e)
        {
            m_blncheckevents = false;
        }
        private void lueParty_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Index == 1)
                {
                    FrmPartyMaster frmParty = new FrmPartyMaster();
                    frmParty.ShowDialog();
                    Global.LOOKUPParty(lueParty);
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                return;
            }
        }
        private void lueBroker_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Index == 1)
                {
                    FrmBrokerMaster frmBroker = new FrmBrokerMaster();
                    frmBroker.ShowDialog();
                    Global.LOOKUPBroker(lueBroker);
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                return;
            }
        }
        private void panelControl4_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.FromArgb(255, 191, 219, 255), 2);
            e.Graphics.DrawLine(pen, 0, 57, 1500, 57);
        }
        private void backgroundWorker_SaleReturn_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.Default;
                if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
                {
                    Conn = new BeginTranConnection(true, false);
                }
                else
                {
                    Conn = new BeginTranConnection(false, true);
                }
                SaleReturn_Property objSaleReturn_Property = new SaleReturn_Property();
                SaleReturn objSaleReturn = new SaleReturn();
                try
                {
                    IntRes = 0;
                    objSaleReturn_Property.sale_return_id = Val.ToInt(lblMode.Tag);
                    objSaleReturn_Property.invoice_no = Val.ToString(txtSaleReturnNo.Text);
                    objSaleReturn_Property.company_id = Val.ToInt(GlobalDec.gEmployeeProperty.company_id);
                    objSaleReturn_Property.branch_id = Val.ToInt(GlobalDec.gEmployeeProperty.branch_id);
                    objSaleReturn_Property.location_id = Val.ToInt(GlobalDec.gEmployeeProperty.location_id);
                    objSaleReturn_Property.department_id = Val.ToInt(GlobalDec.gEmployeeProperty.department_id);

                    objSaleReturn_Property.return_date = Val.DBDate(dtpSaleReturnDate.Text);
                    objSaleReturn_Property.delivery_type_id = Val.ToInt(lueDeliveryType.EditValue);
                    objSaleReturn_Property.remarks = Val.ToString(txtEntry.Text);
                    objSaleReturn_Property.delivery_type_id = Val.ToInt(lueDeliveryType.EditValue);

                    objSaleReturn_Property.form_id = m_numForm_id;

                    objSaleReturn_Property.Party_Id = Val.ToInt(lueParty.EditValue);
                    objSaleReturn_Property.Broker_Id = Val.ToInt(lueBroker.EditValue);
                    objSaleReturn_Property.Term_Days = Val.ToInt(txtTermDays.EditValue);
                    objSaleReturn_Property.Add_On_Days = Val.ToInt(txtAddOnDays.EditValue);

                    objSaleReturn_Property.Special_Remark = Val.ToString(txtJKK.Text);
                    objSaleReturn_Property.Client_Remark = Val.ToString(txtSaleRemark.Text);
                    objSaleReturn_Property.Payment_Remark = Val.ToString(txtAccountRemark.Text);

                    objSaleReturn_Property.total_pcs = Math.Round(Val.ToDecimal(clmPcs.SummaryItem.SummaryValue), 3);
                    objSaleReturn_Property.total_carat = Math.Round(Val.ToDecimal(clmDetCarat.SummaryItem.SummaryValue), 3);

                    objSaleReturn_Property.Gross_Amount = Math.Round(Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue), 3);

                    objSaleReturn_Property.Brokerage_Per = Val.ToDecimal(txtBrokeragePer.Text);
                    objSaleReturn_Property.Brokerage_Amt = Val.ToDecimal(txtBrokerageAmt.Text);
                    objSaleReturn_Property.Discount_Per = Val.ToDecimal(txtDiscountPer.Text);
                    objSaleReturn_Property.Discount_Amt = Val.ToDecimal(txtDiscountAmt.Text);
                    objSaleReturn_Property.Interest_Per = Val.ToDecimal(txtInterestPer.Text);
                    objSaleReturn_Property.Interest_Amt = Val.ToDecimal(txtInterestAmt.Text);
                    objSaleReturn_Property.Shipping_Charge = Val.ToDecimal(txtShippingCharge.Text);

                    objSaleReturn_Property.net_amount = Val.ToDecimal(txtNetAmount.Text);

                    objSaleReturn_Property = objSaleReturn.Save(objSaleReturn_Property, DLL.GlobalDec.EnumTran.Start, Conn);

                    Int64 NewmSaleReturnid = Val.ToInt64(objSaleReturn_Property.sale_return_id);

                    int IntCounter = 0;
                    int Count = 0;
                    int TotalCount = m_dtbSaleReturnDetails.Rows.Count;

                    foreach (DataRow drw in m_dtbSaleReturnDetails.Rows)
                    {
                        objSaleReturn_Property = new SaleReturn_Property();
                        objSaleReturn_Property.sale_return_id = Val.ToInt32(NewmSaleReturnid);
                        objSaleReturn_Property.return_detail_id = Val.ToInt(drw["return_detail_id"]);
                        objSaleReturn_Property.assort_id = Val.ToInt(drw["assort_id"]);
                        objSaleReturn_Property.sieve_id = Val.ToInt(drw["sieve_id"]);
                        objSaleReturn_Property.sub_sieve_id = Val.ToInt(drw["sub_sieve_id"]);
                        objSaleReturn_Property.pcs = Val.ToInt(drw["pcs"]);
                        objSaleReturn_Property.carat = Val.ToDecimal(drw["carat"]);
                        objSaleReturn_Property.rate = Val.ToDecimal(drw["rate"]);
                        objSaleReturn_Property.amount = Val.ToDecimal(drw["amount"]);
                        objSaleReturn_Property.discount = Val.ToDecimal(drw["discount"]);
                        objSaleReturn_Property.old_carat = Val.ToDecimal(drw["old_carat"]);
                        objSaleReturn_Property.old_pcs = Val.ToInt(drw["old_pcs"]);
                        objSaleReturn_Property.flag = Val.ToInt(drw["flag"]);
                        objSaleReturn_Property.old_assort_id = Val.ToInt(drw["old_assort_id"]);
                        objSaleReturn_Property.old_sieve_id = Val.ToInt(drw["old_sieve_id"]);
                        objSaleReturn_Property.old_sub_sieve_id = Val.ToInt(drw["old_sub_sieve_id"]);
                        objSaleReturn_Property.current_rate = Val.ToDecimal(drw["current_rate"]);
                        objSaleReturn_Property.current_amount = Val.ToDecimal(drw["current_amount"]);

                        IntRes = objSaleReturn.Save_Detail(objSaleReturn_Property, DLL.GlobalDec.EnumTran.Continue, Conn);

                        Count++;
                        IntCounter++;
                        IntRes++;
                        SetControlPropertyValue(lblProgressCount, "Text", Count.ToString() + "" + "/" + "" + TotalCount.ToString() + " Completed....");
                    }
                    if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
                    {
                        Conn.Inter1.Commit();
                    }
                    else
                    {
                        Conn.Inter2.Commit();
                    }
                }
                catch (Exception ex)
                {
                    IntRes = -1;
                    if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
                    {
                        Conn.Inter1.Rollback();
                    }
                    else
                    {
                        Conn.Inter2.Rollback();
                    }
                    Conn = null;
                    General.ShowErrors(ex.ToString());
                    return;
                }
                finally
                {
                    objSaleReturn_Property = null;
                }
            }
            catch (Exception ex)
            {
                IntRes = -1;
                if (GlobalDec.gEmployeeProperty.Allow_Developer == 0)
                {
                    Conn.Inter1.Rollback();
                }
                else
                {
                    Conn.Inter2.Rollback();
                }
                Conn = null;
                Global.Message(ex.ToString());
                if (ex.InnerException != null)
                {
                    Global.Message(ex.InnerException.ToString());
                }
            }
        }
        private void backgroundWorker_SaleReturn_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            try
            {
                panelProgress.Visible = false;
                if (IntRes > 0)
                {
                    if (Val.ToInt(lblMode.Tag) == 0)
                    {
                        Global.Confirm("Sale Return Data Save Successfully");
                        ClearDetails();
                        PopulateDetails();
                    }
                    else
                    {
                        Global.Confirm("Sale Return Data Update Successfully");
                        ClearDetails();
                        PopulateDetails();
                    }
                }
                else
                {
                    Global.Confirm("Error In Sale Return");
                    txtSaleReturnNo.Focus();
                }
            }
            catch (Exception ex)
            {
                Global.Message(ex.ToString());
                Global.Message(ex.InnerException.ToString());
            }
        }
        #region "Grid Events" 
        private void dgvSaleReturnDetail_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            try
            {

                if (Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) > 0 && Val.ToDecimal(clmDetCarat.SummaryItem.SummaryValue) > 0)
                {
                    m_numTotalCarats = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) / Val.ToDecimal(clmDetCarat.SummaryItem.SummaryValue)), 2, MidpointRounding.AwayFromZero);

                }
                else
                {
                    m_numTotalCarats = 0;
                }
                if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName == "rate")
                {
                    if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                        e.TotalValue = m_numTotalCarats;
                }
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
            }
        }
        private void dgvSaleReturn_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                objSaleReturn = new SaleReturn();
                if (e.RowHandle >= 0)
                {
                    if (e.Clicks == 2)
                    {
                        m_blncheckevents = true;

                        DataRow Drow = dgvSaleReturn.GetDataRow(e.RowHandle);
                        lblMode.Text = "Edit Mode";
                        lblMode.Tag = Val.ToInt32(Drow["sale_return_id"]);

                        dtpSaleReturnDate.Text = Val.DBDate(Val.ToString(Drow["sale_return_date"]));
                        lueDeliveryType.EditValue = Val.ToInt(Drow["delivery_type_id"]);
                        txtSaleReturnNo.Text = Val.ToString(Drow["invoice_no"]);
                        lueParty.EditValue = Val.ToInt(Drow["party_id"]);
                        lueBroker.EditValue = Val.ToInt(Drow["broker_id"]);
                        txtShippingCharge.Text = Val.ToString(Drow["shipping"]);
                        txtTermDays.Text = Val.ToString(Drow["term_days"]);
                        txtAddOnDays.Text = Val.ToString(Drow["add_on_days"]);
                        txtEntry.Text = Val.ToString(Drow["remarks"]);
                        txtJKK.Text = Val.ToString(Drow["special_remarks"]);
                        txtAccountRemark.Text = Val.ToString(Drow["client_remarks"]);
                        txtSaleRemark.Text = Val.ToString(Drow["payment_remarks"]);
                        txtBrokeragePer.Text = Val.ToString(Drow["brokerage_per"]);
                        txtBrokerageAmt.Text = Val.ToString(Drow["brokerage_amount"]);
                        txtDiscountPer.Text = Val.ToString(Drow["discount_per"]);
                        txtDiscountAmt.Text = Val.ToString(Drow["discount_amount"]);
                        txtInterestPer.Text = Val.ToString(Drow["interest_per"]);
                        txtInterestAmt.Text = Val.ToString(Drow["interest_amount"]);
                        txtNetAmount.Text = Val.ToString(Drow["net_amount"]);

                        m_dtbSaleReturnDetails = objSaleReturn.GetDataDetails(Val.ToInt(lblMode.Tag));

                        grdSaleReturnDetail.DataSource = m_dtbSaleReturnDetails;

                        ttlbSaleReturn.SelectedTabPage = tblSaleReturndetail;
                        txtSaleReturnNo.Focus();

                    }
                }
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                return;
            }
        }
        private void dgvSaleReturnDetail_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (e.Clicks == 2)
                    {
                        DataRow Drow = dgvSaleReturnDetail.GetDataRow(e.RowHandle);
                        btnAdd.Text = "&Update";
                        lueSieveName.Text = Val.ToString(Drow["sieve_name"]);
                        lueSieveName.Tag = Val.ToInt64(Drow["sieve_id"]);
                        lueSubSieveName.Text = Val.ToString(Drow["sub_sieve_name"]);
                        lueSubSieveName.Tag = Val.ToInt64(Drow["sub_sieve_id"]);
                        lueAssortName.Text = Val.ToString(Drow["assort_name"]);
                        lueAssortName.Tag = Val.ToInt64(Drow["assort_id"]);
                        txtPcs.Text = Val.ToString(Drow["pcs"]);
                        txtCarat.Text = Val.ToString(Drow["carat"]);
                        txtRate.Text = Val.ToString(Drow["rate"]);
                        txtAmount.Text = Val.ToString(Drow["amount"]);
                        m_numcarat = Val.ToDecimal(Drow["carat"]);
                        m_SaleReturn_detail_id = Val.ToInt(Drow["return_detail_id"]);
                        m_update_srno = Val.ToInt(Drow["sr_no"]);
                    }
                }
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                return;
            }
        }

        #endregion

        #endregion

        #region Functions
        private bool LoadDefaults()
        {
            bool blnReturn = true;
            try
            {
                Global.LOOKUPParty(lueParty);
                Global.LOOKUPBroker(lueBroker);
                Global.LOOKUPDeliveryType(lueDeliveryType);

                m_dtbAssorts = objAssort.GetData(1);
                lueAssortName.Properties.DataSource = m_dtbAssorts;
                lueAssortName.Properties.ValueMember = "assort_id";
                lueAssortName.Properties.DisplayMember = "assort_name";

                m_dtbSieve = objSieve.GetData(1);
                lueSieveName.Properties.DataSource = m_dtbSieve;
                lueSieveName.Properties.ValueMember = "sieve_id";
                lueSieveName.Properties.DisplayMember = "sieve_name";

                m_opDate = Global.GetDate();
                dtpFromDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpFromDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
                dtpFromDate.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpFromDate.Properties.CharacterCasing = CharacterCasing.Upper;
                dtpFromDate.EditValue = Val.DBDate(m_opDate.Rows[0]["opening_date"].ToString());

                dtpToDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpToDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
                dtpToDate.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpToDate.Properties.CharacterCasing = CharacterCasing.Upper;
                dtpToDate.EditValue = DateTime.Now;

                dtpSaleReturnDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpSaleReturnDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
                dtpSaleReturnDate.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpSaleReturnDate.Properties.CharacterCasing = CharacterCasing.Upper;
                dtpSaleReturnDate.EditValue = DateTime.Now;
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                blnReturn = false;
            }
            finally
            {
                objAssort = null;
                objSieve = null;
            }

            return blnReturn;
        }
        private bool AddInGrid()
        {
            bool blnReturn = true;

            try
            {
                m_blnadd = true;
                m_blnsave = false;
                if (!ValidateDetails())
                {
                    m_blnadd = false;
                    blnReturn = false;
                    return blnReturn;
                }

                if (btnAdd.Text == "&Add")
                {
                    DataRow[] dr = m_dtbSaleReturnDetails.Select("sieve_id = " + Val.ToInt(lueSieveName.EditValue) + " AND assort_id = " + Val.ToInt(lueAssortName.EditValue) + " AND sub_sieve_id = " + Val.ToInt(lueSubSieveName.EditValue));
                    if (dr.Count() == 1)
                    {
                        Global.Message("Record already exists in grid", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lueAssortName.Focus();
                        blnReturn = false;
                        return blnReturn;
                    }

                    DataRow drwNew = m_dtbSaleReturnDetails.NewRow();
                    decimal numCarat = Val.ToDecimal(txtCarat.Text);
                    decimal numRate = Val.ToDecimal(txtRate.Text);
                    decimal numAmount = Val.ToDecimal(txtAmount.Text);
                    int numPcs = Val.ToInt(txtPcs.Text);

                    drwNew["sale_return_id"] = Val.ToInt(0);
                    drwNew["return_detail_id"] = Val.ToInt(0);

                    drwNew["assort_id"] = Val.ToInt(lueAssortName.EditValue);
                    drwNew["assort_name"] = Val.ToString(lueAssortName.Text);

                    drwNew["sieve_id"] = Val.ToInt(lueSieveName.EditValue);
                    drwNew["sieve_name"] = Val.ToString(lueSieveName.Text);

                    drwNew["sub_sieve_id"] = Val.ToInt(lueSubSieveName.EditValue);
                    drwNew["sub_sieve_name"] = Val.ToString(lueSubSieveName.Text);

                    drwNew["pcs"] = numPcs;
                    drwNew["carat"] = numCarat;
                    drwNew["rate"] = Val.ToDecimal(txtRate.Text);
                    drwNew["amount"] = Math.Round(Val.ToDecimal(txtCarat.Text) * Val.ToDecimal(txtRate.Text), 3);
                    drwNew["old_carat"] = Val.ToDecimal(0);
                    drwNew["old_pcs"] = Val.ToDecimal(0);
                    drwNew["flag"] = Val.ToInt(0);
                    m_srno = m_srno + 1;
                    drwNew["sr_no"] = Val.ToInt(m_srno);

                    drwNew["current_rate"] = m_current_rate;
                    drwNew["current_amount"] = m_current_amount;

                    m_dtbSaleReturnDetails.Rows.Add(drwNew);

                    dgvSaleReturnDetail.MoveLast();

                    decimal Shipping_Charge = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) + Val.ToDecimal(txtInterestAmt.Text)) - (Val.ToDecimal(txtDiscountAmt.Text)) + Val.ToDecimal(txtShippingCharge.Text), 0);
                    txtNetAmount.Text = Shipping_Charge.ToString();
                }
                else if (btnAdd.Text == "&Update")
                {
                    objSaleReturn = new SaleReturn();
                    //if (Val.ToDecimal(txtCarat.Text) > m_numcarat)
                    //{
                    //if (m_SaleReturn_detail_id == 0)
                    //{
                    //    DataTable p_dtbStockCarat = new DataTable();
                    //    p_dtbStockCarat = objSaleReturn.GetStockCarat(GlobalDec.gEmployeeProperty.company_id, GlobalDec.gEmployeeProperty.branch_id, GlobalDec.gEmployeeProperty.location_id, GlobalDec.gEmployeeProperty.department_id, Val.ToInt(lueAssortName.EditValue), Val.ToInt(lueSieveName.EditValue));

                    //    if (p_dtbStockCarat.Rows.Count > 0)
                    //    {
                    //        numStockCarat = Val.ToDecimal(p_dtbStockCarat.Rows[0]["stock_carat"]);
                    //    }

                    //    if (numStockCarat < Val.ToDecimal(txtCarat.Text))
                    //    {
                    //        Global.Message("Please check enter carat more then stock carat", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        txtCarat.Focus();
                    //        blnReturn = false;
                    //        return blnReturn;
                    //    }
                    //}
                    //else
                    //{
                    //    DataTable p_dtbStockCarat = new DataTable();
                    //    p_dtbStockCarat = objSaleReturn.GetStockCarat(GlobalDec.gEmployeeProperty.company_id, GlobalDec.gEmployeeProperty.branch_id, GlobalDec.gEmployeeProperty.location_id, GlobalDec.gEmployeeProperty.department_id, Val.ToInt(lueAssortName.EditValue), Val.ToInt(lueSieveName.EditValue));

                    //    decimal p_numdiff_Carat = Val.ToDecimal(txtCarat.Text) - m_numcarat;

                    //    if (p_dtbStockCarat.Rows.Count > 0)
                    //    {
                    //        numStockCarat = Val.ToDecimal(p_dtbStockCarat.Rows[0]["stock_carat"]);
                    //    }

                    //    if (numStockCarat < Val.ToDecimal(p_numdiff_Carat))
                    //    {
                    //        Global.Message("Please check enter carat more then stock carat", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        txtCarat.Focus();
                    //        blnReturn = false;
                    //        return blnReturn;
                    //    }
                    //}
                    //}

                    if (m_dtbSaleReturnDetails.Select("assort_id ='" + Val.ToInt(lueAssortName.EditValue) + "' AND sieve_id ='" + Val.ToInt(lueSieveName.EditValue) + "'").Length > 0)
                    {
                        for (int i = 0; i < m_dtbSaleReturnDetails.Rows.Count; i++)
                        {
                            if (m_dtbSaleReturnDetails.Select("return_detail_id ='" + m_SaleReturn_detail_id + "' AND sr_no = '" + m_update_srno + "'").Length > 0)
                            {
                                if (m_dtbSaleReturnDetails.Rows[m_update_srno - 1]["return_detail_id"].ToString() == m_SaleReturn_detail_id.ToString())
                                {
                                    m_dtbSaleReturnDetails.Rows[m_update_srno - 1]["carat"] = Val.ToDecimal(txtCarat.Text).ToString();
                                    m_dtbSaleReturnDetails.Rows[m_update_srno - 1]["pcs"] = Val.ToInt(txtPcs.Text);
                                    m_dtbSaleReturnDetails.Rows[m_update_srno - 1]["rate"] = Val.ToDecimal(txtRate.Text);
                                    m_dtbSaleReturnDetails.Rows[m_update_srno - 1]["flag"] = 1;
                                    m_dtbSaleReturnDetails.Rows[m_update_srno - 1]["amount"] = Math.Round(Val.ToDecimal(txtCarat.Text) * Val.ToDecimal(txtRate.Text), 3);
                                    m_dtbSaleReturnDetails.Rows[m_update_srno - 1]["current_rate"] = m_current_rate;
                                    m_dtbSaleReturnDetails.Rows[m_update_srno - 1]["current_amount"] = m_current_amount;
                                    decimal Shipping_Charge = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) + Val.ToDecimal(txtInterestAmt.Text)) - (Val.ToDecimal(txtDiscountAmt.Text)) + Val.ToDecimal(txtShippingCharge.Text), 0);
                                    txtNetAmount.Text = Shipping_Charge.ToString();
                                    break;
                                }
                            }
                        }
                        btnAdd.Text = "&Add";
                    }
                    else
                    {
                        for (int i = 0; i < m_dtbSaleReturnDetails.Rows.Count; i++)
                        {
                            if (m_dtbSaleReturnDetails.Select("return_detail_id ='" + m_SaleReturn_detail_id + "' AND sr_no = '" + m_update_srno + "'").Length > 0)
                            {
                                if (m_dtbSaleReturnDetails.Rows[m_update_srno - 1]["return_detail_id"].ToString() == m_SaleReturn_detail_id.ToString())
                                {
                                    m_dtbSaleReturnDetails.Rows[m_update_srno - 1]["carat"] = Val.ToDecimal(txtCarat.Text).ToString();
                                    m_dtbSaleReturnDetails.Rows[m_update_srno - 1]["pcs"] = Val.ToInt(txtPcs.Text);
                                    m_dtbSaleReturnDetails.Rows[m_update_srno - 1]["rate"] = Val.ToDecimal(txtRate.Text);
                                    m_dtbSaleReturnDetails.Rows[m_update_srno - 1]["flag"] = 1;
                                    m_dtbSaleReturnDetails.Rows[m_update_srno - 1]["assort_id"] = Val.ToInt(lueAssortName.EditValue);
                                    m_dtbSaleReturnDetails.Rows[m_update_srno - 1]["sieve_id"] = Val.ToInt(lueSieveName.EditValue);
                                    m_dtbSaleReturnDetails.Rows[m_update_srno - 1]["sub_sieve_id"] = Val.ToInt(lueSubSieveName.EditValue);
                                    m_dtbSaleReturnDetails.Rows[m_update_srno - 1]["assort_name"] = Val.ToString(lueAssortName.Text);
                                    m_dtbSaleReturnDetails.Rows[m_update_srno - 1]["sieve_name"] = Val.ToString(lueSieveName.Text);
                                    m_dtbSaleReturnDetails.Rows[m_update_srno - 1]["sub_sieve_name"] = Val.ToString(lueSubSieveName.Text);

                                    m_dtbSaleReturnDetails.Rows[m_update_srno - 1]["amount"] = Math.Round(Val.ToDecimal(txtCarat.Text) * Val.ToDecimal(txtRate.Text), 3);
                                    m_dtbSaleReturnDetails.Rows[m_update_srno - 1]["current_rate"] = m_current_rate;
                                    m_dtbSaleReturnDetails.Rows[m_update_srno - 1]["current_amount"] = m_current_amount;
                                    decimal Shipping_Charge = Math.Round((Val.ToDecimal(clmRSAmount.SummaryItem.SummaryValue) + Val.ToDecimal(txtInterestAmt.Text)) - (Val.ToDecimal(txtDiscountAmt.Text)) + Val.ToDecimal(txtShippingCharge.Text), 0);
                                    txtNetAmount.Text = Shipping_Charge.ToString();
                                }
                            }
                        }
                        btnAdd.Text = "&Add";
                    }
                    dgvSaleReturnDetail.MoveLast();
                }
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                blnReturn = false;
            }
            return blnReturn;
        }
        private bool ValidateDetails()
        {
            bool blnFocus = false;
            List<ListError> lstError = new List<ListError>();
            try
            {
                if (m_blnsave)
                {
                    var result = DateTime.Compare(Convert.ToDateTime(dtpSaleReturnDate.Text), DateTime.Today);
                    if (result > 0)
                    {
                        lstError.Add(new ListError(5, "Sale Return Date Not Be Greater Than Today Date"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            dtpSaleReturnDate.Focus();
                        }
                    }

                    if (m_dtbSaleReturnDetails.Rows.Count == 0)
                    {
                        lstError.Add(new ListError(22, "Record"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                        }
                    }
                }

                if (m_blnadd)
                {
                    if (lueAssortName.Text == "")
                    {
                        lstError.Add(new ListError(13, "Assort"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            lueAssortName.Focus();
                        }
                    }
                    if (lueSieveName.Text == "")
                    {
                        lstError.Add(new ListError(13, "Sieve"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            lueSieveName.Focus();
                        }
                    }
                    if (lueSubSieveName.Text == "")
                    {
                        lstError.Add(new ListError(13, "Sub Sieve"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            lueSubSieveName.Focus();
                        }
                    }

                    if (Val.ToDouble(txtCarat.Text) == 0)
                    {
                        lstError.Add(new ListError(12, "Carat"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            txtCarat.Focus();
                        }
                    }

                    if (Val.ToDouble(txtRate.Text) == 0)
                    {
                        lstError.Add(new ListError(12, "Rate"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            txtRate.Focus();
                        }
                    }

                    if (Val.ToDouble(txtAmount.Text) == 0)
                    {
                        lstError.Add(new ListError(12, "Amount"));
                        if (!blnFocus)
                        {
                            blnFocus = true;
                            txtAmount.Focus();
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                lstError.Add(new ListError(ex));
            }
            return (!(BLL.General.ShowErrors(lstError)));
        }
        private bool ClearDetails()
        {
            bool blnReturn = true;
            try
            {
                if (!GenerateSaleReturnDetails())
                {
                    blnReturn = false;
                    return blnReturn;
                }

                lblMode.Tag = null;
                lueParty.EditValue = System.DBNull.Value;
                lueBroker.EditValue = System.DBNull.Value;
                lueDeliveryType.EditValue = System.DBNull.Value;
                lueDeliveryType.EditValue = Val.ToInt32(GlobalDec.gEmployeeProperty.delivery_type_id);
                txtSaleReturnNo.Text = string.Empty;
                dtpDueDate.EditValue = string.Empty;
                txtTermDays.Text = string.Empty;
                txtAddOnDays.Text = string.Empty;

                dtpSaleReturnDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpSaleReturnDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
                dtpSaleReturnDate.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpSaleReturnDate.Properties.CharacterCasing = CharacterCasing.Upper;
                dtpSaleReturnDate.EditValue = DateTime.Now;

                m_opDate = Global.GetDate();
                dtpFromDate.Properties.Mask.Culture = new System.Globalization.CultureInfo("en-US");
                dtpFromDate.Properties.Mask.EditMask = "dd/MMM/yyyy";
                dtpFromDate.Properties.Mask.UseMaskAsDisplayFormat = true;
                dtpFromDate.Properties.CharacterCasing = CharacterCasing.Upper;
                dtpFromDate.EditValue = Val.DBDate(m_opDate.Rows[0]["opening_date"].ToString());

                lueAssortName.EditValue = System.DBNull.Value;
                lueSieveName.EditValue = System.DBNull.Value;
                lueSubSieveName.EditValue = System.DBNull.Value;
                txtPcs.Text = string.Empty;
                txtCarat.Text = string.Empty;
                txtRate.Text = string.Empty;
                txtAmount.Text = string.Empty;
                txtBrokeragePer.Text = string.Empty;
                txtBrokerageAmt.Text = string.Empty;
                txtDiscountPer.Text = string.Empty;
                txtDiscountAmt.Text = string.Empty;
                txtInterestPer.Text = string.Empty;
                txtInterestAmt.Text = string.Empty;
                txtEntry.Text = string.Empty;
                txtJKK.Text = string.Empty;
                txtAccountRemark.Text = string.Empty;
                txtSaleRemark.Text = string.Empty;
                txtShippingCharge.Text = string.Empty;
                txtNetAmount.Text = string.Empty;
                btnAdd.Text = "&Add";
                txtSaleReturnNo.Focus();
                btnSave.Enabled = true;
                m_srno = 0;
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                blnReturn = false;
            }
            return blnReturn;
        }
        private bool GenerateSaleReturnDetails()
        {
            bool blnReturn = true;
            try
            {
                if (m_dtbSaleReturnDetails.Rows.Count > 0)
                    m_dtbSaleReturnDetails.Rows.Clear();

                m_dtbSaleReturnDetails = new DataTable();

                m_dtbSaleReturnDetails.Columns.Add("sr_no", typeof(int));
                m_dtbSaleReturnDetails.Columns.Add("return_detail_id", typeof(int));
                m_dtbSaleReturnDetails.Columns.Add("sale_return_id", typeof(int));
                m_dtbSaleReturnDetails.Columns.Add("assort_id", typeof(int));
                m_dtbSaleReturnDetails.Columns.Add("assort_name", typeof(string));
                m_dtbSaleReturnDetails.Columns.Add("sieve_id", typeof(int));
                m_dtbSaleReturnDetails.Columns.Add("sieve_name", typeof(string));
                m_dtbSaleReturnDetails.Columns.Add("sub_sieve_id", typeof(int));
                m_dtbSaleReturnDetails.Columns.Add("sub_sieve_name", typeof(string));
                m_dtbSaleReturnDetails.Columns.Add("pcs", typeof(int)).DefaultValue = 0;
                m_dtbSaleReturnDetails.Columns.Add("carat", typeof(decimal)).DefaultValue = 0;
                m_dtbSaleReturnDetails.Columns.Add("rate", typeof(decimal)).DefaultValue = 0;
                m_dtbSaleReturnDetails.Columns.Add("amount", typeof(decimal)).DefaultValue = 0;
                m_dtbSaleReturnDetails.Columns.Add("discount", typeof(decimal)).DefaultValue = 0;
                m_dtbSaleReturnDetails.Columns.Add("remarks", typeof(string));
                m_dtbSaleReturnDetails.Columns.Add("old_pcs", typeof(int)).DefaultValue = 0;
                m_dtbSaleReturnDetails.Columns.Add("old_carat", typeof(decimal));
                m_dtbSaleReturnDetails.Columns.Add("flag", typeof(int)).DefaultValue = 0;
                m_dtbSaleReturnDetails.Columns.Add("old_assort_id", typeof(int));
                m_dtbSaleReturnDetails.Columns.Add("old_sieve_id", typeof(int));
                m_dtbSaleReturnDetails.Columns.Add("old_sub_sieve_id", typeof(int));
                m_dtbSaleReturnDetails.Columns.Add("old_assort_name", typeof(string));
                m_dtbSaleReturnDetails.Columns.Add("old_sieve_name", typeof(string));
                m_dtbSaleReturnDetails.Columns.Add("old_sub_sieve_name", typeof(string));
                m_dtbSaleReturnDetails.Columns.Add("current_rate", typeof(decimal)).DefaultValue = 0;
                m_dtbSaleReturnDetails.Columns.Add("current_amount", typeof(decimal)).DefaultValue = 0;

                grdSaleReturnDetail.DataSource = m_dtbSaleReturnDetails;
                grdSaleReturnDetail.Refresh();
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                blnReturn = false;
            }
            return blnReturn;
        }
        private bool PopulateDetails()
        {
            objSaleReturn = new SaleReturn();
            bool blnReturn = true;
            DateTime datFromDate = DateTime.MinValue;
            DateTime datToDate = DateTime.MinValue;
            try
            {
                m_dtbDetails = objSaleReturn.GetData(Val.DBDate(dtpFromDate.Text), Val.DBDate(dtpToDate.Text));

                if (m_dtbDetails.Rows.Count == 0)
                {
                    Global.Message("Data Not Found");
                    blnReturn = false;
                }

                grdSaleReturn.DataSource = m_dtbDetails;

                dgvSaleReturn.BestFitColumns();
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                blnReturn = false;
            }
            finally
            {
                objSaleReturn = null;
            }

            return blnReturn;
        }
        public void SetControlPropertyValue(Control oControl, string propName, object propValue)
        {
            if (oControl.InvokeRequired)
            {
                SetControlValueCallback d = new SetControlValueCallback(SetControlPropertyValue);
                oControl.Invoke(d, new object[]
                        {
                            oControl,
                            propName,
                            propValue
                        });
            }
            else
            {
                Type t = oControl.GetType();
                PropertyInfo[] props = t.GetProperties();
                foreach (PropertyInfo p in props)
                {
                    if ((p.Name.ToUpper() == propName.ToUpper()))
                    {
                        p.SetValue(oControl, propValue, null);
                    }
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
                            dgvSaleReturn.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            dgvSaleReturn.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            dgvSaleReturn.ExportToXlsx(Filepath);
                            break;
                        case "rtf":
                            dgvSaleReturn.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            dgvSaleReturn.ExportToText(Filepath);
                            break;
                        case "html":
                            dgvSaleReturn.ExportToHtml(Filepath);
                            break;
                        case "csv":
                            dgvSaleReturn.ExportToCsv(Filepath);
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

        private void dtpSaleReturnDate_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtpSaleReturnDate.Text.Length <= 0 || dtpSaleReturnDate.Text == "")
                {
                    txtTermDays.Text = "";
                    txtAddOnDays.Text = "";
                    dtpDueDate.EditValue = null;
                }
                else
                {
                    Double Days = Val.ToDouble(txtTermDays.Text) + Val.ToDouble(txtAddOnDays.Text);
                    DateTime Date = Convert.ToDateTime(dtpSaleReturnDate.EditValue).AddDays(Val.ToDouble(Days));
                    dtpDueDate.EditValue = Val.DBDate(Date.ToShortDateString());
                }
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
            }
        }
    }
}