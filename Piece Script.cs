using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece_Script : MonoBehaviour
{
    Vector2 startPosition;

    internal void Move(float x, float y)
    {
        transform.position = new Vector2(x, y);
    }

    internal void MoveToOrignalPos()
    {
        transform.position = startPosition;
    }

    void Start()
    {
        startPosition  = transform.position;
    }

    void Update()
    {
        
    }
}
