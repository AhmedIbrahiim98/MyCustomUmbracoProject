using MyCustomUmbracoProject.Models;

namespace MyCustomUmbracoProject.Interfaces
{
    public interface IContentService
    {
        GenericResult<HomepageDTO> GetHomeContent();
    }
}
