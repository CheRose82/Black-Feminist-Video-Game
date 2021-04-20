using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeActivateDialogueAfterUse : MonoBehaviour
{
    public int whichPlayer;
    // Jonas 1
    // Sabine 2
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && whichPlayer == 1)
        {
            Invoke(nameof(Die), 0.3f);
        }

        if (other.CompareTag("Sabine") && whichPlayer == 2)
        {
            Invoke(nameof(Die), 0.3f);
        }
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
