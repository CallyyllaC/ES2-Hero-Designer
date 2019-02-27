using ES2_Hero_Designer.Export;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ES2_Hero_Designer
{
    public partial class Skills : Form
    {
        private string dir;
        private CustomSkill Output;
        List<List<HeroSkill>> skillGroups;
        List<string> groups;

        public Skills(string dir, List<HeroSkill> allSkills)
        {
            InitializeComponent();
            this.dir = dir;
            TB_Skill.Enabled = false;
            TB_SimDesc.Enabled = false;

            skillGroups = allSkills.GroupBy(c => c.DescriptorReference).Select(c => c.ToList()).ToList();
            groups = new List<string>();
            for (int i = 0; i < skillGroups.Count; i++)
            {
                groups.Add(skillGroups[i][0].DescriptorReference);
            }

            CB_SkillFile.Items.AddRange(groups.ToArray());
        }

        public Skills(string dir, CustomSkill loaded)
        {
            InitializeComponent();
            Output = loaded;
            this.dir = dir;
            TB_Skill.Enabled = true;
            TB_SimDesc.Enabled = true;

            CB_SkillFile.Enabled = false;
            CB_SkillFile_Skill.Enabled = false;
            CB_Skill_Custom.Checked = true;

            TB_SimDesc.Text = loaded.SimDescXML;
            TB_Skill.Text = loaded.SkillXML;
            TB_Skill_Name.Text = loaded.Name;
        }

        private void CB_Skill_Custom_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_Skill_Custom.Checked == true)
            {
                this.TB_Skill.Enabled = true;
                this.TB_SimDesc.Enabled = true;
            }
            else
            {
                this.TB_Skill.Enabled = false;
                this.TB_SimDesc.Enabled = false;
            }
        }

        private void Skills_Load(object sender, EventArgs e)
        {
        }

        private void CB_SkillFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (groups.Contains(CB_SkillFile.Text))
            {
                CB_SkillFile_Skill.Items.Clear();
                var tmp = skillGroups.Where(x => x[0].DescriptorReference == CB_SkillFile.Text).Single();
                CB_SkillFile_Skill.Items.AddRange(tmp.ToArray());
                CB_SkillFile_Skill.Enabled = true;
            }
            else
            {
                CB_SkillFile_Skill.Enabled = false;
            }
        }

        private void CB_SkillFile_Skill_SelectedIndexChanged(object sender, EventArgs e)
        {
            HeroSkill tmp = CB_SkillFile_Skill.SelectedItem as HeroSkill;
            TB_Skill.Text = FileStructure.FormatXml(tmp.XML);
            TB_SimDesc.Text = FileStructure.FormatXml(tmp.SimDesc);
            SkillChanged();
        }


        private void BT_Skill_Add_Click(object sender, EventArgs e)
        {
            if (TB_Skill.Text == "")
            {
                MessageBox.Show($"Skill box must not be empty", "Error, Missing Skill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(TB_Skill_Name.Text == "")
            {
                MessageBox.Show($"Name must not be empty", "Error, Missing name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Output = new CustomSkill { Name = TB_Skill_Name.Text, SkillXML = TB_Skill.Text, SimDescXML = TB_SimDesc.Text };
            this.Close();
        }
        public CustomSkill Returnable()
        {
            if (Output == null)
            {
                MessageBox.Show($"Skill box must not be empty", "Error, Missing Skill", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            return Output;
        }

        private void SkillChanged()
        {
            if (CB_Skill_Custom.Checked == false)
            {
                string y = TB_SimDesc.Text;
                string x = TB_Skill.Text;

                //x.Replace(@"<HeroSimulationDescriptorReference Name=""HeroSkillComplete"" />", "");
                x = Regex.Replace(x, @"(?<!Hero)(SimulationDescriptorReference Name="")\w+", "${1}%SkillName%");
                x = Regex.Replace(x, @"(Levels="")\d+","${1}1");

                y = Regex.Replace(y, @"(SimulationDescriptor Name="")\w+","${1}%SkillName%");

                TB_SimDesc.Text = y;
                TB_Skill.Text = x;
            }
        }

        private void TB_Skill_Name_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
