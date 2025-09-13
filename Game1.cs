using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace Sprint0;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public ISprite currentSprite;
    public ISprite marioStill;
    public ISprite marioRunning;

    public ISprite marioMovingStill;
    public ISprite marioMovingRunning;

    private IController keyboardController;
    private IController mouseController;

    private TextSprite message;

    private int marioX = 300;
    private int marioY = 180;
    private SpriteFont font;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content/images";
        IsMouseVisible = true;
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        Texture2D marioTexture = Content.Load<Texture2D>("mario");


        Rectangle firstMario = new Rectangle(203, 48, 32, 38);

        marioStill = new StaticSprite(marioTexture, new Vector2(marioX, marioY), firstMario);

        marioMovingStill = new MovingSprite(marioTexture, new Vector2(marioX, marioY), firstMario, new Vector2(0, 2));


        marioRunning = new AnimatedSprite(marioTexture, new Vector2(marioX, marioY), 4, 0.2f, new Point(203, 48), new Point(30, 38));

        marioMovingRunning = new MovingAnimatedSprite((AnimatedSprite)marioRunning, new Vector2(marioX, marioY), new Vector2(2, 0));

        currentSprite = marioStill;


        font = Content.Load<SpriteFont>("Arial");
        message = new TextSprite(font, "Credits\nProgram Made By: Kevin Roback\nSprites from: https://www.mariouniverse.com/wp-content/img/sprites/nes/smb/mario.png", new Vector2(300, 300), Color.Black);

        keyboardController = new KeyboardController(this);
        mouseController = new MouseController(this);
    }

    public void SetCurrentSprite(ISprite sprite)
    {
        currentSprite = sprite;
    }

    protected override void Update(GameTime gameTime)
    {
        keyboardController.Update();
        mouseController.Update();
        currentSprite.Update(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();
        currentSprite.Draw(_spriteBatch);
        message.Draw(_spriteBatch);
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
