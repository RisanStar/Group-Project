using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCutScene : MonoBehaviour
{
    [SerializeField] public Animator fadeIn;

    [SerializeField] public Animator noahRise;
    [SerializeField] public Animator noahTalking;
    [SerializeField] public Animator noahName;
    [SerializeField] public Animator noahTextBox;

    [SerializeField] public Animator noraRise;
    [SerializeField] public Animator noraTalking;
    [SerializeField] public Animator noraName;
    [SerializeField] public Animator noraTextBox;

    public float transitionTimer;
    private float count;

    public float transiitionTimer_;
    private float count_;

    private float noahTalkCount;
    public float noahTalkTimer;

    private float noraTalkCount;
    public float noraTalkTimer;
 

    private bool noahCanTalk = false;
    private bool noraCanTalk = false;

    private void Start()
    {
        fadeIn.SetTrigger("Start");
        count = transitionTimer;
        count_ = transiitionTimer_;
        noahTalkCount = noahTalkTimer;
        noraTalkCount = noraTalkTimer;
    }

    private void Update()
    {
        NoahRise();
        if (noahCanTalk)
        {
            noahTalkCount -= 1f * Time.deltaTime;
            if (noahTalkCount <= 0f) {noahTalkCount = 0;}
            if (noahTalkCount == 0)
            {
                noahTalking.SetBool("NoahTalk", true);
                noahTextBox.SetBool("TextOn", true);
                noahName.SetBool("NoahIs", true);
                NoraRise();
            }
        }

        if (noraCanTalk)
        {
            noraTalkCount -= 1f * Time.deltaTime;
            if(noraTalkCount <= 0f) {noraTalkCount = 0;}
            if(noraTalkCount == 0)
            {
                noraTalking.SetBool("NoraTalk", true);
                noraTextBox.SetBool("TextOn", true);
                noraName.SetBool("NoraIs", true);
            }
        }
    }

    private void NoahRise()
    {
        count -= 1f * Time.deltaTime;
        if (count <= 0) { count = 0;}
        if (count == 0)
        {
            noahRise.SetBool("NoahOn",true);
            noahCanTalk = true;
        }
    }

    private void NoraRise()
    {
        count_ -= 1f * Time.deltaTime;
        if (count_ <= 0f) { count_ = 0; }
        if (count_ == 0)
        {
            noraRise.SetBool("NoraOn", true);
            noraCanTalk = true;
        }
    }

}
