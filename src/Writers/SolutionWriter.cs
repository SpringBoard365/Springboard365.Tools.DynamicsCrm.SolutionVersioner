namespace Springboard365.Tools.DynamicsCrm.SolutionVersioner
{
    using System;
    using Microsoft.Xrm.Sdk;

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

            Console.WriteLine("Updating solution start with id '{0}' with version '{1}'", solutionId, solutionVersion);
            organizationService.Update(toUpdate);
            Console.WriteLine("Updating solution end.");
        }
    }
}