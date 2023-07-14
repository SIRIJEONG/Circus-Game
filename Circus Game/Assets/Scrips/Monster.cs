using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject[] obstacles;


    //private Animator animation = default;
    private bool stepped = false;


    private void OnEnable()
    {
       

        //for (int i = 0; i < obstacles.Length; i++)
        //{
        //    if (Random.Range(0, 1) != 0)
        //    {
        //        obstacles[i].SetActive(false);
        //    }
        //    else
        //    {
        //        obstacles[i].SetActive(true);
        //    }
        //}
    }
    // Start is called before the first frame update
    void Start()
    {
        //animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.tag.Equals("Player"))
    //    {
           
    //        GameManager.Instance.AddScore(1);
    //    }
    //}
}
