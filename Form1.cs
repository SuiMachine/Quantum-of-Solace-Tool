using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Collections.Generic;


namespace QuantumOfSolace
{
    public partial class Form1 : Form
    {
        // Base address value for pointers.
        int baseAddress = 0x10000000;

        // Other variables.
        System.Text.Encoding enc = System.Text.Encoding.UTF8;
        Process[] myProcess;
        string processName;
     
        float fov=85;
        int fps=90;
        int fullscreen = 1;
        byte balance = 0;

        float readFov = 0;
        int readFPS = 0;
        int readFullscreen = 0;
        byte readBalance = 0;
        int[] offsets = new int[] { 0x740 };

        int fovAddress = 0x01A37C98;
        int fpsAdresss = 0x1A36E50;
        int fullscreenAdresss = 0x13A74C4;
        int balanceAdresss = 0x20B1FBA;

        bool autoModeFOV;
        bool autoModeFPS;
        bool autoModeFullscreen;
        bool disableBalancing;

        string labelUrl = "www.pcgamingwiki.com";
        string DonateURL = "https://www.twitchalerts.com/donate/suicidemachine";


        /*------------------
        -- INITIALIZATION --
        ------------------*/
        public Form1()
        {
            InitializeComponent();
            processName = "JB_LiveEngine_s";
        }

        bool foundProcess = false;

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                myProcess = Process.GetProcessesByName(processName);
                if (myProcess.Length > 0)
                {
                    if (foundProcess == false)
                        System.Threading.Thread.Sleep(100);
                    foundProcess = true;
                }
                else
                {
                    // The game process has not been found, reseting values.
                    LB_Running.Text = "007: Quantum of Solace is NOT running";
                    LB_Running.ForeColor = Color.Red;
                    foundProcess = false;
                    ResetValues();
                }

                if (foundProcess)
                {
                    // The game is running, ready for memory reading.
                    LB_Running.Text = "007: Quantum of Solace is running";
                    LB_Running.ForeColor = Color.Green;

                    readFov = Trainer.ReadPointerFloat(myProcess, baseAddress + fovAddress, offsets);
                    readFPS = Trainer.ReadInteger(myProcess, baseAddress + fpsAdresss);
                    readFullscreen = Trainer.ReadInteger(myProcess, baseAddress + fullscreenAdresss);
                    readBalance = Trainer.ReadByte(myProcess, baseAddress + balanceAdresss);

                    L_fov.Text = readFov.ToString();
                    L_fps.Text = readFPS.ToString();
                    L_fullscreen.Text = readFullscreen.ToString();

                    if (autoModeFOV)
                        ChangeFov();
                    if (autoModeFPS)
                        ChangeFPS();
                    if (autoModeFullscreen)
                        ChangeFullscreen();
                    if (disableBalancing)
                        freezeBalance();
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        // Called when the game is not running or no mission is active.
        // Used to reset all the values.
        private void ResetValues()
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Timer.Start();
        }


        void ChangeFov()
        {
            if (fovAddress != 0x0000000 && foundProcess)
            {
                if (readFov != fov)
                    Trainer.WritePointerFloat(myProcess, baseAddress +fovAddress, offsets, fov);
            }
        }

        void ChangeFPS()
        {
            if (fpsAdresss != 0x0000000 && foundProcess)
            { 
                if(readFPS !=fps)
                    Trainer.WriteInteger(myProcess, baseAddress + fpsAdresss, fps);
            }
                
        }

        void ChangeFullscreen()
        {
            if (fullscreenAdresss != 0x0000000 && foundProcess)
            {
                if (readFullscreen !=fullscreen)
                    Trainer.WriteInteger(myProcess, baseAddress + fullscreenAdresss, fullscreen);
            }
        }

        void freezeBalance()
        {
            if (balanceAdresss != 0x0000000 && foundProcess)
            {
                if (readBalance != balance)
                    Trainer.WriteByte(myProcess, baseAddress + balanceAdresss, balance);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }


        // Lazy way to do it i know, it would be better with events

        private void C_AutoModeFOV_CheckedChanged(object sender, EventArgs e)
        {
            if (C_AutoModeFOV.Checked)
            {
                autoModeFOV = true;
            }
            else
            {
                autoModeFOV = false;
            }
        }

        private void B_set_Click(object sender, EventArgs e)
        {
            var res = 0f;
            if (float.TryParse(T_InputFOV.Text, out res))
            {
                fov = res;
            }
        }

        private void B_setFPS_Click(object sender, EventArgs e)
        {
            var resFPS = 0;
            if (int.TryParse(T_InputFPS.Text, out resFPS))
            {
                fps = resFPS;
            }
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(labelUrl);
        }

        private void C_AutoModeFPS_CheckedChanged(object sender, EventArgs e)
        {
            if (C_AutoModeFPS.Checked)
            {
                autoModeFPS = true;
            }
            else
            {
                autoModeFPS = false;
            }
        }

        private void T_InputFPS_TextChanged(object sender, EventArgs e)
        {

        }

        private void T_InputFOV_TextChanged(object sender, EventArgs e)
        {

        }

        private void C_windowed_CheckedChanged(object sender, EventArgs e)
        {
            if (C_fullscreen.Checked)
            {
                autoModeFullscreen = true;
                fullscreen = 1;
            }
            else
            {
                autoModeFullscreen = true;
                MessageBox.Show("The game will not run in proper windowed mode! The feature is buggy.\n Basically the game, will always remain on top, no matter what.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning );
                fullscreen = 0;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void C_balance_CheckedChanged(object sender, EventArgs e)
        {
            if (C_balance.Checked)
            {
                disableBalancing = true;
            }
            else
            {
                disableBalancing = false;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start(DonateURL);
        }
    }
}
