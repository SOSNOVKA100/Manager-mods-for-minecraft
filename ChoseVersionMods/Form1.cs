﻿using System;
using System.Data;
using System.IO;
using System.Linq;
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

            //**                 **                          **//
            public static string pathTlauncherMods = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Roaming", ".minecraft", "mods");
            public static string pathTlauncherVersions = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Roaming", ".minecraft", "versions");
            public static string pathTlauncherConfig = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Roaming", ".minecraft", "mods", "mngConfig");
            // Другие методы и свойства вашего класса...
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            checkBox1.Checked = Directory.Exists(FileHandler.pathlegacyMods);
            checkBox6.Checked = Directory.Exists(FileHandler.pathTlauncherMods);
            if (checkBox6.Checked == true && checkBox1.Checked == true)
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
            if (checkBox1.Checked == true)
            {
                string yourPath = FileHandler.pathlegacyVersions;
                string[] folders = Directory.GetDirectories(yourPath);
                foreach (string folder in folders)
                {
                    string folderName = Path.GetFileName(folder);
                    if (ContainsLetters(folderName))
                    {
                        ChoseVersion.Items.Add(folderName);
                        CurrentVersion.Items.Add(folderName);
                        string modsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), FileHandler.pathlegacyConfig);
                        string currentVersionFile = Path.Combine(modsFolder, "current_version.txt");

                        if (File.Exists(currentVersionFile))
                        {
                            string activeItem = File.ReadAllText(currentVersionFile);
                            if (CurrentVersion.Items.Contains(activeItem))
                            {
                                CurrentVersion.SelectedItem = activeItem;
                                CurrentVersion.Enabled = false;
                            }
                            else
                            {
                                // Обработка случая, если элемент не найден в ComboBox
                            }
                        }
                    }
                    else
                    {
                        // Игнорируем папки, содержащие только цифры и точки
                    }
                }

            }
            else if (checkBox6.Checked == true)
            {
                string yourPath = FileHandler.pathTlauncherVersions;
                string[] folders = Directory.GetDirectories(yourPath);
                foreach (string folder in folders)
                {
                    string folderName = Path.GetFileName(folder);
                    if (ContainsLetters(folderName))
                    {
                        ChoseVersion.Items.Add(folderName);
                        CurrentVersion.Items.Add(folderName);
                        string modsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), FileHandler.pathTlauncherConfig);
                        string currentVersionFile = Path.Combine(modsFolder, "current_version.txt");

                        if (File.Exists(currentVersionFile))
                        {
                            string activeItem = File.ReadAllText(currentVersionFile);
                            if (CurrentVersion.Items.Contains(activeItem))
                            {
                                CurrentVersion.SelectedItem = activeItem;
                                CurrentVersion.Enabled = false;
                            }
                            else
                            {
                                // Обработка случая, если элемент не найден в ComboBox
                            }
                        }
                    }
                    else
                    {
                        // Игнорируем папки, содержащие только цифры и точки
                    }
                }
            }
            else { panel1.Enabled = false; }
        }

        private void CurrentVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {

                if (CurrentVersion.SelectedItem != null)
                {
                    string selectedVersion = CurrentVersion.SelectedItem.ToString();
                    string versionNumbers = new String(selectedVersion.Where(char.IsDigit).ToArray()); // Получаем только цифры и точки из выбранного элемента

                    string targetDirectory = FileHandler.pathlegacyMods; // Замените на вашу целевую директорию
                    string newFolderPath = Path.Combine(targetDirectory, versionNumbers);

                    if (!Directory.Exists(newFolderPath))
                    {
                        Directory.CreateDirectory(newFolderPath);
                        checkBox3.Checked = true;
                        checkBox3.Text = "Создан";
                    }
                    else
                    {
                        checkBox2.Checked = true;
                        checkBox2.Text = "Уже готов";
                    }
                }
                else
                {
                    label1.Text = "What?";
                }
            }
            else if (checkBox6.Checked == true)
            {

                if (CurrentVersion.SelectedItem != null)
                {
                    string selectedVersion = CurrentVersion.SelectedItem.ToString();
                    string versionNumbers = new String(selectedVersion.Where(char.IsDigit).ToArray()); // Получаем только цифры и точки из выбранного элемента

                    string targetDirectory = FileHandler.pathTlauncherMods; // Замените на вашу целевую директорию
                    string newFolderPath = Path.Combine(targetDirectory, versionNumbers);

                    if (!Directory.Exists(newFolderPath))
                    {
                        Directory.CreateDirectory(newFolderPath);
                        checkBox3.Checked = true;
                        checkBox3.Text = "Создан";
                    }
                    else
                    {
                        checkBox2.Checked = true;
                        checkBox2.Text = "Уже готов";
                    }
                }
                else
                {
                    label1.Text = "What?";
                }
            }

        }

        private void ChoseVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {

                if (ChoseVersion.SelectedItem != null)
                {
                    string selectedVersion = ChoseVersion.SelectedItem.ToString();
                    string versionNumbers = new String(selectedVersion.Where(char.IsDigit).ToArray()); // Получаем только цифры и точки из выбранного элемента

                    string targetDirectory = FileHandler.pathlegacyMods; // Замените на вашу целевую директорию
                    string newFolderPath = Path.Combine(targetDirectory, versionNumbers);

                    if (!Directory.Exists(newFolderPath))
                    {
                        Directory.CreateDirectory(newFolderPath);
                        checkBox5.Checked = true;
                        checkBox5.Text = "Создан";
                    }
                    else
                    {
                        checkBox4.Checked = true;
                        checkBox4.Text = "Уже готов";
                    }
                }
                else
                {
                    label1.Text = "What?";
                }
            }
            else if (checkBox6.Checked == true)
            {

                if (ChoseVersion.SelectedItem != null)
                {
                    string selectedVersion = ChoseVersion.SelectedItem.ToString();
                    string versionNumbers = new String(selectedVersion.Where(char.IsDigit).ToArray()); // Получаем только цифры и точки из выбранного элемента

                    string targetDirectory = FileHandler.pathTlauncherMods; // Замените на вашу целевую директорию
                    string newFolderPath = Path.Combine(targetDirectory, versionNumbers);

                    if (!Directory.Exists(newFolderPath))
                    {
                        Directory.CreateDirectory(newFolderPath);
                        checkBox5.Checked = true;
                        checkBox5.Text = "Создан";
                    }
                    else
                    {
                        checkBox4.Checked = true;
                        checkBox4.Text = "Уже готов";
                    }
                }
                else
                {
                    label1.Text = "What?";
                }
            }

        }

        private string GetVersionNumbers(string versionName)
        {
            return new String(versionName.Where(char.IsDigit).ToArray());
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                if ((checkBox2.Checked == true || checkBox3.Checked == true) && (checkBox4.Checked == true || checkBox5.Checked == true))
                {
                    if (CurrentVersion.SelectedItem != null)
                    {
                        string selectedVersion = CurrentVersion.SelectedItem.ToString();
                        string versionNumbers = GetVersionNumbers(selectedVersion);

                        string sourceDirectory = FileHandler.pathlegacyMods; // Замените на вашу исходную директорию
                        string targetDirectory = Path.Combine(FileHandler.pathlegacyMods, versionNumbers); // Замените на вашу целевую директорию
                        label2.Text = versionNumbers;
                        if (!Directory.Exists(targetDirectory))
                        {
                            Directory.CreateDirectory(targetDirectory);
                        }

                        string[] files = Directory.GetFiles(sourceDirectory, "*.jar");
                        foreach (string file in files)
                        {
                            string destFile = Path.Combine(targetDirectory, Path.GetFileName(file));

                            if (File.Exists(destFile))
                            {
                                var result = MessageBox.Show("Файл с таким именем уже существует. Заменить его?", "Замена файла", MessageBoxButtons.YesNo);
                                if (result == DialogResult.Yes)
                                {
                                    File.Delete(destFile); // Удаляем существующий файл
                                    File.Move(file, destFile); // Перемещаем файл и разрешаем замену
                                }
                            }
                            else
                            {
                                File.Move(file, destFile); // Просто перемещаем файл
                            }
                        }
                    }

                    if (ChoseVersion.SelectedItem != null)
                    {
                        string selectedVersion = ChoseVersion.SelectedItem.ToString();
                        string versionNumbers = GetVersionNumbers(selectedVersion);

                        string sourceDirectory = Path.Combine(FileHandler.pathlegacyMods, versionNumbers); // Замените на вашу целевую директорию
                        string targetDirectory = FileHandler.pathlegacyMods; // Замените на вашу исходную директорию
                        label1.Text = versionNumbers;
                        if (!Directory.Exists(targetDirectory))
                        {
                            Directory.CreateDirectory(targetDirectory);
                        }

                        string[] files = Directory.GetFiles(sourceDirectory, "*.jar");
                        foreach (string file in files)
                        {
                            string destFile = Path.Combine(targetDirectory, Path.GetFileName(file));

                            if (File.Exists(destFile))
                            {
                                var result = MessageBox.Show("Файл с таким именем уже установлен. Заменить его?", "Замена файла", MessageBoxButtons.YesNo);
                                if (result == DialogResult.Yes)
                                {
                                    File.Delete(destFile); // Удаляем существующий файл
                                    File.Move(file, destFile); // Перемещаем файл и разрешаем замену
                                }
                            }
                            else
                            {
                                File.Move(file, destFile); // Просто перемещаем файл
                            }
                        }
                    }
                    CurrentVersion.SelectedIndex = ChoseVersion.SelectedIndex;
                    CurrentVersion.Enabled = false;

                    string modsFolder = Path.Combine(Environment.CurrentDirectory, FileHandler.pathlegacyConfig);
                    string currentVersionFile = Path.Combine(modsFolder, "current_version.txt");

                    if (!Directory.Exists(modsFolder))
                    {
                        Directory.CreateDirectory(modsFolder);
                    }

                    string activeItem = CurrentVersion.SelectedItem.ToString(); // Получаем выбранный элемент из комбо-бокса
                    File.WriteAllText(currentVersionFile, activeItem);

                }
                else
                {
                    MessageBox.Show("Не все готово!");
                }
            }
            else if (checkBox6.Checked == true) //для тлаунчера
            {
                if ((checkBox2.Checked == true || checkBox3.Checked == true) && (checkBox4.Checked == true || checkBox5.Checked == true))
                {
                    if (CurrentVersion.SelectedItem != null)
                    {
                        string selectedVersion = CurrentVersion.SelectedItem.ToString();
                        string versionNumbers = GetVersionNumbers(selectedVersion);

                        string sourceDirectory = FileHandler.pathTlauncherMods; // Замените на вашу исходную директорию
                        string targetDirectory = Path.Combine(FileHandler.pathTlauncherMods, versionNumbers); // Замените на вашу целевую директорию
                        label2.Text = versionNumbers;
                        if (!Directory.Exists(targetDirectory))
                        {
                            Directory.CreateDirectory(targetDirectory);
                        }

                        string[] files = Directory.GetFiles(sourceDirectory, "*.jar");
                        foreach (string file in files)
                        {
                            string destFile = Path.Combine(targetDirectory, Path.GetFileName(file));

                            if (File.Exists(destFile))
                            {
                                var result = MessageBox.Show("Файл с таким именем уже существует. Заменить его?", "Замена файла", MessageBoxButtons.YesNo);
                                if (result == DialogResult.Yes)
                                {
                                    File.Delete(destFile); // Удаляем существующий файл
                                    File.Move(file, destFile); // Перемещаем файл и разрешаем замену
                                }
                            }
                            else
                            {
                                File.Move(file, destFile); // Просто перемещаем файл
                            }
                        }
                    }

                    if (ChoseVersion.SelectedItem != null)
                    {
                        string selectedVersion = ChoseVersion.SelectedItem.ToString();
                        string versionNumbers = GetVersionNumbers(selectedVersion);

                        string sourceDirectory = Path.Combine(FileHandler.pathTlauncherMods, versionNumbers); // Замените на вашу целевую директорию
                        string targetDirectory = FileHandler.pathTlauncherMods; // Замените на вашу исходную директорию
                        label1.Text = versionNumbers;
                        if (!Directory.Exists(targetDirectory))
                        {
                            Directory.CreateDirectory(targetDirectory);
                        }

                        string[] files = Directory.GetFiles(sourceDirectory, "*.jar");
                        foreach (string file in files)
                        {
                            string destFile = Path.Combine(targetDirectory, Path.GetFileName(file));

                            if (File.Exists(destFile))
                            {
                                var result = MessageBox.Show("Файл с таким именем уже установлен. Заменить его?", "Замена файла", MessageBoxButtons.YesNo);
                                if (result == DialogResult.Yes)
                                {
                                    File.Delete(destFile); // Удаляем существующий файл
                                    File.Move(file, destFile); // Перемещаем файл и разрешаем замену
                                }
                            }
                            else
                            {
                                File.Move(file, destFile); // Просто перемещаем файл
                            }
                        }
                    }
                    CurrentVersion.SelectedIndex = ChoseVersion.SelectedIndex;
                    CurrentVersion.Enabled = false;

                    string modsFolder = Path.Combine(Environment.CurrentDirectory, FileHandler.pathTlauncherConfig);
                    string currentVersionFile = Path.Combine(modsFolder, "current_version.txt");

                    if (!Directory.Exists(modsFolder))
                    {
                        Directory.CreateDirectory(modsFolder);
                    }

                    string activeItem = CurrentVersion.SelectedItem.ToString(); // Получаем выбранный элемент из комбо-бокса
                    File.WriteAllText(currentVersionFile, activeItem);

                }
                else
                {
                    MessageBox.Show("Не все готово!");
                }
            }



        }
    }
}