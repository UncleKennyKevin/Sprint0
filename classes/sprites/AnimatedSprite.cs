namespace Sprint0;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class AnimatedSprite : ISprite
{
    private Texture2D _texture;
    private Vector2 _position;
    private int _frameWidth;
    private int _frameHeight;
    private int _frameCount;
    private int _currentFrame;
    private float _timer;
    private float _interval;
    private int _startX;
    private int _startY;

    public Vector2 Position
    {
        get => _position;
        set => _position = value;
    }

    public AnimatedSprite(Texture2D texture, Vector2 position, int frameCount, float frameDuration, Point startPos, Point frameSize)
    {
        _texture = texture;
        _position = position;
        _frameCount = frameCount;
        _frameWidth = texture.Width / frameCount;
        _frameHeight = texture.Height;
        _startX = startPos.X;
        _startY = startPos.Y;
        _frameWidth = frameSize.X;
        _frameHeight = frameSize.Y;
        _interval = frameDuration;
        _currentFrame = 0;
        _timer = 0f;
    }

    public void Update(GameTime gameTime)
    {
        _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
        if (_timer >= _interval)
        {
            _currentFrame = (_currentFrame + 1) % _frameCount;
            _timer = 0f;
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        Rectangle sourceRect = new Rectangle(_startX + (_currentFrame * _frameWidth), _startY, _frameWidth, _frameHeight);
        spriteBatch.Draw(_texture, _position, sourceRect, Color.White, 0f, Vector2.Zero, 3.0f, SpriteEffects.None, 0f);
    }
}