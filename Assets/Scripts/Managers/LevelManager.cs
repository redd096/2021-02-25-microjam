using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using redd096;

public class LevelManager : MonoBehaviour
{
    public void EndGame(bool win)
    {
        //show end menu
        GameManager.instance.uiManager.EndMenu(true, win);

        //stop time
        Time.timeScale = 0;

        //disable player input and show cursor
        //GameManager.instance.player.enabled = false;
        Utility.LockMouse(CursorLockMode.None);
    }
}
