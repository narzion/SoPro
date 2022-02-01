using Entity;
using Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IBookmarkService
    {
        BookmarkVM CreateBookmark(BookmarkVM bookmark);
        List<BookmarkVM> GetBookmarks();
        BookmarkVM GetBookmark(int Id);
        void UpdateBookmark(BookmarkVM bookmark);
        void DeleteBookmark(int id);
    }
}
