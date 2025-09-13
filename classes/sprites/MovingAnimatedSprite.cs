using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0;

public class MovingAnimatedSprite : ISprite
{
    private AnimatedSprite _movingAnimated;
    private Vector2 _position;
    private Vector2 _moveSpd;

    public MovingAnimatedSprite(AnimatedSprite movingAnimated, Vector2 startPos, Vector2 moveSpd)
    {
        _movingAnimated = movingAnimated;
        _position = startPos;
        _moveSpd = moveSpd;
    }

    public void Update(GameTime gameTime)
    {
        _movingAnimated.Update(gameTime);
        _position += _moveSpd;

        //Wrap horizontally
        if (_position.X > 800) _position.X = 0;
        if (_position.X < 0) _position.X = 800;

        _movingAnimated.Position = _position;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        _movingAnimated.Draw(spriteBatch);
    }
}