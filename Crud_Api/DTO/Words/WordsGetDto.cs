﻿namespace Crud_Api.DTO.Words
{
    public class WordsGetDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string LangCode { get; set; }
        public HashSet<string> BannedWords { get; set; }
    }
}
