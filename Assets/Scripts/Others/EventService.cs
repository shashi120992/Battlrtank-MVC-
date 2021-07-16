using System;

namespace Others
{
    public class EventService : GenericSingleton<EventService>
    {
        public event Action OnEnemyDeath;
        public event Action OnPlayerFiredBullet;


        public void InvokeOnPlayerFiredBulletEvent()
        {
            OnPlayerFiredBullet?.Invoke();
        }
        public void InvokeEnemyKilledEvent()
        {
            OnEnemyDeath?.Invoke();
        }

    }
}