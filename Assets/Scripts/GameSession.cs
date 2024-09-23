using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameSession  : MonoBehaviour
{
    [SerializeField] int Score = 0;
    [SerializeField] int Points = 2;

    [SerializeField] TextMeshProUGUI ScoreText; 


    [Range(0.1f, 10f)] [SerializeField] float GameTime = 1f;

    
    //Cash
    Block block;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if(gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }



    void Start()
    {
        block = FindObjectOfType<Block>();
        ScoreText.text = Score.ToString();
    }

    
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = GameTime;
    }



    public void AddToScore()
    {
        ScoreText.text = Score.ToString();  
        Score += Points;
    }

    public void newScore()
    {
        block.DestroyBlock();   //ссылаемся на метод DestroyBlock в коде Block
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

}
