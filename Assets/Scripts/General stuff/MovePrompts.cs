using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePrompts : MonoBehaviour
{
    private Animator anim;
    public float timeBeforePrompts;
    public float promptsStayTime;


    private void Start()
    {
        anim = GetComponent<Animator>();
        StartCoroutine(PromptsFade());
    }

    IEnumerator PromptsFade()
    {
        yield return new WaitForSeconds(timeBeforePrompts);
        anim.SetTrigger("FadeIn");
        yield return new WaitForSeconds(promptsStayTime);
        anim.SetTrigger("FadeOut");
    }
    
}
