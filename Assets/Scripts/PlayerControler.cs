using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    private Rigidbody2D myRigidbody;
    public float moveSpeed;
    public Joystick joystick;
   
    SavePlayerPos playerPosData;

    private void Awake()
    {
        playerPosData = FindObjectOfType<SavePlayerPos>();
        playerPosData.PlayerPosLoad();
    }


    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();//declaring the rigidbody
    }

    // Update is called once per frame
    void Update()
    {            
                 
         //declares the moving of the player
        if (joystick.Horizontal > 0.5 || joystick.Horizontal < -0.5)
        {
            myRigidbody.velocity = new Vector2(joystick.Horizontal * moveSpeed, myRigidbody.velocity.y);
        }
        if (joystick.Vertical > 0.5 || joystick.Vertical < -0.5)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, joystick.Vertical * moveSpeed);
        }
        //makes the player stop and not continuously move 
        if (joystick.Horizontal < 0.5f && joystick.Horizontal > -0.5)
        {
            myRigidbody.velocity = new Vector2(0f, myRigidbody.velocity.y);
        }
        if (joystick.Vertical < 0.5f && joystick.Vertical > -0.5)
        {
            myRigidbody.velocity = new Vector2(myRigidbody.velocity.x, 0f);
        }
    }
}
