using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayInfo : MonoBehaviour 
{
	public static DisplayInfo di;
	public Text txtPosition;
	public Text txtNumberOfHouses;
	public GameObject panel;

	// za boks
	public Text txtName;
	public Text txtType;
	public Text txtLevel;
	public Text txtTilePosition;

	public Button btnDestroy;

	private int positionX;
	private int positionY;

	void Awake () 
	{
		if( di == null )
		{
			di = this.GetComponent<DisplayInfo>();
		}

		panel.SetActive( false );

		btnDestroy.onClick.AddListener( BtnDestroyClick );

	}

	public void UpdateUI( string _txtPosition, string _txtHouses )
	{
		txtPosition.text = _txtPosition;
		txtNumberOfHouses.text = _txtHouses;
	}
 
	public void ShowTileInfo ( bool _status, string _name, string _type, int _level, int xpos, int ypos ) 
	{
		panel.SetActive( _status );
		txtTilePosition.text = "X: " + xpos + "; Y: " + ypos;
		positionX = xpos;
		positionY = ypos;
		txtName.text = "Name: " + _name;
		txtType.text = "Type: " + _type;
		if( _level != 0 )
		{
			txtLevel.text = "Level: " + _level;
			btnDestroy.gameObject.SetActive( true );
		}
		else
		{
			txtLevel.text = "";
			btnDestroy.gameObject.SetActive( false );
		}
	}

	public void ShowTileInfo ( bool _status ) 
	{
		panel.SetActive( _status );
	}

	void BtnDestroyClick ()
	{
		this.GetComponent<MapGenerator>().KillObject( positionX, positionY );
		//GetComponent<TileScript>().KillTile();
	}
}
