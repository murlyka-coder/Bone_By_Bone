using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bone_By_Bone
{
    public partial class SettingForm : UserControl
    {
        public event EventHandler BackClicked;
        public event EventHandler SettingsClicked;

        public SettingForm()
        {
            InitializeComponent();
        }


        private void btnFromSettings_Click(object sender, EventArgs e)
        {
            BackClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnSendFeedback_Click(object sender, EventArgs e)
        {
            txtFeedback.Clear();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void chkPlayMusic_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
