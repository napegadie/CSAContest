
namespace CSAContestWeb.Models
{
    public interface IDocumentModelRepo
    {
        Task<bool> AddDocumentModelAsync(DocumentModel newDocumentModel);
        Task<bool> DeleteDocumentModelSync(int docSearchId);
        Task<IEnumerable<DocumentModel>> GetAllDocumentModelAsync();
        Task<DocumentModel> GetDocumentModelByIdAsync(int docSearchId);
        Task<bool> UpdateDocumentModelAsync(DocumentModel newDocumentModel);
        Task<DocumentModel> GetDocByStoragePathAsync(string path);
    }
}