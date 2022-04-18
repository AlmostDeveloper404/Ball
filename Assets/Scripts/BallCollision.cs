using UnityEngine;

public class BallCollision : MonoBehaviour
{
    [SerializeField] private GameObject _resultGO;

    

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("End"))
        {
            GameManager.Instance.Win();
            enabled = false;
            _resultGO.SetActive(true);
        }

        if (other.CompareTag("Lost"))
        {
            GameManager.Instance.Lose();
            enabled = false;
            _resultGO.SetActive(true);
        }
    }

}
