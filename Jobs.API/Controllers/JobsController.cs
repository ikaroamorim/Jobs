namespace Jobs.API.Controllers
{
   using Jobs.API.Entities;
   using Jobs.API.Models;
   using Jobs.API.Persistence;
   using Microsoft.AspNetCore.Mvc;

   [Route("api/[controller]")]
   [ApiController]
   public class JobsController : ControllerBase
   {
      private readonly DevJobsContext _context;

      public JobsController(DevJobsContext context)
      {
         _context = context;

      }

      [HttpGet]
      public IActionResult GetAll()
      {
         var jobs = _context.Jobs;
         return Ok(jobs);
      }

      [HttpGet("{id}")]
      public IActionResult GetById(int id)
      {
         var job = _context.Jobs
            .SingleOrDefault(item => item.Id == id);

         if (job == null)
         {
            return NotFound();
         }
         return Ok(job);
      }

      [HttpPost]
      public IActionResult Post(AddJobInputModel model)
      {
         var job = new Job(model.Title, model.Description, model.Company, model.IsRemote, model.SalaryRange);

         _context.Jobs.Add(job);

         return CreatedAtAction("GetById", new { id = job.Id }, job);
      }

      [HttpPut("{id}")]
      public IActionResult Put(int id, UpdateJobInputModel model)
      {
         var job = _context.Jobs
            .SingleOrDefault(item => item.Id == id);

         if (job == null)
         {
            return NotFound();
         }

         job.UpdateJob( model.Title, model.Description);

         return NoContent();
      }
   }
}