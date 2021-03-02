using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    
    [Range(0f, 5f)]
    float currentSpeed = 1f;
    GameObject currentTarget;
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        UpdateAnimationState();
    }
    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerSpawned();
    }
    private void OnDestroy()
    {
        LevelController levelcontroller = FindObjectOfType<LevelController>();
        //LevelController.instace.AttackerKilled();
        if(levelcontroller != null)
        {
            levelcontroller.AttackerKilled(); 
        }
       // FindObjectOfType<LevelController>().AttackerKilled();

    }

    private void UpdateAnimationState()
    {
        if(!currentTarget)
        {
            GetComponent<Animator>().SetBool("IsAttacking",false);
        }
    }
    public void SetMovementSpeed(float Speed)
    {
        currentSpeed = Speed;
    }

    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttacking", true);
        currentTarget = target;
    }
    public void StrikeCurrentTarget(float damage)
    {
        if(!currentTarget) { return; }
        Health health = currentTarget.GetComponent<Health>();
        if(health)
        {
            health.DealDamage(damage);
        }
    }
}
