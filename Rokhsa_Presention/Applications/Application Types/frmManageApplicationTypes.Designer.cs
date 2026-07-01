using System.Windows.Forms;

namespace Create_DVLD.Applications.Application_Types
{
    public partial class frmManageApplicationTypes : Form
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
        /// 
        //private void InitializeComponent()
        //{
        //    this.components = new System.ComponentModel.Container();
        //    System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        //    this.btnClose = new System.Windows.Forms.Button();
        //    this.lblTitle = new System.Windows.Forms.Label();
        //    this.pbApplicationTypesmage = new System.Windows.Forms.PictureBox();
        //    this.lblRecordsCount = new System.Windows.Forms.Label();
        //    this.label2 = new System.Windows.Forms.Label();
        //    this.dgvApplicationTypes = new System.Windows.Forms.DataGridView();
        //    this.cmsApplicationTypes = new System.Windows.Forms.ContextMenuStrip(this.components);
        //    this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        //    this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        //    this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        //    ((System.ComponentModel.ISupportInitialize)(this.pbApplicationTypesmage)).BeginInit();
        //    ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationTypes)).BeginInit();
        //    this.cmsApplicationTypes.SuspendLayout();
        //    this.SuspendLayout();
        //    // 
        //    // btnClose
        //    // 
        //    this.btnClose.AutoEllipsis = true;
        //    this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        //    this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        //    this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        //    this.btnClose.Location = new System.Drawing.Point(570, 650);
        //    this.btnClose.Name = "btnClose";
        //    this.btnClose.Size = new System.Drawing.Size(135, 36);
        //    this.btnClose.TabIndex = 112;
        //    this.btnClose.Text = "Close";
        //    this.btnClose.UseVisualStyleBackColor = true;
        //    this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
        //    // 
        //    // lblTitle
        //    // 
        //    this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //    this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        //    this.lblTitle.Location = new System.Drawing.Point(155, 218);
        //    this.lblTitle.Name = "lblTitle";
        //    this.lblTitle.Size = new System.Drawing.Size(446, 55);
        //    this.lblTitle.TabIndex = 117;
        //    this.lblTitle.Text = "Manage Application Types";
        //    this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        //    // 
        //    // pbApplicationTypesmage
        //    // 
        //    this.pbApplicationTypesmage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
        //    this.pbApplicationTypesmage.Image = global::Create_DVLD.Properties.Resources.Application_Types_5121;
        //    this.pbApplicationTypesmage.InitialImage = null;
        //    this.pbApplicationTypesmage.Location = new System.Drawing.Point(263, 14);
        //    this.pbApplicationTypesmage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        //    this.pbApplicationTypesmage.Name = "pbApplicationTypesmage";
        //    this.pbApplicationTypesmage.Size = new System.Drawing.Size(220, 189);
        //    this.pbApplicationTypesmage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        //    this.pbApplicationTypesmage.TabIndex = 116;
        //    this.pbApplicationTypesmage.TabStop = false;
        //    this.pbApplicationTypesmage.Click += new System.EventHandler(this.pbApplicationTypesmage_Click);
        //    // 
        //    // lblRecordsCount
        //    // 
        //    this.lblRecordsCount.AutoSize = true;
        //    this.lblRecordsCount.Location = new System.Drawing.Point(173, 664);
        //    this.lblRecordsCount.Name = "lblRecordsCount";
        //    this.lblRecordsCount.Size = new System.Drawing.Size(27, 20);
        //    this.lblRecordsCount.TabIndex = 115;
        //    this.lblRecordsCount.Text = "??";
        //    // 
        //    // label2
        //    // 
        //    this.label2.AutoSize = true;
        //    this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //    this.label2.Location = new System.Drawing.Point(28, 657);
        //    this.label2.Name = "label2";
        //    this.label2.Size = new System.Drawing.Size(139, 29);
        //    this.label2.TabIndex = 114;
        //    this.label2.Text = "# Records:";
        //    // 
        //    // dgvApplicationTypes
        //    // 
        //    this.dgvApplicationTypes.AllowUserToAddRows = false;
        //    this.dgvApplicationTypes.AllowUserToDeleteRows = false;
        //    this.dgvApplicationTypes.AllowUserToResizeRows = false;
        //    this.dgvApplicationTypes.BackgroundColor = System.Drawing.Color.White;
        //    this.dgvApplicationTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        //    this.dgvApplicationTypes.ContextMenuStrip = this.cmsApplicationTypes;
        //    this.dgvApplicationTypes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
        //    this.dgvApplicationTypes.Location = new System.Drawing.Point(26, 288);
        //    this.dgvApplicationTypes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
        //    this.dgvApplicationTypes.MultiSelect = false;
        //    this.dgvApplicationTypes.Name = "dgvApplicationTypes";
        //    this.dgvApplicationTypes.ReadOnly = true;
        //    dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        //    dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
        //    dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        //    dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
        //    dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        //    dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        //    dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        //    this.dgvApplicationTypes.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
        //    this.dgvApplicationTypes.RowHeadersWidth = 62;
        //    this.dgvApplicationTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        //    this.dgvApplicationTypes.Size = new System.Drawing.Size(679, 354);
        //    this.dgvApplicationTypes.TabIndex = 113;
        //    this.dgvApplicationTypes.TabStop = false;
        //    this.dgvApplicationTypes.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvApplicationTypes_CellMouseDown_1);
        //    // 
        //    // cmsApplicationTypes
        //    // 
        //    this.cmsApplicationTypes.ImageScalingSize = new System.Drawing.Size(24, 24);
        //    this.cmsApplicationTypes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        //    this.toolStripSeparator2,
        //    this.editToolStripMenuItem,
        //    this.toolStripSeparator1});
        //    this.cmsApplicationTypes.Name = "contextMenuStrip1";
        //    this.cmsApplicationTypes.Size = new System.Drawing.Size(268, 89);
        //    // 
        //    // toolStripSeparator2
        //    // 
        //    this.toolStripSeparator2.Name = "toolStripSeparator2";
        //    this.toolStripSeparator2.Size = new System.Drawing.Size(264, 6);
        //    // 
        //    // editToolStripMenuItem
        //    // 
        //    this.editToolStripMenuItem.Image = global::Create_DVLD.Properties.Resources.edit_32;
        //    this.editToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        //    this.editToolStripMenuItem.Name = "editToolStripMenuItem";
        //    this.editToolStripMenuItem.Size = new System.Drawing.Size(267, 40);
        //    this.editToolStripMenuItem.Text = "&Edit Application Type";
        //    this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
        //    // 
        //    // toolStripSeparator1
        //    // 
        //    this.toolStripSeparator1.Name = "toolStripSeparator1";
        //    this.toolStripSeparator1.Size = new System.Drawing.Size(264, 6);
        //    // 
        //    // frmManageApplicationTypes
        //    // 
        //    this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
        //    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //    this.ClientSize = new System.Drawing.Size(735, 708);
        //    this.Controls.Add(this.btnClose);
        //    this.Controls.Add(this.lblTitle);
        //    this.Controls.Add(this.pbApplicationTypesmage);
        //    this.Controls.Add(this.lblRecordsCount);
        //    this.Controls.Add(this.label2);
        //    this.Controls.Add(this.dgvApplicationTypes);
        //    this.Name = "frmManageApplicationTypes";
        //    this.Text = "frmManageApplicationTypes";
        //    this.Load += new System.EventHandler(this.frmManageApplicationTypes_Load);
        //    ((System.ComponentModel.ISupportInitialize)(this.pbApplicationTypesmage)).EndInit();
        //    ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationTypes)).EndInit();
        //    this.cmsApplicationTypes.ResumeLayout(false);
        //    this.ResumeLayout(false);
        //    this.PerformLayout();



