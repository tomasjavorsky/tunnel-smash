using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDataGenerator : MonoBehaviour
{

	[Range(32, 128)]
	public int width = 64, height = 64; //Defines size of map
	[Range(46, 50)]
	public int rockFillPercent = 48;
	[Range(46, 50)]
	public int ironFillPercent = 48;
	private int[,] map, ironMap;


	private void Start()
	{
		GenerateMapData();
		PrintIntoTexture();
	}

	private void Update()
	{
		if(Input.GetMouseButton(0))
		{
			GenerateMapData();
			PrintIntoTexture();
		}
	}

	private void GenerateMapData()
	{
		map = new int[width, height];
		ironMap = new int[width, height];
		for(int x = 0; x < width; x++)
		{
			for(int y = 0; y < height; y++)
			{
				map[x, y] = (Random.Range(0, 100) < rockFillPercent) ? 1 : 0;
				ironMap[x,y] = (Random.Range(0, 100) < ironFillPercent) ? 1 : 0;
			}
		}

		for(int i = 0; i < 5; i++)
		{
			SmoothMap(map);
			SmoothMap(ironMap);
		}
		

	}

	private void SmoothMap(int[,] map)
	{
		for(int x = 0; x < width; x++)
		{
			for(int y = 0; y < height; y++)
			{
				map[x, y] = GetSurroundingWallCount(x, y, map) > 4 ? 1 : 0;
			}
		}
	}

	private int GetSurroundingWallCount(int posX, int posY, int[,] map)
	{
		int neighbours = 0;

		for(int x = posX - 1; x <= posX + 1; x++)
		{
			for(int y = posY - 1; y <= posY + 1; y++)
			{
				if(x >= 0 && x < width && y >= 0 && y < height) {
					neighbours += map[x, y];
				}
				else
				{
					neighbours++;
				}
			}
		}
		return neighbours;
	}

	//TODO IRON INTERSECTION

	private void PrintIntoTexture()
	{
		Texture2D mapTexture = new Texture2D(width, height);
		for(int y = 0; y < mapTexture.height; y++)
		{
			for(int x = 0; x < mapTexture.width; x++)
			{
				Color color = (map[x, y] == 1 ? Color.gray : Color.yellow);
				mapTexture.SetPixel(x, y, color);
			}
		}
		mapTexture.Apply();
		GetComponent<Renderer>().material.SetTexture("_BaseMap", mapTexture);

	}
}



