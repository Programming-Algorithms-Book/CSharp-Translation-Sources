namespace LetterTranslation
{
    public struct TranslationType
    {
        public TranslationType(string firstString, string secondString)
            : this()
        {
            this.FirstString = firstString;
            this.SecondString = secondString;
        }

        public string FirstString { get; set; }

        public string SecondString { get; set; }
    }
}