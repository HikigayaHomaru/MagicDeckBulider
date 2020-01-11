using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class testBook : MonoBehaviour
{
    string filePath;
    FileInfo fileInfo;
    StreamWriter streamWriter;

    // Start is called before the first frame update
    void Start()
    {
        filePath = Application.dataPath + @"\Data\testBook.csv";
        //　ファイルが存在しなければ作成
        if (!File.Exists(filePath))
        {
            Debug.Log("2.5");
            using (File.Create(filePath)) { }
        }

        fileInfo = new FileInfo(filePath);

        //Debug.Log("3");
        //配列の要素をファイルに書き込み
        //string[] myStringArray = { "あいうえお", "かきくけこ", "さしすせそ" };
        //File.WriteAllLines(filePath, myStringArray);
        //同上
        //string myString2 = "あいうえお\nかきくけこ\nさしすせそ\nたちつてと\nなにぬねの";
        //File.WriteAllText(filePath, myString2);
        //ファイルの末尾に文字列を追記
        //File.AppendAllText(filePath, "\nHello World");
        //ファイルがすでに存在する場合は末尾から書き込む
        //StreamWriter streamWriter = File.AppendText(filePath);
        //インスタンス化する時に第1引数にファイルのパスを指定し、第2引数に追記するかどうかのbool値を指定します。
        //第2引数がない、もしくはfalseの時はファイルに上書きをします。
        //StreamWriter streamWriter = new StreamWriter(filePath, append: true);
        //参考：https://gametukurikata.com/csharp/readwritefile

        //Debug.Log("OK!");
        //参考：https://teratail.com/questions/134584
        //streamWriter = new StreamWriter(filePath, append: false);

        var fs = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
        var sr = new StreamWriter(fs, append: false);



        streamWriter = fileInfo.AppendText();
        writerHypDist();
    }

    public void writerHypDist()
    {
        ulong k = 1;
        //抽取数
        ulong n = 5;
        //合格样本
        ulong m = 10;
        //样本总数
        ulong N = 100;

        decimal result = Calculator.C_HypDist(k, n, m, N);
        
        streamWriter.Write("k" + k + "=" + result);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
