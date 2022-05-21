namespace CSAContestWeb.Models
{
    public class FileModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IFormFile FormBlobFile { get; set; }
    }
}
