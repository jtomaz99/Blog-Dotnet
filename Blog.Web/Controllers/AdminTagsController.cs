using Blog.Web.Data;
using Blog.Web.Models.Domain;
using Blog.Web.Models.ViewModels;
using Blog.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly ITagRepository _tagRepository;
        public AdminTagsController(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> AddTag(AddTagRequest addTagRequest) 
        {
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName,
            };

            await _tagRepository.AddAsync(tag);

            return RedirectToAction("List");
        }

        [HttpGet]
        [ActionName("List")]
        public async Task<IActionResult> List()
        {
            var tags = await _tagRepository.GetAllAsync();
            return View(tags);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id) 
        {
            var tag = await _tagRepository.GetAsync(Id);

            if (tag != null)
            {
                var editTagRequest = new EditTagRequest
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    DisplayName = tag.DisplayName,
                };

                return View(editTagRequest);
            }

            return View(null);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(EditTagRequest editTagRequest) 
        {
            var tag = new Tag
            {
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName = editTagRequest.DisplayName
            };

            var result = await _tagRepository.UpdateAsync(tag);

            if (result != null) 
            {

            }
            else
            {

            }

            return RedirectToAction("List", new { id = editTagRequest.Id });
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Delete(EditTagRequest editTagRequest) 
        {
            var result = await _tagRepository.DeleteAsync(editTagRequest.Id);

            if (result != null)
            {
                return RedirectToAction("List");
            }

            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }
    }
}