        //}
        //private void InitializeComponent()
        //{
        //    this.components = new System.ComponentModel.Container();

        //    // 1. تعريف الكنترولز (لازم يكونوا موجودين في الفورم)
        //    this.pnlSidebar = new System.Windows.Forms.Panel();
        //    this.pnlMain = new System.Windows.Forms.Panel();
        //    this.lblTitle = new System.Windows.Forms.Label();
        //    this.pbApplicationTypesmage = new System.Windows.Forms.PictureBox();
        //    this.lblRecordsCount = new System.Windows.Forms.Label();
        //    this.label2 = new System.Windows.Forms.Label();
        //    this.dgvApplicationTypes = new System.Windows.Forms.DataGridView();
        //    this.btnClose = new System.Windows.Forms.Button();
        //    this.cmsApplicationTypes = new System.Windows.Forms.ContextMenuStrip(this.components);

        //    this.pnlSidebar.SuspendLayout();
        //    this.pnlMain.SuspendLayout();
        //    ((System.ComponentModel.ISupportInitialize)(this.pbApplicationTypesmage)).BeginInit();
        //    ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationTypes)).BeginInit();
        //    this.SuspendLayout();

        //    // 
        //    // pnlSidebar
        //    // 
        //    this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(44, 54, 79);
        //    this.pnlSidebar.Controls.Add(this.pbApplicationTypesmage);
        //    this.pnlSidebar.Controls.Add(this.lblTitle);
        //    this.pnlSidebar.Controls.Add(this.label2);
        //    this.pnlSidebar.Controls.Add(this.lblRecordsCount);
        //    this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
        //    this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
        //    this.pnlSidebar.Name = "pnlSidebar";
        //    this.pnlSidebar.Size = new System.Drawing.Size(280, 720);

