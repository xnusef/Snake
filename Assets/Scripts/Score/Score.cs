using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public int Points = 0;

    void Start()
    {
        GameManager.GM.SetScoreScript(this);
    }
    public void AddScore()    
    {
        Points += 1;
        this.gameObject.GetComponent<TMP_Text>().text = "Score: " + Points;
    }
}
