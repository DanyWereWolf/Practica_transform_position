using UnityEngine;

public class MarathonRunners : MonoBehaviour
{
    public Transform[] runners;
    public GameObject[] wand;
    public float speed = 5f;
    public float passDistance = 1f;
    private int currentRunnerIndex = 0;

    void Start()
    {
        for (int i = 0; i < wand.Length; i++)
        {
            wand[i].SetActive(i == currentRunnerIndex);
        }
    }
    void Update()
    {
        if (runners.Length == 0 || wand.Length == 0) return;

        Transform currentRunner = runners[currentRunnerIndex];

        Transform nextRunner = runners[(currentRunnerIndex + 1) % runners.Length];
        currentRunner.LookAt(nextRunner);

        Vector3 directionToNext = (nextRunner.position - currentRunner.position).normalized;

        currentRunner.position += directionToNext * speed * Time.deltaTime;

        if (Vector3.Distance(currentRunner.position, nextRunner.position) < passDistance)
        {
            wand[currentRunnerIndex].SetActive(false);

            currentRunnerIndex = (currentRunnerIndex + 1) % runners.Length;

            wand[currentRunnerIndex].SetActive(true);
        }
    }
}
