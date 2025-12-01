using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class colliding : MonoBehaviour
{
    public int MaxHits = 5;
    public int value = 5;
    public float shrink = 0.1f; 
    public float shrinkplus = 0.1f;

    public TextMeshProUGUI Scoretext;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        scoreManager.Instance.AddScore(value);
        MaxHits--;
        Debug.Log("hit! " + MaxHits);
        transform.localScale = new UnityEngine.Vector3(1f - shrink, 1f - shrink, 1f - shrink);
        shrink = shrink + shrinkplus;
        Scoretext.text = scoreManager.Instance.score.ToString();
        if (MaxHits <= 0)
        {
            Destroy(this.gameObject);
        }
        
    }
}
