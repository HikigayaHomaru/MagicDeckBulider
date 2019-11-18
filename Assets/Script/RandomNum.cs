using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNum : MonoBehaviour
{
    public string formula;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int Aabcdefg()
    {
        int x = 0;
        float y = 999f;
        float yan = 0f;

        while(y > yan)
        {
            x = Random.Range(0, 10);
            y = Random.value;

            switch (formula)
            {
                case "Benford":
                    yan = Benford(x);
                    break;
            }
        }

        return x;
    }

    public float Benford(int x)
    {
        float result = -1;
        result = Mathf.Log10(x);
        return result;
    }
}
