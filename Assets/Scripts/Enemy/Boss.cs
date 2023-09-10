using System.Collections;
using UnityEngine;

namespace EnemyMechanics
{
    public class Boss : Enemy
    {
        protected override int EnemyDeathAnimCount => 1;
        protected override int HP { set; get; } = GameConfig.BossHP;

        [SerializeField] private float _speed = 3f;
        private PlayerMovement _playerMovement;

        protected override void OnEnable()
        {
            base.OnEnable();

            _playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
            _playerMovement.PlayerReadyForBoss += StartWalkingTowardsPlayer;
            transform.rotation = Quaternion.LookRotation(_playerMovement.transform.position - transform.position);
        }

        private void OnDisable()
        {
            _playerMovement.PlayerReadyForBoss -= StartWalkingTowardsPlayer;
        }

        private void StartWalkingTowardsPlayer()
        {
            transform.rotation = Quaternion.LookRotation(_playerMovement.transform.position - transform.position);
            StartCoroutine(WalkingTowardsPlayer());
        }

        private IEnumerator WalkingTowardsPlayer()
        {
            Vector3 playerPositon = _playerMovement.transform.position;
            EnemyAnimator.SetTrigger("WalkTowards");
            yield return new WaitForFixedUpdate();
            while (true)
            {
                transform.Translate((transform.position - playerPositon).normalized * _speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, playerPositon) <= 1.3f)
                {
                    EnemyAnimator.SetTrigger("Kick");
                    break;
                }
                yield return new WaitForFixedUpdate();
            }
        }
    }
}
