using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.Input
{
    class MouseInput
    {
        public MouseState mouseState { get; set; }
        public MouseState mouseStateOld { get; set; }
        public Vector2 Inputs()
        {
            throw new NotImplementedException();
        }

        public void MouseUpdate()
        {
            try
            {
                mouseStateOld = mouseState;
            }
            catch (Exception)
            {
            }
            mouseState = Mouse.GetState();
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
