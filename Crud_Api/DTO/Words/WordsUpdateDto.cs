namespace Crud_Api.DTO.Words
{
    public class WordsUpdateDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string LangCode { get; set; }
        public HashSet<string> BannedWords { get; set; }
    }
}
