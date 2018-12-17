using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wormhole : MonoBehaviour {

    //A tunnel section is a partial circle. Or a partial torus in 3D
    public float curveRadius, pipeRadius; //A torus is defined by two radiuses
    public int curveSegmentCount, pipeSegmentCount;//i will use a mesh to create the pipe's surface
}
