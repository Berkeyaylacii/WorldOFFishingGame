using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public GameObject boat;
    public GameObject sellHigherMarketText;

    public GameObject sellHigherMarket;

    public TextMeshProUGUI totalMoney;

    public float countDuration = 1f;
    float currentValue;
    Coroutine Crt;

    public bool isDecreasing = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(boat.transform.position, sellHigherMarketText.transform.position);
        if (distance < 3f && float.Parse(totalMoney.text.ToString()) >= 10f && isDecreasing == false )
        {
            isDecreasing = true;
            
            DecreaseValue(10f);
            Debug.Log("girdi");
            sellHigherMarketText.SetActive(false);
            sellHigherMarket.SetActive(true);
            isDecreasing = false;
        }
    }

    
    IEnumerator CountTo(float value)
    {
        currentValue = float.Parse((totalMoney.text));   //current value set to Total money

        value += currentValue;
        var rate = Mathf.Abs(value - currentValue) / countDuration;

        while (currentValue != value)
        {
            currentValue = Mathf.MoveTowards(currentValue, value, 1.5f * rate * Time.deltaTime);

            totalMoney.text = (((int)currentValue).ToString());  //TMP text set to new value
            yield return null;
        }

        //isScoreIncreasing = false;
    }

    public void AddValue(float value)
    {
        float target = value;
        if (Crt != null)
            StopCoroutine(Crt);

        Crt = StartCoroutine(CountTo(target));
    }

    public void DecreaseValue(float value)
    {
        float target = -value;
        if (Crt != null)
            StopCoroutine(Crt);

        Crt = StartCoroutine(CountTo(target));
    }
}
