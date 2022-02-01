using AutoMapper;
using Data;
using Entity;
using Entity.Repository;
using Entity.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookmarkService : IBookmarkService
    {
        private readonly IBookmarkRepository _bookmarkRepository;
        private readonly IMapper _mapper;
        public BookmarkService(IBookmarkRepository bookmarkRepository, IMapper mapper) 
        {
            _bookmarkRepository = bookmarkRepository;
            _mapper = mapper;
        }
        public BookmarkVM CreateBookmark(BookmarkVM bookmarkVm)
        {
            var mapped = _mapper.Map<Bookmark>(bookmarkVm);
            var bookmark = _bookmarkRepository.CreateBookmark(mapped);
            return _mapper.Map<BookmarkVM>(bookmark);
        }

        public void DeleteBookmark(int id)
        {
             _bookmarkRepository.DeleteBookmark(id);
            return;
        }

        public BookmarkVM GetBookmark(int Id)
        {
          var bookmark =  _bookmarkRepository.GetBookmark(Id);
          return _mapper.Map<BookmarkVM>(bookmark);   
        }

        public List<BookmarkVM> GetBookmarks()
        {
            var bookmarks = _bookmarkRepository.GetBookmarks();
            return _mapper.Map<List<BookmarkVM>>(bookmarks);
        }

        public void UpdateBookmark(BookmarkVM bookmarkVm)
        {
            var mapped = _mapper.Map<Bookmark>(bookmarkVm);
            _bookmarkRepository.UpdateBookmark(mapped);
            return;
        }
    }
}
