﻿namespace DERP.Transaction
{
    partial class FrmOpeningStock
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
            this.PanelSave = new DevExpress.XtraEditors.PanelControl();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnClear = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.grdOpeningStock = new DevExpress.XtraGrid.GridControl();
            this.ContextMNExport = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MNExportExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportPDF = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportTEXT = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportHTML = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportRTF = new System.Windows.Forms.ToolStripMenuItem();
            this.MNExportCSV = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvOpeningStock = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.assort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Sieve = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Shape = new DevExpress.XtraGrid.Columns.GridColumn();
            this.color = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Clarity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Cut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Polish = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Symmetry = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Fluorescence = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Pcs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Carat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Rate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Amount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnBrowse = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblPreferences = new DevExpress.XtraEditors.LabelControl();
            this.lblFormatSample = new DevExpress.XtraEditors.LabelControl();
            this.txtFileName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dtpOpeningDate = new DevExpress.XtraEditors.DateEdit();
            this.panelProgress = new DevExpress.XtraEditors.PanelControl();
            this.lblProgressCount = new System.Windows.Forms.Label();
            this.SaveProgressBar = new DevExpress.XtraEditors.MarqueeProgressBarControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.backgroundWorker_Opening = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.PanelSave)).BeginInit();
            this.PanelSave.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdOpeningStock)).BeginInit();
            this.ContextMNExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpeningStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpOpeningDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpOpeningDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelProgress)).BeginInit();
            this.panelProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SaveProgressBar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelSave
            // 
            this.PanelSave.Controls.Add(this.btnExit);
            this.PanelSave.Controls.Add(this.btnClear);
            this.PanelSave.Controls.Add(this.btnSave);
            this.PanelSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelSave.Location = new System.Drawing.Point(0, 692);
            this.PanelSave.Name = "PanelSave";
            this.PanelSave.Size = new System.Drawing.Size(1069, 50);
            this.PanelSave.TabIndex = 19;
            // 
            // btnExit
            // 
            this.btnExit.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.ImageOptions.Image = global::DERP.Properties.Resources.Exit;
            this.btnExit.Location = new System.Drawing.Point(228, 8);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 32);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "E&xit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Appearance.Options.UseFont = true;
            this.btnClear.ImageOptions.Image = global::DERP.Properties.Resources.Clear;
            this.btnClear.Location = new System.Drawing.Point(120, 8);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(102, 32);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "&Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.ImageOptions.Image = global::DERP.Properties.Resources.Save;
            this.btnSave.Location = new System.Drawing.Point(12, 8);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(102, 32);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grdOpeningStock
            // 
            this.grdOpeningStock.ContextMenuStrip = this.ContextMNExport;
            this.grdOpeningStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOpeningStock.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdOpeningStock.Location = new System.Drawing.Point(2, 2);
            this.grdOpeningStock.MainView = this.dgvOpeningStock;
            this.grdOpeningStock.Name = "grdOpeningStock";
            this.grdOpeningStock.Size = new System.Drawing.Size(1065, 642);
            this.grdOpeningStock.TabIndex = 20;
            this.grdOpeningStock.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.dgvOpeningStock});
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
            // dgvOpeningStock
            // 
            this.dgvOpeningStock.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.dgvOpeningStock.Appearance.ColumnFilterButton.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(184)))), ((int)(((byte)(251)))));
            this.dgvOpeningStock.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.dgvOpeningStock.Appearance.ColumnFilterButton.Options.UseBorderColor = true;
            this.dgvOpeningStock.Appearance.ColumnFilterButton.Options.UseForeColor = true;
            this.dgvOpeningStock.Appearance.FooterPanel.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvOpeningStock.Appearance.FooterPanel.Options.UseFont = true;
            this.dgvOpeningStock.Appearance.HeaderPanel.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold);
            this.dgvOpeningStock.Appearance.HeaderPanel.Options.UseFont = true;
            this.dgvOpeningStock.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.dgvOpeningStock.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.dgvOpeningStock.Appearance.Row.Font = new System.Drawing.Font("Cambria", 9F);
            this.dgvOpeningStock.Appearance.Row.Options.UseFont = true;
            this.dgvOpeningStock.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.assort,
            this.Sieve,
            this.Shape,
            this.color,
            this.Clarity,
            this.Cut,
            this.Polish,
            this.Symmetry,
            this.Fluorescence,
            this.Pcs,
            this.Carat,
            this.Rate,
            this.Amount});
            this.dgvOpeningStock.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.dgvOpeningStock.GridControl = this.grdOpeningStock;
            this.dgvOpeningStock.Name = "dgvOpeningStock";
            this.dgvOpeningStock.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.dgvOpeningStock.OptionsCustomization.AllowColumnMoving = false;
            this.dgvOpeningStock.OptionsCustomization.AllowFilter = false;
            this.dgvOpeningStock.OptionsCustomization.AllowGroup = false;
            this.dgvOpeningStock.OptionsCustomization.AllowSort = false;
            this.dgvOpeningStock.OptionsNavigation.EnterMoveNextColumn = true;
            this.dgvOpeningStock.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.dgvOpeningStock.OptionsView.ShowAutoFilterRow = true;
            this.dgvOpeningStock.OptionsView.ShowFooter = true;
            this.dgvOpeningStock.OptionsView.ShowGroupPanel = false;
            this.dgvOpeningStock.CustomSummaryCalculate += new DevExpress.Data.CustomSummaryEventHandler(this.dgvOpeningStock_CustomSummaryCalculate);
            // 
            // assort
            // 
            this.assort.Caption = "Assort";
            this.assort.FieldName = "assort";
            this.assort.Name = "assort";
            this.assort.OptionsColumn.AllowEdit = false;
            this.assort.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count)});
            this.assort.Visible = true;
            this.assort.VisibleIndex = 0;
            // 
            // Sieve
            // 
            this.Sieve.Caption = "Sieve";
            this.Sieve.FieldName = "sieve";
            this.Sieve.Name = "Sieve";
            this.Sieve.OptionsColumn.AllowEdit = false;
            this.Sieve.Visible = true;
            this.Sieve.VisibleIndex = 1;
            // 
            // Shape
            // 
            this.Shape.Caption = "Shape";
            this.Shape.FieldName = "shape";
            this.Shape.Name = "Shape";
            this.Shape.OptionsColumn.AllowEdit = false;
            this.Shape.Visible = true;
            this.Shape.VisibleIndex = 2;
            // 
            // color
            // 
            this.color.Caption = "Color";
            this.color.FieldName = "color";
            this.color.Name = "color";
            this.color.OptionsColumn.AllowEdit = false;
            this.color.Visible = true;
            this.color.VisibleIndex = 3;
            // 
            // Clarity
            // 
            this.Clarity.Caption = "Purity";
            this.Clarity.FieldName = "clarity";
            this.Clarity.Name = "Clarity";
            this.Clarity.OptionsColumn.AllowEdit = false;
            this.Clarity.Visible = true;
            this.Clarity.VisibleIndex = 4;
            // 
            // Cut
            // 
            this.Cut.Caption = "Cut";
            this.Cut.FieldName = "cut";
            this.Cut.Name = "Cut";
            this.Cut.OptionsColumn.AllowEdit = false;
            this.Cut.Visible = true;
            this.Cut.VisibleIndex = 5;
            // 
            // Polish
            // 
            this.Polish.Caption = "Polish";
            this.Polish.FieldName = "polish";
            this.Polish.Name = "Polish";
            this.Polish.OptionsColumn.AllowEdit = false;
            this.Polish.Visible = true;
            this.Polish.VisibleIndex = 6;
            // 
            // Symmetry
            // 
            this.Symmetry.Caption = "Symmetry";
            this.Symmetry.FieldName = "symmetry";
            this.Symmetry.Name = "Symmetry";
            this.Symmetry.OptionsColumn.AllowEdit = false;
            this.Symmetry.Visible = true;
            this.Symmetry.VisibleIndex = 7;
            // 
            // Fluorescence
            // 
            this.Fluorescence.Caption = "Fluorescence";
            this.Fluorescence.FieldName = "fluorescence";
            this.Fluorescence.Name = "Fluorescence";
            this.Fluorescence.OptionsColumn.AllowEdit = false;
            this.Fluorescence.Visible = true;
            this.Fluorescence.VisibleIndex = 8;
            // 
            // Pcs
            // 
            this.Pcs.Caption = "Pcs";
            this.Pcs.FieldName = "pcs";
            this.Pcs.Name = "Pcs";
            this.Pcs.OptionsColumn.AllowEdit = false;
            this.Pcs.Visible = true;
            this.Pcs.VisibleIndex = 9;
            // 
            // Carat
            // 
            this.Carat.Caption = "Carat";
            this.Carat.FieldName = "carat";
            this.Carat.Name = "Carat";
            this.Carat.OptionsColumn.AllowEdit = false;
            this.Carat.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.Carat.Visible = true;
            this.Carat.VisibleIndex = 10;
            // 
            // Rate
            // 
            this.Rate.Caption = "Rate";
            this.Rate.FieldName = "rate";
            this.Rate.Name = "Rate";
            this.Rate.OptionsColumn.AllowEdit = false;
            this.Rate.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Custom)});
            this.Rate.Visible = true;
            this.Rate.VisibleIndex = 11;
            // 
            // Amount
            // 
            this.Amount.Caption = "Amount";
            this.Amount.FieldName = "amount";
            this.Amount.Name = "Amount";
            this.Amount.OptionsColumn.AllowEdit = false;
            this.Amount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.Amount.Visible = true;
            this.Amount.VisibleIndex = 12;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Appearance.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Appearance.Options.UseFont = true;
            this.btnBrowse.ImageOptions.Image = global::DERP.Properties.Resources.Upload_final;
            this.btnBrowse.Location = new System.Drawing.Point(214, 5);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(102, 32);
            this.btnBrowse.TabIndex = 453;
            this.btnBrowse.Text = "&Browse";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblPreferences);
            this.panelControl1.Controls.Add(this.lblFormatSample);
            this.panelControl1.Controls.Add(this.txtFileName);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.dtpOpeningDate);
            this.panelControl1.Controls.Add(this.btnBrowse);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1069, 46);
            this.panelControl1.TabIndex = 18;
            // 
            // lblPreferences
            // 
            this.lblPreferences.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreferences.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblPreferences.Appearance.Options.UseFont = true;
            this.lblPreferences.Appearance.Options.UseForeColor = true;
            this.lblPreferences.Location = new System.Drawing.Point(736, 14);
            this.lblPreferences.Name = "lblPreferences";
            this.lblPreferences.Size = new System.Drawing.Size(302, 13);
            this.lblPreferences.TabIndex = 462;
            this.lblPreferences.Text = "Please Contact Administrator For Preferences Setting";
            this.lblPreferences.Visible = false;
            // 
            // lblFormatSample
            // 
            this.lblFormatSample.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormatSample.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lblFormatSample.Appearance.Options.UseFont = true;
            this.lblFormatSample.Appearance.Options.UseForeColor = true;
            this.lblFormatSample.Location = new System.Drawing.Point(336, 14);
            this.lblFormatSample.Name = "lblFormatSample";
            this.lblFormatSample.Size = new System.Drawing.Size(168, 13);
            this.lblFormatSample.TabIndex = 461;
            this.lblFormatSample.Text = "Click For Excel Format Sample";
            this.lblFormatSample.Click += new System.EventHandler(this.lblFormatSample_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.EnterMoveNextControl = true;
            this.txtFileName.Location = new System.Drawing.Point(527, 11);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileName.Properties.Appearance.Options.UseFont = true;
            this.txtFileName.Size = new System.Drawing.Size(71, 20);
            this.txtFileName.TabIndex = 455;
            this.txtFileName.Visible = false;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(12, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(69, 13);
            this.labelControl2.TabIndex = 421;
            this.labelControl2.Text = "Opening Stock";
            // 
            // dtpOpeningDate
            // 
            this.dtpOpeningDate.EditValue = null;
            this.dtpOpeningDate.Location = new System.Drawing.Point(87, 9);
            this.dtpOpeningDate.Name = "dtpOpeningDate";
            this.dtpOpeningDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpOpeningDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpOpeningDate.Size = new System.Drawing.Size(121, 20);
            this.dtpOpeningDate.TabIndex = 454;
            this.dtpOpeningDate.EditValueChanged += new System.EventHandler(this.dtpOpeningDate_EditValueChanged);
            // 
            // panelProgress
            // 
            this.panelProgress.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelProgress.Controls.Add(this.lblProgressCount);
            this.panelProgress.Controls.Add(this.SaveProgressBar);
            this.panelProgress.Location = new System.Drawing.Point(376, 178);
            this.panelProgress.Name = "panelProgress";
            this.panelProgress.Size = new System.Drawing.Size(283, 58);
            this.panelProgress.TabIndex = 21;
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
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.panelProgress);
            this.panelControl3.Controls.Add(this.grdOpeningStock);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 46);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1069, 646);
            this.panelControl3.TabIndex = 21;
            // 
            // backgroundWorker_Opening
            // 
            this.backgroundWorker_Opening.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_Opening_DoWork);
            this.backgroundWorker_Opening.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_Opening_RunWorkerCompleted);
            // 
            // FrmOpeningStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 742);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.PanelSave);
            this.Controls.Add(this.panelControl1);
            this.Name = "FrmOpeningStock";
            this.Text = "Opening Stock";
            this.Load += new System.EventHandler(this.FrmOpeningStock_Load);
            this.Shown += new System.EventHandler(this.FrmOpeningStock_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.PanelSave)).EndInit();
            this.PanelSave.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdOpeningStock)).EndInit();
            this.ContextMNExport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOpeningStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpOpeningDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpOpeningDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelProgress)).EndInit();
            this.panelProgress.ResumeLayout(false);
            this.panelProgress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SaveProgressBar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl PanelSave;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnClear;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.GridControl grdOpeningStock;
        private DevExpress.XtraGrid.Views.Grid.GridView dgvOpeningStock;
        private DevExpress.XtraGrid.Columns.GridColumn assort;
        private DevExpress.XtraGrid.Columns.GridColumn Sieve;
        private DevExpress.XtraGrid.Columns.GridColumn Shape;
        private DevExpress.XtraGrid.Columns.GridColumn color;
        private DevExpress.XtraGrid.Columns.GridColumn Clarity;
        private DevExpress.XtraGrid.Columns.GridColumn Cut;
        private DevExpress.XtraGrid.Columns.GridColumn Polish;
        private DevExpress.XtraGrid.Columns.GridColumn Symmetry;
        private DevExpress.XtraGrid.Columns.GridColumn Fluorescence;
        private DevExpress.XtraGrid.Columns.GridColumn Carat;
        private DevExpress.XtraEditors.SimpleButton btnBrowse;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.DateEdit dtpOpeningDate;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtFileName;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraGrid.Columns.GridColumn Pcs;
        private DevExpress.XtraGrid.Columns.GridColumn Rate;
        private DevExpress.XtraGrid.Columns.GridColumn Amount;
        private DevExpress.XtraEditors.LabelControl lblFormatSample;
        private DevExpress.XtraEditors.PanelControl panelProgress;
        private System.Windows.Forms.Label lblProgressCount;
        private DevExpress.XtraEditors.MarqueeProgressBarControl SaveProgressBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker_Opening;
        private DevExpress.XtraEditors.LabelControl lblPreferences;
        private System.Windows.Forms.ContextMenuStrip ContextMNExport;
        private System.Windows.Forms.ToolStripMenuItem MNExportExcel;
        private System.Windows.Forms.ToolStripMenuItem MNExportPDF;
        private System.Windows.Forms.ToolStripMenuItem MNExportTEXT;
        private System.Windows.Forms.ToolStripMenuItem MNExportHTML;
        private System.Windows.Forms.ToolStripMenuItem MNExportRTF;
        private System.Windows.Forms.ToolStripMenuItem MNExportCSV;
    }
}