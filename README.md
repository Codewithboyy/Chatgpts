# Unity MonoBehaviour Testing Sandbox

This repository is a lightweight Unity project scaffold for writing and testing `MonoBehaviour` scripts with `UnityEngine`.

## What's included

- `Assets/Scripts/MonoBehaviourSandbox.cs` — starter behaviour where you can prototype logic.
- `Assets/Tests/EditMode/MonoBehaviourSandboxTests.cs` — starter EditMode tests using Unity Test Framework (`NUnit`).
- `Packages/manifest.json` — minimal package setup including Unity Test Framework.

## How to use

### 1) Open the project

1. Install **Unity Hub**.
2. Install **Unity Editor 2022.3.20f1** (or a compatible 2022.3 LTS release).
3. In Unity Hub, click **Open** and select this repository folder.

### 2) Run the included tests (Editor UI)

1. In Unity Editor, open **Window > General > Test Runner**.
2. Select the **EditMode** tab.
3. Click **Run All**.
4. You should see the two `MonoBehaviourSandboxTests` passing.

### 3) Try the sample MonoBehaviour

`MonoBehaviourSandbox` has:
- `AddScoreTick()` → increases `Score` by `pointsPerTick` (default 1)
- `ResetScore()` → sets `Score` back to 0

To try it quickly in the Editor:
1. Create a GameObject in a scene.
2. Attach `MonoBehaviourSandbox` component.
3. (Optional) Change `Points Per Tick` in the Inspector.
4. Call methods from your own script, e.g.:

```csharp
using UnityEngine;

public class SandboxDriver : MonoBehaviour
{
    [SerializeField] private MonoBehaviourSandbox sandbox;

    private void Start()
    {
        sandbox.AddScoreTick();
        Debug.Log($"Score: {sandbox.Score}");
    }
}
```

## New to Codex? Quick workflow

1. Ask Codex to make changes (for example: "add a new MonoBehaviour and tests").
2. Codex edits files.
3. Codex runs checks/tests it can run in the environment.
4. Codex commits the changes with a commit message.
5. Codex prepares a PR message.

If you only see local commits but nothing on GitHub, you still need to push to your remote branch.

## GitHub not updating? (Most common fix)

Run these commands from the repo root:

```bash
git status
git remote -v
git branch --show-current
git push -u origin "$(git branch --show-current)"
```

If push fails, check these:
- You are on the expected branch (`git branch --show-current`).
- `origin` points to your GitHub repo (`git remote -v`).
- You are authenticated to GitHub (token/SSH key configured).
- You are viewing the same branch on GitHub UI (not `main` vs `work` mismatch).

Helpful verification commands:

```bash
git log --oneline -n 5
git rev-parse --abbrev-ref HEAD
git ls-remote --heads origin
```

## Add your own MonoBehaviour tests

1. Add scripts under `Assets/Scripts`.
2. Add tests under `Assets/Tests/EditMode`.
3. Create a GameObject and attach your component in tests:

```csharp
var gameObject = new GameObject("TestObject");
var component = gameObject.AddComponent<YourMonoBehaviour>();
```

4. Assert expected behavior with NUnit assertions.

## Optional: Run tests from command line (CI/headless)

Use Unity's batchmode test runner (update the Unity path for your machine):

```bash
/Applications/Unity/Hub/Editor/2022.3.20f1/Unity \
  -batchmode -nographics -quit \
  -projectPath "$(pwd)" \
  -runTests -testPlatform EditMode \
  -logFile - \
  -testResults "TestResults.xml"
```

## Notes

- This scaffold is intentionally minimal so it is easy to extend.
- Add PlayMode tests later if you need frame/timing validation.
