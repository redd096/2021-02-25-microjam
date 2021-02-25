using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableEnemy : MonoBehaviour
{
    [Header("Path")]
    [SerializeField] Vector3[] points = default;

    [Header("Movement")]
    [SerializeField] float speed = 2;
    [SerializeField] float timeToRotate = 1;

    Vector3 startPosition;
    int indexToReach;
    Vector3 PositionNextPoint
    {
        //get next point position
        get
        {
            if (Application.isPlaying)
                return startPosition + points[indexToReach];
            else
                return transform.position + points[indexToReach];
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;

        if (points == null)
            return;

        //get start position or transform.position
        Vector3 position = Application.isPlaying ? startPosition : transform.position;

        for(int i = 0; i < points.Length; i++)
        {
            //draw sphere at point
            Gizmos.DrawWireSphere(position + points[i], 0.1f);

            //if not last point, draw line from this to next one point
            if(i < points.Length -1)
            {
                Gizmos.DrawLine(position + points[i], position + points[i + 1]);
            }
        }
    }

    void Start()
    {
        startPosition = transform.position;

        //start movement
        StartCoroutine(PathCoroutine());
    }

    IEnumerator PathCoroutine()
    {
        while (true)
        {
            //foreach point
            for (indexToReach = 0; indexToReach < points.Length; indexToReach++)
            {
                //rotate to point
                yield return RotateCoroutine();

                //move to point
                yield return MoveCoroutine();
            }
        }
    }

    IEnumerator RotateCoroutine()
    {
        //set vars
        Quaternion startRotation = transform.rotation;
        Quaternion endRotation = Quaternion.LookRotation(PositionNextPoint - transform.position, Vector3.up);

        //rotate animation
        float delta = 0;
        while(delta < 1)
        {
            delta += Time.deltaTime / timeToRotate;

            transform.rotation = Quaternion.Lerp(startRotation, endRotation, delta);
            yield return null;
        }
    }

    IEnumerator MoveCoroutine()
    {
        //get direction
        Vector3 direction = (PositionNextPoint - transform.position).normalized;

        while (true)
        {
            //set positions
            Vector3 currentPosition = transform.position;
            Vector3 nextPosition = transform.position + direction * speed * Time.deltaTime;

            //if reached point, break loop
            if (Vector3.Distance(nextPosition, PositionNextPoint) > Vector3.Distance(currentPosition, PositionNextPoint))
                break;

            //else move
            transform.position = nextPosition;
            yield return null;
        }
    }
}
