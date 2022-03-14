namespace Jobs.API.Controllers
{
   using Jobs.API.Entities;
   using Jobs.API.Models;
   using Jobs.API.Persistence;
   using Microsoft.AspNetCore.Mvc;

   [Route("api/Jobs/{id}/applications")]
   [ApiController]
   public class JobApplicationsController : ControllerBase
   {
      private readonly DevJobsContext _context;

      public JobApplicationsController(DevJobsContext context)
      {
         _context = context;
      }

      [HttpPost]
      public IActionResult Post( int id, AddJobApplicationInputModel model)
      {
         var job = _context.Jobs
            .SingleOrDefault(item => item.Id == id);

         if (job == null)
         {
            return NotFound();
         }

         var application = new JobApplication( model.ApplicantName, model.ApplicantEmail, id);

         job.Applications.Add(application);
         return NoContent();
      }
   }
}