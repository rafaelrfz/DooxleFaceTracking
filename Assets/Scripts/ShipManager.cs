using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ShipManager : MonoBehaviour
{
    [SerializeField] private ARFace arFace;
    [SerializeField] private AsteroidGameManager asteroidGameManager;
    [SerializeField] private List<GameObject> bulletsPool;
    [SerializeField] private int indexVerticePosition = 13;
    [SerializeField] private GameObject ship;
    [SerializeField] private AudioSource sfx;
    [SerializeField] bool canShoot = true;
    int indexBullet = 0;

    void Start()
    {
        asteroidGameManager = FindObjectOfType<AsteroidGameManager>();
        arFace.updated += (arFaceUpdatedEventArgs) => {
            ship.transform.localPosition = arFaceUpdatedEventArgs.face.vertices[indexVerticePosition];

            if (arFaceUpdatedEventArgs.face.vertices[14].y < -0.05f)//Abrió la boca
            {
                if (canShoot) {
                    Shoot();
                    canShoot = false;
                }
            }
            else {
                canShoot = true;
            }
        };
    }
	/*private void Update()
	{
        if (Input.GetKeyDown(KeyCode.A)){
            Shoot();
        }
	}*/

    void Shoot() {
        indexBullet++;
        indexBullet = indexBullet.Equals(bulletsPool.Count) ? 0 : indexBullet;
        GameObject bullet = bulletsPool[indexBullet];
        bullet.transform.position = new Vector3(ship.transform.position.x, ship.transform.position.y, 0.35f);
        bullet.SetActive(true);
        
    }
	private void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("Sphere"))
		{
			LoseScore(other);
		}
	}

	public void LoseScore(Collider other)
	{
		asteroidGameManager.Score--;
		sfx.Play();
		other.gameObject.SetActive(false);
	}
}