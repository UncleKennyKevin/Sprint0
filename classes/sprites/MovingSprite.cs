using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0;

public class MovingSprite : ISprite
{
    private Texture2D _texture;
    private Vector2 _position;
    private Vector2 _moveSpd;
    private Rectangle _sourceRect;

    public MovingSprite(Texture2D texture, Vector2 startPos, Rectangle sourceRect, Vector2 moveSpd)
    {
        _texture = texture;
        _position = startPos;
        _sourceRect = sourceRect;
        _moveSpd = moveSpd;
    }

    public void Update(GameTime gameTime)
    {
        _position += _moveSpd;

        //Wrap vertically
        if (_position.Y > 480) _position.Y = 0;
        if (_position.Y < 0) _position.Y = 480;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, _position, _sourceRect, Color.White, 0f, Vector2.Zero, 3.0f, SpriteEffects.None, 0f);
    }
}