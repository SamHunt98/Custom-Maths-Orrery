using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatescript : MonoBehaviour {

    //didnt use this script in the end, was replaced with the individual rotation scripts for planets and moons

    Vector3[] ModelSpaceVertices;
    MeshFilter MF;
    public Vector3 OrbitRotation;
    public float orbitSpeed;
    public float yawAngle;
    public Vector3 orbitDistance;
    public Vector3 newPos;
    public Vector3 worldPos;
    public float Scale;
    public Vector3 offset;
    public float SpeedScalar;

    void Start()
    {
        //stores information about current mesh
        MeshFilter MF = GetComponent<MeshFilter>();
        //gets a copy of all vertices
        ModelSpaceVertices = MF.mesh.vertices;
    }
    void Update () {

        PlanetOrbit();

    }
  
     void PlanetOrbit()
    {
        GameObject controller = GameObject.Find("SpeedController");
        SpeedControl spController = controller.GetComponent<SpeedControl>();
        SpeedScalar = spController.Speed;
        OrbitRotation.y += Time.deltaTime * orbitSpeed * SpeedScalar;
        Vector3[] TransformedVertices = new Vector3[ModelSpaceVertices.Length];
        yawAngle += Time.deltaTime;

        //create the first rotation matrix for individual planet rotation
        Matrix4by4 rollMatrix = new Matrix4by4
            (new Vector3(Mathf.Cos(yawAngle), Mathf.Sin(yawAngle), 0),
            new Vector3(-Mathf.Sin(yawAngle), Mathf.Cos(yawAngle), 0),
            new Vector3(0, 0, 1),
            Vector3.zero);
        Matrix4by4 pitchmatrix = new Matrix4by4(
            new Vector3(1, 0, 0),
            new Vector3(0, Mathf.Cos(yawAngle), Mathf.Sin(yawAngle)),
            new Vector3(0, -Mathf.Sin(yawAngle), Mathf.Cos(yawAngle)),
            Vector3.zero);
        Matrix4by4 yawmatrix = new Matrix4by4(
            new Vector3(Mathf.Cos(yawAngle), 0, -Mathf.Sin(yawAngle)),
            new Vector3(0, 1, 0),
            new Vector3(Mathf.Sin(yawAngle), 0, Mathf.Cos(yawAngle)),
            Vector3.zero);


        //create second rotation matrix for the planet's orbit
        Matrix4by4 OrbitRoll = new Matrix4by4
            (new Vector3(Mathf.Cos(OrbitRotation.z), Mathf.Sin(OrbitRotation.z), 0),
            new Vector3(-Mathf.Sin(OrbitRotation.z), Mathf.Cos(OrbitRotation.z), 0),
            new Vector3(0, 0, 1),
            Vector3.zero);
        Matrix4by4 OrbitPitch = new Matrix4by4(
            new Vector3(1, 0, 0),
            new Vector3(0, Mathf.Cos(OrbitRotation.x), Mathf.Sin(OrbitRotation.x)),
            new Vector3(0, -Mathf.Sin(OrbitRotation.x), Mathf.Cos(OrbitRotation.x)),
            Vector3.zero);
        Matrix4by4 OrbitYaw = new Matrix4by4(
            new Vector3(Mathf.Cos(OrbitRotation.y), 0, -Mathf.Sin(OrbitRotation.y)),
            new Vector3(0, 1, 0),
            new Vector3(Mathf.Sin(OrbitRotation.y), 0, Mathf.Cos(OrbitRotation.y)),
            Vector3.zero);


        Matrix4by4 RotationOfOrbit = OrbitYaw * (OrbitPitch * OrbitRoll);


        Matrix4by4 R = yawmatrix * (pitchmatrix * rollMatrix);


       offset = RotationOfOrbit * orbitDistance;

        newPos = worldPos + offset;

        Matrix4by4 T = new Matrix4by4(new Vector3(1, 0, 0),
            new Vector3(0, 1, 0)
            , new Vector3(0, 0, 1),
            new Vector3(newPos.x + offset.x, newPos.y + offset.y, newPos.z + offset.z));

        Matrix4by4 S = new Matrix4by4(new Vector3(1, 0, 0) * Scale, new Vector3(0, 1, 0) * Scale, new Vector3(0, 0, 1) * Scale, Vector3.zero);
        Matrix4by4 M = T * R * S;

        //Transforms.Position = actualposition;
        for (int i = 0; i < TransformedVertices.Length; i++)
        {
            TransformedVertices[i] = M * ModelSpaceVertices[i];
        }
        MeshFilter MF = GetComponent<MeshFilter>();
        MF.mesh.vertices = TransformedVertices;
        MF.mesh.RecalculateNormals();
        MF.mesh.RecalculateBounds();
    }
}
