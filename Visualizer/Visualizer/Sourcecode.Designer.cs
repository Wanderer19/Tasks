using System.Windows.Forms;

namespace Visualizer
{
    partial class Sourcecode
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
            this.bubbleSortCode = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // bubbleSortCode
            // 
            this.bubbleSortCode.BackColor = System.Drawing.Color.PaleTurquoise; ;
            this.bubbleSortCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bubbleSortCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.bubbleSortCode.Location = new System.Drawing.Point(12, 12);
            this.bubbleSortCode.Name = "bubbleSortCode";
            this.bubbleSortCode.ReadOnly = true;
            this.bubbleSortCode.Size = new System.Drawing.Size(870, 573);
            this.bubbleSortCode.TabIndex = 1;
            this.bubbleSortCode.Text = System.IO.File.ReadAllText(file);
            this.bubbleSortCode.TextChanged += new System.EventHandler(this.bubbleSortCode_TextChanged);
            // 
            // Sourcecode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(887, 606);
            this.Controls.Add(this.bubbleSortCode);
            this.Name = "Sourcecode";
            this.Text = "Sourcecode";
            this.ResumeLayout(false);

        }

        #endregion

        private RichTextBox bubbleSortCode;
    }
}