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
            this.label2 = new System.Windows.Forms.Label();
            this.BT_Add = new System.Windows.Forms.Button();
            this.TBL_Skilltree = new System.Windows.Forms.DataGridView();
            this.CB_Custom_Skills = new System.Windows.Forms.ComboBox();
            this.TB_Level = new System.Windows.Forms.TextBox();
            this.LB_Skill = new System.Windows.Forms.Label();
            this.LB_Level = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CB_Delete = new System.Windows.Forms.ComboBox();
            this.BT_Delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TBL_Skilltree)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Select skill to add";
            // 
            // BT_Add
            // 
            this.BT_Add.Location = new System.Drawing.Point(687, 39);
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
            this.TBL_Skilltree.Location = new System.Drawing.Point(15, 117);
            this.TBL_Skilltree.Name = "TBL_Skilltree";
            this.TBL_Skilltree.Size = new System.Drawing.Size(773, 321);
            this.TBL_Skilltree.TabIndex = 19;
            // 
            // CB_Custom_Skills
            // 
            this.CB_Custom_Skills.FormattingEnabled = true;
            this.CB_Custom_Skills.Location = new System.Drawing.Point(198, 39);
            this.CB_Custom_Skills.Name = "CB_Custom_Skills";
            this.CB_Custom_Skills.Size = new System.Drawing.Size(483, 21);
            this.CB_Custom_Skills.TabIndex = 20;
            // 
            // TB_Level
            // 
            this.TB_Level.Location = new System.Drawing.Point(57, 40);
            this.TB_Level.Name = "TB_Level";
            this.TB_Level.Size = new System.Drawing.Size(100, 20);
            this.TB_Level.TabIndex = 21;
            // 
            // LB_Skill
            // 
            this.LB_Skill.AutoSize = true;
            this.LB_Skill.Location = new System.Drawing.Point(163, 43);
            this.LB_Skill.Name = "LB_Skill";
            this.LB_Skill.Size = new System.Drawing.Size(29, 13);
            this.LB_Skill.TabIndex = 22;
            this.LB_Skill.Text = "Skill:";
            // 
            // LB_Level
            // 
            this.LB_Level.AutoSize = true;
            this.LB_Level.Location = new System.Drawing.Point(15, 42);
            this.LB_Level.Name = "LB_Level";
            this.LB_Level.Size = new System.Drawing.Size(36, 13);
            this.LB_Level.TabIndex = 23;
            this.LB_Level.Text = "Level:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(488, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Delete Row:";
            // 
            // CB_Delete
            // 
            this.CB_Delete.FormattingEnabled = true;
            this.CB_Delete.Location = new System.Drawing.Point(560, 12);
            this.CB_Delete.Name = "CB_Delete";
            this.CB_Delete.Size = new System.Drawing.Size(121, 21);
            this.CB_Delete.TabIndex = 25;
            // 
            // BT_Delete
            // 
            this.BT_Delete.Location = new System.Drawing.Point(688, 12);
            this.BT_Delete.Name = "BT_Delete";
            this.BT_Delete.Size = new System.Drawing.Size(100, 23);
            this.BT_Delete.TabIndex = 26;
            this.BT_Delete.Text = "Delete";
            this.BT_Delete.UseVisualStyleBackColor = true;
            this.BT_Delete.Click += new System.EventHandler(this.BT_Delete_Click);
            // 
            // SkillTrees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BT_Delete);
            this.Controls.Add(this.CB_Delete);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LB_Level);
            this.Controls.Add(this.LB_Skill);
            this.Controls.Add(this.TB_Level);
            this.Controls.Add(this.CB_Custom_Skills);
            this.Controls.Add(this.TBL_Skilltree);
            this.Controls.Add(this.BT_Add);
            this.Controls.Add(this.label2);
            this.Name = "SkillTrees";
            this.Text = "SkillTree";
            ((System.ComponentModel.ISupportInitialize)(this.TBL_Skilltree)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BT_Add;
        private System.Windows.Forms.DataGridView TBL_Skilltree;
        private System.Windows.Forms.ComboBox CB_Custom_Skills;
        private System.Windows.Forms.TextBox TB_Level;
        private System.Windows.Forms.Label LB_Skill;
        private System.Windows.Forms.Label LB_Level;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CB_Delete;
        private System.Windows.Forms.Button BT_Delete;
    }
}