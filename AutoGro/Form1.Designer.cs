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
            this.BT_Help_Workshop = new System.Windows.Forms.Button();
            this.BT_Help_Gtitle = new System.Windows.Forms.Button();
            this.BT_Help_OtherWLDs = new System.Windows.Forms.Button();
            this.CB_Workshop = new System.Windows.Forms.CheckBox();
            this.CB_OtherWLDs = new System.Windows.Forms.CheckBox();
            this.CB_Gtitle = new System.Windows.Forms.CheckBox();
            this.BT_ContentDir = new System.Windows.Forms.Button();
            this.LB_GameFolder = new System.Windows.Forms.Label();
            this.TB_GamePath = new System.Windows.Forms.TextBox();
            this.FBD_ContentDir = new System.Windows.Forms.FolderBrowserDialog();
            this.RTB_Log = new System.Windows.Forms.RichTextBox();
            this.BT_Log_Copy = new System.Windows.Forms.Button();
            this.BT_Log_Clear = new System.Windows.Forms.Button();
            this.BT_Exit = new System.Windows.Forms.Button();
            this.BT_Browse_Workshop = new System.Windows.Forms.Button();
            this.LB_Workshop = new System.Windows.Forms.Label();
            this.TB_WorkshopPath = new System.Windows.Forms.TextBox();
            this.CB_Autodetection = new System.Windows.Forms.CheckBox();
            this.BT_Help_Autodetection = new System.Windows.Forms.Button();
            this.BT_Update = new System.Windows.Forms.Button();
            this.BT_Log_Open = new System.Windows.Forms.Button();
            this.BT_Settings = new System.Windows.Forms.Button();
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
            this.TB_DirWLD.Location = new System.Drawing.Point(15, 34);
            this.TB_DirWLD.Name = "TB_DirWLD";
            this.TB_DirWLD.Size = new System.Drawing.Size(693, 20);
            this.TB_DirWLD.TabIndex = 0;
            // 
            // BT_WldInput
            // 
            this.BT_WldInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_WldInput.Location = new System.Drawing.Point(714, 32);
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
            this.TB_OutputName.Location = new System.Drawing.Point(15, 151);
            this.TB_OutputName.Name = "TB_OutputName";
            this.TB_OutputName.Size = new System.Drawing.Size(696, 20);
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
            this.LB_OutputFN.Location = new System.Drawing.Point(27, 135);
            this.LB_OutputFN.Name = "LB_OutputFN";
            this.LB_OutputFN.Size = new System.Drawing.Size(79, 13);
            this.LB_OutputFN.TabIndex = 4;
            this.LB_OutputFN.Text = "Output file path";
            // 
            // BT_PackGro
            // 
            this.BT_PackGro.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_PackGro.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BT_PackGro.Location = new System.Drawing.Point(374, 232);
            this.BT_PackGro.Name = "BT_PackGro";
            this.BT_PackGro.Size = new System.Drawing.Size(391, 70);
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
            this.BT_OutputFN.Location = new System.Drawing.Point(714, 149);
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
            this.GB_Settings.Controls.Add(this.BT_Help_Workshop);
            this.GB_Settings.Controls.Add(this.BT_Help_Gtitle);
            this.GB_Settings.Controls.Add(this.BT_Help_OtherWLDs);
            this.GB_Settings.Controls.Add(this.CB_Workshop);
            this.GB_Settings.Controls.Add(this.CB_OtherWLDs);
            this.GB_Settings.Controls.Add(this.CB_Gtitle);
            this.GB_Settings.Location = new System.Drawing.Point(15, 190);
            this.GB_Settings.Name = "GB_Settings";
            this.GB_Settings.Size = new System.Drawing.Size(318, 112);
            this.GB_Settings.TabIndex = 7;
            this.GB_Settings.TabStop = false;
            this.GB_Settings.Text = "Optional settings";
            // 
            // BT_Help_Exceptions
            // 
            this.BT_Help_Exceptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_Help_Exceptions.Location = new System.Drawing.Point(6, 85);
            this.BT_Help_Exceptions.Name = "BT_Help_Exceptions";
            this.BT_Help_Exceptions.Size = new System.Drawing.Size(17, 23);
            this.BT_Help_Exceptions.TabIndex = 21;
            this.BT_Help_Exceptions.Text = "?";
            this.BT_Help_Exceptions.UseVisualStyleBackColor = true;
            this.BT_Help_Exceptions.Click += new System.EventHandler(this.BT_Help_Exceptions_Click);
            // 
            // BT_ExceptionsSettings
            // 
            this.BT_ExceptionsSettings.Location = new System.Drawing.Point(202, 85);
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
            this.CB_Exceptions.Checked = true;
            this.CB_Exceptions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_Exceptions.Location = new System.Drawing.Point(29, 89);
            this.CB_Exceptions.Name = "CB_Exceptions";
            this.CB_Exceptions.Size = new System.Drawing.Size(139, 17);
            this.CB_Exceptions.TabIndex = 19;
            this.CB_Exceptions.Text = "Do not pack exceptions";
            this.CB_Exceptions.UseVisualStyleBackColor = true;
            this.CB_Exceptions.CheckedChanged += new System.EventHandler(this.CB_Exceptions_CheckedChanged);
            // 
            // BT_Help_Workshop
            // 
            this.BT_Help_Workshop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_Help_Workshop.Location = new System.Drawing.Point(6, 62);
            this.BT_Help_Workshop.Name = "BT_Help_Workshop";
            this.BT_Help_Workshop.Size = new System.Drawing.Size(17, 23);
            this.BT_Help_Workshop.TabIndex = 18;
            this.BT_Help_Workshop.Text = "?";
            this.BT_Help_Workshop.UseVisualStyleBackColor = true;
            this.BT_Help_Workshop.Click += new System.EventHandler(this.BT_Help_Workshop_Click);
            // 
            // BT_Help_Gtitle
            // 
            this.BT_Help_Gtitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.BT_Help_OtherWLDs.Location = new System.Drawing.Point(6, 39);
            this.BT_Help_OtherWLDs.Name = "BT_Help_OtherWLDs";
            this.BT_Help_OtherWLDs.Size = new System.Drawing.Size(17, 23);
            this.BT_Help_OtherWLDs.TabIndex = 16;
            this.BT_Help_OtherWLDs.Text = "?";
            this.BT_Help_OtherWLDs.UseVisualStyleBackColor = true;
            this.BT_Help_OtherWLDs.Click += new System.EventHandler(this.BT_Help_OtherWLDs_Click);
            // 
            // CB_Workshop
            // 
            this.CB_Workshop.AutoSize = true;
            this.CB_Workshop.Checked = true;
            this.CB_Workshop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_Workshop.Location = new System.Drawing.Point(29, 66);
            this.CB_Workshop.Name = "CB_Workshop";
            this.CB_Workshop.Size = new System.Drawing.Size(241, 17);
            this.CB_Workshop.TabIndex = 2;
            this.CB_Workshop.Text = "Examine workshop subscriptions dependency";
            this.CB_Workshop.UseVisualStyleBackColor = true;
            this.CB_Workshop.CheckedChanged += new System.EventHandler(this.CB_Workshop_CheckedChanged);
            // 
            // CB_OtherWLDs
            // 
            this.CB_OtherWLDs.AutoSize = true;
            this.CB_OtherWLDs.Location = new System.Drawing.Point(29, 43);
            this.CB_OtherWLDs.Name = "CB_OtherWLDs";
            this.CB_OtherWLDs.Size = new System.Drawing.Size(193, 17);
            this.CB_OtherWLDs.TabIndex = 1;
            this.CB_OtherWLDs.Text = "Examine levels linked from selected";
            this.CB_OtherWLDs.UseVisualStyleBackColor = true;
            // 
            // CB_Gtitle
            // 
            this.CB_Gtitle.AutoSize = true;
            this.CB_Gtitle.Location = new System.Drawing.Point(30, 20);
            this.CB_Gtitle.Name = "CB_Gtitle";
            this.CB_Gtitle.Size = new System.Drawing.Size(162, 17);
            this.CB_Gtitle.TabIndex = 0;
            this.CB_Gtitle.Text = "Pack .gtitle and its resources";
            this.CB_Gtitle.UseVisualStyleBackColor = true;
            // 
            // BT_ContentDir
            // 
            this.BT_ContentDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_ContentDir.Location = new System.Drawing.Point(714, 71);
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
            this.TB_GamePath.Location = new System.Drawing.Point(15, 73);
            this.TB_GamePath.Name = "TB_GamePath";
            this.TB_GamePath.Size = new System.Drawing.Size(696, 20);
            this.TB_GamePath.TabIndex = 8;
            // 
            // RTB_Log
            // 
            this.RTB_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTB_Log.Location = new System.Drawing.Point(15, 308);
            this.RTB_Log.MaxLength = 10000;
            this.RTB_Log.Name = "RTB_Log";
            this.RTB_Log.ReadOnly = true;
            this.RTB_Log.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.RTB_Log.Size = new System.Drawing.Size(783, 124);
            this.RTB_Log.TabIndex = 11;
            this.RTB_Log.Text = "";
            // 
            // BT_Log_Copy
            // 
            this.BT_Log_Copy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BT_Log_Copy.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.BT_Log_Copy.Location = new System.Drawing.Point(112, 438);
            this.BT_Log_Copy.Name = "BT_Log_Copy";
            this.BT_Log_Copy.Size = new System.Drawing.Size(70, 23);
            this.BT_Log_Copy.TabIndex = 12;
            this.BT_Log_Copy.Text = "Copy";
            this.BT_Log_Copy.UseVisualStyleBackColor = true;
            this.BT_Log_Copy.Click += new System.EventHandler(this.BT_Log_Copy_Click);
            // 
            // BT_Log_Clear
            // 
            this.BT_Log_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BT_Log_Clear.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.BT_Log_Clear.Location = new System.Drawing.Point(193, 438);
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
            this.BT_Exit.Location = new System.Drawing.Point(714, 438);
            this.BT_Exit.Name = "BT_Exit";
            this.BT_Exit.Size = new System.Drawing.Size(75, 23);
            this.BT_Exit.TabIndex = 14;
            this.BT_Exit.Text = "Exit";
            this.BT_Exit.UseVisualStyleBackColor = true;
            this.BT_Exit.Click += new System.EventHandler(this.BT_Exit_Click);
            // 
            // BT_Browse_Workshop
            // 
            this.BT_Browse_Workshop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_Browse_Workshop.Location = new System.Drawing.Point(714, 110);
            this.BT_Browse_Workshop.Name = "BT_Browse_Workshop";
            this.BT_Browse_Workshop.Size = new System.Drawing.Size(75, 23);
            this.BT_Browse_Workshop.TabIndex = 18;
            this.BT_Browse_Workshop.Text = "Browse";
            this.BT_Browse_Workshop.UseVisualStyleBackColor = true;
            this.BT_Browse_Workshop.Click += new System.EventHandler(this.BT_Browse_Workshop_Click);
            // 
            // LB_Workshop
            // 
            this.LB_Workshop.AutoSize = true;
            this.LB_Workshop.Location = new System.Drawing.Point(27, 96);
            this.LB_Workshop.Name = "LB_Workshop";
            this.LB_Workshop.Size = new System.Drawing.Size(85, 13);
            this.LB_Workshop.TabIndex = 17;
            this.LB_Workshop.Text = "Workshop folder";
            // 
            // TB_WorkshopPath
            // 
            this.TB_WorkshopPath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_WorkshopPath.Location = new System.Drawing.Point(15, 112);
            this.TB_WorkshopPath.Name = "TB_WorkshopPath";
            this.TB_WorkshopPath.Size = new System.Drawing.Size(696, 20);
            this.TB_WorkshopPath.TabIndex = 16;
            // 
            // CB_Autodetection
            // 
            this.CB_Autodetection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_Autodetection.AutoSize = true;
            this.CB_Autodetection.Checked = true;
            this.CB_Autodetection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_Autodetection.Location = new System.Drawing.Point(647, 9);
            this.CB_Autodetection.Name = "CB_Autodetection";
            this.CB_Autodetection.Size = new System.Drawing.Size(127, 17);
            this.CB_Autodetection.TabIndex = 18;
            this.CB_Autodetection.Text = "Enable autodetection";
            this.CB_Autodetection.UseVisualStyleBackColor = true;
            // 
            // BT_Help_Autodetection
            // 
            this.BT_Help_Autodetection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_Help_Autodetection.Location = new System.Drawing.Point(772, 5);
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
            this.BT_Update.Location = new System.Drawing.Point(356, 438);
            this.BT_Update.Name = "BT_Update";
            this.BT_Update.Size = new System.Drawing.Size(119, 23);
            this.BT_Update.TabIndex = 20;
            this.BT_Update.Text = "Check for updates";
            this.BT_Update.UseVisualStyleBackColor = true;
            this.BT_Update.Click += new System.EventHandler(this.BT_Update_Click);
            // 
            // BT_Log_Open
            // 
            this.BT_Log_Open.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BT_Log_Open.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.BT_Log_Open.Location = new System.Drawing.Point(19, 438);
            this.BT_Log_Open.Name = "BT_Log_Open";
            this.BT_Log_Open.Size = new System.Drawing.Size(82, 23);
            this.BT_Log_Open.TabIndex = 21;
            this.BT_Log_Open.Text = "Open in file";
            this.BT_Log_Open.UseVisualStyleBackColor = true;
            this.BT_Log_Open.Click += new System.EventHandler(this.BT_Log_Open_Click);
            // 
            // BT_Settings
            // 
            this.BT_Settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_Settings.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.BT_Settings.Location = new System.Drawing.Point(600, 438);
            this.BT_Settings.Name = "BT_Settings";
            this.BT_Settings.Size = new System.Drawing.Size(108, 23);
            this.BT_Settings.TabIndex = 22;
            this.BT_Settings.Text = "Settings";
            this.BT_Settings.UseVisualStyleBackColor = true;
            this.BT_Settings.Visible = false;
            this.BT_Settings.Click += new System.EventHandler(this.BT_Settings_Click);
            // 
            // PB_Process
            // 
            this.PB_Process.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PB_Process.Location = new System.Drawing.Point(374, 203);
            this.PB_Process.Name = "PB_Process";
            this.PB_Process.Size = new System.Drawing.Size(391, 23);
            this.PB_Process.TabIndex = 23;
            // 
            // LB_CurrentState
            // 
            this.LB_CurrentState.AutoSize = true;
            this.LB_CurrentState.Location = new System.Drawing.Point(381, 187);
            this.LB_CurrentState.Name = "LB_CurrentState";
            this.LB_CurrentState.Size = new System.Drawing.Size(96, 13);
            this.LB_CurrentState.TabIndex = 24;
            this.LB_CurrentState.Text = "PROCESS STATE";
            // 
            // F_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 471);
            this.Controls.Add(this.LB_CurrentState);
            this.Controls.Add(this.PB_Process);
            this.Controls.Add(this.BT_Settings);
            this.Controls.Add(this.BT_Log_Open);
            this.Controls.Add(this.BT_Update);
            this.Controls.Add(this.BT_Help_Autodetection);
            this.Controls.Add(this.CB_Autodetection);
            this.Controls.Add(this.BT_Browse_Workshop);
            this.Controls.Add(this.LB_Workshop);
            this.Controls.Add(this.TB_WorkshopPath);
            this.Controls.Add(this.BT_Exit);
            this.Controls.Add(this.BT_Log_Clear);
            this.Controls.Add(this.BT_Log_Copy);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(828, 491);
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
        private System.Windows.Forms.CheckBox CB_Workshop;
        private System.Windows.Forms.Button BT_ContentDir;
        private System.Windows.Forms.Label LB_GameFolder;
        private System.Windows.Forms.TextBox TB_GamePath;
        private System.Windows.Forms.FolderBrowserDialog FBD_ContentDir;
        private System.Windows.Forms.Button BT_Log_Copy;
        private System.Windows.Forms.Button BT_Log_Clear;
        private System.Windows.Forms.Button BT_Exit;
        private System.Windows.Forms.Button BT_Help_Gtitle;
        private System.Windows.Forms.Button BT_Help_OtherWLDs;
        private System.Windows.Forms.Button BT_Browse_Workshop;
        private System.Windows.Forms.Label LB_Workshop;
        private System.Windows.Forms.TextBox TB_WorkshopPath;
        private System.Windows.Forms.CheckBox CB_Autodetection;
        private System.Windows.Forms.Button BT_Help_Workshop;
        private System.Windows.Forms.Button BT_Help_Autodetection;
        private System.Windows.Forms.Button BT_Update;
        private System.Windows.Forms.RichTextBox RTB_Log;
        private System.Windows.Forms.Button BT_Log_Open;
        private System.Windows.Forms.Button BT_Settings;
        private System.Windows.Forms.ProgressBar PB_Process;
        private System.Windows.Forms.Label LB_CurrentState;
        private System.Windows.Forms.Button BT_ExceptionsSettings;
        private System.Windows.Forms.CheckBox CB_Exceptions;
        private System.Windows.Forms.Button BT_Help_Exceptions;
    }
}

