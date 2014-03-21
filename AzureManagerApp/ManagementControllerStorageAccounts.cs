using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Management.Storage.Models;
using System;
using System.Threading.Tasks;

namespace AzureManagerApp
{
    internal partial class ManagementController
    {
        internal async Task CreateStorageAccount()
        {
            await _storageManagementClient.StorageAccounts.CreateAsync(
                new StorageAccountCreateParameters
                {
                    Location = _parameters.Region,
                    Name = _parameters.StorageAccountName
                } , 
                new System.Threading.CancellationToken());  // CancellationToken required to compile
        }
    }
}
