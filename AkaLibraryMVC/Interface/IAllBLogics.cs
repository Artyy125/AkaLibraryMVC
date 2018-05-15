using AkaLibraryMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkaLibraryMVC.Interface
{
    public interface IAllBLogics
    {
        bool IsMemberExist(int memberId);
        void IncreaseSignout(AvailableBookModel data);
        bool IsAvailable(AvailableBookModel data);
        bool IsMemberExceeded(AvailableBookModel data);
        bool CanReturn(AvailableBookModel data);
        void DeacreasingSignout(AvailableBookModel data);
    }
}
