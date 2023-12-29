using FinalWebsite.Models;

namespace FinalWebsite
{
    public interface IEmotionRepository
    {
        public IEnumerable<Emotion> GetAllEmotions();

        public Emotion GetEmotion(int id);

        public void UpdateEmotion(Emotion emotion);

        public void InsertEmotion(Emotion emotionToInsert);

        public IEnumerable<Category> GetCategories();

        public Emotion AssignCategory();

        public void DeleteEmotion(Emotion emotion);
    }
}
