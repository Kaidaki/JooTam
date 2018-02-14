using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoreManager : MonoBehaviour
{
    public static CoreManager coreManagerIns = null;

    public HpController hpController;
    public Shield shield;
    public Slider slider;   //체력 슬라이더
    public RhythmicStage.NoteReferee noteReferee;

    public bool judgeNote = true;

    void Awake()
    {
        if (coreManagerIns == null)
            coreManagerIns = this;
        else if (coreManagerIns != this)
            Destroy(gameObject);

        hpController = GameObject.Find("Canvas").GetComponentInChildren<HpController>();
        shield = GameObject.Find("GameObjects").GetComponent<Shield>();
        slider = GameObject.Find("Canvas").GetComponentInChildren<Slider>();
        noteReferee = GameObject.Find("GameObjects").transform.Find("NoteRail")
                     .GetComponentInChildren<RhythmicStage.NoteReferee>();
    }

}
