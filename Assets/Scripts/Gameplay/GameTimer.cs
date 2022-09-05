using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Core;
using Match.PubSub;
using TMPro;


namespace Match.GameTimer
{
    public class GameTimer : MonoBehaviour
    {
        [SerializeField]
        float timerGameplay = 20f;
        [SerializeField]
        TextMeshProUGUI timerText;
        float timer;
        bool timeActive;
        private void Start()
        {
            timeActive = true;
        }

        void Update()
        {
            if (timeActive)
                CountDown();
        }
        void CountDown()
        {
            timerGameplay -= Time.deltaTime;
            timer = Mathf.Round(timerGameplay);
            timerText.text = timer.ToString();
            if (timerGameplay <= 0)
            {
                timeActive = false;
                PublishSubscribe.Instance.Publish<TimeOver>(new TimeOver());
            }
        }
    }
}

