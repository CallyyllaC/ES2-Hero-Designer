using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ES2_Hero_Designer
{
    public partial class SkillTrees : Form
    {
        string name = "";
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
            TB_Alhpa.Text = "255";
            TB_Red.Text = "0";
            TB_Green.Text = "0";
            TB_Blue.Text = "0";
        }

        public SkillTrees(SkillTree loaded, CustomSkill[] skills)
        {
            InitializeComponent();
            this.TB_Name.Text = loaded.Name;
            this.TB_Desc.Text = loaded.Desc;
            this.skills = skills;
            Output = loaded;
            table.Columns.Add("Level", typeof(int));
            table.Columns.Add("Skill", typeof(CustomSkill));
            foreach (var item in loaded.Skills)
            {
                table.Rows.Add(item.Item1, item.Item2);
            }
            TBL_Skilltree.DataSource = table;
            CB_Custom_Skills.Items.AddRange(skills);
            TB_Alhpa.Text = loaded.Alpha;
            TB_Red.Text = loaded.Red;
            TB_Green.Text = loaded.Green;
            TB_Blue.Text = loaded.Blue;
        }

        public SkillTree Returnable()
        {
            if (TB_Name == null)
            {
                MessageBox.Show($"Skill tree requires a name", "Error, No name given", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            var tmp = TBL_Skilltree.DataSource as DataTable;
            Output = new SkillTree() { Name = TB_Name.Text, Desc = TB_Desc.Text, Red = TB_Red.Text, Green = TB_Green.Text, Blue = TB_Blue.Text, Alpha = TB_Alhpa.Text};
            Output.Skills = new List<Tuple<int, CustomSkill>>();
            foreach (DataRow item in tmp.Rows)
            {
                Output.Skills.Add(new Tuple<int, CustomSkill>(int.Parse(item.ItemArray[0].ToString()), item.ItemArray[1] as CustomSkill));
            }
            return Output;
        }

        private void BT_Add_Click(object sender, EventArgs e)
        {
            table.Rows.Add(int.Parse(TB_Level.Text), skills.Where(x => x.ToString() == CB_Custom_Skills.SelectedItem.ToString()).Single());
            CB_Delete.Items.Clear();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                CB_Delete.Items.Add(i.ToString());
            }
        }

        private void BT_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                table.Rows.RemoveAt(int.Parse(CB_Delete.Text));
                CB_Delete.Items.Clear();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    CB_Delete.Items.Add(i.ToString());
                }
            }
            catch { }
        }

        private void TB_Name_TextChanged(object sender, EventArgs e)
        {
            var regx = new Regex("[^a-zA-Z0-9 _]");
            if (regx.IsMatch(TB_Name.Text))
            {
                TB_Name.Text = name.Replace(" ", "_");
            }
            else
            {
                name = TB_Name.Text;
            }
            TB_Name.Focus();
            TB_Name.SelectionStart = TB_Name.Text.Length;
        }
    }
}
