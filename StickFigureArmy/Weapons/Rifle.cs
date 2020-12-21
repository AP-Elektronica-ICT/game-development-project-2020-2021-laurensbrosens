using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using StickFigureArmy.Animations;
using StickFigureArmy.Input;
using StickFigureArmy.Interfaces;
using StickFigureArmy.Physics;
using StickFigureArmy.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.Weapons
{
    class Rifle : ITransform, IDraw, IAnimate
    {
        public Vector2 Position { get; set; }
        public Texture2D texture2D { get; set; }
        public List<Animation> animations { get; set; }
        private const int Width = 64; //FrameWidth
        private const int Height = 64; //FrameHeight
        private BulletInput bulletInput;
        private bool shot = false; //Nodig voor animatie te starten
        public Rifle(Texture2D texture, MouseInput mouse)
        {
            animations = new List<Animation>();
            animations.Add(Animation.Create(0, 0, Width, Height, 3, "Shoot1", 10f));
            animations.Add(Animation.Create(0, Height, Width, Height, 3, "Shoot2", 10f));
            animations.Add(Animation.Create(0, Height * 2, Width, Height, 3, "Shoot3", 10f));
            animations.Add(Animation.Create(0, Height * 3, Width, Height, 1, "idleRight", 5f));
            texture2D = texture;
            bulletInput = new BulletInput(mouse, this);
        }
        public void Shoot(List<Bullet> bullets, List<ICollisionRectangle> collidableObjects)
        {
            shot = true;
            foreach (Bullet bullet in bullets)
            {
                if (!bullet.Alive)
                {
                    bullet.Alive = true;
                    bullet.HP = 1;
                    bullet.Position = Position;
                    bullet.Direction = bulletInput; //Nog berekenen met muispositie en positie rifle
                    //bullet.texture2D = ... rode textures voor enemies?
                    return;
                }
            }
            bullets.Add(new Bullet(collidableObjects, ));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            shot = false; //Zodat 1 keer per schot animatie wordt gestart
            throw new NotImplementedException();
        }
    }
}
