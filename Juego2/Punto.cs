using System;

namespace Juego2
{
	
	public class Punto
	{
		double px,py;
		public Punto()
		{
			px=py=0;
			
		}
		
		public Punto(double x, double y)
		{
			px=x;
			py=y;
		}
		
		public double x
		{
			get{return px;}
			set{px=value;}
		}
		public double y
		{
			get{return py;}
			set{py=value;}
		}
		
	}
}