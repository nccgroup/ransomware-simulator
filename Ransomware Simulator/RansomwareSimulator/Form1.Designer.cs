/*
Released as open source by NCC Group Plc - http://www.nccgroup.com/

Developed by Donato Ferrante, donato dot ferrante at nccgroup dot trust

https://www.github.com/nccgroup/ransomware-simulator

Released under AGPL see LICENSE for more information
*/

namespace RansomwareSimulator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelHeader = new System.Windows.Forms.Panel();
            this.panelNCCLogo = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonAcknowledgement = new System.Windows.Forms.Button();
            this.labelCurrentFile = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.LabelFileVictimRem = new System.Windows.Forms.Label();
            this.LabelDataVictimRem = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.LabelFileVictimNet = new System.Windows.Forms.Label();
            this.LabelDataVictimNet = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.LabelFileVictim = new System.Windows.Forms.Label();
            this.LabelDataVictim = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonInspect = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxTargets = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonReport = new System.Windows.Forms.Button();
            this.richTextBoxOutput = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelNCC = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.panelHeader.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelHeader
            // 
            this.panelHeader.BackColor = System.Drawing.Color.Black;
            this.panelHeader.Controls.Add(this.panelNCCLogo);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(1008, 101);
            this.panelHeader.TabIndex = 0;
            // 
            // panelNCCLogo
            // 
            this.panelNCCLogo.BackgroundImage = global::RansomwareSimulator.Properties.Resources.nccrlogo;
            this.panelNCCLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panelNCCLogo.Location = new System.Drawing.Point(3, 3);
            this.panelNCCLogo.Name = "panelNCCLogo";
            this.panelNCCLogo.Size = new System.Drawing.Size(405, 100);
            this.panelNCCLogo.TabIndex = 0;
            this.panelNCCLogo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelNCCLogo_MouseClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.buttonAcknowledgement);
            this.groupBox1.Controls.Add(this.labelCurrentFile);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.buttonInspect);
            this.groupBox1.Controls.Add(this.labelStatus);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.textBoxTargets);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buttonReport);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1008, 173);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // buttonAcknowledgement
            // 
            this.buttonAcknowledgement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAcknowledgement.Location = new System.Drawing.Point(856, 107);
            this.buttonAcknowledgement.Name = "buttonAcknowledgement";
            this.buttonAcknowledgement.Size = new System.Drawing.Size(134, 24);
            this.buttonAcknowledgement.TabIndex = 24;
            this.buttonAcknowledgement.Text = "Acknowledgements";
            this.buttonAcknowledgement.UseVisualStyleBackColor = true;
            this.buttonAcknowledgement.Click += new System.EventHandler(this.buttonAcknowledgement_Click);
            // 
            // labelCurrentFile
            // 
            this.labelCurrentFile.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelCurrentFile.AutoSize = true;
            this.labelCurrentFile.ForeColor = System.Drawing.Color.DarkRed;
            this.labelCurrentFile.Location = new System.Drawing.Point(9, 152);
            this.labelCurrentFile.Name = "labelCurrentFile";
            this.labelCurrentFile.Size = new System.Drawing.Size(14, 14);
            this.labelCurrentFile.TabIndex = 23;
            this.labelCurrentFile.Text = ".";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.LabelFileVictimRem);
            this.groupBox4.Controls.Add(this.LabelDataVictimRem);
            this.groupBox4.Location = new System.Drawing.Point(405, 71);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(181, 70);
            this.groupBox4.TabIndex = 21;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Removable";
            // 
            // label17
            // 
            this.label17.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.DarkRed;
            this.label17.Location = new System.Drawing.Point(18, 19);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 14);
            this.label17.TabIndex = 5;
            this.label17.Text = "Files:";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.DarkRed;
            this.label18.Location = new System.Drawing.Point(25, 46);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(42, 14);
            this.label18.TabIndex = 6;
            this.label18.Text = "Data:";
            // 
            // LabelFileVictimRem
            // 
            this.LabelFileVictimRem.AutoSize = true;
            this.LabelFileVictimRem.Location = new System.Drawing.Point(70, 19);
            this.LabelFileVictimRem.Name = "LabelFileVictimRem";
            this.LabelFileVictimRem.Size = new System.Drawing.Size(14, 14);
            this.LabelFileVictimRem.TabIndex = 10;
            this.LabelFileVictimRem.Text = "0";
            // 
            // LabelDataVictimRem
            // 
            this.LabelDataVictimRem.AutoSize = true;
            this.LabelDataVictimRem.Location = new System.Drawing.Point(70, 46);
            this.LabelDataVictimRem.Name = "LabelDataVictimRem";
            this.LabelDataVictimRem.Size = new System.Drawing.Size(14, 14);
            this.LabelDataVictimRem.TabIndex = 11;
            this.LabelDataVictimRem.Text = "0";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.LabelFileVictimNet);
            this.groupBox3.Controls.Add(this.LabelDataVictimNet);
            this.groupBox3.Location = new System.Drawing.Point(209, 71);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(181, 70);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Remote";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.DarkRed;
            this.label13.Location = new System.Drawing.Point(18, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 14);
            this.label13.TabIndex = 5;
            this.label13.Text = "Files:";
            // 
            // label14
            // 
            this.label14.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.DarkRed;
            this.label14.Location = new System.Drawing.Point(25, 46);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 14);
            this.label14.TabIndex = 6;
            this.label14.Text = "Data:";
            // 
            // LabelFileVictimNet
            // 
            this.LabelFileVictimNet.AutoSize = true;
            this.LabelFileVictimNet.Location = new System.Drawing.Point(70, 19);
            this.LabelFileVictimNet.Name = "LabelFileVictimNet";
            this.LabelFileVictimNet.Size = new System.Drawing.Size(14, 14);
            this.LabelFileVictimNet.TabIndex = 10;
            this.LabelFileVictimNet.Text = "0";
            // 
            // LabelDataVictimNet
            // 
            this.LabelDataVictimNet.AutoSize = true;
            this.LabelDataVictimNet.Location = new System.Drawing.Point(70, 46);
            this.LabelDataVictimNet.Name = "LabelDataVictimNet";
            this.LabelDataVictimNet.Size = new System.Drawing.Size(14, 14);
            this.LabelDataVictimNet.TabIndex = 11;
            this.LabelDataVictimNet.Text = "0";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.LabelFileVictim);
            this.groupBox2.Controls.Add(this.LabelDataVictim);
            this.groupBox2.Location = new System.Drawing.Point(12, 71);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(181, 70);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Local";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.DarkRed;
            this.label4.Location = new System.Drawing.Point(18, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 5;
            this.label4.Text = "Files:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(25, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 14);
            this.label5.TabIndex = 6;
            this.label5.Text = "Data:";
            // 
            // LabelFileVictim
            // 
            this.LabelFileVictim.AutoSize = true;
            this.LabelFileVictim.Location = new System.Drawing.Point(70, 19);
            this.LabelFileVictim.Name = "LabelFileVictim";
            this.LabelFileVictim.Size = new System.Drawing.Size(14, 14);
            this.LabelFileVictim.TabIndex = 10;
            this.LabelFileVictim.Text = "0";
            // 
            // LabelDataVictim
            // 
            this.LabelDataVictim.AutoSize = true;
            this.LabelDataVictim.Location = new System.Drawing.Point(70, 46);
            this.LabelDataVictim.Name = "LabelDataVictim";
            this.LabelDataVictim.Size = new System.Drawing.Size(14, 14);
            this.LabelDataVictim.TabIndex = 11;
            this.LabelDataVictim.Text = "0";
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.DarkRed;
            this.label11.Location = new System.Drawing.Point(861, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 14);
            this.label11.TabIndex = 16;
            this.label11.Text = "Inspect";
            // 
            // buttonInspect
            // 
            this.buttonInspect.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonInspect.BackgroundImage = global::RansomwareSimulator.Properties.Resources.task;
            this.buttonInspect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonInspect.Location = new System.Drawing.Point(856, 13);
            this.buttonInspect.Name = "buttonInspect";
            this.buttonInspect.Size = new System.Drawing.Size(64, 64);
            this.buttonInspect.TabIndex = 15;
            this.buttonInspect.UseVisualStyleBackColor = true;
            this.buttonInspect.Click += new System.EventHandler(this.buttonInspect_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(341, 39);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(28, 14);
            this.labelStatus.TabIndex = 14;
            this.labelStatus.Text = "n/a";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.DarkRed;
            this.label8.Location = new System.Drawing.Point(279, 39);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 14);
            this.label8.TabIndex = 13;
            this.label8.Text = "Status:";
            // 
            // textBoxTargets
            // 
            this.textBoxTargets.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBoxTargets.Location = new System.Drawing.Point(84, 36);
            this.textBoxTargets.Name = "textBoxTargets";
            this.textBoxTargets.Size = new System.Drawing.Size(180, 20);
            this.textBoxTargets.TabIndex = 7;
            this.textBoxTargets.Text = "*.docx";
            this.textBoxTargets.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(23, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "Target:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(933, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Report";
            // 
            // buttonReport
            // 
            this.buttonReport.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.buttonReport.BackgroundImage = global::RansomwareSimulator.Properties.Resources.reporting;
            this.buttonReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonReport.Enabled = false;
            this.buttonReport.Location = new System.Drawing.Point(926, 13);
            this.buttonReport.Name = "buttonReport";
            this.buttonReport.Size = new System.Drawing.Size(64, 64);
            this.buttonReport.TabIndex = 1;
            this.buttonReport.UseVisualStyleBackColor = true;
            this.buttonReport.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // richTextBoxOutput
            // 
            this.richTextBoxOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxOutput.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxOutput.Location = new System.Drawing.Point(0, 274);
            this.richTextBoxOutput.Name = "richTextBoxOutput";
            this.richTextBoxOutput.ReadOnly = true;
            this.richTextBoxOutput.Size = new System.Drawing.Size(1008, 226);
            this.richTextBoxOutput.TabIndex = 2;
            this.richTextBoxOutput.Text = "";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.labelNCC);
            this.panel2.Controls.Add(this.labelVersion);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 500);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1008, 24);
            this.panel2.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.DarkRed;
            this.label10.Location = new System.Drawing.Point(573, 5);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "]]";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.DarkRed;
            this.label9.Location = new System.Drawing.Point(377, 5);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "[[";
            // 
            // labelNCC
            // 
            this.labelNCC.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.labelNCC.AutoSize = true;
            this.labelNCC.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNCC.ForeColor = System.Drawing.Color.White;
            this.labelNCC.Location = new System.Drawing.Point(391, 5);
            this.labelNCC.Name = "labelNCC";
            this.labelNCC.Size = new System.Drawing.Size(181, 13);
            this.labelNCC.TabIndex = 16;
            this.labelNCC.Text = "NCC Group - www.nccgroup.trust";
            this.labelNCC.Click += new System.EventHandler(this.labelNCC_Click);
            // 
            // labelVersion
            // 
            this.labelVersion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelVersion.AutoSize = true;
            this.labelVersion.ForeColor = System.Drawing.Color.DimGray;
            this.labelVersion.Location = new System.Drawing.Point(8, 5);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(47, 13);
            this.labelVersion.TabIndex = 15;
            this.labelVersion.Text = "version: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 524);
            this.Controls.Add(this.richTextBoxOutput);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelHeader);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "NCC Ransomware Simulator";
            this.panelHeader.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Panel panelNCCLogo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBoxOutput;
        private System.Windows.Forms.Button buttonReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxTargets;
        private System.Windows.Forms.Label LabelDataVictim;
        private System.Windows.Forms.Label LabelFileVictim;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelNCC;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonInspect;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label LabelFileVictimNet;
        private System.Windows.Forms.Label LabelDataVictimNet;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label LabelFileVictimRem;
        private System.Windows.Forms.Label LabelDataVictimRem;
        private System.Windows.Forms.Label labelCurrentFile;
        private System.Windows.Forms.Button buttonAcknowledgement;
    }
}

