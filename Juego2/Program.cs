using System;
using OpenTK;
using System.Drawing;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Juego2
{
	class Program
	{
		public static void Main(string[] args)
		{
			Pantalla game=new Pantalla();
			game.Run(1.0/60.0);
		}
	}
}