using System;
using System.Collections.Generic;
using System.Media;

namespace Game
{
    public class Program
    {
        public static float deltaTime;
        static DateTime lastFrameTime = DateTime.Now;

        //static Collitions collitions;

        static Character player;
        static Character ship;

        static Player jugador;

        //static Collitions collitions;

        static Animation currentAnimation = null;
        static Animation idle;

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
            
           
            idle = CreateAnimation();
            currentAnimation = idle;



            //SoundPlayer myplayer = new SoundPlayer("Sounds/XP.wav");
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

            if (gameStarted)
            {
                if (!victory && !defeat)
                {
                    ship.AddMove(new Vector2(20 * deltaTime, 0));

                    jugador.Update();

                    var l_characters = CharactersManager.Instance.GetCharacters();
                    foreach (var character in l_characters)
                    {
                        character.Update();
                    }


                        timer += deltaTime;
                    if (timer >= timeLimit)
                    {
                        gameStarted = false;
                        defeat = true;
                    }

                }
                
            }
            else if (Engine.GetKey(Keys.K)) gameStarted = true;

            

           

            //var l_boxCollider = BoxColliderManager.Instance.GetCollider();
            //Engine.Debug(l_boxCollider.Count);

            //var l_circleCollider = CircleColliderManager.Instance.GetCollider();
            //Engine.Debug(l_circleCollider.Count);

            //var l_boxCollider = BoxColliderManager.Instance.GetCollider();
            //var l_circleCollider = CircleColliderManager.Instance.GetCollider();
            /*
            foreach (var boxCollider in l_boxCollider)
            {
                /*
                foreach (var circleCollider in l_circleCollider)
                {
                
                    for (int i = 0; i < l_circleCollider.Count; i++)
                    {
                        if (CircleToBoxCollition(boxCollider, l_circleCollider[i]))
                        {
                            Engine.Debug("ESTOY COLICIONANDO");
                        }
                    }
                //}

            }
            */

            /*
            foreach (var boxCollider in l_boxCollider)
            {
                for (int i = 0; i < l_boxCollider.Count; i++)
                {
                    if (boxCollider != l_boxCollider[i])
                        if (BoxToBoxCollition(boxCollider, l_boxCollider[i]))
                        {
                            Engine.Debug("ESTOY COLISIONANDO");
                        }
                }
            }
            */
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

        /*
        bool CircleToBoxCollition(BoxCollider box, CircleCollider circle)
        {
            float px = circle._position.x;
            if (circle._position.x < box._position.x) px = box._position.x;
            else if (circle._position.x > box._position.x + box._dimentions.x / 2) px = box._position.x + box._dimentions.x / 2;

            float py = circle._position.y;
            if (circle._position.y < box._position.y) px = box._position.y;
            else if (circle._position.y > box._position.y + box._dimentions.y / 2) px = box._position.y + box._dimentions.y / 2;

            float distanceX = circle._position.x - px;
            float distanceY = circle._position.y - py;

            float distance = (float)Math.Sqrt(distanceX * distanceX + distanceY * distanceY);

            if (distance <= circle._radio)
            {
                return true;
            }
            return false;
            //Engine.Debug(distance);
        }
        */

        public bool BoxToBoxCollition(BoxCollider p_objA, BoxCollider p_objB)
        {
            float distanceX = Math.Abs(p_objA._position.x - p_objB._position.x);
            float distanceY = Math.Abs(p_objA._position.y - p_objB._position.y);

            float sumHalfWidths = p_objA._dimentions.x / 2 + p_objB._dimentions.x / 2;
            float sumHalfHeights = p_objA._dimentions.y / 2 + p_objB._dimentions.y / 2;

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