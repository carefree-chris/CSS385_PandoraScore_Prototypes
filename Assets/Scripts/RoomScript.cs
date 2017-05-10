using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RoomPrefabs
{
    public Color32 color;
    public GameObject[] onebyone;
    public GameObject[] onebytwo;
    public GameObject[] twobyone;
    public GameObject[] twobytwo;
    public GameObject[] threebythree;
}

public class RoomScript : MonoBehaviour
{

    public RoomPrefabs[] RoomPrefabs;

    public GameObject Door;

    private GameObject[] Doors;
    private GameObject[][] Tiles;

    List<GameObject> Interactables = new List<GameObject>();

    // Use this for initialization
    void Start()
    {

        Doors = new GameObject[4];

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
    }

    // Update is called once per frame
    void Update()
    {

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

    public void init(int num, Texture2D room)
    {
        Tiles = new GameObject[7][];

        for (int i = 0; i < Tiles.Length; i++)
        {
            Tiles[i] = new GameObject[12];
        }

        GameObject t = transform.FindChild("Tiles").gameObject;

        InitTiles(6, t.transform.FindChild("Row 1").gameObject);
        InitTiles(5, t.transform.FindChild("Row 2").gameObject);
        InitTiles(4, t.transform.FindChild("Row 3").gameObject);
        InitTiles(3, t.transform.FindChild("Row 4").gameObject);
        InitTiles(2, t.transform.FindChild("Row 5").gameObject);
        InitTiles(1, t.transform.FindChild("Row 6").gameObject);
        InitTiles(0, t.transform.FindChild("Row 7").gameObject);

        Color32[] pixels = room.GetPixels32();

        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 12; j++)
            {
                spawnTiles(pixels[(i * 12) + j], Tiles[i][j]);
            }
        }
    }

    private void spawnTiles(Color32 c, GameObject t)
    {
        foreach (RoomPrefabs r in RoomPrefabs)
        {
            if (c.Equals(r.color))
            {
                placeObject(r, t);
            }
        }
    }

    public void DisableRoom(int i, int j)
    {
        //todo, disable all visuals for room, keep collisions enabled for pathing?
    }

    void placeObject(RoomPrefabs room, GameObject t)
    {
        GameObject g = Instantiate(room.onebyone[Random.Range(0, room.onebyone.Length - 1)]);
        g.transform.parent = t.transform;

        g.transform.localPosition = new Vector3(0, 0, 0);
        g.transform.rotation = new Quaternion(0, 0, 0, 0);

        if (room == RoomPrefabs[0] || room == RoomPrefabs[1] || room == RoomPrefabs[2])
        {
            Interactables.Add(g);
        }
    }

    void placeHazards()
    {

    }

    public void placeKey()
    {
        int num = Random.Range(0, Interactables.Count - 1);
        Interactables[num].tag = "HasKey";
    }
}
