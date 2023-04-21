using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class Barrel : MonoBehaviour
{
    [SerializeField] private float radius = 5;
    [SerializeField] private Transform player;
    

    void Update()
    {
        if (player.position.x>=transform.position.x - radius && player.position.x<=transform.position.x + radius)
        {
            Debug.Log("Player in");
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 center = transform.position;
        Gizmos.DrawWireSphere(center,radius);
        float distance = 0;
        if (player!=null)
        {
           distance = (player.position - center).magnitude;
        }

        if (distance<=radius)
        {
            Debug.Log("Player in");
        }
        
    }
}
