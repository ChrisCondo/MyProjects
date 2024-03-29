﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureManagerApp
{
    internal class ManagementControllerParamters
    {
        internal string Region { get; set; }
        internal string StorageAccountName { get; set; }
        internal string CloudServiceName { get; set; }
        internal string PackageFilePath { get; set; }
        public string SubscriptionId { get; set; }
        public string Base64EncodedCertificate { get; set; }
    }
}
