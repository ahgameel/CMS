using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LookTechnoCMS.Data;
using LookTechnoCMS.Data.Infrastructure;

namespace LookTechnoCMS.Service.NewsletterSubscriberService
{
    public class SubscribersService:EntityService<NewsletterSubscriber>,ISubscribersService
    {
         readonly LookTechno _context;

         public SubscribersService(LookTechno context)
            : base(context)
        {
            _context = context;
            Dbset = _context.Set<NewsletterSubscriber>();

        }

        public IEnumerable<NewsletterSubscriber> GetSubscribers()
        {
            var subscribers = (from s in _context.NewsletterSubscribers

                        select new
                        {
                            s.Id,
                            s.Email,

                           s.DateCreated


                        }).OrderByDescending(x => x.DateCreated).AsEnumerable().Select(x => new NewsletterSubscriber
                        {
                            Id = x.Id,
                           Email = x.Email,
                           DateCreated = x.DateCreated


                        }).ToList();





            return subscribers.ToList();
        }
    }
}
