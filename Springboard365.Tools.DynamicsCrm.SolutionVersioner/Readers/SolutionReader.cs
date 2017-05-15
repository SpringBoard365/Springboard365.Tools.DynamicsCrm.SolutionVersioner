namespace Springboard365.Tools.DynamicsCrm.SolutionVersioner
{
    using System.Linq;
    using log4net;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;

    public class SolutionReader : ISolutionReader
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(SolutionReader));
        private readonly IOrganizationService organizationService;

        public SolutionReader(IOrganizationService organizationService)
        {
            this.organizationService = organizationService;
        }

        public Entity GetSolutionEntity(string solutionUniqueName)
        {
            var querySolution = new QueryExpression
            {
                EntityName = "solution",
                ColumnSet = new ColumnSet("version"),
                Criteria = new FilterExpression()
            };
            querySolution.Criteria.AddCondition("uniquename", ConditionOperator.Equal, solutionUniqueName);

            logger.Info("Retrieve solution entity start.");
            var solutionEntity = organizationService.RetrieveMultiple(querySolution).Entities.First();
            logger.Info("Retrieve solution entity end.");

            return solutionEntity;
        }
    }
}