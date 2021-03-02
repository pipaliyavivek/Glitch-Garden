using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpwaner : MonoBehaviour
{

    Defender defender;
    GameObject DefenderPerent;
   
    const string DEFENDER_PERENT_NAME = "Defenders";
    private void Start()
    {
        CreateDefenderPerent();
       
    }
    public void CreateDefenderPerent()
    {
        DefenderPerent = GameObject.Find(DEFENDER_PERENT_NAME);
        if(!DefenderPerent)
        {
            DefenderPerent = new GameObject(DEFENDER_PERENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        AttemptToPlaceDefederAt(GetsqureClicked());
       // Debug.Log("On Mouse Click");
    }
    private Vector2 GetsqureClicked()
    {
//      Debug.Log("Square Clicked");
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 WorldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridepos = SnapToGride(WorldPos);
        return gridepos;
    }
    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }
    public void AttemptToPlaceDefederAt(Vector2 gridPos)
    {
        if (!defender) return;

        var StarDisplay = FindObjectOfType<StarDisplay>();
        int DefenderCost = defender.GetStarCost();


        if (StarDisplay.HaveEnoughStars(DefenderCost))
        {
            SpawnDefender(gridPos);
            StarDisplay.Spendstar(DefenderCost);
        }
        else
        {
            Debug.Log("Please Select Defender");
        }
    }
    private Vector2 SnapToGride(Vector2 RawWorldPos)
    {
        float newX = Mathf.RoundToInt(RawWorldPos.x);
        float newY = Mathf.RoundToInt(RawWorldPos.y);
        return new Vector2(newX, newY);
    }
    void SpawnDefender(Vector2 RoundedPos)
    {
        Defender newDefender = Instantiate(defender,RoundedPos, Quaternion.identity) as Defender;
        newDefender.transform.parent = DefenderPerent.transform;
    }
}
