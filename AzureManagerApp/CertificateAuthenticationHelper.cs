using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using Microsoft.WindowsAzure;

namespace AzureManagerApp
{
    internal class CertificateAuthenticationHelper
    {
        internal static SubscriptionCloudCredentials GetCredentials(
            string subscriptionId,
            string base64EncodedCert)
        {
            return new CertificateCloudCredentials(subscriptionId,
                new X509Certificate2(Convert.FromBase64String(base64EncodedCert)));
        }
    }
}
