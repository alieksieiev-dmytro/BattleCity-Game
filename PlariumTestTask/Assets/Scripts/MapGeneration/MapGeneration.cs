using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour
{
    public Transform[] startingPosition;
    public GameObject[] rooms;

    public GameObject[] friendlyRooms;
    public GameObject[] enemyRooms;

    private int direction;
    public float moveAmount;

    public float minX, maxX, minY;
    public bool stopGeneration;

    public LayerMask room;

    private int downcounter;

    public Transform player;

    private Transform fixedStartingPosition;
    private int fixedStartingRoom;

    private void Start()
    {
        int randStartingPos = Random.Range(0, startingPosition.Length);
        transform.position = startingPosition[randStartingPos].position;
        int rand = Random.Range(0, rooms.Length);
        Instantiate(rooms[rand], transform.position, Quaternion.identity);

        fixedStartingPosition = startingPosition[randStartingPos];
        fixedStartingRoom = rand;

        direction = Random.Range(1, 6);
    }

    private void Update()
    {
        if (!stopGeneration)
        {
            Move();
        }
    }

    private void Move()
    {
        if (direction == 1 || direction == 2)
        {
            if (transform.position.x < maxX)
            {
                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6);

                if (direction == 3)
                {
                    direction = 2;
                } 
                else if (direction == 4)
                {
                    direction = 5;
                }
            }
            else
            {
                direction = 5;
            }
        }
        else if (direction == 3 || direction == 4)
        {
            if (transform.position.x > minX)
            {
                downcounter = 0;
                Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(0, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(3, 6);
            }
            else
            {
                direction = 5;
            }
        } 
        else if (direction == 5)
        {
            downcounter++;

            if (transform.position.y > minY)
            {
                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, room);

                if (roomDetection.GetComponent<RoomType>().type != 1 && roomDetection.GetComponent<RoomType>().type != 3)
                {
                    if (downcounter >= 2)
                    {
                        roomDetection.GetComponent<RoomType>().RoomDestruction();
                        Instantiate(rooms[3], transform.position, Quaternion.identity);
                    }
                    else
                    {
                        roomDetection.GetComponent<RoomType>().RoomDestruction();

                        int randBottomRoom = Random.Range(1, 4);
                        if (randBottomRoom == 2)
                        {
                            randBottomRoom = 1;
                        }
                        Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);
                        fixedStartingRoom = randBottomRoom;
                    }
                }

                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = newPos;

                int rand = Random.Range(2, 4);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1, 6);
            }
            else
            {
                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, room);
                Instantiate(enemyRooms[roomDetection.GetComponent<RoomType>().type], transform.position, Quaternion.identity);
                roomDetection.GetComponent<RoomType>().RoomDestruction();

                Collider2D startingRoomDetection = Physics2D.OverlapCircle(fixedStartingPosition.position, 1, room);
                Instantiate(friendlyRooms[fixedStartingRoom], fixedStartingPosition.position, Quaternion.identity);
                startingRoomDetection.GetComponent<RoomType>().RoomDestruction();

                SpawnPlayer();

                stopGeneration = true;
            }
        }
    }

    private void SpawnPlayer()
    {
        SpawnPoint sp  = friendlyRooms[fixedStartingRoom].GetComponent<SpawnPoint>();
        Vector3 newPosition = sp.spawnPoint.transform.position;
        if (fixedStartingPosition.position.x > 5)
        {
            player.position = new Vector3(newPosition.x
                - 4f
                + fixedStartingPosition.position.x, newPosition.y, player.position.z);
        }
        else
        {

            player.position = new Vector3(newPosition.x
                + 1f, newPosition.y, player.position.z);
        }
    }
}
