namespace GwammCalc
{
    public static class TitleCounter
    {
        private static int _titleCount;

        public static int CurrentTitleCount => _titleCount;

        public static void AddTitle() => _titleCount++;
        public static void RemoveTitle() => _titleCount--;
    }
}
