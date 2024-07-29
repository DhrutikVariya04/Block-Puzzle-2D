using UnityEngine;

public class GridGenerate : MonoBehaviour
{
    [SerializeField]
    GameObject SpawnImage;

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                var block = Instantiate(SpawnImage, new Vector2(i, j), Quaternion.identity);
                block.transform.SetParent(transform, false);

            }
        }

    }

    void Update()
    {

    }
}
