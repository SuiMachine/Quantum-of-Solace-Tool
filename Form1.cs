using System;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;


namespace QuantumOfSolace
{
	public partial class Form1 : Form
	{
		UserPreferences userPreferences;
		// Base address value for pointers.
		int baseAddress = 0x0;

		// Other variables.
		Process[] myProcess;
		string processName;

		float fov = 85;
		int fps = 90;
		int fullscreen = 1;
		byte balance = 0;

		float readFov = 0;
		int readFPS = 0;
		int readFullscreen = 0;
		byte readBalance = 0;
		int[] offsets = new int[] { 0x10 };

		int fovAddress = 0x1C523DC;
		int fpsAdresss = 0x1A36E50;
		int fullscreenAdresss = 0x13A74C4;
		int balanceAdresss = 0x20B1FBA;

		bool autoModeFOV;
		bool autoModeFPS;
		bool autoModeFullscreen;
		bool disableBalancing;

		string labelUrl = "www.pcgamingwiki.com";

		//Keyboard hook
		KeyboardHook.LowLevelKeyboardHook keyboardHook;
		Keys toggleKey;

		bool initialized = false;


		/*------------------
        -- INITIALIZATION --
        ------------------*/
		public Form1()
		{
			userPreferences = UserPreferences.Load();
			InitializeComponent();
			processName = "JB_LiveEngine_s";
			LoadUserPreferences();
		}

		private void LoadUserPreferences()
		{
			fov = userPreferences.DesiredFOV;
			autoModeFOV = userPreferences.DesiredFOVHackEnabled;

			fps = userPreferences.DesiredFPS;
			autoModeFPS = userPreferences.DesiredFPSHackEnabled;

			if (!userPreferences.FullScreenMode)
			{
				autoModeFullscreen = true;
				fullscreen = 0;
			}

			disableBalancing = userPreferences.NoBalancingMiniGame;
			toggleKey = userPreferences.DesiredFPSToggleKey;
		}

		private void Form1_Shown(object sender, EventArgs e)
		{
			keyboardHook = new KeyboardHook.LowLevelKeyboardHook();
			RegisterHotkeys();
			keyboardHook.KeyPressed += KeyboardHook_KeyPressed;

			//Set toggles, textboxes
			C_AutoModeFOV.Checked = autoModeFOV;
			T_InputFOV.Text = fov.ToString();

			C_AutoModeFPS.Checked = autoModeFPS;
			T_InputFPS.Text = fps.ToString();

			C_balance.Checked = disableBalancing;
			C_fullscreen.Checked = fullscreen != 0;
			initialized = true;
		}

		private void RegisterHotkeys()
		{
			keyboardHook.RegisterHotKey(toggleKey);
			TB_ToggleKey.Text = toggleKey.ToString();
		}

		public delegate void KeyboardHook_KeyPressedDelagate(KeyEventArgs e);

		private void KeyboardHook_KeyPressed(object sender, KeyEventArgs e)
		{
			if (C_AutoModeFOV.InvokeRequired)
			{
				KeyboardHook_KeyPressedDelagate d = new KeyboardHook_KeyPressedDelagate(ToggleFPSLock);
				this.Invoke(d, e);
			}
			else
			{
				ToggleFPSLock(e);
			}
		}

		private void ToggleFPSLock(KeyEventArgs e)
		{
			if (e.KeyCode == toggleKey)
			{
				if (autoModeFPS)
				{
					autoModeFPS = false;
					C_AutoModeFPS.Checked = false;
					WriteOriginalFPS();
				}
				else
				{
					autoModeFPS = true;
					C_AutoModeFPS.Checked = true;
					ChangeFPS();
				}
			}
		}

		bool foundProcess = false;

		private void Timer_Tick(object sender, EventArgs e)
		{
			try
			{
				keyboardHook.Poll();

				myProcess = Process.GetProcessesByName(processName);
				if (myProcess.Length > 0)
				{
					if (foundProcess == false)
					{
						System.Threading.Thread.Sleep(100);
						//baseAddress = myProcess[0].MainModule.BaseAddress.ToInt32();
					}
					foundProcess = true;

					if (baseAddress == 0x0)
					{
						LB_Running.Text = "Getting base address...";
						LB_Running.ForeColor = Color.Blue;
						var module = GetModule(myProcess[0].Modules);
						if (module != null)
							baseAddress = module.BaseAddress.ToInt32();
					}
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
			catch (Exception ex)
			{
				Debug.WriteLine(ex.ToString());
			}
		}

		private ProcessModule GetModule(ProcessModuleCollection modules)
		{
			for (int i = 0; i < modules.Count; i++)
			{
				if (modules[i].ModuleName != null && modules[i].ModuleName.ToLower() == "jb_sp_s.dll")
					return modules[i];
			}
			return null;
		}

		// Called when the game is not running or no mission is active.
		// Used to reset all the values.
		private void ResetValues()
		{
			baseAddress = 0x0;
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
					Trainer.WritePointerFloat(myProcess, baseAddress + fovAddress, offsets, fov);
			}
		}

		void ChangeFPS()
		{
			if (fpsAdresss != 0x0000000 && foundProcess)
			{
				if (readFPS != fps)
					Trainer.WriteInteger(myProcess, baseAddress + fpsAdresss, fps);
			}
		}

		void WriteOriginalFPS()
		{
			if (fpsAdresss != 0x0000000 && foundProcess)
			{
				Trainer.WriteInteger(myProcess, baseAddress + fpsAdresss, 30);
			}
		}

		void ChangeFullscreen()
		{
			if (fullscreenAdresss != 0x0000000 && foundProcess)
			{
				if (readFullscreen != fullscreen)
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
			keyboardHook.KeyPressed -= KeyboardHook_KeyPressed;
			userPreferences.Save();
		}

		private void C_AutoModeFOV_CheckedChanged(object sender, EventArgs e)
		{
			autoModeFOV = C_AutoModeFOV.Checked;
			userPreferences.DesiredFOVHackEnabled = autoModeFOV;
		}

		private void B_set_Click(object sender, EventArgs e)
		{
			if (float.TryParse(T_InputFOV.Text, out float res))
			{
				fov = res;
				userPreferences.DesiredFOV = fov;
			}
		}

		private void B_setFPS_Click(object sender, EventArgs e)
		{
			if (int.TryParse(T_InputFPS.Text, out int resFPS))
			{
				fps = resFPS;
				userPreferences.DesiredFPS = fps;
			}
		}

		private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(labelUrl);
		}

		private void C_AutoModeFPS_CheckedChanged(object sender, EventArgs e)
		{
			autoModeFPS = C_AutoModeFPS.Checked;
			userPreferences.DesiredFPSHackEnabled = autoModeFPS;
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
				if (initialized)
					MessageBox.Show("The game will not run in proper windowed mode! The feature is buggy.\n Basically the game, will always remain on top, no matter what.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				fullscreen = 0;
			}
			userPreferences.FullScreenMode = fullscreen != 0;
		}


		private void C_balance_CheckedChanged(object sender, EventArgs e)
		{
			disableBalancing = C_balance.Checked;
			userPreferences.NoBalancingMiniGame = disableBalancing;
		}

		private void TB_ToggleKey_KeyDown(object sender, KeyEventArgs e)
		{
			keyboardHook.UnregisterAllHotkeys();
			toggleKey = e.KeyCode;
			RegisterHotkeys();
		}
	}
}
