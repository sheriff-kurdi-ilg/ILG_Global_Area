using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ILG_Global.BussinessLogic.Models
{
    public class HtmlContentDetail
    {
        public int HtmlContentID { get; set; }
        [ForeignKey("HtmlContentID")]
        public HtmlContentMaster HtmlContentMaster { get; set; }

        public string LanguageCode { get; set; }
        [ForeignKey("LanguageCode")]
        public Language Language { get; set; }

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
    }
}
