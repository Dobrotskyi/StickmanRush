using System;
using UnityEngine;

namespace LevelQuads
{
    public class LevelQuad : MonoBehaviour
    {
        public static event Action<Transform> PlayerPassedTrigger;

        private const float DESTROY_AFTER_SECONDS = 2f;
        private bool _passedFirstTrigger = false;

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (!_passedFirstTrigger)
                {
                    PlayerPassedTrigger?.Invoke(transform);
                    _passedFirstTrigger = true;
                }
                else
                    Destroy(gameObject, DESTROY_AFTER_SECONDS);
            }
        }
    }
}
