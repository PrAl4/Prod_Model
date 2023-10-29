namespace Prod_Model
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
            this.Direct_output = new System.Windows.Forms.Button();
            this.Reverse_output = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.Check_elem = new System.Windows.Forms.CheckedListBox();
            this.All_rules = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.allRules = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.text_rulles = new System.Windows.Forms.TextBox();
            this.Close_rulles = new System.Windows.Forms.Button();
            this.resultes = new System.Windows.Forms.CheckedListBox();
            this.all_results = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Direct_output
            // 
            this.Direct_output.Location = new System.Drawing.Point(13, 14);
            this.Direct_output.Name = "Direct_output";
            this.Direct_output.Size = new System.Drawing.Size(174, 73);
            this.Direct_output.TabIndex = 0;
            this.Direct_output.Text = "Прямой вывод";
            this.Direct_output.UseVisualStyleBackColor = true;
            this.Direct_output.Click += new System.EventHandler(this.Direct_output_Click);
            // 
            // Reverse_output
            // 
            this.Reverse_output.Location = new System.Drawing.Point(13, 93);
            this.Reverse_output.Name = "Reverse_output";
            this.Reverse_output.Size = new System.Drawing.Size(174, 73);
            this.Reverse_output.TabIndex = 1;
            this.Reverse_output.Text = "Обратный вывод";
            this.Reverse_output.UseVisualStyleBackColor = true;
            this.Reverse_output.Click += new System.EventHandler(this.Reverse_output_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(13, 567);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(174, 73);
            this.Clear.TabIndex = 2;
            this.Clear.Text = "Очистить";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Check_elem
            // 
            this.Check_elem.FormattingEnabled = true;
            this.Check_elem.Location = new System.Drawing.Point(520, 48);
            this.Check_elem.Name = "Check_elem";
            this.Check_elem.Size = new System.Drawing.Size(294, 599);
            this.Check_elem.TabIndex = 3;
            // 
            // All_rules
            // 
            this.All_rules.Location = new System.Drawing.Point(12, 205);
            this.All_rules.Name = "All_rules";
            this.All_rules.Size = new System.Drawing.Size(174, 73);
            this.All_rules.TabIndex = 4;
            this.All_rules.Text = "Показать все правила";
            this.All_rules.UseVisualStyleBackColor = true;
            this.All_rules.Click += new System.EventHandler(this.All_rules_Click);
            // 
            // allRules
            // 
            this.allRules.Location = new System.Drawing.Point(208, 48);
            this.allRules.Multiline = true;
            this.allRules.Name = "allRules";
            this.allRules.Size = new System.Drawing.Size(294, 599);
            this.allRules.TabIndex = 5;
            this.allRules.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(520, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(294, 22);
            this.textBox1.TabIndex = 6;
            this.textBox1.Text = "Все компоненты";
            // 
            // text_rulles
            // 
            this.text_rulles.Location = new System.Drawing.Point(208, 14);
            this.text_rulles.Name = "text_rulles";
            this.text_rulles.Size = new System.Drawing.Size(294, 22);
            this.text_rulles.TabIndex = 7;
            this.text_rulles.Text = "Все правила";
            this.text_rulles.Visible = false;
            // 
            // Close_rulles
            // 
            this.Close_rulles.Location = new System.Drawing.Point(13, 284);
            this.Close_rulles.Name = "Close_rulles";
            this.Close_rulles.Size = new System.Drawing.Size(174, 73);
            this.Close_rulles.TabIndex = 8;
            this.Close_rulles.Text = "Скрыть все правила";
            this.Close_rulles.UseVisualStyleBackColor = true;
            this.Close_rulles.Click += new System.EventHandler(this.Close_rulles_Click);
            // 
            // resultes
            // 
            this.resultes.FormattingEnabled = true;
            this.resultes.Location = new System.Drawing.Point(835, 48);
            this.resultes.Name = "resultes";
            this.resultes.Size = new System.Drawing.Size(294, 599);
            this.resultes.TabIndex = 9;
            this.resultes.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.resultes_ItemCheck);
            // 
            // all_results
            // 
            this.all_results.Location = new System.Drawing.Point(835, 14);
            this.all_results.Name = "all_results";
            this.all_results.Size = new System.Drawing.Size(294, 22);
            this.all_results.TabIndex = 10;
            this.all_results.Text = "Все исходы";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1580, 652);
            this.Controls.Add(this.all_results);
            this.Controls.Add(this.resultes);
            this.Controls.Add(this.Close_rulles);
            this.Controls.Add(this.text_rulles);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.allRules);
            this.Controls.Add(this.All_rules);
            this.Controls.Add(this.Check_elem);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.Reverse_output);
            this.Controls.Add(this.Direct_output);
            this.Name = "Form1";
            this.Text = "League of Legends Items";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Direct_output;
        private System.Windows.Forms.Button Reverse_output;
        private System.Windows.Forms.Button Clear;
        private System.Windows.Forms.CheckedListBox Check_elem;
        private System.Windows.Forms.Button All_rules;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox allRules;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox text_rulles;
        private System.Windows.Forms.Button Close_rulles;
        private System.Windows.Forms.CheckedListBox resultes;
        private System.Windows.Forms.TextBox all_results;
    }
}

