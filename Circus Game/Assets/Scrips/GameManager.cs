using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isGameOver = false;
    public TMP_Text scoreText; // Text mesh pro컴포넌트 쓴 경우
    public GameObject gameoverUi;
    public float score = default;

    


    private void Awake()
    {
        if (Instance.IsValid() == false)
        {
            Instance = this;
        }
        else
        {
            GFunc.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다 !");
            Destroy(gameObject);
        }


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == true && Input.GetMouseButtonDown(0))
        {
            GFunc.LoadScene(GFunc.GetActiveSceneName());
        }
        if (isGameOver == false)
        {
            score += Time.deltaTime * 2;
            scoreText.text = string.Format("Score : {0}M", (int)score);

            if((int)score == 60)
            {

                Debug.Log("단상이 나옵니다");
            }
        }
    }

    //public void AddScore(int newScore)
    //{
    //}

    public void OnPlayerDead()
    {
        isGameOver = true;
        gameoverUi.SetActive(true);
    }
}
