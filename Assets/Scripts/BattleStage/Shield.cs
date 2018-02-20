using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Shield : MonoBehaviour
{
    public int shieldPos;
    public bool shieldOn; //true면 쉴드 발동

    void Start()
    {
        shieldPos = 4;
        shieldOn = false;
    }
}

public partial class Shield : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            shieldPos = 0;
        }
        else if (Input.GetKeyDown("w"))
        {
            shieldPos = 1;
        }
        else if (Input.GetKeyDown("e"))
        {
            shieldPos = 2;
        }
    }
}


