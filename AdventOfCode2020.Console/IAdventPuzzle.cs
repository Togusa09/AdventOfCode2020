namespace AdventOfCode2020.App
{
    public interface IAdventPuzzle<T>
    {
        T Solve(string fileContent);
        T SolveForFile();
    }
}