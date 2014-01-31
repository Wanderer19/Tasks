namespace Visualizer
{
    partial class BubbleSortForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        #region Windows Form Designer generated codeprogramMenu

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bubbleSortTitle = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.programMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizer = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceCode = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceCodeCSharp = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceCodeCPlusPlus = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceCodeJava = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceCodePython = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.help = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bubbleSortTitle
            // 
            this.bubbleSortTitle.AutoSize = true;
            this.bubbleSortTitle.Font = new System.Drawing.Font("Segoe Script", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bubbleSortTitle.ForeColor = System.Drawing.Color.MidnightBlue;
            this.bubbleSortTitle.Location = new System.Drawing.Point(12, 48);
            this.bubbleSortTitle.Name = "bubbleSortTitle";
            this.bubbleSortTitle.Size = new System.Drawing.Size(723, 80);
            this.bubbleSortTitle.TabIndex = 0;
            this.bubbleSortTitle.Text = "Пузырьковая Сортировка";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 29;
            this.listBox1.Items.AddRange(new object[] {
            "Сортировка простыми обменами, сортиро́вка пузырько́м",
            "(англ. bubble sort) — простой алгоритм сортировки.",
            "Для понимания и реализации этот алгоритм — простейший, ",
            "но эффективен он лишь для небольших массивов. Сложность",
            "алгоритма: O(n²). Алгоритм считается учебным и практически ",
            "не применяется вне учебной литературы, вместо него на практике ",
            "применяются более эффективные алгоритмы сортировки. ",
            "В то же время метод сортировки обменами лежит в основе ",
            "некоторых более совершенных алгоритмов, таких как шейкерная",
            "сортировка, пирамидальная сортировка и быстрая сортировка.",
            "",
            "Алгоритм",
            "Алгоритм состоит из повторяющихся проходов по сортируемому ",
            "массиву. За каждый проход элементы последовательно сравниваются",
            "попарно и, если порядок в паре неверный, выполняется обмен ",
            "элементов. Проходы по массиву повторяются N-1 раз или до тех пор, ",
            "пока на очередном проходе не окажется, что обмены больше не нужны, ",
            "что означает — массив отсортирован. При каждом проходе алгоритма ",
            "по внутреннему циклу, очередной наибольший элемент массива ставится ",
            "на своё место в конце массива рядом с предыдущим «наибольшим ",
            "элементом», а наименьший элемент перемещается на одну позицию",
            "к началу массива («всплывает» до нужной позиции как пузырёк ",
            "в воде, отсюда и название алгоритма).",
            "",
            "Особенность данного алгоритма заключается в следующем: после ",
            "первого завершения внутреннего цикла максимальный элемент ",
            "массива всегда находится на N-ой позиции. При втором проходе, ",
            "следующий по значению максимальный элемент находится ",
            "на N-1 месте. И так далее. Таким образом, на каждом следующем",
            " проходе число обрабатываемых элементов уменьшается на 1 и ",
            "нет необходимости «обходить» весь массив от начала до конца",
            "каждый раз."});
            this.listBox1.Location = new System.Drawing.Point(12, 140);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(861, 609);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programMenu,
            this.helpMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(850, 36);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // programMenu
            // 
            this.programMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visualizer,
            this.sourceCode});
            this.programMenu.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.programMenu.ForeColor = System.Drawing.Color.Navy;
            this.programMenu.Name = "programMenu";
            this.programMenu.Size = new System.Drawing.Size(146, 32);
            this.programMenu.Text = "Программа";
            // 
            // visualizer
            // 
            this.visualizer.Name = "visualizer";
            this.visualizer.Size = new System.Drawing.Size(237, 32);
            this.visualizer.Text = "Визуализатор";
            this.visualizer.Click += new System.EventHandler(this.RunVisualizer);
            // 
            // sourceCode
            // 
            this.sourceCode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sourceCodeCSharp,
            this.sourceCodeCPlusPlus,
            this.sourceCodeJava,
            this.sourceCodePython});
            this.sourceCode.Name = "sourceCode";
            this.sourceCode.Size = new System.Drawing.Size(237, 32);
            this.sourceCode.Text = "Исходный код";
            // 
            // sourceCodeCSharp
            // 
            this.sourceCodeCSharp.Name = "sourceCodeCSharp";
            this.sourceCodeCSharp.Size = new System.Drawing.Size(152, 32);
            this.sourceCodeCSharp.Text = "C#";
            this.sourceCodeCSharp.Click += new System.EventHandler(this.ShowSourceCodeCSharp);
            // 
            // sourceCodeCPlusPlus
            // 
            this.sourceCodeCPlusPlus.Name = "sourceCodeCPlusPlus";
            this.sourceCodeCPlusPlus.Size = new System.Drawing.Size(152, 32);
            this.sourceCodeCPlusPlus.Text = "C++";
            this.sourceCodeCPlusPlus.Click += new System.EventHandler(this.ShowSourceCodeCPlusPlus);
            // 
            // sourceCodeJava
            // 
            this.sourceCodeJava.Name = "sourceCodeJava";
            this.sourceCodeJava.Size = new System.Drawing.Size(152, 32);
            this.sourceCodeJava.Text = "Java";
            this.sourceCodeJava.Click += new System.EventHandler(this.ShowSourceCodeJava);
            // 
            // sourceCodePython
            // 
            this.sourceCodePython.Name = "sourceCodePython";
            this.sourceCodePython.Size = new System.Drawing.Size(152, 32);
            this.sourceCodePython.Text = "Python";
            this.sourceCodePython.Click += new System.EventHandler(this.ShowSourceCodePython);
            // 
            // helpMenu
            // 
            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.help});
            this.helpMenu.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpMenu.ForeColor = System.Drawing.Color.Navy;
            this.helpMenu.Name = "helpMenu";
            this.helpMenu.Size = new System.Drawing.Size(116, 32);
            this.helpMenu.Text = "Справка";
            // 
            // help
            // 
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(175, 32);
            this.help.Text = "Помощь";
            this.help.Click += new System.EventHandler(this.ShowHelp);
            // 
            // BubbleSortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(850, 753);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.bubbleSortTitle);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "BubbleSortForm";
            this.Text = "BubbleSortForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label bubbleSortTitle;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem programMenu;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem visualizer;
        private System.Windows.Forms.ToolStripMenuItem sourceCode;
        private System.Windows.Forms.ToolStripMenuItem sourceCodeCSharp;
        private System.Windows.Forms.ToolStripMenuItem sourceCodeCPlusPlus;
        private System.Windows.Forms.ToolStripMenuItem sourceCodeJava;
        private System.Windows.Forms.ToolStripMenuItem sourceCodePython;
        private System.Windows.Forms.ToolStripMenuItem help;
    }
}