using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    int score;
    public float speed = 0; 
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        winText.text = "";

        if(instance == null)
        {
            instance = this;
        }
    }
    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        text.text = "Score: "+score.ToString();
        if (score==8)
        {
            winText.text = "You Win! Game created by vcaprion";
            GetComponent<AudioSource>().Play();
        }
        
    }

}

