using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class factor : MonoBehaviour {

    public Text a;
    float aNum;
    public Text b;
    float bNum;
    public Text c;
    float cNum;
    public Text plusMinus1;
    public Text plusMinus2;
    public Text plusMinus3;

    float aSqrt;
    float cSqrt;

    float aPlusC;
    public Text extra;
    public Text answer;

    private void Start()
    {
        extra.gameObject.SetActive(false);
        answer.gameObject.SetActive(false);
    }

    public void factorManager()
    {
        aNum = float.Parse(a.text.ToString());
        bNum = float.Parse(b.text.ToString());
        cNum = float.Parse(c.text.ToString());
        aSqrt = Mathf.Sqrt(aNum);
        cSqrt = Mathf.Sqrt(cNum);
        Debug.Log(aSqrt + " " + cSqrt);
        factoring();
        //if ((aSqrt % 1 == 0 && cSqrt % 1 == 0) && (plusMinus1.text != "-" && plusMinus3.text != "-"))
        //{
        //    factorTrinomial();
        //} else
        //{
        //    factoring();
        //}
    }

    public void factoring()
    {
        int factorCount = 0;
        int sqrt = (int)Mathf.Ceil(cSqrt * aSqrt);

        // Start from 1 as we want our method to also work when numberToCheck is 0 or 1.
        for (int i = 1; i < sqrt; i++)
        {
            if ((i + i) == bNum)
            {
                Debug.Log("ugh");
            }
            if (cNum % i == 0)
            {
                Debug.Log(cNum % i);
                if ((factorCount + i) == bNum)
                {
                    answer.gameObject.SetActive(true);
                    answer.text = "(x" + "+" + factorCount.ToString() + ")" + " " + "(x" + "+" + i.ToString() + ")";
                } else if (factorCount * 2 == bNum || i * 2 == bNum)
                {
                    answer.gameObject.SetActive(true);
                    answer.text = "(" + aSqrt + "x" + "+" + Mathf.Sqrt(i).ToString() + ")" + " " + "(x" + "+" + factorCount.ToString() + ")";
                }
                Debug.Log(factorCount + " " + i);
                factorCount += 2;
            }
        }

        // Check if our number is an exact square.
        if (sqrt * sqrt == cNum)
        {
            factorCount++;
        }
    }
	
    public void factorDifference()
    {

    }

	public void factorTrinomial()
    {
        aPlusC = aSqrt * (cSqrt * 2);
        if(aPlusC == bNum)
        {
            if (plusMinus2.text == "-")
            {
                answer.gameObject.SetActive(true);
                answer.text = "(" + aSqrt + "x" + "-" + cSqrt + ")" + " " + "(" + aSqrt + "x" + "-" + cSqrt + ")";
            } else
            {
                answer.gameObject.SetActive(true);
                answer.text = "(" + aSqrt + "x" + "+" + cSqrt + ")" + " " + "(" + aSqrt + "x" + "+" + cSqrt + ")";
            }
            extra.gameObject.SetActive(true);
            extra.text = "Trinomial";
        }
	}
}
