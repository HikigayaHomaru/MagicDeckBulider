using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculator : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Debug.Log("HypDist(4, 10, 40, 100) = " + HypDist(4, 10, 40, 100));//Bug exist.
        //Debug.Log(Choices(9, 6));//Succeed.
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Using to calculate Hypergeometric distribution(超几何分布).
    /// </summary>
    /// <returns></returns>
    private float HypDist(int k, int n, int m, int N)
    {
        return (Choices(m, k) * Choices(N - m, n - k)) / Choices(N, n);
    }


    /// <summary>
    /// Using to calculate Binomial coefficient(二項式係數/組合/選擇).
    /// </summary>
    /// <param name="n"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    private int Choices(int n,int k)
    {
        return Factorial(n) / (Factorial(k) * Factorial(n - k));
        Debug.Log("Choices is running.");
    }

    /// <summary>
    /// Using to calculate Factorial(階乗).
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    private int Factorial(int x)
    {
        if (x > 0)
        {
            int n = 1;
            for (int i = 2; i <= x; i++)
            {
                n *= i;
            }
            //Debug.Log("Factorial is returned.");
            return n;
        }
        else if (x == 0)
        {
            //Debug.Log("Factorial is 0.");
            return 1;
        }
        else
        {
            Debug.Log("Error. Num cant be small then 0.");//Return an Error.
            return -1;
        }
    }
}
