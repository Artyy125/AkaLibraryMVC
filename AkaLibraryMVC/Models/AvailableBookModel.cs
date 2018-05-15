using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AkaLibraryMVC.Models
{
    public class AvailableBookModel
    {
        public int? Id { get; set; }
        public int LibraryId { get; set; }
        public int BookId { get; set; }
        public int MemberId { get; set; }
    }
}