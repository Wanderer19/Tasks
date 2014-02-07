using System;
using System.Drawing;
using System.Windows.Forms;

namespace Visualizer
{
    partial class DataReceiverForm
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
            this.defaultDataRadioButton = new System.Windows.Forms.RadioButton();
            this.enteredDataButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.signatureInputField = new System.Windows.Forms.Label();
            this.inputField = new System.Windows.Forms.RichTextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // 
            // defaultDataRadioButton
            // 

            this.defaultDataRadioButton.AutoSize = (bool) settings.GetObject("DefaultDataRadioButtonAutoSize");
            this.defaultDataRadioButton.Font = (Font) settings.GetObject("DefaultDataRadioButtonFont");
            this.defaultDataRadioButton.ForeColor = (Color) settings.GetObject("DefaultDataRadioButtonForeColor");
            this.defaultDataRadioButton.Location = (Point) settings.GetObject("DefaultDataRadioButtonLocation");
            this.defaultDataRadioButton.Name = settings.GetString("DefaultDataRadioButtonName");
            this.defaultDataRadioButton.Size = (Size) settings.GetObject("DefaultDataRadioButtonSize");
            this.defaultDataRadioButton.TabIndex = (int) settings.GetObject("DefaultDataRadioButtonTabIndex");
            this.defaultDataRadioButton.TabStop = (bool) settings.GetObject("DefaultDataRadioButtonTabStop");
            this.defaultDataRadioButton.Text = settings.GetString("DefaultDataRadioButtonText");
            this.defaultDataRadioButton.UseVisualStyleBackColor = (bool)settings.GetObject("DefaultDataRadioButtonUseVisualStyleBackColor");
            this.defaultDataRadioButton.CheckedChanged += new System.EventHandler(this.SelectDefaultData);

            // 
            // enteredDataButton
            // 

            this.enteredDataButton.AutoSize = (bool) settings.GetObject("EnteredDataButtonAutoSize");
            this.enteredDataButton.Font =(Font) settings.GetObject("EnteredDataButtonFont");
            this.enteredDataButton.ForeColor = (Color) settings.GetObject("EnteredDataButtonForeColor");
            this.enteredDataButton.Location = (Point) settings.GetObject("EnteredDataButtonLocation");
            this.enteredDataButton.Name = settings.GetString("EnteredDataButtonName");
            this.enteredDataButton.Size = (Size) settings.GetObject("EnteredDataButtonSize");
            this.enteredDataButton.TabIndex = (int) settings.GetObject("EnteredDataButtonTabIndex");
            this.enteredDataButton.TabStop = (bool) settings.GetObject("EnteredDataButtonTabStop");
            this.enteredDataButton.Text = settings.GetString("EnteredDataButtonText");
            this.enteredDataButton.UseVisualStyleBackColor = (bool) settings.GetObject("EnteredDataButtonUseVisualStyleBackColor");
            this.enteredDataButton.CheckedChanged += new System.EventHandler(this.SelectEnteredDataButton);

            //
            // signatureInputField
            // 

            this.signatureInputField.AutoSize = (bool) settings.GetObject("SignatureInputFieldAutoSize");
            this.signatureInputField.Font = (Font) settings.GetObject("SignatureInputFieldFont");
            this.signatureInputField.ForeColor = (Color) settings.GetObject("SignatureInputFieldForeColor");
            this.signatureInputField.Location = (Point) settings.GetObject("SignatureInputFieldLocation");
            this.signatureInputField.Name = settings.GetString("SignatureInputFieldName");
            this.signatureInputField.Size = (Size) settings.GetObject("SignatureInputFieldSize");
            this.signatureInputField.TabIndex = (int)settings.GetObject("SignatureInputFieldTabIndex");
            this.signatureInputField.Text = settings.GetString("SignatureInputFieldText");

            // 
            // inputField
            // 

            this.inputField.BackColor = (Color) settings.GetObject("InputFieldBackColor");
            this.inputField.Location = (Point) settings.GetObject("InputFieldLocation");
            this.inputField.Name = settings.GetString("InputFieldName");
            this.inputField.Size = (Size) settings.GetObject("InputFieldSize");
            this.inputField.TabIndex = (int) settings.GetObject("InputFieldTabIndex");
            this.inputField.Text = settings.GetString("InputFieldText");

            // 
            // OkButton
            // 

            this.OkButton.BackColor = (Color) settings.GetObject("OkButtonBackColor");
            this.OkButton.Cursor = (Cursor) settings.GetObject("OkButtonCursor");
            this.OkButton.FlatAppearance.BorderSize = (int) settings.GetObject("OkButtonBorderSize");
            this.OkButton.FlatAppearance.MouseDownBackColor = (Color) settings.GetObject("OkButtonMouseDownBackColor");
            this.OkButton.FlatAppearance.MouseOverBackColor = (Color) settings.GetObject("OkButtonMouseOverBackColor");
            this.OkButton.FlatStyle = (FlatStyle) settings.GetObject("OkButtonFlatStyle");
            this.OkButton.Font = (Font) settings.GetObject("OkButtonFont");
            this.OkButton.ForeColor = (Color) settings.GetObject("OkButtonForeColor");
            this.OkButton.Location = (Point) settings.GetObject("OkButtonLocation");
            this.OkButton.Name = settings.GetString("OkButtonName");
            this.OkButton.Size = (Size) settings.GetObject("OkButtonSize");
            this.OkButton.TabIndex = (int) settings.GetObject("OkButtonTabIndex");
            this.OkButton.Text = settings.GetString("OkButtonText");
            this.OkButton.UseVisualStyleBackColor = (bool) settings.GetObject("OkButtonUseVisualStyleBackColor");
            this.OkButton.Click += new System.EventHandler(this.RunVisualizer);

            // 
            // DataReceiverForm
            // 

            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(814, 539);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.inputField);
            this.Controls.Add(this.signatureInputField);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.enteredDataButton);
            this.Controls.Add(this.defaultDataRadioButton);
            this.Closed += new EventHandler(CloseDataReceiverForm);
            this.Name = "DataReceiverForm";
            this.Text = "DataReceiverForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton defaultDataRadioButton;
        private System.Windows.Forms.RadioButton enteredDataButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label signatureInputField;
        private System.Windows.Forms.RichTextBox inputField;
        private System.Windows.Forms.Button OkButton;

        private bool VisualizerCanBeRun()
        {
            var isValidData = true;
            var array = new int[] {0, -9, 7, 1, 5};
                
            if (!choice)
            {
                if (ArrayReader.IsValidInputString(inputField.Text))
                {
                    array = ArrayReader.ReadData(inputField.Text);
                    isValidData = true;
                }
                else
                    isValidData = false;
            }

            inputArray = array;

            return isValidData && ArrayReader.IsValidValuesElementsInArray(array, (int)settings.GetObject("SizeLimitArray"), (int)settings.GetObject("LimitArrayElementValue"));
        }
    }
}