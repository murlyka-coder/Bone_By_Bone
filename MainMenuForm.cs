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
    public partial class MainMenuForm : UserControl
    {

        public event EventHandler StartGameClicked;

        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartGameClicked?.Invoke(this, EventArgs.Empty);

        }
    }
}
