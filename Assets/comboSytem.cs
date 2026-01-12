using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.DebugUI;
public class comboSytem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TextMeshProUGUI Scoretext;
    private List<string> bumperTags = new List<string>();
  
    public double multipayer2 = 1;
    
    public shootball shootball;
   // private List<int> bumpersvalue = new List<int>();

    private int scoreMultiplier = 1;
   

    private void Start()
    {
        Scoretext.text = ($"Score: {scoreManager.Instance.score} " + $" Multiplier: {scoreMultiplier}X");
        colliding.onBumperHit += CheckForCombo;
        CountBalls.onBallLost += score;
        CountBalls.onBallshot += fixscore;
        CountBalls.onBallDepleted += fixscore;

       // CountBalls.onBallLost += addpoints;

    }

    private void OnDisable()
    {
        colliding.onBumperHit -= CheckForCombo;
        CountBalls.onBallLost -= score;
        CountBalls.onBallshot -= fixscore;
        CountBalls.onBallDepleted -= fixscore;
        // CountBalls.onBallLost -= addpoints;
    }
    private void CheckForCombo(string tag,  double multiplyer)
    {

        // bumpersvalue.Add(bumpervalue);

       
        multipayer2 = multipayer2 * multiplyer;
            
        //scoreManager.Instance.AddScore(bumpervalue * scoreMultiplier);
        string scoretxt = ($"Score: {scoreManager.Instance.score} ");
        string combotxt = ($" Multiplier: {multipayer2}X");



        Scoretext.text = scoretxt + combotxt;


    }
    private void score() {
        if (multipayer2 != 1) { 
        scoreManager.Instance.AddScore(shootball.points * multipayer2);
    }
        string scoretxt = ($"Money: {scoreManager.Instance.score} ");
        string combotxt = ($" Multiplier: {scoreMultiplier}X");
        Scoretext.text = scoretxt + combotxt;
       
        multipayer2 = 1;
    }
    private void fixscore()
    {
        
        string scoretxt = ($"Money: {scoreManager.Instance.score} ");
        string combotxt = ($" Multiplier: {scoreMultiplier}X");
        Scoretext.text = scoretxt + combotxt;
    }
    /*  private void addpoints()
      {
          foreach (string i in bumperTags)
          {

          }
      }
    */
}
