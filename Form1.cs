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
                MessageBox.Show("�����ʼ������", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(1);
            }
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            try
            {
                // �����Ի������ڻ�ȡ��Ҫת�����ļ�
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.InitialDirectory = System.Environment.CurrentDirectory;
                ofd.Title = "ѡ���ļ�";
                ofd.Filter = "JSON�ļ�|*.json";
                ofd.FilterIndex = 0;
                ofd.Multiselect = true;
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                ofd.DefaultExt = "json";
                ofd.ShowDialog();
                string[] strFilesPath = ofd.FileNames;

                // ���ݻ�ȡ���ļ����ж�·��������
                if (strFilesPath.Count() > 1)
                {
                    txtBoxFolderPath.Text = "����Ӷ���ļ�";
                }
                else if (strFilesPath.Count() == 1)
                {
                    txtBoxFolderPath.Text = strFilesPath[0];
                }
                else
                {
                    ShowMsg("��ȡ�ļ��б����", msgLevel.FATAL);
                }

                // ����ȡ���������ļ��б��浽�ֵ� filesPathAndName<fileName, filePath> �� �ļ��б�� ��
                foreach (string strFilePath in strFilesPath)
                {
                    LoadFile(strFilePath);
                }
                CheckStatusFlag_FileReady();
            }
            catch { ShowMsg("ѡ���ļ��쳣", msgLevel.FATAL); }
        }
        private void listBoxFileNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckGUICurrentFileInformation();
        }

        /// <summary>
        /// �ļ��б��Ҽ��˵��С�����б�����
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
                ShowMsg("������ļ��б�");
            }
            catch { ShowMsg("����ļ��б�ʧ��", msgLevel.ERROR); }
        }

        /// <summary>
        /// �ļ��б��Ҽ��˵��С����б���ɾ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteSingleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // ɾ���ֵ��еĸ���
            bool result = filesPathAndName.Remove(listBoxFileNames.Text);
            if (result)
            {
                ShowMsg("�Ѵ��б���ɾ���ļ�[" + listBoxFileNames.Text + "]");
            }
            else
            {
                ShowMsg("ɾ��ָ���ļ�ʧ��", msgLevel.ERROR);
            }

            // ɾ���ļ��б��еĸ��ļ�
            int currentSelectedIndex = listBoxFileNames.SelectedIndex;
            listBoxFileNames.Items.RemoveAt(currentSelectedIndex);
            // �Զ�ѡ����һ���ļ�
            if (currentSelectedIndex < listBoxFileNames.Items.Count)
            {
                listBoxFileNames.SetSelected(currentSelectedIndex, true);
            }
            CheckStatusFlag_FileReady();
        }

        /// <summary>
        /// �ڵ����Ҽ��˵�ʱ����ѡ������չʾ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxFileNamesMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // ��δѡ���ļ�����ʾ�����б���ɾ��������
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
        /// �����ťִ��ת������
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
                    ShowMsg("ȫ��ת�����");
                }
                else
                {
                    ShowMsg("ת���д��ڴ���", msgLevel.ERROR);
                }
            }
            else
            {
                ShowMsg("�Ѿ������ļ�ת�������Ժ�");
            }
            
        }

        /// <summary>
        /// ��������ء���ť�������ļ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            try
            {
                // ���ı����ȡ����
                string filePath = txtBoxFolderPath.Text;
                // ��ȥ�ı��е��������
                filePath = filePath.Trim(new char[] { ' ', '"' });
                // �ж��ļ��Ƿ����
                if (File.Exists(filePath))
                {
                    LoadFile(filePath);
                }
                else
                {
                    ShowMsg("�ļ�·����������·��", msgLevel.WARNING);
                }
            }
            catch { ShowMsg("�ļ�����ʧ��", msgLevel.WARNING); }
            
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