using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisions : MonoBehaviour
{
    private void onCollisionEnter(Collision2D other)
    {
        if (other.collider.name == "Ground")
        {
            Debug.Log("COMPUTER2");
            gameObject.SetActive(false);
            MenuManager.instance.GameOver();
            gameObject.SetActive(false);
            Application.Quit();
            
        }

        if (other.collider.name == "computer")
        {
            Debug.Log("COMPUTER2");
            gameObject.SetActive(false);
            MenuManager.instance.GameOver();
            gameObject.SetActive(false);

        }
    }
    
}
