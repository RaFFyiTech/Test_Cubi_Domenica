using UnityEngine;

public class EnemyCube : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -5f)
        {
            Debug.Log("Cubo eliminato! +1 Punto!");
            
            Destroy(gameObject);
        }
    }
}