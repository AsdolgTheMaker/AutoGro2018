namespace AutoGro
{
    partial class F_Main
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Main));
            this.TB_DirWLD = new System.Windows.Forms.TextBox();
            this.BT_WldInput = new System.Windows.Forms.Button();
            this.TB_OutputName = new System.Windows.Forms.TextBox();
            this.LB_DirWLD = new System.Windows.Forms.Label();
            this.LB_OutputFN = new System.Windows.Forms.Label();
            this.BT_PackGro = new System.Windows.Forms.Button();
            this.OFD_WldInput = new System.Windows.Forms.OpenFileDialog();
            this.SFD_OutputFN = new System.Windows.Forms.SaveFileDialog();
            this.BT_OutputFN = new System.Windows.Forms.Button();
            this.GB_Settings = new System.Windows.Forms.GroupBox();
            this.BT_Help_Exceptions = new System.Windows.Forms.Button();
            this.BT_ExceptionsSettings = new System.Windows.Forms.Button();
            this.CB_Exceptions = new System.Windows.Forms.CheckBox();
            this.BT_Help_Gtitle = new System.Windows.Forms.Button();
            this.BT_Help_OtherWLDs = new System.Windows.Forms.Button();
            this.CB_OtherWLDs = new System.Windows.Forms.CheckBox();
            this.CB_Gtitle = new System.Windows.Forms.CheckBox();
            this.BT_ContentDir = new System.Windows.Forms.Button();
            this.LB_GameFolder = new System.Windows.Forms.Label();
            this.TB_GamePath = new System.Windows.Forms.TextBox();
            this.FBD_ContentDir = new System.Windows.Forms.FolderBrowserDialog();
            this.RTB_Log = new System.Windows.Forms.RichTextBox();
            this.BT_Log_Clear = new System.Windows.Forms.Button();
            this.BT_Exit = new System.Windows.Forms.Button();
            this.CB_Autodetection = new System.Windows.Forms.CheckBox();
            this.BT_Help_Autodetection = new System.Windows.Forms.Button();
            this.BT_Update = new System.Windows.Forms.Button();
            this.PB_Process = new System.Windows.Forms.ProgressBar();
            this.LB_CurrentState = new System.Windows.Forms.Label();
            this.GB_Settings.SuspendLayout();
            this.SuspendLayout();
            // 
            // TB_DirWLD
            // 
            this.TB_DirWLD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_DirWLD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TB_DirWLD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_DirWLD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TB_DirWLD.Location = new System.Drawing.Point(15, 34);
            this.TB_DirWLD.Name = "TB_DirWLD";
            this.TB_DirWLD.Size = new System.Drawing.Size(718, 20);
            this.TB_DirWLD.TabIndex = 0;
            // 
            // BT_WldInput
            // 
            this.BT_WldInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_WldInput.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.BT_WldInput.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BT_WldInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_WldInput.Location = new System.Drawing.Point(739, 32);
            this.BT_WldInput.Name = "BT_WldInput";
            this.BT_WldInput.Size = new System.Drawing.Size(75, 23);
            this.BT_WldInput.TabIndex = 1;
            this.BT_WldInput.Text = "Browse";
            this.BT_WldInput.UseVisualStyleBackColor = true;
            this.BT_WldInput.Click += new System.EventHandler(this.BT_WldInput_Click);
            // 
            // TB_OutputName
            // 
            this.TB_OutputName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_OutputName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TB_OutputName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_OutputName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TB_OutputName.Location = new System.Drawing.Point(15, 112);
            this.TB_OutputName.Name = "TB_OutputName";
            this.TB_OutputName.Size = new System.Drawing.Size(718, 20);
            this.TB_OutputName.TabIndex = 2;
            // 
            // LB_DirWLD
            // 
            this.LB_DirWLD.AutoSize = true;
            this.LB_DirWLD.Location = new System.Drawing.Point(27, 18);
            this.LB_DirWLD.Name = "LB_DirWLD";
            this.LB_DirWLD.Size = new System.Drawing.Size(79, 13);
            this.LB_DirWLD.TabIndex = 3;
            this.LB_DirWLD.Text = "Select input file";
            // 
            // LB_OutputFN
            // 
            this.LB_OutputFN.AutoSize = true;
            this.LB_OutputFN.Location = new System.Drawing.Point(27, 96);
            this.LB_OutputFN.Name = "LB_OutputFN";
            this.LB_OutputFN.Size = new System.Drawing.Size(79, 13);
            this.LB_OutputFN.TabIndex = 4;
            this.LB_OutputFN.Text = "Output file path";
            // 
            // BT_PackGro
            // 
            this.BT_PackGro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_PackGro.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BT_PackGro.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BT_PackGro.FlatAppearance.MouseOverBackColor = System.Drawing.Color.ForestGreen;
            this.BT_PackGro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_PackGro.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BT_PackGro.Location = new System.Drawing.Point(374, 194);
            this.BT_PackGro.Name = "BT_PackGro";
            this.BT_PackGro.Size = new System.Drawing.Size(440, 50);
            this.BT_PackGro.TabIndex = 5;
            this.BT_PackGro.Text = "Start packing";
            this.BT_PackGro.UseVisualStyleBackColor = true;
            this.BT_PackGro.Click += new System.EventHandler(this.BT_PackGro_Click);
            // 
            // OFD_WldInput
            // 
            this.OFD_WldInput.DefaultExt = "wld";
            this.OFD_WldInput.Filter = "Serious Engine levels|*.wld|Serious Engine models|*.mdl|All files|*.*";
            this.OFD_WldInput.Title = "Choose file to analyze";
            // 
            // SFD_OutputFN
            // 
            this.SFD_OutputFN.DefaultExt = "gro";
            this.SFD_OutputFN.Filter = "SED package files|*.gro";
            this.SFD_OutputFN.Title = "Choose output .gro file path";
            // 
            // BT_OutputFN
            // 
            this.BT_OutputFN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_OutputFN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.BT_OutputFN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BT_OutputFN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_OutputFN.Location = new System.Drawing.Point(739, 110);
            this.BT_OutputFN.Name = "BT_OutputFN";
            this.BT_OutputFN.Size = new System.Drawing.Size(75, 23);
            this.BT_OutputFN.TabIndex = 6;
            this.BT_OutputFN.Text = "Browse";
            this.BT_OutputFN.UseVisualStyleBackColor = true;
            this.BT_OutputFN.Click += new System.EventHandler(this.BT_OutputFN_Click);
            // 
            // GB_Settings
            // 
            this.GB_Settings.Controls.Add(this.BT_Help_Exceptions);
            this.GB_Settings.Controls.Add(this.BT_ExceptionsSettings);
            this.GB_Settings.Controls.Add(this.CB_Exceptions);
            this.GB_Settings.Controls.Add(this.BT_Help_Gtitle);
            this.GB_Settings.Controls.Add(this.BT_Help_OtherWLDs);
            this.GB_Settings.Controls.Add(this.CB_OtherWLDs);
            this.GB_Settings.Controls.Add(this.CB_Gtitle);
            this.GB_Settings.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.GB_Settings.Location = new System.Drawing.Point(15, 152);
            this.GB_Settings.Name = "GB_Settings";
            this.GB_Settings.Size = new System.Drawing.Size(318, 92);
            this.GB_Settings.TabIndex = 7;
            this.GB_Settings.TabStop = false;
            this.GB_Settings.Text = "Optional settings";
            // 
            // BT_Help_Exceptions
            // 
            this.BT_Help_Exceptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_Help_Exceptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Help_Exceptions.ForeColor = System.Drawing.Color.Silver;
            this.BT_Help_Exceptions.Location = new System.Drawing.Point(6, 62);
            this.BT_Help_Exceptions.Name = "BT_Help_Exceptions";
            this.BT_Help_Exceptions.Size = new System.Drawing.Size(17, 23);
            this.BT_Help_Exceptions.TabIndex = 21;
            this.BT_Help_Exceptions.Text = "?";
            this.BT_Help_Exceptions.UseVisualStyleBackColor = true;
            this.BT_Help_Exceptions.Click += new System.EventHandler(this.BT_Help_Exceptions_Click);
            // 
            // BT_ExceptionsSettings
            // 
            this.BT_ExceptionsSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.BT_ExceptionsSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BT_ExceptionsSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_ExceptionsSettings.Location = new System.Drawing.Point(202, 62);
            this.BT_ExceptionsSettings.Name = "BT_ExceptionsSettings";
            this.BT_ExceptionsSettings.Size = new System.Drawing.Size(110, 22);
            this.BT_ExceptionsSettings.TabIndex = 20;
            this.BT_ExceptionsSettings.Text = "Tune exceptions...";
            this.BT_ExceptionsSettings.UseVisualStyleBackColor = true;
            this.BT_ExceptionsSettings.Click += new System.EventHandler(this.BT_ExceptionsSettings_Click);
            // 
            // CB_Exceptions
            // 
            this.CB_Exceptions.AutoSize = true;
            this.CB_Exceptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.CB_Exceptions.Checked = true;
            this.CB_Exceptions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_Exceptions.FlatAppearance.CheckedBackColor = System.Drawing.Color.Green;
            this.CB_Exceptions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.CB_Exceptions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CB_Exceptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_Exceptions.Location = new System.Drawing.Point(29, 66);
            this.CB_Exceptions.Name = "CB_Exceptions";
            this.CB_Exceptions.Size = new System.Drawing.Size(136, 17);
            this.CB_Exceptions.TabIndex = 19;
            this.CB_Exceptions.Text = "Do not pack exceptions";
            this.CB_Exceptions.UseVisualStyleBackColor = false;
            this.CB_Exceptions.CheckedChanged += new System.EventHandler(this.CB_Exceptions_CheckedChanged);
            // 
            // BT_Help_Gtitle
            // 
            this.BT_Help_Gtitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_Help_Gtitle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.BT_Help_Gtitle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BT_Help_Gtitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Help_Gtitle.ForeColor = System.Drawing.Color.Silver;
            this.BT_Help_Gtitle.Location = new System.Drawing.Point(6, 16);
            this.BT_Help_Gtitle.Name = "BT_Help_Gtitle";
            this.BT_Help_Gtitle.Size = new System.Drawing.Size(17, 23);
            this.BT_Help_Gtitle.TabIndex = 17;
            this.BT_Help_Gtitle.Text = "?";
            this.BT_Help_Gtitle.UseVisualStyleBackColor = true;
            this.BT_Help_Gtitle.Click += new System.EventHandler(this.BT_Help_Gtitle_Click);
            // 
            // BT_Help_OtherWLDs
            // 
            this.BT_Help_OtherWLDs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_Help_OtherWLDs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Help_OtherWLDs.ForeColor = System.Drawing.Color.Silver;
            this.BT_Help_OtherWLDs.Location = new System.Drawing.Point(6, 39);
            this.BT_Help_OtherWLDs.Name = "BT_Help_OtherWLDs";
            this.BT_Help_OtherWLDs.Size = new System.Drawing.Size(17, 23);
            this.BT_Help_OtherWLDs.TabIndex = 16;
            this.BT_Help_OtherWLDs.Text = "?";
            this.BT_Help_OtherWLDs.UseVisualStyleBackColor = true;
            this.BT_Help_OtherWLDs.Click += new System.EventHandler(this.BT_Help_OtherWLDs_Click);
            // 
            // CB_OtherWLDs
            // 
            this.CB_OtherWLDs.AutoSize = true;
            this.CB_OtherWLDs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.CB_OtherWLDs.FlatAppearance.CheckedBackColor = System.Drawing.Color.Green;
            this.CB_OtherWLDs.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.CB_OtherWLDs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CB_OtherWLDs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_OtherWLDs.Location = new System.Drawing.Point(29, 43);
            this.CB_OtherWLDs.Name = "CB_OtherWLDs";
            this.CB_OtherWLDs.Size = new System.Drawing.Size(190, 17);
            this.CB_OtherWLDs.TabIndex = 1;
            this.CB_OtherWLDs.Text = "Examine levels linked from selected";
            this.CB_OtherWLDs.UseVisualStyleBackColor = false;
            // 
            // CB_Gtitle
            // 
            this.CB_Gtitle.AutoSize = true;
            this.CB_Gtitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.CB_Gtitle.FlatAppearance.CheckedBackColor = System.Drawing.Color.Green;
            this.CB_Gtitle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.CB_Gtitle.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CB_Gtitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_Gtitle.Location = new System.Drawing.Point(30, 20);
            this.CB_Gtitle.Name = "CB_Gtitle";
            this.CB_Gtitle.Size = new System.Drawing.Size(159, 17);
            this.CB_Gtitle.TabIndex = 0;
            this.CB_Gtitle.Text = "Pack .gtitle and its resources";
            this.CB_Gtitle.UseVisualStyleBackColor = false;
            // 
            // BT_ContentDir
            // 
            this.BT_ContentDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_ContentDir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.BT_ContentDir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BT_ContentDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_ContentDir.Location = new System.Drawing.Point(739, 71);
            this.BT_ContentDir.Name = "BT_ContentDir";
            this.BT_ContentDir.Size = new System.Drawing.Size(75, 23);
            this.BT_ContentDir.TabIndex = 10;
            this.BT_ContentDir.Text = "Browse";
            this.BT_ContentDir.UseVisualStyleBackColor = true;
            this.BT_ContentDir.Click += new System.EventHandler(this.BT_ContentDir_Click);
            // 
            // LB_GameFolder
            // 
            this.LB_GameFolder.AutoSize = true;
            this.LB_GameFolder.Location = new System.Drawing.Point(27, 57);
            this.LB_GameFolder.Name = "LB_GameFolder";
            this.LB_GameFolder.Size = new System.Drawing.Size(64, 13);
            this.LB_GameFolder.TabIndex = 9;
            this.LB_GameFolder.Text = "Game folder";
            // 
            // TB_GamePath
            // 
            this.TB_GamePath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_GamePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TB_GamePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_GamePath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TB_GamePath.Location = new System.Drawing.Point(15, 73);
            this.TB_GamePath.Name = "TB_GamePath";
            this.TB_GamePath.Size = new System.Drawing.Size(718, 20);
            this.TB_GamePath.TabIndex = 8;
            // 
            // RTB_Log
            // 
            this.RTB_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTB_Log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RTB_Log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.RTB_Log.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.RTB_Log.Location = new System.Drawing.Point(15, 250);
            this.RTB_Log.MaxLength = 10000;
            this.RTB_Log.Name = "RTB_Log";
            this.RTB_Log.ReadOnly = true;
            this.RTB_Log.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.RTB_Log.Size = new System.Drawing.Size(799, 153);
            this.RTB_Log.TabIndex = 11;
            this.RTB_Log.Text = "";
            // 
            // BT_Log_Clear
            // 
            this.BT_Log_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BT_Log_Clear.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.BT_Log_Clear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.BT_Log_Clear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BT_Log_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Log_Clear.Location = new System.Drawing.Point(15, 409);
            this.BT_Log_Clear.Name = "BT_Log_Clear";
            this.BT_Log_Clear.Size = new System.Drawing.Size(70, 23);
            this.BT_Log_Clear.TabIndex = 13;
            this.BT_Log_Clear.Text = "Clear";
            this.BT_Log_Clear.UseVisualStyleBackColor = true;
            this.BT_Log_Clear.Click += new System.EventHandler(this.BT_Log_Clear_Click);
            // 
            // BT_Exit
            // 
            this.BT_Exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_Exit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BT_Exit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.BT_Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Exit.Location = new System.Drawing.Point(730, 409);
            this.BT_Exit.Name = "BT_Exit";
            this.BT_Exit.Size = new System.Drawing.Size(75, 23);
            this.BT_Exit.TabIndex = 14;
            this.BT_Exit.Text = "Exit";
            this.BT_Exit.UseVisualStyleBackColor = true;
            this.BT_Exit.Click += new System.EventHandler(this.BT_Exit_Click);
            // 
            // CB_Autodetection
            // 
            this.CB_Autodetection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_Autodetection.AutoSize = true;
            this.CB_Autodetection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.CB_Autodetection.Checked = true;
            this.CB_Autodetection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_Autodetection.FlatAppearance.CheckedBackColor = System.Drawing.Color.Green;
            this.CB_Autodetection.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.CB_Autodetection.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.CB_Autodetection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_Autodetection.Location = new System.Drawing.Point(668, 9);
            this.CB_Autodetection.Name = "CB_Autodetection";
            this.CB_Autodetection.Size = new System.Drawing.Size(124, 17);
            this.CB_Autodetection.TabIndex = 18;
            this.CB_Autodetection.Text = "Enable autodetection";
            this.CB_Autodetection.UseVisualStyleBackColor = false;
            // 
            // BT_Help_Autodetection
            // 
            this.BT_Help_Autodetection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_Help_Autodetection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Help_Autodetection.ForeColor = System.Drawing.Color.Silver;
            this.BT_Help_Autodetection.Location = new System.Drawing.Point(790, 5);
            this.BT_Help_Autodetection.Name = "BT_Help_Autodetection";
            this.BT_Help_Autodetection.Size = new System.Drawing.Size(17, 23);
            this.BT_Help_Autodetection.TabIndex = 19;
            this.BT_Help_Autodetection.Text = "?";
            this.BT_Help_Autodetection.UseVisualStyleBackColor = true;
            this.BT_Help_Autodetection.Click += new System.EventHandler(this.BT_Help_Autodetection_Click);
            // 
            // BT_Update
            // 
            this.BT_Update.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.BT_Update.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.BT_Update.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BT_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Update.Location = new System.Drawing.Point(364, 409);
            this.BT_Update.Name = "BT_Update";
            this.BT_Update.Size = new System.Drawing.Size(119, 23);
            this.BT_Update.TabIndex = 20;
            this.BT_Update.Text = "Check for updates";
            this.BT_Update.UseVisualStyleBackColor = true;
            this.BT_Update.Click += new System.EventHandler(this.BT_Update_Click);
            // 
            // PB_Process
            // 
            this.PB_Process.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PB_Process.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.PB_Process.Location = new System.Drawing.Point(374, 165);
            this.PB_Process.Name = "PB_Process";
            this.PB_Process.Size = new System.Drawing.Size(440, 23);
            this.PB_Process.TabIndex = 23;
            // 
            // LB_CurrentState
            // 
            this.LB_CurrentState.AutoSize = true;
            this.LB_CurrentState.Location = new System.Drawing.Point(381, 149);
            this.LB_CurrentState.Name = "LB_CurrentState";
            this.LB_CurrentState.Size = new System.Drawing.Size(96, 13);
            this.LB_CurrentState.TabIndex = 24;
            this.LB_CurrentState.Text = "PROCESS STATE";
            // 
            // F_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(828, 444);
            this.Controls.Add(this.LB_CurrentState);
            this.Controls.Add(this.PB_Process);
            this.Controls.Add(this.BT_Update);
            this.Controls.Add(this.BT_Help_Autodetection);
            this.Controls.Add(this.CB_Autodetection);
            this.Controls.Add(this.BT_Exit);
            this.Controls.Add(this.BT_Log_Clear);
            this.Controls.Add(this.RTB_Log);
            this.Controls.Add(this.BT_ContentDir);
            this.Controls.Add(this.LB_GameFolder);
            this.Controls.Add(this.TB_GamePath);
            this.Controls.Add(this.GB_Settings);
            this.Controls.Add(this.BT_OutputFN);
            this.Controls.Add(this.BT_PackGro);
            this.Controls.Add(this.LB_OutputFN);
            this.Controls.Add(this.LB_DirWLD);
            this.Controls.Add(this.TB_OutputName);
            this.Controls.Add(this.BT_WldInput);
            this.Controls.Add(this.TB_DirWLD);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(828, 444);
            this.Name = "F_Main";
            this.Text = "AutoGro 2018";
            this.GB_Settings.ResumeLayout(false);
            this.GB_Settings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TB_DirWLD;
        private System.Windows.Forms.Button BT_WldInput;
        private System.Windows.Forms.TextBox TB_OutputName;
        private System.Windows.Forms.Label LB_DirWLD;
        private System.Windows.Forms.Label LB_OutputFN;
        private System.Windows.Forms.Button BT_PackGro;
        private System.Windows.Forms.OpenFileDialog OFD_WldInput;
        private System.Windows.Forms.SaveFileDialog SFD_OutputFN;
        private System.Windows.Forms.Button BT_OutputFN;
        private System.Windows.Forms.GroupBox GB_Settings;
        private System.Windows.Forms.CheckBox CB_OtherWLDs;
        private System.Windows.Forms.CheckBox CB_Gtitle;
        private System.Windows.Forms.Button BT_ContentDir;
        private System.Windows.Forms.Label LB_GameFolder;
        private System.Windows.Forms.TextBox TB_GamePath;
        private System.Windows.Forms.FolderBrowserDialog FBD_ContentDir;
        private System.Windows.Forms.Button BT_Log_Clear;
        private System.Windows.Forms.Button BT_Exit;
        private System.Windows.Forms.Button BT_Help_Gtitle;
        private System.Windows.Forms.Button BT_Help_OtherWLDs;
        private System.Windows.Forms.CheckBox CB_Autodetection;
        private System.Windows.Forms.Button BT_Help_Autodetection;
        private System.Windows.Forms.Button BT_Update;
        private System.Windows.Forms.RichTextBox RTB_Log;
        private System.Windows.Forms.ProgressBar PB_Process;
        private System.Windows.Forms.Label LB_CurrentState;
        private System.Windows.Forms.Button BT_ExceptionsSettings;
        private System.Windows.Forms.CheckBox CB_Exceptions;
        private System.Windows.Forms.Button BT_Help_Exceptions;
    }
}

