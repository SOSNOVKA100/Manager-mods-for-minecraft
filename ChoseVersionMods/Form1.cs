using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ChoseVersionMods
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool ContainsLetters(string input)
        {
            return input.Any(char.IsLetter);
        }

        public class FileHandler
        {
            public static string pathlegacyMods = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".tlauncher", "legacy", "Minecraft", "game", "mods");
            public static string pathlegacyVersions = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".tlauncher", "legacy", "Minecraft", "game", "versions");
            public static string pathlegacyConfig = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".tlauncher", "legacy", "Minecraft", "game", "mods", "mngConfig");

            public static string pathTlauncherMods = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft", "mods");
            public static string pathTlauncherVersions = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft", "versions");
            public static string pathTlauncherConfig = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft", "mods", "mngConfig");

            public static string pathOtherDownload = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Проверка существования директорий до папки mods
            bool legacyModsPathExists = Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".tlauncher", "legacy", "Minecraft", "game"));
            bool tlauncherModsPathExists = Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft"));

            // Проверка существования папки mods
            checkBox1.Checked = legacyModsPathExists && Directory.Exists(FileHandler.pathlegacyMods);
            checkBox6.Checked = tlauncherModsPathExists && Directory.Exists(FileHandler.pathTlauncherMods);

            // Создание папки mods, если она отсутствует
            if (legacyModsPathExists && !Directory.Exists(FileHandler.pathlegacyMods))
            {
                Directory.CreateDirectory(FileHandler.pathlegacyMods);
                MessageBox.Show("Папка 'mods' для Legacy была создана.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                checkBox1.Checked = true; // Активируем флажок для Legacy
            }

            if (tlauncherModsPathExists && !Directory.Exists(FileHandler.pathTlauncherMods))
            {
                Directory.CreateDirectory(FileHandler.pathTlauncherMods);
                MessageBox.Show("Папка 'mods' для TLauncher была создана.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                checkBox6.Checked = true; // Активируем флажок для TLauncher
            }

            if (checkBox6.Checked && checkBox1.Checked)
            {
                var result = MessageBox.Show("У вас две версии, с какой работать? Да=TLauncher Нет=Legacy", "Выбор версии", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                if (result == DialogResult.Yes)
                {
                    checkBox1.Checked = false; // Выбрана версия "tlauncher"
                }
                else
                {
                    checkBox6.Checked = false; // Выбрана версия "legacy"
                }
            }
            else if (!checkBox6.Checked && !checkBox1.Checked)
            {
                MessageBox.Show("Ни одна из поддерживаемых версий лаунчера майнкрафт не обнаружена. Установите TLauncher или Legacy Launcher. Путь к legacy " + FileHandler.pathlegacyMods + " Путь у TLauncher " + FileHandler.pathTlauncherMods, "Ошибка поиска", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (checkBox1.Checked)
            {
                LoadVersions(FileHandler.pathlegacyVersions, FileHandler.pathlegacyConfig);
            }
            else if (checkBox6.Checked)
            {
                LoadVersions(FileHandler.pathTlauncherVersions, FileHandler.pathTlauncherConfig);
            }
            else
            {
                panel1.Enabled = false;
            }
        }

        private void LoadVersions(string versionsPath, string configPath)
        {
            string[] folders = Directory.GetDirectories(versionsPath);
            bool versionFound = false;

            foreach (string folder in folders)
            {
                string folderName = Path.GetFileName(folder);
                if (ContainsLetters(folderName))
                {
                    ChoseVersion.Items.Add(folderName);
                    CurrentVersion.Items.Add(folderName);
                    versionFound = true;
                    string currentVersionFile = Path.Combine(configPath, "current_version.ini");

                    if (File.Exists(currentVersionFile))
                    {
                        string activeItem = File.ReadAllText(currentVersionFile);
                        if (CurrentVersion.Items.Contains(activeItem))
                        {
                            CurrentVersion.SelectedItem = activeItem;
                            CurrentVersion.Enabled = false;
                        }
                    }
                }
            }

            if (!versionFound)
            {
                MessageBox.Show("Не обнаружено ни одной поддерживаемой версии. Установите версию имеющию поддержку Forge, Fabric, Quit", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CurrentVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleVersionSelection(CurrentVersion, checkBox1.Checked ? FileHandler.pathlegacyMods : FileHandler.pathTlauncherMods, checkBox2, checkBox3);
        }

        private void ChoseVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            HandleVersionSelection(ChoseVersion, checkBox1.Checked ? FileHandler.pathlegacyMods : FileHandler.pathTlauncherMods, checkBox4, checkBox5);
        }

        private void HandleVersionSelection(ComboBox comboBox, string targetDirectory, CheckBox checkBoxReady, CheckBox checkBoxCreated)
        {
            if (comboBox.SelectedItem != null)
            {
                string selectedVersion = comboBox.SelectedItem.ToString();
                string cleanedVersion = selectedVersion.Replace("OptiFine", "");

                string mainKeyword = Regex.Match(cleanedVersion, @"\b(Fabric|Quilt|Forge)\b", RegexOptions.IgnoreCase).Value;
                string version = Regex.Match(cleanedVersion, @"\d+(\.\d+)+").Value;

                if (!string.IsNullOrEmpty(mainKeyword) && !string.IsNullOrEmpty(version))
                {
                    string newFolderPath = Path.Combine(targetDirectory, mainKeyword + " " + version);

                    if (!Directory.Exists(newFolderPath))
                    {
                        Directory.CreateDirectory(newFolderPath);
                        checkBoxCreated.Checked = true;
                        checkBoxCreated.Text = "Создан";
                    }
                    else
                    {
                        checkBoxReady.Checked = true;
                        checkBoxReady.Text = "Уже готов";
                    }
                }
                else
                {
                    MessageBox.Show("Выбранный элемент не содержит ключевых слов (Fabric, Quilt, Forge).", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    checkBoxReady.Checked = false;
                    checkBoxCreated.Checked = false;
                }
            }
            else
            {
                MessageBox.Show("What?");
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if ((checkBox2.Checked || checkBox3.Checked) && (checkBox4.Checked || checkBox5.Checked))
            {
                string targetDirectory = checkBox1.Checked ? FileHandler.pathlegacyMods : FileHandler.pathTlauncherMods;
                string configPath = checkBox1.Checked ? FileHandler.pathlegacyConfig : FileHandler.pathTlauncherConfig;

                if (CurrentVersion.SelectedItem != null)
                {
                    MoveFiles(CurrentVersion.SelectedItem.ToString(), targetDirectory);
                }

                if (ChoseVersion.SelectedItem != null)
                {
                    MoveFiles(ChoseVersion.SelectedItem.ToString(), targetDirectory);
                }

                CurrentVersion.SelectedIndex = ChoseVersion.SelectedIndex;
                CurrentVersion.Enabled = false;

                string currentVersionFile = Path.Combine(configPath, "current_version.ini");
                if (!Directory.Exists(configPath))
                {
                    Directory.CreateDirectory(configPath);
                }

                File.WriteAllText(currentVersionFile, CurrentVersion.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("Не все готово!", "Готовность", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MoveFiles(string selectedVersion, string targetDirectory)
        {
            string cleanedVersion = selectedVersion.Replace("OptiFine", "");
            string mainKeyword = Regex.Match(cleanedVersion, @"\b(Fabric|Quilt|Forge)\b", RegexOptions.IgnoreCase).Value;
            string version = Regex.Match(cleanedVersion, @"\d+(\.\d+)+").Value;

            string versionNumbers = mainKeyword + " " + version;
            string sourceDirectory = Path.Combine(targetDirectory, versionNumbers);

            if (!Directory.Exists(sourceDirectory))
            {
                Directory.CreateDirectory(sourceDirectory);
            }

            string[] files = Directory.GetFiles(targetDirectory, "*.jar");
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file).Replace("OptiFine", "");
                string destFile = Path.Combine(sourceDirectory, fileName);

                if (File.Exists(destFile))
                {
                    var result = MessageBox.Show("Файл с таким именем уже установлен. Заменить его?", "Замена файла", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        File.Delete(destFile);
                        File.Move(file, destFile);
                    }
                }
                else
                {
                    File.Move(file, destFile);
                }
            }
        }

        private void btnLocalSearch_Click(object sender, EventArgs e)
        {
            if (checkBox2.Checked || checkBox3.Checked)
            {
                OpenFileDialog openFileExe = new OpenFileDialog
                {
                    InitialDirectory = FileHandler.pathOtherDownload,
                    Filter = "jar files (*.jar) | *.jar",
                    Multiselect = true
                };

                if (openFileExe.ShowDialog() == DialogResult.OK)
                {
                    string targetDirectory = checkBox1.Checked ? FileHandler.pathlegacyMods : FileHandler.pathTlauncherMods;

                    foreach (string filename in openFileExe.FileNames)
                    {
                        string destinationPath = Path.Combine(targetDirectory, Path.GetFileName(filename));

                        if (File.Exists(destinationPath))
                        {
                            var result = MessageBox.Show("Файл с именем " + Path.GetFileName(filename) + " уже установлен. Заменить его?", "Замена файла", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result == DialogResult.Yes)
                            {
                                File.Delete(destinationPath);
                                File.Move(filename, destinationPath);
                            }
                        }
                        else
                        {
                            File.Move(filename, destinationPath);
                        }
                    }

                    MessageBox.Show("Выбранные файлы успешно установлены на текущую версию", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не выбран файл", "Проблема", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Не выбранна текущая версия", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
