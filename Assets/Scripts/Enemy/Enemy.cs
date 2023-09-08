using UnityEngine;

public class Enemy : MonoBehaviour
{
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

    private void TakeDamage()
    {
        HP -= GameConfig.BasicDamage;
        _hpText.text = HP.ToString();

        if (HP <= 0)
            OnKilled();
    }

    private void OnKilled()
    {
        Destroy(gameObject);
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
}
