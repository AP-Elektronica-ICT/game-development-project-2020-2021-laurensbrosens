using Microsoft.Xna.Framework.Input;

namespace GameEngine1.Input
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
