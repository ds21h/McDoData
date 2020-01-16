namespace McDoData
{
    partial class FrmMain
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
            this.BtnNL = new System.Windows.Forms.Button();
            this.DgrdResult = new System.Windows.Forms.DataGridView();
            this.PnlControl = new System.Windows.Forms.Panel();
            this.BtnBE = new System.Windows.Forms.Button();
            this.PnlResult = new System.Windows.Forms.Panel();
            this.ClmID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmDescr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmPostalCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmLongitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmLatitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmMonday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmMondayDrive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmTuesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmTuesdayDrive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmWednesday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmWednesdayDrive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmThursday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmThursdayDrive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmFriday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmFridayDrive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmSaturday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmSaturdayDrive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmSunday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClmSundayDrive = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DgrdResult)).BeginInit();
            this.PnlControl.SuspendLayout();
            this.PnlResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnNL
            // 
            this.BtnNL.Location = new System.Drawing.Point(12, 12);
            this.BtnNL.Name = "BtnNL";
            this.BtnNL.Size = new System.Drawing.Size(75, 23);
            this.BtnNL.TabIndex = 0;
            this.BtnNL.Text = "NL";
            this.BtnNL.UseVisualStyleBackColor = true;
            this.BtnNL.Click += new System.EventHandler(this.BtnNL_Click);
            // 
            // DgrdResult
            // 
            this.DgrdResult.AllowUserToAddRows = false;
            this.DgrdResult.AllowUserToDeleteRows = false;
            this.DgrdResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgrdResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ClmID,
            this.ClmName,
            this.ClmDescr,
            this.ClmAddress,
            this.ClmPostalCode,
            this.ClmCity,
            this.ClmLongitude,
            this.ClmLatitude,
            this.ClmMonday,
            this.ClmMondayDrive,
            this.ClmTuesday,
            this.ClmTuesdayDrive,
            this.ClmWednesday,
            this.ClmWednesdayDrive,
            this.ClmThursday,
            this.ClmThursdayDrive,
            this.ClmFriday,
            this.ClmFridayDrive,
            this.ClmSaturday,
            this.ClmSaturdayDrive,
            this.ClmSunday,
            this.ClmSundayDrive});
            this.DgrdResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgrdResult.Location = new System.Drawing.Point(0, 0);
            this.DgrdResult.Name = "DgrdResult";
            this.DgrdResult.ReadOnly = true;
            this.DgrdResult.Size = new System.Drawing.Size(1090, 579);
            this.DgrdResult.TabIndex = 1;
            this.DgrdResult.VirtualMode = true;
            this.DgrdResult.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.DgrdResult_CellValueNeeded);
            // 
            // PnlControl
            // 
            this.PnlControl.Controls.Add(this.BtnBE);
            this.PnlControl.Controls.Add(this.BtnNL);
            this.PnlControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlControl.Location = new System.Drawing.Point(0, 579);
            this.PnlControl.Name = "PnlControl";
            this.PnlControl.Size = new System.Drawing.Size(1090, 46);
            this.PnlControl.TabIndex = 2;
            // 
            // BtnBE
            // 
            this.BtnBE.Location = new System.Drawing.Point(93, 12);
            this.BtnBE.Name = "BtnBE";
            this.BtnBE.Size = new System.Drawing.Size(75, 23);
            this.BtnBE.TabIndex = 1;
            this.BtnBE.Text = "BE";
            this.BtnBE.UseVisualStyleBackColor = true;
            this.BtnBE.Click += new System.EventHandler(this.BtnBE_Click);
            // 
            // PnlResult
            // 
            this.PnlResult.Controls.Add(this.DgrdResult);
            this.PnlResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlResult.Location = new System.Drawing.Point(0, 0);
            this.PnlResult.Name = "PnlResult";
            this.PnlResult.Size = new System.Drawing.Size(1090, 579);
            this.PnlResult.TabIndex = 3;
            // 
            // ClmID
            // 
            this.ClmID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ClmID.HeaderText = "ID";
            this.ClmID.Name = "ClmID";
            this.ClmID.ReadOnly = true;
            this.ClmID.Width = 43;
            // 
            // ClmName
            // 
            this.ClmName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ClmName.HeaderText = "Name";
            this.ClmName.Name = "ClmName";
            this.ClmName.ReadOnly = true;
            this.ClmName.Width = 60;
            // 
            // ClmDescr
            // 
            this.ClmDescr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ClmDescr.HeaderText = "Descr";
            this.ClmDescr.Name = "ClmDescr";
            this.ClmDescr.ReadOnly = true;
            this.ClmDescr.Width = 60;
            // 
            // ClmAddress
            // 
            this.ClmAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ClmAddress.HeaderText = "Address";
            this.ClmAddress.Name = "ClmAddress";
            this.ClmAddress.ReadOnly = true;
            this.ClmAddress.Width = 70;
            // 
            // ClmPostalCode
            // 
            this.ClmPostalCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ClmPostalCode.HeaderText = "Postal Code";
            this.ClmPostalCode.Name = "ClmPostalCode";
            this.ClmPostalCode.ReadOnly = true;
            this.ClmPostalCode.Width = 89;
            // 
            // ClmCity
            // 
            this.ClmCity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ClmCity.HeaderText = "City";
            this.ClmCity.Name = "ClmCity";
            this.ClmCity.ReadOnly = true;
            this.ClmCity.Width = 49;
            // 
            // ClmLongitude
            // 
            this.ClmLongitude.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ClmLongitude.HeaderText = "Longitude";
            this.ClmLongitude.Name = "ClmLongitude";
            this.ClmLongitude.ReadOnly = true;
            this.ClmLongitude.Width = 79;
            // 
            // ClmLatitude
            // 
            this.ClmLatitude.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ClmLatitude.HeaderText = "Latitude";
            this.ClmLatitude.Name = "ClmLatitude";
            this.ClmLatitude.ReadOnly = true;
            this.ClmLatitude.Width = 70;
            // 
            // ClmMonday
            // 
            this.ClmMonday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ClmMonday.HeaderText = "Monday";
            this.ClmMonday.Name = "ClmMonday";
            this.ClmMonday.ReadOnly = true;
            this.ClmMonday.Width = 70;
            // 
            // ClmMondayDrive
            // 
            this.ClmMondayDrive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ClmMondayDrive.HeaderText = "Drive";
            this.ClmMondayDrive.Name = "ClmMondayDrive";
            this.ClmMondayDrive.ReadOnly = true;
            this.ClmMondayDrive.Width = 57;
            // 
            // ClmTuesday
            // 
            this.ClmTuesday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ClmTuesday.HeaderText = "Tuesday";
            this.ClmTuesday.Name = "ClmTuesday";
            this.ClmTuesday.ReadOnly = true;
            this.ClmTuesday.Width = 73;
            // 
            // ClmTuesdayDrive
            // 
            this.ClmTuesdayDrive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ClmTuesdayDrive.HeaderText = "Drive";
            this.ClmTuesdayDrive.Name = "ClmTuesdayDrive";
            this.ClmTuesdayDrive.ReadOnly = true;
            this.ClmTuesdayDrive.Width = 57;
            // 
            // ClmWednesday
            // 
            this.ClmWednesday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ClmWednesday.HeaderText = "Wednesday";
            this.ClmWednesday.Name = "ClmWednesday";
            this.ClmWednesday.ReadOnly = true;
            this.ClmWednesday.Width = 89;
            // 
            // ClmWednesdayDrive
            // 
            this.ClmWednesdayDrive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ClmWednesdayDrive.HeaderText = "Drive";
            this.ClmWednesdayDrive.Name = "ClmWednesdayDrive";
            this.ClmWednesdayDrive.ReadOnly = true;
            this.ClmWednesdayDrive.Width = 57;
            // 
            // ClmThursday
            // 
            this.ClmThursday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ClmThursday.HeaderText = "Thursday";
            this.ClmThursday.Name = "ClmThursday";
            this.ClmThursday.ReadOnly = true;
            this.ClmThursday.Width = 76;
            // 
            // ClmThursdayDrive
            // 
            this.ClmThursdayDrive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ClmThursdayDrive.HeaderText = "Drive";
            this.ClmThursdayDrive.Name = "ClmThursdayDrive";
            this.ClmThursdayDrive.ReadOnly = true;
            this.ClmThursdayDrive.Width = 57;
            // 
            // ClmFriday
            // 
            this.ClmFriday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ClmFriday.HeaderText = "Friday";
            this.ClmFriday.Name = "ClmFriday";
            this.ClmFriday.ReadOnly = true;
            this.ClmFriday.Width = 60;
            // 
            // ClmFridayDrive
            // 
            this.ClmFridayDrive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ClmFridayDrive.HeaderText = "Drive";
            this.ClmFridayDrive.Name = "ClmFridayDrive";
            this.ClmFridayDrive.ReadOnly = true;
            this.ClmFridayDrive.Width = 57;
            // 
            // ClmSaturday
            // 
            this.ClmSaturday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ClmSaturday.HeaderText = "Saturday";
            this.ClmSaturday.Name = "ClmSaturday";
            this.ClmSaturday.ReadOnly = true;
            this.ClmSaturday.Width = 74;
            // 
            // ClmSaturdayDrive
            // 
            this.ClmSaturdayDrive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ClmSaturdayDrive.HeaderText = "Drive";
            this.ClmSaturdayDrive.Name = "ClmSaturdayDrive";
            this.ClmSaturdayDrive.ReadOnly = true;
            this.ClmSaturdayDrive.Width = 57;
            // 
            // ClmSunday
            // 
            this.ClmSunday.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ClmSunday.HeaderText = "Sunday";
            this.ClmSunday.Name = "ClmSunday";
            this.ClmSunday.ReadOnly = true;
            this.ClmSunday.Width = 68;
            // 
            // ClmSundayDrive
            // 
            this.ClmSundayDrive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ClmSundayDrive.HeaderText = "Drive";
            this.ClmSundayDrive.Name = "ClmSundayDrive";
            this.ClmSundayDrive.ReadOnly = true;
            this.ClmSundayDrive.Width = 57;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 625);
            this.Controls.Add(this.PnlResult);
            this.Controls.Add(this.PnlControl);
            this.Name = "FrmMain";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DgrdResult)).EndInit();
            this.PnlControl.ResumeLayout(false);
            this.PnlResult.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnNL;
        private System.Windows.Forms.DataGridView DgrdResult;
        private System.Windows.Forms.Panel PnlControl;
        private System.Windows.Forms.Panel PnlResult;
        private System.Windows.Forms.Button BtnBE;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmDescr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmPostalCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmLongitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmLatitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmMonday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmMondayDrive;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmTuesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmTuesdayDrive;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmWednesday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmWednesdayDrive;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmThursday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmThursdayDrive;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmFriday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmFridayDrive;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmSaturday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmSaturdayDrive;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmSunday;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClmSundayDrive;
    }
}

