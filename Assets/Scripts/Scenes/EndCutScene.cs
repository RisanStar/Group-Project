using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndCutScene : MonoBehaviour
{
    [SerializeField] public Animator fadeIn;
    [SerializeField] public Animator fadeOut;

    [SerializeField] public Animator noahRise;
    [SerializeField] public Animator noahTalking;
    [SerializeField] public Animator noahName;
    [SerializeField] public Animator noahTextBox;

    [SerializeField] public Animator noraRise;
    [SerializeField] public Animator noraTalking;
    [SerializeField] public Animator noraName;
    [SerializeField] public Animator noraTextBox;

    [SerializeField] public Animator entityRise;
    [SerializeField] public Animator entityName;
    [SerializeField] public Animator entityTextBox;

    public float transitionTimer;
    private float count;

    public float transiitionTimer_;
    private float count_;

    public float transitonTimer__;
    private float count__;

    private float noahTalkCount;
    public float noahTalkTimer;

    private float noraTalkCount;
    public float noraTalkTimer;

    private float entityTalkCount;
    public float entityTalkTimer;
 
    private bool noahCanTalk = false;
    private bool noraCanTalk = false;
    private bool entityCanTalk = false;

    public float endTheCutsceneTimer;
    private float endTheCutsceneCount;
    private void Start()
    {
        fadeIn.SetTrigger("Start");
        fadeOut.SetTrigger("Start");

        count = transitionTimer;
        count_ = transiitionTimer_;
        count__ = transitonTimer__;

        noahTalkCount = noahTalkTimer;
        noraTalkCount = noraTalkTimer;
        entityTalkCount = entityTalkTimer;

        endTheCutsceneCount = endTheCutsceneTimer;
    }

    private void Update()
    {
        endTheCutsceneCount -= 1 * Time.deltaTime;
        if (endTheCutsceneCount <= 0) {endTheCutsceneCount = 0;}
        if (endTheCutsceneCount == 0)
        {
            SceneManager.LoadScene("MainMenu");
        }

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
                EntityRise();
            }
        }

        if (entityCanTalk)
        {
            entityTalkCount -= 1f * Time.deltaTime;
            if (entityTalkCount <= 0f) { entityTalkCount = 0; }
            if (entityTalkCount == 0)
            {
                entityTextBox.SetBool("TextOn", true);
                entityName.SetBool("EntityIs", true);
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

    private void EntityRise()
    {
        count__ -= 1f * Time.deltaTime;
        if (count__ <= 0f) { count__ = 0; }
        if (count__ == 0)
        {
            entityRise.SetBool("EntityOn", true);
            entityCanTalk = true;
        }

    }
}
