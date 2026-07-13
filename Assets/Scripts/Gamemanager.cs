using UnityEngine;
using TMPro; // Serve per parlare con TextMeshPro!

public class GameManager : MonoBehaviour
{
    // Creiamo un'istanza "statica" così tutti gli altri script (es. i cubi)
    // possono chiamare il GameManager facilmente senza fare giri assurdi
    public static GameManager instance;

    public TextMeshProUGUI scoreText; // Trascineremo qui il testo della UI
    private int score = 0;

    void Awake()
    {
        // Configura l'istanza unica
        if (instance == null) instance = this;
    }

    void Start()
    {
        UpdateScoreUI();
    }

    // Questa funzione verrà chiamata ogni volta che un cubo verde viene eliminato
    public void AddPoint(int pointsToAdd)
    {
        score += pointsToAdd;
        UpdateScoreUI();
    }

    // Aggiorna la scritta a schermo
    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Punti: " + score;
        }
    }
}