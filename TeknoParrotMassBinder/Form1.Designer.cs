namespace TeknoParrotMassBinder
{
	partial class Form1
	{
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
			this.btn_browse = new System.Windows.Forms.Button();
			this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
			this.btn_checkall = new System.Windows.Forms.Button();
			this.btn_checknone = new System.Windows.Forms.Button();
			this.btn_checknonbinded = new System.Windows.Forms.Button();
			this.txt_dir = new System.Windows.Forms.TextBox();
			this.btn_load = new System.Windows.Forms.Button();
			this.combo_gameselection = new System.Windows.Forms.ComboBox();
			this.label_gameselected = new System.Windows.Forms.Label();
			this.listView1 = new System.Windows.Forms.ListView();
			this.cmd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.DI = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.XI = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.RI = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.chk_Rinput = new System.Windows.Forms.CheckBox();
			this.chk_Xinput = new System.Windows.Forms.CheckBox();
			this.chk_Dinput = new System.Windows.Forms.CheckBox();
			this.chk_Existing = new System.Windows.Forms.CheckBox();
			this.cmb_listkey = new System.Windows.Forms.ComboBox();
			this.btn_overwrite = new System.Windows.Forms.Button();
			this.group_gameinfo = new System.Windows.Forms.GroupBox();
			this.btn_list = new System.Windows.Forms.Button();
			this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
			this.btn_clearAllBind = new System.Windows.Forms.Button();
			this.btn_save = new System.Windows.Forms.Button();
			this.btn_hardlink = new System.Windows.Forms.Button();
			this.group_gameinfo.SuspendLayout();
			this.SuspendLayout();
			// 
			// btn_browse
			// 
			this.btn_browse.Location = new System.Drawing.Point(352, 11);
			this.btn_browse.Name = "btn_browse";
			this.btn_browse.Size = new System.Drawing.Size(31, 20);
			this.btn_browse.TabIndex = 0;
			this.btn_browse.Text = "...";
			this.btn_browse.UseVisualStyleBackColor = true;
			this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
			// 
			// checkedListBox1
			// 
			this.checkedListBox1.FormattingEnabled = true;
			this.checkedListBox1.Location = new System.Drawing.Point(23, 60);
			this.checkedListBox1.Name = "checkedListBox1";
			this.checkedListBox1.Size = new System.Drawing.Size(360, 274);
			this.checkedListBox1.TabIndex = 1;
			// 
			// btn_checkall
			// 
			this.btn_checkall.Location = new System.Drawing.Point(23, 340);
			this.btn_checkall.Name = "btn_checkall";
			this.btn_checkall.Size = new System.Drawing.Size(82, 37);
			this.btn_checkall.TabIndex = 2;
			this.btn_checkall.Text = "Check all";
			this.btn_checkall.UseVisualStyleBackColor = true;
			this.btn_checkall.Click += new System.EventHandler(this.btn_checkall_Click);
			// 
			// btn_checknone
			// 
			this.btn_checknone.Location = new System.Drawing.Point(111, 340);
			this.btn_checknone.Name = "btn_checknone";
			this.btn_checknone.Size = new System.Drawing.Size(82, 37);
			this.btn_checknone.TabIndex = 3;
			this.btn_checknone.Text = "Check None";
			this.btn_checknone.UseVisualStyleBackColor = true;
			this.btn_checknone.Click += new System.EventHandler(this.btn_checknone_Click);
			// 
			// btn_checknonbinded
			// 
			this.btn_checknonbinded.Location = new System.Drawing.Point(291, 340);
			this.btn_checknonbinded.Name = "btn_checknonbinded";
			this.btn_checknonbinded.Size = new System.Drawing.Size(91, 37);
			this.btn_checknonbinded.TabIndex = 4;
			this.btn_checknonbinded.Text = "Uncheck Fully Binded";
			this.btn_checknonbinded.UseVisualStyleBackColor = true;
			this.btn_checknonbinded.Click += new System.EventHandler(this.btn_checknonbinded_Click);
			// 
			// txt_dir
			// 
			this.txt_dir.Location = new System.Drawing.Point(12, 12);
			this.txt_dir.Name = "txt_dir";
			this.txt_dir.ReadOnly = true;
			this.txt_dir.Size = new System.Drawing.Size(334, 20);
			this.txt_dir.TabIndex = 5;
			this.txt_dir.TextChanged += new System.EventHandler(this.txt_dir_TextChanged);
			// 
			// btn_load
			// 
			this.btn_load.Location = new System.Drawing.Point(316, 36);
			this.btn_load.Name = "btn_load";
			this.btn_load.Size = new System.Drawing.Size(66, 24);
			this.btn_load.TabIndex = 6;
			this.btn_load.Text = "Load";
			this.btn_load.UseVisualStyleBackColor = true;
			this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
			// 
			// combo_gameselection
			// 
			this.combo_gameselection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combo_gameselection.FormattingEnabled = true;
			this.combo_gameselection.Location = new System.Drawing.Point(23, 395);
			this.combo_gameselection.Name = "combo_gameselection";
			this.combo_gameselection.Size = new System.Drawing.Size(359, 21);
			this.combo_gameselection.TabIndex = 7;
			this.combo_gameselection.SelectedIndexChanged += new System.EventHandler(this.combo_gameselection_SelectedIndexChanged);
			// 
			// label_gameselected
			// 
			this.label_gameselected.AutoSize = true;
			this.label_gameselected.Location = new System.Drawing.Point(13, 22);
			this.label_gameselected.Name = "label_gameselected";
			this.label_gameselected.Size = new System.Drawing.Size(53, 13);
			this.label_gameselected.TabIndex = 8;
			this.label_gameselected.Text = "GameInfo";
			// 
			// listView1
			// 
			this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Default;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cmd,
            this.DI,
            this.XI,
            this.RI});
			this.listView1.GridLines = true;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(6, 126);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(470, 377);
			this.listView1.TabIndex = 10;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// cmd
			// 
			this.cmd.Text = "Command";
			this.cmd.Width = 100;
			// 
			// DI
			// 
			this.DI.Text = "DirectInput";
			this.DI.Width = 120;
			// 
			// XI
			// 
			this.XI.Text = "XInput";
			this.XI.Width = 120;
			// 
			// RI
			// 
			this.RI.Text = "RawInput";
			this.RI.Width = 120;
			// 
			// chk_Rinput
			// 
			this.chk_Rinput.AutoSize = true;
			this.chk_Rinput.Location = new System.Drawing.Point(276, 427);
			this.chk_Rinput.Name = "chk_Rinput";
			this.chk_Rinput.Size = new System.Drawing.Size(106, 17);
			this.chk_Rinput.TabIndex = 11;
			this.chk_Rinput.Text = "Overwrite RInput";
			this.chk_Rinput.UseVisualStyleBackColor = true;
			// 
			// chk_Xinput
			// 
			this.chk_Xinput.AutoSize = true;
			this.chk_Xinput.Location = new System.Drawing.Point(149, 427);
			this.chk_Xinput.Name = "chk_Xinput";
			this.chk_Xinput.Size = new System.Drawing.Size(105, 17);
			this.chk_Xinput.TabIndex = 12;
			this.chk_Xinput.Text = "Overwrite XInput";
			this.chk_Xinput.UseVisualStyleBackColor = true;
			// 
			// chk_Dinput
			// 
			this.chk_Dinput.AutoSize = true;
			this.chk_Dinput.Location = new System.Drawing.Point(25, 427);
			this.chk_Dinput.Name = "chk_Dinput";
			this.chk_Dinput.Size = new System.Drawing.Size(106, 17);
			this.chk_Dinput.TabIndex = 13;
			this.chk_Dinput.Text = "Overwrite DInput";
			this.chk_Dinput.UseVisualStyleBackColor = true;
			// 
			// chk_Existing
			// 
			this.chk_Existing.AutoSize = true;
			this.chk_Existing.Location = new System.Drawing.Point(25, 450);
			this.chk_Existing.Name = "chk_Existing";
			this.chk_Existing.Size = new System.Drawing.Size(151, 17);
			this.chk_Existing.TabIndex = 14;
			this.chk_Existing.Text = "Overwrite Existing Keybind";
			this.chk_Existing.UseVisualStyleBackColor = true;
			// 
			// cmb_listkey
			// 
			this.cmb_listkey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmb_listkey.Enabled = false;
			this.cmb_listkey.FormattingEnabled = true;
			this.cmb_listkey.Location = new System.Drawing.Point(25, 473);
			this.cmb_listkey.Name = "cmb_listkey";
			this.cmb_listkey.Size = new System.Drawing.Size(269, 21);
			this.cmb_listkey.TabIndex = 15;
			this.cmb_listkey.SelectedIndexChanged += new System.EventHandler(this.cmb_listkey_SelectedIndexChanged);
			// 
			// btn_overwrite
			// 
			this.btn_overwrite.Enabled = false;
			this.btn_overwrite.Location = new System.Drawing.Point(894, 473);
			this.btn_overwrite.Name = "btn_overwrite";
			this.btn_overwrite.Size = new System.Drawing.Size(454, 47);
			this.btn_overwrite.TabIndex = 16;
			this.btn_overwrite.Text = "Overwrite";
			this.btn_overwrite.UseVisualStyleBackColor = true;
			this.btn_overwrite.Click += new System.EventHandler(this.btn_overwrite_Click);
			// 
			// group_gameinfo
			// 
			this.group_gameinfo.Controls.Add(this.label_gameselected);
			this.group_gameinfo.Controls.Add(this.listView1);
			this.group_gameinfo.Location = new System.Drawing.Point(390, 11);
			this.group_gameinfo.Name = "group_gameinfo";
			this.group_gameinfo.Size = new System.Drawing.Size(498, 509);
			this.group_gameinfo.TabIndex = 17;
			this.group_gameinfo.TabStop = false;
			this.group_gameinfo.Text = "GameInfo";
			// 
			// btn_list
			// 
			this.btn_list.Enabled = false;
			this.btn_list.Location = new System.Drawing.Point(299, 471);
			this.btn_list.Name = "btn_list";
			this.btn_list.Size = new System.Drawing.Size(79, 23);
			this.btn_list.TabIndex = 18;
			this.btn_list.Text = "List";
			this.btn_list.UseVisualStyleBackColor = true;
			this.btn_list.Click += new System.EventHandler(this.btn_list_Click);
			// 
			// checkedListBox2
			// 
			this.checkedListBox2.Enabled = false;
			this.checkedListBox2.FormattingEnabled = true;
			this.checkedListBox2.Location = new System.Drawing.Point(894, 13);
			this.checkedListBox2.Name = "checkedListBox2";
			this.checkedListBox2.Size = new System.Drawing.Size(454, 454);
			this.checkedListBox2.TabIndex = 11;
			// 
			// btn_clearAllBind
			// 
			this.btn_clearAllBind.Location = new System.Drawing.Point(25, 500);
			this.btn_clearAllBind.Name = "btn_clearAllBind";
			this.btn_clearAllBind.Size = new System.Drawing.Size(168, 27);
			this.btn_clearAllBind.TabIndex = 19;
			this.btn_clearAllBind.Text = "Clear All KeyBind";
			this.btn_clearAllBind.UseVisualStyleBackColor = true;
			this.btn_clearAllBind.Click += new System.EventHandler(this.btn_clearAllBind_Click);
			// 
			// btn_save
			// 
			this.btn_save.Location = new System.Drawing.Point(210, 500);
			this.btn_save.Name = "btn_save";
			this.btn_save.Size = new System.Drawing.Size(168, 27);
			this.btn_save.TabIndex = 20;
			this.btn_save.Text = "Save all xml";
			this.btn_save.UseVisualStyleBackColor = true;
			this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
			// 
			// btn_hardlink
			// 
			this.btn_hardlink.Enabled = false;
			this.btn_hardlink.Location = new System.Drawing.Point(12, 36);
			this.btn_hardlink.Name = "btn_hardlink";
			this.btn_hardlink.Size = new System.Drawing.Size(181, 23);
			this.btn_hardlink.TabIndex = 21;
			this.btn_hardlink.Text = "Create Human-Readable Hardlinks";
			this.btn_hardlink.UseVisualStyleBackColor = true;
			this.btn_hardlink.Click += new System.EventHandler(this.btn_hardlink_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1360, 532);
			this.Controls.Add(this.btn_hardlink);
			this.Controls.Add(this.btn_save);
			this.Controls.Add(this.btn_clearAllBind);
			this.Controls.Add(this.checkedListBox2);
			this.Controls.Add(this.btn_list);
			this.Controls.Add(this.group_gameinfo);
			this.Controls.Add(this.btn_overwrite);
			this.Controls.Add(this.cmb_listkey);
			this.Controls.Add(this.chk_Existing);
			this.Controls.Add(this.chk_Dinput);
			this.Controls.Add(this.chk_Xinput);
			this.Controls.Add(this.chk_Rinput);
			this.Controls.Add(this.combo_gameselection);
			this.Controls.Add(this.btn_load);
			this.Controls.Add(this.txt_dir);
			this.Controls.Add(this.btn_checknonbinded);
			this.Controls.Add(this.btn_checknone);
			this.Controls.Add(this.btn_checkall);
			this.Controls.Add(this.checkedListBox1);
			this.Controls.Add(this.btn_browse);
			this.Name = "Form1";
			this.Text = "-";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.group_gameinfo.ResumeLayout(false);
			this.group_gameinfo.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btn_browse;
		private System.Windows.Forms.CheckedListBox checkedListBox1;
		private System.Windows.Forms.Button btn_checkall;
		private System.Windows.Forms.Button btn_checknone;
		private System.Windows.Forms.Button btn_checknonbinded;
		private System.Windows.Forms.TextBox txt_dir;
		private System.Windows.Forms.Button btn_load;
		private System.Windows.Forms.ComboBox combo_gameselection;
		private System.Windows.Forms.Label label_gameselected;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader cmd;
		private System.Windows.Forms.ColumnHeader DI;
		private System.Windows.Forms.ColumnHeader XI;
		private System.Windows.Forms.ColumnHeader RI;
		private System.Windows.Forms.CheckBox chk_Rinput;
		private System.Windows.Forms.CheckBox chk_Xinput;
		private System.Windows.Forms.CheckBox chk_Dinput;
		private System.Windows.Forms.CheckBox chk_Existing;
		private System.Windows.Forms.ComboBox cmb_listkey;
		private System.Windows.Forms.Button btn_overwrite;
		private System.Windows.Forms.GroupBox group_gameinfo;
		private System.Windows.Forms.Button btn_list;
		private System.Windows.Forms.CheckedListBox checkedListBox2;
		private System.Windows.Forms.Button btn_clearAllBind;
		private System.Windows.Forms.Button btn_save;
		private System.Windows.Forms.Button btn_hardlink;
	}
}

