using System;
using UnityEngine;
using UnityEngine.SceneManagement;

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
                    grid.Highlight(pickedObject);
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
                grid.Placeblock(pickedObject);
            }

            pickedObject = null;
            grid.clearHighlight();
        }
    }

    [System.Obsolete]
    public void Setting()
    {
        // For Click Sound  :-
        AudioManager.Audio.ClickSound();

        SceneManager.UnloadScene("Play Screen");

        // This Method For Start Camera And EventListner :-
        Home.home.ActiveListner();
     
    }
}