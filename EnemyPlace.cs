using UnityEngine;

public class EnemyPlace : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.GetComponent<Enemy>())
        {
            Destroy(other.gameObject);
        }
    }
}