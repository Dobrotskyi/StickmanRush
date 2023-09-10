using System;
using System.Collections;
using UnityEngine;

namespace EnemyMechanics
{
    public class Boss : Enemy
    {
        public static event Action BossIsDead;

        protected override int EnemyDeathAnimCount => 1;

        [SerializeField] private float _speed = 3f;
        private PlayerMovement _playerMovement;

        protected override void OnEnable()
        {
            HP = GameBalance.BossHP;

            base.OnEnable();

            _playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
            _playerMovement.PlayerReadyForBoss += StartWalkingTowardsPlayer;
            transform.rotation = Quaternion.LookRotation(_playerMovement.transform.position - transform.position);
        }

        protected override void OnKilled()
        {
            base.OnKilled();
            BossIsDead?.Invoke();
            StopAllCoroutines();
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
