using System.ComponentModel.DataAnnotations;

namespace CSAContestWeb.Models
{
    public class DocumentModel
    {
        [Key]
        [Required]
        public int DocSearchId { get; set; }

        public string StoragePath { get; set; } = string.Empty;
        public string DateInvoice { get; set; } = string.Empty;
        public string ReceiverBy { get; set; } = string.Empty;
        public string BirdFindLocation { get; set; } = string.Empty;
        public string DonorName { get; set; } = string.Empty;
        public string DonorAddress { get; set; } = string.Empty;
        public string DonorApt { get; set; } = string.Empty;
        public string DonorCity { get; set; } = string.Empty;
        public string DonorPostal { get; set; } = string.Empty;
        public string DonorTel { get; set; } = string.Empty;
        public string DonorEmail { get; set; } = string.Empty;
        public string SumGifted { get; set; } = string.Empty;
        public string TaxReceipt { get; set; } = string.Empty;
        public string GiftConsideration { get; set; } = string.Empty;
    }
}
