using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField]
    private GameObject knife;
    [SerializeField]
    private GameObject gun;

    private bool isKnife = false;
    private bool isGun = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isKnife = !isKnife; // Toggle the value of isKnife
            isGun = !isGun;     // Toggle the value of isGun

            knife.SetActive(isKnife);
            gun.SetActive(isGun);
        }
    }
}