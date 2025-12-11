using TMPro;
using UnityEngine;

public class CountBallsUI : MonoBehaviour
{
    public TextMeshProUGUI ballcounttext;
    public int ballsshot = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CountBalls.onBallshot += ballcount;
        CountBalls.onBallDepleted += ballcount;
    }

    // Update is called once per frame
    void Update()
    {
        ballcounttext.text = ($"BallCount: {ballsshot}");
    }
    private void ballcount()
    {
        ballsshot++;
    }
}
