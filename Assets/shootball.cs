using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class shootball : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb;
    public float Force = 500f;
    public Vector3 dir = new Vector3(0f, 0f, 0f);  
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(dir * Force);

        }
    }
}
