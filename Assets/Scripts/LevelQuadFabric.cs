using System.Linq;
using UnityEngine;

namespace LevelQuads
{
    public class LevelQuadFabric : MonoBehaviour
    {
        [SerializeField] private LevelQuad _quad;

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
            Vector3 newPos = quadTransform.position;
            Bounds bounds = quadTransform.GetComponents<Collider>().First(c => !c.isTrigger).bounds;
            newPos.z += bounds.size.z;
            Instantiate(_quad, newPos, quadTransform.rotation);
        }
    }
}
