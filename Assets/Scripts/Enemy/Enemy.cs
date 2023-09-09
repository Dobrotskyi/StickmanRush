using System;
using UnityEngine;

namespace EnemyMechanics
{
    public class Enemy : MonoBehaviour
    {
        private const int ENEMY_DEATH_ANIM_COUNT = 3;

        public static event Action<Vector3> EnemyKilledAtPosition;

        [SerializeField] private TextMesh _hpText;
        [SerializeField] private ParticleSystem _hitMarker;
        private Animator _animator;
        private float HP = GameConfig.EnemiesHP;

        private void OnEnable()
        {
            _animator = GetComponent<Animator>();
            _hpText.text = HP.ToString();
            System.Random random = new System.Random();
            _animator.Play(0, 0, (float)random.NextDouble());
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
            _animator.SetInteger("DeathNumber", rand.Next(0, ENEMY_DEATH_ANIM_COUNT));
            GetComponent<Collider>().enabled = false;
            _hpText.gameObject.SetActive(false);
            EnemyKilledAtPosition?.Invoke(transform.position);
        }
    }
}