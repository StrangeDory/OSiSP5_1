using System.Windows.Forms;

namespace OSiSP5_1
{
    public partial class Form1 : Form
    {
        int x0, y0;
        int width, height;
        bool isShiftDown;

        public Form1()
        {
            InitializeComponent();
            this.MouseWheel += new MouseEventHandler(MouseWheelScroll);
            x0 = y0 = 0;
            width = Resource1.icons8_аниме_эмодзи_100.Width;
            height = Resource1.icons8_аниме_эмодзи_100.Height;
            isShiftDown = false;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            isShiftDown = false;
            
        }

        void increaseX(int delta)
        {
            x0 += delta;
            x0 = (x0 < 0) ? 0 : x0;
            x0 = (x0 + width > ClientSize.Width) ? ClientSize.Width - width : x0;
            Invalidate();
        }

        void increaseY(int delta)
        {
            y0 += delta;
            y0 = (y0 < 0) ? 0 : y0;
            y0 = (y0 + height > ClientSize.Height) ? ClientSize.Height - height : y0;
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(Resource1.icons8_аниме_эмодзи_100, x0, y0);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            isShiftDown = true;
            if (e.KeyCode == Keys.Down)
            {
                increaseY(5);
                correctY();
            }
            if (e.KeyCode == Keys.Up)
            {
                increaseY(-5);
                correctY();
            }
            if (e.KeyCode == Keys.Right)
            {
                increaseX(5);
                correctX();
            }
            if (e.KeyCode == Keys.Left)
            {
                increaseX(-5);
                correctX();
            }
        }

        void correctY()
        {
            if (y0 == 0) y0 += 50;
            if (y0 == ClientSize.Height - height) y0 -= 50;
            Invalidate();
        }

        void correctX()
        {
            if (x0 == 0) x0 += 50;
            if (x0 == ClientSize.Width - width) x0 -= 50;
            Invalidate();
        }

        void MouseWheelScroll(object sender, MouseEventArgs e)
        {
            if (isShiftDown)
            {
                increaseX(e.Delta);
                correctX();
            }
            else
            {
                increaseY(e.Delta);
                correctY();
            }
        }
    }
}
