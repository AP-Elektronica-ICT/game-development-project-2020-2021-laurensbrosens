using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.Input
{
    class KeyboardInput : IKeyboard
    {
        public KeyboardState keyboardState { get; set; }
        public KeyboardState keyboardStateOld { get; set; }

        public void KeyboardUpdate()
        {
            keyboardStateOld = keyboardState;
            keyboardState = Keyboard.GetState();
        }
        public bool KeyClicked(Keys key)
        {
            if (keyboardStateOld.IsKeyUp(key) && keyboardState.IsKeyDown(key))
            {
                return true;
            }
            return false;
        }
    }
}
