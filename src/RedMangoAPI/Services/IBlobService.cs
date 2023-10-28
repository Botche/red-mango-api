namespace RedMangoAPI.Services
{
    public interface IBlobService
    {
        string Get(string blobName, string containerName);
        Task<bool> Delete(string blobName, string containerName);
        Task<string> Upload(string blobName, string containerName, IFormFile imageFile);
    }
}
