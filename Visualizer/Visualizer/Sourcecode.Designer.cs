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

            this.textField.BackColor = SourceCodeSettings.TextFieldBackColor;
            this.textField.BorderStyle = SourceCodeSettings.TextFieldBorderStyle;
            this.textField.Font = SourceCodeSettings.TextFieldFont;
            this.textField.Location = SourceCodeSettings.TextFieldLocation;
            this.textField.Name = SourceCodeSettings.TextFieldName;
            this.textField.ReadOnly = SourceCodeSettings.TextFieldReadOnly;
            this.textField.Size = SourceCodeSettings.TextFieldSize;
            this.textField.TabIndex = SourceCodeSettings.TextFieldTabIndex;
            this.textField.Text = System.IO.File.ReadAllText(file);
			
            // 
            // Sourcecode
            // 

            this.AutoScaleDimensions = SourceCodeSettings.AutoScaleDimensions;
            this.AutoScaleMode = SourceCodeSettings.AutoScaleMode;
            this.BackColor = SourceCodeSettings.BackColor;
            this.ClientSize = SourceCodeSettings.ClientSize;
            this.Name = SourceCodeSettings.Name;
            this.Text = SourceCodeSettings.Text;

            this.Controls.Add(this.textField);
            this.ResumeLayout(false);

        }

        #endregion

        private RichTextBox textField;
    }
}