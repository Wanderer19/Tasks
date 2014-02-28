using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualizer
{
    class SelectionSortFormSettings : SortingFormSettings
    {
        public override string MainTitleText { get { return "Сортировка выбором"; } }
        public override string AboutSortingFile { get { return "selectionSort.txt"; } }
        public override string SourceCodeCSharp { get { return "SelectionSort(c#).txt"; } }
        public override string SourceCodeCPlusPlus { get { return "SelectionSort(c++).txt"; } }
        public override string SourceCodeJava { get { return "SelectionSort(java).txt"; } }
        public override string SourceCodePython { get { return "SelectionSort(python).txt"; } }
        public override int SortID { get { return 2; } }
    }
}
