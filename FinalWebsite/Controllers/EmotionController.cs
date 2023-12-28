using FinalWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalWebsite.Controllers
{
    public class EmotionController : Controller
    {
        private readonly IEmotionRepository repo;

        public EmotionController(IEmotionRepository repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            var emotions = repo.GetAllEmotions();
            return View(emotions);
        }

        public IActionResult ViewEmotion(int id)
        {
            var emotion = repo.GetEmotion(id);
            return View(emotion);
        }
        public IActionResult UpdateEmotion(int id)
        {
            Emotion emo = repo.GetEmotion(id);
            if (emo == null)
            {
                return View("EntryNotFound");
            }
            return View(emo);
        }

        public IActionResult UpdateEmotionToDatabase(Emotion emotion)
        {
            repo.UpdateEmotion(emotion);

            return RedirectToAction("ViewEmotion", new { id = emotion.NewEntryID });
        }
    }
}
