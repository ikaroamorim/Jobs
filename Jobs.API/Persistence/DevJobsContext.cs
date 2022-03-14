using Jobs.API.Entities;

namespace Jobs.API.Persistence
{
   public class DevJobsContext
   {
      public DevJobsContext()
      {
         Jobs = new List<Job>();
      }

      public List<Job> Jobs { get; set; }
   }
}