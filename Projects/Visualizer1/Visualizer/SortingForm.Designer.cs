using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Visualizer
{
    partial class SortingForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label mainTitle;
        private System.Windows.Forms.ListBox aboutSorting;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem programMenu;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.ToolStripMenuItem visualizerMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sourceCodeMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sourceCodeCSharp;
        private System.Windows.Forms.ToolStripMenuItem sourceCodeCPlusPlus;
        private System.Windows.Forms.ToolStripMenuItem sourceCodeJava;
        private System.Windows.Forms.ToolStripMenuItem sourceCodePython;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;

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
            this.mainTitle = new System.Windows.Forms.Label();
            this.aboutSorting = new System.Windows.Forms.ListBox();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.programMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceCodeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceCodeCSharp = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceCodeCPlusPlus = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceCodeJava = new System.Windows.Forms.ToolStripMenuItem();
            this.sourceCodePython = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();

            // 
            // mainTitle
            // 

            this.mainTitle.AutoSize = (bool) sortingFormSettings.GetObject("MainTitleAutoSize");
            this.mainTitle.Font = (Font) sortingFormSettings.GetObject("MainTitleFont");
            this.mainTitle.ForeColor = (Color) sortingFormSettings.GetObject("MainTitleForeColor");
            this.mainTitle.Location = (Point) sortingFormSettings.GetObject("MainTitleLocation");
            this.mainTitle.Name = sortingFormSettings.GetString("MainTitleName");
            this.mainTitle.Size = (Size) sortingFormSettings.GetObject("MainTitleSize");
            this.mainTitle.TabIndex = (int) sortingFormSettings.GetObject("MainTitleTabIndex");
            this.mainTitle.Text = sortingFormSettings.GetString("MainTitleText");

            // 
            // aboutSorting
            // 

            this.aboutSorting.BackColor = (Color) sortingFormSettings.GetObject("AboutSortingBackColor");
            this.aboutSorting.BorderStyle = (BorderStyle) sortingFormSettings.GetObject("AboutSortingBorderStyle");
            this.aboutSorting.Font = (Font) sortingFormSettings.GetObject("AboutSortingFont");
            this.aboutSorting.FormattingEnabled = (bool) sortingFormSettings.GetObject("AboutSortingFormattingEnabled");
            this.aboutSorting.ItemHeight = (int) sortingFormSettings.GetObject("AboutSortingItemHeight");
            this.aboutSorting.Location = (Point) sortingFormSettings.GetObject("AboutSortingLocation");
            this.aboutSorting.Name = sortingFormSettings.GetString("AboutSortingName");
            this.aboutSorting.ScrollAlwaysVisible = (bool) sortingFormSettings.GetObject("AboutSortingScrollAlwaysVisible");
            this.aboutSorting.Size = (Size) sortingFormSettings.GetObject("AboutSortingSize");
            this.aboutSorting.TabIndex = (int) sortingFormSettings.GetObject("AboutSortingTabIndex");
            this.aboutSorting.Items.AddRange((string [])sortingFormSettings.GetObject("AboutSortingFile"));
            
            // 
            // mainMenu
            // 

            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.programMenu, this.helpMenu});

            this.mainMenu.BackColor = (Color) sortingFormSettings.GetObject("MainMenuBackColor");
            this.mainMenu.Location = (Point) sortingFormSettings.GetObject("MainMenuLocation");
            this.mainMenu.Name = sortingFormSettings.GetString("MainMenuName");
            this.mainMenu.Size = (Size) sortingFormSettings.GetObject("MainMenuSize");
            this.mainMenu.TabIndex = (int) sortingFormSettings.GetObject("MainMenuTabIndex");
            this.mainMenu.Text = sortingFormSettings.GetString("MainMenuText");

            // 
            // programMenu
            // 

            this.programMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {this.visualizerMenuItem, this.sourceCodeMenuItem});

            this.programMenu.Font = (Font) sortingFormSettings.GetObject("ProgramMenuFont");
            this.programMenu.ForeColor = (Color) sortingFormSettings.GetObject("ProgramMenuForeColor");
            this.programMenu.Name = sortingFormSettings.GetString("ProgramMenuName");
            this.programMenu.Size = (Size) sortingFormSettings.GetObject("ProgramMenuSize");
            this.programMenu.Text = sortingFormSettings.GetString("ProgramMenuText");

            // 
            // visualizerMenuItem
            // 

            this.visualizerMenuItem.Name = sortingFormSettings.GetString("VisualizerMenuItemName");
            this.visualizerMenuItem.Size = (Size) sortingFormSettings.GetObject("VisualizerMenuItemSize");
            this.visualizerMenuItem.Text = sortingFormSettings.GetString("VisualizerMenuItemText");
            this.visualizerMenuItem.Click += new System.EventHandler(this.RunVisualizer);

            // 
            // sourceCodeMenuItem
            //

            this.sourceCodeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {this.sourceCodeCSharp, this.sourceCodeCPlusPlus, this.sourceCodeJava, this.sourceCodePython});

            this.sourceCodeMenuItem.Name = sortingFormSettings.GetString("SourceCodeMenuItemName");
            this.sourceCodeMenuItem.Size = (Size) sortingFormSettings.GetObject("SourceCodeMenuItemSize");
            this.sourceCodeMenuItem.Text = sortingFormSettings.GetString("SourceCodeMenuItemText");

            // 
            // sourceCodeCSharp
            // 

            this.sourceCodeCSharp.Name = sortingFormSettings.GetString("SourceCodeCSharpName");
            this.sourceCodeCSharp.Size = (Size) sortingFormSettings.GetObject("SourceCodeCSharpSize");
            this.sourceCodeCSharp.Text = sortingFormSettings.GetString("SourceCodeCSharpText");
            this.sourceCodeCSharp.Click += new System.EventHandler(this.ShowSourceCodeCSharp);
           
            // 
            // sourceCodeCPlusPlus
            //

            this.sourceCodeCPlusPlus.Name = sortingFormSettings.GetString("SourceCodeCPlusPlusName");
            this.sourceCodeCPlusPlus.Size = (Size) sortingFormSettings.GetObject("SourceCodeCPlusPlusSize");
            this.sourceCodeCPlusPlus.Text = sortingFormSettings.GetString("SourceCodeCPlusPlusText");

            this.sourceCodeCPlusPlus.Click += new System.EventHandler(this.ShowSourceCodeCPlusPlus);

            // 
            // sourceCodeJava
            // 

            this.sourceCodeJava.Name = sortingFormSettings.GetString("SourceCodeJavaName");
            this.sourceCodeJava.Size = (Size) sortingFormSettings.GetObject("SourceCodeJavaSize");
            this.sourceCodeJava.Text = sortingFormSettings.GetString("SourceCodeJavaText");

            this.sourceCodeJava.Click += new System.EventHandler(this.ShowSourceCodeJava);

            // 
            // sourceCodePython
            // 

            this.sourceCodePython.Name = sortingFormSettings.GetString("SourceCodePythonName");
            this.sourceCodePython.Size = (Size) sortingFormSettings.GetObject("SourceCodePythonSize");
            this.sourceCodePython.Text = sortingFormSettings.GetString("SourceCodePythonText");

            this.sourceCodePython.Click += new System.EventHandler(this.ShowSourceCodePython);

            // 
            // helpMenu
            // 

            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.helpMenuItem});

            this.helpMenu.Font = (Font) sortingFormSettings.GetObject("HelpMenuFont");
            this.helpMenu.ForeColor = (Color) sortingFormSettings.GetObject("HelpMenuForeColor");
            this.helpMenu.Name = sortingFormSettings.GetString("HelpMenuName");
            this.helpMenu.Size = (Size) sortingFormSettings.GetObject("HelpMenuSize");
            this.helpMenu.Text = sortingFormSettings.GetString("HelpMenuText");

            // 
            // helpMenuItem
            // 

            this.helpMenuItem.Name = sortingFormSettings.GetString("HelpMenuItemName");
            this.helpMenuItem.Size = (Size) sortingFormSettings.GetObject("HelpMenuItemSize");
            this.helpMenuItem.Text = sortingFormSettings.GetString("HelpMenuItemText");

            this.helpMenuItem.Click += new System.EventHandler(this.ShowHelp);

            // 
            // BubbleSortForm
            // 

            this.Controls.Add(this.aboutSorting);
            this.Controls.Add(this.mainTitle);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.Closed += new System.EventHandler(this.CloseBubbleSortForm);
            this.ResumeLayout(false);
            this.PerformLayout();

            this.AutoScaleDimensions = (SizeF) sortingFormSettings.GetObject("AutoScaleDimensions");
            this.AutoScaleMode = (System.Windows.Forms.AutoScaleMode) sortingFormSettings.GetObject("AutoScaleMode");
            this.BackColor = (Color) sortingFormSettings.GetObject("BackColor");
            this.ClientSize = (Size) sortingFormSettings.GetObject("ClientSize");
            this.Name = sortingFormSettings.GetString("Name");
            this.Text = sortingFormSettings.GetString("BubbleSortForm");
       }

        #endregion
    }
}