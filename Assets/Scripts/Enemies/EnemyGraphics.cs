using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using redd096;

[RequireComponent(typeof(FieldOfView3D))]
public class EnemyGraphics : MonoBehaviour
{
    [Header("Field of View")]
    [SerializeField] LineRenderer linePrefab = default;
    [SerializeField] LineRenderer killPlayerLinePrefab = default;

    FieldOfView3D fov;

    LineRenderer line;
    Vector3 rightFov;
    Vector3 leftFov;

    void Start()
    {
        //get references
        fov = GetComponent<FieldOfView3D>();
        line = Instantiate(linePrefab, transform);
    }

    void Update()
    {
        UpdateLinePosition();
        SetLinePositions();
    }

    void UpdateLinePosition()
    {
        //get right and left point
        leftFov = transform.position + fov.DirFromAngle(-fov.viewAngle / 2, false) * fov.viewRadius;
        rightFov = transform.position + fov.DirFromAngle(fov.viewAngle / 2, false) * fov.viewRadius;

        //check if hit walls
        //RaycastHit hit;
        //if(Physics.Linecast(transform.position, leftFov, out hit))
        //{
        //    leftFov = hit.point;
        //}
        //if(Physics.Linecast(transform.position, rightFov, out hit))
        //{
        //    rightFov = hit.point;
        //}
    }

    void SetLinePositions()
    {
        //set points in line renderer
        line.positionCount = 3;
        line.SetPosition(0, transform.position);
        line.SetPosition(1, rightFov);
        line.SetPosition(2, leftFov);
    }

    public void ShowLineToPlayer(Transform player)
    {
        //instantiate line
        LineRenderer lineToPlayer = Instantiate(killPlayerLinePrefab);

        //draw line from this to player
        lineToPlayer.positionCount = 2;
        lineToPlayer.SetPosition(0, transform.position);
        lineToPlayer.SetPosition(1, player.position);
    }
}
