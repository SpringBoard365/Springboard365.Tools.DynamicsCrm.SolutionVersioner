namespace Springboard365.Tools.DynamicsCrm.SolutionVersioner
{
    using Springboard365.Tools.DynamicsCrm.Common;

    public class SolutionVersion : CrmToolBase
    {
        private ISolutionReader solutionReader;
        private ISolutionWriter solutionWriter;
        private IVersionIncrementor versionIncrementor;

        public SolutionVersion(string[] args)
            : base(new SolutionVersionCommandLineParameters(), args)
        {
        }

        public override void Initialize()
        {
            solutionReader = new SolutionReader(OrganizationService);
            solutionWriter = new SolutionWriter(OrganizationService);
            versionIncrementor = new VersionIncrementor();
        }

        public override void Run()
        {
            var parameters = (SolutionVersionCommandLineParameters)CommandLineParameterBase;

            var solutionEntity = solutionReader.GetSolutionEntity(parameters.SolutionUniqueName);

            var solutionVersion = versionIncrementor.IncrementVersion(solutionEntity["version"].ToString(), parameters.SolutionVersionPartToIncrement);

            solutionWriter.UpdateSolution(solutionEntity.Id, solutionVersion);
        }
    }
}