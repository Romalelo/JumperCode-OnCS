using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlocks : MonoBehaviour {

    public GameObject block, allCubes;
    private GameObject blockInst;
    private Vector3 blockPos;
    private float speed=10f;
    private bool onPlace;


	void Start()
    {
        blockPos = new Vector3(Random.Range(0.5f, 1f), Random.Range(1.35f, -1f), 0f);
        blockInst = Instantiate(block, new Vector3(Random.Range(0.5f, 1f), Random.Range(1.35f, -1f), 0f), Quaternion.identity) as GameObject;
        blockInst.transform.localScale = new Vector3 (Random.Range(1.35f, 1.85f), 0.5f, 2.0f);
        blockInst.transform.parent = allCubes.transform;
        print("loler");
    }

    void Update()
    {
        if (blockInst.transform.position != blockPos && !onPlace)
            blockInst.transform.position = Vector3.MoveTowards(blockInst.transform.position, blockPos, Time.deltaTime * speed);
        else if (blockInst.transform.position == blockPos)
            onPlace = true;
        if (CubeJump.jump && CubeJump.nextBlock && CubeJump.spawn && !CubeJump.lose)
        {
            blockPos = new Vector3(Random.Range(0.5f, 1f), Random.Range(1.35f, -1f), 0f);
            blockInst = Instantiate(block, new Vector3(4f, -5f, 0f), Quaternion.identity) as GameObject;
            blockInst.transform.localScale = new Vector3(Random.Range(1.35f, 1.85f), 0.5f, 1.5f);
            blockInst.transform.parent = allCubes.transform;
            onPlace = false;
            CubeJump.spawn = false;
            print("2");
        }
    }
}
