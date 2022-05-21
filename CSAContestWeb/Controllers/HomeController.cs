using CSAContestWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CSAContestWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDocumentModelRepo _repo;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IDocumentModelRepo repo)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<DocumentModel> list = new List<DocumentModel>();
            var listDocumentModel = await _repo.GetAllDocumentModelAsync();

            if (listDocumentModel != null)
                return View(listDocumentModel);

            return View();
        }

        public async Task<IActionResult> Update(int id)
        {

            var newDocumentModel = await _repo.GetDocumentModelByIdAsync(id);

            if (newDocumentModel != null)
                return View(newDocumentModel);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(DocumentModel dModel)
        {
            try
            {
                if (dModel == null)
                {
                    return BadRequest();
                }

                bool resp = await _repo.UpdateDocumentModelAsync(dModel);

                if (resp)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("Error", "There is an API error");
                    return View(dModel);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Caught exception : " + ex);
                //return "Error：" + e.Message;
                return View(dModel);
            }
        }

        public async Task<IActionResult> DeleteDocument(int id)
        {

            var newDocumentModel = await _repo.GetDocumentModelByIdAsync(id);
            if (newDocumentModel == null) return NotFound();

            bool resp = await _repo.DeleteDocumentModelSync(id);

            if (resp)
            {
                return RedirectToAction("Index");


            }
            else
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}