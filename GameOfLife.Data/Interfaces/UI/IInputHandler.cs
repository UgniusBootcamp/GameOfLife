namespace GameOfLife.Data.Interfaces.UI
{
    public interface IInputHandler
    {
        int GetInt(string message);
        string? GetString(string message);
    }
}
