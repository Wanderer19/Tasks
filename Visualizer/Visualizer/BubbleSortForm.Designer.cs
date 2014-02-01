using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Visualizer
{
    partial class BubbleSortForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label bubbleSortTitle;
        private System.Windows.Forms.ListBox aboutSorting;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem programMenu;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem visualizer;
        private System.Windows.Forms.ToolStripMenuItem sourceCode;
        private System.Windows.Forms.ToolStripMenuItem sourceCodeCSharp;
        private System.Windows.Forms.ToolStripMenuItem sourceCodeCPlusPlus;
        private System.Windows.Forms.ToolStripMenuItem sourceCodeJava;
        private System.Windows.Forms.ToolStripMenuItem sourceCodePython;
        private System.Windows.Forms.ToolStripMenuItem help;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated codeprogramMenu

        private void InitializeComponent()
        {
            XDocument settings = XDocument.Load("BubbleSortFormSettings.xml");
            
            
            this.bubbleSortTitle = new System.Windows.Forms.Label();
            this.aboutSorting = new System.Windows.Forms.ListBox();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.programMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizer = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceCode = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceCodeCSharp = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceCodeCPlusPlus = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceCodeJava = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceCodePython = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.help = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
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
            // aboutSorting
            // 
            this.aboutSorting.BackColor = System.Drawing.Color.PaleTurquoise;
            this.aboutSorting.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.aboutSorting.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.aboutSorting.FormattingEnabled = true;
            this.aboutSorting.ItemHeight = 29;
         
            this.aboutSorting.Items.AddRange(settings.Element("main").Element("aboutSorting").Value.Split(new string[] { "\n" }, StringSplitOptions.None));
            this.aboutSorting.Location = new System.Drawing.Point(12, 140);
            this.aboutSorting.Name = "aboutSorting";
            this.aboutSorting.ScrollAlwaysVisible = true;
            this.aboutSorting.Size = new System.Drawing.Size(861, 609);
            this.aboutSorting.TabIndex = 1;
            this.aboutSorting.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.Color.PaleTurquoise;
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programMenu,
            this.helpMenu});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(850, 36);
            this.mainMenu.TabIndex = 2;
            this.mainMenu.Text = "mainMenu";
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
            this.help.Size = new System.Drawing.Size(172, 32);
            this.help.Text = "Помощь";
            this.help.Click += new System.EventHandler(this.ShowHelp);
            // 
            // BubbleSortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(850, 753);
            this.Controls.Add(this.aboutSorting);
            this.Controls.Add(this.bubbleSortTitle);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "BubbleSortForm";
            this.Text = "BubbleSortForm";
            this.Closed += new System.EventHandler(this.CloseBubbleSortForm);


            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}