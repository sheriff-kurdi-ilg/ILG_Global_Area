using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ILG_Global.BussinessLogic.Models
{
    public class NewsLetterSubscribe
    {
        public int ID { get; set; }

        public string PreferredLanguage { get; set; }

        [Required] 
        //[RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z")]
        public string Email { get; set; }
        public bool? IsEnabled { get; set; }
    }
}
