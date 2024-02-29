using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCutScene : MonoBehaviour
{
    [SerializeField] public Animator fadeIn;
    [SerializeField] public Animator noahRise;
    [SerializeField] public Animator noahTalking;
    [SerializeField] public Animator textBox;
    public float transitionTimer;
    private float count;
    private float talkCount;
    public float talkTimer;
 

    private bool canTalk = false;

    private void Start()
    {
        fadeIn.SetTrigger("Start");
        count = transitionTimer;
        talkCount = talkTimer;
    }

    private void Update()
    {
        NoahRise();
        if (canTalk)
        {
            talkCount -= 1f * Time.deltaTime;
            if (talkCount <= 0f) {talkCount = 0;}
            if (talkCount == 0)
            {
                noahTalking.SetBool("NoahTalk", true);
                textBox.SetBool("TextOn", true);
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
            canTalk = true;
        }
    }

}
