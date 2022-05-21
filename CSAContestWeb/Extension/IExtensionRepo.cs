namespace CSAContestWeb.Extension
{
    public interface IExtensionRepo
    {
        string Between(string content, string start, string end);
        void findGiftAmount(string val);
        void findGiftConsideration(string val);
        void findTaxReceipt(string val);
        string findXinGift(string str);
        string findXinTax(string str);
        string considerXinTax(string str);
    }
}