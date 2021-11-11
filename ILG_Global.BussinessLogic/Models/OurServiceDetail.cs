using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ILG_Global.BussinessLogic.Models
{
    public class OurServiceDetail
    {
        public int OurServiceID { get; set; }
        [ForeignKey("OurServiceID")]
        public OurServiceMaster OurServiceMaster { get; set; }

        public string LanguageCode { get; set; }
        [ForeignKey("LanguageCode")]
        public Language Language { get; set; }

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
    
    }
}
