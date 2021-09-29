using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTac
{
    public partial class MsgBox : Form
    {
        public MsgBox(string text, string yes, string no)
        {
            InitializeComponent();
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = false;
            button1.Visible = true;
            button2.Visible = true;
            button3.Visible = false;
            label1.Text = text;
            button1.Text = yes;
            button2.Text = no;
            ShowDialog();
        }

        public MsgBox(string text, string ok)
        {
            InitializeComponent();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = true;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = true;
            label1.Text = text;
            button3.Text = ok;
            ShowDialog();
        }

        public int Choice { get; private set; }

        private void Button1_Click(object sender, EventArgs e)
        {
            Choice = 1;
            Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Choice = 2;
            Close();
        }

        private void Button3_Click(object sender, EventArgs e) => Close();
    }
}
