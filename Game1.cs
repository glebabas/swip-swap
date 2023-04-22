using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace swip_swap
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D texture;
        Vector2 position = Vector2.Zero;
        float speed = 5f;


        bool inverse = false;

        int frameWidth = 108;
        int frameHeight = 140;
        Point currentFrame = new Point(0, 0);
        Point spriteSize = new Point(8, 2);




        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Content.Load<Texture2D>("scottpilgrim_multiple");
        }

     
        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboardState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || keyboardState.IsKeyDown(Keys.Escape))
                Exit();
     
           

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                position.X -= speed;
             
            }

            if (keyboardState.IsKeyDown(Keys.Right)) 
            {
                position.X += speed;
              
            }
               
            if (keyboardState.IsKeyDown(Keys.Up))
                position.Y -= speed;
            if (keyboardState.IsKeyDown(Keys.Down))
                position.Y += speed;

            if (keyboardState.IsKeyDown(Keys.V))
            {
                inverse = !inverse;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(inverse ? Color.Black : Color.CornflowerBlue);


            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            spriteBatch.Draw(texture, position,
                new Rectangle(currentFrame.X * frameWidth,
                    currentFrame.Y * frameHeight,
                    frameWidth, frameHeight),
                Color.White, 0, Vector2.Zero,
                1, SpriteEffects.None, 0);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}