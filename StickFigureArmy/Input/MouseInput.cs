using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using StickFigureArmy.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.Input
{
    public class MouseInput
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
