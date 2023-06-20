using System;
using System.Collections.Generic;
using System.Media;

namespace Game
{
    public class Program
    {
        public static float deltaTime;
        static DateTime lastFrameTime = DateTime.Now;

        static Character player;
        static Character ship;

        static Player jugador;

        static Collitions collitions;

        static bool gameStarted = false;
        static bool victory = false;
        static bool defeat = false;

        static float timer = 0;
        static float timeLimit = 10;





        static void Main(string[] args)
        {
            Engine.Initialize();
            player = new Character(new Vector2(100,100));
            ship = new Character(new Vector2(150,100));
            jugador = new Player(new Vector2(400, 550), 200);

            collitions = new Collitions();

            while (true)
            {
                calcDeltatime();

                Update();
                Draw();
            }
        }

        static void Update()
        {

            if (gameStarted)
            {
                if (!victory && !defeat)
                {
                    ship.AddMove(new Vector2(20 * deltaTime, 0));

                    jugador.Update();

                    /*
                    var l_bullet = BulletManager.Instance.GetBullet();
                    var l_characters = CharactersManager.Instance.GetCharacters();
                    foreach (var character in l_characters)
                    {
                        foreach (var bullet in l_bullet)
                        {
                            if (BoxToBoxCollition(character.Transf.position, new Vector2(character.RealWidth, character.RealHeight), bullet.Transf.position, new Vector2(bullet.RealWidth, bullet.RealHeight)))
                            {
                                Engine.Debug("IMPACTO A ESTRIBOR");
                                character.Kill();

                            }
                        }

                        character.Update();
                    }
                    */
                    var l_characters = CharactersManager.Instance.GetCharacters();
                    foreach (var character in l_characters)
                    {
                        character.Update();
                    }

                    collitions.Update();

                    timer += deltaTime;
                    if (timer >= timeLimit)
                    {
                        gameStarted = false;
                        defeat = true;
                    }

                }

            }
            else if (Engine.GetKey(Keys.K)) gameStarted = true;
        }

        static void Draw()
        {
            Engine.Clear();

            if (gameStarted)
            {
                
                    Engine.Draw("Playa.png", 0, 0, 1, 0.8f);

                jugador.Draw();

                foreach (var character in CharactersManager.Instance.GetCharacters())
                {
                    character.Draw();
                }
            }
            else Engine.Draw("Inicio.png", 0, 0, 1, 1, 0, 0, 0.8f);

            if (victory)
            {
                Engine.Draw("Victoria.png", 0, 0, 1, 1, 0, 0, 0.8f);
            }
            else if (defeat)
            {
                Engine.Draw("Derrota.png", 0, 0, 1, 1, 0, 0, 0.8f);
            }

            Engine.Show();
        }


        public static bool BoxToBoxCollition(Vector2 positionA, Vector2 sizeA, Vector2 positionB, Vector2 sizeB)
        {
            float distanceX = Math.Abs(positionA.x - positionB.x);
            float distanceY = Math.Abs(positionA.y - positionB.y);

            float sumHalfWidths = sizeA.x / 2 + sizeB.x / 2;
            float sumHalfHeights = sizeA.y / 2 + sizeB.y / 2;

            if (distanceX <= sumHalfWidths && distanceY <= sumHalfHeights)
            {
                return true;
            }
            return false;
        }

        static void calcDeltatime()
        {
            TimeSpan deltaSpan = DateTime.Now - lastFrameTime;
            deltaTime = (float)deltaSpan.TotalSeconds;
            lastFrameTime = DateTime.Now;
        }
    }
}