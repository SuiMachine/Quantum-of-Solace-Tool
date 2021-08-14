using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuantumOfSolace
{
	public class UserPreferences
	{
		private const string CONFIG_FILE = "QuantumOfSolaceTool.xml";

		public bool FullScreenMode { get; set; }
		public bool NoBalancingMiniGame { get; set; }

		public float DesiredFOV { get; set; }
		public bool DesiredFOVHackEnabled { get; set; }

		public int DesiredFPS { get; set; }
		public bool DesiredFPSHackEnabled { get; set; }

		public Keys DesiredFPSToggleKey { get; set; }


		public UserPreferences()
		{
			FullScreenMode = false;
			NoBalancingMiniGame = false;
			DesiredFOV = 80;
			DesiredFOVHackEnabled = false;
			DesiredFPS = 60;
			DesiredFPSHackEnabled = false;
			DesiredFPSToggleKey = Keys.F5;
		}

		public static UserPreferences Load()
		{
			if (File.Exists(CONFIG_FILE))
			{
				var readFile = XMLSerialization.ReadFromXMLFile<UserPreferences>(CONFIG_FILE);
				return readFile;
			}
			else
				return new UserPreferences();
		}

		public void Save()
		{
			XMLSerialization.SaveObjectToXML<UserPreferences>(this, CONFIG_FILE);
		}
	}
}
