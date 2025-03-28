using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public GameObject[] orbs;
    public Material dissolveMaterial;
    public Material originalMaterial;

    public Renderer enemyRenderer;
    private float dissolveSpeed = 0.2f;
    private bool isDissolving = false;

    private void Awake()
    {
        enemyRenderer = GetComponent<Renderer>();
    }

    private void OnEnable()
    {
        ActivateRandomOrbs();
        ResetDissolve(); 
    }

    void ActivateRandomOrbs()
    {
        foreach (var orb in orbs)
            orb.SetActive(false);

        int orbsToActivate = Random.Range(2, 5);
        for (int i = 0; i < orbsToActivate; i++)
        {
            int index = Random.Range(0, orbs.Length);
            while (orbs[index].activeSelf)
                index = Random.Range(0, orbs.Length);

            orbs[index].SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")  && !isDissolving)
        {
            isDissolving = true;
            StartCoroutine(DissolveAndGameOver());
        }
    }

    IEnumerator DissolveAndGameOver()
    {
        GameManager.instance.GameOver();
        Debug.Log("Dissolve started");

        enemyRenderer.material = new Material(dissolveMaterial);

        float duration = 1f; 
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float dissolveAmount = Mathf.Lerp(0, 1, elapsedTime / duration);
            enemyRenderer.material.SetFloat("_DissolveAmount", dissolveAmount);

            Debug.Log("Dissolve Progress: " + dissolveAmount + " | Time: " + elapsedTime);

            elapsedTime += Time.deltaTime;

            if (elapsedTime >= duration) 
            {               
                break;
            }

            yield return null;
        }        

        enemyRenderer.material.SetFloat("_DissolveAmount", 1);
        yield return new WaitForSeconds(0.5f);
        Debug.Log("Gameover");
        SceneManager.LoadScene("GameOver");
    }




    void ResetDissolve()
    {       
        enemyRenderer.material = originalMaterial;
        originalMaterial.SetFloat("_DissolveAmount", 0); 
        isDissolving = false;
    }
}
