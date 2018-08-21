using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSONParser : MonoBehaviour 
{
	private string filePath;

	void Start () 
	{
		//string jsonContent = loadJSON("map.json");
		//print( jsonContent );

		//string x;

		MapInfo mp = new MapInfo();
		mp = JsonUtility.FromJson<MapInfo>( loadJSON ( "map.json") );

		print( "width : " + mp.map_width );
		print( "height: " + mp.map_height );
		print( "houses: " + mp.number_of_houses );
		print( "tiles : " + mp.tiles.Length );
	}
	

	void Update () 
	{
		
	}

	string loadJSON( string fileName )
	{
		fileName = fileName.Replace( ".json", "" );
		TextAsset data = Resources.Load<TextAsset>( fileName );
		return data.text;
	}
}
