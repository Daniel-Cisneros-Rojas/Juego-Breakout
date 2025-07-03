using System;
using OpenTK;
using System.Drawing;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Juego2
{

	public class Bloques
	{
		Punto origen=new Punto();
		Punto referencia=new Punto();
		int largo,lado_colision=0,activo=1,color=1; 
		double distancia;
		
		public Bloques()
		{
			
			origen.x=0;
			origen.y=0;
		}
		
		public Bloques(Punto a)
		{
			origen.x=a.x;
			origen.y=a.y;
		}
		
		public double x
		{
			get{return origen.x;}
			set{origen.x=value;}
		}
		public double y
		{
			get{return origen.y;}
			set{origen.y=value;}
		}
		
		public void poner_color(int c)
		{
			color=c;
		}
		public double distanc(Punto a, Punto b)
		{
			double d;
			d=Math.Sqrt(Math.Pow((a.x-b.x),2)+Math.Pow((a.y-b.y),2));
			return d;
		}
		
		public void dibujar()
		{
			if(color==1)
			{
				GL.Color3(Color.Pink);
			}
			if(color==2)
			{
				GL.Color3(Color.LimeGreen);
			}
			if(color==3)
			{
				GL.Color3(Color.Red);
			}
			if(color==4)
			{
				GL.Color3(Color.CornflowerBlue);
			}
			GL.Begin(PrimitiveType.Polygon);
			GL.Vertex2(origen.x,origen.y);
			GL.Vertex2(origen.x+100,origen.y);
			GL.Vertex2(origen.x+100,origen.y+50);
			GL.Vertex2(origen.x,origen.y+50);
			GL.End();
			
			GL.Begin(PrimitiveType.LineLoop);
			GL.Color3(Color.White);
			GL.Vertex2(origen.x,origen.y);
			GL.Vertex2(origen.x+100,origen.y);
			GL.Vertex2(origen.x+100,origen.y+50);
			GL.Vertex2(origen.x,origen.y+50);
			GL.End();
		}
		
		public int buscar_colision(Pelota bola)
		{
			referencia.x=bola.x;
			if ( referencia.x < origen.x ) referencia.x = origen.x;
			if ( referencia.x > origen.x + 100 ) referencia.x = origen.x+100;
			referencia.y = bola.y;
            if ( referencia.y < origen.y ) referencia.y = origen.y;
            if ( referencia.y > origen.y+50 ) referencia.y = origen.y+50 ;
            distancia = distanc(referencia,new Punto(bola.x,bola.y));
            
            if ( distancia < bola.rad() ) 
               {
            	if((int)referencia.y==(int)origen.y+50)
            	{
            		lado_colision=2;
            	}
            	else if((int)referencia.y==(int)origen.y)
            	{
            		lado_colision=4;
            	}
            	else if((int)referencia.x==(int)origen.x)
            	{
            		lado_colision=1;
            	}
            	else if((int)referencia.x==(int)origen.x+100)
            	{
            		lado_colision=3;
            	}
            	
            	activo=0;
            	return lado_colision;
            	
               }
            //GL.Begin(PrimitiveType.Lines);
            //GL.Vertex2(bola.x,bola.y);
            //GL.Vertex2(referencia.x,referencia.y);
            //GL.End();
            return 0;
		}
		
		public int vivo()
		{
			return activo;
		}
		
	}
}
