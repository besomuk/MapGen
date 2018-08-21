using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TileScript : MonoBehaviour 
{
	public string _name;
	public string _type;
	public int _level;
	public int _xpos;
	public int _ypos;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown ()
	{
		if( !EventSystem.current.IsPointerOverGameObject() ) // fix for 'see through'
		{
			DisplayInfo.di.ShowTileInfo( true, _name, _type, _level, _xpos, _ypos );

			if( _level != 0 )
			{
				//DisplayInfo.di.ShowTileInfo( true, _name, _type, _level, _xpos, _ypos );
			}
			else
			{
				//DisplayInfo.di.ShowTileInfo( false );
			}
		}
	}

	public void KillTile()
	{
		print ("tile script kill tile...");
	}

	public void SetPosition ( int x, int y )
	{
		_xpos = x;
		_ypos = y;
	}

	public string Name
	{
		set
		{
			_name = value;
		}
		get
		{
			return _name;
		}
	}

	public string Type
	{
		set
		{
			_type = value;
		}
		get
		{
			return _type;
		}
	}

	public int Level
	{
		set
		{
			_level = value;
		}
		get
		{
			return _level;
		}
	}
}
