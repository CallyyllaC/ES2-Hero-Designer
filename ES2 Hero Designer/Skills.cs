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
    public partial class Skills : Form
    {
        public Skills()
        {
            InitializeComponent();
            this.TB_Skill.Enabled = false;
        }

        private void CB_Skill_Custom_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_Skill_Custom.Checked == true)
            {
                this.TB_Skill.Enabled = true;
            }
            else
            {
                this.TB_Skill.Enabled = false;
            }
        }
    }
}
