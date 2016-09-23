using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class OnSceneLoad : MonoBehaviour {
    public void OnLevelWasLoaded(int level)
    {
        new CubicTextDrawer(SceneParameters.TextParameter);
    }
}
