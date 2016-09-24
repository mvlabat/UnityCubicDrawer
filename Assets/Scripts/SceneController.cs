using UnityEngine;
using Assets.Scripts;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private static SceneModel model = new SceneModel();

    private static SceneView view = new SceneView(model);

    public void LoadScene(string textParameter)
    {
        model.TextParameter = textParameter;
        SceneManager.LoadScene(1);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void OnLevelWasLoaded(int level)
    {
        if (level == 1)
        {
            view.DrawText();
        }
    }
}
