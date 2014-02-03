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
    public static class GeneralSettings
    {
        public static readonly bool MainTitleAutoSize = true;
        public static readonly Color MainTitleBackColor = System.Drawing.Color.LightSkyBlue;
        public static readonly Font MainTitleFont = new System.Drawing.Font("Monotype Corsiva", 48F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        public static readonly Color MainTitleForeColor = System.Drawing.Color.Blue;
        public static readonly Point MainTitleLocation = new System.Drawing.Point(48, 82);
        public static readonly System.Windows.Forms.Padding MainTitleMargin = new System.Windows.Forms.Padding(17, 0, 17, 0);
        public static readonly string MainTitleName = "mainTitle";
        public static readonly Size MainTitleSize = new System.Drawing.Size(783, 97);
        public static readonly int MainTitleTabIndex = 0;
        public static readonly string MainTitleText = "Алгоритмы Сортировок";
        public static readonly System.Drawing.ContentAlignment MainTitleTextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        public static readonly Color BubbleSortButtonBackColor = System.Drawing.Color.LightSkyBlue;
        public static readonly Cursor BubbleSortButtonCursor = System.Windows.Forms.Cursors.Hand;
        public static readonly Color BubbleSortButtonBorderColor = System.Drawing.Color.Navy;
        public static readonly int BubbleSortButtonBorderSize = 0;
        public static readonly Color BubbleSortButtonMouseDownBackColor = System.Drawing.SystemColors.Highlight;
        public static readonly Color BubbleSortButtonMouseOverBackColor = System.Drawing.SystemColors.Highlight;
        public static readonly FlatStyle BubbleSortButtonFlatStyle = System.Windows.Forms.FlatStyle.Flat;
        public static readonly Font BubbleSortButtonFont = new System.Drawing.Font("Mistral", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        public static readonly Color BubbleSortButtonForeColor = System.Drawing.Color.DarkBlue;
        public static readonly Point BubbleSortButtonLocation = new System.Drawing.Point(105, 228);
        public static readonly string BubbleSortButtonName = "bubbleSortButton";
        public static readonly Size BubbleSortButtonSize = new System.Drawing.Size(654, 125);
        public static readonly int BubbleSortButtonTabIndex = 1;
        public static readonly string BubbleSortButtonText = "Пузырьковая сортировка";
        public static readonly bool BubbleSortButtonUseVisualStyleBackColor = false;

        public static readonly Color MainMenuBackColor = System.Drawing.Color.LightSkyBlue;
        public static readonly Font MainMenuFont = new System.Drawing.Font("Stencil", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        public static readonly Point MainMenuLocation = new System.Drawing.Point(0, 0);
        public static readonly string MainMenuName = "mainMenu";
        public static readonly Size MainMenuSize = new System.Drawing.Size(857, 37);
        public static readonly int MainMenuTabIndex = 2;

        public static readonly Font HelpProgramMenuFont = new System.Drawing.Font("Stencil", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        public static readonly Color HelpProgramMenuForeColor = System.Drawing.Color.DarkBlue;
        public static readonly string HelpProgramMenuName = "helpProgramMenu";
        public static readonly Size HelpProgramMenuSize = new System.Drawing.Size(129, 33);
        public static readonly string HelpProgramMenuText = "Справка";

        public static readonly string AboutProgramMenuItemName = "aboutProgramMenuItem";
        public static readonly Size AboutProgramMenuItemSize = new System.Drawing.Size(253, 34);
        public static readonly string AboutProgramMenuItemText = "О программе";
        public static readonly string AboutProgramFile = "about.txt";

        public static readonly string HelpMenuItemName = "helpMenuItem";
        public static readonly Size HelpMenuItemSize = new System.Drawing.Size(253, 34);
        public static readonly string HelpMenuItemText = "Справка";
        public static readonly string HelpFile = "help.txt";

        public static readonly SizeF AutoScaleDimensions = new System.Drawing.SizeF(48F, 143F);
        public static readonly System.Windows.Forms.AutoScaleMode AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        public static readonly Color BackColor = System.Drawing.Color.LightSkyBlue;
        public static readonly Size ClientSize = new System.Drawing.Size(857, 897);
        public static readonly Font Font = new System.Drawing.Font("Mistral", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
        public static readonly Padding Margin = new System.Windows.Forms.Padding(17, 25, 17, 25);
        public static readonly string Name = "Application";
        public static readonly System.Windows.Forms.FormStartPosition StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        public static readonly string Text = "Визуализатор алгоритмов сортировок";

        public const int BubbleSortId = 1;
    }
}
