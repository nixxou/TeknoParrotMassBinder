using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;

namespace WindowsFormsApp1
{
	internal class Game
	{
		public string XmlFile { get; private set; }
		public string Name { get; private set; }

		public string InputType { get; private set; }

		public bool isDinputCapable = false;
		public bool isXinputCapable = false;
		public bool isRawinputCapable = false;

		public XDocument _document;
		public Dictionary<string, Button> Buttons { get; private set; }

		public bool fullyBinded = true;
		public int bindCount = 0;

		public bool changed = false;

		public Game(string xmlFile) 
		{
			this.XmlFile = xmlFile;
			_document = XDocument.Load(xmlFile);
			Name = _document.Descendants("GameName").FirstOrDefault()?.Value;

			Buttons = new Dictionary<string, Button>();

			InputType = (from config in _document.Descendants("FieldInformation")
						  where (string)config.Element("FieldName") == "Input API"
						  select (string)config.Element("FieldValue")
				   ).FirstOrDefault();

			var capabilities = _document.Descendants("FieldInformation")
				.Where(j => (string)j.Element("FieldName") == "Input API")
				.Select(j => j.Element("FieldOptions").Nodes()
					.Select(node => node is XElement el ? el.Value : node.ToString())
					.ToArray())
				.FirstOrDefault();

			if (capabilities == null) throw new Exception("No Capabilities");


			if (capabilities.Contains("DirectInput")) isDinputCapable = true;
			if (capabilities.Contains("XInput")) isXinputCapable = true;
			if (capabilities.Contains("RawInput")) isRawinputCapable = true;



			List<string> DuplicateButtonToDelete = new List<string>();

			var buttonNames = _document.Descendants("JoystickButtons")
				.Where(j => !string.IsNullOrEmpty((string)j.Element("ButtonName")))
				.Select(j => (string)j.Element("ButtonName"));

			foreach (string btnName in buttonNames)
			{
				if (String.IsNullOrWhiteSpace(btnName)) continue;
				
				var btnElement = _document.Descendants("JoystickButtons")
					.Where(j => (string)j.Element("ButtonName") == btnName)
					.FirstOrDefault();

				var NewButton = new Button(btnElement, btnName);
				if (InputType == "DirectInput")
				{
					if (!NewButton.isDinput) fullyBinded = false;
					else bindCount++;
				}
				if (InputType == "XInput")
				{
					if (!NewButton.isXinput) fullyBinded = false;
					else bindCount++;
				}
				if (InputType == "RawInput")
				{
					if (!NewButton.isRawinput) fullyBinded = false;
					else bindCount++;
				}

				if (!Buttons.ContainsKey(btnName))
				{
					Buttons.Add(btnName, NewButton);
				}
				
			}
		}

		public bool ReplaceBtnInTarget(Game TargetObj,string btnName, ButtonType buttonType, bool overwrite = true)
		{
			if (!Buttons.ContainsKey(btnName)) return false;
			if (!TargetObj.Buttons.ContainsKey(btnName)) return false;
			var SelfButton = Buttons[btnName];
			var TargetButton = TargetObj.Buttons[btnName];

			if (buttonType == ButtonType.Rawinput && !SelfButton.isRawinput) return false;
			if (buttonType == ButtonType.Dinput && !SelfButton.isDinput) return false;
			if (buttonType == ButtonType.Xinput && !SelfButton.isXinput) return false;

			if (buttonType == ButtonType.Rawinput && !TargetObj.isRawinputCapable) return false;
			if (buttonType == ButtonType.Dinput && !TargetObj.isDinputCapable) return false;
			if (buttonType == ButtonType.Xinput && !TargetObj.isXinputCapable) return false;

			if(overwrite == false)
			{
				if (buttonType == ButtonType.Rawinput && TargetObj.Buttons[btnName].isRawinput) return false;
				if (buttonType == ButtonType.Dinput && TargetObj.Buttons[btnName].isDinput) return false;
				if (buttonType == ButtonType.Xinput && TargetObj.Buttons[btnName].isXinput) return false;

			}

			bool res = TargetObj.Buttons[btnName].ReplaceButton(Buttons[btnName], buttonType);
			if(res) TargetObj.changed= true;
			return res;
		}

		public bool HasButton(string btnName)
		{
			return Buttons.ContainsKey(btnName);
		}

		public void ClearAllButtons()
		{
			foreach (var btn in Buttons)
			{
				btn.Value.ClearButton();
			}
			bindCount= 0;
			changed = true;
		}

		public void RebuilDoc()
		{
			foreach(var btn in Buttons)
			{
				_document.Descendants("JoystickButtons")
					.Where(j => (string)j.Element("ButtonName") == btn.Key)
					.First().ReplaceWith(btn.Value.wholeButton);
			}
		}







	}
}
