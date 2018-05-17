using AkaLibraryMVC.Interface;
using AkaLibraryMVC.Models;
using Elmah;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using AkaLibraryMVC.DTO;

namespace AkaLibraryMVC.Concrete
{
    public class AllBLogics : IAllBLogics
    {
        private IDbContext _db;
        public AllBLogics(IDbContext db)
        {
            _db = db;

        }
        public bool IsMemberExist(int memberId)
        {
            try
            {
                if (_db.Members.Where(r=>r.MemberId == memberId).FirstOrDefault() == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.GetDefault(null).Log(new Error(ex));
                throw;
            }
        }
        public bool IsAvailable(AvailableBookModel data)
        {
            try
            {
                var result = _db.Library_Book.Where(r => r.BookId == data.BookId && r.LibraryId == data.LibraryId).FirstOrDefault();
                bool isAvailable = result.TotalPurchasedByLibrary > (result.Signout == null ? 0 : result.Signout.Value) ? true : false;
                return isAvailable;
            }
            catch (Exception ex)
            {
                ErrorLog.GetDefault(null).Log(new Error(ex));
                throw;
            }
        }
        public bool IsMemberExceeded(AvailableBookModel data)
        {
            try
            {
                var result = _db.BookSignedOuts.Where(r => r.LibraryBookSId == data.Id && r.WhenReturned == null).ToList();
                if (result?.Count() >=2)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.GetDefault(null).Log(new Error(ex));
                throw;
            }
        }

        public bool CanReturn(AvailableBookModel data)
        {
            try
            {
                var result = _db.BookSignedOuts.Where(r => r.MemberId == data.MemberId && r.LibraryBookSId == data.Id && r.WhenReturned == null).FirstOrDefault();
                if (result == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                ErrorLog.GetDefault(null).Log(new Error(ex));
                throw;
            }
        }
        public void IncreaseSignout(AvailableBookModel data)
        {
            try
            {

                var result = _db.Library_Book.Where(r => r.LibraryBookSId == data.Id).FirstOrDefault();
                if (result != null)
                {
                    BookSignedOut info = new BookSignedOut
                    {
                        LibraryBookSId = data.Id.Value,
                        MemberId = data.MemberId,
                        WhenSignedOut = DateTime.UtcNow,
                        WhenReturned = null
                    };
                    _db.BookSignedOuts.Add(info);
                    result.Signout = result.Signout == null ? 1 : result.Signout.Value + 1;
                    _db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.GetDefault(null).Log(new Error(ex));
                throw;
            }
        }

        public void DeacreasingSignout(AvailableBookModel data)
        {
            try
            {
                var result = _db.Library_Book.Where(r => r.LibraryBookSId == data.Id).FirstOrDefault();
                var bookSignout = _db.BookSignedOuts.Where(r => r.MemberId == data.MemberId && r.LibraryBookSId == data.Id && r.WhenReturned == null).FirstOrDefault();
                if (result != null)
                {
                    bookSignout.WhenReturned = DateTime.UtcNow;
                    result.Signout = result.Signout.Value - 1;
                    _db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                ErrorLog.GetDefault(null).Log(new Error(ex));
                throw;
            }
        }
    }
}