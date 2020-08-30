using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quat
{
    //a custom class used to emulate Quaternion rotation

    public float w, x, y, z;

    //constructors
    public Quat(float Angle, Vector3 Axis)
    {
        float halfAngle = Angle / 2;
        w = Mathf.Cos(halfAngle);
        x = Axis.x * Mathf.Sin(halfAngle);
        y = Axis.y * Mathf.Sin(halfAngle);
        z = Axis.z * Mathf.Sin(halfAngle);
    }
    public Quat(Vector3 Axis)
    {
        x = Axis.x;
        y = Axis.y;
        z = Axis.z;
        w = 0;
    }
    public Quat()
    {

    }
    public Vector3 GetAxis()
    {
        return (new Vector3(x, y, z));
    }
   
    public void SetAxis(Vector3 rv)
    {
       
        x = rv.x;
        y = rv.y;
        z = rv.z;
       

    }

    public Quat Inverse()
    {
        Quat rv = new Quat();
        rv.w = w;
        rv.SetAxis((-GetAxis()));
        return rv;
    }
    public Vector4 GetAxisAngle()
    {
        Vector4 rv = new Vector4();
        //inverse cosine to get half angle back
        float halfAngle = Mathf.Acos(w);
        rv.w = halfAngle * 2; // this is the full angle

        //simple calculations to get normal axis back
        rv.x = x / Mathf.Sin(halfAngle);
        rv.y = y / Mathf.Sin(halfAngle);
        rv.z = z / Mathf.Sin(halfAngle);
        return rv;
    }
    public static Quat SLERP(Quat q, Quat r, float t)
    {
        t = Mathf.Clamp(t, 0.0f, 1.0f);

        Quat d = r * q.Inverse();
        Vector4 AxisAngle = d.GetAxisAngle();
        Quat dT = new Quat(AxisAngle.w * t, new Vector3(AxisAngle.x, AxisAngle.y, AxisAngle.z));
        return dT * q;
    }
    //overridden operator for multiplying two quaternions
    public static Quat operator *(Quat R, Quat S)
    {
        Quat RS = new Quat(0, Vector3.zero);
        RS.w = S.w * R.w - VectorMaths.DotProduct(S.GetAxis(), R.GetAxis());
        RS.SetAxis(S.w * R.GetAxis() + R.w * S.GetAxis() + VectorMaths.CrossProduct(R.GetAxis(), S.GetAxis()));
        return RS;
    }
}

