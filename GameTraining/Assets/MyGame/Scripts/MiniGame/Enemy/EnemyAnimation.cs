using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator anim;
    private bool isReady;
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

    public IEnumerator ExecuteAnimation(int animation,float timeAnimation,int backAnimation)
    {
        if (!isReady)
        {
            isReady = true;
            anim.SetInteger("transition", animation);
            yield return new WaitForSeconds(timeAnimation);
            anim.SetInteger("transition", backAnimation);
            isReady = false;
        }
    }
}
