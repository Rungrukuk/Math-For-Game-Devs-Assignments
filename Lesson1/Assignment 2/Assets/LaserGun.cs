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
    private float hypotenuse;

    // Update is called once per frame
    void Update()
    {
        if (Camera.main != null) mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        hypotenuse = new Vector2(mousePosition.y - transform.position.y, mousePosition.x - transform.position.x).magnitude;
        if (mousePosition.y>transform.position.y)
        {
            angle = 90 - Mathf.Asin((mousePosition.x - transform.position.x) / hypotenuse) * 180 / Mathf.PI;

        }
        else
        {
            angle = 270 - Mathf.Asin((transform.position.x - mousePosition.x) / hypotenuse) * 180 / Mathf.PI;
        }
        transform.rotation = Quaternion.Euler(0, 0, angle);
        if (Input.GetMouseButtonDown(0))
        {

            shootingMousePos = mousePosition;
            var bullet = Instantiate(bulletPrefab, shootingPos);
            bullet.transform.parent = bullets.transform;
        }
        
    }
}
