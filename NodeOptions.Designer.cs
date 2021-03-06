﻿namespace VignetteCreator1._0
{
    partial class NodeOptions
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DescriptionTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.NameTB = new System.Windows.Forms.TextBox();
            this.confirmB = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.cancelB = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.widthTB = new System.Windows.Forms.TextBox();
            this.heightTB = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 198);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description :";
            // 
            // DescriptionTB
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.DescriptionTB, 2);
            this.DescriptionTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DescriptionTB.Location = new System.Drawing.Point(3, 3);
            this.DescriptionTB.Multiline = true;
            this.DescriptionTB.Name = "DescriptionTB";
            this.DescriptionTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DescriptionTB.Size = new System.Drawing.Size(587, 233);
            this.DescriptionTB.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(380, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Type :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "Size :";
            // 
            // NameTB
            // 
            this.NameTB.Location = new System.Drawing.Point(98, 6);
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(177, 31);
            this.NameTB.TabIndex = 5;
            // 
            // confirmB
            // 
            this.confirmB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.confirmB.Location = new System.Drawing.Point(3, 242);
            this.confirmB.Name = "confirmB";
            this.confirmB.Size = new System.Drawing.Size(290, 58);
            this.confirmB.TabIndex = 6;
            this.confirmB.Text = "Confirm";
            this.confirmB.UseVisualStyleBackColor = true;
            this.confirmB.Click += new System.EventHandler(this.confirmB_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.confirmB, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cancelB, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.DescriptionTB, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 235);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(593, 303);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // cancelB
            // 
            this.cancelB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancelB.Location = new System.Drawing.Point(299, 242);
            this.cancelB.Name = "cancelB";
            this.cancelB.Size = new System.Drawing.Size(291, 58);
            this.cancelB.TabIndex = 7;
            this.cancelB.Text = "Cancel";
            this.cancelB.UseVisualStyleBackColor = true;
            this.cancelB.Click += new System.EventHandler(this.cancelB_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(180, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "x";
            // 
            // widthTB
            // 
            this.widthTB.Location = new System.Drawing.Point(84, 62);
            this.widthTB.Name = "widthTB";
            this.widthTB.Size = new System.Drawing.Size(86, 31);
            this.widthTB.TabIndex = 9;
            // 
            // heightTB
            // 
            this.heightTB.Location = new System.Drawing.Point(209, 62);
            this.heightTB.Name = "heightTB";
            this.heightTB.Size = new System.Drawing.Size(86, 31);
            this.heightTB.TabIndex = 10;
            // 
            // NodeOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 538);
            this.Controls.Add(this.heightTB);
            this.Controls.Add(this.widthTB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.NameTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NodeOptions";
            this.Text = "Node Details";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DescriptionTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NameTB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button confirmB;
        private System.Windows.Forms.Button cancelB;
        private System.Windows.Forms.TextBox widthTB;
        private System.Windows.Forms.TextBox heightTB;
        private System.Windows.Forms.Label label5;
    }
}