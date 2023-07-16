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
        static Character ship2;

        static Bote bote;

        static Player jugador;

        static Collitions collitions;
        static GameManager gameManager;

        static IDisparable disparable;

        static bool gameStarted = false;
        static bool defeat = false;

        static void Main(string[] args)
        {
            Engine.Initialize();
            player = new Character("bote", new Vector2(100, 100), true);
            ship = new Character("bote", new Vector2(150, 150), false);
            ship2 = new Character("bote", new Vector2(400, 210), true);
            bote = new Bote("bote", new Vector2(600, 50), false);
            disparable = player;

            jugador = new Player("cannon", new Vector2(400, 550), 200);
            jugador.OnLifeChanged += (life) => Defeat(life);


            gameManager = new GameManager();
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
                if (!gameManager.Victory && !defeat)
                {
                    gameManager.Update();
                    jugador.Update();

                    var l_characters = CharactersManager.Instance.GetCharacters();
                    foreach (var character in l_characters)
                    {
                        character.Update();
                    }
                    collitions.Update();
                }

            }
            else if (Engine.GetKey(Keys.I)) gameStarted = true;
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

                foreach (var bullet in BulletManager.Instance.GetBullet())
                {
                    bullet.Draw();
                }
            }
            else Engine.Draw("Inicio2.png", 0, 0, 1, 1, 0, 0, 0.8f);

            if (gameManager.Victory)
            {
                Engine.Draw("Victoria2.png", 0, 0, 1, 1, 0, 0, 0.8f);
            }
            else if (defeat)
            {
                Engine.Draw("Derrota2.png", 0, 0, 1, 1, 0, 0, 0.8f);
            }

            Engine.Show();
        }

        static void Defeat(int p_life)
        {
            if (p_life <= 0)
            {
                defeat = true;
            }
        }

        static void calcDeltatime()
        {
            TimeSpan deltaSpan = DateTime.Now - lastFrameTime;
            deltaTime = (float)deltaSpan.TotalSeconds;
            lastFrameTime = DateTime.Now;
        }
    }
}