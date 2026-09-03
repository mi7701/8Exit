using UnityEngine;
using UnityEngine.InputSystem;

public class Playeranimation : MonoBehaviour {
   private Animator animator;
   private SpriteRenderer sr;

   private float idleTime = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        bool walking = Keyboard.current.dKey.isPressed || Keyboard.current.aKey.isPressed;

        animator.SetBool("isWalking", walking);

        if (walking)
        {
            idleTime = 0f;
        }
        else
        {
            idleTime += Time.deltaTime;
        }

        if (idleTime >= 10f)
        {
            animator.SetBool("isLongIdle", true);
            idleTime = 0f;
        }
        else
        {
            animator.SetBool("isLongIdle", false);
        }

        if (Keyboard.current.dKey.isPressed )
        {
            sr.flipX = false;//‰EŒü‚«
        }

        if (Keyboard.current.aKey.isPressed)
        {
            sr.flipX = true;//¶Œü‚«
        }
     
    }
}