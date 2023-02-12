using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool IsPause { get; set; }

    [SerializeField] GameObject menu;
    [SerializeField] GameObject best;
    [SerializeField] GameObject game;
    [SerializeField] GameObject pause;

    private GameObject LevelRef { get; set; }

    public void OpenBestScore(bool IsOpen)
    {
        menu.SetActive(!IsOpen);
        best.SetActive(IsOpen);
    }

    public void OpenGame(bool IsOpen)
    {
        pause.SetActive(false);

        menu.SetActive(!IsOpen);
        game.SetActive(IsOpen);

        if(IsOpen)
        {
            LevelRef = Instantiate(Resources.Load<GameObject>("level"), GameObject.Find("Environment").transform);
        }
        else
        {
            Destroy(LevelRef);
            IsPause = false;
        }
    }

    public void OpenPause(bool IsOpen)
    {
        IsPause = IsOpen;

        game.SetActive(!IsOpen);
        pause.SetActive(IsOpen);
    }
}
