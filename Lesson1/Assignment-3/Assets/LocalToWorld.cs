using UnityEngine;

public class LocalToWorld : MonoBehaviour
{
    [SerializeField] private Vector2 localCoord;

    public void OnDrawGizmos()
    {
        Vector2 worldPos = ConvertLocalToWorld(localCoord);
        Gizmos.DrawSphere(worldPos,0.1f);
    }

    private Vector2 ConvertLocalToWorld(Vector2 local)
    {
        Vector2 position = transform.position;
        position += local.x * (Vector2)transform.right;
        position += local.y * (Vector2)transform.up;
        return position;
    }
}
