namespace McTools.Xrm.Connection.WinForms.CustomControls
{
    partial class ConnectionSucceededControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearEnvHighlight = new System.Windows.Forms.Button();
            this.btnSetEnvHighlight = new System.Windows.Forms.Button();
            this.btnClearBrowser = new System.Windows.Forms.Button();
            this.btnSetBrowser = new System.Windows.Forms.Button();
            this.lblAddToFolder = new System.Windows.Forms.Label();
            this.cbbFolderSelection = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtConnectionName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblHighlight = new System.Windows.Forms.Label();
            this.lblBrowser = new System.Windows.Forms.Label();
            this.btnNewFolder = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1011, 40);
            this.label1.TabIndex = 17;
            this.label1.Text = "The connection was created successfully. If you want to save this connection, ple" +
    "ase provide a name for this connection.";
            // 
            // btnClearEnvHighlight
            // 
            this.btnClearEnvHighlight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClearEnvHighlight.Location = new System.Drawing.Point(657, 39);
            this.btnClearEnvHighlight.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearEnvHighlight.Name = "btnClearEnvHighlight";
            this.btnClearEnvHighlight.Size = new System.Drawing.Size(352, 33);
            this.btnClearEnvHighlight.TabIndex = 23;
            this.btnClearEnvHighlight.Text = "Clear Environment Highlight";
            this.btnClearEnvHighlight.UseVisualStyleBackColor = true;
            this.btnClearEnvHighlight.Visible = false;
            this.btnClearEnvHighlight.Click += new System.EventHandler(this.btnClearEnvHighlight_Click);
            // 
            // btnSetEnvHighlight
            // 
            this.btnSetEnvHighlight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSetEnvHighlight.Location = new System.Drawing.Point(302, 39);
            this.btnSetEnvHighlight.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetEnvHighlight.Name = "btnSetEnvHighlight";
            this.btnSetEnvHighlight.Size = new System.Drawing.Size(351, 33);
            this.btnSetEnvHighlight.TabIndex = 22;
            this.btnSetEnvHighlight.Text = "Set Environment Highlight";
            this.btnSetEnvHighlight.UseVisualStyleBackColor = true;
            this.btnSetEnvHighlight.Click += new System.EventHandler(this.btnSetEnvHighlight_Click);
            // 
            // btnClearBrowser
            // 
            this.btnClearBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClearBrowser.Location = new System.Drawing.Point(657, 76);
            this.btnClearBrowser.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearBrowser.Name = "btnClearBrowser";
            this.btnClearBrowser.Size = new System.Drawing.Size(352, 33);
            this.btnClearBrowser.TabIndex = 26;
            this.btnClearBrowser.Text = "Clear Browser";
            this.btnClearBrowser.UseVisualStyleBackColor = true;
            this.btnClearBrowser.Visible = false;
            this.btnClearBrowser.Click += new System.EventHandler(this.btnClearBrowser_Click);
            // 
            // btnSetBrowser
            // 
            this.btnSetBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSetBrowser.Location = new System.Drawing.Point(302, 76);
            this.btnSetBrowser.Margin = new System.Windows.Forms.Padding(2);
            this.btnSetBrowser.Name = "btnSetBrowser";
            this.btnSetBrowser.Size = new System.Drawing.Size(351, 33);
            this.btnSetBrowser.TabIndex = 25;
            this.btnSetBrowser.Text = "Set Browser";
            this.btnSetBrowser.UseVisualStyleBackColor = true;
            this.btnSetBrowser.Click += new System.EventHandler(this.btnSetBrowser_Click);
            // 
            // lblAddToFolder
            // 
            this.lblAddToFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAddToFolder.Location = new System.Drawing.Point(2, 111);
            this.lblAddToFolder.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAddToFolder.Name = "lblAddToFolder";
            this.lblAddToFolder.Size = new System.Drawing.Size(296, 37);
            this.lblAddToFolder.TabIndex = 27;
            this.lblAddToFolder.Text = "Add the connection to folder";
            this.lblAddToFolder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbbFolderSelection
            // 
            this.cbbFolderSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbFolderSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFolderSelection.FormattingEnabled = true;
            this.cbbFolderSelection.Location = new System.Drawing.Point(303, 114);
            this.cbbFolderSelection.Name = "cbbFolderSelection";
            this.cbbFolderSelection.Size = new System.Drawing.Size(349, 28);
            this.cbbFolderSelection.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(4, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(292, 37);
            this.label2.TabIndex = 18;
            this.label2.Text = "Name";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtConnectionName
            // 
            this.txtConnectionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.txtConnectionName, 2);
            this.txtConnectionName.Location = new System.Drawing.Point(304, 4);
            this.txtConnectionName.Margin = new System.Windows.Forms.Padding(4);
            this.txtConnectionName.Name = "txtConnectionName";
            this.txtConnectionName.Size = new System.Drawing.Size(703, 26);
            this.txtConnectionName.TabIndex = 19;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtConnectionName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblHighlight, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblBrowser, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbbFolderSelection, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblAddToFolder, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnClearBrowser, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnSetEnvHighlight, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnSetBrowser, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnClearEnvHighlight, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnNewFolder, 2, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 40);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1011, 150);
            this.tableLayoutPanel1.TabIndex = 30;
            // 
            // lblHighlight
            // 
            this.lblHighlight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHighlight.Location = new System.Drawing.Point(2, 37);
            this.lblHighlight.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHighlight.Name = "lblHighlight";
            this.lblHighlight.Size = new System.Drawing.Size(296, 37);
            this.lblHighlight.TabIndex = 22;
            this.lblHighlight.Text = "Define an environment highlight";
            this.lblHighlight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBrowser
            // 
            this.lblBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBrowser.Location = new System.Drawing.Point(2, 74);
            this.lblBrowser.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBrowser.Name = "lblBrowser";
            this.lblBrowser.Size = new System.Drawing.Size(296, 37);
            this.lblBrowser.TabIndex = 24;
            this.lblBrowser.Text = "Define a browser and profile";
            this.lblBrowser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnNewFolder
            // 
            this.btnNewFolder.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNewFolder.Location = new System.Drawing.Point(658, 114);
            this.btnNewFolder.Name = "btnNewFolder";
            this.btnNewFolder.Size = new System.Drawing.Size(51, 31);
            this.btnNewFolder.TabIndex = 29;
            this.btnNewFolder.Text = "+";
            this.btnNewFolder.UseVisualStyleBackColor = true;
            this.btnNewFolder.Click += BtnNewFolder_Click;
            // 
            // ConnectionSucceededControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ConnectionSucceededControl";
            this.Size = new System.Drawing.Size(1011, 214);
            this.Load += new System.EventHandler(this.ConnectionSucceededControl_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

       

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClearEnvHighlight;
        private System.Windows.Forms.Button btnSetEnvHighlight;
        private System.Windows.Forms.Button btnClearBrowser;
        private System.Windows.Forms.Button btnSetBrowser;
        private System.Windows.Forms.Label lblAddToFolder;
        private System.Windows.Forms.ComboBox cbbFolderSelection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtConnectionName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblHighlight;
        private System.Windows.Forms.Label lblBrowser;
        private System.Windows.Forms.Button btnNewFolder;
    }
}