        //    // pbApplicationTypesmage
        //    this.pbApplicationTypesmage.Image = global::Create_DVLD.Properties.Resources.Application_Types_5121;
        //    this.pbApplicationTypesmage.Location = new System.Drawing.Point(65, 45);
        //    this.pbApplicationTypesmage.Size = new System.Drawing.Size(150, 150);
        //    this.pbApplicationTypesmage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

        //    // lblTitle
        //    this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
        //    this.lblTitle.ForeColor = System.Drawing.Color.White;
        //    this.lblTitle.Location = new System.Drawing.Point(10, 210);
        //    this.lblTitle.Size = new System.Drawing.Size(260, 100);
        //    this.lblTitle.Text = "Manage Application Types";
        //    this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        //    // label2 & lblRecordsCount (التنسيق في أسفل السايدبار)
        //    this.label2.ForeColor = System.Drawing.Color.Silver;
        //    this.label2.Location = new System.Drawing.Point(25, 660);
        //    this.label2.Text = "Records:";
        //    this.label2.AutoSize = true;
        //    this.lblRecordsCount.ForeColor = System.Drawing.Color.White;
        //    this.lblRecordsCount.Location = new System.Drawing.Point(110, 660);
        //    this.lblRecordsCount.Text = "??";

        //    // 
        //    // pnlMain
        //    // 
        //    this.pnlMain.BackColor = System.Drawing.Color.White;
        //    this.pnlMain.Controls.Add(this.dgvApplicationTypes);
        //    this.pnlMain.Controls.Add(this.btnClose);
        //    this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
        //    this.pnlMain.Location = new System.Drawing.Point(280, 0);
        //    this.pnlMain.Padding = new System.Windows.Forms.Padding(20);

        //    // dgvApplicationTypes
        //    this.dgvApplicationTypes.BackgroundColor = System.Drawing.Color.WhiteSmoke;
        //    this.dgvApplicationTypes.BorderStyle = System.Windows.Forms.BorderStyle.None;
        //    this.dgvApplicationTypes.Dock = System.Windows.Forms.DockStyle.Top;
        //    this.dgvApplicationTypes.Location = new System.Drawing.Point(20, 20);
        //    this.dgvApplicationTypes.Size = new System.Drawing.Size(650, 580);
        //    this.dgvApplicationTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

        //    // btnClose
        //    this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        //    this.btnClose.BackColor = System.Drawing.Color.FromArgb(44, 54, 79);
        //    this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        //    this.btnClose.ForeColor = System.Drawing.Color.White;
        //    this.btnClose.Location = new System.Drawing.Point(520, 650);
        //    this.btnClose.Size = new System.Drawing.Size(130, 40);
        //    this.btnClose.Text = "Close";
        //    this.btnClose.UseVisualStyleBackColor = false;
        //    this.btnClose.Click += new System.EventHandler(this.btnClose_Click);

        //    // 
        //    // frmManageApplicationTypes Setup
        //    // 
        //    this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
        //    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //    this.ClientSize = new System.Drawing.Size(950, 720);
        //    this.Controls.Add(this.pnlMain);
        //    this.Controls.Add(this.pnlSidebar);
        //    this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        //    this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        //    this.Text = "DVLD - Application Types";
        //    this.Load += new System.EventHandler(this.frmManageApplicationTypes_Load);

