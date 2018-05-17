using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AkaLibraryMVC.DTO
{
    public class LibraryBookDTO
    {
        public int LibraryBookSId { get; set; }

        public int LibraryId { get; set; }

        public int BookId { get; set; }

        public int TotalPurchasedByLibrary { get; set; }

        public int? Signout { get; set; }

        public BookTitleDTO BookTitle { get; set; }
    }
}