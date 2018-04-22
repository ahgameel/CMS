using System.Collections.Generic;
using LookTechnoCMS.Data.Infrastructure;
using LookTechnoCMS.Data;
namespace LookTechnoCMS.Service.ContactusService
{
    public interface IContactUsService : IEntityService<Contatctu>
    {
        Contatctu GetById(int id);
        IEnumerable<Contatctu> GetContactMessages();
    }
}
