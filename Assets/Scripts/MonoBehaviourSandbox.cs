using UnityEngine;

public class MonoBehaviourSandbox : MonoBehaviour
{
    [SerializeField] private int pointsPerTick = 1;

    public int Score { get; private set; }

    public void AddScoreTick()
    {
        Score += pointsPerTick;
    }

    public void ResetScore()
    {
        Score = 0;
    }
}
