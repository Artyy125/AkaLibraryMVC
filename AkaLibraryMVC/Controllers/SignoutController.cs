using AkaLibraryMVC.Interface;
using AkaLibraryMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AkaLibraryMVC.Controllers
{
    public class SignoutController : Controller
    {
        private IAllBLogics _cm;
        public SignoutController(IAllBLogics cm)
        {
            _cm = cm;
        }
        [HttpGet]
        public async Task<ActionResult> Index(int id,int libraryId,int bookId)
        {
            AvailableBookModel model = new AvailableBookModel();
            model.Id = id;
            model.LibraryId = libraryId;
            model.BookId = bookId;
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Signout(AvailableBookModel data)
        {
            bool isMemberExist = _cm.IsMemberExist(data.MemberId);
            bool isAvailable = _cm.IsAvailable(data);
            bool isMemberExceeded = _cm.IsMemberExceeded(data);
            if (isMemberExist && isAvailable)
            {
                _cm.IncreaseSignout(data);
            }
            return RedirectToAction("List","LibraryBook",new { id=data.Id });
        }
        [HttpPost]
        public async Task<ActionResult> Return(AvailableBookModel data)
        {
            bool canReturn = _cm.CanReturn(data);
            if (canReturn)
            {
                _cm.DeacreasingSignout(data);
            }
            return RedirectToAction("List", "LibraryBook", new { id = data.Id });
        }
        public async Task<ActionResult> Return(int id, int libraryId, int bookId)
        {
            AvailableBookModel model = new AvailableBookModel();
            model.Id = id;
            model.LibraryId = libraryId;
            model.BookId = bookId;
            return View(model);
        }
    }
}