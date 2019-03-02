namespace ES2_Hero_Designer
{
    partial class SkillTrees
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SkillTrees));
            this.BT_Add = new System.Windows.Forms.Button();
            this.TBL_Skilltree = new System.Windows.Forms.DataGridView();
            this.CB_Custom_Skills = new System.Windows.Forms.ComboBox();
            this.TB_Level = new System.Windows.Forms.TextBox();
            this.LB_Skill = new System.Windows.Forms.Label();
            this.LB_Level = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_Delete = new System.Windows.Forms.ComboBox();
            this.BT_Delete = new System.Windows.Forms.Button();
            this.TB_Name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_Desc = new System.Windows.Forms.TextBox();
            this.TB_Red = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LB_Red = new System.Windows.Forms.Label();
            this.LB_Green = new System.Windows.Forms.Label();
            this.LB_Blue = new System.Windows.Forms.Label();
            this.LB_Alphla = new System.Windows.Forms.Label();
            this.TB_Green = new System.Windows.Forms.TextBox();
            this.TB_Blue = new System.Windows.Forms.TextBox();
            this.TB_Alhpa = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.TBL_Skilltree)).BeginInit();
            this.SuspendLayout();
            // 
            // BT_Add
            // 
            this.BT_Add.Location = new System.Drawing.Point(687, 89);
            this.BT_Add.Name = "BT_Add";
            this.BT_Add.Size = new System.Drawing.Size(101, 23);
            this.BT_Add.TabIndex = 17;
            this.BT_Add.Text = "Add Skill";
            this.BT_Add.UseVisualStyleBackColor = true;
            this.BT_Add.Click += new System.EventHandler(this.BT_Add_Click);
            // 
            // TBL_Skilltree
            // 
            this.TBL_Skilltree.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TBL_Skilltree.Location = new System.Drawing.Point(15, 147);
            this.TBL_Skilltree.Name = "TBL_Skilltree";
            this.TBL_Skilltree.Size = new System.Drawing.Size(773, 291);
            this.TBL_Skilltree.TabIndex = 19;
            // 
            // CB_Custom_Skills
            // 
            this.CB_Custom_Skills.FormattingEnabled = true;
            this.CB_Custom_Skills.Location = new System.Drawing.Point(198, 89);
            this.CB_Custom_Skills.Name = "CB_Custom_Skills";
            this.CB_Custom_Skills.Size = new System.Drawing.Size(483, 21);
            this.CB_Custom_Skills.TabIndex = 20;
            // 
            // TB_Level
            // 
            this.TB_Level.Location = new System.Drawing.Point(57, 90);
            this.TB_Level.Name = "TB_Level";
            this.TB_Level.Size = new System.Drawing.Size(100, 20);
            this.TB_Level.TabIndex = 21;
            // 
            // LB_Skill
            // 
            this.LB_Skill.AutoSize = true;
            this.LB_Skill.Location = new System.Drawing.Point(163, 94);
            this.LB_Skill.Name = "LB_Skill";
            this.LB_Skill.Size = new System.Drawing.Size(29, 13);
            this.LB_Skill.TabIndex = 22;
            this.LB_Skill.Text = "Skill:";
            // 
            // LB_Level
            // 
            this.LB_Level.AutoSize = true;
            this.LB_Level.Location = new System.Drawing.Point(12, 94);
            this.LB_Level.Name = "LB_Level";
            this.LB_Level.Size = new System.Drawing.Size(36, 13);
            this.LB_Level.TabIndex = 23;
            this.LB_Level.Text = "Level:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(488, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Delete Row:";
            // 
            // CB_Delete
            // 
            this.CB_Delete.FormattingEnabled = true;
            this.CB_Delete.Location = new System.Drawing.Point(560, 118);
            this.CB_Delete.Name = "CB_Delete";
            this.CB_Delete.Size = new System.Drawing.Size(121, 21);
            this.CB_Delete.TabIndex = 25;
            // 
            // BT_Delete
            // 
            this.BT_Delete.Location = new System.Drawing.Point(688, 118);
            this.BT_Delete.Name = "BT_Delete";
            this.BT_Delete.Size = new System.Drawing.Size(100, 23);
            this.BT_Delete.TabIndex = 26;
            this.BT_Delete.Text = "Delete";
            this.BT_Delete.UseVisualStyleBackColor = true;
            this.BT_Delete.Click += new System.EventHandler(this.BT_Delete_Click);
            // 
            // TB_Name
            // 
            this.TB_Name.Location = new System.Drawing.Point(81, 10);
            this.TB_Name.Name = "TB_Name";
            this.TB_Name.Size = new System.Drawing.Size(707, 20);
            this.TB_Name.TabIndex = 27;
            this.TB_Name.TextChanged += new System.EventHandler(this.TB_Name_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Description:";
            // 
            // TB_Desc
            // 
            this.TB_Desc.Location = new System.Drawing.Point(81, 37);
            this.TB_Desc.Name = "TB_Desc";
            this.TB_Desc.Size = new System.Drawing.Size(707, 20);
            this.TB_Desc.TabIndex = 30;
            // 
            // TB_Red
            // 
            this.TB_Red.Location = new System.Drawing.Point(297, 63);
            this.TB_Red.Name = "TB_Red";
            this.TB_Red.Size = new System.Drawing.Size(87, 20);
            this.TB_Red.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Colour:";
            // 
            // LB_Red
            // 
            this.LB_Red.AutoSize = true;
            this.LB_Red.Location = new System.Drawing.Point(261, 66);
            this.LB_Red.Name = "LB_Red";
            this.LB_Red.Size = new System.Drawing.Size(30, 13);
            this.LB_Red.TabIndex = 33;
            this.LB_Red.Text = "Red:";
            // 
            // LB_Green
            // 
            this.LB_Green.AutoSize = true;
            this.LB_Green.Location = new System.Drawing.Point(390, 66);
            this.LB_Green.Name = "LB_Green";
            this.LB_Green.Size = new System.Drawing.Size(39, 13);
            this.LB_Green.TabIndex = 34;
            this.LB_Green.Text = "Green:";
            // 
            // LB_Blue
            // 
            this.LB_Blue.AutoSize = true;
            this.LB_Blue.Location = new System.Drawing.Point(528, 66);
            this.LB_Blue.Name = "LB_Blue";
            this.LB_Blue.Size = new System.Drawing.Size(31, 13);
            this.LB_Blue.TabIndex = 35;
            this.LB_Blue.Text = "Blue:";
            // 
            // LB_Alphla
            // 
            this.LB_Alphla.AutoSize = true;
            this.LB_Alphla.Location = new System.Drawing.Point(658, 66);
            this.LB_Alphla.Name = "LB_Alphla";
            this.LB_Alphla.Size = new System.Drawing.Size(37, 13);
            this.LB_Alphla.TabIndex = 36;
            this.LB_Alphla.Text = "Alpha:";
            // 
            // TB_Green
            // 
            this.TB_Green.Location = new System.Drawing.Point(435, 63);
            this.TB_Green.Name = "TB_Green";
            this.TB_Green.Size = new System.Drawing.Size(87, 20);
            this.TB_Green.TabIndex = 37;
            // 
            // TB_Blue
            // 
            this.TB_Blue.Location = new System.Drawing.Point(565, 63);
            this.TB_Blue.Name = "TB_Blue";
            this.TB_Blue.Size = new System.Drawing.Size(87, 20);
            this.TB_Blue.TabIndex = 38;
            // 
            // TB_Alhpa
            // 
            this.TB_Alhpa.Location = new System.Drawing.Point(701, 63);
            this.TB_Alhpa.Name = "TB_Alhpa";
            this.TB_Alhpa.Size = new System.Drawing.Size(87, 20);
            this.TB_Alhpa.TabIndex = 39;
            // 
            // SkillTrees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TB_Alhpa);
            this.Controls.Add(this.TB_Blue);
            this.Controls.Add(this.TB_Green);
            this.Controls.Add(this.LB_Alphla);
            this.Controls.Add(this.LB_Blue);
            this.Controls.Add(this.LB_Green);
            this.Controls.Add(this.LB_Red);
            this.Controls.Add(this.TB_Red);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TB_Desc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_Name);
            this.Controls.Add(this.BT_Delete);
            this.Controls.Add(this.CB_Delete);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LB_Level);
            this.Controls.Add(this.LB_Skill);
            this.Controls.Add(this.TB_Level);
            this.Controls.Add(this.CB_Custom_Skills);
            this.Controls.Add(this.TBL_Skilltree);
            this.Controls.Add(this.BT_Add);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SkillTrees";
            this.Text = "SkillTree";
            ((System.ComponentModel.ISupportInitialize)(this.TBL_Skilltree)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BT_Add;
        private System.Windows.Forms.DataGridView TBL_Skilltree;
        private System.Windows.Forms.ComboBox CB_Custom_Skills;
        private System.Windows.Forms.TextBox TB_Level;
        private System.Windows.Forms.Label LB_Skill;
        private System.Windows.Forms.Label LB_Level;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CB_Delete;
        private System.Windows.Forms.Button BT_Delete;
        private System.Windows.Forms.TextBox TB_Name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_Desc;
        private System.Windows.Forms.TextBox TB_Red;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LB_Red;
        private System.Windows.Forms.Label LB_Green;
        private System.Windows.Forms.Label LB_Blue;
        private System.Windows.Forms.Label LB_Alphla;
        private System.Windows.Forms.TextBox TB_Green;
        private System.Windows.Forms.TextBox TB_Blue;
        private System.Windows.Forms.TextBox TB_Alhpa;
    }
}