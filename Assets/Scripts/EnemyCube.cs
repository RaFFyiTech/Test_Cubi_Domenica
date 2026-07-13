using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Soglia di altezza: se il ring è a Y = 0, a -5 sono sicuramente caduti nel vuoto
    private float fallThreshold = -5f; 
    private bool pointGiven = false; // Evita che assegni punti multipli mentre cade

    void Update()
    {
        // Se il cubo scende sotto la soglia e non ha ancora dato punti...
        if (transform.position.y < fallThreshold && !pointGiven)
        {
            pointGiven = true; // Blocchiamo subito per sicurezza

            // 1. CHIAMIAMO IL GAMEMANAGER E AGGIUNGIAMO 10 PUNTI!
            if (GameManager.instance != null)
            {
                GameManager.instance.AddPoint(10);
            }

            // 2. DISTRUGGIAMO IL CUBO VERDE PER SEMPRE
            Destroy(gameObject);
        }
    }
}