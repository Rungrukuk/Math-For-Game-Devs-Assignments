using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorProjection : MonoBehaviour
{
    [SerializeField] private Transform vector1StartPos;
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(default,transform.position);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(vector1StartPos.position,transform.position/2);
    }
}
