using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculator : MonoBehaviour {

    // Use this for initialization
    void Start() {
        Debug.Log("超几何分布(4,10,50,99) = " + HypDist(7, 13, 39, 99));//Bug exist.
                                                                        //Debug.Log(Choices(9, 6));//Succeed.
    }

    // Update is called once per frame
    void Update() {

    }

    /// <summary>
    /// Using to calculate Hypergeometric distribution(超几何分布).
    /// </summary>
    /// <returns></returns>
    private decimal HypDist(ulong k, ulong n, ulong m, ulong N)
    {
        ulong a = _nCm(m, k);
        ulong b = _nCm(N - m, n - k);
        decimal c = (decimal)(a * b);
        ulong d = _nCm(N, n);
        //return (Choices(m, k) * Choices(N - m, n - k)) / Choices(N, n);
        //Debug.Log("_nCm(m, k) = " + a);
        //Debug.Log("_nCm(N - m, n - k) = " + b);
        //Debug.Log("a * b = " + c);
        //Debug.Log("_nCm(N, n) = " + d);
        //Debug.Log("c / d = " + c / d);
        return 1-(c / d);
    }

    /*
    /// <summary>
    /// Using to calculate Binomial coefficient(二項式係數/組合/選擇).
    /// </summary>
    /// <param name="n"></param>
    /// <param name="k"></param>
    /// <returns></returns>
    private ulong Choices(ulong n, ulong k)
    {
        return Factorial(n) / (Factorial(k) * Factorial(n - k));
        Debug.Log("Choices is running.");
    }

    /// <summary>
    /// Using to calculate Factorial(階乗).
    /// </summary>
    /// <param name="x"></param>
    /// <returns></returns>
    private ulong Factorial(ulong x)
    {
        if (x > 0)
        {
            ulong n = 1;
            for (ulong i = 2; i <= x; i++)
            {
                n *= i;
            }
            Debug.Log("Factorial is returned.");
            Debug.Log(n);
            return n;
        }
        else
        {
            Debug.Log("Factorial is 0.");
            return 1;
        }
    }*/

    
    private ulong _nCm(ulong n,ulong m)
    {
        if (m == 0) return 1;
        if (n == 0) return 0;
        return n * _nCm(n - 1, m - 1) / m;
    }
}
