using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerSc : MonoBehaviour
{
    public float TimerBound = 6f;
    public int TrashesNum = 4;
    public List<GameObject> TrashPrefabs;
    public List<GameObject> LeftPoints;
    public List<GameObject> RightPoints;
    public List<GameObject> Fishes;
    private float Timer = 6;
    [SerializeField] private Vector3 center;
    [SerializeField] private Vector3 size;
    [SerializeField] private Vector3 LeftVec;
    [SerializeField] private Vector3 RightVec;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if ((int)Timer> TimerBound)
        {
            SpawnFishes();
            for (int i=0;i< TrashesNum; i++)
            {
                SpawnTrash();

            }
            
            Timer = 0;
        }

    }
    public void SpawnTrash()
    {
        int IdTrash = 0;
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2 , size.x / 2), Random.Range(-size.y / 2, size.y / 2),0.0f);
        IdTrash =  Random.Range(0,3);
        Debug.Log(IdTrash);
        Instantiate(TrashPrefabs[IdTrash], pos, Quaternion.identity);
    }

    public void SpawnFishes()
    {
        GameObject gm1;
        int IdFish = 0;
        int IdPointsL = 0;
        int IdPointsR = 0;
        IdFish = Random.Range(0,2);
        IdPointsL = Random.Range(0,3);
        IdPointsR = Random.Range(0,3);

        if (IdFish == 0)
        {
            Instantiate(Fishes[IdFish], LeftPoints[IdPointsL].transform.position, Quaternion.identity).GetComponent<MovingFishes>().MoveRorL = LeftVec;
        }
        if (IdFish == 1)
        {
            Instantiate(Fishes[IdFish], RightPoints[IdPointsL].transform.position, Quaternion.identity).GetComponent<MovingFishes>().MoveRorL = RightVec;
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1,0,0,0.5f);
        Gizmos.DrawCube(center,size);
    }
}
