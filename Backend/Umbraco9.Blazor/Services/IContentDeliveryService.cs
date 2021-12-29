using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Umbraco9.Core.Models.Pages;

namespace Umbraco9.Blazor.Services
{
    public interface IContentDeliveryService
    {
        public Task<T> GetPageOfType<T>(string urlSegment);
    }
}
