using UnityEngine;


public class LaserGun : MonoBehaviour
{
    private Vector3 mousePosition;
    private float dotProduct;
    private float angle;
    [HideInInspector]
    public Vector3 shootingMousePos;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] Transform shootingPos;
    [SerializeField] private GameObject bullets;

    // Update is called once per frame
    void Update()
    {
        if (Camera.main != null) mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if (Input.GetMouseButtonDown(0))
        {
            transform.rotation = Quaternion.identity;
            var position = transform.position;
            dotProduct = position.normalized.x * mousePosition.x + position.normalized.y * mousePosition.y;
            angle = Mathf.Acos(dotProduct / mousePosition.magnitude * position.normalized.magnitude) * 180 / Mathf.PI;
            transform.rotation = Quaternion.Euler(0,0,angle);
            shootingMousePos = mousePosition;
            var bullet = Instantiate(bulletPrefab, shootingPos);
            bullet.transform.parent = bullets.transform;
        }
        
    }
}
