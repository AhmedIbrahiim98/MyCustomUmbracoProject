using Microsoft.AspNetCore.Mvc;
using MyCustomUmbracoProject.Interfaces;
using MyCustomUmbracoProject.Models;

namespace MyCustomUmbracoProject.Controllers
{
    [Route("api/[controller]")]
    public class ContentController : ControllerBase
    {
        private IContentService _contentService;

        public ContentController(IContentService contentService)
        {
            _contentService = contentService;
        }

        [HttpGet]
        [Route("home-content")]
        public ActionResult<HomepageDTO> FetcHomeContent()
        {
            var result = this._contentService.GetHomeContent();
            return Ok(result);
        }
    }
}
