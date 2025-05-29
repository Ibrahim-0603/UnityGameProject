using UnityEngine;

public class DebugOnDestroy : MonoBehaviour
{
    void OnDestroy()
    {
        Debug.Log("ScoreText GameObject was destroyed! Parent: " + transform.parent?.name);
    }

}
