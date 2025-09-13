namespace Sprint0;

using Microsoft.Xna.Framework;

public class QuitCommand : ICommand
{
    private Game1 _game;

    public QuitCommand(Game1 game)
    {
        _game = game;
    }

    public void Execute()
    {
        _game.Exit();
    }
}