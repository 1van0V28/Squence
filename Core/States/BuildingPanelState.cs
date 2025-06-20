namespace Squence.Core.States
{
    internal class BuildingPanelState
    {
        public bool IsVisible { get; private set; } = false;

        public void Show()
        {
            IsVisible = true;
        }

        public void Hide()
        {
            IsVisible = false;
        }
    }
}
