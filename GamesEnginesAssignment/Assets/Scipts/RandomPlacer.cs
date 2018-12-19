﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPlacer : ItemGenerator
{

    public TunnellItem[] itemPrefabs;

    public override void GenerateItems(Wormhole pipe)
    {
        float angleStep = pipe.CurveAngle / pipe.CurveSegmentCount;
        for (int i = 0; i < pipe.CurveSegmentCount; i++)
        {
            TunnellItem item = Instantiate<TunnellItem>(
                itemPrefabs[Random.Range(0, itemPrefabs.Length)]);
            float pipeRotation =
                (Random.Range(0, pipe.pipeSegmentCount) + 0.5f) *
                360f / pipe.pipeSegmentCount;
            item.Position(pipe, i * angleStep, pipeRotation);
        }
    }
}