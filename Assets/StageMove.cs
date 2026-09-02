using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class StageMove : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        //‰E‚ÖˆÚ“®
        if (Keyboard.current.dKey.isPressed)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        //¶‚ÖˆÚ“®
        if (Keyboard.current.aKey.isPressed)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
        /*if (transform.position.x <= -25f)
        {
            SceneManager.LoadScene("Scene1");
        }*/
        /*
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                SceneManager.LoadScene("Scene1.");
            }
        } */
      
    }
}