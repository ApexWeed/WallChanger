using System;
using System.Windows.Forms;

namespace WallChanger
{
    public partial class AutoResolveForm : Form
    {
        new DuplicateForm Parent;

        public AutoResolveForm(DuplicateForm Parent)
        {
            InitializeComponent();

            this.Parent = Parent;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {

        }

        public void UpdateProgress(int Current, int Total)
        {

        }

        public void Complete()
        {

        }
    }
}
