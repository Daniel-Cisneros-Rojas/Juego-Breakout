using System;
using OpenTK;
using System.Drawing;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Juego2
{
	public class Graficos
	{
		
		public Graficos()
		{
		}
		int color=1,control=-1;
		
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
				GL.Vertex2(centro.x +(Math.Cos(theta)*40),centro.y +(Math.Sin(theta))*40);
			}
			GL.End();
		}
		
		public double distanc(Punto a, Punto b)
		{
			double d;
			d=Math.Sqrt(Math.Pow((a.x-b.x),2)+Math.Pow((a.y-b.y),2));
			return d;
		}
		
		public void bordes()
		{
			GL.Begin(PrimitiveType.Lines);
			GL.Color3(Color.Black);
			GL.Vertex2(0,0);
			GL.Vertex2(900,0);
			
			GL.Vertex2(1,0);
			GL.Vertex2(1,900);
			
			GL.Vertex2(1,899);
			GL.Vertex2(900,899);
			
			GL.Vertex2(900,899);
			GL.Vertex2(900,0);
			
			GL.End();
			
		}
		
		
public void palabra_perdiste(Punto a)
		{
			GL.LineWidth(3);
            GL.Begin(PrimitiveType.LineStrip);
            GL.Color3(Color.White);
            GL.Vertex2(a.x+10,a.y);
            GL.Vertex2(a.x+10,a.y+30);
            GL.Vertex2(a.x+30,a.y+30);
            GL.Vertex2(a.x+30,a.y+15);
            GL.Vertex2(a.x+10,a.y+15);
            GL.End();
            
            GL.LineWidth(3);
            GL.Begin(PrimitiveType.LineStrip);
            GL.Vertex2(a.x+60,a.y);
            GL.Vertex2(a.x+40,a.y);
            GL.Vertex2(a.x+40,a.y+15);
            GL.Vertex2(a.x+60,a.y+15);
            GL.Vertex2(a.x+40,a.y+15);
            GL.Vertex2(a.x+40,a.y+30);
            GL.Vertex2(a.x+60,a.y+30);
            GL.End();
            
            GL.LineWidth(3);
            GL.Begin(PrimitiveType.LineStrip);
            GL.Vertex2(a.x+70,a.y);
            GL.Vertex2(a.x+70,a.y+30);
            GL.Vertex2(a.x+90,a.y+30);
            GL.Vertex2(a.x+90,a.y+15);
            GL.Vertex2(a.x+70,a.y+15);
            GL.Vertex2(a.x+90,a.y+15);
            GL.Vertex2(a.x+94,a.y);
            GL.End();
            
            GL.LineWidth(3);
            GL.Begin(PrimitiveType.LineStrip);
            GL.Vertex2(a.x+100,a.y);
            GL.Vertex2(a.x+100,a.y+30);
            GL.Vertex2(a.x+110,a.y+30);
            GL.Vertex2(a.x+120,a.y+15);
            GL.Vertex2(a.x+110,a.y);
            GL.Vertex2(a.x+100,a.y);
            GL.End();
            
            GL.LineWidth(3);
            GL.Begin(PrimitiveType.LineStrip);
            GL.Vertex2(a.x+130,a.y);
            GL.Vertex2(a.x+130,a.y+30);
            GL.End();
            
            GL.LineWidth(3);
            GL.Begin(PrimitiveType.LineStrip);
            GL.Vertex2(a.x+140,a.y);
            GL.Vertex2(a.x+160,a.y);
            GL.Vertex2(a.x+160,a.y+15);
            GL.Vertex2(a.x+140,a.y+15);
            GL.Vertex2(a.x+140,a.y+30);
            GL.Vertex2(a.x+160,a.y+30);
            GL.End();
            
            GL.LineWidth(3);
            GL.Begin(PrimitiveType.LineStrip);
            GL.Vertex2(a.x+180,a.y);
            GL.Vertex2(a.x+180,a.y+30);
            GL.Vertex2(a.x+170,a.y+30);
            GL.Vertex2(a.x+190,a.y+30);
            GL.End();
            
            GL.LineWidth(3);
            GL.Begin(PrimitiveType.LineStrip);
            GL.Vertex2(a.x+220,a.y);
            GL.Vertex2(a.x+200,a.y);
            GL.Vertex2(a.x+200,a.y+15);
            GL.Vertex2(a.x+220,a.y+15);
            GL.Vertex2(a.x+200,a.y+15);
            GL.Vertex2(a.x+200,a.y+30);
            GL.Vertex2(a.x+220,a.y+30);
            GL.End();
		}
		
		
	}
}