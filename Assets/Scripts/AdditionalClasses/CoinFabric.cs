using UnityEngine;

public class CoinFabric : MonoBehaviour
{
    [SerializeField] private Coin _coin;

    private void OnEnable()
    {
        Enemy.EnemyKilledAtPosition += SpawnCoinAtPostion;
    }

    private void OnDisable()
    {
        Enemy.EnemyKilledAtPosition -= SpawnCoinAtPostion;
    }

    private void SpawnCoinAtPostion(Vector3 position)
    {
        Instantiate(_coin, position, Quaternion.identity);
    }
}
