using EnemyMechanics;
using UnityEngine;

namespace LevelQuads
{
    public class BossQuad : MonoBehaviour
    {
        [SerializeField] private Boss _boss;

        private void OnEnable()
        {
            Instantiate(_boss, transform.position, Quaternion.identity);
        }
    }
}
