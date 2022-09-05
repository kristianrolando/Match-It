using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Core;
using Match.PubSub;

public class InputRaycast : MonoBehaviour
{

    private void Update()
    {
        InputPlayer();
    }

    void InputPlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D click = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);


            if (click.collider != null)
            {
                IClick cl = click.collider.GetComponent<IClick>();
                if (cl != null)
                {
                    PublishSubscribe.Instance.Publish<MatchGotClick>(new MatchGotClick(cl.Click()));
                    Debug.Log("Publish");
                }
            }
        }
    }
}
