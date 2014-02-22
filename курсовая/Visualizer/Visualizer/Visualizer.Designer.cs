using System.Drawing;
using System.Windows.Forms;

namespace Visualizer
{
    partial class Visualizer
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button changeDataButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button automaticModeButton;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.Button backwardButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button continueButton;
        protected System.Windows.Forms.RichTextBox commentsBox;

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
            this.changeDataButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.automaticModeButton = new System.Windows.Forms.Button();
            this.forwardButton = new System.Windows.Forms.Button();
            this.backwardButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.continueButton = new System.Windows.Forms.Button();
            this.commentsBox = new System.Windows.Forms.RichTextBox();
       
            this.SuspendLayout();

            //
            // commentsBox
            //

            this.commentsBox.Location = new System.Drawing.Point(13, 300);
            this.commentsBox.Name = "commentsBox";
            this.commentsBox.Size = new System.Drawing.Size(720, 400);
            this.commentsBox.TabIndex = 1;
            this.commentsBox.Text = "";
            this.commentsBox.BackColor = (Color)settings.GetObject("BackColor");
            this.commentsBox.ReadOnly = true;
            this.commentsBox.Font = new System.Drawing.Font("Arial Black", 25.2F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.commentsBox.ForeColor = Color.Navy;
            //this.commentsBox.TextChanged += new System.EventHandler(this.commentsBox_TextChanged);

            // 
            // changeDataButton
            // 

            this.changeDataButton.AutoSizeMode = (System.Windows.Forms.AutoSizeMode) settings.GetObject("ChangeDataButtonAutoSizeMode");
            this.changeDataButton.BackColor = (Color) settings.GetObject("ButtonBackColor");
            this.changeDataButton.Cursor = (Cursor) settings.GetObject("ButtonCursor");
            this.changeDataButton.FlatAppearance.BorderSize = (int) settings.GetObject("ButtonBorderSize");
            this.changeDataButton.FlatAppearance.MouseDownBackColor = (Color) settings.GetObject("ButtonMouseDownBackColor");
            this.changeDataButton.FlatAppearance.MouseOverBackColor = (Color) settings.GetObject("ButtonMouseOverBackColor");
            this.changeDataButton.FlatStyle = (FlatStyle) settings.GetObject("ButtonFlatStyle");
            this.changeDataButton.Font = (Font) settings.GetObject("ButtonFont");
            this.changeDataButton.ForeColor = (Color) settings.GetObject("ButtonForeColor");
            this.changeDataButton.Location = (Point) settings.GetObject("ChangeDataButtonLocation");
            this.changeDataButton.Name = settings.GetString("ChangeDataButtonName");
            this.changeDataButton.Size = (Size) settings.GetObject("ChangeDataButtonSize");
            this.changeDataButton.TabIndex = (int ) settings.GetObject("ChangeDataButtonTabIndex");
            this.changeDataButton.Text = settings.GetString("ChangeDataButtonText");
            this.changeDataButton.UseVisualStyleBackColor = (bool)settings.GetObject("ButtonUseVisualStyleBackColor");

            this.changeDataButton.Click += new System.EventHandler(this.ChangeData);

            // 
            // startButton
            // 

            this.startButton.BackColor = (Color) settings.GetObject("ButtonBackColor");
            this.startButton.Cursor = (Cursor) settings.GetObject("ButtonCursor");
            this.startButton.FlatAppearance.BorderSize = (int) settings.GetObject("ButtonBorderSize");
            this.startButton.FlatAppearance.MouseDownBackColor = (Color) settings.GetObject("ButtonMouseDownBackColor");
            this.startButton.FlatAppearance.MouseOverBackColor = (Color) settings.GetObject("ButtonMouseOverBackColor");
            this.startButton.FlatStyle = (FlatStyle) settings.GetObject("ButtonFlatStyle");
           this.startButton.Font = (Font) settings.GetObject("ButtonFont");
            this.startButton.Location = (Point) settings.GetObject("StartButtonLocation");
            this.startButton.Name = settings.GetString("StartButtonName");
            this.startButton.Size = (Size) settings.GetObject("StartButtonSize");
            this.startButton.TabIndex = (int) settings.GetObject("StartButtonTabIndex");
            this.startButton.Text = settings.GetString("StartButtonText");
            this.startButton.UseVisualStyleBackColor = (bool) settings.GetObject("ButtonUseVisualStyleBackColor");

            this.startButton.Click += new System.EventHandler(this.ToStart);

            // 
            // automaticModeButton
            // 

            this.automaticModeButton.BackColor = (Color) settings.GetObject("ButtonBackColor");
            this.automaticModeButton.Cursor = (Cursor) settings.GetObject("ButtonCursor");
            this.automaticModeButton.FlatAppearance.BorderSize = (int) settings.GetObject("ButtonBorderSize");
            this.automaticModeButton.FlatAppearance.MouseDownBackColor = (Color) settings.GetObject("ButtonMouseDownBackColor");
            this.automaticModeButton.FlatAppearance.MouseOverBackColor = (Color) settings.GetObject("ButtonMouseOverBackColor");
            this.automaticModeButton.Font = (Font) settings.GetObject("ButtonFont");
            this.automaticModeButton.Location = (Point) settings.GetObject("AutomaticModeButtonLocation");
            this.automaticModeButton.Name = settings.GetString("AutomaticModeButtonName");
            this.automaticModeButton.Size = (Size) settings.GetObject("AutomaticModeButtonSize");
            this.automaticModeButton.TabIndex = (int) settings.GetObject("AutomaticModeButtonTabIndex");
            this.automaticModeButton.Text = settings.GetString("AutomaticModeButtonText");
            this.automaticModeButton.UseVisualStyleBackColor = (bool) settings.GetObject("ButtonUseVisualStyleBackColor");

            this.automaticModeButton.Click += new System.EventHandler(this.EnableAutomaticMode);

            // 
            // forwardButton
            // 

            this.forwardButton.BackColor = (Color) settings.GetObject("ButtonBackColor");
            this.forwardButton.Cursor = (Cursor) settings.GetObject("ButtonCursor");
            this.forwardButton.FlatAppearance.BorderSize = (int) settings.GetObject("ButtonBorderSize");
            this.forwardButton.FlatAppearance.MouseDownBackColor = (Color) settings.GetObject("ButtonMouseDownBackColor");
            this.forwardButton.FlatAppearance.MouseOverBackColor = (Color) settings.GetObject("ButtonMouseOverBackColor");
            this.forwardButton.FlatStyle = (FlatStyle) settings.GetObject("ButtonFlatStyle");
            this.forwardButton.Location = (Point) settings.GetObject("ForwardButtonLocation");
            this.forwardButton.Font = (Font) settings.GetObject("ButtonFont");
            this.forwardButton.Name = settings.GetString("ForwardButtonName");
            this.forwardButton.Size = (Size) settings.GetObject("ForwardButtonSize");
            this.forwardButton.TabIndex = (int) settings.GetObject("ForwardButtonTabIndex");
            this.forwardButton.Text = settings.GetString("ForwardButtonText");
            this.forwardButton.UseVisualStyleBackColor = (bool) settings.GetObject("ButtonUseVisualStyleBackColor");

            this.forwardButton.Click += new System.EventHandler(this.DoStepForward);

            // 
            // backwardButton
            // 

            this.backwardButton.BackColor = (Color)settings.GetObject("ButtonBackColor");
            this.backwardButton.Cursor = (Cursor) settings.GetObject("ButtonCursor");
            this.backwardButton.FlatAppearance.BorderSize = (int) settings.GetObject("ButtonBorderSize");
            this.backwardButton.FlatAppearance.MouseDownBackColor = (Color) settings.GetObject("ButtonMouseDownBackColor");
            this.backwardButton.FlatAppearance.MouseOverBackColor = (Color) settings.GetObject("ButtonMouseOverBackColor");
            this.backwardButton.FlatStyle = (FlatStyle) settings.GetObject("ButtonFlatStyle");
            this.backwardButton.Font = (Font) settings.GetObject("ButtonFont");
            this.backwardButton.Location = (Point) settings.GetObject("BackwardButtonLocation");
            this.backwardButton.Name = settings.GetString("BackwardButtonName");
            this.backwardButton.Size = (Size) settings.GetObject("BackwardButtonSize");
            this.backwardButton.TabIndex = (int) settings.GetObject("BackwardButtonTabIndex");
            this.backwardButton.Text = settings.GetString("BackwardButtonText");
            this.backwardButton.UseVisualStyleBackColor = (bool) settings.GetObject("ButtonUseVisualStyleBackColor");

            this.backwardButton.Click += new System.EventHandler(this.DoStepBackward);

            // 
            // pauseButton
            // 

            this.pauseButton.BackColor = (Color) settings.GetObject("ButtonBackColor");
            this.pauseButton.Cursor = (Cursor) settings.GetObject("ButtonCursor");
            this.pauseButton.FlatAppearance.BorderSize = (int) settings.GetObject("ButtonBorderSize");
            this.pauseButton.FlatAppearance.MouseDownBackColor = (Color) settings.GetObject("ButtonMouseDownBackColor");
            this.pauseButton.FlatAppearance.MouseOverBackColor = (Color) settings.GetObject("ButtonMouseOverBackColor");
            this.pauseButton.FlatStyle = (FlatStyle) settings.GetObject("ButtonFlatStyle");
            this.pauseButton.Font = (Font) settings.GetObject("ButtonFont");
            this.pauseButton.Location = (Point) settings.GetObject("PauseButtonLocation");
            this.pauseButton.Name = settings.GetString("PauseButtonName");
            this.pauseButton.Size = (Size) settings.GetObject("PauseButtonSize");
            this.pauseButton.TabIndex = (int) settings.GetObject("PauseButtonTabIndex");
            this.pauseButton.Text = settings.GetString("PauseButtonText");
            this.pauseButton.UseVisualStyleBackColor = (bool) settings.GetObject("ButtonUseVisualStyleBackColor");

            this.pauseButton.Click += new System.EventHandler(this.DoPause);

            // 
            // continueButton
            // 

            this.continueButton.BackColor = (Color) settings.GetObject("ButtonBackColor");
            this.continueButton.Cursor = (Cursor) settings.GetObject("ButtonCursor");
            this.continueButton.FlatAppearance.BorderSize = (int) settings.GetObject("ButtonBorderSize");
            this.continueButton.FlatAppearance.MouseDownBackColor = (Color) settings.GetObject("ButtonMouseDownBackColor");
            this.continueButton.FlatAppearance.MouseOverBackColor = (Color) settings.GetObject("ButtonMouseOverBackColor");
            this.continueButton.FlatStyle = (FlatStyle) settings.GetObject("ButtonFlatStyle");
            this.continueButton.Font = (Font) settings.GetObject("ButtonFont");
            this.continueButton.Location = (Point) settings.GetObject("ContinueButtonLocation");
            this.continueButton.Name = settings.GetString("ContinueButtonName");
            this.continueButton.Size = (Size) settings.GetObject("ContinueButtonSize");
            this.continueButton.TabIndex = (int) settings.GetObject("ContinueButtonTabIndex");
            this.continueButton.Text = settings.GetString("ContinueButtonText");
            this.continueButton.UseVisualStyleBackColor = (bool) settings.GetObject("ButtonUseVisualStyleBackColor");

            this.continueButton.Click += new System.EventHandler(this.Proceed);

            // 
            // BubbleSortVisualizer
            // 

            this.AutoScaleDimensions = (SizeF) settings.GetObject("AutoScaleDimensions");
            this.AutoScaleMode = (System.Windows.Forms.AutoScaleMode) settings.GetObject("AutoScaleMode");
            this.BackColor = (Color) settings.GetObject("BackColor");
            this.ClientSize = (Size) settings.GetObject("ClientSize");
            this.WindowState = FormWindowState.Maximized;
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.backwardButton);
            this.Controls.Add(this.forwardButton);
            this.Controls.Add(this.automaticModeButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.changeDataButton);
            this.Controls.Add(this.commentsBox);
            this.Closed += new System.EventHandler(this.CloseVisualizer);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}