namespace Sprint0;

public class SetSpriteCommand : ICommand
{
    private Game1 _game;
    private ISprite _sprite;

    public SetSpriteCommand(Game1 game, ISprite sprite)
    {
        _game = game;
        _sprite = sprite;
    }

    public void Execute()
    {
        _game.SetCurrentSprite(_sprite);
    }
}