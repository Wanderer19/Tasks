namespace Visualizer
{
    partial class BubbleSortVisualizer
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.help = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonChangeData = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.finishButton = new System.Windows.Forms.Button();
            this.automaticModeButton = new System.Windows.Forms.Button();
            this.forwardButton = new System.Windows.Forms.Button();
            this.backwardButton = new System.Windows.Forms.Button();
            this.pauseButton = new System.Windows.Forms.Button();
            this.continueButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightCyan;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpMessage});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(949, 36);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpMessage
            // 
            this.helpMessage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.help});
            this.helpMessage.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.helpMessage.Name = "helpMessage";
            this.helpMessage.Size = new System.Drawing.Size(102, 32);
            this.helpMessage.Text = "Справка";
            // 
            // help
            // 
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(166, 32);
            this.help.Text = "Помощь";
            this.help.Click += new System.EventHandler(this.ShowHelpMessage);
            // 
            // buttonChangeData
            // 
            this.buttonChangeData.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonChangeData.BackColor = System.Drawing.Color.MediumTurquoise;
            this.buttonChangeData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonChangeData.FlatAppearance.BorderSize = 0;
            this.buttonChangeData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonChangeData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonChangeData.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonChangeData.Font = new System.Drawing.Font("Lucida Sans", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonChangeData.ForeColor = System.Drawing.Color.Black;
            this.buttonChangeData.Location = new System.Drawing.Point(72, 485);
            this.buttonChangeData.Name = "buttonChangeData";
            this.buttonChangeData.Size = new System.Drawing.Size(802, 38);
            this.buttonChangeData.TabIndex = 1;
            this.buttonChangeData.Text = "Поменять данные";
            this.buttonChangeData.UseVisualStyleBackColor = false;
            this.buttonChangeData.Click += new System.EventHandler(this.buttonChangeData_Click);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.MediumTurquoise;
            this.startButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startButton.FlatAppearance.BorderSize = 0;
            this.startButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.startButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.startButton.Font = new System.Drawing.Font("Lucida Sans", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(72, 445);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(249, 43);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "В начало";
            this.startButton.UseVisualStyleBackColor = false;
            // 
            // finishButton
            // 
            this.finishButton.BackColor = System.Drawing.Color.MediumTurquoise;
            this.finishButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.finishButton.FlatAppearance.BorderSize = 0;
            this.finishButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.finishButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.finishButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.finishButton.Font = new System.Drawing.Font("Lucida Sans", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finishButton.Location = new System.Drawing.Point(317, 445);
            this.finishButton.Name = "finishButton";
            this.finishButton.Size = new System.Drawing.Size(273, 43);
            this.finishButton.TabIndex = 3;
            this.finishButton.Text = "В конец";
            this.finishButton.UseVisualStyleBackColor = false;
            // 
            // automaticModeButton
            // 
            this.automaticModeButton.BackColor = System.Drawing.Color.MediumTurquoise;
            this.automaticModeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.automaticModeButton.FlatAppearance.BorderSize = 0;
            this.automaticModeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.automaticModeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.automaticModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.automaticModeButton.Font = new System.Drawing.Font("Lucida Sans", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.automaticModeButton.Location = new System.Drawing.Point(588, 445);
            this.automaticModeButton.Name = "automaticModeButton";
            this.automaticModeButton.Size = new System.Drawing.Size(286, 43);
            this.automaticModeButton.TabIndex = 4;
            this.automaticModeButton.Text = "Автоматический режим";
            this.automaticModeButton.UseVisualStyleBackColor = false;
            // 
            // forwardButton
            // 
            this.forwardButton.BackColor = System.Drawing.Color.MediumTurquoise;
            this.forwardButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.forwardButton.FlatAppearance.BorderSize = 0;
            this.forwardButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.forwardButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.forwardButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.forwardButton.Font = new System.Drawing.Font("Lucida Sans", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.forwardButton.Location = new System.Drawing.Point(72, 415);
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(249, 33);
            this.forwardButton.TabIndex = 5;
            this.forwardButton.Text = ">>>Вперед";
            this.forwardButton.UseVisualStyleBackColor = false;
            // 
            // backwardButton
            // 
            this.backwardButton.BackColor = System.Drawing.Color.MediumTurquoise;
            this.backwardButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backwardButton.FlatAppearance.BorderSize = 0;
            this.backwardButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.backwardButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.backwardButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.backwardButton.Font = new System.Drawing.Font("Lucida Sans", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backwardButton.Location = new System.Drawing.Point(317, 415);
            this.backwardButton.Name = "backwardButton";
            this.backwardButton.Size = new System.Drawing.Size(273, 33);
            this.backwardButton.TabIndex = 6;
            this.backwardButton.Text = "<<<Назад";
            this.backwardButton.UseVisualStyleBackColor = false;
            // 
            // pauseButton
            // 
            this.pauseButton.BackColor = System.Drawing.Color.MediumTurquoise;
            this.pauseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pauseButton.FlatAppearance.BorderSize = 0;
            this.pauseButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pauseButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.pauseButton.Font = new System.Drawing.Font("Lucida Sans", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pauseButton.Location = new System.Drawing.Point(588, 415);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(127, 33);
            this.pauseButton.TabIndex = 7;
            this.pauseButton.Text = "Пауза";
            this.pauseButton.UseVisualStyleBackColor = false;
            // 
            // continueButton
            // 
            this.continueButton.BackColor = System.Drawing.Color.MediumTurquoise;
            this.continueButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.continueButton.FlatAppearance.BorderSize = 0;
            this.continueButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.continueButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.continueButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.continueButton.Font = new System.Drawing.Font("Lucida Sans", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.continueButton.Location = new System.Drawing.Point(710, 415);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(164, 33);
            this.continueButton.TabIndex = 8;
            this.continueButton.Text = "Продолжить";
            this.continueButton.UseVisualStyleBackColor = false;
            // 
            // BubbleSortVisualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(949, 518);
            this.Controls.Add(this.continueButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.backwardButton);
            this.Controls.Add(this.forwardButton);
            this.Controls.Add(this.automaticModeButton);
            this.Controls.Add(this.finishButton);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.buttonChangeData);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "BubbleSortVisualizer";
            this.Text = "BubbleSortVisualizer";
            this.Load += new System.EventHandler(this.BubbleSortVisualizer_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpMessage;
        private System.Windows.Forms.Button buttonChangeData;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button finishButton;
        private System.Windows.Forms.Button automaticModeButton;
        private System.Windows.Forms.Button forwardButton;
        private System.Windows.Forms.Button backwardButton;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button continueButton;
        private System.Windows.Forms.ToolStripMenuItem help;
    }
}