using Microsoft.AspNetCore.Mvc;
using MyCustomUmbracoProject.Models;
using Umbraco.Cms.Web.Common;
using ContentModels = Umbraco.Cms.Web.Common.PublishedModels;

namespace MyCustomUmbracoProject.Controllers
{
    public class AngularController : ControllerBase
    {
        private UmbracoHelper umbracoHelper;

        public AngularController(UmbracoHelper umbracoHelper)
        {
            this.umbracoHelper = umbracoHelper;
        }
        [HttpGet]
        public ActionResult<HomepageDTO> Get()
        {
            var model = this.umbracoHelper?.ContentAtRoot()?.DescendantsOrSelf<ContentModels.HomePage>().FirstOrDefault() ?? null;

            return new HomepageDTO()
            {
                Title = model?.Title ?? "",
                // ImageUrl=model?.Image?.Src??""
            };
        }
    }
}
