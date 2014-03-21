using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.WindowsAzure.Management.Storage;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;


namespace AzureManagerApp
{
    internal partial class ManagementController
    {
        internal void Cleanup()
        {
            _computeManagementClient.Deployments.DeleteBySlotAsync(_parameters.CloudServiceName, DeploymentSlot.Staging, new CancellationToken());
            _computeManagementClient.HostedServices.DeleteAsync(_parameters.CloudServiceName, new CancellationToken());
            _storageManagementClient.StorageAccounts.DeleteAsync(_parameters.StorageAccountName, new CancellationToken());
        }
    }
}
