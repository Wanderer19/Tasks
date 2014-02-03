namespace Visualizer
{
    class BubbleSortFormSettings : SortingFormSettings
    {
        public override string MainTitleText { get { return "Пузырьковая Сортировка"; } }
        public override string AboutSortingFile { get { return "bubbleSort.txt"; } }
        public override string SourceCodeCSharp { get { return "BubleSort(c#).txt"; } }
        public override string SourceCodeCPlusPlus { get { return "BubleSort(c++).txt"; } }
        public override string SourceCodeJava { get { return "BubleSort(java).txt"; } }
        public override string SourceCodePython { get { return "BubleSort(python).txt"; } }
        public override int SortID { get { return 1; } }
    }
}