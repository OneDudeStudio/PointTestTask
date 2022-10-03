using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text _moneyText;
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _gameWinPanel;
    [SerializeField] private GameObject _gameOverPanel;

    [Header("Coin list")]
    private List<Money> _activeMoney = new List<Money>();

    private PlayerLocomotion _player;
    private LineManager _lineManager;
    private bool _gameIsOver;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerLocomotion>();
        _lineManager = FindObjectOfType<LineManager>();
        _gameOverPanel.SetActive(false);
        _gameWinPanel.SetActive(false);
    }

    private void Start()
    {
        UpdateTakeMoneyText();
    }

    public void AddMoneyToList(Money money)
    {
        _activeMoney.Add(money);
    }

    public void TakeMoney(Money money)
    {
        _activeMoney.Remove(money);
    }

    public void UpdateTakeMoneyText()
    {
        _moneyText.text = "Осталось собрать: " + _activeMoney.Count + " монет";
        CheckGameEnd();
    }
    public void TakeSpikes()
    {
        _player.isAlive = false;
        CheckGameEnd();
    }
    public void CheckGameEnd()
    {
        if (_player.isAlive == false)
        {
            GameOver();
        }
        if (_activeMoney.Count <= 0)
        {
            GameWin();
        }
    }

    private void GameWin()
    {
        _gameIsOver = true;
        _player.enabled = false;
        _lineManager.EraseLine();
        _lineManager.enabled = false;
        _gameWinPanel.SetActive(true);
    }

    private void GameOver()
    {
        Debug.Log("Game over");
        _gameIsOver = true;
        _player.enabled = false;
        _lineManager.EraseLine();
        _lineManager.enabled = false;
        _gameOverPanel.SetActive(true);
        _gamePanel.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
