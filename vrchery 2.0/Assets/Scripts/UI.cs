using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    // Private variables
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateScore(int points)
    {
        score += points;
        GetComponent<TMP_Text>().SetText("Score: " + score);
    }

    public void updateArrows(int remaining)
    {
        GetComponent<TMP_Text>().SetText("Arrows: " + remaining);
    }

    public int getScore() { return score; }
}
