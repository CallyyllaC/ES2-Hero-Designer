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
            this.components = new System.ComponentModel.Container();
            this.GrpBox_Skill = new System.Windows.Forms.GroupBox();
            this.LB_Icon = new System.Windows.Forms.Label();
            this.CB_Icon = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_Desc = new System.Windows.Forms.TextBox();
            this.BT_Save = new System.Windows.Forms.Button();
            this.BT_Level_Add = new System.Windows.Forms.Button();
            this.BT_Level_Remove = new System.Windows.Forms.Button();
            this.CB_Levels = new System.Windows.Forms.ComboBox();
            this.LB_Level = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_SimDesc = new System.Windows.Forms.TextBox();
            this.LB_Skill_SimDesc = new System.Windows.Forms.Label();
            this.LB_Skill_Skill = new System.Windows.Forms.Label();
            this.LB_Skill_Template = new System.Windows.Forms.Label();
            this.LB_Skill_Name = new System.Windows.Forms.Label();
            this.TB_Skill_Name = new System.Windows.Forms.TextBox();
            this.BT_Skill_Add = new System.Windows.Forms.Button();
            this.CB_SkillFile_Skill = new System.Windows.Forms.ComboBox();
            this.CB_SkillFile = new System.Windows.Forms.ComboBox();
            this.CB_Skill_Custom = new System.Windows.Forms.CheckBox();
            this.TB_Skill = new System.Windows.Forms.TextBox();
            this.ToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.GrpBox_Skill.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpBox_Skill
            // 
            this.GrpBox_Skill.Controls.Add(this.LB_Icon);
            this.GrpBox_Skill.Controls.Add(this.CB_Icon);
            this.GrpBox_Skill.Controls.Add(this.label2);
            this.GrpBox_Skill.Controls.Add(this.TB_Desc);
            this.GrpBox_Skill.Controls.Add(this.BT_Save);
            this.GrpBox_Skill.Controls.Add(this.BT_Level_Add);
            this.GrpBox_Skill.Controls.Add(this.BT_Level_Remove);
            this.GrpBox_Skill.Controls.Add(this.CB_Levels);
            this.GrpBox_Skill.Controls.Add(this.LB_Level);
            this.GrpBox_Skill.Controls.Add(this.label1);
            this.GrpBox_Skill.Controls.Add(this.TB_SimDesc);
            this.GrpBox_Skill.Controls.Add(this.LB_Skill_SimDesc);
            this.GrpBox_Skill.Controls.Add(this.LB_Skill_Skill);
            this.GrpBox_Skill.Controls.Add(this.LB_Skill_Template);
            this.GrpBox_Skill.Controls.Add(this.LB_Skill_Name);
            this.GrpBox_Skill.Controls.Add(this.TB_Skill_Name);
            this.GrpBox_Skill.Controls.Add(this.BT_Skill_Add);
            this.GrpBox_Skill.Controls.Add(this.CB_SkillFile_Skill);
            this.GrpBox_Skill.Controls.Add(this.CB_SkillFile);
            this.GrpBox_Skill.Controls.Add(this.CB_Skill_Custom);
            this.GrpBox_Skill.Controls.Add(this.TB_Skill);
            this.GrpBox_Skill.Location = new System.Drawing.Point(13, 13);
            this.GrpBox_Skill.Name = "GrpBox_Skill";
            this.GrpBox_Skill.Size = new System.Drawing.Size(1239, 575);
            this.GrpBox_Skill.TabIndex = 0;
            this.GrpBox_Skill.TabStop = false;
            this.GrpBox_Skill.Text = "Skill";
            // 
            // LB_Icon
            // 
            this.LB_Icon.AutoSize = true;
            this.LB_Icon.Location = new System.Drawing.Point(6, 103);
            this.LB_Icon.Name = "LB_Icon";
            this.LB_Icon.Size = new System.Drawing.Size(31, 13);
            this.LB_Icon.TabIndex = 19;
            this.LB_Icon.Text = "Icon:";
            // 
            // CB_Icon
            // 
            this.CB_Icon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Icon.FormattingEnabled = true;
            this.CB_Icon.Location = new System.Drawing.Point(50, 100);
            this.CB_Icon.Name = "CB_Icon";
            this.CB_Icon.Size = new System.Drawing.Size(376, 21);
            this.CB_Icon.TabIndex = 18;
            this.CB_Icon.SelectedIndexChanged += new System.EventHandler(this.CB_Icon_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Description:";
            // 
            // TB_Desc
            // 
            this.TB_Desc.Location = new System.Drawing.Point(75, 45);
            this.TB_Desc.Name = "TB_Desc";
            this.TB_Desc.Size = new System.Drawing.Size(351, 20);
            this.TB_Desc.TabIndex = 16;
            // 
            // BT_Save
            // 
            this.BT_Save.Location = new System.Drawing.Point(6, 332);
            this.BT_Save.Name = "BT_Save";
            this.BT_Save.Size = new System.Drawing.Size(420, 23);
            this.BT_Save.TabIndex = 15;
            this.BT_Save.Text = "Save";
            this.BT_Save.UseVisualStyleBackColor = true;
            this.BT_Save.Click += new System.EventHandler(this.BT_Save_Click);
            // 
            // BT_Level_Add
            // 
            this.BT_Level_Add.Location = new System.Drawing.Point(222, 71);
            this.BT_Level_Add.Name = "BT_Level_Add";
            this.BT_Level_Add.Size = new System.Drawing.Size(99, 23);
            this.BT_Level_Add.TabIndex = 14;
            this.BT_Level_Add.Text = "Add Level";
            this.BT_Level_Add.UseVisualStyleBackColor = true;
            this.BT_Level_Add.Click += new System.EventHandler(this.BT_Level_Add_Click);
            // 
            // BT_Level_Remove
            // 
            this.BT_Level_Remove.Location = new System.Drawing.Point(327, 71);
            this.BT_Level_Remove.Name = "BT_Level_Remove";
            this.BT_Level_Remove.Size = new System.Drawing.Size(99, 23);
            this.BT_Level_Remove.TabIndex = 13;
            this.BT_Level_Remove.Text = "Remove Level";
            this.BT_Level_Remove.UseVisualStyleBackColor = true;
            this.BT_Level_Remove.Click += new System.EventHandler(this.BT_Level_Remove_Click);
            // 
            // CB_Levels
            // 
            this.CB_Levels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Levels.FormattingEnabled = true;
            this.CB_Levels.Location = new System.Drawing.Point(50, 72);
            this.CB_Levels.Name = "CB_Levels";
            this.CB_Levels.Size = new System.Drawing.Size(166, 21);
            this.CB_Levels.Sorted = true;
            this.CB_Levels.TabIndex = 12;
            this.CB_Levels.SelectedIndexChanged += new System.EventHandler(this.CB_Levels_SelectedIndexChanged);
            // 
            // LB_Level
            // 
            this.LB_Level.AutoSize = true;
            this.LB_Level.Location = new System.Drawing.Point(6, 76);
            this.LB_Level.Name = "LB_Level";
            this.LB_Level.Size = new System.Drawing.Size(36, 13);
            this.LB_Level.TabIndex = 11;
            this.LB_Level.Text = "Level:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(420, 33);
            this.label1.TabIndex = 10;
            this.label1.Text = "Only for people who know what theyre doing, this stops the program from automatic" +
    "ally renaming the variables so it is advised to disable it before adding the ski" +
    "ll";
            // 
            // TB_SimDesc
            // 
            this.TB_SimDesc.Enabled = false;
            this.TB_SimDesc.Location = new System.Drawing.Point(432, 315);
            this.TB_SimDesc.Multiline = true;
            this.TB_SimDesc.Name = "TB_SimDesc";
            this.TB_SimDesc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TB_SimDesc.Size = new System.Drawing.Size(801, 254);
            this.TB_SimDesc.TabIndex = 9;
            this.TB_SimDesc.WordWrap = false;
            // 
            // LB_Skill_SimDesc
            // 
            this.LB_Skill_SimDesc.AutoSize = true;
            this.LB_Skill_SimDesc.Location = new System.Drawing.Point(429, 299);
            this.LB_Skill_SimDesc.Name = "LB_Skill_SimDesc";
            this.LB_Skill_SimDesc.Size = new System.Drawing.Size(108, 13);
            this.LB_Skill_SimDesc.TabIndex = 8;
            this.LB_Skill_SimDesc.Text = "SimulationDescriptors";
            // 
            // LB_Skill_Skill
            // 
            this.LB_Skill_Skill.AutoSize = true;
            this.LB_Skill_Skill.Location = new System.Drawing.Point(432, 16);
            this.LB_Skill_Skill.Name = "LB_Skill_Skill";
            this.LB_Skill_Skill.Size = new System.Drawing.Size(51, 13);
            this.LB_Skill_Skill.TabIndex = 7;
            this.LB_Skill_Skill.Text = "Skill XML";
            // 
            // LB_Skill_Template
            // 
            this.LB_Skill_Template.AutoSize = true;
            this.LB_Skill_Template.Location = new System.Drawing.Point(6, 153);
            this.LB_Skill_Template.Name = "LB_Skill_Template";
            this.LB_Skill_Template.Size = new System.Drawing.Size(81, 13);
            this.LB_Skill_Template.TabIndex = 6;
            this.LB_Skill_Template.Text = "Skill Templates:";
            // 
            // LB_Skill_Name
            // 
            this.LB_Skill_Name.AutoSize = true;
            this.LB_Skill_Name.Location = new System.Drawing.Point(6, 22);
            this.LB_Skill_Name.Name = "LB_Skill_Name";
            this.LB_Skill_Name.Size = new System.Drawing.Size(38, 13);
            this.LB_Skill_Name.TabIndex = 5;
            this.LB_Skill_Name.Text = "Name:";
            // 
            // TB_Skill_Name
            // 
            this.TB_Skill_Name.Location = new System.Drawing.Point(75, 19);
            this.TB_Skill_Name.Name = "TB_Skill_Name";
            this.TB_Skill_Name.Size = new System.Drawing.Size(351, 20);
            this.TB_Skill_Name.TabIndex = 4;
            this.TB_Skill_Name.TextChanged += new System.EventHandler(this.TB_Skill_Name_TextChanged);
            // 
            // BT_Skill_Add
            // 
            this.BT_Skill_Add.Location = new System.Drawing.Point(6, 546);
            this.BT_Skill_Add.Name = "BT_Skill_Add";
            this.BT_Skill_Add.Size = new System.Drawing.Size(420, 23);
            this.BT_Skill_Add.TabIndex = 1;
            this.BT_Skill_Add.Text = "Add Skill(s) and Close";
            this.BT_Skill_Add.UseVisualStyleBackColor = true;
            this.BT_Skill_Add.Click += new System.EventHandler(this.BT_Skill_Add_Click);
            // 
            // CB_SkillFile_Skill
            // 
            this.CB_SkillFile_Skill.Enabled = false;
            this.CB_SkillFile_Skill.FormattingEnabled = true;
            this.CB_SkillFile_Skill.Location = new System.Drawing.Point(6, 196);
            this.CB_SkillFile_Skill.Name = "CB_SkillFile_Skill";
            this.CB_SkillFile_Skill.Size = new System.Drawing.Size(420, 21);
            this.CB_SkillFile_Skill.TabIndex = 3;
            this.CB_SkillFile_Skill.SelectedIndexChanged += new System.EventHandler(this.CB_SkillFile_Skill_SelectedIndexChanged);
            // 
            // CB_SkillFile
            // 
            this.CB_SkillFile.Enabled = false;
            this.CB_SkillFile.FormattingEnabled = true;
            this.CB_SkillFile.Location = new System.Drawing.Point(6, 169);
            this.CB_SkillFile.Name = "CB_SkillFile";
            this.CB_SkillFile.Size = new System.Drawing.Size(420, 21);
            this.CB_SkillFile.TabIndex = 2;
            this.CB_SkillFile.SelectedIndexChanged += new System.EventHandler(this.CB_SkillFile_SelectedIndexChanged);
            // 
            // CB_Skill_Custom
            // 
            this.CB_Skill_Custom.AutoSize = true;
            this.CB_Skill_Custom.Location = new System.Drawing.Point(9, 282);
            this.CB_Skill_Custom.Name = "CB_Skill_Custom";
            this.CB_Skill_Custom.Size = new System.Drawing.Size(83, 17);
            this.CB_Skill_Custom.TabIndex = 0;
            this.CB_Skill_Custom.Text = "Custom Skill";
            this.CB_Skill_Custom.UseVisualStyleBackColor = true;
            this.CB_Skill_Custom.CheckedChanged += new System.EventHandler(this.CB_Skill_Custom_CheckedChanged);
            // 
            // TB_Skill
            // 
            this.TB_Skill.Enabled = false;
            this.TB_Skill.Location = new System.Drawing.Point(432, 32);
            this.TB_Skill.Multiline = true;
            this.TB_Skill.Name = "TB_Skill";
            this.TB_Skill.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TB_Skill.Size = new System.Drawing.Size(801, 254);
            this.TB_Skill.TabIndex = 1;
            this.TB_Skill.WordWrap = false;
            // 
            // Skills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1264, 600);
            this.Controls.Add(this.GrpBox_Skill);
            this.Name = "Skills";
            this.Text = "Skills";
            this.GrpBox_Skill.ResumeLayout(false);
            this.GrpBox_Skill.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpBox_Skill;
        private System.Windows.Forms.ComboBox CB_SkillFile_Skill;
        private System.Windows.Forms.ComboBox CB_SkillFile;
        private System.Windows.Forms.CheckBox CB_Skill_Custom;
        private System.Windows.Forms.Button BT_Skill_Add;
        private System.Windows.Forms.Label LB_Skill_Template;
        private System.Windows.Forms.Label LB_Skill_Name;
        private System.Windows.Forms.Label LB_Skill_SimDesc;
        private System.Windows.Forms.Label LB_Skill_Skill;
        public System.Windows.Forms.TextBox TB_Skill;
        public System.Windows.Forms.TextBox TB_SimDesc;
        public System.Windows.Forms.TextBox TB_Skill_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LB_Level;
        private System.Windows.Forms.Button BT_Level_Add;
        private System.Windows.Forms.Button BT_Level_Remove;
        private System.Windows.Forms.ComboBox CB_Levels;
        private System.Windows.Forms.Button BT_Save;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox TB_Desc;
        private System.Windows.Forms.Label LB_Icon;
        private System.Windows.Forms.ComboBox CB_Icon;
        private System.Windows.Forms.ToolTip ToolTips;
    }
}