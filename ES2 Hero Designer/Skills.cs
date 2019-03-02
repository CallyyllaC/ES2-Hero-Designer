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
        string name = "";
        private string dir;
        private CustomSkill Output;
        List<List<HeroSkill>> skillGroups;
        List<string> groups;

        public Skills(string dir, List<HeroSkill> allSkills, List<string> Icons)
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

            CB_Icon.Items.AddRange(Icons.ToArray());

            CB_Levels.Items.Add(new SkillLevel() { Level = "1" });
            CB_Levels.SelectedIndex = 0;
            CB_SkillFile.Items.AddRange(groups.ToArray());

            ToolTips.AutoPopDelay = 5000;
            ToolTips.InitialDelay = 250;
            ToolTips.ReshowDelay = 100;
            ToolTips.SetToolTip(this.CB_Icon, this.CB_Icon.Text);
            ToolTips.SetToolTip(this.CB_SkillFile, this.CB_SkillFile.Text);
            ToolTips.SetToolTip(this.CB_SkillFile_Skill, this.CB_SkillFile_Skill.Text);
        }

        public Skills(string dir, CustomSkill loaded, List<HeroSkill> allSkills, List<string> Icons)
        {
            InitializeComponent();
            Output = loaded;
            this.dir = dir;
            TB_Skill.Enabled = true;
            TB_SimDesc.Enabled = true;

            CB_SkillFile.Enabled = false;
            CB_SkillFile_Skill.Enabled = false;
            CB_Skill_Custom.Checked = true;

            skillGroups = allSkills.GroupBy(c => c.DescriptorReference).Select(c => c.ToList()).ToList();
            groups = new List<string>();
            for (int i = 0; i < skillGroups.Count; i++)
            {
                groups.Add(skillGroups[i][0].DescriptorReference);
            }

            CB_Icon.Items.AddRange(Icons.ToArray());
            CB_SkillFile.Items.AddRange(groups.ToArray());

            CB_Levels.Items.AddRange(loaded.Levels.ToArray());
            CB_Levels.SelectedIndex = 0;
            TB_Skill_Name.Text = loaded.Name;
            TB_Desc.Text = loaded.Desc;
            CB_Icon.Text = loaded.Icon;

            ToolTips.AutoPopDelay = 5000;
            ToolTips.InitialDelay = 250;
            ToolTips.ReshowDelay = 100;
            ToolTips.SetToolTip(this.CB_Icon, this.CB_Icon.Text);
            ToolTips.SetToolTip(this.CB_SkillFile, this.CB_SkillFile.Text);
            ToolTips.SetToolTip(this.CB_SkillFile_Skill, this.CB_SkillFile_Skill.Text);
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

        private void CB_SkillFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolTips.SetToolTip(this.CB_SkillFile, this.CB_SkillFile.Text);
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
            ToolTips.SetToolTip(this.CB_SkillFile_Skill, this.CB_SkillFile_Skill.Text);
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
            };
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
                
                x = Regex.Replace(x, @"(?<!Hero)(SimulationDescriptorReference Name="")\w+", "${1}%SkillName%");
                x = Regex.Replace(x, @"(Levels="")\d+", "${1}" + CB_Levels.Text);

                y = Regex.Replace(y, @"(SimulationDescriptor Name="")\w+","${1}%SkillName%");

                TB_SimDesc.Text = y;
                TB_Skill.Text = x;
            }
        }

        private void BT_Level_Add_Click(object sender, EventArgs e)
        {
            int count = 1;
            for (int i = 0; i < CB_Levels.Items.Count; i++)
            {
                var level = CB_Levels.Items[i] as SkillLevel;
                if (level.Level.Trim() != count.ToString().Trim())
                {
                    CB_Levels.Items.Add(new SkillLevel { Level = $"{count}" });
                    return;
                }
                count++;
            }

            var Level = CB_Levels.Items[CB_Levels.Items.Count - 1] as SkillLevel;
            CB_Levels.Items.Add(new SkillLevel { Level = $"{int.Parse(Level.Level) + 1}" });
        }

        private void BT_Level_Remove_Click(object sender, EventArgs e)
        {
            try
            {
                var tmp = CB_Levels.SelectedIndex;

                if (tmp == 0)
                {
                    MessageBox.Show($"You cant remove level 1", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CB_Levels.Items.RemoveAt(tmp);

                try { CB_Levels.SelectedIndex = tmp - 1; }
                catch
                {
                    try { CB_Levels.SelectedIndex = tmp + 1; }
                    catch { }
                }
                
            }
            catch
            {
                MessageBox.Show($"ComboBox must have a valid entry to delete", "Error, Missing item", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CB_Levels_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = CB_Levels.SelectedItem as SkillLevel;
            TB_SimDesc.Text = item.SimDescXML;
            TB_Skill.Text = item.SkillXML;

            if (CB_Levels.SelectedItem.GetType() == typeof(SkillLevel))
            {
                CB_SkillFile.Enabled = true;
            }
            else
            {
                CB_SkillFile.Enabled = false;
                CB_SkillFile_Skill.Enabled = false;
            }
        }

        private void BT_Save_Click(object sender, EventArgs e)
        {
            var pos = CB_Levels.SelectedIndex;
            var item = CB_Levels.SelectedItem as SkillLevel;
            CB_Levels.Items.RemoveAt(pos);
            CB_Levels.Items.Add(new SkillLevel() { Level = item.Level, SimDescXML = TB_SimDesc.Text, SkillXML = TB_Skill.Text });
            List<SkillLevel> levels = new List<SkillLevel>();
            levels.AddRange(CB_Levels.Items.OfType<SkillLevel>());
            Output = new CustomSkill() { Name = TB_Skill_Name.Text, Desc = TB_Desc.Text, Levels = levels, Icon = CB_Icon.Text };

            try
            {
                CB_Levels.SelectedIndex = pos;
            }
            catch
            {
                CB_Levels.SelectedIndex = 0;
            }
        }

        private void TB_Skill_Name_TextChanged(object sender, EventArgs e)
        {
            var regx = new Regex("[^a-zA-Z0-9 _]");
            if (regx.IsMatch(TB_Skill_Name.Text))
            {
                TB_Skill_Name.Text = name.Replace(" ", "_");
            }
            else
            {
                name = TB_Skill_Name.Text.Replace(" ", "_");
            }
            TB_Skill_Name.Focus();
            TB_Skill_Name.SelectionStart = TB_Skill_Name.Text.Length;
        }

        private void CB_Icon_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToolTips.SetToolTip(this.CB_Icon, this.CB_Icon.Text);
        }
    }
}
