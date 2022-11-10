using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventQueue : MonoBehaviour
{
    // �۾� ť ����
    List<Timimg> eventList;
    bool flag;

    // Start is called before the first frame update
    void Awake()
    {
        eventList = new List<Timimg>();
    }

    // Update is called once per frame
    void Update()
    {
        if(flag)
        {
            RunQueue();
        }
    }

    void RunQueue()
    {
        eventList.ForEach((time) =>
        {
            switch(time.effect)
            {
                case "forward":
                    Forward(time.me);
                    break;
                default:
                    break;
            }

        Debug.Log(time.me.aura);
        });

        Destroy(gameObject);
    }

    /// <summary>
    ///  �̺�Ʈť �׽�Ʈ
    /// </summary>
    public void TestAddTiming(Player me, Player you)
    {
        Debug.Log(me);
        Debug.Log(you);
        eventList.Add(new Timimg(me, you, "before", ""));
        eventList.Add(new Timimg(me, you, "effect", "forward"));

        flag = true;
    }

    void Forward(Player player)
    {
        player.aura += 1;
    }

}