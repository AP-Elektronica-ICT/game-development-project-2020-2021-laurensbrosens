using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace StickFigureArmy.Input
{
    public interface IKeyboard
    {
        public KeyboardState keyboardState { get; set; }
        public KeyboardState keyboardStateOld { get; set; }
        public void KeyboardUpdate();
        bool KeyClicked(Keys key);
    }
}
