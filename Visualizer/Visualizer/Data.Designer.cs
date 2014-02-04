namespace Visualizer
{
    partial class Data
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
            this.label2 = new System.Windows.Forms.Label();
            this.inputField = new System.Windows.Forms.RichTextBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
			
            // 
            // defaultDataRadioButton
            // 
			
            this.defaultDataRadioButton.AutoSize = true;
            this.defaultDataRadioButton.Font = new System.Drawing.Font("Lucida Sans", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.defaultDataRadioButton.ForeColor = System.Drawing.Color.Navy;
            this.defaultDataRadioButton.Location = new System.Drawing.Point(59, 25);
            this.defaultDataRadioButton.Name = "defaultDataRadioButton";
            this.defaultDataRadioButton.Size = new System.Drawing.Size(282, 31);
            this.defaultDataRadioButton.TabIndex = 0;
            this.defaultDataRadioButton.TabStop = true;
            this.defaultDataRadioButton.Text = "Данные по умолчанию";
            this.defaultDataRadioButton.UseVisualStyleBackColor = true;
            this.defaultDataRadioButton.CheckedChanged += new System.EventHandler(this.SelectDefaultData);
            // 
            // enteredDataButton
            // 
            this.enteredDataButton.AutoSize = true;
            this.enteredDataButton.Font = new System.Drawing.Font("Lucida Sans", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enteredDataButton.ForeColor = System.Drawing.Color.Navy;
            this.enteredDataButton.Location = new System.Drawing.Point(59, 74);
            this.enteredDataButton.Name = "enteredDataButton";
            this.enteredDataButton.Size = new System.Drawing.Size(176, 31);
            this.enteredDataButton.TabIndex = 1;
            this.enteredDataButton.TabStop = true;
            this.enteredDataButton.Text = "Свои данные";
            this.enteredDataButton.UseVisualStyleBackColor = true;
            this.enteredDataButton.CheckedChanged += new System.EventHandler(this.SelectEnteredDataButton);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(80, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 17);
            this.label1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(83, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "Массив";
            // 
            // inputField
            // 
            this.inputField.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.inputField.Location = new System.Drawing.Point(88, 170);
            this.inputField.Name = "inputField";
            this.inputField.Size = new System.Drawing.Size(593, 288);
            this.inputField.TabIndex = 4;
            this.inputField.Text = "";
            // 
            // OkButton
            // 
            this.OkButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.OkButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OkButton.FlatAppearance.BorderSize = 0;
            this.OkButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Azure;
            this.OkButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Azure;
            this.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OkButton.Font = new System.Drawing.Font("Lucida Sans", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OkButton.ForeColor = System.Drawing.Color.Navy;
            this.OkButton.Location = new System.Drawing.Point(263, 480);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(199, 60);
            this.OkButton.TabIndex = 5;
            this.OkButton.Text = "Ок";
            this.OkButton.UseVisualStyleBackColor = false;
            this.OkButton.Click += new System.EventHandler(this.RunVisualizer);
            // 
            // Data
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(814, 539);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.inputField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.enteredDataButton);
            this.Controls.Add(this.defaultDataRadioButton);
            this.Name = "Data";
            this.Text = "Data";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton defaultDataRadioButton;
        private System.Windows.Forms.RadioButton enteredDataButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox inputField;
        private System.Windows.Forms.Button OkButton;
    }
}