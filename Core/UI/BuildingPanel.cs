using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Squence.Core.Managers;
using Squence.Core.States;

namespace Squence.Core.UI
{
    internal class BuildingPanel : Interfaces.IDrawable
    {
        private readonly GraphicsDevice _graphicsDevice;
        private readonly BuildingPanelState _buildingState = new();

        private readonly Vector2 _iconFirePosition;
        private readonly Vector2 _iconLightningPosition;
        private readonly Vector2 _iconIcePosition;
        private readonly int _iconSize = 80;

        public BuildingPanel(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;

            var windowWidth = _graphicsDevice.PresentationParameters.BackBufferWidth;
            var windowHeight = _graphicsDevice.PresentationParameters.BackBufferHeight;
            _iconFirePosition = new Vector2(windowWidth - 300, windowHeight - 150);
            _iconLightningPosition = new Vector2(windowWidth - 200, windowHeight - 150);
            _iconIcePosition = new Vector2(windowWidth - 100, windowHeight - 150);
        }

        public void Draw(DrawingManager drawingManager)
        {
            if (_buildingState.IsVisible)
            {
                drawingManager.DrawIcon(_iconFirePosition, _iconSize, "Content/Icons/fire_icon.png");
                drawingManager.DrawIcon(_iconLightningPosition, _iconSize, "Content/Icons/lightning_icon.png");
                drawingManager.DrawIcon(_iconIcePosition, _iconSize, "Content/Icons/ice_icon.png");
            }
        }

        public void Show()
        {
            _buildingState.Show();
        }

        public void Hide()
        {
            _buildingState.Hide();
        }

        public void TryHandleClick(MouseState mouseState)
        {

        }

        private bool IsClicked(MouseState mouseState, Vector2 componentPosition, int componentWidth, int componentHeight)
        {
            Vector2 mousePosition = new(mouseState.X, mouseState.Y);
            Rectangle componentBorders = new Rectangle(
                        (int)componentPosition.X,
                        (int)componentPosition.Y,
                        componentWidth,
                        componentHeight
                        );

            return componentBorders.Contains(mousePosition);
        }
    }
}
