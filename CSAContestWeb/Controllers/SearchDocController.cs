using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Models;
using CSAContestWeb.Extension;
using CSAContestWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSAContestWeb.Controllers
{
    public class SearchDocController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SearchIndexClient _searchIndexClient;
        private IExtensionRepo _extRepo;
        private readonly IDocumentModelRepo _repo;
        //List<DocumentModel> list = new List<DocumentModel>();

        //private readonly IConfigurationRoot _configuration;

        public SearchDocController(ILogger<HomeController> logger, SearchIndexClient searchIndexClient, IExtensionRepo extRepo, IDocumentModelRepo repo)
        {
            _logger = logger;
            _searchIndexClient = searchIndexClient;
            _extRepo = extRepo;
            _repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            string indexName = "azureblob-index";
            string queryApiKey = "HRZJz08HaLYyuFraCYmNXBrdEWoUgnhSB8SKG4sDEEAzSeB6knH1";
            

            var options = new SearchOptions
            {

                Size = 500,
                SearchMode = SearchMode.Any,
                QueryType = SearchQueryType.Full,
                Filter = "",
                OrderBy = { "" },
                IncludeTotalCount = true

            };

            SearchClient searchClient = _searchIndexClient.GetSearchClient(indexName);
            SearchResults<SearchDocument> response = await searchClient.SearchAsync<SearchDocument>("*", options);
            foreach (SearchResult<SearchDocument> result in response.GetResults())
            {
                DocumentModel _doc = new DocumentModel();

                string content = (string)result.Document["merged_content"];
                _doc.StoragePath = (string)result.Document["metadata_storage_path"];
                _doc.DateInvoice = _extRepo.Between(content, "Date", "Case leNicHoir");
                _doc.ReceiverBy = _extRepo.Between(content, "Received by", "CONTACT INFORMATION");
                _doc.BirdFindLocation = _extRepo.Between(content, "Where was the bird found?", "SALUTATION");
                _doc.DonorName = _extRepo.Between(content, "NAME", "ADDRESS");
                _doc.DonorAddress = _extRepo.Between(content, "ADDRESS", "APT");
                _doc.DonorApt = _extRepo.Between(content, "APT", "CITY");
                _doc.DonorCity = _extRepo.Between(content, "CITY", "POSTAL CODE");
                _doc.DonorPostal = _extRepo.Between(content, "POSTAL CODE", "TELEPHONE");
                _doc.DonorTel = _extRepo.Between(content, "TELEPHONE", "EMAIL");
                _doc.DonorEmail = _extRepo.Between(content, "EMAIL", "Je préfère des communications en français");
                string giftXfind = _extRepo.Between(content, "I WOULD LIKE TO SUPPORT LE NICHOIR WITH A GIFT IN THE AMOUNT OF", "Tax receipt by");
                _doc.SumGifted = _extRepo.findXinGift(giftXfind);
                string TaxXfind = _extRepo.Between(content, "Tax receipt by", "PLEASE CONSIDER MY GIFT AS");
                _doc.TaxReceipt = _extRepo.findXinTax(TaxXfind);
                string considerXfind = _extRepo.Between(content, "PLEASE CONSIDER MY GIFT AS (OPTIONAL) :", "Yes, I would like to receive News");
                _doc.GiftConsideration = _extRepo.considerXinTax(considerXfind);
                //Console.WriteLine($"{content}\n{storage_path}\n");
                DoclisClass.list.Add(_doc);
            }
            var newDocumentModel = new DocumentModel();
            if (DoclisClass.list != null)
                return View(DoclisClass.list);

            return View();
        }

        public async Task<IActionResult> Add()
        {
            if (DoclisClass.list != null)
            {
                foreach (DocumentModel doc in DoclisClass.list)
                {
                    var docpath = await _repo.GetDocByStoragePathAsync(doc.StoragePath);

                    if (docpath == null)
                        await _repo.AddDocumentModelAsync(doc);
                }

            }
           
            return RedirectToAction("Index");
        }

        

        
    }
}
