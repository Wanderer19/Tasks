namespace Visualizer
{
    partial class Visualizer
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem helpMenu;
        private System.Windows.Forms.Button changeDataButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button automaticModeButton;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.Button backwardButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.ToolStripMenuItem helpMenuItem;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        public void InitializeComponent()
        {
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.helpMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeDataButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.automaticModeButton = new System.Windows.Forms.Button();
            this.forwardButton = new System.Windows.Forms.Button();
            this.backwardButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.continueButton = new System.Windows.Forms.Button();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // mainMenu
            //

            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.helpMenu });
            
            this.mainMenu.BackColor = VisualizerSettings.BackColor;
            this.mainMenu.Location = VisualizerSettings.MainMenuLocation;
            this.mainMenu.Name = VisualizerSettings.MainMenuName;
            this.mainMenu.Size = VisualizerSettings.MainMenuSize;
            this.mainMenu.TabIndex = VisualizerSettings.MainMenuTabIndex;
            this.mainMenu.Text = VisualizerSettings.MainMenuText;
            
            // 
            // helpMenu
            // 

            this.helpMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.helpMenuItem });
            this.helpMenu.Font = VisualizerSettings.HelpMenuFont;
            this.helpMenu.Name = VisualizerSettings.HelpMenuName;
            this.helpMenu.Size = VisualizerSettings.HelpMenuSize;
            this.helpMenu.Text = VisualizerSettings.HelpMenuText;

            // 
            // helpMenuItem
            // 

            this.helpMenuItem.Name = VisualizerSettings.HelpMenuItemName;
            this.helpMenuItem.Size = VisualizerSettings.HelpMenuItemSize;
            this.helpMenuItem.Text = VisualizerSettings.HelpMenuItemText;

            this.helpMenuItem.Click += new System.EventHandler(this.ShowHelpMessage);

            // 
            // changeDataButton
            // 

            this.changeDataButton.AutoSizeMode = VisualizerSettings.ChangeDataButtonAutoSizeMode;
            this.changeDataButton.BackColor = VisualizerSettings.ButtonBackColor;
            this.changeDataButton.Cursor = VisualizerSettings.ButtonCursor;
            this.changeDataButton.FlatAppearance.BorderSize = VisualizerSettings.ButtonBorderSize;
            this.changeDataButton.FlatAppearance.MouseDownBackColor = VisualizerSettings.ButtonMouseDownBackColor;
            this.changeDataButton.FlatAppearance.MouseOverBackColor = VisualizerSettings.ButtonMouseOverBackColor;
            this.changeDataButton.FlatStyle = VisualizerSettings.ButtonFlatStyle;
            this.changeDataButton.Font = VisualizerSettings.ButtonFont;
            this.changeDataButton.ForeColor = VisualizerSettings.ButtonForeColor;
            this.changeDataButton.Location = VisualizerSettings.ChangeDataButtonLocation;
            this.changeDataButton.Name = VisualizerSettings.ChangeDataButtonName;
            this.changeDataButton.Size = VisualizerSettings.ChangeDataButtonSize;
            this.changeDataButton.TabIndex = VisualizerSettings.ChangeDataButtonTabIndex;
            this.changeDataButton.Text = VisualizerSettings.ChangeDataButtonText;
            this.changeDataButton.UseVisualStyleBackColor = VisualizerSettings.ButtonUseVisualStyleBackColor;

            this.changeDataButton.Click += new System.EventHandler(this.ChangeData);

            // 
            // startButton
            // 

            this.startButton.BackColor = VisualizerSettings.ButtonBackColor;
            this.startButton.Cursor = VisualizerSettings.ButtonCursor;
            this.startButton.FlatAppearance.BorderSize = VisualizerSettings.ButtonBorderSize;
            this.startButton.FlatAppearance.MouseDownBackColor = VisualizerSettings.ButtonMouseDownBackColor;
            this.startButton.FlatAppearance.MouseOverBackColor = VisualizerSettings.ButtonMouseOverBackColor;
            this.startButton.FlatStyle = VisualizerSettings.ButtonFlatStyle;
            this.startButton.Font = VisualizerSettings.ButtonFont;
            this.startButton.Location = VisualizerSettings.StartButtonLocation;
            this.startButton.Name = VisualizerSettings.StartButtonName;
            this.startButton.Size = VisualizerSettings.StartButtonSize;
            this.startButton.TabIndex = VisualizerSettings.StartButtonTabIndex;
            this.startButton.Text = VisualizerSettings.StartButtonText;
            this.startButton.UseVisualStyleBackColor = VisualizerSettings.ButtonUseVisualStyleBackColor;

            this.startButton.Click += new System.EventHandler(this.ToStart);

            // 
            // automaticModeButton
            // 

            this.automaticModeButton.BackColor = VisualizerSettings.ButtonBackColor;
            this.automaticModeButton.Cursor = VisualizerSettings.ButtonCursor;
            this.automaticModeButton.FlatAppearance.BorderSize = VisualizerSettings.ButtonBorderSize;
            this.automaticModeButton.FlatAppearance.MouseDownBackColor = VisualizerSettings.ButtonMouseDownBackColor;
            this.automaticModeButton.FlatAppearance.MouseOverBackColor = VisualizerSettings.ButtonMouseOverBackColor;
            this.automaticModeButton.Font = VisualizerSettings.ButtonFont;
            this.automaticModeButton.Location = VisualizerSettings.AutomaticModeButtonLocation;
            this.automaticModeButton.Name = VisualizerSettings.AutomaticModeButtonName;
            this.automaticModeButton.Size = VisualizerSettings.AutomaticModeButtonSize;
            this.automaticModeButton.TabIndex = VisualizerSettings.AutomaticModeButtonTabIndex;
            this.automaticModeButton.Text = VisualizerSettings.AutomaticModeButtonText;
            this.automaticModeButton.UseVisualStyleBackColor = VisualizerSettings.ButtonUseVisualStyleBackColor;

            this.automaticModeButton.Click += new System.EventHandler(this.EnableAutomaticMode);

            // 
            // forwardButton
            // 

            this.forwardButton.BackColor = VisualizerSettings.ButtonBackColor;
            this.forwardButton.Cursor = VisualizerSettings.ButtonCursor;
            this.forwardButton.FlatAppearance.BorderSize = VisualizerSettings.ButtonBorderSize;
            this.forwardButton.FlatAppearance.MouseDownBackColor = VisualizerSettings.ButtonMouseDownBackColor;
            this.forwardButton.FlatAppearance.MouseOverBackColor = VisualizerSettings.ButtonMouseOverBackColor;
            this.forwardButton.FlatStyle = VisualizerSettings.ButtonFlatStyle;
            this.forwardButton.Font = VisualizerSettings.ButtonFont;
            this.forwardButton.Location = VisualizerSettings.ForwardButtonLocation;
            this.forwardButton.Name = VisualizerSettings.ForwardButtonName;
            this.forwardButton.Size = VisualizerSettings.ForwardButtonSize;
            this.forwardButton.TabIndex = VisualizerSettings.ForwardButtonTabIndex;
            this.forwardButton.Text = VisualizerSettings.ForwardButtonText;
            this.forwardButton.UseVisualStyleBackColor = VisualizerSettings.ButtonUseVisualStyleBackColor;

            this.forwardButton.Click += new System.EventHandler(this.DoStepForward);

            // 
            // backwardButton
            // 

            this.backwardButton.BackColor = VisualizerSettings.ButtonBackColor;
            this.backwardButton.Cursor = VisualizerSettings.ButtonCursor;
            this.backwardButton.FlatAppearance.BorderSize = VisualizerSettings.ButtonBorderSize;
            this.backwardButton.FlatAppearance.MouseDownBackColor = VisualizerSettings.ButtonMouseDownBackColor;
            this.backwardButton.FlatAppearance.MouseOverBackColor = VisualizerSettings.ButtonMouseOverBackColor;
            this.backwardButton.FlatStyle = VisualizerSettings.ButtonFlatStyle;
            this.backwardButton.Font = VisualizerSettings.ButtonFont;
            this.backwardButton.Location = VisualizerSettings.BackwardButtonLocation;
            this.backwardButton.Name = VisualizerSettings.BackwardButtonName;
            this.backwardButton.Size = VisualizerSettings.BackwardButtonSize;
            this.backwardButton.TabIndex = VisualizerSettings.BackwardButtonTabIndex;
            this.backwardButton.Text = VisualizerSettings.BackwardButtonText;
            this.backwardButton.UseVisualStyleBackColor = VisualizerSettings.ButtonUseVisualStyleBackColor;

            this.backwardButton.Click += new System.EventHandler(this.DoStepBackward);

            // 
            // pauseButton
            // 

            this.pauseButton.BackColor = VisualizerSettings.ButtonBackColor;
            this.pauseButton.Cursor = VisualizerSettings.ButtonCursor;
            this.pauseButton.FlatAppearance.BorderSize = VisualizerSettings.ButtonBorderSize;
            this.pauseButton.FlatAppearance.MouseDownBackColor = VisualizerSettings.ButtonMouseDownBackColor;
            this.pauseButton.FlatAppearance.MouseOverBackColor = VisualizerSettings.ButtonMouseOverBackColor;
            this.pauseButton.FlatStyle = VisualizerSettings.ButtonFlatStyle;
            this.pauseButton.Font = VisualizerSettings.ButtonFont;
            this.pauseButton.Location = VisualizerSettings.PauseButtonLocation;
            this.pauseButton.Name = VisualizerSettings.PauseButtonName;
            this.pauseButton.Size = VisualizerSettings.PauseButtonSize;
            this.pauseButton.TabIndex = VisualizerSettings.PauseButtonTabIndex;
            this.pauseButton.Text = VisualizerSettings.PauseButtonText;
            this.pauseButton.UseVisualStyleBackColor = VisualizerSettings.ButtonUseVisualStyleBackColor;

            this.pauseButton.Click += new System.EventHandler(this.DoPause);

            // 
            // continueButton
            // 

            this.continueButton.BackColor = VisualizerSettings.ButtonBackColor;
            this.continueButton.Cursor = VisualizerSettings.ButtonCursor;
            this.continueButton.FlatAppearance.BorderSize = VisualizerSettings.ButtonBorderSize;
            this.continueButton.FlatAppearance.MouseDownBackColor = VisualizerSettings.ButtonMouseDownBackColor;
            this.continueButton.FlatAppearance.MouseOverBackColor = VisualizerSettings.ButtonMouseOverBackColor;
            this.continueButton.FlatStyle = VisualizerSettings.ButtonFlatStyle;
            this.continueButton.Font = VisualizerSettings.ButtonFont;
            this.continueButton.Location = VisualizerSettings.ContinueButtonLocation;
            this.continueButton.Name = VisualizerSettings.ContinueButtonName;
            this.continueButton.Size = VisualizerSettings.ContinueButtonSize;
            this.continueButton.TabIndex = VisualizerSettings.ContinueButtonTabIndex;
            this.continueButton.Text = VisualizerSettings.ContinueButtonText;
            this.continueButton.UseVisualStyleBackColor = VisualizerSettings.ButtonUseVisualStyleBackColor;

            this.continueButton.Click += new System.EventHandler(this.Proceed);

            // 
            // BubbleSortVisualizer
            // 

            this.AutoScaleDimensions = VisualizerSettings.AutoScaleDimensions;
            this.AutoScaleMode = VisualizerSettings.AutoScaleMode;
            this.BackColor = VisualizerSettings.BackColor;
            this.ClientSize = VisualizerSettings.ClientSize;
            this.Name = VisualizerSettings.Name;
            this.Text = VisualizerSettings.Text;

            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.backwardButton);
            this.Controls.Add(this.forwardButton);
            this.Controls.Add(this.automaticModeButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.changeDataButton);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Closed += new System.EventHandler(this.CloseVisualizer);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        }
}