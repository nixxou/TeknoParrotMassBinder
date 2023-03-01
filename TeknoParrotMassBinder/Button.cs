using System;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
	class Button
	{
		public string ButtonName { get; set;}
		public bool isDinput= false;
		public bool isXinput = false;
		public bool isRawinput = false;

		public XElement wholeButton = null;

		public XElement DInputButton = null;
		public XElement XInputButton = null;
		public XElement RawInputButton = null;

		public XElement BindNameDi = null;
		public XElement BindNameXi = null;
		public XElement BindNameRi = null;


		public Button(XElement wholeButtonSource, string buttonName)
		{

			this.ButtonName = buttonName;
			wholeButton = wholeButtonSource;

			DInputButton = wholeButton.Elements("DirectInputButton").FirstOrDefault();
			XInputButton = wholeButton.Elements("XInputButton").FirstOrDefault();
			RawInputButton = wholeButton.Elements("RawInputButton").FirstOrDefault();

			BindNameDi = wholeButton.Elements("BindNameDi").FirstOrDefault();
			BindNameXi = wholeButton.Elements("BindNameXi").FirstOrDefault();
			BindNameRi = wholeButton.Elements("BindNameRi").FirstOrDefault();

			if (DInputButton != null && BindNameDi != null && !String.IsNullOrEmpty(BindNameDi.Value)) isDinput = true;
			if (XInputButton != null && BindNameXi != null && !String.IsNullOrEmpty(BindNameXi.Value)) isXinput = true;
			if (RawInputButton != null && BindNameRi != null &&!String.IsNullOrEmpty(BindNameRi.Value)) isRawinput = true;

		}

		public bool ReplaceButton(Button otherButton, ButtonType type)
		{
			if (type == ButtonType.Dinput && otherButton.isDinput)
			{
				DInputButton = otherButton.DInputButton;
				BindNameDi = otherButton.BindNameDi;
				isDinput= true;
				RebuildWholeButton();
				return true;
			}
			if (type == ButtonType.Xinput && otherButton.isXinput)
			{
				XInputButton = otherButton.XInputButton;
				BindNameXi = otherButton.BindNameXi;
				isXinput = true;
				RebuildWholeButton();
				return true;
			}
			if (type == ButtonType.Rawinput && otherButton.isRawinput)
			{
				RawInputButton = otherButton.RawInputButton;
				BindNameRi = otherButton.BindNameRi;
				isRawinput = true;
				RebuildWholeButton();
				return true;
			}
			return false;
		}

		public bool ContainsElement(string name)
		{
			var zzz = wholeButton.Descendants("JoystickButtons").Elements("DirectInputButton").FirstOrDefault();
			return true;
		}

		public void RebuildWholeButton()
		{

			wholeButton.Elements("DirectInputButton").Remove();
			wholeButton.Elements("XInputButton").Remove();
			wholeButton.Elements("RawInputButton").Remove();
			wholeButton.Elements("BindNameDi").Remove();
			wholeButton.Elements("BindNameXi").Remove();
			wholeButton.Elements("BindNameRi").Remove();

			if (DInputButton != null) wholeButton.Elements("InputMapping").First().AddBeforeSelf(DInputButton);
			if (XInputButton != null) wholeButton.Elements("InputMapping").First().AddBeforeSelf(XInputButton);
			if (RawInputButton != null) wholeButton.Elements("InputMapping").First().AddBeforeSelf(RawInputButton);




			if (BindNameRi != null) wholeButton.Elements("AnalogType").First().AddAfterSelf(BindNameRi);
			if (BindNameXi != null) wholeButton.Elements("AnalogType").First().AddAfterSelf(BindNameXi);
			if (BindNameDi != null) wholeButton.Elements("AnalogType").First().AddAfterSelf(BindNameDi);

		}

		public void ClearButton()
		{
			DInputButton = XInputButton = RawInputButton = BindNameDi = BindNameXi = BindNameRi = null;
			isDinput = isRawinput = isXinput = false;
			RebuildWholeButton();
		}



	}
}
