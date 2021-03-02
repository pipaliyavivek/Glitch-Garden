using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    //public static Health instance;
    [SerializeField] private float health = 100f;
    [SerializeField] GameObject DeathVFX;
    void Start()
    {
      //  instance = this;   
    }
   public void DealDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }
    public void TriggerDeathVFX()
    {
        if ( !DeathVFX ) { return; }

            GameObject DeathVFXObject =  Instantiate(DeathVFX, transform.position, Quaternion.identity);
        Destroy(DeathVFXObject, 1f);
    }
}
