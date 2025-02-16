using UnityAsset.NET.BundleFile;

namespace AssetEncryptionTool
{
        delegate void EncryptDelegate(string input, string output, string key);
    public partial class Form1 : Form
    {
        public string[] allowExtension = { ".asset", ".bundle" };
        public Form1()
        {
            InitializeComponent();
        }
        private void BrowseWorkDirBtn_Click(object sender, EventArgs e)
        {
            string? path = Utilities.GetFolderPathFromDialog();
            WorkDirField.Text = path;
        }
        private void BrowseSaveDir_Click(object sender, EventArgs e)
        {
            string? path = Utilities.GetFolderPathFromDialog();
            SaveDirField.Text = path;
        }
        static void DecryptSingle(string inFile, string outFile, string key)
        {
            using FileStream inStream = new FileStream(inFile, FileMode.Open, FileAccess.Read);
            BundleFile inBundleFile = new BundleFile(inStream, key: key);
            inBundleFile.Write(new FileStream(outFile, FileMode.Create, FileAccess.Write), unityCN: false);
        }

        static void EncryptSingle(string inFile, string outFile, string key)
        {
            using FileStream inStream = new FileStream(inFile, FileMode.Open, FileAccess.Read);
            BundleFile inBundleFile = new BundleFile(inStream);
            inBundleFile.Write(new FileStream(outFile, FileMode.Create, FileAccess.Write), infoPacker: "lz4hc",
                dataPacker: "lz4hc", unityCN: true, key: key);
        }
        void test(string inputPath, string outputPath, string key, EncryptDelegate @delegate)
        {
            string[] childFiles = GetChildPath(inputPath);
            foreach(string childPath in childFiles)
            {
                Console.WriteLine(childPath);
                @delegate($"{inputPath}\\{childPath}", $"{outputPath}\\{childPath}", key);
            }
        }
        private void EncryptionBtn_Click(object sender, EventArgs e)
        {
            test(WorkDirField.Text, SaveDirField.Text, txt_key.Text, EncryptSingle);
        }
        private void DecryptionBtn_Click(object sender, EventArgs e)
        {
            test(WorkDirField.Text, SaveDirField.Text, txt_key.Text, DecryptSingle);
        }
        
        public string[] GetChildPath(string path)
        {
            string[] filePaths = Directory.GetFiles(path);
            List<string> fileNames = new List<string>();
            for (int i = 0; i < filePaths.Length; i++)
            {
                if (CheckAllowExtension(filePaths[i], allowExtension))
                    fileNames.Add(Path.GetFileName(filePaths[i]));
            }
            return fileNames.ToArray();
        }
        public bool CheckAllowExtension(string path, string[] allowExtensions)
        {
            foreach(string extension in allowExtensions)
            {
                if (path.EndsWith(extension))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
