namespace Springboard365.Tools.DynamicsCrm.SolutionVersioner
{
    public interface IVersionIncrementor
    {
        string IncrementVersion(string currentSolutionVersion, string solutionVersionPartToIncrement);
    }
}