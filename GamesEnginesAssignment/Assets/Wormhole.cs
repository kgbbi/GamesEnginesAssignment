using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wormhole : MonoBehaviour
{

    //A tunnel section is a partial circle. Or a partial torus in 3D
    public float curveRadius, pipeRadius; //A torus is defined by two radiuses
    public int curveSegmentCount, pipeSegmentCount; //i will use a mesh to create the pipe's surface

    private Vector3 GetPointOnTorus(float u, float v) //find points on the surface using x = (R + r cos v) cos u
        //y = (R + r cos v) sin u
        //z = r cos v
    {
        Vector3 p;
        float r = (curveRadius + pipeRadius * Mathf.Cos(v));
        p.x = r * Mathf.Sin(u);
        p.y = r * Mathf.Cos(u);
        p.z = pipeRadius * Mathf.Sin(v);
        return p;
    }


    private void OnDrawGizmos() //test whether torus displays
    {
        float vStep = (2f * Mathf.PI) / pipeSegmentCount;
        float uStep = (2f * Mathf.PI) / curveSegmentCount;

        for (int u = 0; u < curveSegmentCount; u++)
        {
            //test for entire torus
            for (int v = 0; v < pipeSegmentCount; v++)
            {
                Vector3 point = GetPointOnTorus(u * uStep, v * vStep);
                Gizmos.color = new Color(
                    1f,
                    (float) v / pipeSegmentCount,
                    (float) u / curveSegmentCount);
                Gizmos.DrawSphere(point, 0.1f);
            }
        }
    }

    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;

    private void Awake()
    {
        //create the mesh when the object awakens
        GetComponent<MeshFilter>().mesh = mesh = new Mesh();
        mesh.name = "Wormhole";
        SetVertices();
        SetTriangles();
    }

    private void SetVertices() { }

    private void SetTriangles() { }
}
