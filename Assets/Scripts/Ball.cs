using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball Instance { set; get; }
    [SerializeField] private float InitialSpeed;
    [SerializeField] private float SpeedIncrease;
    [SerializeField] private TextMeshProUGUI player1Score;
    [SerializeField] private TextMeshProUGUI player2Score;

    private int HitCounter;
    private Rigidbody2D Rb;

    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        Instance = this;
    }

    public void StartThis()
    {
        Invoke("StartBall", 2f);
    }

    private void FixedUpdate()
    {
        Rb.velocity = Vector2.ClampMagnitude(Rb.velocity, InitialSpeed + (SpeedIncrease * HitCounter));
    }
    private void StartBall()
    {
        Rb.velocity = new Vector2(-1,0)*(InitialSpeed+SpeedIncrease* HitCounter);
    }
    private void ResetBall()
    {
        Rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
        HitCounter = 0;
        Invoke("StartBall",2f);
    }
    private void PlayerBounce(Transform myObject)
    {
        HitCounter++;

        Vector2 ballPos = transform.position;
        Vector2 playerPos = myObject.position;

        float xDirection, yDirection;
        if(transform.position.x > 0)
        {
            xDirection = -1;
        }
        else
        {
            xDirection = 1;
        }
        yDirection = (ballPos.y - playerPos.y) / myObject.GetComponent<Collider2D>().bounds.size.y;
        if(yDirection == 0)
        {
            yDirection = 0.25f;
        }
        Rb.velocity = new Vector2(xDirection, yDirection) * (InitialSpeed + (SpeedIncrease * HitCounter));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "LeftPaddle" || collision.gameObject.name == "RightPaddle")
        {
            PlayerBounce(collision.transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered the collision method. THE FUCK AREn'T YOU WORKINg");

        if(transform.position.x > 0)
        {
            ResetBall();
            player1Score.text = (int.Parse(player1Score.text) + 1).ToString();
        }
        else if (transform.position.x < 0)
        {
            ResetBall();
            player2Score.text = (int.Parse(player2Score.text) + 1).ToString();
        }
    }

}
