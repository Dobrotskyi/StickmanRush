using UnityEngine;

namespace EnemyMechanics
{
    public class EnemyCleaner : MonoBehaviour
    {
        private const float DISTANCE_BEHIND_PLAYER = -5f;

        private Transform _playerTransform;

        private void OnEnable()
        {
            _playerTransform = GameObject.FindWithTag("Player").transform;
        }

        private void FixedUpdate()
        {
            if (transform.position.z - _playerTransform.position.z < DISTANCE_BEHIND_PLAYER)
                Destroy(gameObject);
        }
    }
}
