namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pB1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.showButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.BChooseFile = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.PicNumberTaker = new System.Windows.Forms.NumericUpDown();
            this.BGTeinlesen = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pB1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicNumberTaker)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.16817F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 81.83183F));
            this.tableLayoutPanel1.Controls.Add(this.pB1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.PicNumberTaker, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(666, 373);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // pB1
            // 
            this.pB1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tableLayoutPanel1.SetColumnSpan(this.pB1, 2);
            this.pB1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pB1.Location = new System.Drawing.Point(3, 3);
            this.pB1.Name = "pB1";
            this.pB1.Size = new System.Drawing.Size(660, 329);
            this.pB1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pB1.TabIndex = 0;
            this.pB1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.showButton);
            this.flowLayoutPanel1.Controls.Add(this.clearButton);
            this.flowLayoutPanel1.Controls.Add(this.BChooseFile);
            this.flowLayoutPanel1.Controls.Add(this.BGTeinlesen);
            this.flowLayoutPanel1.Controls.Add(this.closeButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(124, 338);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(539, 32);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // showButton
            // 
            this.showButton.AutoSize = true;
            this.showButton.Location = new System.Drawing.Point(445, 3);
            this.showButton.Name = "showButton";
            this.showButton.Size = new System.Drawing.Size(91, 23);
            this.showButton.TabIndex = 0;
            this.showButton.Text = "Bild anzeigen";
            this.showButton.UseVisualStyleBackColor = true;
            this.showButton.Click += new System.EventHandler(this.showButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.AutoSize = true;
            this.clearButton.Location = new System.Drawing.Point(345, 3);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(94, 23);
            this.clearButton.TabIndex = 1;
            this.clearButton.Text = "Anzeige leeren";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // BChooseFile
            // 
            this.BChooseFile.AutoSize = true;
            this.BChooseFile.Location = new System.Drawing.Point(253, 3);
            this.BChooseFile.Name = "BChooseFile";
            this.BChooseFile.Size = new System.Drawing.Size(86, 23);
            this.BChooseFile.TabIndex = 2;
            this.BChooseFile.Text = "Bilder wählen";
            this.BChooseFile.UseVisualStyleBackColor = true;
            this.BChooseFile.Click += new System.EventHandler(this.BChooseFile_Click);
            // 
            // closeButton
            // 
            this.closeButton.AutoSize = true;
            this.closeButton.Location = new System.Drawing.Point(65, 3);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 3;
            this.closeButton.Text = "beenden";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // PicNumberTaker
            // 
            this.PicNumberTaker.Location = new System.Drawing.Point(3, 338);
            this.PicNumberTaker.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.PicNumberTaker.Name = "PicNumberTaker";
            this.PicNumberTaker.Size = new System.Drawing.Size(45, 20);
            this.PicNumberTaker.TabIndex = 3;
            // 
            // BGTeinlesen
            // 
            this.BGTeinlesen.AutoSize = true;
            this.BGTeinlesen.Location = new System.Drawing.Point(146, 3);
            this.BGTeinlesen.Name = "BGTeinlesen";
            this.BGTeinlesen.Size = new System.Drawing.Size(101, 23);
            this.BGTeinlesen.TabIndex = 4;
            this.BGTeinlesen.Text = "GT Daten wählen";
            this.BGTeinlesen.UseVisualStyleBackColor = true;
            this.BGTeinlesen.Click += new System.EventHandler(this.BGTeinlesen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 373);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pB1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicNumberTaker)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pB1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button showButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button BChooseFile;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.NumericUpDown PicNumberTaker;
        private System.Windows.Forms.Button BGTeinlesen;
    }
}

