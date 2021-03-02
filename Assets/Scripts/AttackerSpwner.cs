using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpwner : MonoBehaviour
{
    [SerializeField] float minSpownDelay = 1f;
    [SerializeField] float maxSpownDelay = 5f;
    [SerializeField] GameObject[] AttackerPrefabArray;

    bool Spawn = true;
    
   IEnumerator Start()
    {
        while(Spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpownDelay, maxSpownDelay));
            SpownerAttacker();
        }
    }
    public void StopSpawing()
    {
        Spawn = false;
    }
   private void SpownerAttacker()
    {
        var attackerIndex = Random.Range(0, AttackerPrefabArray.Length);

        spawn(AttackerPrefabArray[attackerIndex]);
    }
   private void spawn(GameObject myAttacker)
    {
        GameObject newAttacker = Instantiate(myAttacker, transform.position, Quaternion.identity) as GameObject;
        newAttacker.transform.parent = transform;
    }
}
