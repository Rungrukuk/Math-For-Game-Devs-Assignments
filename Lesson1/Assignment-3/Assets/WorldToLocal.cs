using UnityEngine;

public class WorldToLocal : MonoBehaviour
{
    [SerializeField] private Vector2 worldCoord;
    private Vector2 localCoord;
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(worldCoord,0.1f);
        localCoord = ConvertWorldToLocal(worldCoord);
    }

    private Vector2 ConvertWorldToLocal(Vector2 worldPos)
    {
        Vector2 rel = -worldPos + (Vector2)transform.position;
        float x = Vector2.Dot(rel, transform.right);
        float y = Vector2.Dot(rel, transform.up);
        return new (x,y);
    }
    
}
