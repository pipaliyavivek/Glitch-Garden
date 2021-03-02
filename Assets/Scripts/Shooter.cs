using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    AttackerSpwner MyLaneSpawner;
    [SerializeField] GameObject projecttile,Gun;

    Animator anim;
    GameObject ProjectTilePerent;
    const string PROJECTILE_PERENT_NAME = "Projecttile";
    private void Start()
    {
        SetLaneInSpwaner();
        anim = GetComponent<Animator>();
        CreateProjectTilePerent();
    }
    public void CreateProjectTilePerent()
    {
        ProjectTilePerent = GameObject.Find(PROJECTILE_PERENT_NAME);
        if(!ProjectTilePerent)
        {
            ProjectTilePerent = new GameObject(PROJECTILE_PERENT_NAME);
        }


    }
    private void Update()
    {
        if(IsAttackerInLane())
        {
            //Debug.Log("Shoot in pew pew");
            anim.SetBool("IsAttacking", true);
        }
        else
        {
            anim.SetBool("IsAttacking", false);

            //Debug.Log("Not shoot");

        }
    }
    void SetLaneInSpwaner()
    {
        AttackerSpwner[] spawners = FindObjectsOfType<AttackerSpwner>();
        foreach(AttackerSpwner spwner in spawners)
        {
            bool IsCloseEnough = (Mathf.Abs( spwner.transform.position.y - transform.position.y ) <= Mathf.Epsilon);
            if(IsCloseEnough)
            {
                MyLaneSpawner = spwner;
            }
        }
    }
    private bool IsAttackerInLane()
    {
        return true;
        //if(MyLaneSpawner.transform.childCount <= 0)
        //{
        //    return false;
        //}
        //else
        //{
        //    return true;
        //}
    }
    public void Fire()
    {
       GameObject newprojecttime = Instantiate(projecttile,Gun.transform.position, Quaternion.identity)as GameObject ;

        newprojecttime.transform.parent = ProjectTilePerent.transform;

            //return;
    }
}
