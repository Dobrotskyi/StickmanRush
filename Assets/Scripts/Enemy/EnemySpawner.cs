using UnityEngine;
using Helper;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _yOffset = 1.5f;

    private void Awake()
    {
        SpawnEnemies();
    }

    public void SpawnEnemies()
    {
        int i = 1;
        Quaternion enemyRotation = Quaternion.Euler(0, 180, 0);
        Vector3 newSpawnPos = transform.position;
        System.Random rand = new System.Random();
        while (true)
        {
            newSpawnPos.z += i * GameConfig.EnemySpawnFrequency;
            newSpawnPos.x = Utility.RandomFloatInRange(rand, -_yOffset, _yOffset);

            GameObject newObject = new("Enemy");
            newObject.transform.position = newSpawnPos;
            newObject.transform.rotation = enemyRotation;

            if (ProperEnemyPlacement(newObject.transform))
            {
                Transform enemyTransform = Instantiate(_enemyPrefab, newObject.transform).transform;
                enemyTransform.position = new Vector3(enemyTransform.position.x, 0, enemyTransform.position.z);
            }
            else
            {
                Destroy(newObject);
                break;
            }
        }
    }

    private bool ProperEnemyPlacement(Transform placement)
    {
        Ray ray = new Ray(placement.position, -placement.up);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
            if (hit.collider.gameObject.CompareTag("Level"))
                return true;

        return false;
    }
}
