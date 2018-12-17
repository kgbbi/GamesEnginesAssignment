using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//creates multiple pipes together to generate the wormhole tunnel effect
public class Tunnell : MonoBehaviour {

    public Wormhole pipePrefab;

    public int pipeCount;

    private Wormhole[] pipes;

    private void Awake()
    {
        pipes = new Wormhole[pipeCount];
        for (int i = 0; i < pipes.Length; i++)
        {
            Wormhole pipe = pipes[i] = Instantiate<Wormhole>(pipePrefab);
            pipe.transform.SetParent(transform, false);
            //tunnells aligned with each other by aligning with the previous one.
            if (i > 0)
            {
                pipe.AlignWith(pipes[i - 1]);
            }
        }
    }
}
