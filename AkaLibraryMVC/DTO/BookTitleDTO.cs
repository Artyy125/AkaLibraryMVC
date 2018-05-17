using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AkaLibraryMVC.DTO
{
    public class BookTitleDTO
    {
        public string Title { get; set; }

        public string ISBN { get; set; }

        public DateTime? DateOfPublication { get; set; }
        public ICollection<LibraryBookDTO> Library_Book { get; set; }

    }
}