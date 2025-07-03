using System;
using OpenTK;
using System.Drawing;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Juego2
{
	
	public class Bandeja
	{
		Punto posicion= new Punto(400,10);
		
		
		public Bandeja()
		{
		}
		
		public void derecha()
		{
			if(posicion.x<890)
			{
				posicion.x=posicion.x+10;
			}
			
		}
		public void izquierda()
		{
			if(posicion.x>10)
			{
				posicion.x=posicion.x-10;
			}
		}
		
		public void mostrar()
		{
			GL.Begin(PrimitiveType.Polygon);
			GL.Color3(Color.White);
			GL.Vertex2(posicion.x,posicion.y);
			GL.Vertex2(posicion.x,posicion.y+10);
			GL.Vertex2(posicion.x+100,posicion.y+10);
			GL.Vertex2(posicion.x+100,posicion.y);
			GL.End();
		}
		
		public double x
		{
			get{return posicion.x;}
			set{posicion.x=value;}
		}
		
		public double y
		{
			get{return posicion.y;}
			set{posicion.y=value;}
		}
	}
}
