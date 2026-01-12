using System;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;

public class colliding : MonoBehaviour
{
    public int MaxHits = 5;
    
    public double multiplyer;
    public float shrink = 0.1f; 
    public float shrinkplus = 0.1f;
    private ParticleSystem ps;
    private int hitt = 0;
    public int collided2 = 0;
    private AudioSource audioSource;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static event Action<string, double> onBumperHit;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        ps = GetComponent<ParticleSystem>();
        ps?.Stop();
        CountBalls.onBallLost += score;
    }
    private void OnDisable()
    {
        CountBalls.onBallLost -= score;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hitt == 0)
        {
            /*if (!this.gameObject.CompareTag("combo"))
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
            */
            if (collision.gameObject.CompareTag("ball"))
            {
                onBumperHit?.Invoke(gameObject.tag, multiplyer);
               
                hitt = 1;
                collided2 = 1;

            }
        }
        if (collision.gameObject.CompareTag("ball"))
        {
           
            ps?.Stop();


            ps?.Play();
            audioSource.Stop();

            audioSource.Play();

        }


    }
    private void score()
    {
        hitt = 0;
    }



}
