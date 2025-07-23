using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet; // Prefab of the bullet to be shot
    public Camera mainCamera; // Reference to the main camera
    public Transform spawnBullet; // Transform representing the spawn point of the bullet

    public float shootForce; // Force applied to the bullet when shooting
    public float spread; // Amount of spread to apply to the bullet direction

    public GameObject muzzleFlash; // Prefab of the muzzle flash effect
    public Transform muzzleFlashPosition; // Transform representing the position of the muzzle flash

    private float shootCooldown = 0.5f; // Cooldown duration in seconds
    private float lastShootTime = -Mathf.Infinity; // Time of the last shot, initialized to negative infinity

    void Update()
    {
        // Check if enough time has passed since the last shot
        if (Time.time - lastShootTime >= shootCooldown)
        {
            // Check for input or condition to shoot
            if (Input.GetMouseButton(0))
            {
                Shoot(); // Call the method to perform the shooting
                lastShootTime = Time.time; // Update the last shoot time
            }
        }
    }

    private void Shoot()
    {
        // Instantiate and destroy muzzle flash effect
        GameObject flash = Instantiate(muzzleFlash, muzzleFlashPosition);
        Destroy(flash, 0.1f);

        // Create a ray from the center of the screen
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        // Calculate bullet direction without spread
        Vector3 dirWithoutSpread = targetPoint - spawnBullet.position;

        // Apply random spread to the bullet direction
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);
        Vector3 dirWithSpread = dirWithoutSpread + new Vector3(x, y, 0);

        // Instantiate bullet and set its direction and force
        GameObject currentBullet = Instantiate(bullet, spawnBullet.position, Quaternion.identity);
        currentBullet.transform.forward = dirWithSpread.normalized;
        currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * shootForce, ForceMode.Impulse);
    }
    void OnShoot()
    {
        float currentTime = Time.time; // Get the current time

      /*  // Check if enough time has passed since the last shoot
        if (currentTime - lastShootTime >= shootCooldown)
        {*/
            AkSoundEngine.PostEvent("Play_Shot", gameObject);
            Shoot();
            lastShootTime = currentTime; // Update the last shoot time
       // }
    }
}
