using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GachaWishExportTransform
{
    public partial class convertTool : Form
    {
        // 创建程序功能状态
        private Dictionary<string, bool> statusFlag = new Dictionary<string, bool>();
        // 创建待加载文件目录
        private Dictionary<string, FileInformation> filesPathAndName = new Dictionary<string, FileInformation>();

        /// <summary>
        /// 初始化所有必须元素
        /// </summary>
        /// <returns>返回初始化情况</returns>
        private bool InitProgram()
        {
            // 记录是否所有的都初始化完成
            bool result = true;
            // 可按【result = result & xxx();】的格式罗列
            result = result & InitStatusFlag();
            result = result & InitGUI();

            if (result)
            {
                ShowMsg("初始化完成");
                return true;
            }
            else
            {
                ShowMsg("初始化失败", msgLevel.FATAL);
                return false;
            }
        }
        private bool InitGUI()
        {
            try
            {
                // 检查计数标签
                CheckStatusFlag_FileReady();
                // 初始化【文件加载】默认值
                labelFileJSONLoaded.Text = "未选择";
                // 初始化【文件名】默认值
                labelCurrentFileName.Text = "";
                // 初始化【所属QQ】默认值
                labelCurrentFileQQ.Text = "";
                // 初始化【UID】默认值
                labelCurrentFileUID.Text = "";
                // 初始化【角色祈愿】默认值
                labelCurrentFileCharacterEventWish.Text = "0 条";
                // 初始化【武器祈愿】默认值
                labelCurrentFileWeaponEventWish.Text = "0 条";
                // 初始化【常驻祈愿】默认值
                labelCurrentFileStandardWish.Text = "0 条";
                // 初始化【新手祈愿】默认值
                labelCurrentFileNoviceWish.Text = "0 条";
                // 初始化【云崽角色祈愿】默认值
                labelCurrentFileCharacterEventWish.Text = "未转换";
                // 初始化【云崽武器祈愿】默认值
                labelCurrentFileWeaponEventWish.Text = "未转换";
                // 初始化【云崽常驻祈愿】默认值
                labelCurrentFileStandardWish.Text = "未转换";

                return true;
            }
            catch
            {
                ShowMsg("界面初始化失败", msgLevel.FATAL);
                return false;
            }

        }
        /// <summary>
        /// 用于检查字典是否存有内容以更改【文件准备】的状态指示器，同时也会检查计数标签文本
        /// </summary>
        private void CheckStatusFlag_FileReady()
        {
            if (filesPathAndName.Count == 0)
            {
                statusFlag["FilesReady"] = false;
            }
            else
            {
                statusFlag["FilesReady"] = true;
            }
            labelTotal.Text = listBoxFileNames.Items.Count.ToString();
        }
        /// <summary>
        /// 初始化程序中的各种功能状态
        /// </summary>
        private bool InitStatusFlag()
        {
            try
            {
                statusFlag.Add("FilesReady", false);
                statusFlag.Add("Converting", false);
                // ShowMsg("初始化状态完成");
                return true;
            }
            catch
            {
                ShowMsg("初始化状态失败", msgLevel.FATAL);
                return false;
            }

        }
        /// <summary>
        /// 检查文件输出目录是否存在，不存在则创建目录，若存在输出目录，则无输出信息
        /// </summary>
        /// <returns>执行成功返回 true，否则返回 false</returns>
        private bool CheckOutputDirectoryExist()
        {
            try
            {
                string outputFolderPath = ".\\FilesOutput";
                if (!Directory.Exists(outputFolderPath))
                {
                    Directory.CreateDirectory(outputFolderPath);
                    ShowMsg("生成输出目录[FilesOutput]成功");
                }
                //else
                //{
                //    ShowMsg("输出目录[FilesOutput]已存在");
                //}
                return true;
            }
            catch
            {
                ShowMsg("初始化输出目录[FilesOutput]失败", msgLevel.FATAL);
                return false;
            }
        }
        /// <summary>
        /// 检查字典内是否含有已经装载好的文件内容
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>返回 true 则已存在JSON文件，返回 false 则未生成对应的JSON文件内容</returns>
        private bool CheckFileJsonExist(string fileName)
        {
            if (filesPathAndName.ContainsKey(fileName))
            {
                if (filesPathAndName[fileName].fileContent != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 开始转换文件
        /// </summary>
        //private bool ConvertFile()
        async private Task<bool> ConvertFile()
        {
            // 检查输出文件目录情况 和 检查转换准备情况
            if (!(CheckOutputDirectoryExist() & CheckReadyConvertFlag()))
                return false;
            //记录转换情况
            int convertComplete = 0;
            string totalCount = filesPathAndName.Count().ToString();
            foreach (var fileName in filesPathAndName.Keys)
            {
                bool currentConvert = await ConvertSingleFile(fileName);
                if (currentConvert)
                {
                    convertComplete++;
                }
            }
            // 转换完成
            statusFlag["Converting"] = false;
            ShowMsg("===转换完成，共 " + totalCount + " 个，成功 " + convertComplete + " 个===");
            return true;
        }
        /// <summary>
        /// 用于转换单个文件
        /// </summary>
        /// <param name="filePath"></param>
        async private Task<bool> ConvertSingleFile(string fileName)
        {
            // 创建输出目录
            if (!CheckOutputDirectoryExist())
                return false;
            if (!File.Exists(filesPathAndName[fileName].filePath))
            {
                ShowMsg("文件[" + fileName + ".json]已不存在，请检查文件", msgLevel.ERROR);
                return false;
            }
            // 转换文件
            try
            {
                // 指示转换状态
                statusFlag["Converting"] = true;
                // 若对应的JSON对象不存在则生成对象
                if (!CheckFileJsonExist(fileName))
                {
                    if (!await readFile2Json(fileName))
                    {
                        statusFlag["Converting"] = false;
                        return false;
                    }
                }

                // 若文件已准备好，从字典中取出内容
                JObject? jsonFileContent = filesPathAndName[fileName].fileContent;
                // 尝试构建账号输出目录
                string userDirectory = "";
                // 检查文件内容
                if (jsonFileContent["user_id"] != null)
                {
                    if (jsonFileContent["uid"] != null)
                    {
                        // 根据内容及 Yunzai 的数据格式创建文件夹
                        userDirectory = ".\\FilesOutput\\" + jsonFileContent["user_id"].ToString() + "\\" + jsonFileContent["uid"].ToString();
                        DirectoryInfo userDirInfo = Directory.CreateDirectory(userDirectory);
                    }
                    else
                    {
                        ShowMsg("缺少游戏UID，无法创建目录，请检查文件", msgLevel.ERROR);
                        ShowMsg("文件[" + fileName + "]读取错误，已从列表中删除", msgLevel.ERROR);
                        listBoxFileNames.Items.RemoveAt(listBoxFileNames.Items.IndexOf(fileName));
                        filesPathAndName.Remove(fileName);
                        statusFlag["Converting"] = false;
                        return false;
                    }
                }
                else
                {
                    ShowMsg("缺少QQ账号，无法创建目录，请检查文件", msgLevel.ERROR);
                    ShowMsg("文件[" + fileName + "]读取错误，已从列表中删除", msgLevel.ERROR);
                    listBoxFileNames.Items.RemoveAt(listBoxFileNames.Items.IndexOf(fileName));
                    filesPathAndName.Remove(fileName);
                    statusFlag["Converting"] = false;
                    return false;
                }

                // 转换格式
                // 创建 Yunzai 格式的 JSON 类型数组
                Dictionary<string, JArray> yzConvertContent = new Dictionary<string, JArray>();
                //JArray yz200All = new JArray(); JArray yz301All = new JArray(); JArray yz302All = new JArray(); JArray yzOthers = new JArray();
                yzConvertContent.Add("200", new JArray());
                yzConvertContent.Add("301", new JArray());
                yzConvertContent.Add("302", new JArray());
                yzConvertContent.Add("Others", new JArray());

                // 根据 LittlePaimon 的内容构建 Yunzai 的格式
                if (jsonFileContent["item_list"] != null)
                {
                    // 循环获取各个池子数据：角色祈愿，武器祈愿，新手祈愿
                    foreach (var multipleWish in jsonFileContent["item_list"])
                    {
                        if (multipleWish != null)
                        {
                            //各个祈愿的内容
                            foreach (var itemArray in multipleWish)
                            {
                                // item 为
                                if (itemArray != null)
                                {
                                    foreach (var itemDI in itemArray)
                                    {

                                        if (itemDI["gacha_type"] != null)
                                        {
                                            // 根据祈愿物品类型进行分类
                                            switch (itemDI["gacha_type"].ToString())
                                            {
                                                case "100":
                                                    yzConvertContent["Others"].Add(Convert2YunzaiData(itemDI, jsonFileContent["uid"].ToString()));
                                                    ShowMsg("文件[" + fileName + "]中[gacha_type]发现[新手祈愿]，已添加至文件 Others.json", msgLevel.WARNING);
                                                    break;
                                                case "200":
                                                    // yz200All.Add(Convert2YunzaiData(item, jsonFileContent["uid"].ToString()));
                                                    yzConvertContent["200"].Add(Convert2YunzaiData(itemDI, jsonFileContent["uid"].ToString()));
                                                    break;
                                                case "301":
                                                    // yz301All.Add(Convert2YunzaiData(item, jsonFileContent["uid"].ToString()));
                                                    yzConvertContent["301"].Add(Convert2YunzaiData(itemDI, jsonFileContent["uid"].ToString()));
                                                    break;
                                                case "400":
                                                    yzConvertContent["301"].Add(Convert2YunzaiData(itemDI, jsonFileContent["uid"].ToString()));
                                                    break;
                                                case "302":
                                                    // yz302All.Add(Convert2YunzaiData(item, jsonFileContent["uid"].ToString()));
                                                    yzConvertContent["302"].Add(Convert2YunzaiData(itemDI, jsonFileContent["uid"].ToString()));
                                                    break;
                                                default:
                                                    // yzOthers.Add(Convert2YunzaiData(item, jsonFileContent["uid"].ToString()));
                                                    yzConvertContent["Others"].Add(Convert2YunzaiData(itemDI, jsonFileContent["uid"].ToString()));
                                                    ShowMsg("文件[" + fileName + "]中[gacha_type]发现非法值[" + itemDI["gacha_type"].ToString() + "]，已添加至文件 Others.json", msgLevel.WARNING);
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            ShowMsg("文件[" + fileName + "]中未找到[gacha_type]", msgLevel.ERROR);
                                            statusFlag["Converting"] = false;
                                            return false;
                                        }
                                    }
                                }
                                else
                                {
                                    string parentName = itemArray.Parent.ToString();
                                    ShowMsg("文件[" + fileName + "]中的[" + parentName + "]未找到内容", msgLevel.WARNING);
                                    statusFlag["Converting"] = false;
                                    return false;
                                }

                            }
                        }
                        else
                        {
                            ShowMsg("文件[" + fileName + "]未找到各个祈愿池的详细数据", msgLevel.ERROR);
                            statusFlag["Converting"] = false;
                            return false;
                        }
                    }



                }
                else
                {
                    ShowMsg("文件[" + fileName + "]未找到祈愿数据", msgLevel.ERROR);
                    statusFlag["Converting"] = false;
                    return false;
                }

                // 若格式转换成功，将生成的JSON数据序列化
                Dictionary<string, string> strYZNeedOutputContent = new Dictionary<string, string>();
                // 循环写入序列化后的数据
                foreach (var item in yzConvertContent.Keys)
                {
                    string strOutputContent = JsonConvert.SerializeObject(yzConvertContent[item], Formatting.Indented);
                    // 生成新的JSON文件
                    string newFilePath = userDirectory + "\\" + item + ".json";
                    try
                    {
                        using (StreamWriter swWrite = new StreamWriter(newFilePath))
                        {
                            swWrite.Write(strOutputContent);
                        }
                    }
                    catch { ShowMsg("QQ[" + jsonFileContent["user_id"] + "]的UID[" + jsonFileContent["uid"] + "]文件生成失败", msgLevel.ERROR); }
                }

                // JObject jsonFileContent = JObject.Parse(fileContent);
                ShowMsg("文件[" + fileName + "]转换完成");
                statusFlag["Converting"] = false;
                return true;
            }
            catch
            {
                // 指示转换状态
                statusFlag["Converting"] = false;
                ShowMsg("文件[" + fileName + "]转换失败", msgLevel.ERROR);
                return false;
            }
        }
        /// <summary>
        /// 将文件读入并转为JSON格式保存到 filesPathAndName
        /// </summary>
        /// <param name="fileName">要读入并转换的文件名</param>
        /// <returns>返回读取成功情况</returns>
        async private Task<bool> readFile2Json(string fileName)
        {
            try
            {
                // 读入 LittlePaimon 的 JSON 文件
                string fileContent = File.ReadAllText(filesPathAndName[fileName].filePath);
                // 将 string 转为 JObject 类型
                JObject? jsonFileContent = JsonConvert.DeserializeObject<JObject>(fileContent);
                if (jsonFileContent == null)
                {
                    ShowMsg("文件[" + fileName + "]读入失败", msgLevel.ERROR);
                    return false;

                }
                filesPathAndName[fileName].fileContent = jsonFileContent;
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 检查是否可以准备转换文件
        /// </summary>
        /// <returns>为 true 则表示可以准备转换，为 false 则表示不可转换</returns>
        private bool CheckReadyConvertFlag()
        {
            // 判断是否存在待转换的文件
            if (!statusFlag["FilesReady"])
            {
                ShowMsg("未选择需要转换的文件", msgLevel.WARNING);
                MessageBox.Show("请先添加文件", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 将获取到的 JSON 格式对应生成 Yunzai 格式的 JSON 格式
        /// </summary>
        /// <param name="item">JSON格式对象</param>
        /// <param name="uid">该对象的主UID</param>
        /// <returns>生成的JSON格式对象</returns>
        private JObject Convert2YunzaiData(JToken? item, string uid)
        {
            if (item == null)
            {
                JObject errorData = new JObject();
                return errorData;
            }
            // 生成 Yunzai 的JSON格式对象
            JObject yzDI = new JObject();

            // yZDI.uid = jsonFileContent["uid"].ToString();
            yzDI["uid"] = uid;
            yzDI["gacha_type"] = item["gacha_type"];
            yzDI["item_id"] = "";
            yzDI["count"] = "1";
            string wishGetTime = item["time"].ToString().Replace("T", " ");
            yzDI["time"] = wishGetTime;
            yzDI["name"] = item["name"];
            yzDI["lang"] = "zh-cn";
            yzDI["item_type"] = item["item_type"];
            yzDI["rank_type"] = item["rank_type"];
            yzDI["id"] = item["id"];

            return yzDI;
        }
        /// <summary>
        /// 将文件加载到字典及文件列表中
        /// </summary>
        /// <param name="filePath">文件路径</param>
        private void LoadFile(string filePath)
        {
            // 获取该文件路径的文件名
            string strFileName = Path.GetFileNameWithoutExtension(filePath);
            // 检查文件是否已存在
            if (filesPathAndName.ContainsKey(strFileName))
            {
                ShowMsg("文件名[" + strFileName + "]已存在", msgLevel.WARNING);
                return;
            }

            // 将文件保存到字典和文件列表
            filesPathAndName.Add(strFileName, new FileInformation(filePath, null));
            listBoxFileNames.Items.Add(strFileName);
            ShowMsg("文件[" + strFileName + "]已添加");
        }
        /// <summary>
        /// 更新图形界面的【当前文件信息】的内容
        /// </summary>
        private void CheckGUICurrentFileInformation()
        {
            string currentFileName = listBoxFileNames.Text;
            //显示当前文件名，位于【文件名】
            labelCurrentFileName.Text = currentFileName;
            // 检查文件加载情况，位于【文件加载】
            bool fileLoaded = CheckFileJsonExist(currentFileName);
            if (fileLoaded)
            {
                labelFileJSONLoaded.Text = "已加载";
                // 加载该文件的QQ号和UID
                GetJsonString2LabelTxt(filesPathAndName[currentFileName].fileContent["user_id"], labelCurrentFileQQ);
                GetJsonString2LabelTxt(filesPathAndName[currentFileName].fileContent["uid"], labelCurrentFileUID);

                // 加载该文件的角色祈愿、武器祈愿、标准祈愿和新手祈愿
                try
                {
                    GetJsonCount2LabelTxt(filesPathAndName[currentFileName].fileContent["item_list"]["角色祈愿"], labelCurrentFileCharacterEventWish);
                    GetJsonCount2LabelTxt(filesPathAndName[currentFileName].fileContent["item_list"]["武器祈愿"], labelCurrentFileWeaponEventWish);
                    GetJsonCount2LabelTxt(filesPathAndName[currentFileName].fileContent["item_list"]["常驻祈愿"], labelCurrentFileStandardWish);
                    GetJsonCount2LabelTxt(filesPathAndName[currentFileName].fileContent["item_list"]["新手祈愿"], labelCurrentFileNoviceWish);
                }
                catch
                {
                    ShowMsg("文件[" + currentFileName + "]读取错误，已从列表中删除", msgLevel.ERROR);
                    listBoxFileNames.Items.RemoveAt(listBoxFileNames.Items.IndexOf(currentFileName));
                    filesPathAndName.Remove(currentFileName);
                    return;
                }
                // 生成 Yunzai 文件读取目录
                string userDirectory = ".\\FilesOutput\\" + filesPathAndName[currentFileName].fileContent["user_id"].ToString() + "\\" + filesPathAndName[currentFileName].fileContent["uid"].ToString();
                // 设定读取到的祈愿类型数量
                int convertKindNumber = 0;
                // 查找并读取【常驻祈愿】、【角色祈愿】、【武器祈愿】数量
                if (GetWishCountAndSet(userDirectory + "\\" + "200.json", labelCurrentFile200))
                    convertKindNumber++;
                if (GetWishCountAndSet(userDirectory + "\\" + "301.json", labelCurrentFile301))
                    convertKindNumber++;
                if (GetWishCountAndSet(userDirectory + "\\" + "302.json", labelCurrentFile302))
                    convertKindNumber++;

                // 根据查找情况修改【转换文件】的情况
                switch (convertKindNumber)
                {
                    case 0:
                        labelConverted.Text = "未转换/未找到";
                        break;
                    case 3:
                        labelConverted.Text = "已转换";
                        break;
                    default:
                        labelConverted.Text = "部分转换";
                        break;
                }
            }
            else
            {
                InitGUI();
                labelFileJSONLoaded.Text = "未加载";
                labelConverted.Text = "未转换";
            }
            CheckStatusFlag_FileReady();
        }

        /// <summary>
        /// 将JSON文件内容输出到指定标签
        /// </summary>
        /// <param name="json">要获取的JSON格式数据</param>
        /// <param name="label">被修改内容的标签</param>
        /// <param name="strEnd">标签文本内容后缀</param>
        /// <returns>成功则返回 true，否则为 false</returns>
        public bool GetJsonString2LabelTxt(JToken? json, Label label, string strEnd = "")
        {
            if (json != null)
            {
                label.Text = json.ToString() + strEnd;
                return true;
            }
            else
            {
                label.Text = "未找到";
                return false;
            }
        }
        /// <summary>
        /// 将JSON文件内容的数量输出到指定标签
        /// </summary>
        /// <param name="json">JSON文件</param>
        /// <param name="label">被修改的标签</param>
        /// <returns>成功则返回 true，否则为 false</returns>
        public bool GetJsonCount2LabelTxt(JToken? json, Label label)
        {
            if (json != null)
            {
                label.Text = json.Count().ToString() + " 条";
                return true;
            }
            else
            {
                label.Text = "未找到";
                return false;
            }
        }
        /// <summary>
        /// 获取 指定文件内的JSON数组的个数并修改到对应的标签文本中
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="modifiedLabel">被修改的标签对象</param>
        /// <returns>成功返回 true，失败返回 false</returns>
        public bool GetWishCountAndSet(string filePath, Label modifiedLabel)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    // 读入 Yunzai 的 JSON 文件
                    string fileContent = File.ReadAllText(filePath);
                    // 若获取到了内容
                    if (fileContent.Trim() != "")
                    {
                        // 将 string 转为 JObject 类型
                        JArray? jsonFile = JsonConvert.DeserializeObject<JArray>(fileContent);
                        if (jsonFile != null)
                        {
                            modifiedLabel.Text = jsonFile.Count().ToString() + " 条";
                            return true;
                        }
                        else
                        {
                            modifiedLabel.Text = "未找到";
                            return false;
                        }

                    }
                    else
                    {
                        ShowMsg("读取[" + filePath + "]文件失败", msgLevel.ERROR);
                        return false;
                    }
                }
                else
                {
                    modifiedLabel.Text = "未生成";
                    return false;
                }

            }
            catch
            {
                ShowMsg("获取 Yunzai 祈愿失败", msgLevel.ERROR);
                modifiedLabel.Text = "未找到";
                return false;
            }
        }
        /// <summary>
        /// 将变量名转为字符串
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public static string GetVarName(System.Linq.Expressions.Expression<Func<string, string>> exp)
        {
            return ((System.Linq.Expressions.MemberExpression)exp.Body).Member.Name;
        }
        /// <summary>
        /// Send message to the log textbox
        /// </summary>
        /// <param name="str">Log message</param>
        /// <param name="level">log level default is INFO</param>
        private void ShowMsg(string str, msgLevel level = msgLevel.INFO)
        {
            // Get the current time
            string time = DateTime.Now.ToString().Substring(11);
            txtLog.AppendText("[" + level.ToString() + "][" + time + "]" + str + "\r\n");
        }
        /// <summary>
        /// 指示日志等级
        /// </summary>
        private enum msgLevel
        {
            INFO, WARNING, ERROR, FATAL, TRACE
        }
    }

    public class FileInformation
    {
        public string filePath;
        public JObject? fileContent;

        public FileInformation(string filePath, JObject? fileContent)
        {
            this.filePath = filePath;
            this.fileContent = fileContent;
        }
    }
}
