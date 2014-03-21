using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Compute.Models;
using System;
using System.Threading.Tasks;

namespace AzureManagerApp
{
    internal partial class ManagementController
    {
        internal async Task CreateVM()
        {
            await _computeManagementClient.VirtualMachines.CreateAsync(
                "ServiceName",
                "DeploymentName",
                new VirtualMachineCreateParameters
                {
                    RoleName = "RoleName",
                    RoleSize = VirtualMachineRoleSize.ExtraSmall
                },
                new System.Threading.CancellationToken());
        }
    }
}
