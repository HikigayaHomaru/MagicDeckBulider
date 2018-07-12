using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculator : MonoBehaviour {

    public ulong Extrac;//抽取数
    public ulong Manu;//合格样本
    public ulong Num;//样本总数

    // Use this for initialization
    void Start()
    {
        int mode = Mode(Extrac, Manu, Num);
        float fal = 0;
        Debug.Log("期望值为" + Mean(Extrac, Manu, Num));
        Debug.Log("众数为" + mode);
        for(ulong i = 0; i <= Extrac; i++)
        {
            decimal hyp = HypDist(i, Extrac, Manu, Num);
            Debug.Log("超几何分布" + i + "=" + hyp);
            if (i < (ulong)mode)
            {
                fal += (float)hyp;
            }
        }


        Debug.Log("小于" + mode + "概率为" + fal * 100 + "%");


        //Debug.Log("超几何分布(4,10,50,99) = " + HypDist(7, 13, 39, 99));
    }
    // Update is called once per frame
    void Update() {

    }

    /// <summary>
    /// Using to calculate Mode(众数).
    /// </summary>
    /// <returns></returns>
    public int Mode(ulong n, ulong m, ulong N)
    {
        int x = (int)n + 1;
        int y = (int)m + 1;
        int z = (int)N + 2;
        return ((x * y) / z);
    }
        
        
    /// <summary>
    /// Using to calculate Mean(期望值).
    /// </summary>
    /// <param name="n"></param>
    /// <param name="m"></param>
    /// <param name="N"></param>
    /// <returns></returns>
    private float Mean(ulong n, ulong m, ulong N)
    {
        float x = (float)n * (float)m / (float)N;
        return x;
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
        return (c / d);
    }
    
    /// <summary>
    /// Using to calculate Binomial coefficient(二項式係數/組合/選擇).
    /// </summary>
    /// <param name="n"></param>
    /// <param name="m"></param>
    /// <returns></returns>
    private ulong _nCm(ulong n,ulong m)
    {
        if (m == 0) return 1;
        if (n == 0) return 0;
        return n * _nCm(n - 1, m - 1) / m;
    }
}
