using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Drag_And_Drop : MonoBehaviour
{
    Vector3 offset;
    bool isDragging = false;
    Transform Hello;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isDragging = true;
        }
        
        if(Input.GetMouseButton(0)) 
        {
            if (isDragging)
            {
                Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
                transform.position = new Vector3(newPosition.x, newPosition.y, transform.position.z);
            }
        }

        if(Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
    }
}
