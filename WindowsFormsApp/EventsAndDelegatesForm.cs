using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class EventsAndDelegatesForm : Form
    {
        public EventsAndDelegatesForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Button clicked 1");
        }

        private void SecondMessageBox(object sender, EventArgs e)
        {
            MessageBox.Show("Button clicked 2");
        }
    }
}
