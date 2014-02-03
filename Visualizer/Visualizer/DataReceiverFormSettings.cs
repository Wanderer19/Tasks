using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Visualizer
{
    class DataReceiverFormSettings
    {
        public static readonly bool DefaultDataRadioButtonAutoSize = true;
        public static readonly Font DefaultDataRadioButtonFont = new System.Drawing.Font("Lucida Sans", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        public static readonly Color DefaultDataRadioButtonForeColor = System.Drawing.Color.Navy;
        public static readonly Point DefaultDataRadioButtonLocation = new System.Drawing.Point(59, 25);
        public static readonly string DefaultDataRadioButtonName = "defaultDataRadioButton";
        public static readonly Size DefaultDataRadioButtonSize = new System.Drawing.Size(282, 31);
        public static readonly int DefaultDataRadioButtonTabIndex = 0;
        public static readonly bool DefaultDataRadioButtonTabStop = true;
        public static readonly string DefaultDataRadioButtonText = "Данные по умолчанию";
        public static readonly bool DefaultDataRadioButtonUseVisualStyleBackColor = true;

        public static readonly bool EnteredDataButtonAutoSize = true;
        public static readonly Font EnteredDataButtonFont = new System.Drawing.Font("Lucida Sans", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        public static readonly Color EnteredDataButtonForeColor = System.Drawing.Color.Navy;
        public static readonly Point EnteredDataButtonLocation = new System.Drawing.Point(59, 74);
        public static readonly string EnteredDataButtonName = "enteredDataButton";
        public static readonly Size EnteredDataButtonSize = new System.Drawing.Size(176, 31);
        public static readonly int EnteredDataButtonTabIndex = 1;
        public static readonly bool EnteredDataButtonTabStop = true;
        public static readonly string EnteredDataButtonText = "Свои данные";
        public static readonly bool EnteredDataButtonUseVisualStyleBackColor = true;

        public static readonly bool SignatureInputFieldAutoSize = true;
        public static readonly Font SignatureInputFieldFont = new System.Drawing.Font("Lucida Sans", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        public static readonly Color SignatureInputFieldForeColor = System.Drawing.Color.Navy;
        public static readonly Point SignatureInputFieldLocation = new System.Drawing.Point(83, 121);
        public static readonly string SignatureInputFieldName = "signatureInputField";
        public static readonly Size SignatureInputFieldSize = new System.Drawing.Size(93, 27);
        public static readonly int SignatureInputFieldTabIndex = 3;
        public static readonly string SignatureInputFieldText = "Массив";
        
        public static readonly Color InputFieldBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
        public static readonly Point InputFieldLocation = new System.Drawing.Point(88, 170);
        public static readonly string InputFieldName = "inputField";
        public static readonly Size InputFieldSize = new System.Drawing.Size(593, 288);
        public static readonly int InputFieldTabIndex = 4;
        public static readonly string InputFieldText = "";

        public static readonly Color OkButtonBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
        public static readonly Cursor OkButtonCursor = System.Windows.Forms.Cursors.Hand;
        public static readonly int OkButtonBorderSize = 0;
        public static readonly Color OkButtonMouseDownBackColor = System.Drawing.Color.Azure;
        public static readonly Color OkButtonMouseOverBackColor = System.Drawing.Color.Azure;
        public static readonly FlatStyle OkButtonFlatStyle = System.Windows.Forms.FlatStyle.Popup;
        public static readonly Font OkButtonFont = new System.Drawing.Font("Lucida Sans", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        public static readonly Color OkButtonForeColor = System.Drawing.Color.Navy;
        public static readonly Point OkButtonLocation = new System.Drawing.Point(263, 480);
        public static readonly string OkButtonName = "OkButton";
        public static readonly Size OkButtonSize = new System.Drawing.Size(199, 60);
        public static readonly int OkButtonTabIndex = 5;
        public static readonly string OkButtonText = "Ок";
        public static readonly bool OkButtonUseVisualStyleBackColor = false;
          
        public static readonly SizeF AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        public static readonly System.Windows.Forms.AutoScaleMode AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        public static readonly Color BackColor = System.Drawing.SystemColors.GradientActiveCaption;
        public static readonly Size ClientSize = new System.Drawing.Size(814, 539);
        public static readonly string Name = "DataReceiverForm";
        public static readonly string Text = "DataReceiverForm";
           
    }
}
