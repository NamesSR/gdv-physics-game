using System;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SocialPlatforms.Impl;
public class CountBalls : MonoBehaviour
{
    public static event Action onBallLost;
    public static event Action onBallDepleted;
    public static event Action onBallshot;
    public TextMeshProUGUI ballcounttext;
    public TextMeshProUGUI gameover;
    shootball shootball;


    [SerializeField] private int ballsLeft = 1 ;
    
    private void Start()
    {
       
        
        shootball.onShootBall += CountOnShot;
        ballsLeft = Convert.ToInt32(Math.Floor(scoreManager.Instance.score)) / 10;
        ballcounttext.text = ($"BallCount: {ballsLeft}");



    }
    private void ballsleftfix()
    {
        ballsLeft = Convert.ToInt32(Math.Floor(scoreManager.Instance.score)) / 10;
        ballcounttext.text = ($"BallCount: {ballsLeft}");
    }


    private void OnDisable()
    {
        //verwijder ook weer alle events
       
        shootball.onShootBall -= CountOnShot;

    }
    private void CountOnShot()
    {
        

        //Check of je nog genoeg ballen over hebt
        if (ballsLeft >= 2)
        {
            //pas je ballen reserve aan
            ballsLeft--;
            ballsLeft = Convert.ToInt32(Math.Floor(scoreManager.Instance.score)) / 10;
            
            ballcounttext.text = ($"BallCount: {ballsLeft}");
            onBallshot.Invoke();
        }
        /*
       else
       {
           //verstuur event als ze op zijn
           ballsLeft--;
           onBallDepleted?.Invoke();
       }
       */
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Check of de bal uit het scherm gaat
        if (collision.gameObject.CompareTag("ball"))
        {
            Debug.Log("contact");
            //verstur een event
            onBallLost?.Invoke();
            //vernietig de bal
            Destroy(collision.gameObject);

            ballsLeft = Convert.ToInt32(Math.Floor(scoreManager.Instance.score)) / 10;
            ballcounttext.text = ($"BallCount: {ballsLeft}");
            if(scoreManager.Instance.score < 10)
            {
                gameover.text = "Game Over";
            }
        }
    }
}