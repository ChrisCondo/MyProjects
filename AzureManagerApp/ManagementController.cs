using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Management.Compute;
using Microsoft.WindowsAzure.Management.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureManagerApp
{
    internal partial class ManagementController: IDisposable
    {
        private StorageManagementClient _storageManagementClient;
        private ManagementControllerParamters _parameters;
        private ComputeManagementClient _computeManagementClient;

        internal ManagementController(ManagementControllerParamters parameters)
        {
            _parameters = parameters;

            var credential = CertificateAuthenticationHelper.GetCredentials(
                parameters.SubscriptionId,
                parameters.Base64EncodedCertificate);

            _storageManagementClient = CloudContext.Clients.CreateStorageManagementClient(credential);
            _computeManagementClient = CloudContext.Clients.CreateComputeManagementClient(credential);
        }

        public void Dispose()
        {
            if (_storageManagementClient != null) _storageManagementClient.Dispose();
            if (_computeManagementClient != null) _computeManagementClient.Dispose(); 
        }
    }
}
