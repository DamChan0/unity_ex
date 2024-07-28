using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newSpanwer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject[] prefab;
    public bool RandomOn = false;
    public int MaxSpawn = 10;
    private List<GameObject> spawnList = new List<GameObject>();
    [SerializeField]
    private void Awake()
    {
        genObject();

    }



    void genObject()
    {

        if (!RandomOn)
        {
            for (int Count = 0; Count < MaxSpawn; Count++)
            {

                float offset = 0;
                if (Count != 0)
                {
                    float boxSize = spawnList[Count - 1].GetComponent<BoxCollider2D>().size.x;
                    offset = spawnList[Count - 1].transform.position.x + boxSize / 2;
                }

                int index = Random.Range(0, prefab.Length);
                //get prefab's BoxCollider2D's  size
                BoxCollider2D box = prefab[index].GetComponent<BoxCollider2D>();
                float x = box.size.x;
                Vector3 pos = new Vector3(offset + x / 2, 0, 0); // Adjust position to account for the new object's width
                GameObject newObject = Instantiate(prefab[index], pos, Quaternion.identity);
                spawnList.Add(newObject); // Add the instantiated object to the spawnList

                // Vector3 pos = new Vector3(-4.5f + i, 0, 0);
                // Quaternion rotation = Quaternion.Euler(0, 0, i * 10);

                // Instantiate(prefab, pos, rotation);
            }
        }

        else
        {
            for (int i = 0; i < MaxSpawn; i++)
            {
                int index = Random.Range(0, prefab.Length);
                float x = Random.Range(-5, 5);
                float y = Random.Range(-5, 5);
                Vector3 pos = new Vector3(x, y, 0);
                Instantiate(prefab[index], pos, Quaternion.identity);

            }
        }


    }
}


