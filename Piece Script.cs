using System;
using UnityEngine;
using UnityEngine.UI;

public class Piece_Script : MonoBehaviour
{
    Vector2 startPosition;
    HorizontalLayoutGroup PieceSpace;

    internal void Move(float x, float y)
    {
        transform.position = new Vector2(x, y);
    }

    internal void MoveToOriginalPos()
    {
        transform.position = startPosition;
        PieceSpace.childAlignment = TextAnchor.MiddleLeft;
        PieceSpace.childAlignment = TextAnchor.MiddleCenter;
    }

    void Start()
    {
       startPosition  = transform.position;
    }

    void Update()
    {
        PieceSpace = GetComponentInParent<HorizontalLayoutGroup>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("Hello");
    }
}
