using System;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class shootball : MonoBehaviour
{    
    [SerializeField] private float lineSpeed = 10f;
    Vector3 offset = new Vector3(0.5f, 0f, 0f);
    private LineRenderer _line;
    public static event Action onShootBall;
   
    private bool _lineActive = false;

    [SerializeField] private GameObject prefab;
    
    [SerializeField] private float forceBuild = 20f;
    
    [SerializeField] private float maximumHoldTime = 5f;

  
    private float _pressTimer = 0f;
    
    private float _launchForce = 0f;
    private bool _shotEnabled = true;
    public TextMeshProUGUI Scoretext;

    private void Start()
    {
        CountBalls.onBallDepleted += DisableShot;
        _line = GetComponent<LineRenderer>();

        _line.SetPosition(1, Vector3.zero + offset);
     

    }
    private void OnDisable()
    {
        CountBalls.onBallDepleted -= DisableShot;
    }

    private void Update()
    {
        if (_shotEnabled)HandleShot();
    }
    
    private void HandleShot()
    {
        if (scoreManager.Instance.score > 9)
        {


            if (Input.GetMouseButtonDown(0))
            {
                _pressTimer = 0;
                _lineActive = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                scoreManager.Instance.score -= 10;

                _launchForce = _pressTimer * forceBuild;
                GameObject ball = Instantiate(prefab, transform.parent);
                ball.transform.rotation = transform.rotation;
                ball.GetComponent<Rigidbody2D>().AddForce(ball.transform.right * _launchForce, ForceMode2D.Impulse);
                ball.transform.position = transform.position;


                //Invoke de action event bij het schieten
                onShootBall?.Invoke();
                _lineActive = false;
                _line.SetPosition(1, Vector3.zero + offset);
            }

            if (_pressTimer < maximumHoldTime)
            {

                _pressTimer += Time.deltaTime;
            }
            if (_lineActive)
            {
                _line.SetPosition(1, Vector3.right * _pressTimer * lineSpeed);
            }
        }
    }
    private void DisableShot()
    {
        _shotEnabled = false;
    }
}
