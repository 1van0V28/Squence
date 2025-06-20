namespace Squence.Core.States
{
    internal class GameState
    {
        public int HealthPoints { get; private set; } = 3;
        public int MoneyCount { get; private set; } = 0;

        public void HandleEnemyBreakthrough()
        {
            HealthPoints--;
        }

        public void HandleCoinCollection()
        {
            MoneyCount++;
        }
    }
}
