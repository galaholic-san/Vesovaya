using System;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace WinApplication
{
    public partial class Form1 : Form
    {
        object obj = new object();
        static private IntPtr openvision = OpenVision.CreateOpenVision("IPCamera", "0", "D:\\Video\\video.avi", 15, "D:\\Development\\WinApplication\\WinApplication\\Cascades\\license_plate.xml");

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread display = new Thread(new ThreadStart(Display));
            display.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }


        public void Display()
        {
            while (true)
            {
                lock (obj)
                {
                    OpenVision.DisplayImageFrame(openvision);
                    Thread RecognizeThread = new Thread(new ThreadStart(Recognize));
                    RecognizeThread.Start();

                    RecognizeThread.Join();
                }
            }
        }

        public void Recognize()
        {
            OpenVision.PrepareImageTo(openvision);
            byte[] buff = new byte[30];
            OpenVision.RecognizePlate(openvision, buff);
            if (buff.Length != 0)
            {
                string line = Encoding.Default.GetString(buff);
                Debug.WriteLine(line);
            }
        }
    }
}
