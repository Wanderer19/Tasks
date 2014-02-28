using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Windows.Forms;

namespace Visualizer
{
    class SourceCodeSettings
    {
        public static readonly Color TextFieldBackColor = System.Drawing.Color.PaleTurquoise; 
        public static readonly System.Windows.Forms.BorderStyle TextFieldBorderStyle = System.Windows.Forms.BorderStyle.None;
        public static readonly Font TextFieldFont = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        public static readonly Point TextFieldLocation = new System.Drawing.Point(12, 12);
        public static readonly string TextFieldName = "TextField";
        public static readonly bool TextFieldReadOnly = true;
        public static readonly Size TextFieldSize = new System.Drawing.Size(870, 573);
        public static readonly int TextFieldTabIndex = 1;

        public static readonly SizeF AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        public static readonly System.Windows.Forms.AutoScaleMode AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        public static readonly Color BackColor = System.Drawing.Color.PaleTurquoise;
        public static readonly Size ClientSize = new System.Drawing.Size(887, 606);
        public static readonly string Name = "Sourcecode";
        public static readonly string Text = "Sourcecode";
    }
}
