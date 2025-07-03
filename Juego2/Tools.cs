using System;
using OpenTK;
using System.Drawing;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;


namespace Juego2
{
	
	public class Tools
	{
		public Tools()
		{
		}
		
		
		public double distanc(Punto a, Punto b)
		{
			double d;
			d=Math.Sqrt(Math.Pow((a.x-b.x),2)+Math.Pow((a.y-b.y),2));
			return d;
		}
		
	
	}
}