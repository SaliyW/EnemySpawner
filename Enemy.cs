using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed;

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            Destroy(gameObject);
        }
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    CHANGED
}