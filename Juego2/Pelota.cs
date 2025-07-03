using System;
using OpenTK;
using System.Drawing;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Juego2
{
	
	public class Pelota
	{
		public Pelota()
		{
		}
		int color=1,control=-1,radio=15,colision_activa=1;
		double distancia;
		Punto referencia=new Punto();
		Punto posicion=new Punto();
		public void CirculoPolar(Punto centro)
		{
			
			GL.Begin(PrimitiveType.Polygon);
			if(color==1)
			{
				GL.Color3(Color.Yellow);
			}
			if(color==2)
			{
				GL.Color3(Color.Purple);
			}
			
			for(double theta=0;theta<Math.PI*2;theta+=0.01)
			{
				GL.Vertex2(centro.x +(Math.Cos(theta)*radio),centro.y +(Math.Sin(theta))*radio);
			}
			GL.End();
		}
		
		public Punto trayecto(Punto a,double theta,double cambio)
		{
			int x,y;
			theta=theta*Math.PI/180;
			x=(int)(a.x+(Math.Cos(theta)*radio*cambio));
			y=(int)(a.y+(Math.Sin(theta))*radio*cambio);
			posicion.x=x;
			posicion.y=y;
			CirculoPolar(new Punto(x,y));
			return new Punto(x,y);
		}
		
		public int choque(Punto a,Bandeja jugador)
		{
			int lado_pego=0;
			
			if(a.x+radio>1000)
			{
				lado_pego=3;
			}
			
			if(a.x-radio<0)
			{
				lado_pego=1;
			}
			
			if(a.y+radio>1000)
			{
				lado_pego=2;
			}
			
			if(a.y<0)
			{
				lado_pego=4;
			}
			
			
			
			
			//colision con bandeja
			referencia.x=a.x;
			if ( referencia.x < jugador.x ) referencia.x = jugador.x;
			if ( referencia.x > jugador.x + 100 ) referencia.x = jugador.x+100;
			referencia.y = a.y;
            if ( referencia.y < jugador.y ) referencia.y = jugador.y;
            if ( referencia.y > jugador.y+10 ) referencia.y = jugador.y+10 ;
            distancia = distanc(referencia,a);
            //Console.WriteLine(distancia);
            //linea control
            
            
            if ( distancia < radio ) {
            	lado_pego=5;
               }

			if(lado_pego!=0&&lado_pego!=control)
			{
				control=lado_pego;
				if(color==1)
				{
					color=2;
				}
				else
				{
					color=1;
				}
			}
			
			return lado_pego;
		}
		
		public int coli
		{
			get{return colision_activa;}
			set{colision_activa=value;}
		}
		
		public void cambiar_color()
		{
			if(color==1)
			{
				color=2;
			}
			else
			{
				color=1;
			}
		}
		
		public double distanc(Punto a, Punto b)
		{
			double d;
			d=Math.Sqrt(Math.Pow((a.x-b.x),2)+Math.Pow((a.y-b.y),2));
			return d;
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
		public int rad()
		{
			return radio;
		}
		
	}
}
