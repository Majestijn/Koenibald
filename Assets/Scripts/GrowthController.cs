using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthController : MonoBehaviour
{

    private int counter;
    private bool up;
    void Start()
    {
        counter = 0;
        up = true;
    }

    void Update()
    {
        if (up)
        {
            counter++;
            transform.localScale += new Vector3(0.003f, 0.003f, 0.003f);
        }
        else if (!up)
        {
            counter--;
            transform.localScale -= new Vector3(0.003f, 0.003f, 0.003f);
        }

        if (counter == 40)
        {
            up = false;
        }
        else if (counter == 0)
        {
            up = true;
        }
    }
}

