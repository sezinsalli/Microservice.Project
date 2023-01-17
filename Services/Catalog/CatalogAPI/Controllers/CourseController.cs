using CatalogAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.ControllerBases;
using System.Threading.Tasks;

namespace CatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : CustomBaseController
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        public async Task<IActionResult> GetAll()
        {
            var response= await _courseService.GetAllAsync();
            return CreateActionResultInstance(response);
        }
        public async Task<IActionResult> GetById(string id)
        {
            var response=await _courseService.GetByIdAsync(id);
            return CreateActionResultInstance(response);
        }

    }
}
