using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] Transform container;

    private void Start() => UpdateBoard();

    public void UpdateBoard()
    {
        int[] scores = new int[container.childCount];
        for(int i = 0; i < scores.Length; i++)
        {
            scores[i] = Random.Range(250, 800);
        }

        var sortedScores = scores.OrderByDescending(i => i).ToArray();
        for(int i = 0; i < container.childCount; i++)
        {
            Text leader = container.GetChild(i).GetChild(0).GetComponent<Text>();
            leader.text = $"{sortedScores[i]}";
        }
    }
}
