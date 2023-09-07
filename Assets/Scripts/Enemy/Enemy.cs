using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float HP = GameConfig.EnemiesHP;

    private void TakeDamage()
    {
        HP -= GameConfig.BasicDamage;
        Debug.Log(HP);
        if (HP <= 0)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage();
            Destroy(collision.gameObject);
        }
    }
}
