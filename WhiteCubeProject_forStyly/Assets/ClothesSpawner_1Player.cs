using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesSpawner_1Player : MonoBehaviour {

    public GameObject[] clothes;

    private void Start()
    {
        StartCoroutine(SpawnClothes());
    }

    IEnumerator SpawnClothes()
    {
        Debug.Log("SpawnClothes is called");

        yield return new WaitForSeconds(6);

        for (int i = 0; i < clothes.Length; i+=2)
        {
            Debug.Log("Spawning two clothes");

            GameObject clothesA = Instantiate(clothes[i], new Vector3(-0.5f, 0f, 2f), Quaternion.identity);
            GameObject clothesB = Instantiate(clothes[i+1], new Vector3(0.5f, 0f, 2f), Quaternion.identity);

            yield return new WaitForSeconds(8);

            Destroy(clothesA);
            Destroy(clothesB);
        }
    }

}
