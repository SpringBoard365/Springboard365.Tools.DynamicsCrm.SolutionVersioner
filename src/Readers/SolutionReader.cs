namespace Springboard365.Tools.DynamicsCrm.SolutionVersioner
{
    using System;
    using System.Linq;
    using Microsoft.Xrm.Sdk;
    using Microsoft.Xrm.Sdk.Query;

    public class SolutionReader : ISolutionReader
    {
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
                Criteria = new FilterExpression(),
            };
            querySolution.Criteria.AddCondition("uniquename", ConditionOperator.Equal, solutionUniqueName);

            Console.WriteLine("Retrieve solution entity start.");
            var solutionEntity = organizationService.RetrieveMultiple(querySolution).Entities.First();
            Console.WriteLine("Retrieve solution entity end.");

            return solutionEntity;
        }
    }
}