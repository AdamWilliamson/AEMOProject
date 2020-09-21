namespace WebAPI.Controllers.SubTextMatching
{
    public class SubTextMatchingViewModel
    {
        public string Text { get; set; }
        public string SubText { get; set; }
        public bool CaseSensitive { get; set; }

        //public SubTextMatchingViewModel(string text, string subText, bool caseSensitive)
        //{
        //    Text = text;
        //    SubText = subText;
        //    CaseSensitive = caseSensitive;
        //}
    }
}
