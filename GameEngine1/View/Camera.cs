using GameEngine1.Input;
using GameEngine1.Interfaces;
using Microsoft.Xna.Framework;

namespace GameEngine1.View
{
    public class Camera
    {
        public Matrix Transform { get; set; }
        public float Zoom { get; set; }
        public int ScreenWidth { get; set; }
        public int ScreenHeight { get; set; }
        public Camera(int screenWidth, int screenHeight)
        {
            Zoom = 1f;
            ScreenWidth = screenWidth;
            ScreenHeight = screenHeight;
        }
        public void Update(ITransform transform, MouseInput mouse)
        {
            if (mouse.mouseState.ScrollWheelValue > mouse.mouseStateOld.ScrollWheelValue)
            {
                Zoom += 0.1f;
            }
            if (mouse.mouseState.ScrollWheelValue < mouse.mouseStateOld.ScrollWheelValue)
            {
                Zoom -= 0.1f;
            }
            if (Zoom < 0.8f)
            {
                Zoom = 0.8f;
            }
            if (Zoom > 4f)
            {
                Zoom = 4f;
            }
            Transform = Matrix.CreateTranslation(-transform.Position.X, -transform.Position.Y, 0) * Matrix.CreateScale(Zoom);
            Transform *= Matrix.CreateTranslation(ScreenWidth / 2, ScreenHeight / 2, 0);
        }
    }
}
