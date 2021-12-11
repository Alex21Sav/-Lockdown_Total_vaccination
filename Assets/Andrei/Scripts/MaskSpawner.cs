using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _maskPrefab;
    private readonly int _maxSpawnCoordinate=13;
    private readonly int _startedMaskAmount=4;
    private Vector3 _spawnCoordinate;

    private void Start()
    {
        for (int i = 0; i < _startedMaskAmount; i++)
        {
            MaskSpawn();
        }
    }

    public void MaskSpawn()
    {
        float xSpawn = Random.Range(-_maxSpawnCoordinate, _maxSpawnCoordinate);
        float ySpawn = Random.Range(-_maxSpawnCoordinate, _maxSpawnCoordinate);
        _spawnCoordinate = new Vector3(xSpawn, 1, ySpawn);
        GameObject maskPrefab = Instantiate(_maskPrefab, _spawnCoordinate, Quaternion.Euler(90, 0, 0));
    }
}
