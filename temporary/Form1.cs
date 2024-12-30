using System.Windows.Forms;

namespace temporary
{
    public partial class Form1 : Form
    {
        private Rectangle originalFormSize;
        private List<Rectangle> originalRectaglesList = new List<Rectangle>(); // Contains original controls as rectangles
        private List<Control> controls = new List<Control>();
        private Control c;
        private Rectangle r;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            //foreach (Control control in this.Controls)
            //{
            //    control.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            //}


            for (int i = 0; i < controls.Count; i++)
            {
                resizeControl(originalRectaglesList[i], controls[i]);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // takes the form's size on load
            originalFormSize = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height); 
            
            controls.Add(button1);
            controls.Add(button2);
            controls.Add(button3);
            foreach (Control c in controls)
            {
                originalRectaglesList.Add(getMeasurements(c));
            }
        }

        private Rectangle getMeasurements(Control c)
        {
            Rectangle rectangle = new Rectangle(c.Location.X, c.Location.Y, c.Width, c.Height);
            return rectangle;
        }

        private void resizeControl(Rectangle r, Control c)
        {
            float xRatio = (float)(this.Width) / (float)(originalFormSize.Width);
            float yRatio = (float)(this.Height) / (float)(originalFormSize.Height);

            int newX = (int)(r.Location.X * xRatio);
            int newY = (int)(r.Location.Y * yRatio);

            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
        }
    }
}