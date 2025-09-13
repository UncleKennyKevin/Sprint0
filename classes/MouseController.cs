using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Sprint0;

public class MouseController : IController
{
    private Game1 _game;

    public MouseController(Game1 game)
    {
        _game = game;
    }

    public void Update()
    {
        MouseState mouse = Mouse.GetState();
        int width = _game.GraphicsDevice.Viewport.Width;
        int height = _game.GraphicsDevice.Viewport.Height;

        if (mouse.LeftButton == ButtonState.Pressed)
        {
            if (mouse.X < width / 2 && mouse.Y < height / 2)
            {
                new SetSpriteCommand(_game, _game.marioStill).Execute();
            }
            else if (mouse.X >= width / 2 && mouse.Y < height / 2)
            {
                new SetSpriteCommand(_game, _game.marioRunning).Execute();
            }
            else if (mouse.X < width / 2 && mouse.Y >= height / 2)
            {
                new SetSpriteCommand(_game, _game.marioMovingStill).Execute();
            }
            else if (mouse.X >= width / 2 && mouse.Y >= height / 2)
            {
                new SetSpriteCommand(_game, _game.marioMovingRunning).Execute();
            }
        }

        if (mouse.RightButton == ButtonState.Pressed)
        {
            new QuitCommand(_game).Execute();
        }
    }
}