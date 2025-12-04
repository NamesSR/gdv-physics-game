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
     private int scoreMultiplier = 1;
  
    private void Start()
    {
        Scoretext.text = ($"Score: {scoreManager.Instance.score} ");
        colliding.onBumperHit += CheckForCombo;
    }

    private void OnDisable()
    {
        colliding.onBumperHit -= CheckForCombo;
    }
    private void CheckForCombo(string tag, int bumpervalue)
    {
        bumperTags.Add(tag);
        if (bumperTags.Count > 1)
        {
            if (bumperTags[bumperTags.Count - 2] == bumperTags[bumperTags.Count - 1])
            {
                scoreMultiplier++;
            }
            else {
                scoreMultiplier = 1;
                bumperTags.Clear();
            
            
            }
        }
        scoreManager.Instance.AddScore(bumpervalue * scoreMultiplier);
        string scoretxt = ($"Score: {scoreManager.Instance.score} ");
        string combotxt = ($" Multiplier: {scoreMultiplier}X");
        if (scoreMultiplier > 1)
        {
            Scoretext.text = scoretxt + combotxt;
        }
        else
        {

            Scoretext.text = scoretxt;
        }
    }
}
