using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public List<GameObject> entrances;
    public List<GameObject> firstLayer;
    public List<GameObject> secondLayer;
    public List<GameObject> thirdLayer;
    // Start is called before the first frame update
    void Start()
    {
        ShuffleAndDecidePattern(entrances);
        ShuffleAndDecidePattern(firstLayer);
        ShuffleAndDecidePattern(secondLayer);
        ShuffleAndDecidePattern(thirdLayer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShuffleAndDecidePattern(List<GameObject> gameObjectList)
    {
        GameObject tempGO;
        for (int i = 0; i < gameObjectList.Count - 1; i++)
        {
            int rnd = Random.Range(i, gameObjectList.Count);
            tempGO = gameObjectList[rnd];
            gameObjectList[rnd] = gameObjectList[i];
            gameObjectList[i] = tempGO;
        }
        if(gameObjectList.Count == 2)
        {
            gameObjectList[0].SetActive(false);
        }
        else
        {
            for (int i = 0; i < gameObjectList.Count; i++)
            {
                gameObjectList[i].GetComponent<DeathObstacleContainer>().flashType = i;
            }
        }
    }
}
