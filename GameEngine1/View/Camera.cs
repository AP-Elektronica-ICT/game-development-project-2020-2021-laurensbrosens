using GameEngine1.Input;
using GameEngine1.Interfaces;
using Microsoft.Xna.Framework;

namespace GameEngine1.View
{
    public class Camera
    {
        public Matrix Transform { get; set; }
        public float Zoom { get; set; }
        public Camera()
        {
            Zoom = 1f;
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
            if (Zoom < 1f)
            {
                Zoom = 1f;
            }
            if (Zoom > 3f)
            {
                Zoom = 3f;
            }
            Transform = Matrix.CreateTranslation(-transform.Position.X, -transform.Position.Y, 0) * Matrix.CreateScale(Zoom);
            Transform *= Matrix.CreateTranslation(Game1.ScreenWidth / 2, Game1.ScreenHeight / 2, 0);
        }
        public void Zooming(float zoomAmount)
        {
            Zoom += zoomAmount;
            if (Zoom < .3f)
            {
                Zoom = .3f;
            }
            if (Zoom > 1.5f)
            {
                Zoom = 1.5f;
            }
        }
    }
}
