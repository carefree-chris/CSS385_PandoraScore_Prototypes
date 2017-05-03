using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomScript : MonoBehaviour {

    public GameObject Door;
    public GameObject Object1;
    public GameObject Object2;
    public GameObject Object3;

    private GameObject[] Doors;
    private GameObject[][] Tiles;

	// Use this for initialization
	void Start () {
        Tiles = new GameObject[7][];
        Doors = new GameObject[4];

        for(int i = 0; i < Tiles.Length; i++)
        {
            Tiles[i] = new GameObject[12];
        }

        GameObject t = transform.FindChild("Tiles").gameObject;

        InitTiles(0, t.transform.FindChild("Row 1").gameObject);
        InitTiles(1, t.transform.FindChild("Row 2").gameObject);
        InitTiles(2, t.transform.FindChild("Row 3").gameObject);
        InitTiles(3, t.transform.FindChild("Row 4").gameObject);
        InitTiles(4, t.transform.FindChild("Row 5").gameObject);
        InitTiles(5, t.transform.FindChild("Row 6").gameObject);
        InitTiles(6, t.transform.FindChild("Row 7").gameObject);

        GameObject d = transform.FindChild("Doors").gameObject;

        Doors[0] = d.transform.FindChild("DoorLeft").gameObject;
        Doors[1] = d.transform.FindChild("DoorTop").gameObject;
        Doors[2] = d.transform.FindChild("DoorRight").gameObject;
        Doors[3] = d.transform.FindChild("DoorBottom").gameObject;

        GameObject LeftDoor = Instantiate(Door);
        GameObject RightDoor = Instantiate(Door);
        GameObject TopDoor = Instantiate(Door);
        GameObject BottomDoor = Instantiate(Door);

        LeftDoor.transform.parent = Doors[0].transform;
        RightDoor.transform.parent = Doors[2].transform;
        TopDoor.transform.parent = Doors[1].transform;
        BottomDoor.transform.parent = Doors[3].transform;

        LeftDoor.transform.localPosition = new Vector3(0, 0, 0);
        RightDoor.transform.localPosition = new Vector3(0, 0, 0);
        TopDoor.transform.localPosition = new Vector3(0, 0, 0);
        BottomDoor.transform.localPosition = new Vector3(0, 0, 0);

        LeftDoor.transform.localRotation = new Quaternion(0, 0, 0, 0);
        TopDoor.transform.localRotation = new Quaternion(0, 0, 0, 0);
        RightDoor.transform.localRotation = new Quaternion(0, 0, 0, 0);
        BottomDoor.transform.localRotation = new Quaternion(0, 0, 0, 0);

        randomTiles();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void InitTiles(int i, GameObject g)
    {
        Tiles[i][0] = g.transform.FindChild("1").gameObject;
        Tiles[i][1] = g.transform.FindChild("2").gameObject;
        Tiles[i][2] = g.transform.FindChild("3").gameObject;
        Tiles[i][3] = g.transform.FindChild("4").gameObject;
        Tiles[i][4] = g.transform.FindChild("5").gameObject;
        Tiles[i][5] = g.transform.FindChild("6").gameObject;
        Tiles[i][6] = g.transform.FindChild("7").gameObject;
        Tiles[i][7] = g.transform.FindChild("8").gameObject;
        Tiles[i][8] = g.transform.FindChild("9").gameObject;
        Tiles[i][9] = g.transform.FindChild("10").gameObject;
        Tiles[i][10] = g.transform.FindChild("11").gameObject;
        Tiles[i][11] = g.transform.FindChild("12").gameObject;
    }

    public void DisableRoom(int i, int j)
    {
        //todo, disable all visuals for room, keep collisions enabled for pathing?
    }

    void randomTiles()
    {
        for(int i = 0; i < Tiles.Length; i++)
        {
            for(int j = 0; j < Tiles[i].Length; j++)
            {
                float num = Random.Range(0f, 10f);

                if(num < 1)
                {
                    GameObject g = Instantiate(Object1);
                    g.transform.parent = Tiles[i][j].transform;

                    g.transform.localPosition = new Vector3(0, 0, 0);
                    g.transform.rotation = new Quaternion(0, 0, 0, 0);

                }
                else if( num < 2)
                {
                    GameObject g = Instantiate(Object2);
                    g.transform.parent = Tiles[i][j].transform;

                    g.transform.localPosition = new Vector3(0, 0, 0);
                    g.transform.rotation = new Quaternion(0, 0, 0, 0);
                }
                else if (num < 3)
                {
                    GameObject g = Instantiate(Object3);
                    g.transform.parent = Tiles[i][j].transform;

                    g.transform.localPosition = new Vector3(0, 0, 0);
                    g.transform.rotation = new Quaternion(0, 0, 0, 0);
                }
            }
        }
    }
}

