using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public InputManager IM;
    [HideInInspector] public static GameManager GM;
    [HideInInspector] public PlayerMovement PM;
    [HideInInspector] public Score ScoreScript;
    private Food food;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject foodObject;
    [SerializeField] private Transform playerSpawn;
    [HideInInspector] public bool InGame = false;

    public void SetScoreScript(Score script) => ScoreScript = script;
    public void LoadScene(int index) => SceneManager.LoadSceneAsync(index, LoadSceneMode.Additive);
    public void UnloadScene(int index)
    {
        if (SceneManager.GetSceneByBuildIndex(index).isLoaded)
            SceneManager.UnloadSceneAsync(index);
    }
    void Awake()
    {
        GM = this.GetComponent<GameManager>();
    }
    private void Start()
    {
        this.IM = GameObject.Find("InputManager").GetComponent<InputManager>();
        LoadScene(1);
    }
    public void StartGame()
    {
        UnloadScene(1);
        UnloadScene(3);
        LoadScene(2);
        this.InGame = true;
        GameObject _food = GameObject.Instantiate
        (
            foodObject,
            GameObject.Find("/World/Objects").GetComponent<Transform>()
        );
        this.food = _food.GetComponent<Food>();
        playerObject.SetActive(true);
    }
    public void Lose()
    {
        this.InGame = false;
        Destroy(this.food.gameObject);
        this.PM.gameObject.SetActive(false);
        LoadScene(3);
        UnloadScene(2);
    }
}
