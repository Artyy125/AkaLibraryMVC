using AkaLibraryMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkaLibraryMVC.Interface
{
    public interface IDbContext
    {
        DbSet<BookSignedOut> BookSignedOuts { get; set; }
        DbSet<BookTitle> BookTitles { get; set; }
        DbSet<Library> Libraries { get; set; }
        DbSet<Library_Book> Library_Book { get; set; }
        DbSet<Member> Members { get; set; }
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
