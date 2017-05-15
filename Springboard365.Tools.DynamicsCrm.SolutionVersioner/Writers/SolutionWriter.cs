namespace Springboard365.Tools.DynamicsCrm.SolutionVersioner
{
    using System;
    using log4net;
    using Microsoft.Xrm.Sdk;

    public class SolutionWriter : ISolutionWriter
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(SolutionWriter));
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
                ["version"] = solutionVersion
            };

            logger.InfoFormat("Updating solution start with id '{0}' with version '{1}'", solutionId, solutionVersion);
            organizationService.Update(toUpdate);
            logger.InfoFormat("Updating solution end.");
        }
    }
}