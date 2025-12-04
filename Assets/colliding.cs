using System;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class colliding : MonoBehaviour
{
    public int MaxHits = 5;
    public int value = 5;
    public float shrink = 0.1f; 
    public float shrinkplus = 0.1f;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static event Action<string, int> onBumperHit;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (!this.gameObject.CompareTag("combo"))
        {
            MaxHits--;
            Debug.Log("hit! " + MaxHits);


            transform.localScale = new UnityEngine.Vector3(1f - shrink, 1f - shrink, 1f - shrink);
            shrink = shrink + shrinkplus;


            if (MaxHits <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        if (collision.gameObject.CompareTag("ball"))
        {
            onBumperHit?.Invoke(gameObject.tag, value);
        }
       
       
    }
    
   
    
}
