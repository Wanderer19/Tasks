using System;
using System.Drawing;
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
        public System.Windows.Forms.Button heapSortButton;
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
            this.heapSortButton = new System.Windows.Forms.Button();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.helpProgramMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutProgramMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            this.AutoScroll = true;
            // 
            // mainTitle
            // 

            this.mainTitle.AutoSize = (bool) generalSettings.GetObject("MainTitleAutoSize");
            this.mainTitle.BackColor = (Color)generalSettings.GetObject("MainTitleBackColor");
            this.mainTitle.Font = (Font)generalSettings.GetObject("MainTitleFont");
            this.mainTitle.ForeColor = (Color)generalSettings.GetObject("MainTitleForeColor");
            this.mainTitle.Location = (Point)generalSettings.GetObject("MainTitleLocation");
            this.mainTitle.Margin = (Padding)generalSettings.GetObject("MainTitleMargin");
            this.mainTitle.Name = generalSettings.GetString("MainTitleName");
            this.mainTitle.Size = (Size)generalSettings.GetObject("MainTitleSize");
            this.mainTitle.TabIndex = (int)generalSettings.GetObject("MainTitleTabIndex");
            this.mainTitle.Text = generalSettings.GetString("MainTitleText");
            this.mainTitle.TextAlign = (System.Drawing.ContentAlignment)generalSettings.GetObject("MainTitleTextAlign");
            
            // 
            // bubbleSortButton
            // 

            this.bubbleSortButton.BackColor = (Color)generalSettings.GetObject("ButtonBackColor");
            this.bubbleSortButton.Cursor = (Cursor) generalSettings.GetObject("ButtonCursor");
            this.bubbleSortButton.FlatAppearance.BorderColor = (Color)generalSettings.GetObject("ButtonBorderColor");
            this.bubbleSortButton.FlatAppearance.BorderSize = (int) generalSettings.GetObject("ButtonBorderSize");
            this.bubbleSortButton.FlatAppearance.MouseDownBackColor = (Color) generalSettings.GetObject("ButtonMouseDownBackColor");
            this.bubbleSortButton.FlatAppearance.MouseOverBackColor = (Color) generalSettings.GetObject("ButtonMouseOverBackColor");
            this.bubbleSortButton.FlatStyle = (FlatStyle) generalSettings.GetObject("ButtonFlatStyle");
            this.bubbleSortButton.Font = (Font)generalSettings.GetObject("ButtonFont");
            this.bubbleSortButton.ForeColor = (Color)generalSettings.GetObject("ButtonForeColor");
            this.bubbleSortButton.Location = (Point)generalSettings.GetObject("BubbleSortButtonLocation");
            this.bubbleSortButton.Name = generalSettings.GetString("BubbleSortButtonName");
            this.bubbleSortButton.Size = (Size) generalSettings.GetObject("ButtonSize");
            this.bubbleSortButton.TabIndex = (int) generalSettings.GetObject("BubbleSortButtonTabIndex");
            this.bubbleSortButton.Text = generalSettings.GetString("BubbleSortButtonText");
            this.bubbleSortButton.UseVisualStyleBackColor = (bool)generalSettings.GetObject("ButtonUseVisualStyleBackColor");
            this.bubbleSortButton.Click += new System.EventHandler(this.BubbleSortRun);

            //
            // selectionSortButton
            //
            
            this.selectionSortButton.BackColor = (Color) generalSettings.GetObject("ButtonBackColor");
            this.selectionSortButton.Cursor = (Cursor) generalSettings.GetObject("ButtonCursor");
            this.selectionSortButton.FlatAppearance.BorderColor = (Color) generalSettings.GetObject("ButtonBorderColor");
            this.selectionSortButton.FlatAppearance.BorderSize =(int) generalSettings.GetObject("ButtonBorderSize");
            this.selectionSortButton.FlatAppearance.MouseDownBackColor = (Color) generalSettings.GetObject("ButtonMouseDownBackColor");
            this.selectionSortButton.FlatAppearance.MouseOverBackColor = (Color)generalSettings.GetObject("ButtonMouseOverBackColor");
            this.selectionSortButton.FlatStyle = (FlatStyle) generalSettings.GetObject("ButtonFlatStyle");
            this.selectionSortButton.Font = (Font) generalSettings.GetObject("ButtonFont");
            this.selectionSortButton.ForeColor = (Color) generalSettings.GetObject("ButtonForeColor");
            this.selectionSortButton.Location = (Point) generalSettings.GetObject("SelectionSortButtonLocation");
            this.selectionSortButton.Name = generalSettings.GetString("SelectionSortButtonName");
            this.selectionSortButton.Size = (Size)generalSettings.GetObject("ButtonSize");
            this.selectionSortButton.TabIndex = (int) generalSettings.GetObject("SelectionSortButtonTabIndex");
            this.selectionSortButton.Text = generalSettings.GetString("SelectionSortButtonText");
            this.selectionSortButton.UseVisualStyleBackColor = (bool) generalSettings.GetObject("ButtonUseVisualStyleBackColor");

            this.selectionSortButton.Click += new System.EventHandler(this.SelectionSortRun);
            
            //
            // heapSortButton
            //

            this.heapSortButton.BackColor = (Color)generalSettings.GetObject("ButtonBackColor");
           this.heapSortButton.Cursor = (Cursor)generalSettings.GetObject("ButtonCursor");
           this.heapSortButton.FlatAppearance.BorderColor = (Color)generalSettings.GetObject("ButtonBorderColor");
           this.heapSortButton.FlatAppearance.BorderSize = (int)generalSettings.GetObject("ButtonBorderSize");
           this.heapSortButton.FlatAppearance.MouseDownBackColor = (Color)generalSettings.GetObject("ButtonMouseDownBackColor");
           this.heapSortButton.FlatAppearance.MouseOverBackColor = (Color)generalSettings.GetObject("ButtonMouseOverBackColor");
           this.heapSortButton.FlatStyle = (FlatStyle)generalSettings.GetObject("ButtonFlatStyle");
           this.heapSortButton.Font = (Font)generalSettings.GetObject("ButtonFont");
           this.heapSortButton.ForeColor = (Color)generalSettings.GetObject("ButtonForeColor");
           this.heapSortButton.Location = new Point(105, 516);
           this.heapSortButton.Size = (Size)generalSettings.GetObject("ButtonSize");
            this.heapSortButton.TabIndex = 5;
            this.heapSortButton.Text = "Пирамидальная сортировка";
           this.heapSortButton.UseVisualStyleBackColor = (bool)generalSettings.GetObject("ButtonUseVisualStyleBackColor");

           this.heapSortButton.Click += new System.EventHandler(this.HeapSortRun);
            
            // 
            // mainMenu
            // 

            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.helpProgramMenu});

            this.mainMenu.BackColor = (Color)generalSettings.GetObject("MainMenuBackColor");
            this.mainMenu.Font = (Font) generalSettings.GetObject("MainMenuFont");
            this.mainMenu.Location = (Point) generalSettings.GetObject("MainMenuLocation");
            this.mainMenu.Name = generalSettings.GetString("MainMenuName");
            this.mainMenu.Size = (Size) generalSettings.GetObject("MainMenuSize");
            this.mainMenu.TabIndex = (int) generalSettings.GetObject("MainMenuTabIndex");
          
            // 
            // helpProgramMenu
            // 

            this.helpProgramMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[]
            {this.aboutProgramMenuItem});

            this.helpProgramMenu.Font = (Font) generalSettings.GetObject("HelpProgramMenuFont");
            this.helpProgramMenu.ForeColor = (Color) generalSettings.GetObject("HelpProgramMenuForeColor");
            this.helpProgramMenu.Name = generalSettings.GetString("HelpProgramMenuName");
            this.helpProgramMenu.Size = (Size) generalSettings.GetObject("HelpProgramMenuSize");
            this.helpProgramMenu.Text = generalSettings.GetString("HelpProgramMenuText");

            // 
            // aboutProgramMenuItem
            // 

            this.aboutProgramMenuItem.Name = generalSettings.GetString("AboutProgramMenuItemName");
            this.aboutProgramMenuItem.Size = (Size) generalSettings.GetObject("AboutProgramMenuItemSize");
            this.aboutProgramMenuItem.Text = generalSettings.GetString("AboutProgramMenuItemText");
            this.aboutProgramMenuItem.Click += new System.EventHandler(this.ShowAboutProgram);

            // 
            // Application
            // 

            this.AutoScaleDimensions = (SizeF) generalSettings.GetObject("AutoScaleDimensions");
            this.AutoScaleMode = (System.Windows.Forms.AutoScaleMode) generalSettings.GetObject("AutoScaleMode");
            this.BackColor = (Color) generalSettings.GetObject("BackColor");
            this.ClientSize = (Size) generalSettings.GetObject("ClientSize");
            this.Font = (Font) generalSettings.GetObject("Font");
            this.Margin = (Padding) generalSettings.GetObject("Margin");
            this.StartPosition = (System.Windows.Forms.FormStartPosition) generalSettings.GetObject("StartPosition");
            this.Text = generalSettings.GetString("Text");

            this.Controls.Add(this.bubbleSortButton);
            this.Controls.Add(this.selectionSortButton);
            this.Controls.Add(this.heapSortButton);
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

