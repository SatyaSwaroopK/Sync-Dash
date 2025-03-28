using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public TextMeshProUGUI playerDistanceText;
    public TextMeshProUGUI playerOrbText;
    public TextMeshProUGUI ghostDistanceText;
    public TextMeshProUGUI ghostOrbText;
    public Transform player;
    public Transform ghost;

    private int playerDistanceScore = 0;
    private int ghostDistanceScore = 0;
    private int playerOrbScore = 0;
    private int ghostOrbScore = 0;
    private float playerStartZ;
    private float ghostStartZ;
    private bool isGameOver = false;
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        playerStartZ = player.position.z;
        ghostStartZ = ghost.position.z;
    }

    void Update()
    {
        UpdateDistanceScore();
    }

    void UpdateDistanceScore()
    {
        playerDistanceScore = (int)(player.position.z - playerStartZ);
        ghostDistanceScore = (int)(ghost.position.z - ghostStartZ);

        playerDistanceText.text = "Player Distance: " + playerDistanceScore;
        ghostDistanceText.text = "Ghost Distance: " + ghostDistanceScore;
    }

    public void CollectOrb(string playerName)
    {
        if (playerName == "Player")
        {
            playerOrbScore++;
            playerOrbText.text = "Player Orbs: " + playerOrbScore;
        }
        else if (playerName == "Ghost")
        {
            ghostOrbScore++;
            ghostOrbText.text = "Ghost Orbs: " + ghostOrbScore;
        }
    }


    public void GameOver()
    {
        if (isGameOver) return; 
        isGameOver = true;    
        
        player.gameObject.SetActive(false);
        ghost.gameObject.SetActive(false);
       
    }

    
}
