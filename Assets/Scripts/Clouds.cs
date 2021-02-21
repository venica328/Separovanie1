using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float xLimit;
    [SerializeField]
    private float xLimit2;


    private bool movingRight = true;
    private int direction = 1;
    private bool startMoving = false;

    public bool StartMoving { get { return startMoving; } set { startMoving = value; } }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.instance.StartMoving == true) { 
            ChangeDirection();

        transform.position += Vector3.right * moveSpeed * Time.deltaTime * direction;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, xLimit2, xLimit), transform.position.y, transform.position.z);
        }
    }

    void ChangeDirection()
    {
        if (movingRight && transform.position.x >= xLimit)
        {
            movingRight = false;
            direction = -1;
            transform.localScale = new Vector3(direction, 1, 1);
        }

        if (!movingRight && transform.position.x <= xLimit2)
        {
            movingRight = true;
            direction = 1;
            transform.localScale = new Vector3(direction, 1, 1);
        }
    }

}
