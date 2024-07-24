using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public string startMenuSceneName = "start_menu";
    public string sampleSceneName = "SampleScene";
    public string canvasName = "";

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(startMenuSceneName);
    }

    public void LoadSampleScene()
    {
        SceneManager.LoadScene(sampleSceneName);
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == startMenuSceneName)
        {
            // 在start_menu场景中查找特定的Canvas并激活它
            ActivateSpecificCanvas(canvasName);
        }
    }

    private void ActivateSpecificCanvas(string canvasName)
    {
        Canvas[] canvases = FindObjectsOfType<Canvas>();
        foreach (Canvas canvas in canvases)
        {
            if (canvas.name == canvasName)
            {
                canvas.gameObject.SetActive(true);
            }
            else
            {
                canvas.gameObject.SetActive(false);
            }
        }
    }
}
