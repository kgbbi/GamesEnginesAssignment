using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    public Tunnell pipeSystem;
    private float distanceTraveled;
    private float deltaToRotation;
    private float systemRotation;

    public float velocity;

    private Wormhole currentPipe;

    private void Start()
    {
        //start at the first pipe of the system
        currentPipe = pipeSystem.SetupFirstPipe();
        deltaToRotation = 360f / (2f * Mathf.PI * currentPipe.CurveRadius);
    }

    private void Update()
    {
        //distance that it has traveled increases with time to change effects
        float delta = velocity * Time.deltaTime;
        distanceTraveled += delta;
        //convert the delta into a rotation, used to update the system's orientation.
        systemRotation += delta * deltaToRotation;
        if (systemRotation >= currentPipe.CurveAngle)
        {
            delta = (systemRotation - currentPipe.CurveAngle) / deltaToRotation;
            currentPipe = pipeSystem.SetupNextPipe();
            deltaToRotation = 360f / (2f * Mathf.PI * currentPipe.CurveRadius);
            systemRotation = delta * deltaToRotation;
        }
        pipeSystem.transform.localRotation = Quaternion.Euler(0f, 0f, systemRotation);
    }
}
