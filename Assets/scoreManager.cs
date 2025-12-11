using UnityEngine;
using UnityEngine.SceneManagement;

public class scoreManager : MonoBehaviour
{
    // Singleton
    public static scoreManager Instance;

    // Totale score
    public int score = 0;
    public int ballsShot = 0;


    private void Awake()
    {
        // controleren of er al een ScoreManager bestaat
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // dit is nu de enige ScoreManager in de scene
        Instance = this;
    }

    // functie om punten toe te voegen
    public void AddScore(int amount)
    {
        score = score + amount;
        // debug voor testen
        Debug.Log("Score: " + score);
    }
}