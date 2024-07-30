using System;
using UnityEngine;
using UnityEngine.UI;

public class Piece_Script : MonoBehaviour
{
    Vector2 startPosition;

    internal void Move(float x, float y)
    {
        transform.position = new Vector2(x, y);
    }

    internal void MoveToOriginalPos()
    {
        transform.position = startPosition;
    }

    void Start()
    {
       startPosition  = transform.position;       
    }
}
