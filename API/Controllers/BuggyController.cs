using API.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly DataContext _context;
        public BuggyController(DataContext context)
        {
            _context = context;

        }

        [HttpGet("testAuth")]
        [Authorize]
        public ActionResult<string> GetSecureContent()
        {
            return "You are logged in, so are able to view this content";
        }

        // [HttpGet("notfound")]
        // public ActionResult GetNotFoundRequest()
        // {
        //     var item = _context.Products.Find(42);

        //     if(item == null){
        //         return NotFound(new ApiResponse(404));
        //     }

        //     return Ok();
        // }

        // [HttpGet("servererror")]
        // public ActionResult GetServerError()
        // {
        //     var item = _context.Products.Find(42);

        //     var returnItem = item.ToString();

        //     return Ok();
        // }
        
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(400));
        }
        
        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok();
        }
    }
}