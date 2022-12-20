namespace GachaWishExportTransform
{
    public partial class convertTool : Form
    {
        public convertTool()
        {
            InitializeComponent();
            bool initStatus =  InitProgram();
            if(!initStatus)
            {
                MessageBox.Show("程序初始化错误！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(1);
            }
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            try
            {
                // 创建对话框用于获取需要转换的文件
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = System.Environment.CurrentDirectory;
                ofd.Title = "选择文件";
                ofd.Filter = "JSON文件|*.json";
                ofd.FilterIndex = 0;
                ofd.Multiselect = true;
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                ofd.DefaultExt = "json";
                ofd.ShowDialog();
                string[] strFilesPath = ofd.FileNames;

                // 根据获取的文件数判断路径框内容
                if (strFilesPath.Count() > 1)
                {
                    txtBoxFolderPath.Text = "已添加多个文件";
                }
                else if (strFilesPath.Count() == 1)
                {
                    txtBoxFolderPath.Text = strFilesPath[0];
                }
                else
                {
                    ShowMsg("获取文件列表错误", msgLevel.FATAL);
                }

                // 将获取到的所有文件列表保存到字典 filesPathAndName<fileName, filePath> 和 文件列表框 中
                foreach (string strFilePath in strFilesPath)
                {
                    LoadFile(strFilePath);
                }
                CheckStatusFlag_FileReady();
            }
            catch { ShowMsg("选择文件异常", msgLevel.FATAL); }
        }
        private void listBoxFileNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckGUICurrentFileInformation();
        }

        /// <summary>
        /// 文件列表右键菜单中【清空列表】功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                listBoxFileNames.Items.Clear();
                filesPathAndName.Clear();
                CheckStatusFlag_FileReady();
                ShowMsg("已清空文件列表");
            }
            catch { ShowMsg("清空文件列表失败", msgLevel.ERROR); }
        }

        /// <summary>
        /// 文件列表右键菜单中【从列表中删除】功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteSingleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 删除字典中的该项
            bool result = filesPathAndName.Remove(listBoxFileNames.Text);
            if (result)
            {
                ShowMsg("已从列表中删除文件[" + listBoxFileNames.Text + "]");
            }
            else
            {
                ShowMsg("删除指定文件失败", msgLevel.ERROR);
            }

            // 删除文件列表中的该文件
            int currentSelectedIndex = listBoxFileNames.SelectedIndex;
            listBoxFileNames.Items.RemoveAt(currentSelectedIndex);
            // 自动选择下一个文件
            if (currentSelectedIndex < listBoxFileNames.Items.Count)
            {
                listBoxFileNames.SetSelected(currentSelectedIndex, true);
            }
            CheckStatusFlag_FileReady();
        }

        /// <summary>
        /// 在弹出右键菜单时根据选择的情况展示内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxFileNamesMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // 若未选择文件则不显示【从列表中删除】功能
            if (listBoxFileNames.SelectedIndex == -1)
            {
                deleteSingleToolStripMenuItem.Visible = false;
            }
            else
            {
                deleteSingleToolStripMenuItem.Visible = true;
            }
        }

        /// <summary>
        /// 点击按钮执行转换功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnWork_Click(object sender, EventArgs e)
        {
            if (!statusFlag["Converting"])
            {
                //Thread convertFile = new Thread(ConvertFile);
                //convertFile.IsBackground = true;
                //convertFile.Start();

                var result = await Task<bool>.Run(() => ConvertFile());
                // bool result = await ConvertFile();
                if (result)
                {
                    ShowMsg("全部转换完成");
                }
                else
                {
                    ShowMsg("转换中存在错误", msgLevel.ERROR);
                }
            }
            else
            {
                ShowMsg("已经启动文件转换，请稍后");
            }
            
        }

        /// <summary>
        /// 点击【加载】按钮，加载文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            try
            {
                // 从文本框获取内容
                string filePath = txtBoxFolderPath.Text;
                // 除去文本中的特殊符号
                filePath = filePath.Trim(new char[] { ' ', '"' });
                // 判断文件是否存在
                if (File.Exists(filePath))
                {
                    LoadFile(filePath);
                }
                else
                {
                    ShowMsg("文件路径错误，请检查路径", msgLevel.WARNING);
                }
            }
            catch { ShowMsg("文件加载失败", msgLevel.WARNING); }
            
        }

        private void listBoxFileNames_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(listBoxFileNames.SelectedIndex == -1)
            {
                return;
            }
            else
            {
                if (!CheckFileJsonExist(listBoxFileNames.Text))
                {
                    if (readFile2Json(listBoxFileNames.Text))
                    {
                        CheckGUICurrentFileInformation();
                    }
                }
            }
        }

        private void btnConvertSelectedFile_Click(object sender, EventArgs e)
        {
            ConvertSingleFile(listBoxFileNames.Text);
            CheckGUICurrentFileInformation();
        }
    }
}