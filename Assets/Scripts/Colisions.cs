using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colisions : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "papier" || other.gameObject.name == "plast" || other.gameObject.name == "sklo")
        {
            Debug.Log("quit");
            MenuManager.instance.IncreaseFalling();
        }
    }

}
