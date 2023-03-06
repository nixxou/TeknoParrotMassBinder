using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;




namespace TeknoParrotMassBinder
{

	public partial class Form1 : Form
	{
		Dictionary<string, Game> Games = new Dictionary<string, Game>();
		Dictionary<string, string> XMLList = new Dictionary<string, string>();

		Game SelectedGame = null;
		WindowsFormsApp1.Button SelectedKey = null;

		string UserDir = "";

		public Form1()
		{
			InitializeComponent();
		}

		private void btn_browse_Click(object sender, EventArgs e)
		{
			using(var fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();

				if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					txt_dir.Text = fbd.SelectedPath;
					btn_load.Enabled= true;
					Properties.Settings.Default["UserDir"] = fbd.SelectedPath;
					Properties.Settings.Default.Save();

					btn_load.Enabled = true;

					/*
					string[] xmlList = Directory.GetFiles(fbd.SelectedPath, "*.xml");
					foreach (string xml in xmlList)
					{
						var NewGame = new Game(xml);
						Games.Add(NewGame.Name, NewGame);
						checkedListBox1.Items.Add(NewGame.Name);

					}
					if(Games.Count> 0)
					{
						btn_checkall.Enabled = true;
						btn_checknonbinded.Enabled = true;
						btn_checknone.Enabled = true;

					}
					*/
				}



			}
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			btn_checkall.Enabled = false;
			btn_checknonbinded.Enabled = false;
			btn_checknone.Enabled = false;
			btn_load.Enabled = false;

			txt_dir.Text = Properties.Settings.Default["UserDir"].ToString();
			if (Directory.Exists(txt_dir.Text))
			{
				btn_load.Enabled = true;
			}


		}

