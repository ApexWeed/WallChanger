using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WallChanger
{
    public partial class AutoResolveForm : Form
    {
        DuplicateForm Parent;

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
