using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Visualizer
{
    public class VisualizerSettings
    {
        public static readonly Point MainMenuLocation = new System.Drawing.Point(0, 0);
        public static readonly string MainMenuName = "mainMenu";
        public static readonly Size MainMenuSize = new System.Drawing.Size(1182, 36);
        public static readonly int MainMenuTabIndex = 0;
        public static readonly string MainMenuText = "mainMenu";

        public static readonly Font HelpMenuFont = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        public static readonly string HelpMenuName = "helpMenu";
        public static readonly Size HelpMenuSize = new System.Drawing.Size(102, 32);
        public static readonly string HelpMenuText = "Справка";

        public static readonly string HelpMenuItemName = "helpMenuItem";
        public static readonly Size HelpMenuItemSize = new System.Drawing.Size(166, 32);
        public static readonly string HelpMenuItemText = "Помощь";

        public static readonly System.Windows.Forms.AutoSizeMode ChangeDataButtonAutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        public static readonly Color ButtonBackColor = System.Drawing.Color.MediumTurquoise;
        public static readonly Cursor ButtonCursor = System.Windows.Forms.Cursors.Hand;
        public static readonly int ButtonBorderSize = 0;
        public static readonly Color ButtonMouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        public static readonly Color ButtonMouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
        public static readonly FlatStyle ButtonFlatStyle = System.Windows.Forms.FlatStyle.Popup;
        public static readonly Font ButtonFont = new System.Drawing.Font("Lucida Sans", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        public static readonly Color ButtonForeColor = System.Drawing.Color.Black;
        public static readonly bool ButtonUseVisualStyleBackColor = false;

        public static readonly int ChangeDataButtonTabIndex = 1;
        public static readonly Point ChangeDataButtonLocation = new System.Drawing.Point(175, 715);
        public static readonly string ChangeDataButtonName = "changeDataButton";
        public static readonly Size ChangeDataButtonSize = new System.Drawing.Size(802, 38);
        public static readonly string ChangeDataButtonText = "Поменять данные";
       
        public static readonly Point StartButtonLocation = new System.Drawing.Point(175, 677);
        public static readonly string StartButtonName = "startButton";
        public static readonly Size StartButtonSize = new System.Drawing.Size(249, 43);
        public static readonly int StartButtonTabIndex = 2;
        public static readonly string StartButtonText = "В начало";

        public static readonly Point AutomaticModeButtonLocation = new System.Drawing.Point(412, 677);
        public static readonly string AutomaticModeButtonName = "automaticModeButton";
        public static readonly Size AutomaticModeButtonSize = new System.Drawing.Size(565, 43);
        public static readonly int AutomaticModeButtonTabIndex = 4;
        public static readonly string AutomaticModeButtonText = "Автоматический режим";

        public static readonly Point ForwardButtonLocation = new System.Drawing.Point(175, 649);
        public static readonly string ForwardButtonName = "forwardButton";
        public static readonly Size ForwardButtonSize = new System.Drawing.Size(249, 33);
        public static readonly int ForwardButtonTabIndex = 5;
        public static readonly string ForwardButtonText = ">>>Вперед";

        public static readonly Point BackwardButtonLocation = new System.Drawing.Point(412, 649);
        public static readonly string BackwardButtonName = "backwardButton";
        public static readonly Size BackwardButtonSize = new System.Drawing.Size(273, 33);
        public static readonly int BackwardButtonTabIndex = 6;
        public static readonly string BackwardButtonText = "<<<Назад";

        public static readonly Point PauseButtonLocation = new System.Drawing.Point(680, 649);
        public static readonly string PauseButtonName = "pauseButton";
        public static readonly Size PauseButtonSize = new System.Drawing.Size(136, 33);
        public static readonly int PauseButtonTabIndex = 7;
        public static readonly string PauseButtonText = "Пауза";

        public static readonly Point ContinueButtonLocation = new System.Drawing.Point(813, 649);
        public static readonly string ContinueButtonName = "continueButton";
        public static readonly Size ContinueButtonSize = new System.Drawing.Size(164, 33);
        public static readonly int ContinueButtonTabIndex = 8;
        public static readonly string ContinueButtonText = "Продолжить";

        public static readonly SizeF AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        public static readonly System.Windows.Forms.AutoScaleMode AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        public static readonly Color BackColor = System.Drawing.Color.LightCyan;
        public static readonly Size ClientSize = new System.Drawing.Size(1182, 753);
        

        public Point PositionFirstElement
        {
            get { return new Point(3, 200); }
        }

        public  int WidthElemet { get { return 100; }}
        public  Color SelectedElementColor { get { return Color.Fuchsia; }}
        public  Color ElementColor { get { return Color.LightCyan; }}
        public  Size ElementSize { get { return new Size(100, 100); }}
        public  string HelpFile { get { return "help.txt"; }}
        public  Rectangle UpperCommentField { get { return new Rectangle(0, 0, 1500, 200); }}
        public  Rectangle BottomCommentField { get { return new Rectangle(300, 400, 1500, 500); }}
        public  PointF LocationBottomCommentField { get { return new PointF(400, 400); }}
        public  System.Drawing.Font FontDigits { get { return new System.Drawing.Font("Arial", 20); }}
        public  System.Drawing.StringFormat FormatDrawing { get { return new System.Drawing.StringFormat(); }}
        public  System.Drawing.SolidBrush BrushDigit { get
        {
            return new System.Drawing.SolidBrush(System.Drawing.Color.Black);
        }}
        public  System.Drawing.SolidBrush BrushElement { get
        {
            return new System.Drawing.SolidBrush(System.Drawing.Color.LightCyan);
        }}
        public  Pen PenElement { get { return new Pen(Color.Blue, 7); }}
        public  string SymbolComparison { get { return "VS"; }}
        public  Point[] FirstPointerCoordinates { get
        {
            return new Point[] {new Point(53, 180), new Point(100, 155), new Point(153, 180)};
        }}

        public virtual int SortId { get { return 0; } }
    }
}
