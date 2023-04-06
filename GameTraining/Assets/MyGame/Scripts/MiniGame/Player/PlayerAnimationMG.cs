using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationMG : MonoBehaviour
{
    private Animator anim;

    private bool isReady;

    public bool state { get; set; }
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }

    public void ExecuteAnimation(int value)
    {
        anim.SetInteger("transition",value);
    }

    public IEnumerator ExecuteAnimation(int animation,float timeAnimation,int backAnimation,bool value)
    {
        if (!isReady)
        {
            isReady = true;
            state = value;
            anim.SetInteger("transition",animation);
            yield return new WaitForSeconds(timeAnimation);
            anim.SetInteger("transition",backAnimation);
            isReady = false;
            state = !value;

        }
    }

    public IEnumerator ExecuteAnimation(int animation,float timeAnimation,int backAnimation)
    {
        anim.SetInteger("transition",animation);
        yield return new WaitForSeconds(timeAnimation);
        anim.SetInteger("transition", backAnimation);
    }
}
