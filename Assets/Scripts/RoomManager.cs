using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour {

    public float sizeModifier;
    public int collumns = 5;
    public int rows = 5;
    public int actRow = 0;
    public int actCol = 2;

    public GameObject Room;

    private GameObject[][] Rooms;

	// Use this for initialization
	void Start () {
        Rooms = new GameObject[rows][];

        for(int i = 0; i < rows; i++)
        {
            Rooms[i] = new GameObject[collumns];
        }

        for(int i = 0; i < rows; i++)
        {
            for(int j = 0; j < collumns; j++)
            {
                Rooms[i][j] = Instantiate(Room);
                string s = i + " " + j;
                Rooms[i][j].name = s;


                //TODO Commented out section is original, uncomment and delete lines below to return to original condition
                //Rooms[i][j].transform.position = new Vector3((j - 2) * 1500, i * -1000, 0);
                Rooms[i][j].transform.position = new Vector3(((j - 2) * 1500) * sizeModifier, (i * -1000) * sizeModifier, 0);

                if (i == actRow && j == actCol)
                {
                    //RoomScript.DisableRoom(i, j); todo?
                    Rooms[i][j].SetActive(true);
                }
                else
                {
                    Rooms[i][j].SetActive(false);
                }
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DisableRoom(int i, int j)
    {
        Rooms[i][j].SetActive(false);
    }

    public void EnableRoom(int i, int j)
    {
        Rooms[i][j].SetActive(true);
    }

    public int getRows() { return rows; }
    public int getCollumns() { return collumns; }
    public int getActiveRow() { return actRow; }
    public int getActiveCol() { return actCol; }
    public Transform getRoomTransform(int i, int j)
    {
        return Rooms[i][j].transform;
    }
}
