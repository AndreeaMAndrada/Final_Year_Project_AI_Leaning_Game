using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butpop : MonoBehaviour
{
    public GameObject popUpBox;

  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true )
        {
            popUpBox.SetActive(true);

        }


    }


}
