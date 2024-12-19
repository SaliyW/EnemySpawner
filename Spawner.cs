using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;
    [SerializeField] private float _delay;

    private Coroutine _coroutine;

    private void Start()
    {
        _coroutine = StartCoroutine(ActivateRandomSpawnPoint(_delay));
    }

    private IEnumerator ActivateRandomSpawnPoint(float delay)
    {
        WaitForSecondsRealtime wait = new (delay);

        while (true)
        {
            _spawnPoints[Random.Range(0, _spawnPoints.Count)].Spawn();

            yield return wait;
        }
    }
}