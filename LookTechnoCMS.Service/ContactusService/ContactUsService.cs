using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;


using LookTechnoCMS.Data;
using LookTechnoCMS.Data.Infrastructure;

namespace LookTechnoCMS.Service.ContactusService
{
    public class ContactUsService : EntityService<Contatctu>,IContactUsService
    {
        readonly LookTechno _context;

        public ContactUsService(LookTechno context)
            : base(context)
        {
            _context = context;
            Dbset = _context.Set<Contatctu>();

        }

        public Contatctu GetById(int id)
        {
            return Dbset.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Contatctu> GetContactMessages()
        {
            var ContactMessages = (from c in _context.Contatctus

                        select new
                        {
                            c.Id,
                            c.Name,
                            c.Email,
                            c.Subject,
                            c.Message,
                            c.DateCreated


                        }).OrderByDescending(x => x.DateCreated).AsEnumerable().Select(x => new Contatctu
                        {
                            Id = x.Id,
                            Name = x.Name,
                            Email=x.Email,
                            Subject=x.Subject,
                            Message=x.Message,
                            DateCreated=x.DateCreated


                        }).ToList();





            return ContactMessages.ToList();
        }
    }
}
