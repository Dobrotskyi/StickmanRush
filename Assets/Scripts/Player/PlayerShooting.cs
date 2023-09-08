using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private float _shotForce = 100f;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPoint;

    private bool _isShooting;

    private void Update()
    {
        if (!_isShooting)
            if (Input.GetMouseButtonDown(1))
            {
                _isShooting = true;
                StartCoroutine(Shoot());
            }
    }

    private IEnumerator Shoot()
    {
        while (true)
        {
            GameObject bullet = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, _bulletSpawnPoint.transform.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(bullet.transform.forward * _shotForce, ForceMode.VelocityChange);
            Destroy(bullet, GameConfig.BulletTimeOfLifeInSec);
            yield return new WaitForSeconds(GameConfig.BasicFireRate);
        }
    }
}
