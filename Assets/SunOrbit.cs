using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunOrbit : MonoBehaviour {
    
    //unused script 
    //
    //
    //
    float angle = 0;
    float slerpangle = 0;
    float t;
    float ye;
    Vector3[] ModelSpaceVertices;
    MeshFilter MF;
    void Start()
    {
        MeshFilter MF = GetComponent<MeshFilter>();
        ModelSpaceVertices = MF.mesh.vertices;

    }


    void Update()
    {
        transform.position = VectorMaths.LERP(transform.position, new Vector3(10, 0, 0), Time.deltaTime);
    }


    void OrbitPlanet()
    {
        ye += Time.deltaTime * 3;
        Vector3[] orbitVertices = new Vector3[ModelSpaceVertices.Length];
        //create translation matrix
        Matrix4by4 translationMatrix = new Matrix4by4(
            new Vector3(1, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(0, 0, 1),
            new Vector3(ye * 2, 0, ye));

        //transform each individual vertex
        for(int i = 0; i < orbitVertices.Length;i++)
        {
            orbitVertices[i] = translationMatrix * ModelSpaceVertices[i];
        }
        MeshFilter MF = GetComponent<MeshFilter>();

        MF.mesh.vertices = orbitVertices;
        MF.mesh.RecalculateNormals();
        MF.mesh.RecalculateBounds();
    }
    void RotatePlanet() //Same concept just x it by all the vertices e.t.c
    {

        Vector3[] TransformedVertices = new Vector3[ModelSpaceVertices.Length];
        angle += Time.deltaTime * 50;
        Quat Rotation = new Quat(VectorMaths.DegToRad(angle), VectorMaths.VectorNormalize(new Vector3(1, 1, 1)));
   
        for (int i = 0; i < TransformedVertices.Length; i++)
        {
            Quat p = new Quat(ModelSpaceVertices[i]);
            Quat newp = ((Rotation * p) * Rotation.Inverse());
            Vector3 newpos = newp.GetAxisAngle();
            TransformedVertices[i] = newpos;
        }
        // TransformedVertices[0].x = -300;
        MeshFilter MF = GetComponent<MeshFilter>();
        MF.mesh.vertices = TransformedVertices;
        MF.mesh.RecalculateNormals();
        MF.mesh.RecalculateBounds();

    }
}
