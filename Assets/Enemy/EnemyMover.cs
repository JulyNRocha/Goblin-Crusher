using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Tile> path = new List<Tile>();
    [SerializeField] [Range(0f,5f)] float speed = 1f;

    Enemy enemy;

    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void FindPath()
    {
        path.Clear();

        GameObject[] tiles = GameObject.FindGameObjectsWithTag("Path");

        foreach (GameObject tile in tiles)
        {
            Tile waypoint = tile.GetComponent<Tile>();
            if(waypoint != null)
            {
                path.Add(waypoint);    
            }
            
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }

    IEnumerator FollowPath()
    {
        foreach(Tile waypoint in path)
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
        
        FinishPath(); 
    }
}
