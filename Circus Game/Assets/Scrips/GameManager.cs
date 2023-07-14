using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isGameOver = false;
    public TMP_Text scoreText; // Text mesh pro������Ʈ �� ���
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
            GFunc.LogWarning("���� �� �� �̻��� ���� �Ŵ����� �����մϴ� !");
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

                Debug.Log("�ܻ��� ���ɴϴ�");
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
