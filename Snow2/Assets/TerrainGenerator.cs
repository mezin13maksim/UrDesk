using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TerrainGenerator : MonoBehaviour {

    public float sizeElement = 10f;
    public int numOfElements = 10;
    public List<TerrainElement> ElementsOfTerrain;
    float lastElementV;
    float nextElementV = 0;
    
	void Start () {
        Instantiate(ElementsOfTerrain[0], transform);
        transform.GetChild(0).transform.position = new Vector3(0, 0, 0);
    
	}

	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E)) {
            nextElementV = Random.Range(0, 3);
            Debug.Log(nextElementV);
            
            nextGenerate();
            
        }
	}

    void nextGenerate() {

        if (nextElementV == 0)
        {
            if (transform.childCount >= numOfElements)
            {
                Destroy(transform.GetChild(0).gameObject);
            }
            Instantiate(ElementsOfTerrain[0], transform);
            transform.GetChild(transform.childCount - 1).transform.SetParent(transform.GetChild(transform.childCount - 2));
            transform.GetChild(transform.childCount - 1).transform.GetChild(0).localPosition = new Vector3(0, 0, 1);
            transform.GetChild(transform.childCount - 1).transform.GetChild(0).rotation = transform.GetChild(transform.childCount - 1).rotation;
            transform.GetChild(transform.childCount - 1).transform.GetChild(0).SetParent(transform);
            lastElementV = transform.GetChild(transform.childCount - 1).GetComponent<TerrainElement>().Vect;
            
        }

        if (nextElementV == 1)
        {
            if (transform.childCount >= numOfElements)
            {
                Destroy(transform.GetChild(0).gameObject);
            }
            Instantiate(ElementsOfTerrain[1], transform);
            transform.GetChild(transform.childCount - 1).transform.SetParent(transform.GetChild(transform.childCount - 2));
            transform.GetChild(transform.childCount - 1).transform.GetChild(0).localPosition = new Vector3(0, 0, 1);
            transform.GetChild(transform.childCount - 1).transform.GetChild(0).rotation = transform.GetChild(transform.childCount - 1).rotation;
            transform.GetChild(transform.childCount - 1).transform.GetChild(0).Rotate(new Vector3(0, -90, 0));
            transform.GetChild(transform.childCount - 1).transform.GetChild(0).SetParent(transform);
            lastElementV = transform.GetChild(transform.childCount - 1).GetComponent<TerrainElement>().Vect;
            
        }

        if (nextElementV == 2)
        {
            if (transform.childCount >= numOfElements)
            {
                Destroy(transform.GetChild(0).gameObject);
            }
            Instantiate(ElementsOfTerrain[2], transform);
            transform.GetChild(transform.childCount - 1).transform.SetParent(transform.GetChild(transform.childCount - 2));
            transform.GetChild(transform.childCount - 1).transform.GetChild(0).localPosition = new Vector3(0, 0, 1);
            transform.GetChild(transform.childCount - 1).transform.GetChild(0).rotation = transform.GetChild(transform.childCount - 1).rotation;
            transform.GetChild(transform.childCount - 1).transform.GetChild(0).Rotate(new Vector3(0, 90, 0));
            transform.GetChild(transform.childCount - 1).transform.GetChild(0).SetParent(transform);
            lastElementV = transform.GetChild(transform.childCount - 1).GetComponent<TerrainElement>().Vect;
            
        }
        
        
        
       
    }


}
