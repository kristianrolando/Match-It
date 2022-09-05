using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Core;
using Match.PubSub;
using System;

public class TileObject : MonoBehaviour
{
    public InputRaycast input;
    public TileGroup tileGroup;

    public GameObject[,] tiles;

    public GameObject[] tilePref;

    int indexTile1, indexTile2;
    public bool input1 = false, input2 = false;

  
    void Load()
    {
        string t = "fruit";
        
        for(int i = 0; i < tilePref.Length; i++)
        {
            tilePref[i] = Resources.Load<GameObject>(t + "/" + t + "_" + i );
        }
    }
    private void Start()
    {
        //tilePref = new GameObject[tileGroup.xSize];
        //Load();
        tiles = new GameObject[tileGroup.xSize, tileGroup.ySize];
        input = GetComponent<InputRaycast>();
        Subscriber();
    }

    
    void Match(MatchGotClick message)
    {
        if (!input1)
        {
            indexTile1 = message.index;
            input1 = true;
            input2 = false;
        }
        else if (input1 && !input2)
        {
            indexTile2 = message.index;
            input2 = true;
            if (indexTile1 == indexTile2)
            {
                RemoveMatchObj();
            }
            input1 = false;
            input2 = false;
        }
    }
    void RemoveMatchObj()
    {
        Object[] obj = tileGroup.gameObject.GetComponentsInChildren<Object>();
        for (int i = 0; i < obj.Length; i++)
        {
            if (obj[i].index == indexTile1)
            {
                Destroy(obj[i].gameObject);
                PublishSubscribe.Instance.Publish<AddCoinMessage>(new AddCoinMessage());
            }
        }
    }


    private void OnDestroy()
    {
        UnSubscriber();
    }
    void Subscriber()
    {
        PublishSubscribe.Instance.Subscribe<MatchGotClick>(Match);
    }
    void UnSubscriber()
    {
        PublishSubscribe.Instance.Unsubscribe<MatchGotClick>(Match);
    }

}
