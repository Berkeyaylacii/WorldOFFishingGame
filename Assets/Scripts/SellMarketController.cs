using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SellMarketController : MonoBehaviour
{   
    public CatchFish CatchFish;
    public CollectCashAnimation CollectCashAnimation;
    public InterstitialAdController InterstitialAdController;

    public GameObject[] cashes;

    public GameObject sellMarket;
    public GameObject boat;

    public TextMeshPro catchedFishCountText;

    public float sellCount = 0;
    public bool isSellMarketOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        cashes = GameObject.FindGameObjectsWithTag("CashPrefab");
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(boat.transform.position, sellMarket.transform.position);

        if (distance > 3f)
        {
            isSellMarketOpen = false;        
        }

        if (distance < 3f && isSellMarketOpen == false && CatchFish.catchedFishCount > 0) //Increase the score
        {
            isSellMarketOpen = true;

            CollectCashAnimation.CashNumber = int.Parse(catchedFishCountText.text);

            /*for(int i =0; i < cashes.Length; i++)
            {   
                if( i < (cashes.Length)-(int.Parse(boatCapacity.text)) )
                {
                    cashes[(cashes.Length) - i].SetActive(false);
                }             
            } */

            CollectCashAnimation.RewardPileOfCash();

            Debug.Log("All Fish Sold.");

            CatchFish.IncreaseScore();  
            CatchFish.resetCatchedFishCount();
            sellCount = sellCount + 1;
            if(sellCount % 4 == 0)
            {
                InterstitialAdController.ShowAd();
            }
        }
    }

}
