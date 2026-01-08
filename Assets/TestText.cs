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

    string t = "i need Some money";
    string[] txt324 = new string[] {"you grab your phone to call a friend","ring ring ring ring","Yo","Friend: Yo we have not spoken in a while","friend: How have you been sins ...then", "I have been fine i need some money","Friend: AGAIN !!!",
        "Friend: you have not paid me back yet from last week!","Friend: fine fine i give you a 50 but this is the laast time i lend you money","Friend: forever! you asshole how didnt show up to your friends fun..","you hang up the phone","one ball cost 10",""
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
            
            
           
            if (c == 12)
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