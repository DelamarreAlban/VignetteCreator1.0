namespace VignetteCreator1._0
{
    partial class ContextMenuAddNode
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
            this.teacherAction = new System.Windows.Forms.Button();
            this.studentAction = new System.Windows.Forms.Button();
            this.finalNode = new System.Windows.Forms.Button();
            this.classAction = new System.Windows.Forms.Button();
            this.decisionAction = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // teacherAction
            // 
            this.teacherAction.Location = new System.Drawing.Point(284, 26);
            this.teacherAction.Name = "teacherAction";
            this.teacherAction.Size = new System.Drawing.Size(209, 84);
            this.teacherAction.TabIndex = 0;
            this.teacherAction.Text = "Teacher Action";
            this.teacherAction.UseVisualStyleBackColor = true;
            this.teacherAction.Click += new System.EventHandler(this.teacherAction_Click);
            // 
            // studentAction
            // 
            this.studentAction.Location = new System.Drawing.Point(12, 184);
            this.studentAction.Name = "studentAction";
            this.studentAction.Size = new System.Drawing.Size(209, 84);
            this.studentAction.TabIndex = 1;
            this.studentAction.Text = "Student Action";
            this.studentAction.UseVisualStyleBackColor = true;
            // 
            // finalNode
            // 
            this.finalNode.Location = new System.Drawing.Point(92, 433);
            this.finalNode.Name = "finalNode";
            this.finalNode.Size = new System.Drawing.Size(209, 84);
            this.finalNode.TabIndex = 2;
            this.finalNode.Text = "Final Node";
            this.finalNode.UseVisualStyleBackColor = true;
            // 
            // classAction
            // 
            this.classAction.Location = new System.Drawing.Point(465, 433);
            this.classAction.Name = "classAction";
            this.classAction.Size = new System.Drawing.Size(209, 84);
            this.classAction.TabIndex = 3;
            this.classAction.Text = "Class Action";
            this.classAction.UseVisualStyleBackColor = true;
            // 
            // decisionAction
            // 
            this.decisionAction.Location = new System.Drawing.Point(566, 184);
            this.decisionAction.Name = "decisionAction";
            this.decisionAction.Size = new System.Drawing.Size(209, 84);
            this.decisionAction.TabIndex = 4;
            this.decisionAction.Text = "Decision";
            this.decisionAction.UseVisualStyleBackColor = true;
            // 
            // ContextMenuAddNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(787, 529);
            this.Controls.Add(this.decisionAction);
            this.Controls.Add(this.classAction);
            this.Controls.Add(this.finalNode);
            this.Controls.Add(this.studentAction);
            this.Controls.Add(this.teacherAction);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ContextMenuAddNode";
            this.Text = "ContextMenuAddNode";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button teacherAction;
        private System.Windows.Forms.Button studentAction;
        private System.Windows.Forms.Button finalNode;
        private System.Windows.Forms.Button classAction;
        private System.Windows.Forms.Button decisionAction;
    }
}