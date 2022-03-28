using UnityEngine;
using Zenject;

namespace GamePlay.Elements.Player
{
    public interface IPlayerObstacleDetector
    {
    }

    public class PlayerObstacleDetector : MonoBehaviour, IPlayerObstacleDetector
    {
        [Inject] private IDamageable _damageable;


        private void OnTriggerEnter2D(Collider2D other)
        {
          
            _damageable.OnDeath?.Invoke();
        }
    }
}