using Microsoft.AspNetCore.Http;

namespace SoundProdHelper.Web.Write.Models
{
    public class NewDemoModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Demo { get; set; }
    }
}