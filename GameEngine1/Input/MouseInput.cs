using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using GameEngine1.Art;
using GameEngine1.Collisions;
using GameEngine1.GameLogic;
using GameEngine1.GameObjects;
using GameEngine1.Interfaces;
using GameEngine1.View;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameEngine1.Input
{
    public class MouseInput : IMouseInput
    {
        public MouseState mouseState { get; set; }
        public MouseState mouseStateOld { get; set; }
        public Vector2 Position { get; set; }

        public void MouseUpdate(Camera camera)
        {
            mouseStateOld = mouseState;
            mouseState = Mouse.GetState();
            Vector2 worldPosition = new Vector2(mouseState.X, mouseState.Y);
            Position = Vector2.Transform(worldPosition, Matrix.Invert(camera.Transform));
        }

        public bool LeftKeyClicked()
        {
            if (mouseStateOld.LeftButton == ButtonState.Released && mouseState.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }
        public bool RightKeyClicked()
        {
            if (mouseStateOld.RightButton == ButtonState.Released && mouseState.RightButton == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }
    }
}
