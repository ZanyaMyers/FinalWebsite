using Dapper;
using FinalWebsite.Models;
using System.Data;

namespace FinalWebsite.Repository
{
    public class EmotionRepository : IEmotionRepository
    {
        private readonly IDbConnection _conn;

        public EmotionRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public Emotion AssignCategory()
        {
            var categoryList = GetCategories();
            var emotion = new Emotion();
            emotion.Categories = categoryList;
            return emotion;
        }

        public void DeleteEmotion(Emotion emotion)
        {
            _conn.Execute("DELETE FROM entries WHERE NEWENTRYID = @id;", new { id = emotion.NewEntryID });
        }

        public IEnumerable<Emotion> GetAllEmotions()
        {
            return _conn.Query<Emotion>("SELECT * FROM ENTRIES; SELECT * FROM emotions;");
        }

        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM emotions;");
        }

        public Emotion GetEmotion(int id)
        {
            return _conn.QuerySingle<Emotion>("SELECT * FROM ENTRIES WHERE NEWENTRYID = @id", new { id });
        }

        public void InsertEmotion(Emotion emotionToInsert)
        {
            _conn.Execute("INSERT INTO entries (DATE, EMOTIONNAME, ENTRYTEXT) VALUES (@date, @EmotionName, @EntryText);",
       new { emotionToInsert.Date, emotionToInsert.EmotionType, emotionToInsert.EmotionName, emotionToInsert.EntryText });
        }

        public void UpdateEmotion(Emotion emotion)
        {
            _conn.Execute("UPDATE entries SET EntryText = @EntryText WHERE NewEntryID = @id",
           new { emotion.EntryText, id = emotion.NewEntryID });
        }


    }
}
