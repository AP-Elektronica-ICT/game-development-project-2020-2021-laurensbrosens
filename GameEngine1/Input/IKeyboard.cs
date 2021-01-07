using Microsoft.Xna.Framework.Input;

namespace GameEngine1.Input
{
    public interface IKeyboard
    {
        public KeyboardState keyboardState { get; set; }
        public KeyboardState keyboardStateOld { get; set; }
        public void KeyboardUpdate();
        bool KeyClicked(Keys key);
    }
}
