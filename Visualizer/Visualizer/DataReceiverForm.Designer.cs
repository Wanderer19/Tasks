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

            this.defaultDataRadioButton.AutoSize = DataReceiverFormSettings.DefaultDataRadioButtonAutoSize;
            this.defaultDataRadioButton.Font = DataReceiverFormSettings.DefaultDataRadioButtonFont;
            this.defaultDataRadioButton.ForeColor = DataReceiverFormSettings.DefaultDataRadioButtonForeColor;
            this.defaultDataRadioButton.Location = DataReceiverFormSettings.DefaultDataRadioButtonLocation;
            this.defaultDataRadioButton.Name = DataReceiverFormSettings.DefaultDataRadioButtonName;
            this.defaultDataRadioButton.Size = DataReceiverFormSettings.DefaultDataRadioButtonSize;
            this.defaultDataRadioButton.TabIndex = DataReceiverFormSettings.DefaultDataRadioButtonTabIndex;
            this.defaultDataRadioButton.TabStop = DataReceiverFormSettings.DefaultDataRadioButtonTabStop;
            this.defaultDataRadioButton.Text = DataReceiverFormSettings.DefaultDataRadioButtonText;
            this.defaultDataRadioButton.UseVisualStyleBackColor = DataReceiverFormSettings.DefaultDataRadioButtonUseVisualStyleBackColor;
            this.defaultDataRadioButton.CheckedChanged += new System.EventHandler(this.SelectDefaultData);

            // 
            // enteredDataButton
            // 

            this.enteredDataButton.AutoSize = DataReceiverFormSettings.EnteredDataButtonAutoSize;
            this.enteredDataButton.Font = DataReceiverFormSettings.EnteredDataButtonFont;
            this.enteredDataButton.ForeColor = DataReceiverFormSettings.EnteredDataButtonForeColor;
            this.enteredDataButton.Location = DataReceiverFormSettings.EnteredDataButtonLocation;
            this.enteredDataButton.Name = DataReceiverFormSettings.EnteredDataButtonName;
            this.enteredDataButton.Size = DataReceiverFormSettings.EnteredDataButtonSize;
            this.enteredDataButton.TabIndex = DataReceiverFormSettings.EnteredDataButtonTabIndex;
            this.enteredDataButton.TabStop = DataReceiverFormSettings.EnteredDataButtonTabStop;
            this.enteredDataButton.Text = DataReceiverFormSettings.EnteredDataButtonText;
            this.enteredDataButton.UseVisualStyleBackColor = DataReceiverFormSettings.EnteredDataButtonUseVisualStyleBackColor;
            this.enteredDataButton.CheckedChanged += new System.EventHandler(this.SelectEnteredDataButton);

            //
            // signatureInputField
            // 

            this.signatureInputField.AutoSize = DataReceiverFormSettings.SignatureInputFieldAutoSize;
            this.signatureInputField.Font = DataReceiverFormSettings.SignatureInputFieldFont;
            this.signatureInputField.ForeColor = DataReceiverFormSettings.SignatureInputFieldForeColor;
            this.signatureInputField.Location = DataReceiverFormSettings.SignatureInputFieldLocation;
            this.signatureInputField.Name = DataReceiverFormSettings.SignatureInputFieldName;
            this.signatureInputField.Size = DataReceiverFormSettings.SignatureInputFieldSize;
            this.signatureInputField.TabIndex = DataReceiverFormSettings.SignatureInputFieldTabIndex;
            this.signatureInputField.Text = DataReceiverFormSettings.SignatureInputFieldText;

            // 
            // inputField
            // 

            this.inputField.BackColor = DataReceiverFormSettings.InputFieldBackColor;
            this.inputField.Location = DataReceiverFormSettings.InputFieldLocation;
            this.inputField.Name = DataReceiverFormSettings.InputFieldName;
            this.inputField.Size = DataReceiverFormSettings.InputFieldSize;
            this.inputField.TabIndex = DataReceiverFormSettings.InputFieldTabIndex;
            this.inputField.Text = DataReceiverFormSettings.InputFieldText;

            // 
            // OkButton
            // 

            this.OkButton.BackColor = DataReceiverFormSettings.OkButtonBackColor;
            this.OkButton.Cursor = DataReceiverFormSettings.OkButtonCursor;
            this.OkButton.FlatAppearance.BorderSize = DataReceiverFormSettings.OkButtonBorderSize;
            this.OkButton.FlatAppearance.MouseDownBackColor = DataReceiverFormSettings.OkButtonMouseDownBackColor;
            this.OkButton.FlatAppearance.MouseOverBackColor = DataReceiverFormSettings.OkButtonMouseOverBackColor;
            this.OkButton.FlatStyle = DataReceiverFormSettings.OkButtonFlatStyle;
            this.OkButton.Font = DataReceiverFormSettings.OkButtonFont;
            this.OkButton.ForeColor = DataReceiverFormSettings.OkButtonForeColor;
            this.OkButton.Location = DataReceiverFormSettings.OkButtonLocation;
            this.OkButton.Name = DataReceiverFormSettings.OkButtonName;
            this.OkButton.Size = DataReceiverFormSettings.OkButtonSize;
            this.OkButton.TabIndex = DataReceiverFormSettings.OkButtonTabIndex;
            this.OkButton.Text = DataReceiverFormSettings.OkButtonText;
            this.OkButton.UseVisualStyleBackColor = DataReceiverFormSettings.OkButtonUseVisualStyleBackColor;
            this.OkButton.Click += new System.EventHandler(this.HandleReceiverData);

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
    }
}