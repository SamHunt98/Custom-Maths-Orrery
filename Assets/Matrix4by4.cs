
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Matrix4by4 
{
    public float[,] values;


   
    //constructor for creating a 4x4 matrix 
    public Matrix4by4(Vector4 column1, Vector4 column2, Vector4 column3, Vector4 column4)
    {
        values = new float[4, 4];

        //Column1
        values[0, 0] = column1.x;
        values[1, 0] = column1.y;
        values[2, 0] = column1.z;
        values[3, 0] = column1.w;

        //Column2
        values[0, 1] = column2.x;
        values[1, 1] = column2.y;
        values[2, 1] = column2.z;
        values[3, 1] = column2.w;

        //Column3
        values[0, 2] = column3.x;
        values[1, 2] = column3.y;
        values[2, 2] = column3.z;
        values[3, 2] = column3.w;

        //Column4
        values[0, 3] = column4.x;
        values[1, 3] = column4.y;
        values[2, 3] = column4.z;
        values[3, 3] = column4.w;

    }

    public Matrix4by4(Vector3 column1, Vector3 column2, Vector3 column3, Vector3 column4)
    {
        values = new float[4, 4];

        //Column1
        values[0, 0] = column1.x;
        values[1, 0] = column1.y;
        values[2, 0] = column1.z;
        values[3, 0] = 0;

        //Column2
        values[0, 1] = column2.x;
        values[1, 1] = column2.y;
        values[2, 1] = column2.z;
        values[3, 1] = 0;

        //Column3
        values[0, 2] = column3.x;
        values[1, 2] = column3.y;
        values[2, 2] = column3.z;
        values[3, 2] = 0;

        //Column4
        values[0, 3] = column4.x;
        values[1, 3] = column4.y;
        values[2, 3] = column4.z;
        values[3, 3] = 1;
    }

    public static Vector4 operator *(Matrix4by4 lhs, Vector4 vector)
    {
        //overriden operator for multiplying a matrix by a vector4
        Vector4 result = new Vector4();
        vector.w = 1;
        result.x = lhs.values[0, 0] * vector.x + lhs.values[0, 1] * vector.y + lhs.values[0, 2] * vector.z + lhs.values[0, 3] * vector.w;
        result.y = lhs.values[1, 0] * vector.x + lhs.values[1, 1] * vector.y + lhs.values[1, 2] * vector.z + lhs.values[1, 3] * vector.w;
        result.z = lhs.values[2, 0] * vector.x + lhs.values[2, 1] * vector.y + lhs.values[2, 2] * vector.z + lhs.values[2, 3] * vector.w;
        result.w = lhs.values[3, 0] * vector.x + lhs.values[3, 1] * vector.y + lhs.values[3, 2] * vector.z + lhs.values[3, 3] * vector.w;
        return result;
    }
    public static Matrix4by4 operator *(Matrix4by4 matrix1, Matrix4by4 matrix2)
    {
        //overriden operator for multiplying a matrix by another matrix
        Matrix4by4 matrixReturn = new Matrix4by4(new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0));

        matrixReturn.values[0, 0] = matrix1.values[0, 0] * matrix2.values[0, 0] + matrix1.values[0, 1] * matrix2.values[1, 0] + matrix1.values[0, 2] * matrix2.values[2, 0] + matrix1.values[0, 3] * matrix2.values[3, 0];
        matrixReturn.values[0, 1] = matrix1.values[0, 0] * matrix2.values[0, 1] + matrix1.values[0, 1] * matrix2.values[1, 1] + matrix1.values[0, 2] * matrix2.values[2, 1] + matrix1.values[0, 3] * matrix2.values[3, 1];
        matrixReturn.values[0, 2] = matrix1.values[0, 0] * matrix2.values[0, 2] + matrix1.values[0, 1] * matrix2.values[1, 2] + matrix1.values[0, 2] * matrix2.values[2, 2] + matrix1.values[0, 3] * matrix2.values[3, 2];
        matrixReturn.values[0, 3] = matrix1.values[0, 0] * matrix2.values[0, 3] + matrix1.values[0, 1] * matrix2.values[1, 3] + matrix1.values[0, 2] * matrix2.values[2, 3] + matrix1.values[0, 3] * matrix2.values[3, 3];

        matrixReturn.values[1, 0] = matrix1.values[1, 0] * matrix2.values[0, 0] + matrix1.values[1, 1] * matrix2.values[1, 0] + matrix1.values[1, 2] * matrix2.values[2, 0] + matrix1.values[1, 3] * matrix2.values[3, 0];
        matrixReturn.values[1, 1] = matrix1.values[1, 0] * matrix2.values[0, 1] + matrix1.values[1, 1] * matrix2.values[1, 1] + matrix1.values[1, 2] * matrix2.values[2, 1] + matrix1.values[1, 3] * matrix2.values[3, 1];
        matrixReturn.values[1, 2] = matrix1.values[1, 0] * matrix2.values[0, 2] + matrix1.values[1, 1] * matrix2.values[1, 2] + matrix1.values[1, 2] * matrix2.values[2, 2] + matrix1.values[1, 3] * matrix2.values[3, 2];
        matrixReturn.values[1, 3] = matrix1.values[1, 0] * matrix2.values[0, 3] + matrix1.values[1, 1] * matrix2.values[1, 3] + matrix1.values[1, 2] * matrix2.values[2, 3] + matrix1.values[1, 3] * matrix2.values[3, 3];

        matrixReturn.values[2, 0] = matrix1.values[2, 0] * matrix2.values[0, 0] + matrix1.values[2, 1] * matrix2.values[1, 0] + matrix1.values[2, 2] * matrix2.values[2, 0] + matrix1.values[2, 3] * matrix2.values[3, 0];
        matrixReturn.values[2, 1] = matrix1.values[2, 0] * matrix2.values[0, 1] + matrix1.values[2, 1] * matrix2.values[1, 1] + matrix1.values[2, 2] * matrix2.values[2, 1] + matrix1.values[2, 3] * matrix2.values[3, 1];
        matrixReturn.values[2, 2] = matrix1.values[2, 0] * matrix2.values[0, 2] + matrix1.values[2, 1] * matrix2.values[1, 2] + matrix1.values[2, 2] * matrix2.values[2, 2] + matrix1.values[2, 3] * matrix2.values[3, 2];
        matrixReturn.values[2, 3] = matrix1.values[2, 0] * matrix2.values[0, 3] + matrix1.values[2, 1] * matrix2.values[1, 3] + matrix1.values[2, 2] * matrix2.values[2, 3] + matrix1.values[2, 3] * matrix2.values[3, 3];

        matrixReturn.values[3, 0] = matrix1.values[1, 0] * matrix2.values[0, 0] + matrix1.values[3, 1] * matrix2.values[1, 0] + matrix1.values[3, 2] * matrix2.values[2, 0] + matrix1.values[3, 3] * matrix2.values[3, 0];
        matrixReturn.values[3, 1] = matrix1.values[1, 0] * matrix2.values[0, 1] + matrix1.values[3, 1] * matrix2.values[1, 1] + matrix1.values[3, 2] * matrix2.values[2, 1] + matrix1.values[3, 3] * matrix2.values[3, 1];
        matrixReturn.values[3, 2] = matrix1.values[1, 0] * matrix2.values[0, 2] + matrix1.values[3, 1] * matrix2.values[1, 2] + matrix1.values[3, 2] * matrix2.values[2, 2] + matrix1.values[3, 3] * matrix2.values[3, 2];
        matrixReturn.values[3, 3] = matrix1.values[1, 0] * matrix2.values[0, 3] + matrix1.values[3, 1] * matrix2.values[1, 3] + matrix1.values[3, 2] * matrix2.values[2, 3] + matrix1.values[3, 3] * matrix2.values[3, 3];

        return matrixReturn;
    }

    public Matrix4by4 InverseTrans(Matrix4by4 m)
    {
        Matrix4by4 rv = Matrix4by4.Identity; //=// new Matrix4by4(Vector4.zero, Vector4.zero, Vector4.zero, Vector4.zero);
        rv.values = m.values;
        rv.values[0, 3] = -m.values[0, 3];
        rv.values[1, 3] = -m.values[1, 3];
        rv.values[2, 3] = -m.values[2, 3];
        return rv;
    }

    //Return a column specified by i in a 4x4 matrix
    public Vector4 GetRow(short i)
    {
        Vector4 temp = Vector4.zero;

        temp[0] = values[i, 0];
        temp[1] = values[i, 1];
        temp[2] = values[i, 2];
        temp[3] = values[i, 3];
        return temp;
    }
    public Matrix4by4 InverseRotation()
    {
        return new Matrix4by4(GetRow(0), GetRow(1), GetRow(2), GetRow(3));
    }
    public Matrix4by4 ScaleInverse()
    {
        Matrix4by4 rv = Identity;
        rv.values[0, 0] = 1.0f / values[0, 0]; //Invert the scale in 1/A
        rv.values[1, 1] = 1.0f / values[1, 1]; //1/B
        rv.values[2, 2] = 1.0f / values[2, 2]; //1/C
        return rv;
    }

    
    public static Matrix4by4 Identity
    {
        get
        {
            return new Matrix4by4(
                new Vector4(1, 0, 0, 0),
                new Vector4(0, 1, 0, 0),
                new Vector4(0, 0, 1, 0),
                new Vector4(0, 0, 0, 1));
        }
    }



}
public class myAABB
{
    Vector3 MinExtent;
    Vector3 MaxExtent;
    //used to create boundary box collision
    public myAABB(Vector3 Min, Vector3 Max)
    {
        MaxExtent = Max;
        MinExtent = Min;
    }
    public float Top
    {
        get { return MaxExtent.y; }
    }
    public float Bottom
    {
        get { return MinExtent.y; }
    }
    public float Left
    {
        get { return MinExtent.x; }
    }
    public float Right
    {
        get { return MaxExtent.x; }
    }
    public float Front
    {
        get { return MaxExtent.z; }
    }
    public float Back
    {
        get { return MinExtent.z; }
    }

