using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class LoadOnClick : MonoBehaviour {

    public void LoadScene(int level)
    {
        switch (level)
        {
            case 1:
                SceneParameters.TextParameter = "Scene one has been successfully loaded";
                break;

            case 2:
                SceneParameters.TextParameter = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                break;
        }
        SceneManager.LoadScene(level);
    }
}
