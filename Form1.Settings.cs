using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bone_By_Bone
{
    public partial class Form1
    {
        private void btnSettings_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            button1.Visible = false;
            btnSettings.Visible = false;
            panelSettings.Visible = true;
        }


        private void btnFromSettings_Click(object sender, EventArgs e)
        {
            panelSettings.Visible = false;
            label1.Visible = true;
            button1.Visible = true;
            btnSettings.Visible = true;
        }


        private void btnSendFeedback_Click(object sender, EventArgs e)
        {
            txtFeedback.Clear();
        }



    }
}
