using UnityEngine;

public class hide : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public TestText hide2;
    void Start()
    {
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
      if(hide2.textend == 1)
        {
            this.gameObject.SetActive(false);
        }
    }
}
