using Crud_Api.Entities;

namespace Crud_Api.DTO.Games
{
    public class GamesCreateDto
    {
       
        public int BannedWordCount { get; set; }
        public int FailCount { get; set; }
        public int SkipCount { get; set; }
        public int Time { get; set; }
        public string LangCode { get; set; }
        
    }
}
