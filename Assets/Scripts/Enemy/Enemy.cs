using System;
using UnityEngine;

namespace EnemyMechanics
{
    [RequireComponent(typeof(Animator))]
    public class Enemy : MonoBehaviour
    {
        public static event Action<Vector3> EnemyKilledAtPosition;

        protected virtual int EnemyDeathAnimCount => 3;
        protected virtual int HP { set; get; } = GameConfig.EnemiesHP;
        protected Animator EnemyAnimator;

        [SerializeField] private TextMesh _hpText;
        [SerializeField] private ParticleSystem _hitMarker;

        protected virtual void OnEnable()
        {
            EnemyAnimator = GetComponent<Animator>();
            _hpText.text = HP.ToString();
            System.Random random = new System.Random();
            EnemyAnimator.Play(0, 0, (float)random.NextDouble());
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                TakeDamage();
                Instantiate(_hitMarker, collision.contacts[0].point, Quaternion.identity);
                Destroy(collision.gameObject);
            }
        }

        private void TakeDamage()
        {
            HP -= GameConfig.BasicDamage;
            _hpText.text = HP.ToString();

            if (HP <= 0)
                OnKilled();
        }

        private void OnKilled()
        {
            System.Random rand = new System.Random();
            EnemyAnimator.SetInteger("DeathNumber", rand.Next(0, EnemyDeathAnimCount));
            GetComponent<Collider>().enabled = false;
            _hpText.gameObject.SetActive(false);
            EnemyKilledAtPosition?.Invoke(transform.position);
        }
    }
}