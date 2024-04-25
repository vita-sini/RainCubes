using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _timeBetweenSpawn;
    [SerializeField] private Transform[] _spawnPoints;

    private ObjectPool<GameObject> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<GameObject>(
        createFunc: () => Instantiate(_prefab),
        actionOnGet: (prefab) => ActionOnGet(prefab),
        actionOnRelease: (prefab) => prefab.SetActive(false));
    }

    private void ActionOnGet(GameObject prefab)
    {
        int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
        _spawnPoints[spawnPointNumber].transform.position = new Vector3(Random.Range(5.0f, 15.0f), Random.Range(5.0f, 15.0f), Random.Range(5.0f, 15.0f));
        prefab.transform.position = _spawnPoints[spawnPointNumber].transform.position;
        prefab.GetComponent<Rigidbody>().velocity = Vector3.zero;
        prefab.SetActive(true);

        
    }
    private void Start()
    {
        InvokeRepeating(nameof(GetCube), 0.0f, _timeBetweenSpawn);
    }

    private void GetCube()
    {
        _pool.Get();
    }
}
