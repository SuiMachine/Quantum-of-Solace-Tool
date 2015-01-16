namespace QuantumOfSolace
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.LB_Running = new System.Windows.Forms.Label();
            this.T_InputFOV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.C_AutoModeFOV = new System.Windows.Forms.CheckBox();
            this.InputPanel = new System.Windows.Forms.Panel();
            this.linkLabel = new System.Windows.Forms.LinkLabel();
            this.B_setFPS = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.T_InputFPS = new System.Windows.Forms.TextBox();
            this.C_AutoModeFPS = new System.Windows.Forms.CheckBox();
            this.B_setFOV = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.L_fov = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.L_fps = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.C_fullscreen = new System.Windows.Forms.CheckBox();
            this.L_fullscreen = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.C_balance = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.InputPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // Timer
            // 
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // LB_Running
            // 
            this.LB_Running.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LB_Running.Dock = System.Windows.Forms.DockStyle.Top;
            this.LB_Running.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LB_Running.ForeColor = System.Drawing.Color.Red;
            this.LB_Running.Location = new System.Drawing.Point(0, 0);
            this.LB_Running.Name = "LB_Running";
            this.LB_Running.Size = new System.Drawing.Size(595, 24);
            this.LB_Running.TabIndex = 1;
            this.LB_Running.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // T_InputFOV
            // 
            this.T_InputFOV.Location = new System.Drawing.Point(356, 40);
            this.T_InputFOV.Name = "T_InputFOV";
            this.T_InputFOV.Size = new System.Drawing.Size(105, 20);
            this.T_InputFOV.TabIndex = 37;
            this.T_InputFOV.Text = "85";
            this.T_InputFOV.TextChanged += new System.EventHandler(this.T_InputFOV_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(296, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 38;
            this.label1.Text = "Insert Fov";
            // 
            // C_AutoModeFOV
            // 
            this.C_AutoModeFOV.AutoSize = true;
            this.C_AutoModeFOV.Location = new System.Drawing.Point(530, 42);
            this.C_AutoModeFOV.Name = "C_AutoModeFOV";
            this.C_AutoModeFOV.Size = new System.Drawing.Size(59, 17);
            this.C_AutoModeFOV.TabIndex = 39;
            this.C_AutoModeFOV.Text = "Enable";
            this.C_AutoModeFOV.UseVisualStyleBackColor = true;
            this.C_AutoModeFOV.CheckedChanged += new System.EventHandler(this.C_AutoModeFOV_CheckedChanged);
            // 
            // InputPanel
            // 
            this.InputPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputPanel.Controls.Add(this.linkLabel);
            this.InputPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.InputPanel.Location = new System.Drawing.Point(0, 184);
            this.InputPanel.Name = "InputPanel";
            this.InputPanel.Size = new System.Drawing.Size(595, 32);
            this.InputPanel.TabIndex = 41;
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.Location = new System.Drawing.Point(10, 9);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(84, 13);
            this.linkLabel.TabIndex = 43;
            this.linkLabel.TabStop = true;
            this.linkLabel.Text = "PC Gaming Wiki";
            this.linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_LinkClicked);
            // 
            // B_setFPS
            // 
            this.B_setFPS.Location = new System.Drawing.Point(467, 76);
            this.B_setFPS.Name = "B_setFPS";
            this.B_setFPS.Size = new System.Drawing.Size(45, 23);
            this.B_setFPS.TabIndex = 48;
            this.B_setFPS.Text = "Set";
            this.B_setFPS.UseVisualStyleBackColor = true;
            this.B_setFPS.Click += new System.EventHandler(this.B_setFPS_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(296, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 47;
            this.label5.Text = "Insert FPS";
            // 
            // T_InputFPS
            // 
            this.T_InputFPS.Location = new System.Drawing.Point(356, 78);
            this.T_InputFPS.Name = "T_InputFPS";
            this.T_InputFPS.Size = new System.Drawing.Size(105, 20);
            this.T_InputFPS.TabIndex = 46;
            this.T_InputFPS.Text = "90";
            this.T_InputFPS.TextChanged += new System.EventHandler(this.T_InputFPS_TextChanged);
            // 
            // C_AutoModeFPS
            // 
            this.C_AutoModeFPS.AutoSize = true;
            this.C_AutoModeFPS.Location = new System.Drawing.Point(530, 80);
            this.C_AutoModeFPS.Name = "C_AutoModeFPS";
            this.C_AutoModeFPS.Size = new System.Drawing.Size(59, 17);
            this.C_AutoModeFPS.TabIndex = 44;
            this.C_AutoModeFPS.Text = "Enable";
            this.C_AutoModeFPS.UseVisualStyleBackColor = true;
            this.C_AutoModeFPS.CheckedChanged += new System.EventHandler(this.C_AutoModeFPS_CheckedChanged);
            // 
            // B_setFOV
            // 
            this.B_setFOV.Location = new System.Drawing.Point(467, 38);
            this.B_setFOV.Name = "B_setFOV";
            this.B_setFOV.Size = new System.Drawing.Size(45, 23);
            this.B_setFOV.TabIndex = 42;
            this.B_setFOV.Text = "Set";
            this.B_setFOV.UseVisualStyleBackColor = true;
            this.B_setFOV.Click += new System.EventHandler(this.B_set_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.L_fov);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 41);
            this.panel1.TabIndex = 42;
            // 
            // L_fov
            // 
            this.L_fov.AutoSize = true;
            this.L_fov.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_fov.Location = new System.Drawing.Point(109, 15);
            this.L_fov.Name = "L_fov";
            this.L_fov.Size = new System.Drawing.Size(47, 13);
            this.L_fov.TabIndex = 1;
            this.L_fov.Text = "#####";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Current Fov";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.L_fps);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Location = new System.Drawing.Point(-1, 65);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(291, 41);
            this.panel3.TabIndex = 43;
            // 
            // L_fps
            // 
            this.L_fps.AutoSize = true;
            this.L_fps.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_fps.Location = new System.Drawing.Point(109, 15);
            this.L_fps.Name = "L_fps";
            this.L_fps.Size = new System.Drawing.Size(47, 13);
            this.L_fps.TabIndex = 1;
            this.L_fps.Text = "#####";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Current FPS limit";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.C_fullscreen);
            this.panel2.Controls.Add(this.L_fullscreen);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(-1, 106);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(291, 40);
            this.panel2.TabIndex = 44;
            // 
            // C_fullscreen
            // 
            this.C_fullscreen.AutoSize = true;
            this.C_fullscreen.Checked = true;
            this.C_fullscreen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.C_fullscreen.Location = new System.Drawing.Point(185, 13);
            this.C_fullscreen.Name = "C_fullscreen";
            this.C_fullscreen.Size = new System.Drawing.Size(59, 17);
            this.C_fullscreen.TabIndex = 49;
            this.C_fullscreen.Text = "Enable";
            this.C_fullscreen.UseVisualStyleBackColor = true;
            this.C_fullscreen.CheckedChanged += new System.EventHandler(this.C_windowed_CheckedChanged);
            // 
            // L_fullscreen
            // 
            this.L_fullscreen.AutoSize = true;
            this.L_fullscreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.L_fullscreen.Location = new System.Drawing.Point(109, 15);
            this.L_fullscreen.Name = "L_fullscreen";
            this.L_fullscreen.Size = new System.Drawing.Size(47, 13);
            this.L_fullscreen.TabIndex = 1;
            this.L_fullscreen.Text = "#####";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Fullscreen Mode";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.C_balance);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(-1, 145);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(291, 40);
            this.panel4.TabIndex = 50;
            // 
            // C_balance
            // 
            this.C_balance.AutoSize = true;
            this.C_balance.Location = new System.Drawing.Point(185, 13);
            this.C_balance.Name = "C_balance";
            this.C_balance.Size = new System.Drawing.Size(59, 17);
            this.C_balance.TabIndex = 49;
            this.C_balance.Text = "Enable";
            this.C_balance.UseVisualStyleBackColor = true;
            this.C_balance.CheckedChanged += new System.EventHandler(this.C_balance_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "No Balancing Mini-game";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 216);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.C_AutoModeFPS);
            this.Controls.Add(this.B_setFPS);
            this.Controls.Add(this.C_AutoModeFOV);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.T_InputFPS);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.InputPanel);
            this.Controls.Add(this.LB_Running);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.B_setFOV);
            this.Controls.Add(this.T_InputFOV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Quantum of Solace tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.InputPanel.ResumeLayout(false);
            this.InputPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label LB_Running;
        private System.Windows.Forms.TextBox T_InputFOV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox C_AutoModeFOV;
        private System.Windows.Forms.Panel InputPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label L_fov;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button B_setFOV;
        private System.Windows.Forms.LinkLabel linkLabel;
        private System.Windows.Forms.Button B_setFPS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox T_InputFPS;
        private System.Windows.Forms.CheckBox C_AutoModeFPS;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label L_fps;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox C_fullscreen;
        private System.Windows.Forms.Label L_fullscreen;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckBox C_balance;
        private System.Windows.Forms.Label label7;
    }
}

