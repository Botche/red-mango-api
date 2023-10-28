namespace RedMangoAPI.Services
{
    public interface IBlobService
    {
        Task<string> Get(string blobName, string containerName);
        Task<string> Delete(string blobName, string containerName);
        Task<string> Upload(string blobName, string containerName, IFormFile imageFile);
    }
}
