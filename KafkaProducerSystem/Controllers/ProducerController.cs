using Microsoft.AspNetCore.Mvc;

namespace KafkaProducerSystem.Controllers
{
    public class ProducerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
