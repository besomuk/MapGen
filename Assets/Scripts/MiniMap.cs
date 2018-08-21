using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniMap : MonoBehaviour 
{
	public static MiniMap mp;
	public Image img;

	Texture2D tex;

	void Awake () 
	{
		print( "Ja sam minimapa..." );

		if( mp == null )
			mp = this.GetComponent<MiniMap>();

		tex = new Texture2D( 512, 512 );      // dont forget to change this !!!
		tex.filterMode = FilterMode.Point;

	}

	void Update () 
	{
		
	}

	public void ClearTex ()
	{
		for( int i = 0; i < 512; i++ )
		{
			for( int j = 0; j < 512; j++ )
			{
				tex.SetPixel (  i, j, new Color( 1.0f, 1.0f, 1.000f, 1.0f ) );
			}
		}

		img.material.mainTexture = tex;
		img.transform.localScale = new Vector3( 0.5f, 0.5f, 1 );

		tex.Apply();		
	}

	public void ShowMiniMap ( bool _status )
	{
		img.gameObject.SetActive( _status );
	}

	public bool IsMiniMapOnScreen ()
	{
		return img.isActiveAndEnabled;
	}

	public void DrawMinimap( int[,] map, int mapWidth, int mapHeight)
	{		

		for( int i = 0; i < mapWidth; i++ )
		{
			for( int j = 0; j < mapHeight; j++ )
			{
				if( map[i, j] == 1 )                        // ako si trava
					tex.SetPixel( i, j, new Color( 0.486f, 0.988f, 0.000f, 1.0f ) );
				else if( map[i, j] == 4 || map[i, j] == 5 )  // ako si drvo
					tex.SetPixel( i, j, new Color( 0.000f, 0.392f, 0.000f, 1.0f ) );
				else if( map[i, j] == 6 )  // ako si voda
					tex.SetPixel( i, j, new Color( 0.118f, 0.565f, 1.000f, 1.0f ) );				
				else if( map[i, j] == 2 )  // ako si voda
					tex.SetPixel( i, j, new Color( 0.941f, 0.902f, 0.549f, 1.0f ) );				
				else if( map[i, j] == 0 || map[i, j] == 3)  // ako si kucica
				{
					DrawSquare( i-1, j-1, 1 );
					//DrawSquare( i, j, -5 );
					//DrawSquare( i, j, 3 );
				}
				else
					tex.SetPixel( i, j, Color.red );
			}
		}

		img.material.mainTexture = tex;
		img.transform.localScale = new Vector3( 0.5f, 0.5f, 1 );

		tex.Apply();

	}


	public void DrawSquare ( int _x, int _y, int _len )
	{
		int len = _len;
		DrawLine( tex, _x - len, _y - len, _x + len, _y - len, Color.red ); // dole 
		DrawLine( tex, _x - len, _y + len, _x + len, _y + len, Color.red ); // gore
		DrawLine( tex, _x - len, _y - len, _x - len, _y + len, Color.red ); // levo
		DrawLine( tex, _x + len, _y - len, _x + len, _y + len, Color.red ); // desno
		//DrawLine( tex, _x - len, _y - len, _x + len, _y - len, Color.red );
		tex.Apply();
	}

	public void Test ()
	{
		int a = 100;
		print( a );
	}
	void DrawLine(Texture2D tex, int x0, int y0, int x1, int y1, Color col)
	{
		int dy = (int)(y1-y0);
		int dx = (int)(x1-x0);
		int stepx, stepy;

		if (dy < 0) {dy = -dy; stepy = -1;}
		else {stepy = 1;}
		if (dx < 0) {dx = -dx; stepx = -1;}
		else {stepx = 1;}
		dy <<= 1;
		dx <<= 1;

		float fraction = 0;

		tex.SetPixel(x0, y0, col);
		if (dx > dy) {
			fraction = dy - (dx >> 1);
			while (Mathf.Abs(x0 - x1) > 1) {
				if (fraction >= 0) {
					y0 += stepy;
					fraction -= dx;
				}
				x0 += stepx;
				fraction += dy;
				tex.SetPixel(x0, y0, col);
			}
		}
		else {
			fraction = dx - (dy >> 1);
			while (Mathf.Abs(y0 - y1) > 1) {
				if (fraction >= 0) {
					x0 += stepx;
					fraction -= dy;
				}
				y0 += stepy;
				fraction += dx;
				tex.SetPixel(x0, y0, col);
			}
		}
	}
}
