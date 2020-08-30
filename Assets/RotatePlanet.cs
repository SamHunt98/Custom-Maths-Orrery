using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour {
    public float angle = 0;
    float rotAngle;
    public float rotSpeed;
    public float orbitSpeed;
    public float speedScalar;
    public Vector3 positionVector;
    Vector3[] ModelSpaceVertices;
    MeshFilter MF;
    // Use this for initialization
    void Start () {
      
        MeshFilter MF = GetComponent<MeshFilter>();
        ModelSpaceVertices = MF.mesh.vertices;
    }
	
	// Update is called once per frame
	void Update () {
        GameObject controller = GameObject.Find("SpeedController");
        SpeedControl spController = controller.GetComponent<SpeedControl>();
        speedScalar = spController.Speed;
       Rotate();
        orbit();
    }
    //rotates the vertices of the planet model using the custom-made quaternions
    void Rotate()
    {
        Vector3[] TransformedVertices = new Vector3[ModelSpaceVertices.Length];
        rotAngle += Time.deltaTime * rotSpeed * speedScalar;
        Quat Rotation = new Quat(VectorMaths.DegToRad(rotAngle), VectorMaths.VectorNormalize(new Vector3(1, 1, 1)));

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

    void orbit()
    {
        angle += Time.deltaTime * orbitSpeed * speedScalar;
        Quat q = new Quat(angle, new Vector3(0, 1, 0));
        //positionVector is used to set how far from the sun the object orbits
        Vector3 p = positionVector;
        Quat k = new Quat(1.0f, p);
        Quat newk = q * k * q.Inverse();
        Vector3 newp = newk.GetAxis();
        transform.position = newp;
    }
}
