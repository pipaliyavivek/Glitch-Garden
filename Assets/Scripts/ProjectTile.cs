   
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTile : MonoBehaviour
{
  
   [SerializeField ] private float Speed = 50f;
    [SerializeField] private float damage = 50f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime);    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponent<Health>();
        var attack = collision.GetComponent<Attacker>();

        if (attack && health) 
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
