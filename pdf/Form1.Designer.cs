namespace pdf
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Очистить все используемые ресурсы.
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
        /// его содержимое в редакторе кода.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textBox1 = new TextBox();
            generateButton = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 13);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 0;
            label1.Text = "Ваш текст";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(13, 31);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(475, 102);
            textBox1.TabIndex = 1;
            // 
            // generateButton
            // 
            generateButton.Location = new Point(124, 139);
            generateButton.Name = "generateButton";
            generateButton.Size = new Size(259, 23);
            generateButton.TabIndex = 2;
            generateButton.Text = "Сгенерировать PDF";
            generateButton.UseVisualStyleBackColor = true;
            generateButton.Click += generateButton_Click;
            generateButton.BackColor = Color.FromArgb(46, 204, 113); 
            generateButton.ForeColor = Color.White;
            string text = textBox1.Text;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 210);
            Controls.Add(generateButton);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Генератор отчетов в формате PDF";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button generateButton;
    }
}
