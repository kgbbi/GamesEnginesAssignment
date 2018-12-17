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

    private void SetVertices() //give each quad its own four vertices
    {
        vertices = new Vector3[pipeSegmentCount * curveSegmentCount * 4];
        float uStep = (2f * Mathf.PI) / curveSegmentCount;
        CreateFirstQuadRing(uStep);
        mesh.vertices = vertices;
    }

    private void CreateFirstQuadRing(float u)
    {
        float vStep = (2f * Mathf.PI) / pipeSegmentCount;
        //create two vertices A and B
        Vector3 vertexA = GetPointOnTorus(0f, 0f);
        Vector3 vertexB = GetPointOnTorus(u, 0f);
        //assign  vertices to the quads as it iterates through the segments
        for (int v = 1, i = 0; v <= pipeSegmentCount; v++, i += 4)
        {
            vertices[i] = vertexA;
            vertices[i + 1] = vertexA = GetPointOnTorus(0f, v * vStep);
            vertices[i + 2] = vertexB;
            vertices[i + 3] = vertexB = GetPointOnTorus(u, v * vStep);
        }
    }

    private void SetTriangles()//initialize the triangles. Each quad has two triangles = six vertex indices.
    {
            triangles = new int[pipeSegmentCount * curveSegmentCount * 6];
        //order vertices so triangles show  on the outside of the tunnel.
        for (int t = 0, i = 0; t < triangles.Length; t += 6, i += 4)
            {
                triangles[t] = i;
                triangles[t + 1] = triangles[t + 4] = i + 1;
                triangles[t + 2] = triangles[t + 3] = i + 2;
                triangles[t + 5] = i + 3;
            }

            mesh.triangles = triangles;
        }
}
