using System;
using System.Collections;
using TMPro;

using UnityEngine;

public class shootball : MonoBehaviour
{    
    [SerializeField] private float lineSpeed = 10f;
    Vector3 offset = new Vector3(0.5f, 0f, 0f);
    private LineRenderer _line;
    public static event Action onShootBall;
   
    private bool _lineActive = false;
    public double points = 10;
    float time = 2;

    [SerializeField] private GameObject prefab;
    
    [SerializeField] private float forceBuild = 20f;
    
    [SerializeField] private float maximumHoldTime = 5f;

  
    private float _pressTimer = 0f;
    
    private float _launchForce = 0f;
    private bool _shotEnabled = true;
    public TextMeshProUGUI pointstext;
    public static event Action oncostchagne;
    double valuer = 10;

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
        if (Input.GetKeyDown(KeyCode.RightArrow) && points < scoreManager.Instance.score -5 )
        {
            valuer += 10;
            StartCoroutine(showtext());
            oncostchagne?.Invoke();

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)&& points != 10)
        {
            valuer -= 10;
            StartCoroutine(showtext());
            oncostchagne?.Invoke();
        }
    }
    
    private void HandleShot()
    {
        if (scoreManager.Instance.score > points - 1)
        {


            if (Input.GetMouseButtonDown(0))
            {
                _pressTimer = 0;
                _lineActive = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                points = valuer;
                scoreManager.Instance.score -= points;

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
    IEnumerator showtext()
    {
        pointstext.text = points.ToString();
        yield return new WaitForSeconds(time);
        pointstext.text = "";
    }
}
