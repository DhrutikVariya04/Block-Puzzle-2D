using DG.Tweening;
using UnityEngine;

public class Piece_Script : MonoBehaviour
{
    Vector3 startPosition;

    internal void placeBlock(Vector2 Pos)
    {
        transform.position = new Vector3(Pos.x, Pos.y);
    }

    internal void Move(float x, float y)
    {
        transform.position = new Vector2(x, y);
    }

    internal void MoveToOriginalPos()
    {
        transform.DOMove(startPosition,.25f);
        //transform.position = startPosition;
    }

    private void Start()
    {
         startPosition = transform.position;
    }

}
