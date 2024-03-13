using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] Text textScore;
    private int score;
    public static ScoreController instance;

    private void Awake()
    {
        instance = this;
    }
    public void GetScore(int score)
    {
        this.score += score;
        textScore.text = this.score.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
