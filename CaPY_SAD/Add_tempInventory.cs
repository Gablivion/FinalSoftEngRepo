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
    public partial class Add_tempInventory : Form
    {
        public Form previousform { get; set; }

        public Add_tempInventory()
        {
            InitializeComponent();
        }

        private void quitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Add_tempInventory_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Add_tempInventory_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Add_tempInventory_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
            previousform.Show();
        }
    }
}
