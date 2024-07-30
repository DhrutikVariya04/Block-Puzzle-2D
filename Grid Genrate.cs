using System;
using UnityEditor;
using UnityEngine;

public class GridGenerate : MonoBehaviour
{
    GameObject[,] baseBlock ;
    int size = 10;

    [SerializeField]
    GameObject SpawnImage;

    [SerializeField]
    Color highlight;

    public Sprite Sprite,DefaultImage;

    void Start()
    {
        baseBlock = new GameObject[size, size];
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                var block = Instantiate(SpawnImage, new Vector2(i, j), Quaternion.identity);
                block.transform.SetParent(transform, false);
                baseBlock[i, j] = block;
            }
        }

    }

    public void Highlight(Vector2Int pos)
    {
        clearHighlight();
        var block = baseBlock[pos.x, pos.y].GetComponent<SpriteRenderer>();
        //block.color = highlight;
        block.sprite = Sprite;
        block.transform.localScale = Vector3.one;
    }

    public void clearHighlight()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                var block = baseBlock[i, j].GetComponent<SpriteRenderer>();
                //block.color = Color.white;
                block.sprite = DefaultImage;
                block.transform.localScale = new Vector3(1.5f,1.5f,1.5f);
            }
        }
    }

    public bool inRange(Vector2 pos)
    {
        return pos.x > -0.5 && pos.y > -0.5 &&
            pos.x < size - .5 && pos.y < size-.5;
    }
}
