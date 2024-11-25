using UnityEngine;

public class TransformPosition : MonoBehaviour
{
    [SerializeField] public Transform runner1;
    [SerializeField] public Transform runner2;
    [SerializeField] public GameObject wand1;
    [SerializeField] public GameObject wand2;
    [SerializeField] public Vector3[] points;
    [SerializeField] public float speed = 2.0f;

    [SerializeField] private int currentPointIndex1 = 0;
    [SerializeField] private int currentPointIndex2 = 0;
    [SerializeField] private bool isRunner1Active = true; 

    void Update()
    {
        if (isRunner1Active)
        {
            MoveRunner(runner1, ref currentPointIndex1);
            wand1.SetActive(true);
            wand2.SetActive(false);

        }
        else
        {
            MoveRunner(runner2, ref currentPointIndex2);
            wand1.SetActive(false);
            wand2.SetActive(true);
        }
    }

    void MoveRunner(Transform runner, ref int currentIndex)
    {
        Vector3 targetPosition = points[currentIndex];
        float step = speed * Time.deltaTime;

        runner.position = Vector3.MoveTowards(runner.position, targetPosition, step);

        Vector3 direction = (targetPosition - runner.position).normalized;
        if (direction != Vector3.zero) 
        {
            runner.rotation = Quaternion.LookRotation(direction);
        }

        if (Vector3.Distance(runner.position, targetPosition) < 0.1f)
        {
            currentIndex++;
           
            if (currentIndex >= points.Length)
            {
                currentIndex = 0; 
                isRunner1Active = !isRunner1Active; 
            }
        }
    }
}
