using System.Drawing;
using System.Windows.Forms;

namespace Visualizer
{
    partial class Sourcecode
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.textField = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
			
            // 
            // textField
            // 

            this.textField.BackColor = (Color)settings.GetObject("TextFieldBackColor");
            this.textField.BorderStyle = (BorderStyle) settings.GetObject("TextFieldBorderStyle");
            this.textField.Font = (Font)settings.GetObject("TextFieldFont");
            this.textField.Location = (Point) settings.GetObject("TextFieldLocation");
            this.textField.Name = settings.GetString("TextFieldName");
            this.textField.ReadOnly = (bool) settings.GetObject("TextFieldReadOnly");
            this.textField.Size = (Size) settings.GetObject("TextFieldSize");
            this.textField.TabIndex = (int )settings.GetObject("TextFieldTabIndex");
            this.textField.Text = sourceCode;
			
            // 
            // Sourcecode
            // 

            this.AutoScaleDimensions = (SizeF) settings.GetObject("AutoScaleDimensions");
            this.AutoScaleMode = (System.Windows.Forms.AutoScaleMode) settings.GetObject("AutoScaleMode");
            this.BackColor = (Color) settings.GetObject("BackColor");
            this.ClientSize = (Size) settings.GetObject("ClientSize");
            this.Name = settings.GetString("Name");
            this.Text = settings.GetString("Text");

            this.Controls.Add(this.textField);
            this.ResumeLayout(false);

        }

        #endregion

        private RichTextBox textField;
    }
}