using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coliders : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Ground"))
        {
                Debug.Log("Collided with ground");
                gameObject.SetActive(false);
                MenuManager.instance.IncreaseScore();
                gameObject.SetActive(false);
        }

        if(other.CompareTag("Player"))
        {
            
            Debug.Log("Collided with player");
            gameObject.SetActive(false);
            MenuManager.instance.IncreaseSeparating();
            gameObject.SetActive(false);
        }

        /**
        if (other.gameObject.name == "computer")
        {
            Debug.Log("quit");
            gameObject.SetActive(false);
            MenuManager.instance.GameOver();
            gameObject.SetActive(false);
        }**/

    }

    
}
