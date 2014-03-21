using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.WindowsAzure.Management.Storage;

namespace AzureManagerApp
{
    internal partial class ManagementController
    {
        private async Task<string> GetStorageAccountConnectionString()
        {
            var keys = await
                _storageManagementClient.StorageAccounts.GetKeysAsync(_parameters.StorageAccountName, new CancellationToken());

            string connectionString = string.Format(
                CultureInfo.InstalledUICulture,
                "defaultEndpointsProtocol=http;AccountName={0}; AccountKey={1}",
                _parameters.StorageAccountName, keys.SecondaryKey);

            return connectionString;
        }
    }
}
