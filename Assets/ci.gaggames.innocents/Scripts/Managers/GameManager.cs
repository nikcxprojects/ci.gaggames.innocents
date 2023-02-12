using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject best;
    [SerializeField] GameObject game;
    [SerializeField] GameObject pause;

    public void OpenBestScore(bool IsOpen)
    {
        menu.SetActive(!IsOpen);
        best.SetActive(IsOpen);
    }

    public void OpenGame(bool IsOpen)
    {
        menu.SetActive(!IsOpen);
        game.SetActive(IsOpen);
    }

    public void OpenPause(bool IsOpen)
    {
        game.SetActive(!IsOpen);
        pause.SetActive(IsOpen);
    }
}
