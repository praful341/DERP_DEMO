﻿using BLL;
using BLL.FunctionClasses.Master;
using BLL.PropertyClasses.Master;
using DERP.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using static DERP.Class.Global;

namespace DREP.Master
{ 
    public partial class FrmColorMaster : DevExpress.XtraEditors.XtraForm
    {
        #region Data Member

        FormEvents objBOFormEvents;
        Validation Val;
        BLL.FormPer ObjPer;

        ColorMaster objColor;


        DataTable m_dtbType;
        #endregion

        #region Constructor
        public FrmColorMaster()
        {
            InitializeComponent();

            objBOFormEvents = new FormEvents();
            Val = new Validation();
            ObjPer = new BLL.FormPer();

            objColor = new ColorMaster();

            m_dtbType = new DataTable();
        }
        public void ShowForm()
        {
            ObjPer.FormName = this.Name.ToUpper();
            if (ObjPer.CheckPermission() == false)
            {
                Global.Message(BLL.GlobalDec.gStrPermissionViwMsg);
                return;
            }
            Val.frmGenSet(this);
            AttachFormEvents();
            this.Show();
        }
        private void AttachFormEvents()
        {
            objBOFormEvents.CurForm = this;
            objBOFormEvents.FormKeyPress = true;
            objBOFormEvents.FormKeyDown = true;
            objBOFormEvents.FormResize = true;
            objBOFormEvents.FormClosing = true;
            objBOFormEvents.ObjToDispose.Add(objColor);
            objBOFormEvents.ObjToDispose.Add(Val);
            objBOFormEvents.ObjToDispose.Add(objBOFormEvents);
        }

        #endregion

        #region Events
        private void FrmCountryMaster_Load(object sender, EventArgs e)
        {
            try
            {
                m_dtbType = new DataTable();
                m_dtbType.Columns.Add("type");
                m_dtbType.Rows.Add("ORG");
                m_dtbType.Rows.Add("LOSS");
                lueType.Properties.DataSource = m_dtbType;
                lueType.Properties.ValueMember = "type";
                lueType.Properties.DisplayMember = "type";
                lueType.EditValue = "ORG";
                GetData();
                btnClear_Click(btnClear, null);
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                return;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            ObjPer.FormName = this.Name.ToUpper();
            ObjPer.SetFormPer();
            if (ObjPer.AllowUpdate == false || ObjPer.AllowInsert == false)
            {
                Global.Message(BLL.GlobalDec.gStrPermissionInsUpdMsg);
                return;
            }
            btnSave.Enabled = false;

            if (SaveDetails())
            {
                GetData();
                btnClear_Click(sender, e);
            }

            btnSave.Enabled = true;
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                lblMode.Tag = 0;
                lblMode.Text = "Add Mode";
                txtColorName.Text = "";
                txtRemark.Text = "";
                txtSequenceNo.Text = "";
                chkActive.Checked = true;
                lueType.EditValue = "ORG";
                txtColorName.Focus();
            }
            catch (Exception ex)
            {
                BLL.General.ShowErrors(ex);
                return;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region GridEvent
        private void dgvColorMaster_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                if (e.RowHandle >= 0)
                {
                    if (e.Clicks == 2)
                    {
                        DataRow Drow = dgvColorMaster.GetDataRow(e.RowHandle);
                        lblMode.Text = "Edit Mode";
                        lblMode.Tag = Val.ToInt32(Drow["color_id"]);
                        txtColorName.Text = Val.ToString(Drow["color_name"]);
                        txtRemark.Text = Val.ToString(Drow["remarks"]);
                        txtSequenceNo.Text = Val.ToString(Drow["sequence_no"]);
                        lueType.EditValue = Val.ToString(Drow["type"]);
                        chkActive.Checked = Val.ToBoolean(Drow["active"]);
                        txtColorName.Focus();
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
        private bool SaveDetails()
        {
            bool blnReturn = true;
            Color_MasterProperty ColorMasterProperty = new Color_MasterProperty();
            ColorMaster objColor = new ColorMaster();

            try
            {
                if (!ValidateDetails())
                {
                    blnReturn = false;
                    return blnReturn;
                }

                ColorMasterProperty.color_id = Val.ToInt32(lblMode.Tag);
                ColorMasterProperty.color_name = txtColorName.Text.ToUpper();
                ColorMasterProperty.type = Val.ToString(lueType.EditValue);
                ColorMasterProperty.active = Val.ToBoolean(chkActive.Checked);
                ColorMasterProperty.remarks = txtRemark.Text.ToUpper();
                ColorMasterProperty.sequence_no = Val.ToInt(txtSequenceNo.Text);

                int IntRes = objColor.Save(ColorMasterProperty);
                if (IntRes == -1)
                {
                    Global.Confirm("Error In Save Color Details");
                    txtColorName.Focus();
                }
                else
                {
                    if (Val.ToInt(lblMode.Tag) == 0)
                    {
                        Global.Confirm("Color Details Data Save Successfully");
                    }
                    else
                    {
                        Global.Confirm("Color Details Data Update Successfully");
                    }
                }

            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                blnReturn = false;
            }
            finally
            {
                ColorMasterProperty = null;
            }

            return blnReturn;
        }
        private bool ValidateDetails()
        {
            bool blnFocus = false;
            List<ListError> lstError = new List<ListError>();
            try
            {
                if (txtColorName.Text == string.Empty)
                {
                    lstError.Add(new ListError(12, "Color Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtColorName.Focus();
                    }
                }

                if (!objColor.ISExists(txtColorName.Text, Val.ToInt64(lblMode.Tag)).ToString().Trim().Equals(string.Empty))
                {
                    lstError.Add(new ListError(23, "Color Name"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtColorName.Focus();
                    }
                }

                if (txtSequenceNo.Text == string.Empty || txtSequenceNo.Text == "0")
                {
                    lstError.Add(new ListError(12, "Sequence No"));
                    if (!blnFocus)
                    {
                        blnFocus = true;
                        txtSequenceNo.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                lstError.Add(new ListError(ex));
            }
            return (!(BLL.General.ShowErrors(lstError)));

        }
        public void GetData()
        {
            try
            {
                DataTable DTab = objColor.GetData();
                grdColorMaster.DataSource = DTab;
            }
            catch (Exception ex)
            {
                General.ShowErrors(ex.ToString());
                return;
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
                            dgvColorMaster.ExportToPdf(Filepath);
                            break;
                        case "xls":
                            dgvColorMaster.ExportToXls(Filepath);
                            break;
                        case "xlsx":
                            dgvColorMaster.ExportToXlsx(Filepath);
                            break;
                        case "rtf":
                            dgvColorMaster.ExportToRtf(Filepath);
                            break;
                        case "txt":
                            dgvColorMaster.ExportToText(Filepath);
                            break;
                        case "html":
                            dgvColorMaster.ExportToHtml(Filepath);
                            break;
                        case "csv":
                            dgvColorMaster.ExportToCsv(Filepath);
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
    }
}
