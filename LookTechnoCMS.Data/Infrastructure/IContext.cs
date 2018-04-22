using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LookTechnoCMS.Data.Infrastructure
{
    public interface IContext
    {
        DbSet<Brand> Brands { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<HomeSlider> HomeSliders { get; set; }
        DbSet<Page> Pages { get; set; }
        DbSet<Menu> Menus { get; set; }
        DbSet<Cell> Cells { get; set; }

        DbSet<CellSetting> CellSettings { get; set; }

        DbSet<Contatctu> Contatctus { get; set; }
        DbSet<GeneralSetting> GeneralSettings { get; set; }
        DbSet<NewsletterSubscriber> NewsletterSubscribers { get; set; }
        DbSet<OurService> OurServices { get; set; }
        DbSet<OurSolution> OurSolutions { get; set; }

        DbSet<Product> Products { get; set; }
        DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        DbSet<AspNetRole> AspNetRoles { get; set; }
        DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        //DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        DbSet<AspNetUser> AspNetUsers { get; set; }
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }
}
