using System;
using System.Collections.Generic;
using System.Media;

namespace Game
{
    public class Program
    {
        //variables deltatime
        public static float deltaTime;
        static DateTime lastFrameTime = DateTime.Now;

        //private Transform transform;

        //static float _posY = 305;      /
        //static float _posX = 305;      /Todo esto es para la bala
        //static float _speed = 100;     /
        

        //static float _rot = 0;

        static Character player;
        static Character ship;
        //static Character secShip;

        static Player jugador;

        //static List<Bullet> bullets = new List<Bullet>();

        static Animation currentAnimation = null;
        static Animation idle;

        //static Texture cannon = Engine.GetTexture("Cannon.png");

        //private float RealHeight => cannon.Height * transform.scale.y;


        static void Main(string[] args)
        {
            Engine.Initialize();
            player = new Character(new Vector2(100,100));
            ship = new Character(new Vector2(150,100));
            jugador = new Player(new Vector2(400, 550), 200);
            //secShip = new Character(new Vector2(400, 100));
           
            idle = CreateAnimation();
            currentAnimation = idle;



            SoundPlayer myplayer = new SoundPlayer("Sounds/XP.wav");
            //myplayer.PlayLooping();

            while (true)
            {
                calcDeltatime();

                Update();
                Draw();
            }
        }

        static void Update()
        {
            ship.AddMove(new Vector2(20 * deltaTime, 0));

            //Engine.Debug($"{RealHeight}");
            
            //Engine.Debug(jugador);

            /*
            if (Engine.GetKey(Keys.SPACE))
            {
               player.AddMove(new Vector2(10 * deltaTime, 10 * deltaTime));
            }
            */

            jugador.Update();


            /*
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update();
            }
            */

            var l_characters = CharactersManager.Instance.GetCharacters();
            foreach (var character in l_characters)
            {
                for (int i = 0; i < l_characters.Count; i++)
                {
                    if(character != l_characters[i])
                        if (character.IsBoxColliding(l_characters[i]))
                        {
                            Engine.Debug("ESTOY COLISIONANDO");
                        }
                }

                character.Update();
            }

            //currentAnimation.Update();
            //ship.Update();
            //pp.Update();
        }

        static void Draw()
        {
            Engine.Clear();
        
            Engine.Draw("Playa.png", 0, 0, 1, 0.8f);

            jugador.Draw();
            
            foreach (var character in CharactersManager.Instance.GetCharacters())
            {
                character.Draw();
            }
           
            /*
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].Draw)
                {
                    bullets.RemoveAt(i);
                }
            }

            
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].DrawBullet();
            }
            */

            Engine.Show();
        }

        static void calcDeltatime()
        {
            TimeSpan deltaSpan = DateTime.Now - lastFrameTime;
            deltaTime = (float)deltaSpan.TotalSeconds;
            lastFrameTime = DateTime.Now;
        }

        /*  ESTO DISPARA UNA BALA
        static void Shoot()
        {
            bullets.Add(new Bullet(_posX + 230, _posY + 60, _rot));
        }
        */

        private static Animation CreateAnimation()
        {
            // Idle Animation
            List<Texture> idleFrames = new List<Texture>();

            for (int i = 0; i < 4; i++)
            {
                idleFrames.Add(Engine.GetTexture($"{i}.png"));
            }

            Animation idleAnimation = new Animation("Idle", idleFrames, 2, true);

            return idleAnimation;
        }
    }
}