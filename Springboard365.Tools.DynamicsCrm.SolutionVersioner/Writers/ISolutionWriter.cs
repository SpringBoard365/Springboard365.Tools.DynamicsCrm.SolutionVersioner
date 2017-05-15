namespace Springboard365.Tools.DynamicsCrm.SolutionVersioner
{
    using System;

    public interface ISolutionWriter
    {
        void UpdateSolution(Guid solutionEntityId, string solutionVersion);
    }
}