using System.Linq;
using UnityEngine;

namespace LevelQuads
{
    public class LevelQuadFabric : MonoBehaviour
    {
        private int _levelSectionBeforeBoss = 0;
        [SerializeField] private LevelQuad _quad;
        [SerializeField] private BossQuad _bossQuad;

        private int _spawnedSections = 0;

        private void OnEnable()
        {
            LevelQuad.PlayerPassedTrigger += SpawnNewQuad;
        }

        private void OnDisable()
        {
            LevelQuad.PlayerPassedTrigger -= SpawnNewQuad;
        }

        private void SpawnNewQuad(Transform quadTransform)
        {
            if (_spawnedSections == _levelSectionBeforeBoss)
                SpawnBossQuad(quadTransform);
            else
                SpawnBasicQuad(quadTransform);
        }

        private void SpawnBasicQuad(Transform quadTransform)
        {
            Vector3 newPos = quadTransform.position;
            Bounds bounds = quadTransform.GetComponents<Collider>().First(c => !c.isTrigger).bounds;
            newPos.z += bounds.size.z;
            Instantiate(_quad, newPos, quadTransform.rotation);
            _spawnedSections++;
        }

        private void SpawnBossQuad(Transform quadTransform)
        {
            Vector3 newPos = quadTransform.position;
            Bounds bounds = quadTransform.GetComponents<Collider>().First(c => !c.isTrigger).bounds;
            newPos.z += bounds.size.z / 2 + _bossQuad.transform.localScale.y / 2;
            Instantiate(_bossQuad, newPos, quadTransform.rotation);
        }
    }
}
