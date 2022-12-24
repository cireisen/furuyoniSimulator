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

    /// <summary>
    ///  ť�� ���� �͵��� 
    /// </summary>
    void RunQueue()
    {
        // TODO: ��� ��ư ��Ȱ��ȭ, �˾� �ݱ�
        eventList.ForEach((time) =>
        {
            Debug.Log(time.effect);
            switch(time.effect)
            {
                case "before":
                    // TODO: �⺻�ൿ�̳� ī�� ��� ���� üũ
                    break;
                case "after":
                    break;
                case "forward":
                    Forward(time.me, time.game);
                    break;
                case "na_01_yurina_o_n_5_s5_1":
                    AddFocus(time.me, 1);
                    break;
                case "na_01_yurina_o_n_5_s5_2":
                    //AddFocus(time.me, 1);
                    break;
                case "na_01_yurina_o_n_1_1":
                    break;
                case "draw":
                    DrawCard(time.me, time.game);
                    break;
                default:
                    break;
            }
        });

        flag = false;

        eventList[0].game.UpdateWindow();
        Destroy(gameObject);
    }

    /// <summary>
    ///  �⺻������ �̺�Ʈť�� �߰�
    /// </summary>
    public void AddBasicActionTiming(Player me, SingleGame game, string type)
    {
        eventList.Add(new Timimg(me, game, "basicAction", "before"));
        eventList.Add(new Timimg(me, game, "basicAction", type));
        eventList.Add(new Timimg(me, game, "basicAction", "after"));
        flag = true;
    }

    public void AddDrawTiming(Player me, Player you, SingleGame game, int count)
    {
        eventList.Add(new Timimg(me, you, game, "drawCard", "before"));
        for(int i = 0; i < count; i++)
        {
            eventList.Add(new Timimg(me, you, game, "drawCard", "draw"));
        }
        eventList.Add(new Timimg(me, you, game, "drawCard", "before"));
        flag = true;
    }

    public void AddCardTiming(Player me, Player you, SingleGame game, Card card)
    {
        eventList.Add(new Timimg(me, you, game, card.cardType, "before"));
        for(int i = 0; i < card.effectList.Count; i++)
        {
            eventList.Add(new Timimg(me, you, game, card.effectList[i].tag, card.effectList[i].effect));
        }
        eventList.Add(new Timimg(me, you, game, card.cardType, "after"));
        flag = true;

    }

    void Forward(Player player, SingleGame game)
    {
        int n = CountAvailableSakura(game.distance, 1);
        if(player.aura + n > player.maxAura)
        {
            return;
        }

        int distance = game.distance;
        int aura = player.aura;

        moveSakura(ref distance, ref aura, 1);

        game.distance = distance;
        player.aura = aura;

        Debug.Log(player.aura);
        Debug.Log(game.distance);
    }


    /// <summary>
    ///  ���߷� �߰�
    /// </summary>
    void AddFocus(Player player, int num)
    {
        // TODO: ���� ������ �� num�� 1 ��� �� �߰�
        if(player.focus + num > 2)
            player.focus = 2;
        else
            player.focus += num;
    }

    void DrawCard(Player player, SingleGame game)
    {
        if (player.deck.Count > 0)
        {
            Card card = player.deck[0];
            player.deck.RemoveAt(0);
            player.hand.Add(card);
            game.SetHandPanel(card);
        }
        else
        {
            // TODO: ������, GetDamage ���?
        }
    }

    int CountAvailableSakura(int startLocation, int count)
    {
        int n = count;
        if(startLocation <= n)
        {
            n = startLocation;
        }

        return n;
    }

    void moveSakura(ref int startLocation, ref int endLocation, int count)
    {
        if(startLocation <= count)
        {
            count = startLocation;
        }

        startLocation -= count;
        endLocation += count;
    }

    void Attack(Player me, Player you, int auraDamage, int lifeDamage)
    {
        //TODO : ���� ����
        
    }

    void GetDamage(Player me, int auraDamage, int lifeDamage)
    {

    }

}