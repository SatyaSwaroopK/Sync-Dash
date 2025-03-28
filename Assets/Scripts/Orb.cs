using UnityEngine;

public class Orb : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.CollectOrb("Player");
            gameObject.SetActive(false); 
        }
        else if (other.CompareTag("Ghost"))
        {
            GameManager.instance.CollectOrb("Ghost");
            gameObject.SetActive(false); 
        }
    }
}
