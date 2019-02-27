using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ES2_Hero_Designer
{
    public partial class SkillTrees : Form
    {
        SkillTree Output = null;
        CustomSkill[] skills;
        DataTable table = new DataTable();

        public SkillTrees(CustomSkill[] skills)
        {
            InitializeComponent();
            this.skills = skills;
            table.Columns.Add("Level", typeof(int));
            table.Columns.Add("Skill", typeof(CustomSkill));
            TBL_Skilltree.DataSource = table;
            CB_Custom_Skills.Items.AddRange(skills);
        }

        public SkillTrees(SkillTree loaded, CustomSkill[] skills)
        {
            InitializeComponent();
            this.skills = skills;
            Output = loaded;
            table.Columns.Add("Level", typeof(int));
            table.Columns.Add("Skill", typeof(CustomSkill));
            foreach (var item in loaded.Skills)
            {
                table.Rows.Add(item.Key, item.Value);
            }
            TBL_Skilltree.DataSource = table;
            CB_Custom_Skills.Items.AddRange(skills);
        }

        public SkillTree Returnable()
        {
            if (Output == null)
            {
                MessageBox.Show($"Skilltree must not be empty", "Error, Missing Skilltree", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return Output;
        }

        private void BT_Add_Click(object sender, EventArgs e)
        {
            table.Rows.Add(int.Parse(TB_Level.Text), skills.Where(x=> x.Name == CB_Custom_Skills.Text).Single());
        }

        private void BT_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                table.Rows.RemoveAt(int.Parse(CB_Delete.Text));
            }
            catch { }
        }
    }
}
