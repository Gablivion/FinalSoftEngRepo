using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaPY_SAD
{
    public partial class View_staff : Form
    {
        public Form previousform { get; set; }

        public View_staff()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            previousform.Show();
        }

        private void View_staff_Load(object sender, EventArgs e)
        {

        }

        private void editBtn_Click(object sender, EventArgs e)
        {
            firstnameTxt.Enabled = true;
            lastnameTxt.Enabled = true;
            middlenameTxt.Enabled = true;
            maleRadio.Enabled = true;
            femaleRadio.Enabled = true;
            bdayTxt.Enabled = true;
            addressTxt.Enabled = true;
            cnumTxt.Enabled = true;
            emailTxt.Enabled = true;
            positionCmb.Enabled = true;
            usernameTxt.Enabled = true;
            passwordTxt.Enabled = true;
            positionCmb.Enabled = true;
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void View_staff_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void View_staff_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void View_staff_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
