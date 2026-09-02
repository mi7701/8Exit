using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class StageMove3 : MonoBehaviour
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
        if (transform.position.x <= -40.6f)
        {
            SceneManager.LoadScene("Scene1");
        }
    }
}