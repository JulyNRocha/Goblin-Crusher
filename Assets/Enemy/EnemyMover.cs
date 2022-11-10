using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] [Range(0f,5f)] float speed = 1f;

    void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        foreach(Waypoint waypoint in path)
        {
            Vector3 startPoint = this.transform.position;
            Vector3 finalPoint = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(finalPoint);

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                this.transform.position = Vector3.Lerp(startPoint, finalPoint, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
