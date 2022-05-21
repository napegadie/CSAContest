namespace CSAContestWeb.Models
{
    public class AzureSearchReturnModel
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "moduleId")]
        public String ModuleId { get; set; }


        [Newtonsoft.Json.JsonProperty(PropertyName = "endItemId")]
        public String EndItemId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "endItemTypeId")]
        public String EndItemTypeId { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "fileName")]
        public string FileName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "fileExtension")]
        public string FileExtension { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "moduleType")]
        public string ModuleTypeName { get; set; }

        [Newtonsoft.Json.JsonProperty(PropertyName = "metadata_storage_size")]
        public long FileSize { get; set; }
    }
}
