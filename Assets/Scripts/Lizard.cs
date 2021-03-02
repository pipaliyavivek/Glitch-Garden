using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log("Trigger Succesfuly..." +collision.name);
        GameObject otherObject = collision.gameObject;
        if( otherObject.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(otherObject);
        }

    }
}
