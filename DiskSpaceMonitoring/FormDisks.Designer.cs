namespace DiskSpaceMonitoring
{
    partial class FormDisks
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDisks));
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.buttonTestConnection = new System.Windows.Forms.Button();
            this.labelUrl = new System.Windows.Forms.Label();
            this.textBoxServerUrl = new System.Windows.Forms.TextBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.buttonSaveSettings = new System.Windows.Forms.Button();
            this.tabPageDisks = new System.Windows.Forms.TabPage();
            this.tabControlDisks = new System.Windows.Forms.TabControl();
            this.notifyIconDisks = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripDisks = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageSettings.SuspendLayout();
            this.tabControlDisks.SuspendLayout();
            this.contextMenuStripDisks.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.buttonTestConnection);
            this.tabPageSettings.Controls.Add(this.labelUrl);
            this.tabPageSettings.Controls.Add(this.textBoxServerUrl);
            this.tabPageSettings.Controls.Add(this.checkedListBox1);
            this.tabPageSettings.Controls.Add(this.buttonSaveSettings);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 25);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(1206, 454);
            this.tabPageSettings.TabIndex = 1;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            this.tabPageSettings.Move += new System.EventHandler(this.tabPageSettings_Move);
            // 
            // buttonTestConnection
            // 
            this.buttonTestConnection.Location = new System.Drawing.Point(978, 8);
            this.buttonTestConnection.Name = "buttonTestConnection";
            this.buttonTestConnection.Size = new System.Drawing.Size(112, 25);
            this.buttonTestConnection.TabIndex = 8;
            this.buttonTestConnection.Text = "Test connection";
            this.buttonTestConnection.UseVisualStyleBackColor = true;
            this.buttonTestConnection.Click += new System.EventHandler(this.buttonTestConnection_Click_1);
            // 
            // labelUrl
            // 
            this.labelUrl.AutoSize = true;
            this.labelUrl.Location = new System.Drawing.Point(8, 12);
            this.labelUrl.Name = "labelUrl";
            this.labelUrl.Size = new System.Drawing.Size(78, 16);
            this.labelUrl.TabIndex = 7;
            this.labelUrl.Text = "Server URL";
            // 
            // textBoxServerUrl
            // 
            this.textBoxServerUrl.Location = new System.Drawing.Point(92, 9);
            this.textBoxServerUrl.Name = "textBoxServerUrl";
            this.textBoxServerUrl.Size = new System.Drawing.Size(880, 22);
            this.textBoxServerUrl.TabIndex = 6;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(11, 53);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(514, 293);
            this.checkedListBox1.TabIndex = 0;
            // 
            // buttonSaveSettings
            // 
            this.buttonSaveSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveSettings.Location = new System.Drawing.Point(1125, 425);
            this.buttonSaveSettings.Name = "buttonSaveSettings";
            this.buttonSaveSettings.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveSettings.TabIndex = 3;
            this.buttonSaveSettings.Text = "Save";
            this.buttonSaveSettings.UseVisualStyleBackColor = true;
            this.buttonSaveSettings.Click += new System.EventHandler(this.buttonSaveSettings_Click);
            // 
            // tabPageDisks
            // 
            this.tabPageDisks.BackColor = System.Drawing.SystemColors.Menu;
            this.tabPageDisks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPageDisks.Location = new System.Drawing.Point(4, 25);
            this.tabPageDisks.Name = "tabPageDisks";
            this.tabPageDisks.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDisks.Size = new System.Drawing.Size(471, 449);
            this.tabPageDisks.TabIndex = 0;
            this.tabPageDisks.Text = "Disks";
            // 
            // tabControlDisks
            // 
            this.tabControlDisks.Controls.Add(this.tabPageDisks);
            this.tabControlDisks.Controls.Add(this.tabPageSettings);
            this.tabControlDisks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDisks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControlDisks.Location = new System.Drawing.Point(0, 0);
            this.tabControlDisks.Name = "tabControlDisks";
            this.tabControlDisks.SelectedIndex = 0;
            this.tabControlDisks.Size = new System.Drawing.Size(479, 478);
            this.tabControlDisks.TabIndex = 4;
            this.tabControlDisks.Click += new System.EventHandler(this.tabControlDisks_Click);
            // 
            // notifyIconDisks
            // 
            this.notifyIconDisks.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIconDisks.BalloonTipText = "TipText";
            this.notifyIconDisks.BalloonTipTitle = "4title";
            this.notifyIconDisks.ContextMenuStrip = this.contextMenuStripDisks;
            this.notifyIconDisks.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconDisks.Icon")));
            this.notifyIconDisks.Text = "Disk space monitoring";
            this.notifyIconDisks.Visible = true;
            this.notifyIconDisks.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStripDisks
            // 
            this.contextMenuStripDisks.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.hideToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStripDisks.Name = "contextMenuStrip1";
            this.contextMenuStripDisks.Size = new System.Drawing.Size(117, 92);
            this.contextMenuStripDisks.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // FormDisks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 478);
            this.Controls.Add(this.tabControlDisks);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDisks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Disk Space Viewer";
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageSettings.PerformLayout();
            this.tabControlDisks.ResumeLayout(false);
            this.contextMenuStripDisks.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.TabPage tabPageDisks;
        private System.Windows.Forms.TabControl tabControlDisks;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button buttonSaveSettings;
        private System.Windows.Forms.Button buttonTestConnection;
        private System.Windows.Forms.Label labelUrl;
        private System.Windows.Forms.TextBox textBoxServerUrl;
        private System.Windows.Forms.NotifyIcon notifyIconDisks;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripDisks;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    }
}

