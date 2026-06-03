using UnityEngine;

public class MovingHazard : MonoBehaviour
{
    [SerializeField] private float moveDistance = 3f;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private bool moveHorizontally = true;

    private Vector3 startPosition;
    private float timer;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        timer += Time.deltaTime * moveSpeed;
        float offset = Mathf.Sin(timer) * moveDistance;

        transform.position = moveHorizontally
            ? startPosition + new Vector3(offset, 0, 0)
            : startPosition + new Vector3(0, offset, 0);
    }
}