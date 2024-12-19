using UnityEngine;
using UnityEngine.Pool;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Color _enemyColor;
    [SerializeField] private float _enemySpeed = 1;

    private ObjectPool<GameObject> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<GameObject>(
        createFunc: () => Instantiate(_enemyPrefab.gameObject, transform.position, Quaternion.identity),
        actionOnGet: (obj) => ActionOnGet(obj),
        actionOnRelease: (obj) => obj.SetActive(false),
        actionOnDestroy: (obj) => Destroy(obj));
    }

    public void Spawn()
    {
        _pool.Get();
    }

    private void ActionOnGet(GameObject obj)
    {
        obj.GetComponent<Renderer>().material.color = _enemyColor;
        obj.transform.position = transform.position;
        obj.transform.Rotate(0, GetRandomAngle(), 0);
        obj.GetComponent<Enemy>().SetSpeed(_enemySpeed);
        obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
        obj.SetActive(true);
    }

    private float GetRandomAngle()
    {
        float fullTurn = 360;

        return Random.Range(0, fullTurn);
    }
}