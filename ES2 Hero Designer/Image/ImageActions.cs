using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ES2_Hero_Designer.Image
{
    class ImageActions
    {
        public static void Load(PictureBox picbox)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Title = "Open Image",
                Filter = "png files (*.png)|*.png"
            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                picbox.Image = new Bitmap(dlg.FileName);
            }

            dlg.Dispose();
        }
    }
}