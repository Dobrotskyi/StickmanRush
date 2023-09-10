using System;
using UnityEngine;

namespace EnemyMechanics
{
    [RequireComponent(typeof(Animator))]
    public class Enemy : MonoBehaviour
    {
        public static event Action<Vector3> EnemyKilledAtPosition;
        public static event Action PlayerGotKicked;

        protected virtual int EnemyDeathAnimCount => 3;
        protected int HP { set; get; } = GameBalance.EnemyHP;
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
            else if (collision.gameObject.CompareTag("Player"))
                PlayerGotKicked?.Invoke();
        }

        private void TakeDamage()
        {
            HP -= GameBalance.Damage;
            _hpText.text = HP.ToString();

            if (HP <= 0)
                OnKilled();
        }

        protected virtual void OnKilled()
        {
            System.Random rand = new System.Random();
            EnemyAnimator.SetInteger("DeathNumber", rand.Next(0, EnemyDeathAnimCount));
            GetComponent<Collider>().enabled = false;
            _hpText.gameObject.SetActive(false);
            EnemyKilledAtPosition?.Invoke(transform.position);
        }

        private void PlayerKickedAnimEvent()
        {
            PlayerGotKicked?.Invoke();
        }
    }
}