namespace Springboard365.Tools.DynamicsCrm.SolutionVersioner
{
    using System;
    using Microsoft.Xrm.Sdk;
    using Springboard365.Tools.CommandLine.Core;

    public class SolutionWriter : ISolutionWriter
    {
        private readonly IOrganizationService organizationService;

        public SolutionWriter(IOrganizationService organizationService)
        {
            this.organizationService = organizationService;
        }

        public void UpdateSolution(Guid solutionId, string solutionVersion)
        {
            var toUpdate = new Entity("solution")
            {
                Id = solutionId,
            };
            toUpdate["version"] = solutionVersion;

            ConsoleLogger.LogMessage($"Updating solution start with id '{solutionId}' with version '{solutionVersion}'");
            organizationService.Update(toUpdate);
            ConsoleLogger.LogMessage("Updating solution end.");
        }
    }
}