using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] private float checkDistance = 5;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player.transform.position.x>=transform.position.x - checkDistance && player.transform.position.x<=transform.position.x + checkDistance)
        {
            Debug.Log("Player in");
        }
    }

    private void OnDrawGizmos()
    {
        var position = transform.position;
        Gizmos.DrawLine(position,new Vector3(position.x - checkDistance,position.y,0));
        Gizmos.DrawLine(position,new Vector3(position.x + checkDistance,position.y,0));
    }
}
