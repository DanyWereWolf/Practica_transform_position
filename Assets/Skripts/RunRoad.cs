using UnityEngine;

public class RunRoad : MonoBehaviour
{
    public Vector3[] points; 
    public float speed = 2.0f; 
    private int currentPointIndex = 0;
    private int direction = 1;
    bool forward = true;

    void Update()
    {
        Vector3 targetPosition = points[currentPointIndex];
        float step = speed * Time.deltaTime; 

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        transform.LookAt(targetPosition);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            if (forward == true)
            {
                currentPointIndex += direction;
            }
            
            if (currentPointIndex >= points.Length || currentPointIndex < 0)
            {
                    direction *= -1;
                currentPointIndex = Mathf.Clamp(currentPointIndex, 0, points.Length - 1);
            }
        }
    }
}
