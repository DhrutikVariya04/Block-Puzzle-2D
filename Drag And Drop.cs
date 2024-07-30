using System;
using UnityEngine;

public class Drag_And_Drop : MonoBehaviour
{
    Piece_Script pickedObject = null;
    public GridGenerate grid;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 offset = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 MousePos2D = new Vector2(offset.x, offset.y);

            var Hit = Physics2D.Raycast(MousePos2D, Vector2.zero);

            if (Hit.collider != null)
            {
                if (Hit.transform.tag == "MainPiece")
                {
                    pickedObject = Hit.transform.gameObject.GetComponent<Piece_Script>();
                }
            }
        }

        if (Input.GetMouseButton(0))
        {
            if (pickedObject != null)
            {
                Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                pickedObject.Move(newPosition.x, newPosition.y);

                if (grid.inRange(newPosition))
                {
                    Vector2Int pos = converToVector2Int(newPosition);
                    grid.Highlight(pos);
                    grid.Sprite = pickedObject.gameObject.GetComponent<SpriteRenderer>().sprite;
                }
                else
                {
                    grid.clearHighlight();
                }             

            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (pickedObject != null)
            {
                pickedObject.MoveToOriginalPos();
            }
            pickedObject = null;
            grid.clearHighlight();
        }
    }

    private Vector2Int converToVector2Int(Vector2 pos)
    {
        return new Vector2Int((int)(pos.x + .5f), (int)(pos.y + .5f));
    }
}