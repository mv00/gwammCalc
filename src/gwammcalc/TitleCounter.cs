namespace GwammCalc
{
    public static class TitleCounter
    {
        private static int _titleCount;

        public static void AddTitle()
        {
            var oldtitleCount = _titleCount;
            _titleCount++;
        }
        public static void RemoveTitle() => _titleCount--;
        public static int CurrentTitleCount => _titleCount;
    }
}
