using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Indexes;
using Azure.Search.Documents.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace CSAContestWeb.Controllers
{
    public class SearchController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SearchClient _searchClient;
        //private readonly IConfigurationRoot _configuration;

        public SearchController(ILogger<HomeController> logger, SearchClient searchClient)
        {
            _logger = logger;
            _searchClient = searchClient;
            //_configuration = configuration;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult SearchContent()
        {
            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> SearchContent(string SearchString)
        {
            string serviceName = "<YOUR-SERVICE-NAME>";
            //string indexName = "hotels-quickstart";
            string apiKey = "<YOUR-ADMIN-API-KEY>";

            //string indexName = _configuration["SearchClient:indexname"];
            //string searchServiceEndPoint = _configuration["SearchClient:endpoint"];
            //string queryApiKey = _configuration["SearchClient:apiKey"];

            string indexName = "index";
            string searchServiceEndPoint = "index";
            string queryApiKey = "index";

            try
            {

                if (!String.IsNullOrEmpty(SearchString))
                {
                    //var searchTerm = term.TrimEnd('*').Trim() + "*";

                    var options = new SearchOptions
                    {

                        Size = 500,
                        SearchMode = SearchMode.Any,
                        QueryType = SearchQueryType.Full,
                        Filter = "",
                        OrderBy = { "" },
                        IncludeTotalCount = true
                        //Filter = $"{nameof(OrderProcessIndex.Source)} eq 'ArchiveV2'"

                    };

                    //options.Select.Add("HotelId");
                    //options.Select.Add("HotelName");
                    //options.Select.Add("Description_fr");
                    //options.SearchFields.Add("Tags");
                    //options.SearchFields.Add("Description_fr");


                    // Create a SearchIndexClient to send create/delete index commands
                    Uri serviceEndpoint = new Uri($"https://{serviceName}.search.windows.net/");
                    AzureKeyCredential credential = new AzureKeyCredential(apiKey);
                    SearchIndexClient adminClient = new SearchIndexClient(serviceEndpoint, credential);

                    // Create a SearchClient to load and query documents
                    SearchClient srchclient = new SearchClient(serviceEndpoint, indexName, credential);
                    SearchClient searchClient = new SearchClient(new Uri(searchServiceEndPoint), indexName, new AzureKeyCredential(queryApiKey));

                    //SearchResults<JsonObject> response = srchclient.Search<JsonObject>("name", options);
                    SearchResults<SearchDocument> response = srchclient.Search<SearchDocument>("name", options);
                    //SearchResults<SearchDocument> response = client.Search<SearchDocument>("Microsoft", new SearchOptions { Size = 5 });


                    foreach (SearchResult<SearchDocument> result in response.GetResults())
                    {
                        string title = (string)result.Document["business_title"];
                        string description = (string)result.Document["job_description"];
                        Console.WriteLine($"{title}\n{description}\n");
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Ok();
        }
    }
}
