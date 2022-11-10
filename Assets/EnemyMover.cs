using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] float waitSeconds = 1f;

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

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime;
                this.transform.position = Vector3.Lerp(startPoint, finalPoint, travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
