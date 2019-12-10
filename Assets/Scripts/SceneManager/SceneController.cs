using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{


    public SceneData sceneData;
    private int currentSceneIndex;
    private void Start()
    {
        SceneData sceneData = new SceneData();
        sceneData.setValue(SceneManager.GetActiveScene().buildIndex, SceneManager.sceneCountInBuildSettings, SceneManager.GetActiveScene().name);
        currentSceneIndex = sceneData.GetCurrentIndex();
    }

    private void Update()
    {
        Debug.Log($"被调用前的值为: {sceneData.GetCurrentIndex()}");
        if(currentSceneIndex != sceneData.GetCurrentIndex())
        {
            SceneManager.LoadSceneAsync(sceneData.GetCurrentIndex());
            currentSceneIndex = sceneData.GetCurrentIndex();
        }
            
    }
    public void NextScene(bool NextScene)
    {
        sceneData.ChangeScene(NextScene);
    }
}
[System.Serializable]
public struct SceneData
{
    private int    currentIndex;
    private int    total;
    private string name;
    public void setValue(int currentIndex, int total, string name)
    {
        this.currentIndex = currentIndex;
        this.total = total;
        this.name = name;
    }
    public void ChangeScene(bool NextScene)
    {
        if (NextScene && currentIndex < total)
        {
            currentIndex++;
        }
    }
    public int GetTotal()
    {
        return total;
    }
    public int GetCurrentIndex()
    {
        return currentIndex;
    }
    public string GetName()
    {
        return name;
    }

}
