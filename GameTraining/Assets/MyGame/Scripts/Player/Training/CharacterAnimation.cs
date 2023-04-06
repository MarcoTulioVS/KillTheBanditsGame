using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private Animator anim;

    private bool isReady;

    public bool state { get; set; }
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        
    }

    public IEnumerator ExecuteAnimation(int animation,float timeAnimation,int goBackAnimation)
    {
        anim.SetInteger("transition",animation);
        yield return new WaitForSeconds(timeAnimation);
        anim.SetInteger("transition",goBackAnimation);
    }

    public IEnumerator ExecuteAnimation(int animation,float timeAnimation,int goBackAnimation,bool value)
    {
        if (!isReady)
        {
            isReady = true;
            state = value;
            anim.SetInteger("transition", animation);
            yield return new WaitForSeconds(timeAnimation);
            anim.SetInteger("transition", goBackAnimation);
            state = !value;
            isReady = false;

        }
    }

    public void ExecuteAnimation(int value)
    {
        anim.SetInteger("transition", value);
    }
}
