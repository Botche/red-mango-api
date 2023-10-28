namespace RedMangoAPI.Services
{
    public class BlobService : IBlobService
    {
        public Task<string> Delete(string blobName, string containerName)
        {
            throw new NotImplementedException();
        }

        public Task<string> Get(string blobName, string containerName)
        {
            throw new NotImplementedException();
        }

        public Task<string> Upload(string blobName, string containerName, IFormFile imageFile)
        {
            throw new NotImplementedException();
        }
    }
}
