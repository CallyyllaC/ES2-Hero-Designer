namespace ES2_Hero_Designer
{
    partial class Skills
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TB_Skill = new System.Windows.Forms.TextBox();
            this.CB_Skill_Custom = new System.Windows.Forms.CheckBox();
            this.CB_SkillFile = new System.Windows.Forms.ComboBox();
            this.CB_SkillFile_Skill = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CB_SkillFile_Skill);
            this.groupBox1.Controls.Add(this.CB_SkillFile);
            this.groupBox1.Controls.Add(this.CB_Skill_Custom);
            this.groupBox1.Controls.Add(this.TB_Skill);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(875, 575);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Skill";
            // 
            // TB_Skill
            // 
            this.TB_Skill.Enabled = false;
            this.TB_Skill.Location = new System.Drawing.Point(432, 19);
            this.TB_Skill.Multiline = true;
            this.TB_Skill.Name = "TB_Skill";
            this.TB_Skill.Size = new System.Drawing.Size(437, 550);
            this.TB_Skill.TabIndex = 1;
            // 
            // CB_Skill_Custom
            // 
            this.CB_Skill_Custom.AutoSize = true;
            this.CB_Skill_Custom.Location = new System.Drawing.Point(7, 75);
            this.CB_Skill_Custom.Name = "CB_Skill_Custom";
            this.CB_Skill_Custom.Size = new System.Drawing.Size(83, 17);
            this.CB_Skill_Custom.TabIndex = 0;
            this.CB_Skill_Custom.Text = "Custom Skill";
            this.CB_Skill_Custom.UseVisualStyleBackColor = true;
            this.CB_Skill_Custom.CheckedChanged += new System.EventHandler(this.CB_Skill_Custom_CheckedChanged);
            // 
            // CB_SkillFile
            // 
            this.CB_SkillFile.FormattingEnabled = true;
            this.CB_SkillFile.Location = new System.Drawing.Point(6, 20);
            this.CB_SkillFile.Name = "CB_SkillFile";
            this.CB_SkillFile.Size = new System.Drawing.Size(420, 21);
            this.CB_SkillFile.TabIndex = 2;
            // 
            // CB_SkillFile_Skill
            // 
            this.CB_SkillFile_Skill.Enabled = false;
            this.CB_SkillFile_Skill.FormattingEnabled = true;
            this.CB_SkillFile_Skill.Location = new System.Drawing.Point(7, 48);
            this.CB_SkillFile_Skill.Name = "CB_SkillFile_Skill";
            this.CB_SkillFile_Skill.Size = new System.Drawing.Size(419, 21);
            this.CB_SkillFile_Skill.TabIndex = 3;
            // 
            // Skills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.groupBox1);
            this.Name = "Skills";
            this.Text = "Skills";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CB_SkillFile_Skill;
        private System.Windows.Forms.ComboBox CB_SkillFile;
        private System.Windows.Forms.CheckBox CB_Skill_Custom;
        private System.Windows.Forms.TextBox TB_Skill;
    }
}