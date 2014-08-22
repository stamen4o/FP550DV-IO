using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FP3530;
using System.IO.Ports;
using System.Text.RegularExpressions;

namespace service550dv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            textBox2.TextAlign = HorizontalAlignment.Right;
        }
        public int comPortSelected = 1;
        public int speedPortSelected = 9600;
         private void button3_Click(object sender, EventArgs e)
        {
            string exitCode = "";
            string cashSum = "";
            string servIn = "";
            string servOut = "";
            try
            {
                FP3530.CS_BGR_FP550_D_KL fp = new CS_BGR_FP550_D_KLClass();
                fp.INIT_Ex1(comPortSelected,speedPortSelected);
                fp.CMD_70_0_0(textBox2.Text.ToString(),ref exitCode,ref cashSum,ref servIn,ref servOut);
                if (exitCode == "P")
                {
                    double cash = Convert.ToDouble(cashSum);
                    double servI = Convert.ToDouble(servIn);
                    double servO = Convert.ToDouble(servOut);
                    MessageBox.Show("Операцията е успешна\n" + "Касова наличност : " + cash / 100 + " лв.\n" + "Общо въведени за деня: " + servI / 100 + " лв.\n" + "Общо изведени за деня: " + servO / 100 + " лв.\n");
                }
                else
                {
                    double cash = Convert.ToDouble(cashSum);
                    double servI = Convert.ToDouble(servIn);
                    double servO = Convert.ToDouble(servOut);
                    MessageBox.Show("Операцията е неуспешна\n" + "Касова наличност : " + cash / 100 + " лв.\n" + "Общо въведени за деня: " + servI / 100 + " лв.\n" + "Общо изведени за деня: " + servO / 100 + " лв.\n");
                }
                

            }
            catch (Exception)
            {
                MessageBox.Show("Проблем с въвеждането");
            }    
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            FP3530.CS_BGR_FP550_D_KL fp = new CS_BGR_FP550_D_KLClass();
            try
            {
                string comPort = System.IO.File.ReadAllText(@"C:\FP550DV-IO\FP550DV-IO\comNumber.txt");
                comPortSelected = Convert.ToInt32(comPort);
            }
            catch
            {
                MessageBox.Show(@"Проблем със номера за COM порт.");
            }
            try 
	        {
                string comSpeed = System.IO.File.ReadAllText(@"C:\FP550DV-IO\FP550DV-IO\comSpeed.txt");
                speedPortSelected = Convert.ToInt32(comSpeed);
	        }
	        catch (Exception)
	        {
		        MessageBox.Show(@"Проблем със скороста за COM порт.");
	        }
            string printerName = "";
            string fwRev = "";
            string fwDate = "";
            string fwTime = "";
            string chK = "";
            string sW = "";
            string serial = "";
            string fm = "";
            try
            {
                fp.INIT_Ex1(comPortSelected,speedPortSelected);
                fp.CMD_90_0_0(ref printerName, ref fwRev, ref fwDate, ref fwTime, ref chK, ref sW, ref serial, ref fm);
                label3.Text = serial;
                if (serial != null)
                {
                    pictureBox1.Visible = true;
                    pictureBox2.Visible = false;
                }
                else
                {
                    pictureBox2.Visible = true;
                    pictureBox1.Visible = false;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Проверете данни за COM порт.");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string exitCode = "";
            string cashSum = "";
            string servIn = "";
            string servOut = "";
            try
            {
                FP3530.CS_BGR_FP550_D_KL fp = new CS_BGR_FP550_D_KLClass();
                fp.INIT_Ex1(comPortSelected, speedPortSelected);
                fp.CMD_70_0_0("-" + textBox2.Text.ToString(), ref exitCode, ref cashSum, ref servIn, ref servOut);
                if (exitCode == "P")
                {
                    double cash = Convert.ToDouble(cashSum);
                    double servI = Convert.ToDouble(servIn);
                    double servO = Convert.ToDouble(servOut);
                    MessageBox.Show("Операцията е успешна\n" + "Касова наличност : " + cash / 100 + " лв.\n" + "Общо въведени за деня: " + servI / 100 + " лв.\n" + "Общо изведени за деня: " + servO / 100 + " лв.\n");
                }
                else
                {
                    double cash = Convert.ToDouble(cashSum);
                    double servI = Convert.ToDouble(servIn);
                    double servO = Convert.ToDouble(servOut);
                    MessageBox.Show("Операцията е неуспешна\n" + "Касова наличност : " + cash / 100 + " лв.\n" + "Общо въведени за деня: " + servI / 100 + " лв.\n" + "Общо изведени за деня: " + servO / 100 + " лв.\n");
                }
                

            }
            catch (Exception)
            {
                MessageBox.Show("Проблем с извеждането");
            }    
        }

        private void дневенXОтчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string closure = "";
            string fmTotal = "";
            string totA = "";
            string totB = "";
            string totC = "";
            string totD = "";
            string totE = "";
            string totF = "";
            string totG = "";
            string totH = "";
            FP3530.CS_BGR_FP550_D_KL fp = new CS_BGR_FP550_D_KLClass();
            fp.INIT_Ex1(comPortSelected, speedPortSelected);
            fp.CMD_69_0_0("2", "N", ref closure, ref fmTotal, ref totA, ref totB, ref totC, ref totD, ref totE, ref totF, ref totG, ref totH);
        }

        private void дневенZОтчетToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string closure = "";
            string fmTotal = "";
            string totA = "";
            string totB = "";
            string totC = "";
            string totD = "";
            string totE = "";
            string totF = "";
            string totG = "";
            string totH = "";
            FP3530.CS_BGR_FP550_D_KL fp = new CS_BGR_FP550_D_KLClass();
            fp.INIT_Ex1(comPortSelected, speedPortSelected);
            fp.CMD_69_0_0("0", "", ref closure, ref fmTotal, ref totA, ref totB, ref totC, ref totD, ref totE, ref totF, ref totG, ref totH);
        }

        private void диагностикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
             FP3530.CS_BGR_FP550_D_KL fp = new CS_BGR_FP550_D_KLClass();
            try
            {
                string comPort = System.IO.File.ReadAllText(@"C:\FP550DV-IO\FP550DV-IO\comNumber.txt");
                comPortSelected = Convert.ToInt32(comPort);
            }
            catch
            {
                MessageBox.Show(@"Проблем със номера за COM порт.");
            }
            try 
	        {
                string comSpeed = System.IO.File.ReadAllText(@"C:\FP550DV-IO\FP550DV-IO\comSpeed.txt");
                speedPortSelected = Convert.ToInt32(comSpeed);
	        }
	        catch (Exception)
	        {
                MessageBox.Show(@"Проблем със скороста за COM порт.");
	        }
            try
            {
                fp.INIT_Ex1(comPortSelected,speedPortSelected);
                fp.CMD_71_0_0();
            }
            catch (Exception)
            {
                MessageBox.Show("Проблем с комуникацията");
            }            
        }
    }         
}
    


