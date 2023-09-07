using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private TextMesh _hpText;
    [SerializeField] private ParticleSystem _hitMarker;
    private float HP = GameConfig.EnemiesHP;

    private void OnEnable()
    {
        _hpText.text = HP.ToString();
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
