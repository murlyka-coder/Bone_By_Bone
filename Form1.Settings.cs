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



            // запоминание предыдущего меню
            if (panelGame.Visible) previousPanel = "game";
            else if (panelLevelSelect.Visible) previousPanel = "levels";
            else previousPanel = "menu";

        }


        private void btnFromSettings_Click(object sender, EventArgs e)
        {
            panelSettings.Visible = false;
            btnSettings.Visible = true;


            // возврат к сохранённой предыдущей панели
            if (previousPanel == "game") panelGame.Visible = true;
            else if (previousPanel == "levels") panelLevelSelect.Visible = true;
            else
            {
                label1.Visible = true;
                button1.Visible = true;
            }


        }


        private void btnSendFeedback_Click(object sender, EventArgs e)
        {
            txtFeedback.Clear();
        }



    }
}
