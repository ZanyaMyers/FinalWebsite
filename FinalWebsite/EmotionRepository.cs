using Dapper;
using FinalWebsite.Models;
using System.Data;

namespace FinalWebsite
{
    public class EmotionRepository : IEmotionRepository
    {
        private readonly IDbConnection _conn;

        public EmotionRepository(IDbConnection conn)
        {
            _conn = conn;
        }
        public IEnumerable<Emotion> GetAllEmotions()
        {
            return _conn.Query<Emotion>("SELECT * FROM ENTRIES;");
        }

        public Emotion GetEmotion(int id)
        {
            return _conn.QuerySingle<Emotion>("SELECT * FROM ENTRIES WHERE NEWENTRYID = @id", new { id = id });
        }

        public void UpdateEmotion(Emotion emotion)
        {
            _conn.Execute("UPDATE entries SET EntryText = @entrytext WHERE NewEntryID = @id",
            new { EntryText = emotion.EntryText, id = emotion.NewEntryID });
        }
    }
}
