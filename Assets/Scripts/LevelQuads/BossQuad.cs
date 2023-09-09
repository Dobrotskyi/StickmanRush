using EnemyMechanics;
using UnityEngine;

namespace LevelQuads
{
    public class BossQuad : MonoBehaviour
    {
        public Vector3 PlayerPosition => _playerPosition.position;

        [SerializeField] private Boss _boss;
        [SerializeField] private Transform _playerPosition;
        [SerializeField] private Transform _bossPlacement;

        private void OnEnable()
        {
            Instantiate(_boss, _bossPlacement.position, Quaternion.identity);
        }
    }
}
