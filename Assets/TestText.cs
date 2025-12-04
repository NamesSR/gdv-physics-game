using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestText : MonoBehaviour
{

    TextMeshProUGUI text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float time = 0.5f;

    string story = "";
    public int i = 0;
    
    public int textend = 0;
    
    public int c = 0;

    string t = "We have not spoken in aq while";
    string[] txt324 = new string[] {"How have you been sins ...then", ""
        };
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();

        StartCoroutine(showtext());
        




    }
    void Update()
    {
        if (i == t.Length && Input.GetKeyDown(KeyCode.Space) && textend == 0)
        {
            
            
           
            if (c == 1)
            {
                i = 0;
                t = txt324[c];
                text.SetText("");

                story = "";
                textend = 1;
               

                
            }
            else
            {
                i = 0;
                text.SetText("");
                t = txt324[c];
                story = "";
                c++;
            }
            
            StartCoroutine(showtext());


        }




    }
    IEnumerator showtext()
    {

        foreach (char c in t)
        {

            story += c;
            i++;
            Debug.Log(story + i);

            text.text = story;
            yield return new WaitForSeconds(time);


        }
    }
}