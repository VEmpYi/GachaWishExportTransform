namespace GachaWishExportTransform
{
    partial class convertTool
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.txtBoxFolderPath = new System.Windows.Forms.TextBox();
            this.labelDescribeStatusTxtBox = new System.Windows.Forms.Label();
            this.listBoxFileNames = new System.Windows.Forms.ListBox();
            this.listBoxFileNamesMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteSingleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnConvertAllFile = new System.Windows.Forms.Button();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.labelTotalDescribeText = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelDescribeCurrentFileName = new System.Windows.Forms.Label();
            this.labelCurrentFileName = new System.Windows.Forms.Label();
            this.groupFileList = new System.Windows.Forms.GroupBox();
            this.groupCurrentFileTitle = new System.Windows.Forms.GroupBox();
            this.labelDescribeConvert = new System.Windows.Forms.Label();
            this.labelConverted = new System.Windows.Forms.Label();
            this.labelDescribeConverted = new System.Windows.Forms.Label();
            this.labelCurrentFile302 = new System.Windows.Forms.Label();
            this.labelCurrentFile301 = new System.Windows.Forms.Label();
            this.labelCurrentFile200 = new System.Windows.Forms.Label();
            this.labelCurrentFileNoviceWish = new System.Windows.Forms.Label();
            this.labelDescribeCurrentFileNoviceWish = new System.Windows.Forms.Label();
            this.labelDescribeCurrentFile302 = new System.Windows.Forms.Label();
            this.labelDescribeCurrentFile200 = new System.Windows.Forms.Label();
            this.labelDescribeCurrentFile301 = new System.Windows.Forms.Label();
            this.labelCurrentFileStandardWish = new System.Windows.Forms.Label();
            this.labelCurrentFileWeaponEventWish = new System.Windows.Forms.Label();
            this.labelDescribeCurrentFileWeaponEventWish = new System.Windows.Forms.Label();
            this.labelCurrentFileCharacterEventWish = new System.Windows.Forms.Label();
            this.labelDescribeCurrentFileStandardWish = new System.Windows.Forms.Label();
            this.labelDescribeCurrentFileCharacterEventWish = new System.Windows.Forms.Label();
            this.labelCurrentFileUID = new System.Windows.Forms.Label();
            this.labelDescribeCurrentFileUID = new System.Windows.Forms.Label();
            this.labelCurrentFileQQ = new System.Windows.Forms.Label();
            this.labelDescribeCurrentFileQQ = new System.Windows.Forms.Label();
            this.labelFileJSONLoaded = new System.Windows.Forms.Label();
            this.labelDescribeLoadedFile = new System.Windows.Forms.Label();
            this.btnConvertSelectedFile = new System.Windows.Forms.Button();
            this.listBoxFileNamesMenuStrip.SuspendLayout();
            this.groupFileList.SuspendLayout();
            this.groupCurrentFileTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtLog
            // 
            this.txtLog.CausesValidation = false;
            this.txtLog.Location = new System.Drawing.Point(259, 300);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(529, 143);
            this.txtLog.TabIndex = 2;
            this.txtLog.TabStop = false;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSelectFolder.Location = new System.Drawing.Point(694, 12);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(94, 29);
            this.btnSelectFolder.TabIndex = 1;
            this.btnSelectFolder.Text = "选择文件";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // txtBoxFolderPath
            // 
            this.txtBoxFolderPath.Location = new System.Drawing.Point(12, 12);
            this.txtBoxFolderPath.Name = "txtBoxFolderPath";
            this.txtBoxFolderPath.PlaceholderText = "点击【选择文件】选择要转换的文件或复制文件路径到此框并点击【加载】      仅支持JSON";
            this.txtBoxFolderPath.Size = new System.Drawing.Size(612, 27);
            this.txtBoxFolderPath.TabIndex = 2;
            this.txtBoxFolderPath.WordWrap = false;
            // 
            // labelDescribeStatusTxtBox
            // 
            this.labelDescribeStatusTxtBox.AutoSize = true;
            this.labelDescribeStatusTxtBox.Location = new System.Drawing.Point(694, 303);
            this.labelDescribeStatusTxtBox.Name = "labelDescribeStatusTxtBox";
            this.labelDescribeStatusTxtBox.Size = new System.Drawing.Size(69, 20);
            this.labelDescribeStatusTxtBox.TabIndex = 5;
            this.labelDescribeStatusTxtBox.Text = "状态信息";
            // 
            // listBoxFileNames
            // 
            this.listBoxFileNames.AccessibleDescription = "显示要加载的文件列表";
            this.listBoxFileNames.ContextMenuStrip = this.listBoxFileNamesMenuStrip;
            this.listBoxFileNames.FormattingEnabled = true;
            this.listBoxFileNames.ItemHeight = 20;
            this.listBoxFileNames.Location = new System.Drawing.Point(16, 25);
            this.listBoxFileNames.Name = "listBoxFileNames";
            this.listBoxFileNames.Size = new System.Drawing.Size(204, 344);
            this.listBoxFileNames.TabIndex = 3;
            this.listBoxFileNames.SelectedIndexChanged += new System.EventHandler(this.listBoxFileNames_SelectedIndexChanged);
            this.listBoxFileNames.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxFileNames_MouseDoubleClick);
            // 
            // listBoxFileNamesMenuStrip
            // 
            this.listBoxFileNamesMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.listBoxFileNamesMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteSingleToolStripMenuItem,
            this.clearAllToolStripMenuItem});
            this.listBoxFileNamesMenuStrip.Name = "listBoxFileNamesMenuStrip";
            this.listBoxFileNamesMenuStrip.Size = new System.Drawing.Size(169, 52);
            this.listBoxFileNamesMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.listBoxFileNamesMenuStrip_Opening);
            // 
            // deleteSingleToolStripMenuItem
            // 
            this.deleteSingleToolStripMenuItem.Name = "deleteSingleToolStripMenuItem";
            this.deleteSingleToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.deleteSingleToolStripMenuItem.Text = "从列表中删除";
            this.deleteSingleToolStripMenuItem.Click += new System.EventHandler(this.deleteSingleToolStripMenuItem_Click);
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(168, 24);
            this.clearAllToolStripMenuItem.Text = "清空列表";
            this.clearAllToolStripMenuItem.Click += new System.EventHandler(this.clearAllToolStripMenuItem_Click);
            // 
            // btnConvertAllFile
            // 
            this.btnConvertAllFile.Location = new System.Drawing.Point(694, 86);
            this.btnConvertAllFile.Name = "btnConvertAllFile";
            this.btnConvertAllFile.Size = new System.Drawing.Size(94, 27);
            this.btnConvertAllFile.TabIndex = 7;
            this.btnConvertAllFile.Text = "转换所有";
            this.btnConvertAllFile.UseVisualStyleBackColor = true;
            this.btnConvertAllFile.Click += new System.EventHandler(this.btnWork_Click);
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.AccessibleDescription = "加载直接复制到文件路径框的文件";
            this.btnLoadFile.AccessibleName = "加载路径框的内容";
            this.btnLoadFile.Location = new System.Drawing.Point(630, 12);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(58, 29);
            this.btnLoadFile.TabIndex = 8;
            this.btnLoadFile.Text = "加载";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // labelTotalDescribeText
            // 
            this.labelTotalDescribeText.AutoSize = true;
            this.labelTotalDescribeText.Location = new System.Drawing.Point(6, 372);
            this.labelTotalDescribeText.Name = "labelTotalDescribeText";
            this.labelTotalDescribeText.Size = new System.Drawing.Size(39, 20);
            this.labelTotalDescribeText.TabIndex = 9;
            this.labelTotalDescribeText.Text = "共计";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(51, 372);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(18, 20);
            this.labelTotal.TabIndex = 10;
            this.labelTotal.Text = "0";
            // 
            // labelDescribeCurrentFileName
            // 
            this.labelDescribeCurrentFileName.AutoSize = true;
            this.labelDescribeCurrentFileName.Location = new System.Drawing.Point(6, 25);
            this.labelDescribeCurrentFileName.Name = "labelDescribeCurrentFileName";
            this.labelDescribeCurrentFileName.Size = new System.Drawing.Size(69, 20);
            this.labelDescribeCurrentFileName.TabIndex = 11;
            this.labelDescribeCurrentFileName.Text = "文件名：";
            // 
            // labelCurrentFileName
            // 
            this.labelCurrentFileName.AutoSize = true;
            this.labelCurrentFileName.Location = new System.Drawing.Point(70, 25);
            this.labelCurrentFileName.MaximumSize = new System.Drawing.Size(330, 20);
            this.labelCurrentFileName.MinimumSize = new System.Drawing.Size(100, 20);
            this.labelCurrentFileName.Name = "labelCurrentFileName";
            this.labelCurrentFileName.Size = new System.Drawing.Size(100, 20);
            this.labelCurrentFileName.TabIndex = 12;
            this.labelCurrentFileName.Text = "未选择文件";
            // 
            // groupFileList
            // 
            this.groupFileList.Controls.Add(this.listBoxFileNames);
            this.groupFileList.Controls.Add(this.labelTotalDescribeText);
            this.groupFileList.Controls.Add(this.labelTotal);
            this.groupFileList.Location = new System.Drawing.Point(12, 48);
            this.groupFileList.Name = "groupFileList";
            this.groupFileList.Size = new System.Drawing.Size(241, 395);
            this.groupFileList.TabIndex = 13;
            this.groupFileList.TabStop = false;
            this.groupFileList.Text = "文件列表";
            // 
            // groupCurrentFileTitle
            // 
            this.groupCurrentFileTitle.Controls.Add(this.labelDescribeConvert);
            this.groupCurrentFileTitle.Controls.Add(this.labelConverted);
            this.groupCurrentFileTitle.Controls.Add(this.labelDescribeConverted);
            this.groupCurrentFileTitle.Controls.Add(this.labelCurrentFile302);
            this.groupCurrentFileTitle.Controls.Add(this.labelCurrentFile301);
            this.groupCurrentFileTitle.Controls.Add(this.labelCurrentFile200);
            this.groupCurrentFileTitle.Controls.Add(this.labelCurrentFileNoviceWish);
            this.groupCurrentFileTitle.Controls.Add(this.labelDescribeCurrentFileNoviceWish);
            this.groupCurrentFileTitle.Controls.Add(this.labelDescribeCurrentFile302);
            this.groupCurrentFileTitle.Controls.Add(this.labelDescribeCurrentFile200);
            this.groupCurrentFileTitle.Controls.Add(this.labelDescribeCurrentFile301);
            this.groupCurrentFileTitle.Controls.Add(this.labelCurrentFileStandardWish);
            this.groupCurrentFileTitle.Controls.Add(this.labelCurrentFileWeaponEventWish);
            this.groupCurrentFileTitle.Controls.Add(this.labelDescribeCurrentFileWeaponEventWish);
            this.groupCurrentFileTitle.Controls.Add(this.labelCurrentFileCharacterEventWish);
            this.groupCurrentFileTitle.Controls.Add(this.labelDescribeCurrentFileStandardWish);
            this.groupCurrentFileTitle.Controls.Add(this.labelDescribeCurrentFileCharacterEventWish);
            this.groupCurrentFileTitle.Controls.Add(this.labelCurrentFileUID);
            this.groupCurrentFileTitle.Controls.Add(this.labelDescribeCurrentFileUID);
            this.groupCurrentFileTitle.Controls.Add(this.labelCurrentFileQQ);
            this.groupCurrentFileTitle.Controls.Add(this.labelDescribeCurrentFileQQ);
            this.groupCurrentFileTitle.Controls.Add(this.labelFileJSONLoaded);
            this.groupCurrentFileTitle.Controls.Add(this.labelDescribeLoadedFile);
            this.groupCurrentFileTitle.Controls.Add(this.labelDescribeCurrentFileName);
            this.groupCurrentFileTitle.Controls.Add(this.labelCurrentFileName);
            this.groupCurrentFileTitle.Location = new System.Drawing.Point(259, 48);
            this.groupCurrentFileTitle.Name = "groupCurrentFileTitle";
            this.groupCurrentFileTitle.Size = new System.Drawing.Size(429, 153);
            this.groupCurrentFileTitle.TabIndex = 14;
            this.groupCurrentFileTitle.TabStop = false;
            this.groupCurrentFileTitle.Text = "当前文件信息";
            // 
            // labelDescribeConvert
            // 
            this.labelDescribeConvert.AutoSize = true;
            this.labelDescribeConvert.Location = new System.Drawing.Point(146, 95);
            this.labelDescribeConvert.Name = "labelDescribeConvert";
            this.labelDescribeConvert.Size = new System.Drawing.Size(101, 20);
            this.labelDescribeConvert.TabIndex = 36;
            this.labelDescribeConvert.Text = "---转换后--->";
            // 
            // labelConverted
            // 
            this.labelConverted.AutoSize = true;
            this.labelConverted.Location = new System.Drawing.Point(329, 65);
            this.labelConverted.Name = "labelConverted";
            this.labelConverted.Size = new System.Drawing.Size(54, 20);
            this.labelConverted.TabIndex = 35;
            this.labelConverted.Text = "未转换";
            // 
            // labelDescribeConverted
            // 
            this.labelDescribeConverted.AutoSize = true;
            this.labelDescribeConverted.Location = new System.Drawing.Point(250, 65);
            this.labelDescribeConverted.Name = "labelDescribeConverted";
            this.labelDescribeConverted.Size = new System.Drawing.Size(84, 20);
            this.labelDescribeConverted.TabIndex = 34;
            this.labelDescribeConverted.Text = "转换文件：";
            // 
            // labelCurrentFile302
            // 
            this.labelCurrentFile302.AutoSize = true;
            this.labelCurrentFile302.Location = new System.Drawing.Point(328, 125);
            this.labelCurrentFile302.Name = "labelCurrentFile302";
            this.labelCurrentFile302.Size = new System.Drawing.Size(37, 20);
            this.labelCurrentFile302.TabIndex = 33;
            this.labelCurrentFile302.Text = "0 条";
            // 
            // labelCurrentFile301
            // 
            this.labelCurrentFile301.AutoSize = true;
            this.labelCurrentFile301.Location = new System.Drawing.Point(329, 105);
            this.labelCurrentFile301.Name = "labelCurrentFile301";
            this.labelCurrentFile301.Size = new System.Drawing.Size(37, 20);
            this.labelCurrentFile301.TabIndex = 32;
            this.labelCurrentFile301.Text = "0 条";
            // 
            // labelCurrentFile200
            // 
            this.labelCurrentFile200.AutoSize = true;
            this.labelCurrentFile200.Location = new System.Drawing.Point(329, 85);
            this.labelCurrentFile200.Name = "labelCurrentFile200";
            this.labelCurrentFile200.Size = new System.Drawing.Size(37, 20);
            this.labelCurrentFile200.TabIndex = 31;
            this.labelCurrentFile200.Text = "0 条";
            // 
            // labelCurrentFileNoviceWish
            // 
            this.labelCurrentFileNoviceWish.AutoSize = true;
            this.labelCurrentFileNoviceWish.Location = new System.Drawing.Point(74, 125);
            this.labelCurrentFileNoviceWish.Name = "labelCurrentFileNoviceWish";
            this.labelCurrentFileNoviceWish.Size = new System.Drawing.Size(37, 20);
            this.labelCurrentFileNoviceWish.TabIndex = 30;
            this.labelCurrentFileNoviceWish.Text = "0 条";
            // 
            // labelDescribeCurrentFileNoviceWish
            // 
            this.labelDescribeCurrentFileNoviceWish.AutoSize = true;
            this.labelDescribeCurrentFileNoviceWish.Location = new System.Drawing.Point(6, 125);
            this.labelDescribeCurrentFileNoviceWish.Name = "labelDescribeCurrentFileNoviceWish";
            this.labelDescribeCurrentFileNoviceWish.Size = new System.Drawing.Size(84, 20);
            this.labelDescribeCurrentFileNoviceWish.TabIndex = 29;
            this.labelDescribeCurrentFileNoviceWish.Text = "新手祈愿：";
            // 
            // labelDescribeCurrentFile302
            // 
            this.labelDescribeCurrentFile302.AutoSize = true;
            this.labelDescribeCurrentFile302.Location = new System.Drawing.Point(250, 125);
            this.labelDescribeCurrentFile302.Name = "labelDescribeCurrentFile302";
            this.labelDescribeCurrentFile302.Size = new System.Drawing.Size(84, 20);
            this.labelDescribeCurrentFile302.TabIndex = 28;
            this.labelDescribeCurrentFile302.Text = "武器祈愿：";
            // 
            // labelDescribeCurrentFile200
            // 
            this.labelDescribeCurrentFile200.AutoSize = true;
            this.labelDescribeCurrentFile200.Location = new System.Drawing.Point(250, 85);
            this.labelDescribeCurrentFile200.Name = "labelDescribeCurrentFile200";
            this.labelDescribeCurrentFile200.Size = new System.Drawing.Size(84, 20);
            this.labelDescribeCurrentFile200.TabIndex = 27;
            this.labelDescribeCurrentFile200.Text = "常驻祈愿：";
            // 
            // labelDescribeCurrentFile301
            // 
            this.labelDescribeCurrentFile301.AutoSize = true;
            this.labelDescribeCurrentFile301.Location = new System.Drawing.Point(250, 105);
            this.labelDescribeCurrentFile301.Name = "labelDescribeCurrentFile301";
            this.labelDescribeCurrentFile301.Size = new System.Drawing.Size(84, 20);
            this.labelDescribeCurrentFile301.TabIndex = 26;
            this.labelDescribeCurrentFile301.Text = "角色祈愿：";
            // 
            // labelCurrentFileStandardWish
            // 
            this.labelCurrentFileStandardWish.AutoSize = true;
            this.labelCurrentFileStandardWish.Location = new System.Drawing.Point(74, 105);
            this.labelCurrentFileStandardWish.Name = "labelCurrentFileStandardWish";
            this.labelCurrentFileStandardWish.Size = new System.Drawing.Size(37, 20);
            this.labelCurrentFileStandardWish.TabIndex = 23;
            this.labelCurrentFileStandardWish.Text = "0 条";
            // 
            // labelCurrentFileWeaponEventWish
            // 
            this.labelCurrentFileWeaponEventWish.AutoSize = true;
            this.labelCurrentFileWeaponEventWish.Location = new System.Drawing.Point(74, 85);
            this.labelCurrentFileWeaponEventWish.Name = "labelCurrentFileWeaponEventWish";
            this.labelCurrentFileWeaponEventWish.Size = new System.Drawing.Size(37, 20);
            this.labelCurrentFileWeaponEventWish.TabIndex = 25;
            this.labelCurrentFileWeaponEventWish.Text = "0 条";
            // 
            // labelDescribeCurrentFileWeaponEventWish
            // 
            this.labelDescribeCurrentFileWeaponEventWish.AutoSize = true;
            this.labelDescribeCurrentFileWeaponEventWish.Location = new System.Drawing.Point(6, 85);
            this.labelDescribeCurrentFileWeaponEventWish.Name = "labelDescribeCurrentFileWeaponEventWish";
            this.labelDescribeCurrentFileWeaponEventWish.Size = new System.Drawing.Size(84, 20);
            this.labelDescribeCurrentFileWeaponEventWish.TabIndex = 24;
            this.labelDescribeCurrentFileWeaponEventWish.Text = "武器祈愿：";
            // 
            // labelCurrentFileCharacterEventWish
            // 
            this.labelCurrentFileCharacterEventWish.AutoSize = true;
            this.labelCurrentFileCharacterEventWish.Location = new System.Drawing.Point(74, 65);
            this.labelCurrentFileCharacterEventWish.Name = "labelCurrentFileCharacterEventWish";
            this.labelCurrentFileCharacterEventWish.Size = new System.Drawing.Size(37, 20);
            this.labelCurrentFileCharacterEventWish.TabIndex = 20;
            this.labelCurrentFileCharacterEventWish.Text = "0 条";
            // 
            // labelDescribeCurrentFileStandardWish
            // 
            this.labelDescribeCurrentFileStandardWish.AutoSize = true;
            this.labelDescribeCurrentFileStandardWish.Location = new System.Drawing.Point(6, 105);
            this.labelDescribeCurrentFileStandardWish.Name = "labelDescribeCurrentFileStandardWish";
            this.labelDescribeCurrentFileStandardWish.Size = new System.Drawing.Size(84, 20);
            this.labelDescribeCurrentFileStandardWish.TabIndex = 15;
            this.labelDescribeCurrentFileStandardWish.Text = "常驻祈愿：";
            // 
            // labelDescribeCurrentFileCharacterEventWish
            // 
            this.labelDescribeCurrentFileCharacterEventWish.AutoSize = true;
            this.labelDescribeCurrentFileCharacterEventWish.Location = new System.Drawing.Point(6, 65);
            this.labelDescribeCurrentFileCharacterEventWish.Name = "labelDescribeCurrentFileCharacterEventWish";
            this.labelDescribeCurrentFileCharacterEventWish.Size = new System.Drawing.Size(84, 20);
            this.labelDescribeCurrentFileCharacterEventWish.TabIndex = 19;
            this.labelDescribeCurrentFileCharacterEventWish.Text = "角色祈愿：";
            // 
            // labelCurrentFileUID
            // 
            this.labelCurrentFileUID.AutoSize = true;
            this.labelCurrentFileUID.Location = new System.Drawing.Point(293, 45);
            this.labelCurrentFileUID.MaximumSize = new System.Drawing.Size(110, 0);
            this.labelCurrentFileUID.Name = "labelCurrentFileUID";
            this.labelCurrentFileUID.Size = new System.Drawing.Size(90, 20);
            this.labelCurrentFileUID.TabIndex = 15;
            this.labelCurrentFileUID.Text = "100179605";
            // 
            // labelDescribeCurrentFileUID
            // 
            this.labelDescribeCurrentFileUID.AutoSize = true;
            this.labelDescribeCurrentFileUID.Location = new System.Drawing.Point(250, 45);
            this.labelDescribeCurrentFileUID.Name = "labelDescribeCurrentFileUID";
            this.labelDescribeCurrentFileUID.Size = new System.Drawing.Size(50, 20);
            this.labelDescribeCurrentFileUID.TabIndex = 18;
            this.labelDescribeCurrentFileUID.Text = "UID：";
            // 
            // labelCurrentFileQQ
            // 
            this.labelCurrentFileQQ.AutoSize = true;
            this.labelCurrentFileQQ.Location = new System.Drawing.Point(74, 45);
            this.labelCurrentFileQQ.MaximumSize = new System.Drawing.Size(110, 0);
            this.labelCurrentFileQQ.Name = "labelCurrentFileQQ";
            this.labelCurrentFileQQ.Size = new System.Drawing.Size(108, 20);
            this.labelCurrentFileQQ.TabIndex = 17;
            this.labelCurrentFileQQ.Text = "36090171111";
            // 
            // labelDescribeCurrentFileQQ
            // 
            this.labelDescribeCurrentFileQQ.AutoSize = true;
            this.labelDescribeCurrentFileQQ.Location = new System.Drawing.Point(6, 45);
            this.labelDescribeCurrentFileQQ.Name = "labelDescribeCurrentFileQQ";
            this.labelDescribeCurrentFileQQ.Size = new System.Drawing.Size(78, 20);
            this.labelDescribeCurrentFileQQ.TabIndex = 16;
            this.labelDescribeCurrentFileQQ.Text = "所属QQ：";
            // 
            // labelFileJSONLoaded
            // 
            this.labelFileJSONLoaded.AutoSize = true;
            this.labelFileJSONLoaded.Location = new System.Drawing.Point(370, -1);
            this.labelFileJSONLoaded.Name = "labelFileJSONLoaded";
            this.labelFileJSONLoaded.Size = new System.Drawing.Size(54, 20);
            this.labelFileJSONLoaded.TabIndex = 15;
            this.labelFileJSONLoaded.Text = "未加载";
            // 
            // labelDescribeLoadedFile
            // 
            this.labelDescribeLoadedFile.AutoSize = true;
            this.labelDescribeLoadedFile.Location = new System.Drawing.Point(299, -1);
            this.labelDescribeLoadedFile.Name = "labelDescribeLoadedFile";
            this.labelDescribeLoadedFile.Size = new System.Drawing.Size(84, 20);
            this.labelDescribeLoadedFile.TabIndex = 13;
            this.labelDescribeLoadedFile.Text = "文件加载：";
            // 
            // btnConvertSelectedFile
            // 
            this.btnConvertSelectedFile.Location = new System.Drawing.Point(694, 51);
            this.btnConvertSelectedFile.Name = "btnConvertSelectedFile";
            this.btnConvertSelectedFile.Size = new System.Drawing.Size(94, 29);
            this.btnConvertSelectedFile.TabIndex = 15;
            this.btnConvertSelectedFile.Text = "转换当前";
            this.btnConvertSelectedFile.UseVisualStyleBackColor = true;
            this.btnConvertSelectedFile.Click += new System.EventHandler(this.btnConvertSelectedFile_Click);
            // 
            // convertTool
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnConvertSelectedFile);
            this.Controls.Add(this.groupCurrentFileTitle);
            this.Controls.Add(this.groupFileList);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.btnConvertAllFile);
            this.Controls.Add(this.labelDescribeStatusTxtBox);
            this.Controls.Add(this.txtBoxFolderPath);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.txtLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "convertTool";
            this.ShowIcon = false;
            this.Text = "抽卡记录转换工具 — 将 LittlePaimon 的抽卡记录格式转为 Yunzai 的抽卡记录格式";
            this.listBoxFileNamesMenuStrip.ResumeLayout(false);
            this.groupFileList.ResumeLayout(false);
            this.groupFileList.PerformLayout();
            this.groupCurrentFileTitle.ResumeLayout(false);
            this.groupCurrentFileTitle.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button btnSelectFolder;
        private TextBox txtBoxFolderPath;
        private Label labelDescribeStatusTxtBox;
        private TextBox txtLog;
        private ListBox listBoxFileNames;
        private ContextMenuStrip listBoxFileNamesMenuStrip;
        private ToolStripMenuItem deleteSingleToolStripMenuItem;
        private ToolStripMenuItem clearAllToolStripMenuItem;
        private Button btnConvertAllFile;
        private Button btnLoadFile;
        private Label labelTotalDescribeText;
        private Label labelTotal;
        private Label labelDescribeCurrentFileName;
        private Label labelCurrentFileName;
        private GroupBox groupFileList;
        private GroupBox groupCurrentFileTitle;
        private Label labelDescribeLoadedFile;
        private Label labelFileJSONLoaded;
        private Label labelCurrentFileQQ;
        private Label labelDescribeCurrentFileQQ;
        private Label labelCurrentFileUID;
        private Label labelDescribeCurrentFileUID;
        private Label labelDescribeCurrentFileCharacterEventWish;
        private Label labelCurrentFileCharacterEventWish;
        private Label labelCurrentFileStandardWish;
        private Label labelDescribeCurrentFileStandardWish;
        private Label labelCurrentFileWeaponEventWish;
        private Label labelDescribeCurrentFileWeaponEventWish;
        private Label labelDescribeCurrentFile301;
        private Label labelDescribeCurrentFile302;
        private Label labelDescribeCurrentFile200;
        private Label labelDescribeCurrentFileNoviceWish;
        private Label labelCurrentFileNoviceWish;
        private Label labelCurrentFile302;
        private Label labelCurrentFile301;
        private Label labelCurrentFile200;
        private Label labelConverted;
        private Label labelDescribeConverted;
        private Label labelDescribeConvert;
        private Button btnConvertSelectedFile;
    }
}