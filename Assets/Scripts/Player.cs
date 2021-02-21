using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    [SerializeField]
    private float speed;

    private bool startMoving = false;

    public bool StartMoving { get { return startMoving; } set { startMoving = value; } }

    private Vector2 target;

    private void Start()
    {
        target = transform.position;
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.y = transform.position.y;
        }
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

    }
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        /**if (other.CompareTag("Falling"))
        {
            MenuManager.instance.GameOver();
            gameObject.SetActive(false);
        }**/
        if(other.gameObject.name == "computer" || other.gameObject.name == "phone")
        {
            Debug.Log("quit");
            gameObject.SetActive(false);
            MenuManager.instance.GameOver();
            gameObject.SetActive(false);
        }
    }

}
