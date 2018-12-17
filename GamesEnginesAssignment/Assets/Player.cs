using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


    public Tunnell pipeSystem;
    private float distanceTraveled;

    public float velocity;

    private Wormhole currentPipe;

    private void Start()
    {
        //start at the first pipe of the system
        currentPipe = pipeSystem.SetupFirstPipe();
    }

    private void Update()
    {
        //distance that it has traveled increases with time to change effects
        float delta = velocity * Time.deltaTime;
        distanceTraveled += delta;
    }
}
