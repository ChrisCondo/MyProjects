using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;
using System.Threading.Tasks;

namespace AzureManagerApp
{
    internal partial class ManagementController
    {
        internal async Task DeployCloudService()
        {
            var storageConnectionString = await GetStorageAccountConnectionString();

            var account = CloudStorageAccount.Parse(storageConnectionString);

            var blobs = account.CreateCloudBlobClient();

            var container = blobs.GetContainerReference("deployments");

            await container.CreateIfNotExistsAsync();

            await container.SetPermissionsAsync(
                new BlobContainerPermissions()
                {
                    PublicAccess = BlobContainerPublicAccessType.Container
                });

            var blob = container.GetBlockBlobReference(
                Path.GetFileName(_parameters.PackageFilePath));

            await blob.UploadFromFileAsync(_parameters.PackageFilePath, FileMode.Open);

            await _computeManagementClient.Deployments.CreateAsync(
                _parameters.CloudServiceName,
                DeploymentSlot.Production,
                new DeploymentCreateParameters
                {
                    Label = _parameters.CloudServiceName,
                    Name = _parameters.CloudServiceName + "Prod",
                    PackageUri = blob.Uri,
                    Configuration = File.ReadAllText(_parameters.PackageFilePath),  // TODO: ConfigurationFilePath
                    StartDeployment = true
                },
                new System.Threading.CancellationToken());

        }
    }
}