        //    this.pnlSidebar.ResumeLayout(false);
        //    this.pnlSidebar.PerformLayout();
        //    this.pnlMain.ResumeLayout(false);
        //    ((System.ComponentModel.ISupportInitialize)(this.pbApplicationTypesmage)).EndInit();
        //    ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationTypes)).EndInit();
        //    this.ResumeLayout(false);
        //}


        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmManageApplicationTypes));
            this.cmsApplicationTypes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pbApplicationTypesmage = new System.Windows.Forms.PictureBox();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvApplicationTypes = new System.Windows.Forms.DataGridView();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.cmsApplicationTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbApplicationTypesmage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // cmsApplicationTypes
            // 
            this.cmsApplicationTypes.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmsApplicationTypes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.editToolStripMenuItem,
            this.toolStripSeparator1});
            this.cmsApplicationTypes.Name = "contextMenuStrip1";
            this.cmsApplicationTypes.Size = new System.Drawing.Size(268, 56);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(264, 6);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = global::Create_DVLD.Properties.Resources.edit_32;
            this.editToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(267, 40);
            this.editToolStripMenuItem.Text = "&Edit Application Type";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(264, 6);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTitle.Location = new System.Drawing.Point(29, 208);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(644, 55);
            this.lblTitle.TabIndex = 117;
            this.lblTitle.Text = "Manage Application Types";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbApplicationTypesmage
            // 
            this.pbApplicationTypesmage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbApplicationTypesmage.Image = global::Create_DVLD.Properties.Resources.Application_Types_5122;
            this.pbApplicationTypesmage.InitialImage = null;
            this.pbApplicationTypesmage.Location = new System.Drawing.Point(251, 14);
            this.pbApplicationTypesmage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbApplicationTypesmage.Name = "pbApplicationTypesmage";
            this.pbApplicationTypesmage.Size = new System.Drawing.Size(220, 189);
            this.pbApplicationTypesmage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbApplicationTypesmage.TabIndex = 116;
            this.pbApplicationTypesmage.TabStop = false;
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.AutoSize = true;
            this.lblRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsCount.Location = new System.Drawing.Point(101, 635);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(27, 20);
            this.lblRecordsCount.TabIndex = 115;
            this.lblRecordsCount.Text = "??";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 635);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 114;
            this.label2.Text = "# Records:";
            // 
            // dgvApplicationTypes
            // 
            this.dgvApplicationTypes.AllowUserToAddRows = false;
            this.dgvApplicationTypes.AllowUserToDeleteRows = false;
            this.dgvApplicationTypes.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.dgvApplicationTypes.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvApplicationTypes.BackgroundColor = System.Drawing.Color.White;
            this.dgvApplicationTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvApplicationTypes.ContextMenuStrip = this.cmsApplicationTypes;
            this.dgvApplicationTypes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvApplicationTypes.Location = new System.Drawing.Point(13, 273);
            this.dgvApplicationTypes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvApplicationTypes.MultiSelect = false;
            this.dgvApplicationTypes.Name = "dgvApplicationTypes";
            this.dgvApplicationTypes.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvApplicationTypes.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvApplicationTypes.RowHeadersWidth = 62;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.dgvApplicationTypes.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvApplicationTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvApplicationTypes.Size = new System.Drawing.Size(679, 354);
            this.dgvApplicationTypes.TabIndex = 113;
            this.dgvApplicationTypes.TabStop = false;
            this.dgvApplicationTypes.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvApplicationTypes_CellMouseDown_1);
            // 
            // btnClose
            // 
            this.btnClose.BorderRadius = 15;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(561, 635);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(131, 53);
            this.btnClose.TabIndex = 216;
            this.btnClose.Text = "Close ❌ ";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // frmManageApplicationTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(710, 694);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pbApplicationTypesmage);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvApplicationTypes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmManageApplicationTypes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DVLD - Manage Application Types";
            this.Load += new System.EventHandler(this.frmManageApplicationTypes_Load);
            this.cmsApplicationTypes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbApplicationTypesmage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvApplicationTypes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

        //// أضف هذه التعريفات في أسفل ملف الديزاينر مع الـ Variables
        //private System.Windows.Forms.Panel pnlSidebar;
        //private System.Windows.Forms.Panel pnlMain;

        #endregion
        private ContextMenuStrip cmsApplicationTypes;
        //private ToolStripSeparator toolStripSeparator2;
        //private ToolStripMenuItem editToolStripMenuItem;
        //private ToolStripSeparator toolStripSeparator1;
        private Panel panel2;
        private Panel panel1;
        private Label lblTitle;
        private PictureBox pbApplicationTypesmage;
        private Label lblRecordsCount;
        private Label label2;
        private DataGridView dgvApplicationTypes;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        /////////////////////////////
        ///// أضف هذه الأسطر في نهاية ملف الديزاينر قبل إغلاق القوس الأخير
        //private System.Windows.Forms.Panel pnlSidebar;
        //private System.Windows.Forms.Panel pnlMain;
        //private System.Windows.Forms.Label lblTitle;
        //private System.Windows.Forms.PictureBox pbApplicationTypesmage;
        //private System.Windows.Forms.Label lblRecordsCount;
        //private System.Windows.Forms.Label label2;
        //private System.Windows.Forms.DataGridView dgvApplicationTypes;
        //private System.Windows.Forms.Button btnClose;
        //private System.Windows.Forms.ContextMenuStrip cmsApplicationTypes;
        //private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        //private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        //private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}