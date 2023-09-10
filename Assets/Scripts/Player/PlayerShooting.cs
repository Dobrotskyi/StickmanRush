using EnemyMechanics;
using System.Collections;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private float _shotForce = 100f;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _bulletSpawnPoint;

    private PlayerMovement _playerMovement;


    private void OnEnable()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _playerMovement.PlayerMovingAtPosition += StopAllCoroutines;
        _playerMovement.PlayerReadyForBoss += StartShooting;
        PlayerMovement.PlayerLost += StopAllCoroutines;
        Boss.BossIsDead += StopAllCoroutines;
        GameStarter.Start += StartShooting;
    }

    private void OnDisable()
    {
        _playerMovement.PlayerMovingAtPosition -= StopAllCoroutines;
        _playerMovement.PlayerReadyForBoss -= StartShooting;
        PlayerMovement.PlayerLost -= StopAllCoroutines;
        Boss.BossIsDead -= StopAllCoroutines;
        GameStarter.Start -= StartShooting;
    }

    private void StartShooting() => StartCoroutine(Shoot());

    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(0.1f);
        while (true)
        {
            GameObject bullet = Instantiate(_bulletPrefab, _bulletSpawnPoint.position, _bulletSpawnPoint.transform.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(bullet.transform.forward * _shotForce, ForceMode.VelocityChange);
            Destroy(bullet, GameBalance.BulletTimeOfLifeInSec);
            yield return new WaitForSeconds(GameBalance.FireRate);
        }
    }
}
