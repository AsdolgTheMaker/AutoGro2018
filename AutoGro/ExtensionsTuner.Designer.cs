namespace AutoGro
{
    partial class ExtensionsTuner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtensionsTuner));
            this.BT_Cancel = new System.Windows.Forms.Button();
            this.BT_Apply = new System.Windows.Forms.Button();
            this.BT_Default = new System.Windows.Forms.Button();
            this.TB_NewExtension = new System.Windows.Forms.TextBox();
            this.BT_Add = new System.Windows.Forms.Button();
            this.BT_Remove = new System.Windows.Forms.Button();
            this.listExtensions = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // BT_Cancel
            // 
            this.BT_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_Cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BT_Cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.BT_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Cancel.Location = new System.Drawing.Point(146, 205);
            this.BT_Cancel.Name = "BT_Cancel";
            this.BT_Cancel.Size = new System.Drawing.Size(75, 23);
            this.BT_Cancel.TabIndex = 0;
            this.BT_Cancel.Text = "Cancel";
            this.BT_Cancel.UseVisualStyleBackColor = true;
            this.BT_Cancel.Click += new System.EventHandler(this.BT_Cancel_Click);
            // 
            // BT_Apply
            // 
            this.BT_Apply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_Apply.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BT_Apply.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.BT_Apply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Apply.Location = new System.Drawing.Point(146, 234);
            this.BT_Apply.Name = "BT_Apply";
            this.BT_Apply.Size = new System.Drawing.Size(75, 23);
            this.BT_Apply.TabIndex = 1;
            this.BT_Apply.Text = "Apply";
            this.BT_Apply.UseVisualStyleBackColor = true;
            this.BT_Apply.Click += new System.EventHandler(this.BT_Apply_Click);
            // 
            // BT_Default
            // 
            this.BT_Default.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.BT_Default.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.BT_Default.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BT_Default.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Default.Location = new System.Drawing.Point(12, 234);
            this.BT_Default.Name = "BT_Default";
            this.BT_Default.Size = new System.Drawing.Size(108, 23);
            this.BT_Default.TabIndex = 2;
            this.BT_Default.Text = "Revert to default";
            this.BT_Default.UseVisualStyleBackColor = true;
            this.BT_Default.Click += new System.EventHandler(this.BT_Default_Click);
            // 
            // TB_NewExtension
            // 
            this.TB_NewExtension.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_NewExtension.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TB_NewExtension.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TB_NewExtension.ForeColor = System.Drawing.Color.White;
            this.TB_NewExtension.Location = new System.Drawing.Point(151, 12);
            this.TB_NewExtension.Name = "TB_NewExtension";
            this.TB_NewExtension.Size = new System.Drawing.Size(70, 20);
            this.TB_NewExtension.TabIndex = 4;
            this.TB_NewExtension.TextChanged += new System.EventHandler(this.TB_NewExtension_TextChanged);
            // 
            // BT_Add
            // 
            this.BT_Add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.BT_Add.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Green;
            this.BT_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Add.Location = new System.Drawing.Point(151, 38);
            this.BT_Add.Name = "BT_Add";
            this.BT_Add.Size = new System.Drawing.Size(70, 23);
            this.BT_Add.TabIndex = 5;
            this.BT_Add.Text = "Add";
            this.BT_Add.UseVisualStyleBackColor = true;
            this.BT_Add.Click += new System.EventHandler(this.BT_Add_Click);
            // 
            // BT_Remove
            // 
            this.BT_Remove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_Remove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BT_Remove.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.BT_Remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Remove.Location = new System.Drawing.Point(151, 97);
            this.BT_Remove.Name = "BT_Remove";
            this.BT_Remove.Size = new System.Drawing.Size(70, 37);
            this.BT_Remove.TabIndex = 6;
            this.BT_Remove.Text = "Remove selected";
            this.BT_Remove.UseVisualStyleBackColor = true;
            this.BT_Remove.Click += new System.EventHandler(this.BT_Remove_Click);
            // 
            // listExtensions
            // 
            this.listExtensions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listExtensions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.listExtensions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listExtensions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.listExtensions.FormattingEnabled = true;
            this.listExtensions.Location = new System.Drawing.Point(12, 12);
            this.listExtensions.Name = "listExtensions";
            this.listExtensions.Size = new System.Drawing.Size(108, 197);
            this.listExtensions.TabIndex = 7;
            // 
            // ExtensionsTuner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(233, 269);
            this.Controls.Add(this.listExtensions);
            this.Controls.Add(this.BT_Remove);
            this.Controls.Add(this.BT_Add);
            this.Controls.Add(this.TB_NewExtension);
            this.Controls.Add(this.BT_Default);
            this.Controls.Add(this.BT_Apply);
            this.Controls.Add(this.BT_Cancel);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(233, 269);
            this.Name = "ExtensionsTuner";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ExtensionsTuner";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BT_Cancel;
        private System.Windows.Forms.Button BT_Apply;
        private System.Windows.Forms.Button BT_Default;
        private System.Windows.Forms.TextBox TB_NewExtension;
        private System.Windows.Forms.Button BT_Add;
        private System.Windows.Forms.Button BT_Remove;
        private System.Windows.Forms.ListBox listExtensions;
    }
}