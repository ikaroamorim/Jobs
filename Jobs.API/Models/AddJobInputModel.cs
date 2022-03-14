namespace Jobs.API.Models
{
    public record AddJobInputModel( string Title, string Description, string Company, bool IsRemote, string SalaryRange)
    {
        
    }
}