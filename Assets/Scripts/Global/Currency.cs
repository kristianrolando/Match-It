using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Match.PubSub;
using Agate.MVC.Core;

public class Currency : MonoBehaviour
{
    public static Currency instance;

    private void Awake()
    {
        instance = this;
        Debug.Log("coin : " + PlayerPrefs.GetInt("coin"));
        Subscriber();
    }

    public void AddCoin(AddCoinMessage message)
    {
        PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + 5);
        Debug.Log("coin : " + PlayerPrefs.GetInt("coin"));
    }
    public void SpentCoin(int coin)
    {
        if(PlayerPrefs.GetInt("coin") == 0)
        {
            Debug.Log("coin = 0 ");
            return;
        }
        PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") - coin);

    }
    private void OnDestroy()
    {
        UnSubscriber();
    }
    void Subscriber()
    {
        PublishSubscribe.Instance.Subscribe<AddCoinMessage>(AddCoin);
    }
    void UnSubscriber()
    {
        PublishSubscribe.Instance.Unsubscribe<AddCoinMessage>(AddCoin);
    }
}
