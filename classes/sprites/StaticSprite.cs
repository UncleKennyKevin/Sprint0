// StaticSprite.cs
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Sprint0;
public class StaticSprite : ISprite
{
    private Texture2D _texture;
    private Vector2 _position;
    private Rectangle _sourceRect;

    public StaticSprite(Texture2D texture, Vector2 position, Rectangle sourceRect)
    {
        _texture = texture;
        _position = position;
        _sourceRect = sourceRect;
    }

    public void Update(GameTime gameTime) { }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, _position, _sourceRect, Color.White, 0f, Vector2.Zero, 3.0f, SpriteEffects.None, 0f);
    }
}