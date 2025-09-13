using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0
{
    public class TextSprite : ISprite
    {
        private SpriteFont font;
        private string text;
        private Vector2 position;
        private Color color;

        public TextSprite(SpriteFont font, string text, Vector2 position, Color color)
        {
            this.font = font;
            this.text = text;
            this.position = position;
            this.color = color;
        }

        public void SetText(string newText)
        {
            text = newText;
        }

        public void SetPosition(Vector2 newPosition)
        {
            position = newPosition;
        }

        public void SetColor(Color newColor)
        {
            color = newColor;
        }

        public void Update(GameTime gameTime)
        {
            // If you want text to animate, blink, etc., add logic here
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, position, color);
        }
    }
}