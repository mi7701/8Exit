using UnityEngine;

public class JellyfishMove : MonoBehaviour
{
    public float speed = 1f;
    public float height = 0.2f;

    private Vector3 startPosition;
    private float offset;

    void Start()
    {
        startPosition = transform.localPosition;
        offset = Random.Range(0f, 10f);
    }

    void Update()
    {
        float y = Mathf.Sin((Time.time + offset) * speed) * height;

        transform.localPosition = startPosition + new Vector3(0, y, 0);
    }
}