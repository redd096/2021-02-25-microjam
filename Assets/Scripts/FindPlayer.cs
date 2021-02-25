using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using redd096;

[RequireComponent(typeof(FieldOfView3D))]
[RequireComponent(typeof(EnemyGraphics))]
public class FindPlayer : MonoBehaviour
{
    FieldOfView3D fov;
    EnemyGraphics enemyGraphics;

    void Start()
    {
        //get references
        fov = GetComponent<FieldOfView3D>();
        enemyGraphics = GetComponent<EnemyGraphics>();
    }

    void Update()
    {
        //foreach target, if there is player
        foreach(Transform target in fov.VisibleTargets)
        {
            if (target.GetComponentInParent<Player>())
            {
                //lose
                LoseGame(target);
            }
        }
    }

    void LoseGame(Transform target)
    {
        //show line to player, and lose menu
        enemyGraphics.ShowLineToPlayer(target);
        GameManager.instance.levelManager.EndGame(false);
    }
}
