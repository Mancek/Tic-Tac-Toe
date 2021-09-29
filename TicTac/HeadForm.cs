using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTac
{
    public partial class HeadForm : Form
    {
        static readonly string workingDirectory = Environment.CurrentDirectory;
        static readonly string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
        private readonly Game TicTac;

        public HeadForm()
        {
            InitializeComponent();

            MsgBox box = new MsgBox("~ ~ Choose who plays first ~ ~\n\'X\' or \'O\'", "X", "O");
            TicTac = new Game(box.Choice);
            UpdateScore();
        }

        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void TitlePanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, 0x112, 0xf012, 0);
            }
        }

        private void SetImage(Button b) => b.Image = TicTac.NrPlayer == 1 ?
            Image.FromFile($"{projectDirectory}//Images//X.png") :
            Image.FromFile($"{projectDirectory}//Images//O.png");

        private void SetImageIfNotTaken(int pos, Button b)
        {
            if (!TicTac.IsTaken(pos))
            {
                SetImage(b);
            }
        }

        private void ClearImage(Button b) =>  b.Image = null;

        private void ClearImageIfNotTaken(int pos, Button b)
        {
            if (!TicTac.IsTaken(pos))
            {
                ClearImage(b);
            }
        }

        private void UpdateScore()
        {
            label2.Text = $"X won: {TicTac.Result[0]}";
            label3.Text = $"O won: {TicTac.Result[1]}";
        }

        private void ResetGame()
        {
            Controls.OfType<Button>().ToList().ForEach(ClearImage);
            TicTac.Reset();
            TicTac.SetPlayer();
        }

        private void Outcome(int pos, Button b)
        {
            int outcome = TicTac.Move(pos);
            if (outcome == 1 || outcome == 2)
            {
                SetImage(b);
                UpdateScore();

                string text = outcome == 1 ? "\'X\' won!\nDo you want to play again?" : "\'O\' won!\nDo you want to play again?";
                MsgBox box = new MsgBox(text, "Yes", "No");

                if (box.Choice == 1)
                {
                    ResetGame();
                }
                else
                {
                    Application.Exit();
                }
            }
            else if (outcome == 3)
            {
                SetImage(b);
                new MsgBox("There is no winner in this one!", "Ok");
                ResetGame();
            }
            else if (outcome == 4)
            {
                new MsgBox("You played impossible move!", "Ok");
            }
            else
            {
                SetImage(b);
                TicTac.SetPlayer();
            }
        }

        // Mouse click button events
        private void Button1_MouseClick(object sender, MouseEventArgs e) => Outcome(1, sender as Button);

        private void Button2_MouseClick(object sender, MouseEventArgs e) => Outcome(2, sender as Button);

        private void Button3_MouseClick(object sender, MouseEventArgs e) => Outcome(3, sender as Button);

        private void Button4_MouseClick(object sender, MouseEventArgs e) => Outcome(4, sender as Button);

        private void Button5_MouseClick(object sender, MouseEventArgs e) => Outcome(5, sender as Button);

        private void Button6_MouseClick(object sender, MouseEventArgs e) => Outcome(6, sender as Button);

        private void Button7_MouseClick(object sender, MouseEventArgs e) => Outcome(7, sender as Button);

        private void Button8_MouseClick(object sender, MouseEventArgs e) => Outcome(8, sender as Button);

        private void Button9_MouseClick(object sender, MouseEventArgs e) => Outcome(9, sender as Button);

        private void Button10_Click(object sender, EventArgs e) => Application.Exit();

        // Mouser hover button events
        private void Button1_MouseHover(object sender, EventArgs e) => SetImageIfNotTaken(1, sender as Button);

        private void Button2_MouseHover(object sender, EventArgs e) => SetImageIfNotTaken(2, sender as Button);

        private void Button3_MouseHover(object sender, EventArgs e) => SetImageIfNotTaken(3, sender as Button);

        private void Button4_MouseHover(object sender, EventArgs e) => SetImageIfNotTaken(4, sender as Button);

        private void Button5_MouseHover(object sender, EventArgs e) => SetImageIfNotTaken(5, sender as Button);

        private void Button6_MouseHover(object sender, EventArgs e) => SetImageIfNotTaken(6, sender as Button);

        private void Button7_MouseHover(object sender, EventArgs e) => SetImageIfNotTaken(7, sender as Button);

        private void Button8_MouseHover(object sender, EventArgs e) => SetImageIfNotTaken(8, sender as Button);

        private void Button9_MouseHover(object sender, EventArgs e) => SetImageIfNotTaken(9, sender as Button);

        // Mouse Leave button events
        private void Button1_MouseLeave(object sender, EventArgs e) => ClearImageIfNotTaken(1,sender as Button);

        private void Button2_MouseLeave(object sender, EventArgs e) => ClearImageIfNotTaken(2, sender as Button);

        private void Button3_MouseLeave(object sender, EventArgs e) => ClearImageIfNotTaken(3, sender as Button);

        private void Button4_MouseLeave(object sender, EventArgs e) => ClearImageIfNotTaken(4, sender as Button);

        private void Button5_MouseLeave(object sender, EventArgs e) => ClearImageIfNotTaken(5, sender as Button);

        private void Button6_MouseLeave(object sender, EventArgs e) => ClearImageIfNotTaken(6, sender as Button);

        private void Button7_MouseLeave(object sender, EventArgs e) => ClearImageIfNotTaken(7, sender as Button);

        private void Button8_MouseLeave(object sender, EventArgs e) => ClearImageIfNotTaken(8, sender as Button);

        private void Button9_MouseLeave(object sender, EventArgs e) => ClearImageIfNotTaken(9, sender as Button);
    }
}
