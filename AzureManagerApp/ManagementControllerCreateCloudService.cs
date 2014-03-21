using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;
using System;
using System.Threading.Tasks;

namespace AzureManagerApp
{
    internal partial class ManagementController
    {
        internal async Task CreateCloudService()
        {
            await _computeManagementClient.HostedServices.CreateAsync(
                new HostedServiceCreateParameters
                {
                    Location = _parameters.Region,
                    ServiceName = _parameters.CloudServiceName
                },
                new System.Threading.CancellationToken());
        }
    }
}
