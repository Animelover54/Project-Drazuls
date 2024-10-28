using System.Collections;
using UnityEngine;

public class EnemyColliders : MonoBehaviour
{
    public AudioSource soundEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Skill")
        {
            soundEffect.Play();
            Debug.Log("Oh no you killed me!");
            StartCoroutine(DestroyAfterSound());
        }
        else
        {
            Debug.Log(other.gameObject.name + "touched me");
        }
    }
    // Not my Code :( After this ..... needed a timer

    // Coroutine to destroy the GameObject after the sound has finished playing
    private IEnumerator DestroyAfterSound()
    {
        // Wait until the sound finishes playing
        yield return new WaitForSeconds(soundEffect.clip.length);
        GameObject.Destroy(this.gameObject);
    }
}
