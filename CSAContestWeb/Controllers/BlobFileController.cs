using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Azure;

namespace CSAContestWeb.Controllers
{
    public class BlobFileController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BlobServiceClient _blobServiceClient;


        public BlobFileController(ILogger<HomeController> logger, BlobServiceClient blobServiceClient)
        {
            _logger = logger;
            _blobServiceClient = blobServiceClient;
        }
        // Get a list of all the blobs in the demo container
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("test");
            var results = new List<string>();
            await foreach (BlobItem blob in containerClient.GetBlobsAsync())
            {
                results.Add(blob.Name);
            }
            return results.ToArray();
        }

        public IActionResult UploadFile()
        {
            return View();
        }

        [HttpPost()]
        public async Task<IActionResult> UploadFile(IFormFile files)
        {
            try
            {

                if (files != null)
                {

                    HttpClient httpClient = new HttpClient();

                    // Create the container and return a container client object
                    BlobContainerClient containerClient = _blobServiceClient.GetBlobContainerClient("test");
                    await containerClient.CreateIfNotExistsAsync();

                    // Get a reference to a blob
                    BlobClient blobClient = containerClient.GetBlobClient(files.FileName);
                    BlobHttpHeaders httpHeaders = new BlobHttpHeaders()
                    {
                        ContentType = files.ContentType
                    };

                    // Upload data from the local file
                    await blobClient.UploadAsync(files.OpenReadStream(), httpHeaders);

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
