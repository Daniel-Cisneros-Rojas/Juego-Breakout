using System;
using OpenTK;
using System.Drawing;
using OpenTK.Graphics;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL;
namespace Juego2
{
	
	public class Pantalla:GameWindow
	{
		Bloques[]bloque=new Bloques[54];
		Bandeja jugador=new Bandeja();
		Graficos letras=new Graficos();
		Pelota[] bola=new Pelota[1];
		double[] angulo=new double[1];
		double[] tiempo=new double[1];
		Punto[] inicio=new Punto[10];
		Punto[] actual=new Punto[10];
		int lado=0,min,max,ajuste=0,opcion=1,color=1,lado_pego_bloque=0,bajar_y=0,ajuste_x=0,cantidad_activos,perdiste=0,bolas=3;
		Random rnd = new Random();
		int[] control=new int[1];
		
		public Pantalla():base(800,600,GraphicsMode.Default,"Breakout")
		{
			
		}
		
		protected override void OnLoad(EventArgs e)
		{
			GL.ClearColor(Color.Black);
			GL.MatrixMode(MatrixMode.Projection);
			GL.Ortho(0,1000,0,1000,-1,1);
			for(int i=0;i<bola.Length;i++)
			{
				inicio[i]=new Punto(400,300);
				actual[i]=new Punto(400,300);
				angulo[i]=270;
				tiempo[i]=0;
				bola[i]=new Pelota();
				control[i]=0;
			}
			cantidad_activos=bloque.Length;
			for(int i=0,k=0;i<bloque.Length;i++)
			{
				bloque[i]=new Bloques();
				bloque[i].poner_color(color);
				bloque[i].x=ajuste_x+(k*100);
				bloque[i].y=800-(bajar_y);
				k++;
				if(k==10&&ajuste_x==0)
				{
					k=0;
					bajar_y=bajar_y+50;
					if(ajuste_x==0)
					{
						ajuste_x=-50;
					}
					else
					{
						ajuste_x=0;
					}
					color++;
				}
				if(k==12)
				{
					k=0;
					bajar_y=bajar_y+50;
					if(ajuste_x==0)
					{
						ajuste_x=-50;
					}
					else
					{
						ajuste_x=0;
					}
					color++;
				}
				if(color==5)
				{
					color=1;
				}
			}
			
		}
		
		protected override void OnUpdateFrame(FrameEventArgs e)
		{
			GL.Clear(ClearBufferMask.ColorBufferBit);
			
			if(perdiste==0)
			{
				for(int i=0;i<bola.Length;i++)
			{
			tiempo[i]=tiempo[i]+0.3;
			lado=bola[i].choque(actual[i],jugador);
			
				
			//Console.WriteLine(angulo[i]);
			switch(lado)
			{
				case 0:
					ajuste=0;
					break;
				case 1:
					tiempo[i]=0.18;
					inicio[i]=actual[i];
					if(angulo[i]<180&&angulo[i]>90)
					{
						angulo[i]=180-angulo[i];
						//angulo[i]=90-angulo[i];
					}
					
					if(angulo[i]>180&&angulo[i]<270)
					{
						angulo[i]=angulo[i]-180;
						angulo[i]=360-angulo[i];
					}
					
					
					ajuste++;
					break;
				case 2:
					tiempo[i]=0.12;
					inicio[i]=actual[i];
					if(angulo[i]<90&&angulo[i]>0)
					{
						angulo[i]=360-angulo[i];
					}
					
					if(angulo[i]>90&&angulo[i]<180)
					{
						angulo[i]=angulo[i]-90;
						angulo[i]=180+angulo[i];
					}
					ajuste++;
					break;
				case 3:
					tiempo[i]=0.1;
					inicio[i]=actual[i];
					if(angulo[i]<90&&angulo[i]>0)
					{
						angulo[i]=180-angulo[i];
					}
					
					if(angulo[i]>270&&angulo[i]<360)
					{
						angulo[i]=360-angulo[i];
						angulo[i]=180+angulo[i];
					}
					ajuste++;
					break;
				case 4:
					bolas--;
					if(bolas==0)
					{
						perdiste=1;
					}
					else
					{
						inicio[i].x=jugador.x+50;
						inicio[i].y=300;
						tiempo[i]=0.1;
						angulo[i]=270;
					}
					break;
				case 5:
					tiempo[i]=0.1;
					inicio[i]=actual[i];
					opcion=rnd.Next(1,3);
					
					if(opcion==1)
					{
					 min=20;
					 max=70;	
					}
					if(opcion==2)
					{
					 min=110;
					 max=150;
					}
					
					angulo[i]=rnd.Next(min, max);
					ajuste++;
					break;
				default:
					
					break;
			 }
			}
			}
			else
			{
				letras.palabra_perdiste(new Punto(300,500));
			}
		}
		
		protected override void OnRenderFrame(FrameEventArgs e)
		{
			 
			jugador.mostrar();
			
			for(int j=0;j<bola.Length;j++)
			{
				actual[j]=bola[j].trayecto(inicio[j],angulo[j],tiempo[j]);
				
				for(int i=0;i<bloque.Length;i++)
			{
					if(bloque[i].vivo()==1)
					{
						bloque[i].dibujar();
				       lado_pego_bloque=bloque[i].buscar_colision(bola[j]);
					switch(lado_pego_bloque)
			{
				case 0:
					ajuste=0;
					break;
				case 1:
					tiempo[j]=0.1;
					inicio[j]=actual[j];
					if(angulo[j]<90&&angulo[j]>0)
					{
						angulo[j]=180-angulo[j];
					}
					
					if(angulo[j]>270&&angulo[j]<360)
					{
						angulo[j]=360-angulo[j];
						angulo[j]=180+angulo[j];
					}
					ajuste++;
					break;
				case 2:
					tiempo[j]=0.1;
					inicio[j]=actual[j];
					if(angulo[j]<270&&angulo[j]>180)
					{
						angulo[j]=angulo[j]-180;
						angulo[j]=180-angulo[j];
					}
					
					if(angulo[j]>270&&angulo[j]<360)
					{
						angulo[j]=360-angulo[j];
					}
					ajuste++;
					break;
				case 3:
					
					tiempo[j]=0.1;
					inicio[j]=actual[j];
					if(angulo[j]<180&&angulo[j]>90)
					{
						angulo[j]=180-angulo[j];
						//angulo[i]=90-angulo[i];
					}
					
					if(angulo[j]>180&&angulo[j]<270)
					{
						angulo[j]=angulo[j]-180;
						angulo[j]=360-angulo[j];
					}
					
					
					ajuste++;
					break;
				case 4:
					tiempo[j]=0.12;
					inicio[j]=actual[j];
					if(angulo[j]<90&&angulo[j]>0)
					{
						angulo[j]=360-angulo[j];
					}
					
					if(angulo[j]>90&&angulo[j]<180)
					{
						angulo[j]=angulo[j]-90;
						angulo[j]=180+angulo[j];
					}
					ajuste++;
					break;
				
				default:
					
					break;
			 }
					}
				
				
				
			}
			}
			
		  
			SwapBuffers();
		}
		
		protected override void OnResize(EventArgs e)
		{
			GL.Viewport(0,0,Width,Height);
		}
		
		protected override void OnKeyPress(KeyPressEventArgs e)
		{
			if(e.KeyChar=='a')
			{
				jugador.izquierda();
				
			}
			
			if(e.KeyChar=='d')
			{
				jugador.derecha();
				
			}
			

			base.OnKeyPress(e);
		}
		
		
		
	}
}