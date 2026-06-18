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

        private void btnSettings_Click(object sender, EventArgs e)
        {
            panelSettings.Visible = true;
            btnSettings.Visible = false;
        }

        private void btnFromSettings_Click(object sender, EventArgs e)
        {
            panelSettings.Visible = false;
            btnSettings.Visible = true;
            BackClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnSendFeedback_Click(object sender, EventArgs e)
        {
            txtFeedback.Clear();
        }
    }
}
