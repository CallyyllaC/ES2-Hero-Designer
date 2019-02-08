using ES2_Hero_Designer.Export;
using ES2_Hero_Designer.Image;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ES2_Hero_Designer
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Cb_SkillTree2.Items.AddRange(Cb_SkillTree1.Items.Cast<Object>().ToArray());
            Cb_SkillTree3.Items.AddRange(Cb_SkillTree1.Items.Cast<Object>().ToArray());
            ToolTips.AutoPopDelay = 5000;
            ToolTips.InitialDelay = 250;
            ToolTips.ReshowDelay = 100;
            ToolTips.SetToolTip(this.PicBox_GUILarge, "Recomended Image Properties: Format: PNG, Width: 360px, Height: 180px");
            ToolTips.SetToolTip(this.PicBox_GUIMedium, "Recomended Image Properties: Format: PNG, Width: 180px, Height: 240px");
            ToolTips.SetToolTip(this.PicBox_GUIMood, "Recomended Image Properties: Format: PNG, Width: 1324px, Height: 712px");
            ToolTips.SetToolTip(this.PicBox_ModIcon, "Recomended Image Properties: Width: 480px, Height: 480px");

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
            var folderBrowserDialog1 = new FolderBrowserDialog();
            
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folderName = folderBrowserDialog1.SelectedPath+"\\";
                FileStructure.CreateFolders(folderName, this.Tb_WsTitle.Text);
                FileStructure.CreateFiles(folderName, this.Tb_WsTitle.Text, this.Tb_Name.Text, this.Tb_Description.Text, this.Tb_WsTitle.Text, this.Tb_WsDescription.Text, this.Tb_WsAuthor.Text, this.Tb_WsReleaseNotes.Text, this.Cb_Affinity.Text, this.Cb_Class.Text, this.Cb_Politics.Text, this.Cb_ShipDesign.Text, this.Cb_SkillTree1.Text, this.Cb_SkillTree2.Text, this.Cb_SkillTree3.Text, ImageToByteArray(this.PicBox_GUILarge.Image), ImageToByteArray(this.PicBox_GUIMedium.Image), ImageToByteArray(this.PicBox_GUIMood.Image), ImageToByteArray(this.PicBox_ModIcon.Image));
            }

        }

        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
            return ms.ToArray();
        }
    }
}