    public static bool Intersects(myAABB b1, myAABB b2)
    {
        //checks each individual face in the bounding box to see if there are intersections
        return !(b2.Left > b1.Right
                || b2.Right < b1.Left
                || b2.Top < b1.Bottom
                || b2.Bottom > b1.Top
                || b2.Back > b1.Front
                || b2.Front < b1.Back);
    }
    public static bool LineIntersection(myAABB box, Vector3 StartPoint, Vector3 EndPoint, out Vector3 IntersectionPoint)
    {
        //define initial lowest and highest 
        float Lowest = 0.0f;
        float Highest = 1.0f;

        //default value for intersection point is needed
        IntersectionPoint = Vector3.zero;

        //we do an intersection check on every axis by resuing the IntersectingAxis function
        if (!IntersectingAxis(Vector3.right, box, StartPoint, EndPoint, ref Lowest, ref Highest))
            return false;
        if (!IntersectingAxis(Vector3.up, box, StartPoint, EndPoint, ref Lowest, ref Highest))
            return false;
        if (!IntersectingAxis(Vector3.forward, box, StartPoint, EndPoint, ref Lowest, ref Highest))
            return false;
        //caulculate intersection point through interpolation
        IntersectionPoint = VectorMaths.LERP(StartPoint, EndPoint, Lowest);
        return true;
    }
    public static bool IntersectingAxis(Vector3 Axis, myAABB box, Vector3 StartPoint, Vector3 EndPoint, ref float Lowest, ref float Highest)
    {
        //calculate minimum and maximum based on current axis
        float Minimum = 0.0f, Maximum = 1.0f;
        if(Axis == Vector3.right)
        {
            Minimum = (box.Left - StartPoint.x) / (EndPoint.x - StartPoint.x);
            Maximum= (box.Right - StartPoint.x) / (EndPoint.x - StartPoint.x);
        }
        else if (Axis == Vector3.up)
        {
            Minimum = (box.Bottom - StartPoint.y) / (EndPoint.y - StartPoint.y);
            Maximum = (box.Top - StartPoint.y) / (EndPoint.y - StartPoint.y);
        }
        else if (Axis == Vector3.forward)
        {
            Minimum = (box.Back - StartPoint.z) / (EndPoint.z - StartPoint.z);
            Maximum = (box.Front - StartPoint.z) / (EndPoint.z - StartPoint.z);
        }
        if(Maximum < Minimum)
        {
            //swap the values
            float temp = Maximum;
            Maximum = Minimum;
            Minimum = temp;
        }
        //eliminate non-intersections early
        if (Maximum < Lowest)
            return false;
        if (Minimum > Highest)
            return false;

        Lowest = Mathf.Max(Minimum, Lowest);
        Highest = Mathf.Min(Maximum, Highest);

        if (Lowest > Highest)
            return false;

        return true;
    }
}


