using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace RedMangoAPI.Services
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient blobServiceClient;

        public BlobService(BlobServiceClient blobServiceClient)
        {
            this.blobServiceClient = blobServiceClient;
        }

        public async Task<bool> Delete(string blobName, string containerName)
        {
            BlobClient blobClient = GetBlobClient(blobName, containerName);

            return await blobClient.DeleteIfExistsAsync();
        }

        public string Get(string blobName, string containerName)
        {
            BlobClient blobClient = GetBlobClient(blobName, containerName);

            return blobClient.Uri.AbsoluteUri;
        }

        public async Task<string> Upload(string blobName, string containerName, IFormFile imageFile)
        {
            BlobClient blobClient = GetBlobClient(blobName, containerName);
            var httpHeaders = new BlobHttpHeaders()
            {
                ContentType = imageFile.ContentType,
            };
            var result = await blobClient.UploadAsync(imageFile.OpenReadStream(), httpHeaders);
            if (result == null)
            {
                return string.Empty;
            }

            return this.Get(blobName, containerName);
        }

        private BlobClient GetBlobClient(string blobName, string containerName)
        {
            var blobContainerClient = this.blobServiceClient.GetBlobContainerClient(containerName);
            var blobClient = blobContainerClient.GetBlobClient(blobName);

            return blobClient;
        }
    }
}
