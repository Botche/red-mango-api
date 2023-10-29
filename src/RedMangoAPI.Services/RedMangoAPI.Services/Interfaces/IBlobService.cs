namespace RedMangoAPI.Services.Interfaces
{
    using Microsoft.AspNetCore.Http;

    public interface IBlobService
    {
        string Get(string blobName, string containerName);
        Task<bool> Delete(string blobName, string containerName);
        Task<string> Upload(string blobName, string containerName, IFormFile imageFile);
    }
}
