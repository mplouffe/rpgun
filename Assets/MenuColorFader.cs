using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuColorFader : MonoBehaviour
{
    private int redValue;
    private bool increasing;

    // Start is called before the first frame update
    void Start()
    {
        redValue = 0;
        increasing = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (redValue < 50 && increasing)
        {
            redValue++;
            Camera.main.backgroundColor = new Color(redValue, 0, 0);
            if (redValue >= 50)
            {
                increasing = false;
            }
        } else if (redValue > 0 && !increasing)
        {
            redValue--;
            Camera.main.backgroundColor = new Color(redValue, 0, 0);
            if (redValue <= 0)
            {
                increasing = true;
            }
        }
    }
}
