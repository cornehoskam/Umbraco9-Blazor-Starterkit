using System.Threading.Tasks;
using Umbraco9.Core.Models.Pages;

namespace Umbraco9.Core.Services
{
    public interface IContentDeliveryService
    {
        Task<HomepageModel> GetHomePage();
        Task<T> GetPageOfType<T>(string urlSegment) where T : class;
    }
}
