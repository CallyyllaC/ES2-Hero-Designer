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
    public partial class Main : Form
    {
        private string name = null;
        public Main()
        {
            InitializeComponent();

            try
            {
                LastSes lst;
                FileStream fs = new FileStream("LastSession.dat", FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                lst = bf.Deserialize(fs) as LastSes;
                fs.Close();
                TB_GameDir_Dir.Text = lst.dir;
                Tb_WsAuthor.Text = lst.wsauth;
            }
            catch(Exception e)
            {}

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
            var lst = new LastSes() { dir = TB_GameDir_Dir.Text, wsauth = Tb_WsAuthor.Text };
            FileStream fs = new FileStream("LastSession.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, lst);
            fs.Close();

            var folderBrowserDialog1 = new FolderBrowserDialog();
            
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                
                string folderName = folderBrowserDialog1.SelectedPath+"\\";

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
                FileStructure.CreateFiles(folderName, this.Tb_WsTitle.Text, this.Tb_Name.Text, this.Tb_Description.Text, this.Tb_WsTitle.Text, this.Tb_WsDescription.Text, this.Tb_WsAuthor.Text, this.Tb_WsReleaseNotes.Text, this.Cb_Affinity.Text, this.Cb_Class.Text, this.Cb_Politics.Text, this.Cb_ShipDesign.Text, this.Cb_SkillTree1.Text, this.Cb_SkillTree2.Text, this.Cb_SkillTree3.Text, Large, Medium, Mood, Mod);
                if (CLB_HeroDebug.Items.Count !=0)
                {
                    File.WriteAllText($"{folderName}{this.Tb_WsTitle.Text}\\Simulation\\FactionTraits.xml",Data.GetXMLFactionDebug(TB_GameDir_Dir.Text, ref CLB_HeroDebug));
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
                LB_GameDir_Info.Text = "Found";
                LB_GameDir_Info.ForeColor = Color.Green;
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
                LB_GameDir_Info.ForeColor=Color.Red;
                GrpBox_Details.Enabled = false;
                GrpBox_Hero.Enabled = false;
                GrpBox_Images.Enabled = false;
                GrpBox_Skills.Enabled = false;
                GrpBox_Workshop.Enabled = false;
                GrpBox_HeroDebug.Enabled = false;
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
            }
            catch (Exception)
            {
                LB_GameDir_Info.Text = "There was an error loading the required files, please ensure the game was installed propperly";
                LB_GameDir_Info.ForeColor = Color.Red;
                return;
            }
            GrpBox_Details.Enabled = true;
            GrpBox_Hero.Enabled = true;
            GrpBox_Images.Enabled = true;
            //GrpBox_Skills.Enabled = true;
            GrpBox_Workshop.Enabled = true;
            GrpBox_HeroDebug.Enabled = true;
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
                    if (item.name == TB_HeroName.Text.Replace(" ", ""))
                    {
                        trash.Add(item);
                    }
                }
                foreach (var item in trash)
                {
                    CLB_HeroDebug.Items.Remove(item);
                }
                var tmp = new DebugHero() { faction = CB_HeroFaction.Text, name = TB_HeroName.Text.Replace(" ","") };
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
    }
    [Serializable]
    public class LastSes
    {
        public string dir;
        public string wsauth;
    }
    public class DebugHero
    {
        public string faction;
        public string name;

        public override string ToString()
        {
            return $"{faction}: {name}";
        }
    }
}
