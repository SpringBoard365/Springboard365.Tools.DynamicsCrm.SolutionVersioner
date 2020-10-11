namespace Springboard365.Tools.DynamicsCrm.SolutionVersioner
{
    public interface IFileWriter
    {
        void WriteVersionNumberToFile(string versionNumber, string fileName);
    }
}