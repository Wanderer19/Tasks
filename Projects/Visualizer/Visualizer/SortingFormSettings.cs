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
    public class SortingFormSettings
    {
        public static readonly bool MainTitleAutoSize = true;
        public static readonly Font MainTitleFont = new System.Drawing.Font("Segoe Script", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        public static readonly Color MainTitleForeColor = System.Drawing.Color.MidnightBlue;
        public static readonly Point MainTitleLocation = new System.Drawing.Point(12, 48);
        public static readonly string MainTitleName = "mainTitle";
        public static readonly Size MainTitleSize = new System.Drawing.Size(723, 80);
        public static readonly int MainTitleTabIndex = 0;

        public virtual string MainTitleText
        {
            get { return "Сортировка"; }
        }

        public static readonly  Color AboutSortingBackColor = System.Drawing.Color.PaleTurquoise;
        public static readonly  System.Windows.Forms.BorderStyle AboutSortingBorderStyle = System.Windows.Forms.BorderStyle.None;
        public static readonly Font AboutSortingFont = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        public static readonly bool AboutSortingFormattingEnabled = true;
        public static readonly int AboutSortingItemHeight = 29;
        public static readonly Point AboutSortingLocation = new System.Drawing.Point(12, 140);
        public static readonly string AboutSortingName = "aboutSorting";
        public static readonly bool AboutSortingScrollAlwaysVisible = true;
        public static readonly Size AboutSortingSize = new System.Drawing.Size(861, 609);
        public static readonly int AboutSortingTabIndex = 1;

        public virtual string AboutSortingFile
        {
            get { return "sorting.txt"; }
        }

        public static readonly Color MainMenuBackColor = System.Drawing.Color.PaleTurquoise;
        public static readonly Point MainMenuLocation = new System.Drawing.Point(0, 0);
        public static readonly string MainMenuName = "mainMenu";
        public static readonly Size MainMenuSize = new System.Drawing.Size(850, 36);
        public static readonly int MainMenuTabIndex = 2;
        public static readonly string MainMenuText = "mainMenu";

        public static readonly Font ProgramMenuFont = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        public static readonly Color ProgramMenuForeColor = System.Drawing.Color.Navy;
        public static readonly string ProgramMenuName = "programMenu";
        public static readonly Size ProgramMenuSize = new System.Drawing.Size(146, 32);
        public static readonly string ProgramMenuText = "Программа";

        public static readonly string VisualizerMenuItemName = "visualizerMenuItem";
        public static readonly Size VisualizerMenuItemSize = new System.Drawing.Size(237, 32);
        public static readonly string VisualizerMenuItemText = "Визуализатор";

        public static readonly string SourceCodeMenuItemName = "sourceCodeMenuItem";
        public static readonly Size SourceCodeMenuItemSize = new System.Drawing.Size(237, 32);
        public static readonly string SourceCodeMenuItemText = "Исходный код";

        public static readonly string SourceCodeCSharpName = "sourceCodeCSharp";
        public static readonly Size SourceCodeCSharpSize = new System.Drawing.Size(152, 32);
        public static readonly string SourceCodeCSharpText = "C#";
        
        public static readonly string SourceCodeCPlusPlusName = "sourceCodeCPlusPlus";
        public static readonly Size SourceCodeCPlusPlusSize = new System.Drawing.Size(152, 32);
        public static readonly string SourceCodeCPlusPlusText = "C++";
       
        public static readonly string SourceCodeJavaName = "sourceCodeJava";
        public static readonly Size SourceCodeJavaSize = new System.Drawing.Size(152, 32);
        public static readonly string SourceCodeJavaText = "Java";
            
        public static readonly string SourceCodePythonName = "sourceCodePython";
        public static readonly Size SourceCodePythonSize = new System.Drawing.Size(152, 32);
        public static readonly string SourceCodePythonText = "Python";
            
        public static readonly Font HelpMenuFont = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        public static readonly Color HelpMenuForeColor = System.Drawing.Color.Navy;
        public static readonly string HelpMenuName = "helpMenu";
        public static readonly Size HelpMenuSize = new System.Drawing.Size(116, 32);
        public static readonly string HelpMenuText = "Справка";

        public static readonly string HelpMenuItemName = "helpMenuItem";
        public static readonly Size HelpMenuItemSize = new System.Drawing.Size(172, 32);
        public static readonly string HelpMenuItemText = "Помощь";
       
        public static readonly SizeF AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        public static readonly System.Windows.Forms.AutoScaleMode AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        public static readonly Color BackColor = System.Drawing.Color.PaleTurquoise;
        public static readonly Size ClientSize = new System.Drawing.Size(850, 753);
        public static readonly string Name = "SortingForm";
        public static readonly string Text = "BubbleSortForm";

        public virtual string SourceCodeCSharp  {get { return "c#.txt"; }}
        public virtual string SourceCodeCPlusPlus { get { return "c++.txt"; }}
        public virtual string SourceCodeJava  { get { return "java.txt"; }}
        public virtual string SourceCodePython { get { return "python.txt"; }}
        public virtual int SortID{ get { return 0; } }

        public static readonly string HelpFile = "help.txt";

    }
}
