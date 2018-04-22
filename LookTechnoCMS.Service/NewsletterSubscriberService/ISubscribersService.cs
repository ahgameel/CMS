using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LookTechnoCMS.Data;
using LookTechnoCMS.Data.Infrastructure;

namespace LookTechnoCMS.Service.NewsletterSubscriberService
{
    public interface ISubscribersService:IEntityService<NewsletterSubscriber>
    {
        IEnumerable<NewsletterSubscriber> GetSubscribers();
    }
}
