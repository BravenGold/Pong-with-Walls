using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody2D RB;
    [SerializeField] private float speed;
    [SerializeField] private GameObject ball;
    [SerializeField] private bool RightPlayer;
    // [SerializeField] private GameObject paddleLeft;
    // [SerializeField] private GameObject paddleLeft;
    private Vector2 playerMove;
    // private ButtonManager Buttons;

    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        // Buttons = new ButtonManager();
    }

    void Update()
    {
        if (RightPlayer)
        {
            RightPlayerController();
        }
        else
        {
            LeftPlayerController();
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        /*else if (Input.GetKey(KeyCode.P))
        {
            Debug.Log("The 'p' key was reached.");
            // Buttons.HelpClick();
            ButtonManager.Instance.HelpClick();
        }
        //   PlayerController();
        if (Input.GetKey(KeyCode.T))
        {
            Time.timeScale = 0;
        }*/
    }

    private void RightPlayerController()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            // move right paddle
            playerMove = new Vector2(0, Input.GetAxisRaw("Vertical"));
            Debug.Log("Trying to move player 2.");
        }
    }
    private void LeftPlayerController()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            // move left paddle
            playerMove = new Vector2(0, Input.GetAxisRaw("Vertical"));
            Debug.Log("Trying to move player 1.");
            // Debug.Log(playerMove.y);
        }
    }
        ///if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        // {
            // move left paddle
        //    player1 = new Vector2(0, Input.GetAxisRaw("Vertical"));
        //    Debug.Log("Trying to move player 1.");
        //    Debug.Log(player1.y) ;
        // }
        // else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        // {
        //    // move right paddle
        //    player2 = new Vector2(0, Input.GetAxisRaw("Vertical"));
        //    Debug.Log("Trying to move player 2.");
        // } 
        /* if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        } else if (Input.GetKey(KeyCode.P))
        {
            // Buttons.HelpClick();
            ButtonManager.Instance.HelpClick();
        } */
    
    private void FixedUpdate()
    {
        RB.velocity = playerMove * speed;
    }
}
