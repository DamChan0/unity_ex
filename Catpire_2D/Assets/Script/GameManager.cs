using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    public static GameManager instance;
    // Update is called once per frame

    private void Awake()
    {
        instance = this;

    }
    void Update()
    {

    }
}
