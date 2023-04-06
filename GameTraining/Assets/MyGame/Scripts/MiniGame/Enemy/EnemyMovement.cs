using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyMovement : MonoBehaviour
{

    [SerializeField]
    private float speed;

    [SerializeField]
    private bool goFoward;

    private EnemyAnimation enemyAnimation;

    [SerializeField]
    private bool isMoving;

    private bool executeAnimation;

    private Transform player;

    public event Action OnAttack;

    private PlayerHealthMG playerHealth;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyAnimation = GetComponent<EnemyAnimation>();
        playerHealth = player.GetComponent<PlayerHealthMG>();


    }

    
    void Update()
    {
        //CalculateDistance();
        if (playerHealth.health > 0)
        {
            Movement();
            StartCoroutine("CalculateDistance");
        }
    }

    private void GoFoward()
    {
        enemyAnimation.ExecuteAnimation(1);
        transform.position -= transform.right * speed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, 0, 0);
    }

    private void GoBack()
    {
        enemyAnimation.ExecuteAnimation(1);
        transform.position += transform.right * -speed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, 180, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            goFoward = !goFoward;
        }

    }

    IEnumerator CalculateDistance()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        
        if (distance <= 2.3f)
        {
               
            isMoving = false;

            if (!executeAnimation)
            {
               
                executeAnimation = true;
                StartCoroutine(enemyAnimation.ExecuteAnimation(2, 0.667f, 0));
                OnAttack();

            }
            
            yield return new WaitForSeconds(2);
            executeAnimation = false;
            
            
        }
        else
        {
            isMoving = true;
        }
    }

    private void Movement()
    {
        if (isMoving)
        {
            if (goFoward)
            {
                GoFoward();
            }
            else
            {
                GoBack();
            }
        }
        else
        {
            transform.position += Vector3.zero;
        }
    }
}
