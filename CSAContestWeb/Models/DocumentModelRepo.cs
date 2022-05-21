using Microsoft.EntityFrameworkCore;

namespace CSAContestWeb.Models
{
    public class DocumentModelRepo : IDocumentModelRepo
    {
        private DocSearchDbContext _context;
        public DocumentModelRepo(DocSearchDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddDocumentModelAsync(DocumentModel newDocumentModel)
        {
            if (newDocumentModel == null)
            {
                throw new ArgumentNullException(nameof(newDocumentModel));
            }

            //var _publisher = new Publisher()
            //{
            //    Name = newPublisher.Name
            //};


            _context.DocSearch.Add(newDocumentModel);
            bool resp = await _context.SaveChangesAsync() >= 1;

            return resp;
        }

        public async Task<bool> DeleteDocumentModelSync(int docSearchId)
        {
            var _docSearch = await _context.DocSearch.FirstOrDefaultAsync(n => n.DocSearchId == docSearchId);

            if (_docSearch == null)
            {
                throw new Exception($"The Search Document with id: {docSearchId} does not exist");

            }

            _context.DocSearch.Remove(_docSearch);
            bool resp = await _context.SaveChangesAsync() >= 1;

            return resp;
        }

        public async Task<IEnumerable<DocumentModel>> GetAllDocumentModelAsync()
        {
            return await _context.DocSearch.ToListAsync();
        }

        public async Task<DocumentModel> GetDocumentModelByIdAsync(int docSearchId)
        {
            var _docSearchData = await _context.DocSearch.Where(p => p.DocSearchId == docSearchId).FirstOrDefaultAsync();

            return _docSearchData;
        }

        public async Task<DocumentModel> GetDocByStoragePathAsync(string path)
        {
            var _docSearchData = await _context.DocSearch.Where(p => p.StoragePath.Contains(path)).FirstOrDefaultAsync();

            return _docSearchData!;
        }

        public async Task<bool> UpdateDocumentModelAsync(DocumentModel newDocumentModel)
        {
            var _docSearch = _context.DocSearch.FirstOrDefault(n => n.DocSearchId == newDocumentModel.DocSearchId);

            if (_docSearch == null)
            {
                throw new ArgumentNullException(nameof(_docSearch));

            }

            //_docSearch.Name = newDocumentModel.Name;
            _docSearch.DateInvoice = newDocumentModel.DateInvoice;
            _docSearch.ReceiverBy = newDocumentModel.ReceiverBy;
            _docSearch.BirdFindLocation = newDocumentModel.BirdFindLocation;
            _docSearch.DonorName = newDocumentModel.DonorName;
            _docSearch.DonorAddress = newDocumentModel.DonorAddress;
            _docSearch.DonorCity = newDocumentModel.DonorCity;
            _docSearch.DonorApt = newDocumentModel.DonorApt;
            _docSearch.DonorPostal = newDocumentModel.DonorPostal;
            _docSearch.DonorTel = newDocumentModel.DonorTel;
            _docSearch.DonorEmail = newDocumentModel.DonorEmail;
            _docSearch.SumGifted = newDocumentModel.SumGifted;
            _docSearch.TaxReceipt = newDocumentModel.TaxReceipt;
            _docSearch.GiftConsideration = newDocumentModel.GiftConsideration;

            _context.Entry(_docSearch).State = EntityState.Modified;
            bool resp = await _context.SaveChangesAsync() >= 1;

            return (resp);
        }
    }
}
