using Microsoft.VisualStudio.Setup.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.VisualStudio.Setup.Samples
{
    public static class CloneConfiguration
    {
        public static string InstanceConfiguration { get => GetConfiguration(); }

        private static List<string> GetPackages(ISetupPackageReference[] packages, string packageType)
        {
            var packageIds = new List<string>();

            var filteredPackages = from package in packages
                            where string.Equals(package.GetType(), packageType, StringComparison.OrdinalIgnoreCase)
                            orderby package.GetId()
                            select package;

            foreach (var package in filteredPackages)
            {
                packageIds.Add(package.GetId());
            }

            return packageIds;
        }


        private static string GetConfiguration()
        {
            var instance = GetInstance();
            var instance2 = (ISetupInstance2)instance;
            var state = instance2.GetState();
            var installString = new StringBuilder();

            // Confusingly, while modify, uninstall, update are commands, the install command is specified 
            // by leaving the command parameter blank
            installString.Append("vs_enterprise.exe ");

            var installPath = instance.GetInstallationPath();
            installString.Append($"--installPath \"{installPath}\" ");

            if ((state & InstanceState.Registered) == InstanceState.Registered)
            {
                
                var workloads = GetPackages(instance2.GetPackages(), "Workload");
                foreach (var workload in workloads)
                {
                    installString.Append($"--add {workload} ");
                }

                var components = GetPackages(instance2.GetPackages(), "Component");
                foreach (var component in components)
                {
                    installString.Append($"--add {component} ");
                }

                return installString.ToString();

            }
            else
            {
                throw new ApplicationException("Instance is not registered.");
            }
        }

        private static ISetupInstance GetInstance()
        {
            var configString = new StringBuilder();

            var configuration = new SetupConfiguration();
            var allInstances = configuration.EnumAllInstances();
            var setupInstance = new ISetupInstance[1];

            // TODO: select an instance if there are several rather than just grabbing the first one
            allInstances.Next(1, setupInstance, out int instancesFetched);

            if (instancesFetched != 1)
            {
                throw new ApplicationException("Can't find a Visual Studio instance on this machine.");
            }
            else
            { 
                return setupInstance[0];
            }
        }
    }
}