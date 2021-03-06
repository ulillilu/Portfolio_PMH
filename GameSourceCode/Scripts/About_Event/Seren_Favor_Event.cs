﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seren_Favor_Event : MonoBehaviour
{
    [SerializeField]

    public Dialogue dialogue_1;
    public Dialogue dialogue_2;
    public Dialogue dialogue_3;
    public Dialogue dialogue_4;


    private Dialog_Manager TheDM;
    private DataBaseManager theDB;
    private Player_Stat theStat;
    private bool flag;
    
    // Start is called before the first frame update
    void Start()
    {
        TheDM = FindObjectOfType<Dialog_Manager>();
        theDB = FindObjectOfType<DataBaseManager>();
        theStat = FindObjectOfType<Player_Stat>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(!flag && !theDB.has_eventSeren001 && collision.gameObject.tag == "Player" && 5 <= theStat.favorability_Seren)
        {
            flag = true;
            StartCoroutine(EventCoroutine001());
            theDB.has_eventSeren001 = true;
        }

        if(!flag && theDB.has_eventSeren001 && !theDB.has_eventSeren002 && collision.gameObject.tag == "Player" && 10 <= theStat.favorability_Seren)
        {
            flag = true;
            StartCoroutine(EventCoroutine002());
            theDB.has_eventSeren002 = true;
        }

        if(!flag && theDB.has_eventSeren001 && theDB.has_eventSeren002 && !theDB.has_eventSeren003 && collision.gameObject.tag == "Player" && 15 <= theStat.favorability_Seren)
        {
            flag = true;
            StartCoroutine(EventCoroutine003());
            theDB.has_eventSeren003 = true;
        }

        if(!flag && theDB.has_eventSeren001 && theDB.has_eventSeren002 && theDB.has_eventSeren003 && !theDB.has_eventSeren004 && collision.gameObject.tag == "Player" && 20 <= theStat.favorability_Seren)
        {
            flag = true;
            StartCoroutine(EventCoroutine004());
            theDB.has_eventSeren004 = true;
        }

    }

    IEnumerator EventCoroutine001()
    {
        TheDM.ShowDialogue(dialogue_1);
        yield return new WaitUntil(()=> !TheDM.talking);
    }
    IEnumerator EventCoroutine002()
    {
        TheDM.ShowDialogue(dialogue_2);
        yield return new WaitUntil(()=> !TheDM.talking);
    }

    IEnumerator EventCoroutine003()
    {
        TheDM.ShowDialogue(dialogue_3);
        yield return new WaitUntil(()=> !TheDM.talking);
    }
    IEnumerator EventCoroutine004()
    {
        TheDM.ShowDialogue(dialogue_4);
        yield return new WaitUntil(()=> !TheDM.talking);
    }

}
