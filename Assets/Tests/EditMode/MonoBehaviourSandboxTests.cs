using NUnit.Framework;
using UnityEngine;

public class MonoBehaviourSandboxTests
{
    [Test]
    public void AddScoreTick_IncreasesScoreByConfiguredAmount()
    {
        var gameObject = new GameObject("Sandbox");

        try
        {
            var sandbox = gameObject.AddComponent<MonoBehaviourSandbox>();

            sandbox.AddScoreTick();

            Assert.That(sandbox.Score, Is.EqualTo(1));
        }
        finally
        {
            Object.DestroyImmediate(gameObject);
        }
    }

    [Test]
    public void ResetScore_SetsScoreToZero()
    {
        var gameObject = new GameObject("Sandbox");

        try
        {
            var sandbox = gameObject.AddComponent<MonoBehaviourSandbox>();
            sandbox.AddScoreTick();
            sandbox.AddScoreTick();

            sandbox.ResetScore();

            Assert.That(sandbox.Score, Is.EqualTo(0));
        }
        finally
        {
            Object.DestroyImmediate(gameObject);
        }
    }
}
