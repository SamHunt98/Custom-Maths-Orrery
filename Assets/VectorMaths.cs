using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorMaths : MonoBehaviour {


    //class containing all of the functions used for the custom-made vector maths 
    //some functions have overrides for different inputs
    public static Vector2 VectorAdd(Vector2 V1, Vector2 V2)
    {
        Vector2 Temp;
        Temp.x = V1.x + V2.x;
        Temp.y = V1.y + V2.y;
        return Temp;
    }
    public static Vector3 VectorAdd(Vector3 V1, Vector3 V2)
    {
        Vector3 Temp;
        Temp.x = V1.x + V2.x;
        Temp.y = V1.y + V2.y;
        Temp.z = V1.z + V2.z;
        return Temp;
    }
    public static Vector2 VectorSubtract(Vector2 V1, Vector2 V2)
    {
        Vector2 Temp;
        Temp.x = V1.x - V2.x;
        Temp.y = V1.y - V2.y;
        return Temp;
    }
    public static Vector3 VectorSubtract(Vector3 V1, Vector3 V2)
    {
        Vector3 Temp;
        Temp.x = V1.x - V2.x;
        Temp.y = V1.y - V2.y;
        Temp.z = V1.z - V2.z;
        return Temp;
    }
    public static float VectorLength(Vector2 V1)
    {
        float Temp;
        Temp = (V1.x * V1.x) + (V1.y * V1.y);
        Temp = Mathf.Sqrt(Temp);
        return Temp;
    }
    public static float VectorLength(Vector3 V1)
    {
        float Temp;
        Temp = (V1.x * V1.x) + (V1.y * V1.y) + (V1.z * V1.z);
        Temp = Mathf.Sqrt(Temp);
        return Temp;
    }
    public static float VectorLengthSquared(Vector3 V1)
    {
        float Temp;
        Temp = (V1.x * V1.x) + (V1.y * V1.y) + (V1.z * V1.z);
        return Temp;
    }
    public static Vector3 VectorMultiply(Vector3 V1, float Scalar)
    {
        Vector3 Temp = new Vector3(V1.x * Scalar, V1.y * Scalar, V1.z * Scalar);
        return Temp;
    }
    public static Vector3 VectorDivide(Vector3 V1, float Divisor)
    {
        Vector3 Temp = new Vector3(V1.x /Divisor, V1.y / Divisor, V1.z / Divisor);
        return Temp;
    }
    public static Vector3 VectorNormalize(Vector3 V1)
    {
        Vector3 Temp = VectorDivide(V1, VectorLength(V1));
        return Temp;
    }
    public static float DotProduct(Vector3 v1, Vector3 v2)
    {
        float temp = (v1.x * v2.x + v1.y * v2.y + v1.z * v2.z);
        return (temp);
    }
    public static float DotProduct(Vector3 v1, Vector3 v2, bool Normalize = true)
    {
        if (Normalize == true)
        {
            v1.Normalize();
            v2.Normalize();
        }
        float temp = (v1.x * v2.x + v1.y * v2.y + v1.z * v2.z);
        return (temp);
    }
    public static float VectorAngle(Vector2 V1)
    {
        float Temp = Mathf.Atan(V1[1] / V1[0]);
        return Temp;
    }
    public static Vector2 Direction(float Angle)
    {
        Vector2 V1 = new Vector2(Mathf.Cos(Angle), Mathf.Sin(Angle));
        return V1;
    }
    public static Vector3 EulerToDirection(Vector3 EulerAngle)
    {
        Vector3 Temp = new Vector3();
        Temp.x = Mathf.Cos(EulerAngle.y) * Mathf.Cos(EulerAngle.x);
        Temp.y = Mathf.Sin(EulerAngle.x);
        Temp.z = Mathf.Cos(EulerAngle.x) * Mathf.Sin(EulerAngle.y);
        return Temp;

    }
    public static float DegToRad(float degree)
    {
        
        float temp = degree * Mathf.PI / 180.0f;
        return temp;
    }
    public static Vector3 CrossProduct(Vector3 V1, Vector3 V2)
    {
        //Cx = AyBz – AzBy
        // Cy = AzBx – AxBz
        // Cz = AxBy – AyBx

        Vector3 Temp = new Vector3();
        Temp.x = (V1.y * V2.z) - (V1.z * V2.y);
        Temp.y = (V1.z * V2.x) - (V1.x * V2.z);
        Temp.z = (V1.x * V2.y) - (V1.y * V2.x);
        return Temp;
    }
    public static Vector3 LERP(Vector3 V1, Vector3 V2, float t)
    {
        Vector3 Temp;
        Vector3 Temp1;
        Vector3 Temp2;

        Temp1 = VectorMultiply(V1, (1 - t));
        Temp2 = VectorMultiply(V2, t);
        Temp = VectorAdd(Temp1, Temp2);
        return Temp;

    }
}


