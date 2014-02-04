using System;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace Visualizer
{
    partial class Application
    {
        
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label mainTitle;
        public System.Windows.Forms.Button bubbleSortButton;
        public System.Windows.Forms.Button selectionSortButton;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem helpProgramMenu;
        private System.Windows.Forms.ToolStripMenuItem aboutProgramMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;
        
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        
        private void InitializeComponent()
        {
            this.mainTitle = new System.Windows.Forms.Label();
            this.bubbleSortButton = new System.Windows.Forms.Button();
            this.selectionSortButton = new System.Windows.Forms.Button();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.helpProgramMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutProgramMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();

            // 
            // mainTitle
            // 

            this.mainTitle.AutoSize = GeneralSettings.MainTitleAutoSize;
            this.mainTitle.BackColor = GeneralSettings.MainTitleBackColor;
            this.mainTitle.Font = GeneralSettings.MainTitleFont;
            this.mainTitle.ForeColor = GeneralSettings.MainTitleForeColor;
            this.mainTitle.Location = GeneralSettings.MainTitleLocation;
            this.mainTitle.Margin = GeneralSettings.MainTitleMargin;
            this.mainTitle.Name = GeneralSettings.MainTitleName;
            this.mainTitle.Size = GeneralSettings.MainTitleSize;
            this.mainTitle.TabIndex = GeneralSettings.MainTitleTabIndex;
            this.mainTitle.Text = GeneralSettings.MainTitleText;
            this.mainTitle.TextAlign = GeneralSettings.MainTitleTextAlign;
            
            // 
            // bubbleSortButton
            // 

            this.bubbleSortButton.BackColor = GeneralSettings.ButtonBackColor;
            this.bubbleSortButton.Cursor = GeneralSettings.ButtonCursor;
            this.bubbleSortButton.FlatAppearance.BorderColor = GeneralSettings.ButtonBorderColor;
            this.bubbleSortButton.FlatAppearance.BorderSize = GeneralSettings.ButtonBorderSize;
            this.bubbleSortButton.FlatAppearance.MouseDownBackColor = GeneralSettings.ButtonMouseDownBackColor;
            this.bubbleSortButton.FlatAppearance.MouseOverBackColor = GeneralSettings.ButtonMouseOverBackColor;
            this.bubbleSortButton.FlatStyle = GeneralSettings.ButtonFlatStyle;
            this.bubbleSortButton.Font = GeneralSettings.ButtonFont;
            this.bubbleSortButton.ForeColor = GeneralSettings.ButtonForeColor;
            this.bubbleSortButton.Location = GeneralSettings.BubbleSortButtonLocation;
            this.bubbleSortButton.Name = GeneralSettings.BubbleSortButtonName;
            this.bubbleSortButton.Size = GeneralSettings.ButtonSize;
            this.bubbleSortButton.TabIndex = GeneralSettings.BubbleSortButtonTabIndex;
            this.bubbleSortButton.Text = GeneralSettings.BubbleSortButtonText;
            this.bubbleSortButton.UseVisualStyleBackColor = GeneralSettings.ButtonUseVisualStyleBackColor;
            this.bubbleSortButton.Click += new System.EventHandler(this.BubbleSortRun);

            this.selectionSortButton.BackColor = GeneralSettings.ButtonBackColor;
            this.selectionSortButton.Cursor = GeneralSettings.ButtonCursor;
            this.selectionSortButton.FlatAppearance.BorderColor = GeneralSettings.ButtonBorderColor;
            this.selectionSortButton.FlatAppearance.BorderSize = GeneralSettings.ButtonBorderSize;
            this.selectionSortButton.FlatAppearance.MouseDownBackColor = GeneralSettings.ButtonMouseDownBackColor;
            this.selectionSortButton.FlatAppearance.MouseOverBackColor = GeneralSettings.ButtonMouseOverBackColor;
            this.selectionSortButton.FlatStyle = GeneralSettings.ButtonFlatStyle;
            this.selectionSortButton.Font = GeneralSettings.ButtonFont;
            this.selectionSortButton.ForeColor = GeneralSettings.ButtonForeColor;
            this.selectionSortButton.Location = GeneralSettings.SelectionSortButtonLocation;
            this.selectionSortButton.Name = GeneralSettings.SelectionSortButtonName;
            this.selectionSortButton.Size = GeneralSettings.ButtonSize;
            this.selectionSortButton.TabIndex = GeneralSettings.SelectionSortButtonTabIndex;
            this.selectionSortButton.Text = GeneralSettings.SelectionSortButtonText;
            this.selectionSortButton.UseVisualStyleBackColor = GeneralSettings.ButtonUseVisualStyleBackColor;

            this.selectionSortButton.Click += new System.EventHandler(this.SelectionSortRun);
            

            // 
            // mainMenu
            // 

            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.helpProgramMenu });

            this.mainMenu.BackColor = GeneralSettings.MainMenuBackColor;
            this.mainMenu.Font = GeneralSettings.MainMenuFont;
            this.mainMenu.Location = GeneralSettings.MainMenuLocation;
            this.mainMenu.Name = GeneralSettings.MainMenuName;
            this.mainMenu.Size = GeneralSettings.MainMenuSize;
            this.mainMenu.TabIndex = GeneralSettings.MainMenuTabIndex;
          
            // 
            // helpProgramMenu
            // 

            this.helpProgramMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.aboutProgramMenuItem, this.helpMenuItem });

            this.helpProgramMenu.Font = GeneralSettings.HelpProgramMenuFont;
            this.helpProgramMenu.ForeColor = GeneralSettings.HelpProgramMenuForeColor;
            this.helpProgramMenu.Name = GeneralSettings.HelpProgramMenuName;
            this.helpProgramMenu.Size = GeneralSettings.HelpProgramMenuSize;
            this.helpProgramMenu.Text = GeneralSettings.HelpProgramMenuText;

            // 
            // aboutProgramMenuItem
            // 

            this.aboutProgramMenuItem.Name = GeneralSettings.AboutProgramMenuItemName;
            this.aboutProgramMenuItem.Size = GeneralSettings.AboutProgramMenuItemSize;
            this.aboutProgramMenuItem.Text = GeneralSettings.AboutProgramMenuItemText;
            this.aboutProgramMenuItem.Click += new System.EventHandler(this.ShowAboutProgram);

            // 
            // ShowHelp
            // 

            this.helpMenuItem.Name = GeneralSettings.HelpMenuItemName;
            this.helpMenuItem.Size = GeneralSettings.HelpMenuItemSize;
            this.helpMenuItem.Text = GeneralSettings.HelpMenuItemText;
            this.helpMenuItem.Click += new System.EventHandler(this.ShowHelp);

            // 
            // Application
            // 

            this.AutoScaleDimensions = GeneralSettings.AutoScaleDimensions;
            this.AutoScaleMode = GeneralSettings.AutoScaleMode;
            this.BackColor = GeneralSettings.BackColor;
            this.ClientSize = GeneralSettings.ClientSize;
            this.Font = GeneralSettings.Font;
            this.Margin = GeneralSettings.Margin;
            this.StartPosition = GeneralSettings.StartPosition;
            this.Text = GeneralSettings.Text;

            this.Controls.Add(this.bubbleSortButton);
            this.Controls.Add(this.selectionSortButton);
            this.Controls.Add(this.mainTitle);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}

