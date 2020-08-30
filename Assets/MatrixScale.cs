using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixScale : MonoBehaviour {


    public float Scale;
    Vector3[] ModelSpaceVertices;
    MeshFilter MF;
    void Start () {

        //stores information about current mesh
        MeshFilter MF = GetComponent<MeshFilter>();
        //gets a copy of all vertices
        ModelSpaceVertices = MF.mesh.vertices;
        Vector3[] TransformedVertices = new Vector3[ModelSpaceVertices.Length];
        Matrix4by4 S = new Matrix4by4(new Vector3(1, 0, 0) * Scale, new Vector3(0, 1, 0) * Scale, new Vector3(0, 0, 1) * Scale, Vector3.zero);
        for (int i = 0; i < TransformedVertices.Length; i++)
        {
            TransformedVertices[i] = S * ModelSpaceVertices[i];
        }
        
        MF.mesh.vertices = TransformedVertices;
        MF.mesh.RecalculateNormals();
        MF.mesh.RecalculateBounds();
    }
	

}
