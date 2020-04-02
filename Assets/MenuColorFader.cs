using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuColorFader : MonoBehaviour
{
    public float incrementValue;
    private float redValue;
    private bool increasing;

    // Start is called before the first frame update
    void Start()
    {
        redValue = 0;
        increasing = true;
        incrementValue = float.IsNaN(incrementValue) ? 0.01f : incrementValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (redValue < 0.5 && increasing)
        {
            redValue += incrementValue;
            Camera.main.backgroundColor = new Color(redValue, 0, 0);
            if (redValue >= 0.5)
            {
                increasing = false;
            }
        } else if (redValue > 0 && !increasing)
        {
            redValue -= incrementValue;
            Camera.main.backgroundColor = new Color(redValue, 0, 0);
            if (redValue <= 0)
            {
                increasing = true;
            }
        }
    }
}
