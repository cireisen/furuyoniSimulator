using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleGame : MonoBehaviour
{
    public Player me;
    public Player you;
    public GameObject eventQueue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    ///  ī�� ��ο�
    /// </summary>
    public void Draw(Player player, int count)
    {

    }

    /// <summary>
    ///  �⺻�ൿ�� ���� �� �۾�ť�� �̺�Ʈ�� �߰���
    /// </summary>
    public void UseBasicAction(string type)
    {

    }

    public void Test()
    {
        GameObject queue = Instantiate(eventQueue);
        queue.GetComponent<EventQueue>().TestAddTiming(me, you);
    }
}
