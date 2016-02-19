using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FileShredder
{
    public partial class QueryExec : Form
    {
        public QueryExec()
        {
            InitializeComponent();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "XYZ File";
        }


        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = ".txt";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Text = "C:\\Windows";
        }

    }
}
