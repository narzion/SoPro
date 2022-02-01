using AutoMapper;
using Entity;
using Entity.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadLater5.Controllers
{
    public class BookmarksController : Controller
    {

        private readonly IBookmarkService _bookmarkService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public BookmarksController(IBookmarkService bookmarkService, ICategoryService categoryService, IMapper mapper)
        {
            _bookmarkService = bookmarkService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // POST: Bookmark/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create(BookmarkVM bookmark)
        {
            if (ModelState.IsValid)
            {
                _bookmarkService.CreateBookmark(bookmark);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        // GET: Bookmark/Create
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public IActionResult Create()
        {
            var categories = _categoryService.GetCategories();
            var bookmarkVM = new BookmarkVM();
            var mappedCategories = _mapper.Map<List<CategoryVM>>(categories);
            bookmarkVM.Categories = mappedCategories;
            return View(bookmarkVM);
        }

        // GET: Bookmark/Delete/5
        [HttpGet, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _bookmarkService.DeleteBookmark(id);
            return RedirectToAction("Index");
        }

        // GET: Bookmarks
        public IActionResult Index()
        {
            List<BookmarkVM> model = _bookmarkService.GetBookmarks();
            return View(model);
        }

        // GET: Bookmarks/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest);
            }
            BookmarkVM bookmark = _bookmarkService.GetBookmark((int)id);
            if (bookmark == null)
            {
                return new StatusCodeResult(Microsoft.AspNetCore.Http.StatusCodes.Status404NotFound);
            }
            return View(bookmark);
        }

        // POST: Bookmarks/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BookmarkVM bookmark)
        {
            if (ModelState.IsValid)
            {
                _bookmarkService.UpdateBookmark(bookmark);
                return RedirectToAction("Index");
            }
            return View(bookmark);
        }

        // GET: Bookmark/Edit
        [HttpGet]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit(int? id)
        {
            var categories = _categoryService.GetCategories();
            var bookmarkVM = _bookmarkService.GetBookmark((int)id);
            var mappedCategories = _mapper.Map<List<CategoryVM>>(categories);
            bookmarkVM.Categories = mappedCategories;
            return View(bookmarkVM);
        }
    }
}
