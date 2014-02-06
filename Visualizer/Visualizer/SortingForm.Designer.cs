using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
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

            this.mainTitle.AutoSize = SortingFormSettings.MainTitleAutoSize;
            this.mainTitle.Font = SortingFormSettings.MainTitleFont;
            this.mainTitle.ForeColor = SortingFormSettings.MainTitleForeColor;
            this.mainTitle.Location = SortingFormSettings.MainTitleLocation;
            this.mainTitle.Name = SortingFormSettings.MainTitleName;
            this.mainTitle.Size = SortingFormSettings.MainTitleSize;
            this.mainTitle.TabIndex = SortingFormSettings.MainTitleTabIndex;
            this.mainTitle.Text = interfaceSettings.MainTitleText;

            // 
            // aboutSorting
            // 

            this.aboutSorting.BackColor = SortingFormSettings.AboutSortingBackColor;
            this.aboutSorting.BorderStyle = SortingFormSettings.AboutSortingBorderStyle;
            this.aboutSorting.Font = SortingFormSettings.AboutSortingFont;
            this.aboutSorting.FormattingEnabled = SortingFormSettings.AboutSortingFormattingEnabled;
            this.aboutSorting.ItemHeight = SortingFormSettings.AboutSortingItemHeight;
            this.aboutSorting.Location = SortingFormSettings.AboutSortingLocation;
            this.aboutSorting.Name = SortingFormSettings.AboutSortingName;
            this.aboutSorting.ScrollAlwaysVisible = SortingFormSettings.AboutSortingScrollAlwaysVisible;
            this.aboutSorting.Size = SortingFormSettings.AboutSortingSize;
            this.aboutSorting.TabIndex = SortingFormSettings.AboutSortingTabIndex;
            
            // 
            // mainMenu
            // 
            
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.programMenu, this.helpMenu });

            this.mainMenu.BackColor = SortingFormSettings.MainMenuBackColor;
            this.mainMenu.Location = SortingFormSettings.MainMenuLocation;
            this.mainMenu.Name = SortingFormSettings.MainMenuName;
            this.mainMenu.Size = SortingFormSettings.MainMenuSize;
            this.mainMenu.TabIndex = SortingFormSettings.MainMenuTabIndex;
            this.mainMenu.Text = SortingFormSettings.MainMenuText;

            // 
            // programMenu
            // 

            this.programMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.visualizerMenuItem, this.sourceCodeMenuItem });

            this.programMenu.Font = SortingFormSettings.ProgramMenuFont;
            this.programMenu.ForeColor = SortingFormSettings.ProgramMenuForeColor;
            this.programMenu.Name = SortingFormSettings.ProgramMenuName;
            this.programMenu.Size = SortingFormSettings.ProgramMenuSize;
            this.programMenu.Text = SortingFormSettings.ProgramMenuText;

            // 
            // visualizerMenuItem
            // 

            this.visualizerMenuItem.Name = SortingFormSettings.VisualizerMenuItemName;
            this.visualizerMenuItem.Size = SortingFormSettings.VisualizerMenuItemSize;
            this.visualizerMenuItem.Text = SortingFormSettings.VisualizerMenuItemText;
            this.visualizerMenuItem.Click += new System.EventHandler(this.RunVisualizer);

            // 
            // sourceCodeMenuItem
            //
 
            this.sourceCodeMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.sourceCodeCSharp, this.sourceCodeCPlusPlus, this.sourceCodeJava, this.sourceCodePython});

            this.sourceCodeMenuItem.Name = SortingFormSettings.SourceCodeMenuItemName;
            this.sourceCodeMenuItem.Size = SortingFormSettings.SourceCodeMenuItemSize;
            this.sourceCodeMenuItem.Text = SortingFormSettings.SourceCodeMenuItemText;

            // 
            // sourceCodeCSharp
            // 

            this.sourceCodeCSharp.Name = SortingFormSettings.SourceCodeCSharpName;
            this.sourceCodeCSharp.Size = SortingFormSettings.SourceCodeCSharpSize;
            this.sourceCodeCSharp.Text = SortingFormSettings.SourceCodeCSharpText;
            this.sourceCodeCSharp.Click += new System.EventHandler(this.ShowSourceCodeCSharp);
           
            // 
            // sourceCodeCPlusPlus
            //

            this.sourceCodeCPlusPlus.Name = SortingFormSettings.SourceCodeCPlusPlusName;
            this.sourceCodeCPlusPlus.Size = SortingFormSettings.SourceCodeCPlusPlusSize;
            this.sourceCodeCPlusPlus.Text = SortingFormSettings.SourceCodeCPlusPlusText;

            this.sourceCodeCPlusPlus.Click += new System.EventHandler(this.ShowSourceCodeCPlusPlus);

            // 
            // sourceCodeJava
            // 

            this.sourceCodeJava.Name = SortingFormSettings.SourceCodeJavaName;
            this.sourceCodeJava.Size = SortingFormSettings.SourceCodeJavaSize;
            this.sourceCodeJava.Text = SortingFormSettings.SourceCodeJavaText;

            this.sourceCodeJava.Click += new System.EventHandler(this.ShowSourceCodeJava);

            // 
            // sourceCodePython
            // 

            this.sourceCodePython.Name = SortingFormSettings.SourceCodePythonName;
            this.sourceCodePython.Size = SortingFormSettings.SourceCodePythonSize;
            this.sourceCodePython.Text = SortingFormSettings.SourceCodePythonText;

            this.sourceCodePython.Click += new System.EventHandler(this.ShowSourceCodePython);

            // 
            // helpMenu
            // 

            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.helpMenuItem });

            this.helpMenu.Font = SortingFormSettings.HelpMenuFont;
            this.helpMenu.ForeColor = SortingFormSettings.HelpMenuForeColor;
            this.helpMenu.Name = SortingFormSettings.HelpMenuName;
            this.helpMenu.Size = SortingFormSettings.HelpMenuSize;
            this.helpMenu.Text = SortingFormSettings.HelpMenuText;

            // 
            // helpMenuItem
            // 

            this.helpMenuItem.Name = SortingFormSettings.HelpMenuItemName;
            this.helpMenuItem.Size = SortingFormSettings.HelpMenuItemSize;
            this.helpMenuItem.Text = SortingFormSettings.HelpMenuItemText;

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

            this.AutoScaleDimensions = SortingFormSettings.AutoScaleDimensions;
            this.AutoScaleMode = SortingFormSettings.AutoScaleMode;
            this.BackColor = SortingFormSettings.BackColor;
            this.ClientSize = SortingFormSettings.ClientSize;
            this.Name = SortingFormSettings.Name;
            this.Text = "BubbleSortForm";
       }

        #endregion
    }
}