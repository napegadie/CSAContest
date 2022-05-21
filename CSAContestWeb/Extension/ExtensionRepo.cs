using CSAContestWeb.Models;
using System.ComponentModel.DataAnnotations;

namespace CSAContestWeb.Extension
{
    public class DoclisClass
    {
        public static List<DocumentModel> list = new List<DocumentModel>();
    }
    public class ExtensionRepo : IExtensionRepo
    {
        //public List<DocumentModel> list = new List<DocumentModel>();
        public string Between(string content, string start, string end)
        {
            if (start.Equals(end))
                throw new ArgumentException("Start string can't equals a end string.");

            int startIndex = content.LastIndexOf(start) + start.Length;
            int endIndex = content.LastIndexOf(end) - startIndex;

            return content.Substring(startIndex, endIndex);
        }

        public void findGiftAmount(string val)
        {
            switch (val)
            {
                case "$10 ":
                    {
                        Console.WriteLine("Medium number");
                        break;
                    }
                case "$25 ":
                    break;
                case "$35 ":
                    break;
                case "$50 ":
                    break;
                case "$75 ":
                    break;
                case "$100":
                    break;
                default:
                    break;
            }
        }


        public void findTaxReceipt(string val)
        {
            switch (val)
            {
                case "Email":
                    break;
                case "Mail":
                    break;
                case "Mai":
                    break;
                case "Not cecessary":
                    break;
                default:
                    break;
            }
        }

        public void findGiftConsideration(string val)
        {
            switch (val)
            {
                case "In memory":
                    break;
                case "in honour of":
                    break;
                default:
                    break;
            }
        }

        public string findXinGift(string str)
        {
            var c = 'X';
            var i = str.LastIndexOf(c);

            if (i == -1)
            {
                return " ";
            }
            
            return str.Substring(i+1, 5).Trim(); 
        }

        public string findXinTax(string str)
        {
            var c = 'X';
            var i = str.LastIndexOf(c);

            if (i == -1)
            {
                return " ";
            }
            string val = str.Substring(i + 1, 6).Trim();
            if (str.Substring(i + 1, 6).Trim().StartsWith("Email") || str.Substring(i + 1, 6).Trim().StartsWith("Mai"))
                return str.Substring(i + 1, 6).Trim();
            else
                return "Not necessary";
        }

        public string considerXinTax(string str)
        {
            var c = 'X';
            var i = str.LastIndexOf(c);
            var l = str.Length;

            if (l-i < 10)
            {
                return "";
            }

            if (i == -1)
            {
                return " ";
            }
            //string val = str.Substring(i + 1, 11).Trim();
            if (str.Substring(i + 1, 11).Trim().Contains("memory"))
                return "In memory of";
            else if (str.Substring(i + 1, 11).Trim().Contains("honour"))
                return "In honour of";
            else
                return " ";
        }

        //public class KrepselisClass
        //{
            
        //}

    }
}
