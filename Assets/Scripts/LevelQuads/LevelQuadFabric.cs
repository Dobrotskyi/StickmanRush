using UnityEngine;

namespace LevelQuads
{
    public class LevelQuadFabric : MonoBehaviour
    {
        private int _levelSectionBeforeBoss = 0;
        [SerializeField] private LevelQuad _basicQuad;
        [SerializeField] private BossQuad _bossQuad;

        private int _spawnedSections = 0;

        private void OnEnable()
        {
            LevelQuad.PlayerPassedTrigger += SpawnNewQuad;
            _levelSectionBeforeBoss = Random.Range(2, 3);
        }

        private void OnDisable()
        {
            LevelQuad.PlayerPassedTrigger -= SpawnNewQuad;
        }

        private void SpawnNewQuad(Transform quadTransform)
        {
            if (_spawnedSections == _levelSectionBeforeBoss)
                SpawnLevelQuad(quadTransform, _bossQuad.gameObject);
            else
                SpawnLevelQuad(quadTransform, _basicQuad.gameObject);
        }

        private void SpawnLevelQuad(Transform quadTransform, GameObject newQuad)
        {
            Vector3 newPos = quadTransform.position;
            newPos.z += quadTransform.localScale.y / 2 + newQuad.transform.localScale.y / 2;
            Instantiate(newQuad, newPos, quadTransform.rotation);
            _spawnedSections++;
        }
    }
}
