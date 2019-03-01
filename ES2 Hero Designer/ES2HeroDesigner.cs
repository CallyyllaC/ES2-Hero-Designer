using ES2_Hero_Designer.Export;
using ES2_Hero_Designer.Image;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ES2_Hero_Designer
{
    public partial class ES2_Hero_Designer : Form
    {
        private string name = null;
        List<HeroSkill> allSkills = null;
        List<string> Icons = null;
        public ES2_Hero_Designer()
        {
            InitializeComponent();

            try
            {
                LastSes lst;
                FileStream fs = new FileStream("LastSession.dat", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                lst = bf.Deserialize(fs) as LastSes;
                fs.Close();
                TB_GameDir_Dir.Text = lst.Dir;
                Tb_WsAuthor.Text = lst.WSAuth;
                CLB_Skills.Items.AddRange(lst.Skills);
                CLB_Skill_Trees.Items.AddRange(lst.Skilltrees);
                foreach (SkillTree item in CLB_Skill_Trees.Items)
                {
                    Cb_SkillTree1.Items.Add(item.Name);
                    Cb_SkillTree2.Items.Add(item.Name);
                    Cb_SkillTree3.Items.Add(item.Name);
                }
            }
            catch (Exception e)
            {
                
                if (File.Exists("LastSession.dat"))
                {
                    MessageBox.Show($"Unable to load previous data (Maybe from an older version), data will not be loaded. Please restart the application. \n Error Msg: {e.Message}", "Warning, Data could not be loaded", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    File.Delete("LastSession.dat");
                }
                else
                {
                    MessageBox.Show($"Unable to find previous data, data will not be loaded", "Warning, Data could not be loaded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void Main_Load(object sender, EventArgs e)
        {
            ToolTips.AutoPopDelay = 5000;
            ToolTips.InitialDelay = 250;
            ToolTips.ReshowDelay = 100;
            ToolTips.SetToolTip(this.PicBox_GUILarge, "Recomended Image Properties: Format: PNG, Width: 360px, Height: 180px");
            ToolTips.SetToolTip(this.PicBox_GUIMedium, "Recomended Image Properties: Format: PNG, Width: 180px, Height: 240px");
            ToolTips.SetToolTip(this.PicBox_GUIMood, "Recomended Image Properties: Format: PNG, Width: 1324px, Height: 712px");
            ToolTips.SetToolTip(this.PicBox_ModIcon, "Recomended Image Properties: Width: 480px, Height: 480px");
            ToolTips.SetToolTip(this.Tb_Name, "Letters a-z, numbers 0-9 and spaces only, no special characters");
            ToolTips.SetToolTip(this.TB_GameDir_Dir, "Same place the game exe is located");
            ToolTips.SetToolTip(this.Cb_Politics, "1 = Industrialist, 2 = Scientists, 3 = Pacifists, 4 = Ecologists, 5 = Religious, 6 = Militarists");
        }

        private void PicBox_GUILarge_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ImageActions.Load(this.PicBox_GUILarge);
        }

        private void PicBox_GUIMedium_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ImageActions.Load(this.PicBox_GUIMedium);
        }

        private void PicBox_GUIMood_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ImageActions.Load(this.PicBox_GUIMood);
        }

        private void PicBox_ModIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ImageActions.Load(this.PicBox_ModIcon);
        }

        private void Bt_Save_Click(object sender, EventArgs e)
        {
            try
            {
                LastSes lst = null;
                if (CLB_Skills.Items.Count < 1 && CLB_Skill_Trees.Items.Count < 1)
                {
                    lst = new LastSes() { Dir = TB_GameDir_Dir.Text, WSAuth = Tb_WsAuthor.Text, Skills = new CustomSkill[0], Skilltrees = new SkillTree[0] };
                }
                else if (CLB_Skill_Trees.Items.Count < 1)
                {
                    lst = new LastSes() { Dir = TB_GameDir_Dir.Text, WSAuth = Tb_WsAuthor.Text, Skills = CLB_Hero_Skills.Items.OfType<CustomSkill>().ToArray(), Skilltrees = new SkillTree[0] };
                }
                else if (CLB_Skills.Items.Count < 1)
                {
                    lst = new LastSes() { Dir = TB_GameDir_Dir.Text, WSAuth = Tb_WsAuthor.Text, Skills = new CustomSkill[0], Skilltrees = CLB_Skill_Trees.Items.OfType<SkillTree>().ToArray() };
                }
                else
                {
                    lst = new LastSes() { Dir = TB_GameDir_Dir.Text, WSAuth = Tb_WsAuthor.Text, Skills = CLB_Hero_Skills.Items.OfType<CustomSkill>().ToArray(), Skilltrees = CLB_Skill_Trees.Items.OfType<SkillTree>().ToArray() };
                }                
                FileStream fs = new FileStream("LastSession.dat", FileMode.Create);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, lst);
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was an error saving program data, current data input will be lost on restart \n Error Msg: {ex.Message}", "Error, Data could not be saved", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            var folderBrowserDialog1 = new FolderBrowserDialog();

            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {

                string folderName = folderBrowserDialog1.SelectedPath + "\\";

                byte[] Large;
                byte[] Medium;
                byte[] Mood;
                byte[] Mod;

                try
                {
                    Large = ImageToByteArray(this.PicBox_GUILarge.Image);
                }
                catch (Exception)
                {
                    Large = new byte[0];
                }
                try
                {
                    Medium = ImageToByteArray(this.PicBox_GUIMedium.Image);
                }
                catch (Exception)
                {
                    Medium = new byte[0];
                }
                try
                {
                    Mood = ImageToByteArray(this.PicBox_GUIMood.Image);
                }
                catch (Exception)
                {
                    Mood = new byte[0];
                }
                try
                {
                    Mod = ImageToByteArray(this.PicBox_ModIcon.Image);
                }
                catch (Exception)
                {
                    Mod = new byte[0];
                }


                FileStructure.CreateFolders(folderName, this.Tb_WsTitle.Text);
                FileStructure.CreateFiles(folderName, this.Tb_WsTitle.Text, this.Tb_Name.Text, this.Tb_Description.Text, this.Tb_WsTitle.Text, this.Tb_WsDescription.Text, this.Tb_WsAuthor.Text, this.Tb_WsReleaseNotes.Text, this.Cb_Affinity.Text, this.Cb_Class.Text, this.Cb_Politics.Text, this.Cb_ShipDesign.Text, this.Cb_SkillTree1.Text, this.Cb_SkillTree2.Text, this.Cb_SkillTree3.Text, Large, Medium, Mood, Mod, CLB_Hero_Skills.Items.OfType<CustomHeroSkill>().ToList(), CLB_Skill_Trees.Items.OfType<SkillTree>().ToList());
                if (CLB_HeroDebug.Items.Count != 0)
                {
                    File.WriteAllText($"{folderName}{this.Tb_WsTitle.Text}\\Simulation\\FactionTraits.xml", Data.GetXMLFactionDebug(TB_GameDir_Dir.Text, ref CLB_HeroDebug));
                }

            }

        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }

        private void Tb_Name_TextChanged(object sender, EventArgs e)
        {
            var regx = new Regex("[^a-zA-Z0-9 ]");
            if (regx.IsMatch(Tb_Name.Text))
            {
                Tb_Name.Text = name;
            }
            else
            {
                name = Tb_Name.Text;
                TB_HeroName.Text = Tb_Name.Text;
            }
            Tb_Name.Focus();
            Tb_Name.SelectionStart = Tb_Name.Text.Length;
        }

        private void TB_GameDir_Dir_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists($"{TB_GameDir_Dir.Text}EndlessSpace2.exe"))
            {
                LB_GameDir_Info.Text = "Found, Loading...";
                LB_GameDir_Info.ForeColor = Color.Orange;
            }
            else if (File.Exists($"{TB_GameDir_Dir.Text}\\EndlessSpace2.exe"))
            {
                TB_GameDir_Dir.Text = TB_GameDir_Dir.Text + "\\";
                LB_GameDir_Info.Text = "Found";
                LB_GameDir_Info.ForeColor = Color.Green;
            }
            else
            {
                LB_GameDir_Info.Text = "Error cannot find EndlessSpace2.exe to verify folder location";
                LB_GameDir_Info.ForeColor = Color.Red;
                GrpBox_Details.Enabled = false;
                GrpBox_Hero.Enabled = false;
                GrpBox_Images.Enabled = false;
                GrpBox_Skills.Enabled = false;
                GrpBox_Workshop.Enabled = false;
                GrpBox_HeroDebug.Enabled = false;
                GrpBox_HeroSkills.Enabled = false;
                GrpBox_SkillTrees.Enabled = false;
                Bt_Save.Enabled = false;
                return;
            }
            try
            {
                Cb_Affinity.Items.Clear();
                Cb_Class.Items.Clear();
                Cb_Politics.Items.Clear();
                Cb_ShipDesign.Items.Clear();
                Cb_SkillTree1.Items.Clear();
                Cb_SkillTree2.Items.Clear();
                Cb_SkillTree3.Items.Clear();
                CB_HeroFaction.Items.Clear();

                Cb_Affinity.Items.AddRange(Data.GetList(TB_GameDir_Dir.Text, "//HeroAffinityDefinition", "HeroAffinityDefinitions").ToArray());
                Cb_Class.Items.AddRange(Data.GetList(TB_GameDir_Dir.Text, "//HeroClassDefinition", "HeroClassDefinitions").ToArray());
                Cb_Politics.Items.AddRange(Data.GetPolitics(TB_GameDir_Dir.Text, "//HeroPoliticsDefinition", "HeroPoliticsDefinitions").ToArray());
                Cb_ShipDesign.Items.AddRange(Data.GetListShips(TB_GameDir_Dir.Text).ToArray());
                Cb_SkillTree1.Items.AddRange(Data.GetListSKillTree(TB_GameDir_Dir.Text).ToArray());
                Cb_SkillTree2.Items.AddRange(Cb_SkillTree1.Items.Cast<Object>().ToArray());
                Cb_SkillTree3.Items.AddRange(Cb_SkillTree1.Items.Cast<Object>().ToArray());
                CB_HeroFaction.Items.AddRange(Data.GetListFactionDebug(TB_GameDir_Dir.Text).ToArray());
                Icons = Data.GetIconList(TB_GameDir_Dir.Text);
                allSkills = Data.GetSkillList(TB_GameDir_Dir.Text);
                LB_GameDir_Info.Text = "Found";
                LB_GameDir_Info.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was an error loading the required files, please ensure the game was installed propperly \n {ex.Message}", "Error, Game data could not be loaded", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LB_GameDir_Info.Text = "There was an error loading the required files, please ensure the game was installed propperly";
                LB_GameDir_Info.ForeColor = Color.Red;
                return;
            }
            GrpBox_Details.Enabled = true;
            GrpBox_Hero.Enabled = true;
            GrpBox_Images.Enabled = true;
            GrpBox_Skills.Enabled = true;
            GrpBox_Workshop.Enabled = true;
            GrpBox_HeroDebug.Enabled = true;
            GrpBox_HeroSkills.Enabled = true;
            GrpBox_SkillTrees.Enabled = true;
            Bt_Save.Enabled = true;
        }

        private void TB_GameDir_Open_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog1 = new FolderBrowserDialog();

            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                TB_GameDir_Dir.Text = folderBrowserDialog1.SelectedPath + "\\";
            }
        }

        private void BT_AddHero_Click(object sender, EventArgs e)
        {
            if (CB_HeroFaction.Text != null && TB_HeroName.Text != null)
            {
                var trash = new List<DebugHero>();
                foreach (DebugHero item in CLB_HeroDebug.Items)
                {
                    if (item.Name == TB_HeroName.Text.Replace(" ", ""))
                    {
                        trash.Add(item);
                    }
                }
                foreach (var item in trash)
                {
                    CLB_HeroDebug.Items.Remove(item);
                }
                var tmp = new DebugHero() { Faction = CB_HeroFaction.Text, Name = TB_HeroName.Text.Replace(" ", "") };
                CLB_HeroDebug.Items.Add(tmp);
            }
        }

        private void BT_RemoveHero_Click(object sender, EventArgs e)
        {
            var trash = new List<DebugHero>();
            foreach (DebugHero item in CLB_HeroDebug.CheckedItems)
            {
                trash.Add(item);
            }
            foreach (var item in trash)
            {
                CLB_HeroDebug.Items.Remove(item);
            }
        }

        private void BT_AddSkill_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Skills skills = new Skills(TB_GameDir_Dir.Text, allSkills, Icons);
            skills.Show();
            skills.Focus();
            skills.FormClosing += Skills_FormClosing;
        }

        private void Skills_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = true;
            var skills = sender as Skills;
            if (skills.Returnable() == null)
            {
                return;
            }
            this.CLB_Skills.Items.Add(skills.Returnable(), false);
        }

        private void BT_RemoveSkill_Click(object sender, EventArgs e)
        {
            var trash = new List<CustomSkill>();
            foreach (CustomSkill item in CLB_Skills.CheckedItems)
            {
                trash.Add(item);
            }
            foreach (var item in trash)
            {
                CLB_Skills.Items.Remove(item);
            }
        }

        private void BT_Skill_Edit_Click(object sender, EventArgs e)
        {
            if (CLB_Skills.CheckedItems.Count > 1)
            {
                MessageBox.Show($"You can only edit one item at a time", "Error, Only select one item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (CLB_Skills.CheckedItems.Count < 1)
            {
                MessageBox.Show($"You must select an item to edit", "Error, Select atleast one item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                var item = CLB_Skills.CheckedItems.OfType<CustomSkill>().Single();
                CLB_Skills.Items.Remove(item);
                var tmp = new Skills(TB_GameDir_Dir.Text, item, allSkills, Icons);
                this.Visible = false;
                tmp.Show();
                tmp.Focus();
                tmp.FormClosing += Skills2_FormClosing;
            }
        }

        private void Skills2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = true;
            var skills = sender as Skills;
            if (skills.Returnable() == null)
            {
                return;
            }
            this.CLB_Skills.Items.Add(skills.Returnable(), false);
        }

        private void LB_Help_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("steam://url/CommunityFilePage/1648645386");
        }

        private void BT_AddHeroSkill_Click(object sender, EventArgs e)
        {
            if (CLB_Hero_Skills.Items.Count > 2)
            {
                MessageBox.Show($"Players have reported issues when using multiple heros with over 3 skills causing the games to crash", "Warning, Number of skills", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            try
            {
                var transfer = CLB_Skills.Items.OfType<CustomSkill>().Where(x => x.Name == TB_Hero_Skills.Text).Single();
                CLB_Hero_Skills.Items.Add(new CustomHeroSkill() { Name = transfer.Name, level = transfer.Levels.Where(x=> x.Level == TB_Hero_Level.Text).Single(), Desc = transfer.Desc, Icon = transfer.Icon });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"There was an error adding this skill to the hero \n Error Msg: {ex.Message}", "Error, Could not add skill", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CLB_Skills_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                var tmp = CLB_Skills.SelectedItem as CustomSkill;
                TB_Hero_Skills.Text = tmp.Name;
            }
            catch { }
        }

        private void BT_SkillTree_Remove_Click(object sender, EventArgs e)
        {
            var trash = new List<SkillTree>();
            foreach (SkillTree item in CLB_Skill_Trees.CheckedItems)
            {
                trash.Add(item);
            }
            foreach (var item in trash)
            {
                Cb_SkillTree1.Items.Remove(item.Name);
                Cb_SkillTree2.Items.Remove(item.Name);
                Cb_SkillTree3.Items.Remove(item.Name);
                CLB_Skill_Trees.Items.Remove(item);
            }
        }

        private void BT_SkillTree_Edit_Click(object sender, EventArgs e)
        {
            if (CLB_Skill_Trees.CheckedItems.Count > 1)
            {
                MessageBox.Show($"You can only edit one item at a time", "Error, Only select one item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (CLB_Skill_Trees.CheckedItems.Count < 1)
            {
                MessageBox.Show($"You must select an item to edit", "Error, Select atleast one item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                var item = CLB_Skill_Trees.CheckedItems.OfType<SkillTree>().Single();
                CLB_Skill_Trees.Items.Remove(item);
                var tmp = new SkillTrees(item, CLB_Skills.Items.OfType<CustomSkill>().ToArray());
                this.Visible = false;
                tmp.Show();
                tmp.Focus();
                tmp.FormClosing += SkillTree_FormClosing;
            }
        }

        private void BT_SkillTree_Add_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            SkillTrees SkillTrees = new SkillTrees(CLB_Skills.Items.OfType<CustomSkill>().ToArray());
            SkillTrees.Show();
            SkillTrees.Focus();
            SkillTrees.FormClosing += SkillTree_FormClosing;
        }

        private void SkillTree_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = true;
            var SkillTree = sender as SkillTrees;
            var tmp = SkillTree.Returnable();
            if (tmp == null)
            {
                return;
            }
            this.CLB_Skill_Trees.Items.Add(tmp, false);
            if (!Cb_SkillTree1.Items.Contains(tmp))
            {
                Cb_SkillTree1.Items.Add(tmp.Name);
                Cb_SkillTree2.Items.Add(tmp.Name);
                Cb_SkillTree3.Items.Add(tmp.Name);
            }
        }

        private void BT_RemoveHeroSkill_Click(object sender, EventArgs e)
        {
            var trash = new List<CustomHeroSkill>();
            foreach (CustomHeroSkill item in CLB_Hero_Skills.CheckedItems)
            {
                trash.Add(item);
            }
            foreach (var item in trash)
            {
                CLB_Hero_Skills.Items.Remove(item);
            }
        }
    }

    [Serializable]
    public class LastSes
    {
        private string dir;
        private string wSAuth;
        public CustomSkill[] Skills;
        public SkillTree[] Skilltrees;

        public string WSAuth { get => wSAuth; set => wSAuth = value.Trim(); }
        public string Dir { get => dir; set => dir = value.Trim(); }
    }
    public class DebugHero
    {
        private string faction;
        private string name;

        public string Name { get => name; set => name = value.Trim(); }
        public string Faction { get => faction; set => faction = value.Trim(); }

        public override string ToString()
        {
            return $"{Faction}: {Name}";
        }
    }
    public class HeroSkill
    {
        public string Name = "";
        public string Skill = "";
        public string DescriptorReference = "";
        public string SimDesc = "";
        public string XML = "";
        public override string ToString()
        {
            return Skill;
        }
    }
    [Serializable]
    public class SkillTree
    {
        private string name = "";
        private string desc = "";
        private string red = "0";
        private string green = "0";
        private string blue = "0";
        private string alpha = "255";

        public List<Tuple<int, CustomSkill>> Skills;

        public string Alpha { get => alpha; set => alpha = value.Trim(); }
        public string Blue { get => blue; set => blue = value.Trim(); }
        public string Red { get => red; set => red = value.Trim(); }
        public string Green { get => green; set => green = value.Trim(); }
        public string Desc { get => desc; set => desc = value.Trim(); }
        public string Name { get => name; set => name = value.Trim(); }

        public override string ToString()
        {
            return Name;
        }
    }
    [Serializable]
    public class CustomSkill
    {
        private string name = "";
        private string icon = "";
        private string desc = "";
        public List<SkillLevel> Levels;

        public string Desc { get => desc; set => desc = value.Trim(); }
        public string Icon { get => icon; set => icon = value.Trim(); }
        public string Name { get => name; set => name = value.Trim(); }

        public override string ToString()
        {
            return $"{Name} (Levels: {Levels.Count})";
        }
    }
    [Serializable]
    public class CustomHeroSkill
    {
        private string name;
        private string icon = "";
        private string desc = "";
        public SkillLevel level;

        public string Desc { get => desc; set => desc = value.Trim(); }
        public string Icon { get => icon; set => icon = value.Trim(); }
        public string Name { get => name; set => name = value.Trim(); }

        public override string ToString()
        {
            return $"{Name} (Level: {level.Level})";
        }
    }
    [Serializable]
    public class SkillLevel
    {
        private string level = "1";
        private string skillXML;
        private string simDescXML;

        public string SimDescXML { get => simDescXML; set => simDescXML = value.Trim(); }
        public string SkillXML { get => skillXML; set => skillXML = value.Trim(); }
        public string Level { get => level; set => level = value.Trim(); }

        public override string ToString()
        {
            return Level;
        }
    }
}
