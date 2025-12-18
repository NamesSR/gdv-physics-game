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
    public double values23 = 0;
   // private List<int> bumpersvalue = new List<int>();

    private int scoreMultiplier = 1;

    private void Start()
    {
        Scoretext.text = ($"Score: {scoreManager.Instance.score} " + $" Multiplier: {scoreMultiplier}X");
        colliding.onBumperHit += CheckForCombo;
        CountBalls.onBallLost += score;
       // CountBalls.onBallLost += addpoints;

    }

    private void OnDisable()
    {
        colliding.onBumperHit -= CheckForCombo;
        CountBalls.onBallLost -= score;
        // CountBalls.onBallLost -= addpoints;
    }
    private void CheckForCombo(string tag, double bumpervalue, double multiplyer)
    {

        // bumpersvalue.Add(bumpervalue);

        values23 = values23 + bumpervalue;
        multipayer2 = multipayer2 * multiplyer;
            
        //scoreManager.Instance.AddScore(bumpervalue * scoreMultiplier);
        string scoretxt = ($"Score: {scoreManager.Instance.score} ");
        string combotxt = ($" Multiplier: {multipayer2}X");



        Scoretext.text = scoretxt + combotxt;


    }
    private void score() {
        scoreManager.Instance.AddScore(values23 * multipayer2);
        string scoretxt = ($"Score: {scoreManager.Instance.score} ");
        string combotxt = ($" Multiplier: {scoreMultiplier}X");
        Scoretext.text = scoretxt + combotxt;
        values23 = 0;
        multipayer2 = 1;
    }
    /*  private void addpoints()
      {
          foreach (string i in bumperTags)
          {

          }
      }
    */
}
