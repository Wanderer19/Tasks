using System;
using System.Security.AccessControl;
using System.Windows.Forms;

namespace Visualizer
{
    partial class Form1
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
            this.mainText = new System.Windows.Forms.Label();
            this.bubbleSortButton = new System.Windows.Forms.Button();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.helpProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.help = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainText
            // 
            this.mainText.AutoSize = true;
            this.mainText.BackColor = System.Drawing.Color.LightSkyBlue;
            this.mainText.Font = new System.Drawing.Font("Monotype Corsiva", 48F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainText.ForeColor = System.Drawing.Color.Blue;
            this.mainText.Location = new System.Drawing.Point(48, 82);
            this.mainText.Margin = new System.Windows.Forms.Padding(17, 0, 17, 0);
            this.mainText.Name = "mainText";
            this.mainText.Size = new System.Drawing.Size(783, 97);
            this.mainText.TabIndex = 0;
            this.mainText.Text = "Алгоритмы Сортировок";
            this.mainText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mainText.Click += new System.EventHandler(this.mainText_Click);
            // 
            // bubbleSortButton
            // 
            this.bubbleSortButton.BackColor = System.Drawing.Color.LightSkyBlue;
            this.bubbleSortButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bubbleSortButton.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.bubbleSortButton.FlatAppearance.BorderSize = 0;
            this.bubbleSortButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Highlight;
            this.bubbleSortButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.bubbleSortButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bubbleSortButton.Font = new System.Drawing.Font("Mistral", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bubbleSortButton.ForeColor = System.Drawing.Color.DarkBlue;
            this.bubbleSortButton.Location = new System.Drawing.Point(105, 228);
            this.bubbleSortButton.Name = "bubbleSortButton";
            this.bubbleSortButton.Size = new System.Drawing.Size(654, 125);
            this.bubbleSortButton.TabIndex = 1;
            this.bubbleSortButton.Text = "Пузырьковая сортировка";
            this.bubbleSortButton.UseVisualStyleBackColor = false;
            this.bubbleSortButton.Click += new System.EventHandler(this.BubbleSortRun);
            // 
            // mainMenu
            // 
            this.mainMenu.BackColor = System.Drawing.Color.LightSkyBlue;
            this.mainMenu.Font = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpProgram});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(857, 37);
            this.mainMenu.TabIndex = 2;
            this.mainMenu.Text = "menuStrip1";
            // 
            // helpProgram
            // 
            this.helpProgram.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutProgram,
            this.help});
            this.helpProgram.Font = new System.Drawing.Font("Stencil", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.helpProgram.ForeColor = System.Drawing.Color.DarkBlue;
            this.helpProgram.Name = "helpProgram";
            this.helpProgram.Size = new System.Drawing.Size(129, 33);
            this.helpProgram.Text = "Справка";
            // 
            // aboutProgram
            // 
            this.aboutProgram.Name = "aboutProgram";
            this.aboutProgram.Size = new System.Drawing.Size(253, 34);
            this.aboutProgram.Text = "О программе";
            this.aboutProgram.Click += new System.EventHandler(this.ShowAboutProgram);
            // 
            // ShowHelp
            // 
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(253, 34);
            this.help.Text = "Справка";
            this.help.Click += new System.EventHandler(this.ShowHelp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(48F, 143F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(857, 897);
            this.Controls.Add(this.bubbleSortButton);
            this.Controls.Add(this.mainText);
            this.Controls.Add(this.mainMenu);
            this.Font = new System.Drawing.Font("Mistral", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.mainMenu;
            this.Margin = new System.Windows.Forms.Padding(17, 25, 17, 25);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Визуализатор алгоритмов сортировок";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mainText;
        public System.Windows.Forms.Button bubbleSortButton;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem helpProgram;
        private System.Windows.Forms.ToolStripMenuItem aboutProgram;
        private System.Windows.Forms.ToolStripMenuItem help;


      
    }
}

