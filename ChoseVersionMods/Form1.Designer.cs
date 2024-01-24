namespace ChoseVersionMods
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.btnAction = new System.Windows.Forms.Button();
            this.LText2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.CurrentVersion = new System.Windows.Forms.ComboBox();
            this.LText1 = new System.Windows.Forms.Label();
            this.ChoseVersion = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.Search_Click = new System.Windows.Forms.OpenFileDialog();
            this.btnLocalSearch = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox1.Enabled = false;
            this.checkBox1.Font = new System.Drawing.Font("Papyrus", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.checkBox1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox1.Location = new System.Drawing.Point(22, 55);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(138, 48);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Legacy version";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.btnLocalSearch);
            this.panel1.Controls.Add(this.checkBox5);
            this.panel1.Controls.Add(this.checkBox4);
            this.panel1.Controls.Add(this.btnAction);
            this.panel1.Controls.Add(this.LText2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.checkBox3);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.CurrentVersion);
            this.panel1.Controls.Add(this.LText1);
            this.panel1.Controls.Add(this.ChoseVersion);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 116);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 286);
            this.panel1.TabIndex = 1;
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBox5.Enabled = false;
            this.checkBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox5.Location = new System.Drawing.Point(212, 166);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(78, 28);
            this.checkBox5.TabIndex = 10;
            this.checkBox5.Text = "Готовность 2";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBox4.Enabled = false;
            this.checkBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox4.Location = new System.Drawing.Point(41, 166);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(69, 28);
            this.checkBox4.TabIndex = 9;
            this.checkBox4.Text = "Готовность";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // btnAction
            // 
            this.btnAction.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAction.Location = new System.Drawing.Point(123, 203);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(90, 23);
            this.btnAction.TabIndex = 8;
            this.btnAction.Text = "Подготовить";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // LText2
            // 
            this.LText2.AutoSize = true;
            this.LText2.Font = new System.Drawing.Font("Papyrus", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LText2.Location = new System.Drawing.Point(37, 115);
            this.LText2.Name = "LText2";
            this.LText2.Size = new System.Drawing.Size(253, 21);
            this.LText2.TabIndex = 7;
            this.LText2.Text = "Выберите какую версию подготовить";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 286);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "label2";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBox3.Enabled = false;
            this.checkBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox3.Location = new System.Drawing.Point(212, 81);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(78, 28);
            this.checkBox3.TabIndex = 5;
            this.checkBox3.Text = "Готовность 2";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.checkBox2.Enabled = false;
            this.checkBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBox2.Location = new System.Drawing.Point(41, 81);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(69, 28);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Text = "Готовность";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // CurrentVersion
            // 
            this.CurrentVersion.FormattingEnabled = true;
            this.CurrentVersion.Location = new System.Drawing.Point(83, 54);
            this.CurrentVersion.Name = "CurrentVersion";
            this.CurrentVersion.Size = new System.Drawing.Size(172, 21);
            this.CurrentVersion.TabIndex = 3;
            this.CurrentVersion.Text = "Не выбран";
            this.CurrentVersion.SelectedIndexChanged += new System.EventHandler(this.CurrentVersion_SelectedIndexChanged);
            // 
            // LText1
            // 
            this.LText1.AutoSize = true;
            this.LText1.Dock = System.Windows.Forms.DockStyle.Top;
            this.LText1.Font = new System.Drawing.Font("Papyrus", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LText1.Location = new System.Drawing.Point(0, 0);
            this.LText1.Name = "LText1";
            this.LText1.Size = new System.Drawing.Size(332, 42);
            this.LText1.TabIndex = 2;
            this.LText1.Text = "                     Выберите текущую версию\r\nЭто очень важно для первого запуска" +
    " программы\r\n";
            // 
            // ChoseVersion
            // 
            this.ChoseVersion.FormattingEnabled = true;
            this.ChoseVersion.Location = new System.Drawing.Point(83, 139);
            this.ChoseVersion.Name = "ChoseVersion";
            this.ChoseVersion.Size = new System.Drawing.Size(172, 21);
            this.ChoseVersion.TabIndex = 0;
            this.ChoseVersion.Text = "Не выбран";
            this.ChoseVersion.SelectedIndexChanged += new System.EventHandler(this.ChoseVersion_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Papyrus", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label3.Location = new System.Drawing.Point(78, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 60);
            this.label3.TabIndex = 11;
            this.label3.Text = "Проверка файлов\r\n         Minecraft";
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.checkBox6.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.checkBox6.Enabled = false;
            this.checkBox6.Font = new System.Drawing.Font("Papyrus", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox6.ForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.checkBox6.Location = new System.Drawing.Point(160, 55);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(162, 48);
            this.checkBox6.TabIndex = 12;
            this.checkBox6.Text = "Tlauncher version";
            this.checkBox6.UseVisualStyleBackColor = false;
            // 
            // Search_Click
            // 
            this.Search_Click.FileName = "Search_Click";
            this.Search_Click.Multiselect = true;
            // 
            // btnLocalSearch
            // 
            this.btnLocalSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLocalSearch.Location = new System.Drawing.Point(83, 241);
            this.btnLocalSearch.Name = "btnLocalSearch";
            this.btnLocalSearch.Size = new System.Drawing.Size(172, 23);
            this.btnLocalSearch.TabIndex = 11;
            this.btnLocalSearch.Text = "Добавить моды локально";
            this.btnLocalSearch.UseVisualStyleBackColor = true;
            this.btnLocalSearch.Click += new System.EventHandler(this.btnLocalSearch_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(334, 402);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox ChoseVersion;
        private System.Windows.Forms.Label LText1;
        private System.Windows.Forms.ComboBox CurrentVersion;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LText2;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.Button btnLocalSearch;
        private System.Windows.Forms.OpenFileDialog Search_Click;
    }
}