		private void btn_checkall_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < checkedListBox1.Items.Count; i++)
			{
				checkedListBox1.SetItemChecked(i, true);
			}

		}

		private void btn_checknone_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < checkedListBox1.Items.Count; i++)
			{
				checkedListBox1.SetItemChecked(i, false);
			}
		}

		private void btn_checknonbinded_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < checkedListBox1.Items.Count; i++)
			{
				var GameName = checkedListBox1.Items[i].ToString();
				if (Games[GameName].fullyBinded) checkedListBox1.SetItemChecked(i, false);
			}
		}

		private void txt_dir_TextChanged(object sender, EventArgs e)
		{

		}

		private void btn_load_Click(object sender, EventArgs e)
		{
			checkedListBox1.Items.Clear();
			combo_gameselection.Items.Clear();
			XMLList.Clear();
			Games.Clear();

			SelectedGame = null;
			string[] xmlList = Directory.GetFiles(txt_dir.Text, "*.xml");
			foreach (string xml in xmlList)
			{
				try
				{
					var NewGame = new Game(xml);
					Games.Add(NewGame.Name, NewGame);
					checkedListBox1.Items.Add(NewGame.Name);
					combo_gameselection.Items.Add(NewGame.Name);
					XMLList.Add(NewGame.Name, xml);

				}
				catch { }
			}
			if (Games.Count > 0)
			{
				btn_checkall.Enabled = true;
				btn_checknonbinded.Enabled = true;
				btn_checknone.Enabled = true;

				for (int i = 0; i < checkedListBox1.Items.Count; i++)
				{
					checkedListBox1.SetItemChecked(i, true);
				}
				btn_hardlink.Enabled = true;

			}

		}

		private void combo_gameselection_SelectedIndexChanged(object sender, EventArgs e)
		{
			listView1.Items.Clear();
			label_gameselected.Text = "";
			SelectedGame = null;
			SelectedKey = null;
			cmb_listkey.Items.Clear();
			cmb_listkey.Enabled = false;
			btn_list.Enabled = false;

			checkedListBox2.Items.Clear();
			checkedListBox2.Enabled = false;
			btn_overwrite.Enabled = false;


			string GameName = combo_gameselection.SelectedItem.ToString();
			if(String.IsNullOrEmpty(combo_gameselection.SelectedItem.ToString())) return;

			if (Games.ContainsKey(GameName))
			{
				label_gameselected.Text = GameName;
				label_gameselected.Text += "\r\n File : " + Path.GetFileName(XMLList[GameName]);
				label_gameselected.Text += String.Format("\r\n Capabilities : {0}{1}{2}"
					, Games[GameName].isDinputCapable ? "DInput," : ""
					, Games[GameName].isXinputCapable ? "XInput," : ""
					, Games[GameName].isRawinputCapable ? "RawInput," : "").Trim(',');
				label_gameselected.Text += "\r\nActiveInput : " + Games[GameName].InputType;
				label_gameselected.Text += "\r\n Binded Keys : " + Games[GameName].bindCount + " / " + Games[GameName].Buttons.Count();
				foreach(var btn in Games[GameName].Buttons.Values)
				{

					listView1.Items.Add(new ListViewItem(new[] { btn.ButtonName, 
						btn.BindNameDi == null ? "" : btn.BindNameDi.Value.ToString(),
						btn.BindNameXi == null ? "" : btn.BindNameXi.Value.ToString(),
						btn.BindNameRi == null ? "" : btn.BindNameRi.Value.ToString(),
					}));
					if(btn.BindNameDi != null || btn.BindNameXi != null || btn.BindNameRi != null) cmb_listkey.Items.Add(btn.ButtonName);


				}
				SelectedGame= Games[GameName];
				chk_Existing.Checked = true;
				chk_Dinput.Checked = false;
				chk_Xinput.Checked = false;
				chk_Rinput.Checked = false;

				if (Games[GameName].isDinputCapable)
				{
					chk_Dinput.Visible = true;
					chk_Dinput.Checked = true;
				}
				else chk_Dinput.Visible = false;

				if (Games[GameName].isXinputCapable)
				{
					chk_Xinput.Visible = true;
					chk_Xinput.Checked = true;
				}
				else chk_Xinput.Visible = false;

				if (Games[GameName].isRawinputCapable)
				{
					chk_Rinput.Visible = true;
					chk_Rinput.Checked = true;
				}
				else chk_Rinput.Visible = false;

				if (cmb_listkey.Items.Count > 0) cmb_listkey.Enabled = true;


			}

		}

		private void cmb_listkey_SelectedIndexChanged(object sender, EventArgs e)
		{
			btn_list.Enabled = false;
			checkedListBox2.Items.Clear();
			checkedListBox2.Enabled = false;
			btn_overwrite.Enabled = false;

			SelectedKey = null;
			if (SelectedGame == null) return;
			string KeyName = cmb_listkey.SelectedItem.ToString();
			if (String.IsNullOrEmpty(cmb_listkey.SelectedItem.ToString())) return;


			chk_Dinput.Enabled = false;
			chk_Xinput.Enabled = false;
			chk_Rinput.Enabled = false;
			chk_Existing.Enabled = false;

			if (SelectedGame.Buttons.ContainsKey(KeyName))
			{
				
				var btn = SelectedGame.Buttons[KeyName];
				SelectedKey = btn;
				chk_Existing.Enabled = true;
				if(btn.BindNameDi != null) chk_Dinput.Enabled = true;
				if(btn.BindNameXi != null) chk_Xinput.Enabled = true;
				if(btn.BindNameRi != null) chk_Rinput.Enabled = true;
				btn_list.Enabled = true;
			}
		}

		private void btn_list_Click(object sender, EventArgs e)
		{
			checkedListBox2.Enabled = true;
			checkedListBox2.Items.Clear();
			btn_overwrite.Enabled = true;

			foreach (var g in Games.Values)
			{
				if (g.Name == SelectedGame.Name) continue;
				if (!g.HasButton(SelectedKey.ButtonName)) continue;

				bool checkbox_checked = false;
				int index = checkedListBox1.Items.IndexOf(g.Name);
				if (index != -1)
				{
					if (checkedListBox1.GetItemCheckState(index) == CheckState.Checked) checkbox_checked = true; 
				}
				if (!checkbox_checked) continue;

				bool concerned = false;


				if (SelectedGame.isDinputCapable && g.isDinputCapable && SelectedKey.isDinput && chk_Dinput.Enabled && chk_Dinput.Checked)
				{
					if (g.Buttons[SelectedKey.ButtonName].isDinput == false || chk_Existing.Checked)
					{
						concerned = true;
					}
				}

				if (SelectedGame.isXinputCapable && g.isXinputCapable && SelectedKey.isXinput && chk_Xinput.Enabled && chk_Xinput.Checked)
				{
					if (g.Buttons[SelectedKey.ButtonName].isXinput == false || chk_Existing.Checked)
					{
						concerned = true;
					}
				}

				if (SelectedGame.isRawinputCapable && g.isRawinputCapable && SelectedKey.isRawinput && chk_Rinput.Enabled && chk_Rinput.Checked)
				{
					if (g.Buttons[SelectedKey.ButtonName].isRawinput == false || chk_Existing.Checked)
					{
						concerned = true;
					}
				}

				if (concerned)
				{
					Debug.WriteLine(g.Name);
					checkedListBox2.Items.Add(g.Name);
				}


				

			}
			for (int i = 0; i < checkedListBox2.Items.Count; i++)
			{
				checkedListBox2.SetItemChecked(i, true);
			}
		}

		private void btn_clearAllBind_Click(object sender, EventArgs e)
		{
			foreach(var g in Games.Values)
			{
				if (g != null)
				{
					bool checkbox_checked = false;
					int index = checkedListBox1.Items.IndexOf(g.Name);
					if (index != -1)
					{
						if (checkedListBox1.GetItemCheckState(index) == CheckState.Checked) checkbox_checked = true;
					}
					if (!checkbox_checked) continue;

					g.ClearAllButtons();
				}
			}
		}

		private void btn_hardlink_Click(object sender, EventArgs e)
		{
			string SaveDir = Path.Combine(txt_dir.Text, "RenamedConfig");
			if (!Directory.Exists(SaveDir))
			{
				Directory.CreateDirectory(SaveDir);
			}
			Utils.EmptyFolder(SaveDir);

			foreach(var xml in XMLList)
			{
				if (Games[xml.Key] != null)
				{
					string outfile = xml.Key;
					outfile = Utils.RemoveInvalidChars(outfile);
					outfile = Utils.RemoveInvalidChars(outfile);
					outfile = outfile.Trim() + ".xml";
					outfile = Path.Combine(SaveDir, outfile);
					Utils.MakeLink(xml.Value, outfile);
				}
			}

		}

		private void btn_overwrite_Click(object sender, EventArgs e)
		 {
			for (int i = 0; i < checkedListBox2.Items.Count; i++)
			{
				if (checkedListBox2.GetItemCheckState(i) == CheckState.Checked)
				{
					string TargetGameName = checkedListBox2.Items[i].ToString();
					var TargetGame = Games[TargetGameName];
					if (chk_Dinput.Enabled && chk_Dinput.Checked) SelectedGame.ReplaceBtnInTarget(TargetGame, SelectedKey.ButtonName, ButtonType.Dinput,chk_Existing.Checked);
					if (chk_Xinput.Enabled && chk_Xinput.Checked) SelectedGame.ReplaceBtnInTarget(TargetGame, SelectedKey.ButtonName, ButtonType.Xinput, chk_Existing.Checked);
					if (chk_Rinput.Enabled && chk_Rinput.Checked) SelectedGame.ReplaceBtnInTarget(TargetGame, SelectedKey.ButtonName, ButtonType.Rawinput, chk_Existing.Checked);



				}
			}
		}

		private void btn_save_Click(object sender, EventArgs e)
		{
			Process.Start("taskkill", "/F /IM TeknoParrotUi.exe");

			foreach (var xml in XMLList)
			{
				if (Games[xml.Key].changed)
				{
					Games[xml.Key].RebuilDoc();
					System.IO.File.WriteAllText(xml.Value, Games[xml.Key]._document.ToString());

				}
			}
		}
	}
}
