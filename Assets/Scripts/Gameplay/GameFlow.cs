using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Match.PubSub;
using Agate.MVC.Core;
using TMPro;
using UnityEngine.SceneManagement;

public class GameFlow : MonoBehaviour
{
    //public TextMeshProUGUI winText;



    private void Awake()
    {
        Subscriber();
    }
    private void OnDestroy()
    {
        UnSubscriber();
    }

    void SetGameOverStateTime(TimeOver message)
    {
        //winText.text = "lose";
        SceneManager.LoadScene("Home");
    }
    void SetGameOverStateTiles(TilesCleared message)
    {
        //winText.text = "win";
        SceneManager.LoadScene("Home");
    }
    void Subscriber()
    {
        PublishSubscribe.Instance.Subscribe<TimeOver>(SetGameOverStateTime);
        PublishSubscribe.Instance.Subscribe<TilesCleared>(SetGameOverStateTiles);
    }
    void UnSubscriber()
    {
        PublishSubscribe.Instance.Unsubscribe<TimeOver>(SetGameOverStateTime);
        PublishSubscribe.Instance.Unsubscribe<TilesCleared>(SetGameOverStateTiles);
    }
}
