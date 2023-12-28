namespace FinalWebsite.Models
{
    public class Emotion
    {
        public Emotion()
        {

        }

        public DateTime Date {  get; set; }
        public int NewEntryID {  get; set; }

        //public string EmotionType { get; set; }
        public string EmotionName { get; set; }

        public string EntryText { get; set; }
        
    }
}
