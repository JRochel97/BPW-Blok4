using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningShadow : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    public float range = 5f;
    public float smooth = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(player.transform.position, transform.position);
        if(dist > range)
        {
            animator.speed = Mathf.Lerp(animator.speed, 0, smooth* Time.deltaTime);
        }
        else
        {
            animator.speed = Mathf.Lerp(animator.speed, 1, smooth* Time.deltaTime);
        }
        
    }
}
