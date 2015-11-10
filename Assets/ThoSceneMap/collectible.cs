using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class collectible : MonoBehaviour {
    private int score = 0;
    public Text myText;

     void OnCollisionEnter2D(Collision2D coll) 
     {
         if (coll.gameObject.tag == "Diamond")
         {
             Destroy(coll.gameObject);
             score++;
             SetText("score : " + score);
         }
    }
     public void SetText(string text)
     {
         myText.text = "score : " + score;
     }


}
