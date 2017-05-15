namespace Springboard365.Tools.DynamicsCrm.SolutionVersioner
{
    using Microsoft.Xrm.Sdk;

    public interface ISolutionReader
    {
        Entity GetSolutionEntity(string solutionUniqueName);
    }
}