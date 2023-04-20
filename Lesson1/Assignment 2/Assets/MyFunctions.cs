using UnityEngine;
using Vector3 = UnityEngine.Vector3;
using Vector2 = UnityEngine.Vector2;

public static class MyFunctions 
{
    public static float FindAngle(Vector3 pos1,Vector3 pos2)
    {
        float angle;
        float hypotenuse = new Vector2(pos2.y - pos1.y, pos2.x - pos1.x).magnitude;
        if (pos2.y>pos1.y)
        {
            angle = 90 - Mathf.Asin((pos2.x - pos1.x) / hypotenuse) * 180 / Mathf.PI;
        }
        else
        {
            angle = 270 - Mathf.Asin((pos1.x - pos2.x) / hypotenuse) * 180 / Mathf.PI;
        }
        return angle;
    }
}
