

using Microsoft.AspNetCore.Mvc;

public class BuggyController : ApiBaseController
{

    [HttpGet("not-found")]
    public ActionResult GetNotFound()
    {
        return NotFound();
    }

    [HttpGet("bad-request")]
    public ActionResult GetBadRequest()
    {

    var validationDetails = new ValidationProblemDetails
    {
        Title = "Validation failed",
        Status = StatusCodes.Status400BadRequest,
        Detail = "One or more validation errors occurred."
    };
        return BadRequest(new ProblemDetails{Title ="This is a bad request"});
    }

    [HttpGet("unauthorised")]
    public ActionResult GetUnauthorised()
    {
        return Unauthorized();
    }

    [HttpGet("validation-error")]
    public ActionResult GetValidationError()
    {
       ModelState.AddModelError("Problem1","This is problem1");
       ModelState.AddModelError("Problem2","This is problem2");

       return ValidationProblem();
    }

    [HttpGet("server-error")]
    public ActionResult GerServerError()
    {
        throw new Exception("Server Error");
    }
}