using Microsoft.AspNetCore.Mvc;
using MyFirstServerSideBlazor.Servises.Contracts;
using System.Drawing.Imaging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstServerSideBlazor
{
    [Route("[controller]")]
    [ApiController]
    public class ImageAPI : ControllerBase
    {
        private readonly IBookCoverGeneratorServise _coverServise;

        public ImageAPI(IBookCoverGeneratorServise coverServise)
        {
            _coverServise = coverServise;
        }


        // GET api/<ImageAPI>/5
        [Route("Cover/{title}")]
        [HttpGet]
        public IActionResult Get(string title)
        {
            var cover = _coverServise.CreateCover(title);

            using (var _memorystream = new MemoryStream())
            {
                cover.Save(_memorystream, ImageFormat.Png);
                return File(_memorystream.ToArray(), "image/png");
            }
        }


    }
}
