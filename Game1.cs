using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameLibrary;
using MonoGameLibrary.Graphics;

namespace Sprint0;

public class Game1 : Core
{

    // Defines the Mario sprite.
    private Sprite _mario;

    // Defines the mario animated sprite.
    private AnimatedSprite _marioAnimated;

    // Tracks the position of the slime.
    private Vector2 _marioPosition;

    // Speed multiplier when moving.
    private const float MOVEMENT_SPEED = 5.0f;

    public Game1() : base("Sprint0", 1280, 720, false)
    {

    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        // Load the atlas texture using the content manager
        TextureAtlas atlas = TextureAtlas.FromFile(Content, "images/atlas-definition.xml");

        // Create the slime sprite from the atlas.
        _mario = atlas.CreateSprite("mario-still");
        _mario.Scale = new Vector2(4.0f, 4.0f);
        
        // Create the slime animated sprite from the atlas.
        _marioAnimated = atlas.CreateAnimatedSprite("mario-animation");
        _marioAnimated.Scale = new Vector2(4.0f, 4.0f);


    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // Update the slime animated sprite.
        _marioAnimated.Update(gameTime);


        // Check for keyboard input and handle it.
        CheckKeyboardInput();

        // Check for gamepad input and handle it.
        CheckGamePadInput();

        base.Update(gameTime);
    }
    private void CheckKeyboardInput()
    {
        // Get the state of keyboard input
        KeyboardState keyboardState = Keyboard.GetState();

        // If the space key is held down, the movement speed increases by 1.5
        float speed = MOVEMENT_SPEED;
        if (keyboardState.IsKeyDown(Keys.Space))
        {
            speed *= 1.5f;
        }

        // If the W or Up keys are down, move the slime up on the screen.
        if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up))
        {
            _marioPosition.Y -= speed;
        }

        // if the S or Down keys are down, move the slime down on the screen.
        if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down))
        {
            _marioPosition.Y += speed;
        }

        // If the A or Left keys are down, move the slime left on the screen.
        if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
        {
            _marioPosition.X -= speed;
        }

        // If the D or Right keys are down, move the slime right on the screen.
        if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
        {
            _marioPosition.X += speed;
        }
    }

    private void CheckGamePadInput()
    {
        GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);

        // If the A button is held down, the movement speed increases by 1.5
        // and the gamepad vibrates as feedback to the player.
        float speed = MOVEMENT_SPEED;
        if (gamePadState.IsButtonDown(Buttons.A))
        {
            speed *= 1.5f;
            GamePad.SetVibration(PlayerIndex.One, 1.0f, 1.0f);
        }
        else
        {
            GamePad.SetVibration(PlayerIndex.One, 0.0f, 0.0f);
        }

        // Check thumbstick first since it has priority over which gamepad input
        // is movement.  It has priority since the thumbstick values provide a
        // more granular analog value that can be used for movement.
        if (gamePadState.ThumbSticks.Left != Vector2.Zero)
        {
            _marioPosition.X += gamePadState.ThumbSticks.Left.X * speed;
            _marioPosition.Y -= gamePadState.ThumbSticks.Left.Y * speed;
        }
        else
        {
            // If DPadUp is down, move the slime up on the screen.
            if (gamePadState.IsButtonDown(Buttons.DPadUp))
            {
                _marioPosition.Y -= speed;
            }

            // If DPadDown is down, move the slime down on the screen.
            if (gamePadState.IsButtonDown(Buttons.DPadDown))
            {
                _marioPosition.Y += speed;
            }

            // If DPapLeft is down, move the slime left on the screen.
            if (gamePadState.IsButtonDown(Buttons.DPadLeft))
            {
                _marioPosition.X -= speed;
            }

            // If DPadRight is down, move the slime right on the screen.
            if (gamePadState.IsButtonDown(Buttons.DPadRight))
            {
                _marioPosition.X += speed;
            }
        }
    }  

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // Begin the sprite batch to prepare for rendering.
        SpriteBatch.Begin(samplerState: SamplerState.PointClamp);

        // Draw the slime sprite.
        _mario.Draw(SpriteBatch, _marioPosition);

        // Draw the slime sprite.
        _marioAnimated.Draw(SpriteBatch, Vector2.One);

        // Always end the sprite batch when finished.
        SpriteBatch.End();

        base.Draw(gameTime);
    }
}
