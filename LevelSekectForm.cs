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
    public partial class LevelSekectForm : UserControl
    {
        public LevelSekectForm()
        {
            InitializeComponent();
        }

        public event EventHandler<int> LevelSelected;

        private void btnLevel1_Click(object sender, EventArgs e)
        {
            LevelSelected?.Invoke(this, 1);
        }

        private void btnLevel2_Click(object sender, EventArgs e)
        {
            LevelSelected?.Invoke(this, 2);
        }

        private void btnLevel3_Click(object sender, EventArgs e)
        {
            LevelSelected?.Invoke(this, 3);
        }
    }
}
