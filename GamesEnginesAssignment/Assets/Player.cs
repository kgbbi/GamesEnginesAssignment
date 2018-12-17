using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    public Tunnell pipeSystem;
    private float distanceTraveled;
    private float deltaToRotation;
    private float systemRotation;
    private Transform environment;
    private float worldRotation;

    public float velocity;

    private Wormhole currentPipe;

    private void Start()
    {
        environment = pipeSystem.transform.parent;
        //start at the first pipe of the system
        currentPipe = pipeSystem.SetupFirstPipe();
        deltaToRotation = 360f / (2f * Mathf.PI * currentPipe.CurveRadius);
        SetupCurrentPipe();
    }

    private void Update()
    {
        //distance that it has traveled increases with time to change effects
        float delta = velocity * Time.deltaTime;
        distanceTraveled += delta;
        //convert the delta into a rotation, used to update the system's orientation.
        SetupCurrentPipe();
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


    private void SetupCurrentPipe()
    {
        deltaToRotation = 360f / (2f * Mathf.PI * currentPipe.CurveRadius);
        worldRotation += currentPipe.RelativeRotation;
        if (worldRotation < 0f)
        {
            worldRotation += 360f;
        }
        else if (worldRotation >= 360f)
        {
            worldRotation -= 360f;
        }
        environment.localRotation = Quaternion.Euler(worldRotation, 0f, 0f);
    }
}
