using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using redd096;

public class EndPoint : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        //if hit by player
        if (other.GetComponentInParent<Player>())
        {
            //win
            WinGame();
        }
    }

    void WinGame()
    {
        //show win menu
        GameManager.instance.levelManager.EndGame(true);
    }
}
