using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Squence.Core.Interfaces;
using Squence.Core.Managers;
using Squence.Core.States;
using Squence.Entities;

namespace Squence.Core.UI
{
    internal class UIManager(GameState gameState, GraphicsDevice graphicsDevice): IDrawable
    {
        private readonly HUDPanel _hudPanel = new(gameState);
        private readonly BuildingPanel _buildingPanel = new(graphicsDevice);

        public void Draw(DrawingManager drawingManager)
        {
            _hudPanel.Draw(drawingManager);
            _buildingPanel.Draw(drawingManager);
        }
        
        public void ShowBuildingPanel(TileBuildZone tile) // TODO использовать tile для изменения состояния
        {
            _buildingPanel.Show();
        }

        public void HideBuildingPanel()
        {
            _buildingPanel.Hide();
        }

        public void TryHandleClick(MouseState mouseState)
        {
            _buildingPanel.TryHandleClick(mouseState);
        }
    }
}
