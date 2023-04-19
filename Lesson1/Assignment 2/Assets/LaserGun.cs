using UnityEngine;

public class LaserGun : MonoBehaviour
{
    private Vector3 mousePosition;
    private float dotProduct;
    private float angle;

    // Update is called once per frame
    void Update()
    {
        if (Camera.main != null) mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward,mousePosition - transform.position);
    }
}
