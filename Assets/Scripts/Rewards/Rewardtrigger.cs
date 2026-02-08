using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewardtrigger : MonoBehaviour

{
    public GameObject popUpBox;
    public int points = RewardSystem.Points;
    public int change = Dropdownhand.points;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true && (points>0||change>0))
        {
            popUpBox.SetActive(true);

        }


    }
    private void Start()
    {
       
    }
    private void Update()
    {
        points = RewardSystem.Points;
        change = Dropdownhand.points;
        Debug.Log(points);
    }
}
