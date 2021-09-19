using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LevelController", menuName = "ScriptableObjects/LevelController")]
public class LevelController : ScriptableObject
{
    [SerializeField] public int mainSceneIndex = 0;
    public void loadNextLevel()
    {
        int numberOfLevel = SceneManager.GetActiveScene().buildIndex;// получаем номер уровня
        if (numberOfLevel < SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene(++numberOfLevel);// загрузка след уровня номер можно посмотреть через shift + ctrl + b
    }

    public void reStartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void loadLevel(int numLevel)
    {
        if (numLevel < SceneManager.sceneCountInBuildSettings - 1)
            SceneManager.LoadScene(numLevel);
    }

    public void exitGame()
    {
        Application.Quit();
    }
    public void loadMainMenu()
    {
        SceneManager.LoadScene(mainSceneIndex);
    }
}