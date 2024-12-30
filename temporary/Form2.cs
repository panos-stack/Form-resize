using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// CRATE RECTANGLES, RESIZE THEM BY THE RATIO OF THE FORM AT RESIZE EVENT, PASS MESUREMENTS TO CONTROLS IN FORM

namespace temporary
{
    public partial class Form2 : Form
    {
        // Contains controls measurements on load
        private List<Rectangle> origCtr = new List<Rectangle>();
        Rectangle orFormSize;
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            //Width, Height, Location.X, Location.Y, contain the form's measurements on load
            orFormSize = new Rectangle(Location.X, Location.Y, Width, Height);

            foreach (Control c in Controls)
                // Takes the bounds of each control and adds it to the list
                origCtr.Add(c.Bounds);
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            for(int i = 0; i < Controls.Count; i++)
                resizeControl(origCtr[i], Controls[i]);
        }

        private void resizeControl(Rectangle r, Control c)
        {
            // Finds the form ratio at a given instance
            // Width and Height contain the form's measurements at the time the function is called
            float xRatio = (float)Width / (float)(orFormSize.Width);
            float yRatio = (float)Height / (float)(orFormSize.Height);

            c.Bounds = new Rectangle((int)(r.Location.X * xRatio), (int)(r.Location.Y * yRatio),
                                     (int)(r.Width * xRatio), (int)(r.Height * yRatio));
        }
    }
}
