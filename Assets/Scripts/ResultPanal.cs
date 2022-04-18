using UnityEngine;
using UnityEngine.UI;


public class ResultPanal : MonoBehaviour
{
    [SerializeField] private Text _message;
    [SerializeField] private Text _time;

    [SerializeField] private string _noDataMessage;

    private void OnEnable()
    {
        Setup();
    }

    private void Setup()
    {
        Result? result = SaveLoadProgress.LoadData();

        if (result.HasValue)
        {
            _message.text = result.Value.Message;
            _time.text = result.Value.IsWon ?$"Seconds: {result.Value.Time}"  : "";
        }
        else
        {
            _time.text = "";
            _message.text = _noDataMessage;
        }
    }
}
