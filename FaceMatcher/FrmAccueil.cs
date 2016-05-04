using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;

namespace FaceMatcher {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //byte[] attach = System.IO.File.ReadAllBytes(@"‪C:\Users\laot.r\Pictures\Capture.PNG");
            //var m = new Mail("sec.entrepriseautomatic@gmail.com",
            // Chiffrement.base64EnTexte("YXplcnR5dWlvcDc1MzA="),
            // "dsientrepriselambda@gmail.com");
            //m.Envoyer("Objet", "Corps", @"C:\Users\laot.r\Downloads\jpeg-home.jpg");



        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = true;
                pictureBox1.Load("http://10.10.130.60:8080/shot.jpg");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Load("http://10.10.130.60:8080/shot.jpg");
        }
    }
}
