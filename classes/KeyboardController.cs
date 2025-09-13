using Microsoft.Xna.Framework.Input;

namespace Sprint0;

public class KeyboardController : IController
{
    private Game1 _game;

    public KeyboardController(Game1 game)
    {
        _game = game;
    }

    public void Update()
    {
        KeyboardState state = Keyboard.GetState();

        if (state.IsKeyDown(Keys.D0))
        {
            new QuitCommand(_game).Execute();
        }
        else if (state.IsKeyDown(Keys.D1))
        {
            new SetSpriteCommand(_game, _game.marioStill).Execute();
        }
        else if (state.IsKeyDown(Keys.D2))
        {
            new SetSpriteCommand(_game, _game.marioRunning).Execute();
        }
        else if (state.IsKeyDown(Keys.D3))
        {
            new SetSpriteCommand(_game, _game.marioMovingStill).Execute();
        }
        else if (state.IsKeyDown(Keys.D4))
        {
            new SetSpriteCommand(_game, _game.marioMovingRunning).Execute();
        }
    }
    }
