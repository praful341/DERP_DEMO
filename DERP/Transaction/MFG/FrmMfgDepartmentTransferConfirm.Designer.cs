﻿namespace DERP.Transaction
{
    partial class FrmMfgDepartmentTransferConfirm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMfgDepartmentTransferConfirm));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.chkAll = new DevExpress.XtraEditors.CheckEdit();
            this.panelProgress = new DevExpress.XtraEditors.PanelControl();
            this.lblProgressCount = new System.Windows.Forms.Label();
            this.SaveProgressBar = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.grdDepartmentTransferConfirm = new DevExpress.XtraGrid.GridControl();
            this.ContextMNExport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MNExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportPDF = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportTEXT = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportHTML = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportRTF = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvDepartmentTransferConfirm = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.clmTransfer_id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repChkSel = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.clmTransferDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmFromCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmFromBranch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmFromLocation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmFDept = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmLot = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmCut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmPcs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmCarat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmRRPcs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmRRCarat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmUnionId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmKapan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmProcess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmSubProcess = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmToProcessName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmRoughClarity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmSieve = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmQuality = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmPurity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.clmJanged_No = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClmPacketTypeWages = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepWagesType = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ClmManagerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClmRoughSieveID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClmManager = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClmFacWagesID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepSieve = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ClmWagesSieve = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ClmManagerID2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.RepManager = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ClmManager1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.BtnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.dtpConfirmDate = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.lueWagesSieve = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.lueManager = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.lueWagesType = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl30 = new DevExpress.XtraEditors.LabelControl();
            this.txtLotID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.backgroundWorker_DeptConfirm = new System.ComponentModel.BackgroundWorker();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txtSelLot = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtSelCarat = new DevExpress.XtraEditors.TextEdit();
            this.txtSelPcs = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnConfirm = new DevExpress.XtraEditors.SimpleButton();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelProgress)).BeginInit();
            this.panelProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SaveProgressBar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDepartmentTransferConfirm)).BeginInit();
            this.ContextMNExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartmentTransferConfirm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repChkSel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepWagesType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepSieve)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpConfirmDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpConfirmDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueWagesSieve.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueManager.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueWagesType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSelLot.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSelCarat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSelPcs.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.panelControl4);
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1304, 397);
            this.panelControl1.TabIndex = 0;
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.chkAll);
            this.panelControl4.Controls.Add(this.panelProgress);
            this.panelControl4.Controls.Add(this.grdDepartmentTransferConfirm);
            this.panelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl4.Location = new System.Drawing.Point(2, 40);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(1300, 355);
            this.panelControl4.TabIndex = 28;
            // 
            // chkAll
            // 
            this.chkAll.Location = new System.Drawing.Point(21, 4);
            this.chkAll.Name = "chkAll";
            this.chkAll.Properties.Caption = "";
            this.chkAll.Size = new System.Drawing.Size(15, 19);
            this.chkAll.TabIndex = 26;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // panelProgress
            // 
            this.panelProgress.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelProgress.Controls.Add(this.lblProgressCount);
            this.panelProgress.Controls.Add(this.SaveProgressBar);
            this.panelProgress.Location = new System.Drawing.Point(184, 114);
            this.panelProgress.Name = "panelProgress";
            this.panelProgress.Size = new System.Drawing.Size(283, 58);
            this.panelProgress.TabIndex = 25;
            this.panelProgress.Visible = false;
            // 
            // lblProgressCount
            // 
            this.lblProgressCount.AutoSize = true;
            this.lblProgressCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblProgressCount.Location = new System.Drawing.Point(76, 37);
            this.lblProgressCount.Name = "lblProgressCount";
            this.lblProgressCount.Size = new System.Drawing.Size(0, 13);
            this.lblProgressCount.TabIndex = 1;
            // 
            // SaveProgressBar
            // 
            this.SaveProgressBar.EditValue = 0;
            this.SaveProgressBar.Location = new System.Drawing.Point(5, 5);
            this.SaveProgressBar.Name = "SaveProgressBar";
            this.SaveProgressBar.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.SaveProgressBar.Properties.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.SaveProgressBar.Properties.Appearance.BorderColor = System.Drawing.Color.Navy;
            this.SaveProgressBar.Properties.Appearance.ForeColor = System.Drawing.Color.Fuchsia;
            this.SaveProgressBar.Properties.LookAndFeel.SkinMaskColor = System.Drawing.Color.Lime;
            this.SaveProgressBar.Properties.LookAndFeel.SkinMaskColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.SaveProgressBar.Properties.LookAndFeel.SkinName = "Office 2013 Dark Gray";
            this.SaveProgressBar.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.SaveProgressBar.Size = new System.Drawing.Size(273, 25);
            this.SaveProgressBar.TabIndex = 0;
            // 
            // grdDepartmentTransferConfirm
            // 
            this.grdDepartmentTransferConfirm.ContextMenuStrip = this.ContextMNExport;
            this.grdDepartmentTransferConfirm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDepartmentTransferConfirm.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdDepartmentTransferConfirm.Location = new System.Drawing.Point(2, 2);
            this.grdDepartmentTransferConfirm.MainView = this.dgvDepartmentTransferConfirm;
            this.grdDepartmentTransferConfirm.Name = "grdDepartmentTransferConfirm";
            this.grdDepartmentTransferConfirm.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repChkSel,
            this.RepWagesType,
            this.RepManager,
            this.RepSieve});
            this.grdDepartmentTransferConfirm.Size = new System.Drawing.Size(1296, 351);
            this.grdDepartmentTransferConfirm.TabIndex = 21;
            this.grdDepartmentTransferConfirm.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvDepartmentTransferConfirm});
            // 
            // ContextMNExport
            // 
            this.ContextMNExport.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.ContextMNExport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MNExportExcel,
            this.MNExportPDF,
            this.MNExportTEXT,
            this.MNExportHTML,
            this.MNExportRTF,
            this.MNExportCSV});
            this.ContextMNExport.Name = "ContextExport";
            this.ContextMNExport.Size = new System.Drawing.Size(130, 136);
            // 
            // MNExportExcel
            // 
            this.MNExportExcel.Name = "MNExportExcel";
            this.MNExportExcel.Size = new System.Drawing.Size(129, 22);
            this.MNExportExcel.Text = "To Excel";
            this.MNExportExcel.Click += new System.EventHandler(this.MNExportExcel_Click);
            // 
            // MNExportPDF
            // 
            this.MNExportPDF.Name = "MNExportPDF";
            this.MNExportPDF.Size = new System.Drawing.Size(129, 22);
            this.MNExportPDF.Text = "To PDF";
            this.MNExportPDF.Click += new System.EventHandler(this.MNExportPDF_Click);
            // 
            // MNExportTEXT
            // 
            this.MNExportTEXT.Name = "MNExportTEXT";
            this.MNExportTEXT.Size = new System.Drawing.Size(129, 22);
            this.MNExportTEXT.Text = "To TEXT";
            this.MNExportTEXT.Click += new System.EventHandler(this.MNExportTEXT_Click);
            // 
            // MNExportHTML
            // 
            this.MNExportHTML.Name = "MNExportHTML";
            this.MNExportHTML.Size = new System.Drawing.Size(129, 22);
            this.MNExportHTML.Text = "To HTML";
            this.MNExportHTML.Click += new System.EventHandler(this.MNExportHTML_Click);
            // 
            // MNExportRTF
            // 
            this.MNExportRTF.Name = "MNExportRTF";
            this.MNExportRTF.Size = new System.Drawing.Size(129, 22);
            this.MNExportRTF.Text = "To RTF";
            this.MNExportRTF.Click += new System.EventHandler(this.MNExportRTF_Click);
            // 
            // MNExportCSV
            // 
            this.MNExportCSV.Name = "MNExportCSV";
            this.MNExportCSV.Size = new System.Drawing.Size(129, 22);
            this.MNExportCSV.Text = "To CSV";
            this.MNExportCSV.Click += new System.EventHandler(this.MNExportCSV_Click);
            // 
            // dgvDepartmentTransferConfirm
            // 
            this.dgvDepartmentTransferConfirm.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.dgvDepartmentTransferConfirm.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.dgvDepartmentTransferConfirm.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.dgvDepartmentTransferConfirm.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.dgvDepartmentTransferConfirm.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.dgvDepartmentTransferConfirm.Appearance.FooterPanel.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvDepartmentTransferConfirm.Appearance.FooterPanel.Options.UseFont = true;
            this.dgvDepartmentTransferConfirm.Appearance.HeaderPanel.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvDepartmentTransferConfirm.Appearance.HeaderPanel.Options.UseFont = true;
            this.dgvDepartmentTransferConfirm.Appearance.Row.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Bold);
            this.dgvDepartmentTransferConfirm.Appearance.Row.Options.UseFont = true;
            this.dgvDepartmentTransferConfirm.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.clmTransfer_id,
            this.clmSelected,
            this.clmTransferDate,
            this.clmFromCompany,
            this.clmFromBranch,
            this.clmFromLocation,
            this.clmFDept,
            this.clmLot,
            this.clmCut,
            this.clmPcs,
            this.clmCarat,
            this.clmRRPcs,
            this.clmRRCarat,
            this.clmUnionId,
            this.clmKapan,
            this.clmProcess,
            this.clmSubProcess,
            this.clmToProcessName,
            this.clmRoughClarity,
            this.clmSieve,
            this.clmQuality,
            this.clmPurity,
            this.clmJanged_No,
            this.ClmPacketTypeWages,
            this.ClmManagerID,
            this.ClmRoughSieveID,
            this.ClmManager,
            this.ClmFacWagesID,
            this.ClmWagesSieve,
            this.ClmManagerID2,
            this.ClmManager1});
            this.dgvDepartmentTransferConfirm.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.dgvDepartmentTransferConfirm.GridControl = this.grdDepartmentTransferConfirm;
            this.dgvDepartmentTransferConfirm.Name = "dgvDepartmentTransferConfirm";
            this.dgvDepartmentTransferConfirm.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvDepartmentTransferConfirm.OptionsCustomization.AllowGroup = false;
            this.dgvDepartmentTransferConfirm.OptionsCustomization.AllowSort = false;
            this.dgvDepartmentTransferConfirm.OptionsNavigation.EnterMoveNextColumn = true;
            this.dgvDepartmentTransferConfirm.OptionsView.ColumnAutoWidth = false;
            this.dgvDepartmentTransferConfirm.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.dgvDepartmentTransferConfirm.OptionsView.ShowAutoFilterRow = true;
            this.dgvDepartmentTransferConfirm.OptionsView.ShowFooter = true;
            this.dgvDepartmentTransferConfirm.OptionsView.ShowGroupPanel = false;
            this.dgvDepartmentTransferConfirm.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.dgvDepartmentTransferConfirm_RowStyle);
            this.dgvDepartmentTransferConfirm.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.dgvDepartmentTransferConfirm_CustomSummaryCalculate);
            this.dgvDepartmentTransferConfirm.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.dgvDepartmentTransferConfirm_CellValueChanging);
            this.dgvDepartmentTransferConfirm.ColumnFilterChanged += new System.EventHandler(this.dgvDepartmentTransferConfirm_ColumnFilterChanged);
            // 
            // clmTransfer_id
            // 
            this.clmTransfer_id.Caption = "Transfer Id";
            this.clmTransfer_id.FieldName = "transfer_id";
            this.clmTransfer_id.Name = "clmTransfer_id";
            this.clmTransfer_id.OptionsColumn.AllowEdit = false;
            this.clmTransfer_id.OptionsColumn.AllowFocus = false;
            this.clmTransfer_id.OptionsColumn.AllowMove = false;
            // 
            // clmSelected
            // 
            this.clmSelected.AppearanceCell.Font = new System.Drawing.Font("Verdana", 9F);
            this.clmSelected.AppearanceCell.Options.UseFont = true;
            this.clmSelected.AppearanceHeader.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.clmSelected.AppearanceHeader.Options.UseFont = true;
            this.clmSelected.Caption = "SEL";
            this.clmSelected.ColumnEdit = this.repChkSel;
            this.clmSelected.FieldName = "SEL";
            this.clmSelected.Name = "clmSelected";
            this.clmSelected.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.clmSelected.OptionsFilter.FilterPopupMode = DevExpress.XtraGrid.Columns.FilterPopupMode.CheckedList;
            this.clmSelected.Visible = true;
            this.clmSelected.VisibleIndex = 0;
            this.clmSelected.Width = 20;
            // 
            // repChkSel
            // 
            this.repChkSel.AutoHeight = false;
            this.repChkSel.Caption = "Check";
            this.repChkSel.Name = "repChkSel";
            this.repChkSel.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repChkSel.ValueGrayed = false;
            this.repChkSel.QueryValueByCheckState += new DevExpress.XtraEditors.Controls.QueryValueByCheckStateEventHandler(this.repChkSel_QueryValueByCheckState);
            this.repChkSel.CheckedChanged += new System.EventHandler(this.repChkSel_CheckedChanged);
            this.repChkSel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.repChkSel_MouseUp);
            // 
            // clmTransferDate
            // 
            this.clmTransferDate.Caption = "Trf.  Date";
            this.clmTransferDate.FieldName = "transfer_date";
            this.clmTransferDate.Name = "clmTransferDate";
            this.clmTransferDate.OptionsColumn.AllowEdit = false;
            this.clmTransferDate.OptionsColumn.AllowFocus = false;
            this.clmTransferDate.OptionsColumn.AllowMove = false;
            this.clmTransferDate.Visible = true;
            this.clmTransferDate.VisibleIndex = 1;
            this.clmTransferDate.Width = 71;
            // 
            // clmFromCompany
            // 
            this.clmFromCompany.Caption = "From Company";
            this.clmFromCompany.FieldName = "company";
            this.clmFromCompany.Name = "clmFromCompany";
            this.clmFromCompany.OptionsColumn.AllowEdit = false;
            this.clmFromCompany.OptionsColumn.AllowFocus = false;
            this.clmFromCompany.OptionsColumn.AllowMove = false;
            this.clmFromCompany.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.clmFromCompany.Visible = true;
            this.clmFromCompany.VisibleIndex = 20;
            this.clmFromCompany.Width = 94;
            // 
            // clmFromBranch
            // 
            this.clmFromBranch.Caption = "From Branch";
            this.clmFromBranch.FieldName = "branch";
            this.clmFromBranch.Name = "clmFromBranch";
            this.clmFromBranch.OptionsColumn.AllowEdit = false;
            this.clmFromBranch.OptionsColumn.AllowFocus = false;
            this.clmFromBranch.OptionsColumn.AllowMove = false;
            this.clmFromBranch.Visible = true;
            this.clmFromBranch.VisibleIndex = 21;
            this.clmFromBranch.Width = 94;
            // 
            // clmFromLocation
            // 
            this.clmFromLocation.Caption = "From Location";
            this.clmFromLocation.FieldName = "location";
            this.clmFromLocation.Name = "clmFromLocation";
            this.clmFromLocation.OptionsColumn.AllowEdit = false;
            this.clmFromLocation.OptionsColumn.AllowFocus = false;
            this.clmFromLocation.OptionsColumn.AllowMove = false;
            this.clmFromLocation.Visible = true;
            this.clmFromLocation.VisibleIndex = 22;
            this.clmFromLocation.Width = 73;
            // 
            // clmFDept
            // 
            this.clmFDept.Caption = "From Department";
            this.clmFDept.FieldName = "from_department";
            this.clmFDept.Name = "clmFDept";
            this.clmFDept.OptionsColumn.AllowEdit = false;
            this.clmFDept.OptionsColumn.AllowFocus = false;
            this.clmFDept.OptionsColumn.AllowMove = false;
            this.clmFDept.Visible = true;
            this.clmFDept.VisibleIndex = 11;
            this.clmFDept.Width = 78;
            // 
            // clmLot
            // 
            this.clmLot.Caption = "Barcode";
            this.clmLot.FieldName = "lot_id";
            this.clmLot.Name = "clmLot";
            this.clmLot.OptionsColumn.AllowEdit = false;
            this.clmLot.OptionsColumn.AllowFocus = false;
            this.clmLot.OptionsColumn.AllowMove = false;
            this.clmLot.Visible = true;
            this.clmLot.VisibleIndex = 2;
            this.clmLot.Width = 59;
            // 
            // clmCut
            // 
            this.clmCut.Caption = "Cut No";
            this.clmCut.FieldName = "cut_no";
            this.clmCut.Name = "clmCut";
            this.clmCut.OptionsColumn.AllowEdit = false;
            this.clmCut.OptionsColumn.AllowFocus = false;
            this.clmCut.OptionsColumn.AllowMove = false;
            this.clmCut.Visible = true;
            this.clmCut.VisibleIndex = 12;
            this.clmCut.Width = 50;
            // 
            // clmPcs
            // 
            this.clmPcs.Caption = "Pcs";
            this.clmPcs.FieldName = "pcs";
            this.clmPcs.Name = "clmPcs";
            this.clmPcs.OptionsColumn.AllowEdit = false;
            this.clmPcs.OptionsColumn.AllowFocus = false;
            this.clmPcs.OptionsColumn.AllowMove = false;
            this.clmPcs.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.clmPcs.Visible = true;
            this.clmPcs.VisibleIndex = 13;
            this.clmPcs.Width = 50;
            // 
            // clmCarat
            // 
            this.clmCarat.Caption = "Carat";
            this.clmCarat.FieldName = "carat";
            this.clmCarat.Name = "clmCarat";
            this.clmCarat.OptionsColumn.AllowEdit = false;
            this.clmCarat.OptionsColumn.AllowFocus = false;
            this.clmCarat.OptionsColumn.AllowMove = false;
            this.clmCarat.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.clmCarat.Visible = true;
            this.clmCarat.VisibleIndex = 14;
            this.clmCarat.Width = 54;
            // 
            // clmRRPcs
            // 
            this.clmRRPcs.Caption = "Out Pcs";
            this.clmRRPcs.FieldName = "rr_pcs";
            this.clmRRPcs.Name = "clmRRPcs";
            this.clmRRPcs.OptionsColumn.AllowEdit = false;
            this.clmRRPcs.OptionsColumn.AllowFocus = false;
            this.clmRRPcs.OptionsColumn.AllowMove = false;
            this.clmRRPcs.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.clmRRPcs.Visible = true;
            this.clmRRPcs.VisibleIndex = 15;
            this.clmRRPcs.Width = 54;
            // 
            // clmRRCarat
            // 
            this.clmRRCarat.Caption = "Out Carat";
            this.clmRRCarat.FieldName = "rr_carat";
            this.clmRRCarat.Name = "clmRRCarat";
            this.clmRRCarat.OptionsColumn.AllowEdit = false;
            this.clmRRCarat.OptionsColumn.AllowFocus = false;
            this.clmRRCarat.OptionsColumn.AllowMove = false;
            this.clmRRCarat.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.clmRRCarat.Visible = true;
            this.clmRRCarat.VisibleIndex = 16;
            this.clmRRCarat.Width = 69;
            // 
            // clmUnionId
            // 
            this.clmUnionId.Caption = "Union Id";
            this.clmUnionId.FieldName = "union_id";
            this.clmUnionId.Name = "clmUnionId";
            this.clmUnionId.OptionsColumn.AllowEdit = false;
            this.clmUnionId.OptionsColumn.AllowFocus = false;
            this.clmUnionId.OptionsColumn.AllowMove = false;
            // 
            // clmKapan
            // 
            this.clmKapan.Caption = "Kapan No";
            this.clmKapan.FieldName = "kapan_no";
            this.clmKapan.Name = "clmKapan";
            this.clmKapan.OptionsColumn.AllowEdit = false;
            this.clmKapan.OptionsColumn.AllowFocus = false;
            this.clmKapan.OptionsColumn.AllowMove = false;
            this.clmKapan.Visible = true;
            this.clmKapan.VisibleIndex = 17;
            // 
            // clmProcess
            // 
            this.clmProcess.Caption = "From Process";
            this.clmProcess.FieldName = "from_process";
            this.clmProcess.Name = "clmProcess";
            this.clmProcess.OptionsColumn.AllowEdit = false;
            this.clmProcess.OptionsColumn.AllowFocus = false;
            this.clmProcess.OptionsColumn.AllowMove = false;
            this.clmProcess.Visible = true;
            this.clmProcess.VisibleIndex = 18;
            // 
            // clmSubProcess
            // 
            this.clmSubProcess.Caption = "From Sub Process";
            this.clmSubProcess.FieldName = "from_sub_process_name";
            this.clmSubProcess.Name = "clmSubProcess";
            this.clmSubProcess.OptionsColumn.AllowEdit = false;
            this.clmSubProcess.OptionsColumn.AllowFocus = false;
            this.clmSubProcess.OptionsColumn.AllowMove = false;
            // 
            // clmToProcessName
            // 
            this.clmToProcessName.Caption = "To Process";
            this.clmToProcessName.FieldName = "to_process";
            this.clmToProcessName.Name = "clmToProcessName";
            this.clmToProcessName.OptionsColumn.AllowEdit = false;
            this.clmToProcessName.Visible = true;
            this.clmToProcessName.VisibleIndex = 19;
            // 
            // clmRoughClarity
            // 
            this.clmRoughClarity.Caption = "Rough Clarity";
            this.clmRoughClarity.FieldName = "rough_clarity_name";
            this.clmRoughClarity.Name = "clmRoughClarity";
            this.clmRoughClarity.OptionsColumn.AllowEdit = false;
            this.clmRoughClarity.OptionsColumn.AllowFocus = false;
            this.clmRoughClarity.OptionsColumn.AllowMove = false;
            this.clmRoughClarity.Visible = true;
            this.clmRoughClarity.VisibleIndex = 9;
            // 
            // clmSieve
            // 
            this.clmSieve.Caption = "Sieve";
            this.clmSieve.FieldName = "sieve_name";
            this.clmSieve.Name = "clmSieve";
            this.clmSieve.OptionsColumn.AllowEdit = false;
            this.clmSieve.OptionsColumn.AllowFocus = false;
            this.clmSieve.OptionsColumn.AllowMove = false;
            this.clmSieve.Visible = true;
            this.clmSieve.VisibleIndex = 7;
            // 
            // clmQuality
            // 
            this.clmQuality.Caption = "Quality";
            this.clmQuality.FieldName = "quality_name";
            this.clmQuality.Name = "clmQuality";
            this.clmQuality.OptionsColumn.AllowEdit = false;
            this.clmQuality.OptionsColumn.AllowFocus = false;
            this.clmQuality.OptionsColumn.AllowMove = false;
            this.clmQuality.Visible = true;
            this.clmQuality.VisibleIndex = 8;
            // 
            // clmPurity
            // 
            this.clmPurity.Caption = "Purity";
            this.clmPurity.FieldName = "purity_name";
            this.clmPurity.Name = "clmPurity";
            this.clmPurity.OptionsColumn.AllowEdit = false;
            this.clmPurity.OptionsColumn.AllowFocus = false;
            this.clmPurity.OptionsColumn.AllowMove = false;
            this.clmPurity.Visible = true;
            this.clmPurity.VisibleIndex = 10;
            // 
            // clmJanged_No
            // 
            this.clmJanged_No.Caption = "Janged_No";
            this.clmJanged_No.FieldName = "janged_no";
            this.clmJanged_No.Name = "clmJanged_No";
            this.clmJanged_No.OptionsColumn.AllowEdit = false;
            this.clmJanged_No.OptionsColumn.AllowFocus = false;
            this.clmJanged_No.OptionsColumn.AllowMove = false;
            this.clmJanged_No.Visible = true;
            this.clmJanged_No.VisibleIndex = 3;
            // 
            // ClmPacketTypeWages
            // 
            this.ClmPacketTypeWages.Caption = "Wages Type";
            this.ClmPacketTypeWages.ColumnEdit = this.RepWagesType;
            this.ClmPacketTypeWages.FieldName = "packet_type_id";
            this.ClmPacketTypeWages.Name = "ClmPacketTypeWages";
            this.ClmPacketTypeWages.Visible = true;
            this.ClmPacketTypeWages.VisibleIndex = 4;
            this.ClmPacketTypeWages.Width = 83;
            // 
            // RepWagesType
            // 
            this.RepWagesType.AutoHeight = false;
            this.RepWagesType.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepWagesType.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("packet_type_id", "Packet Type Of Wages", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("type", "Type")});
            this.RepWagesType.Name = "RepWagesType";
            this.RepWagesType.NullText = "";
            this.RepWagesType.ShowHeader = false;
            // 
            // ClmManagerID
            // 
            this.ClmManagerID.Caption = "Manager Id";
            this.ClmManagerID.FieldName = "employee_id";
            this.ClmManagerID.Name = "ClmManagerID";
            this.ClmManagerID.OptionsColumn.AllowEdit = false;
            this.ClmManagerID.OptionsColumn.AllowFocus = false;
            this.ClmManagerID.OptionsColumn.AllowMove = false;
            // 
            // ClmRoughSieveID
            // 
            this.ClmRoughSieveID.Caption = "Rough Sieve ID";
            this.ClmRoughSieveID.FieldName = "rough_sieve_id";
            this.ClmRoughSieveID.Name = "ClmRoughSieveID";
            this.ClmRoughSieveID.OptionsColumn.AllowEdit = false;
            this.ClmRoughSieveID.OptionsColumn.AllowFocus = false;
            this.ClmRoughSieveID.OptionsColumn.AllowMove = false;
            // 
            // ClmManager
            // 
            this.ClmManager.Caption = "Manager";
            this.ClmManager.FieldName = "employee_name";
            this.ClmManager.Name = "ClmManager";
            this.ClmManager.OptionsColumn.AllowEdit = false;
            this.ClmManager.OptionsColumn.AllowFocus = false;
            this.ClmManager.OptionsColumn.AllowMove = false;
            this.ClmManager.Visible = true;
            this.ClmManager.VisibleIndex = 23;
            // 
            // ClmFacWagesID
            // 
            this.ClmFacWagesID.Caption = "Wages Sieve";
            this.ClmFacWagesID.ColumnEdit = this.RepSieve;
            this.ClmFacWagesID.FieldName = "factory_wages_sieve_id";
            this.ClmFacWagesID.Name = "ClmFacWagesID";
            this.ClmFacWagesID.Visible = true;
            this.ClmFacWagesID.VisibleIndex = 6;
            this.ClmFacWagesID.Width = 87;
            // 
            // RepSieve
            // 
            this.RepSieve.AutoHeight = false;
            this.RepSieve.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepSieve.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("wages_sieve", "Wages Sieve"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("factory_wages_sieve_id", "Fact Wages Sieve ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default)});
            this.RepSieve.Name = "RepSieve";
            this.RepSieve.NullText = "";
            this.RepSieve.ShowHeader = false;
            // 
            // ClmWagesSieve
            // 
            this.ClmWagesSieve.Caption = "Set Fact Sieve";
            this.ClmWagesSieve.FieldName = "wages_sieve";
            this.ClmWagesSieve.Name = "ClmWagesSieve";
            this.ClmWagesSieve.Width = 95;
            // 
            // ClmManagerID2
            // 
            this.ClmManagerID2.Caption = "Set Manager";
            this.ClmManagerID2.ColumnEdit = this.RepManager;
            this.ClmManagerID2.FieldName = "manager_id";
            this.ClmManagerID2.Name = "ClmManagerID2";
            this.ClmManagerID2.Visible = true;
            this.ClmManagerID2.VisibleIndex = 5;
            this.ClmManagerID2.Width = 114;
            // 
            // RepManager
            // 
            this.RepManager.AutoHeight = false;
            this.RepManager.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.RepManager.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("manager_id", "Manager ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("manager_name", "Manager Name")});
            this.RepManager.Name = "RepManager";
            this.RepManager.NullText = "";
            // 
            // ClmManager1
            // 
            this.ClmManager1.Caption = "Set Manager";
            this.ClmManager1.FieldName = "manager_name";
            this.ClmManager1.Name = "ClmManager1";
            this.ClmManager1.Width = 96;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.BtnRefresh);
            this.panelControl3.Controls.Add(this.dtpConfirmDate);
            this.panelControl3.Controls.Add(this.label1);
            this.panelControl3.Controls.Add(this.btnClear);
            this.panelControl3.Controls.Add(this.lueWagesSieve);
            this.panelControl3.Controls.Add(this.labelControl6);
            this.panelControl3.Controls.Add(this.lueManager);
            this.panelControl3.Controls.Add(this.labelControl5);
            this.panelControl3.Controls.Add(this.btnAdd);
            this.panelControl3.Controls.Add(this.lueWagesType);
            this.panelControl3.Controls.Add(this.labelControl30);
            this.panelControl3.Controls.Add(this.txtLotID);
            this.panelControl3.Controls.Add(this.labelControl4);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(2, 2);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1300, 38);
            this.panelControl3.TabIndex = 27;
            // 
            // BtnRefresh
            // 
            this.BtnRefresh.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRefresh.Appearance.Options.UseFont = true;
            this.BtnRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.BtnRefresh.ImageOptions.Image = global::DERP.Properties.Resources.Erase_final;
            this.BtnRefresh.Location = new System.Drawing.Point(1257, 2);
            this.BtnRefresh.Name = "BtnRefresh";
            this.BtnRefresh.Size = new System.Drawing.Size(41, 34);
            this.BtnRefresh.TabIndex = 187;
            this.BtnRefresh.Text = " ";
            this.BtnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // dtpConfirmDate
            // 
            this.dtpConfirmDate.EditValue = null;
            this.dtpConfirmDate.EnterMoveNextControl = true;
            this.dtpConfirmDate.Location = new System.Drawing.Point(50, 8);
            this.dtpConfirmDate.Name = "dtpConfirmDate";
            this.dtpConfirmDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.dtpConfirmDate.Properties.Appearance.Options.UseFont = true;
            this.dtpConfirmDate.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.dtpConfirmDate.Properties.AppearanceDropDown.Options.UseFont = true;
            this.dtpConfirmDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpConfirmDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpConfirmDate.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtpConfirmDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtpConfirmDate.Size = new System.Drawing.Size(119, 22);
            this.dtpConfirmDate.TabIndex = 185;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 16);
            this.label1.TabIndex = 186;
            this.label1.Text = "Date";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Appearance.Options.UseFont = true;
            this.btnClear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.ImageOptions.Image")));
            this.btnClear.Location = new System.Drawing.Point(1094, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(102, 32);
            this.btnClear.TabIndex = 184;
            this.btnClear.Text = "&Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lueWagesSieve
            // 
            this.lueWagesSieve.EnterMoveNextControl = true;
            this.lueWagesSieve.Location = new System.Drawing.Point(895, 7);
            this.lueWagesSieve.Name = "lueWagesSieve";
            this.lueWagesSieve.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueWagesSieve.Properties.Appearance.Options.UseFont = true;
            this.lueWagesSieve.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.lueWagesSieve.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lueWagesSieve.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Bold);
            this.lueWagesSieve.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.lueWagesSieve.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lueWagesSieve.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueWagesSieve.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("rough_sieve_id", "Sieve ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("sieve_name", "Sieve")});
            this.lueWagesSieve.Properties.NullText = "";
            this.lueWagesSieve.Properties.ShowHeader = false;
            this.lueWagesSieve.Size = new System.Drawing.Size(77, 22);
            this.lueWagesSieve.TabIndex = 182;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.Location = new System.Drawing.Point(806, 10);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(83, 16);
            this.labelControl6.TabIndex = 183;
            this.labelControl6.Text = "Wages Sieve";
            // 
            // lueManager
            // 
            this.lueManager.EnterMoveNextControl = true;
            this.lueManager.Location = new System.Drawing.Point(602, 7);
            this.lueManager.Name = "lueManager";
            this.lueManager.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueManager.Properties.Appearance.Options.UseFont = true;
            this.lueManager.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.lueManager.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lueManager.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Bold);
            this.lueManager.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.lueManager.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lueManager.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueManager.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("short_name", "Short Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("manager_id", "Manager ID", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("manager_name", "Manager Name")});
            this.lueManager.Properties.NullText = "";
            this.lueManager.Size = new System.Drawing.Size(198, 22);
            this.lueManager.TabIndex = 180;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.Location = new System.Drawing.Point(539, 10);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(57, 16);
            this.labelControl5.TabIndex = 181;
            this.labelControl5.Text = "Manager";
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            this.btnAdd.Location = new System.Drawing.Point(988, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 32);
            this.btnAdd.TabIndex = 179;
            this.btnAdd.Text = "&Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lueWagesType
            // 
            this.lueWagesType.EnterMoveNextControl = true;
            this.lueWagesType.Location = new System.Drawing.Point(445, 7);
            this.lueWagesType.Name = "lueWagesType";
            this.lueWagesType.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lueWagesType.Properties.Appearance.Options.UseFont = true;
            this.lueWagesType.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.lueWagesType.Properties.AppearanceDropDown.Options.UseFont = true;
            this.lueWagesType.Properties.AppearanceDropDownHeader.Font = new System.Drawing.Font("Cambria", 11F, System.Drawing.FontStyle.Bold);
            this.lueWagesType.Properties.AppearanceDropDownHeader.Options.UseFont = true;
            this.lueWagesType.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.lueWagesType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueWagesType.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("packet_type_id", "Packet Type Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("type", "Type")});
            this.lueWagesType.Properties.NullText = "";
            this.lueWagesType.Properties.ShowHeader = false;
            this.lueWagesType.Size = new System.Drawing.Size(77, 22);
            this.lueWagesType.TabIndex = 177;
            // 
            // labelControl30
            // 
            this.labelControl30.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl30.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl30.Appearance.Options.UseFont = true;
            this.labelControl30.Appearance.Options.UseForeColor = true;
            this.labelControl30.Location = new System.Drawing.Point(359, 11);
            this.labelControl30.Name = "labelControl30";
            this.labelControl30.Size = new System.Drawing.Size(79, 16);
            this.labelControl30.TabIndex = 178;
            this.labelControl30.Text = "Wages Type";
            // 
            // txtLotID
            // 
            this.txtLotID.EditValue = "";
            this.txtLotID.EnterMoveNextControl = true;
            this.txtLotID.Location = new System.Drawing.Point(223, 7);
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Properties.AccessibleName = "EMPLOYEE";
            this.txtLotID.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLotID.Properties.Appearance.Options.UseFont = true;
            this.txtLotID.Size = new System.Drawing.Size(129, 22);
            this.txtLotID.TabIndex = 175;
            this.txtLotID.ToolTip = "Enter Employee Name";
            this.txtLotID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLotID_KeyPress);
            this.txtLotID.Validated += new System.EventHandler(this.txtLotID_Validated);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(175, 10);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(42, 16);
            this.labelControl4.TabIndex = 176;
            this.labelControl4.Text = "Lot Id";
            // 
            // backgroundWorker_DeptConfirm
            // 
            this.backgroundWorker_DeptConfirm.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_BTConfirm_DoWork);
            this.backgroundWorker_DeptConfirm.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_BTConfirm_RunWorkerCompleted);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.txtSelLot);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.txtSelCarat);
            this.panelControl2.Controls.Add(this.txtSelPcs);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.btnConfirm);
            this.panelControl2.Controls.Add(this.btnExit);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 397);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1304, 56);
            this.panelControl2.TabIndex = 29;
            // 
            // txtSelLot
            // 
            this.txtSelLot.EditValue = "";
            this.txtSelLot.Location = new System.Drawing.Point(103, 16);
            this.txtSelLot.Name = "txtSelLot";
            this.txtSelLot.Properties.AccessibleName = "EMPLOYEE";
            this.txtSelLot.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSelLot.Properties.Appearance.Options.UseFont = true;
            this.txtSelLot.Properties.ReadOnly = true;
            this.txtSelLot.Size = new System.Drawing.Size(68, 22);
            this.txtSelLot.TabIndex = 33;
            this.txtSelLot.ToolTip = "Enter Employee Name";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(5, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(90, 16);
            this.labelControl1.TabIndex = 32;
            this.labelControl1.Text = "Selected Lot";
            // 
            // txtSelCarat
            // 
            this.txtSelCarat.EditValue = "";
            this.txtSelCarat.Location = new System.Drawing.Point(333, 16);
            this.txtSelCarat.Name = "txtSelCarat";
            this.txtSelCarat.Properties.AccessibleName = "EMPLOYEE";
            this.txtSelCarat.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSelCarat.Properties.Appearance.Options.UseFont = true;
            this.txtSelCarat.Properties.ReadOnly = true;
            this.txtSelCarat.Size = new System.Drawing.Size(68, 22);
            this.txtSelCarat.TabIndex = 31;
            this.txtSelCarat.ToolTip = "Enter Employee Name";
            // 
            // txtSelPcs
            // 
            this.txtSelPcs.EditValue = "";
            this.txtSelPcs.Location = new System.Drawing.Point(206, 16);
            this.txtSelPcs.Name = "txtSelPcs";
            this.txtSelPcs.Properties.AccessibleName = "EMPLOYEE";
            this.txtSelPcs.Properties.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSelPcs.Properties.Appearance.Options.UseFont = true;
            this.txtSelPcs.Properties.ReadOnly = true;
            this.txtSelPcs.Size = new System.Drawing.Size(68, 22);
            this.txtSelPcs.TabIndex = 30;
            this.txtSelPcs.ToolTip = "Enter Employee Name";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(177, 19);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(25, 16);
            this.labelControl3.TabIndex = 29;
            this.labelControl3.Text = "Pcs";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(286, 19);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 16);
            this.labelControl2.TabIndex = 28;
            this.labelControl2.Text = "Carat";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Appearance.Options.UseFont = true;
            this.btnConfirm.ImageOptions.Image = global::DERP.Properties.Resources.Save;
            this.btnConfirm.Location = new System.Drawing.Point(1081, 11);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(102, 32);
            this.btnConfirm.TabIndex = 26;
            this.btnConfirm.Text = "&Confirm";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Appearance.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.ImageOptions.Image = global::DERP.Properties.Resources.Exit;
            this.btnExit.Location = new System.Drawing.Point(1189, 11);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 32);
            this.btnExit.TabIndex = 27;
            this.btnExit.Text = "E&xit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FrmMfgDepartmentTransferConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 453);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.panelControl2);
            this.Name = "FrmMfgDepartmentTransferConfirm";
            this.Text = "Department Transfer Confirm";
            this.Load += new System.EventHandler(this.FrmDepartmentTransferConfirm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelProgress)).EndInit();
            this.panelProgress.ResumeLayout(false);
            this.panelProgress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SaveProgressBar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDepartmentTransferConfirm)).EndInit();
            this.ContextMNExport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartmentTransferConfirm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repChkSel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepWagesType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepSieve)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RepManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpConfirmDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpConfirmDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueWagesSieve.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueManager.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lueWagesType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLotID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSelLot.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSelCarat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSelPcs.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl grdDepartmentTransferConfirm;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvDepartmentTransferConfirm;
        private DevExpress.XtraGrid.Columns.GridColumn clmTransfer_id;
        private DevExpress.XtraGrid.Columns.GridColumn clmFromCompany;
        private DevExpress.XtraGrid.Columns.GridColumn clmFromBranch;
        private DevExpress.XtraGrid.Columns.GridColumn clmFromLocation;
        private DevExpress.XtraGrid.Columns.GridColumn clmFDept;
        private DevExpress.XtraGrid.Columns.GridColumn clmCarat;
        private DevExpress.XtraGrid.Columns.GridColumn clmSelected;
        private DevExpress.XtraGrid.Columns.GridColumn clmTransferDate;
        private DevExpress.XtraEditors.PanelControl panelProgress;
        private System.Windows.Forms.Label lblProgressCount;
        private DevExpress.XtraEditors.MarqueeProgressBarControl SaveProgressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker_DeptConfirm;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btnConfirm;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraGrid.Columns.GridColumn clmLot;
        private DevExpress.XtraGrid.Columns.GridColumn clmCut;
        private DevExpress.XtraGrid.Columns.GridColumn clmPcs;
        private DevExpress.XtraGrid.Columns.GridColumn clmRRPcs;
        private DevExpress.XtraGrid.Columns.GridColumn clmRRCarat;
        private DevExpress.XtraGrid.Columns.GridColumn clmUnionId;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repChkSel;
        private DevExpress.XtraEditors.CheckEdit chkAll;
        private System.Windows.Forms.ContextMenuStrip ContextMNExport;
        private System.Windows.Forms.ToolStripMenuItem MNExportExcel;
        private System.Windows.Forms.ToolStripMenuItem MNExportPDF;
        private System.Windows.Forms.ToolStripMenuItem MNExportTEXT;
        private System.Windows.Forms.ToolStripMenuItem MNExportHTML;
        private System.Windows.Forms.ToolStripMenuItem MNExportRTF;
        private System.Windows.Forms.ToolStripMenuItem MNExportCSV;
        private DevExpress.XtraEditors.TextEdit txtSelCarat;
        private DevExpress.XtraEditors.TextEdit txtSelPcs;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtSelLot;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn clmKapan;
        private DevExpress.XtraGrid.Columns.GridColumn clmProcess;
        private DevExpress.XtraGrid.Columns.GridColumn clmSubProcess;
        private DevExpress.XtraGrid.Columns.GridColumn clmRoughClarity;
        private DevExpress.XtraGrid.Columns.GridColumn clmSieve;
        private DevExpress.XtraGrid.Columns.GridColumn clmQuality;
        private DevExpress.XtraGrid.Columns.GridColumn clmPurity;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.TextEdit txtLotID;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraGrid.Columns.GridColumn clmJanged_No;
        private DevExpress.XtraGrid.Columns.GridColumn ClmPacketTypeWages;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit RepWagesType;
        private DevExpress.XtraEditors.LookUpEdit lueWagesType;
        private DevExpress.XtraEditors.LabelControl labelControl30;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraGrid.Columns.GridColumn ClmManagerID;
        private DevExpress.XtraGrid.Columns.GridColumn ClmRoughSieveID;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit RepSieve;
        private DevExpress.XtraGrid.Columns.GridColumn ClmManager;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit RepManager;
        private DevExpress.XtraEditors.LookUpEdit lueWagesSieve;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LookUpEdit lueManager;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraGrid.Columns.GridColumn ClmFacWagesID;
        private DevExpress.XtraGrid.Columns.GridColumn ClmWagesSieve;
        private DevExpress.XtraGrid.Columns.GridColumn ClmManagerID2;
        private DevExpress.XtraGrid.Columns.GridColumn ClmManager1;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraGrid.Columns.GridColumn clmToProcessName;
        private DevExpress.XtraEditors.DateEdit dtpConfirmDate;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton BtnRefresh;
    }
}