// --------------------------------------------
// Sara Reyes Grao
// Curso DAW
// Modalidad Presencial
// Práctica nº 2
// --------------------------------------------

using System;
public class practica_2
{
	public static void Main()
	{
		 
		int contador = 0; 
		int intentos = 6;
		string palabra;
		char letra;
		bool y = false;
		bool fin = false;

		Console.Write("Introduce una palabra para adivinar: ");
		palabra = Console.ReadLine();
		Console.Clear();
		
		char[] letras = new char[palabra.Length];

		for (int i = 0; i < palabra.Length; i++)
			Console.Write("_ ");

		do
		{  	
			Console.WriteLine();	
			Console.Write("Introduce una letra: ");
			letra = Convert.ToChar(Console.ReadLine());	

			contador = 0;
			for (int x = 0; x < palabra.Length; x++)
			{
				if (letra == palabra[x])
				{
					letras[x] = palabra[x];
					y = true;
				}

				if (letras[x] != '\0') 
					contador++;
			}

			for (int i = 0; i < palabra.Length; i++)
			{
				if (letras[i] == '\0') 
				Console.Write("_ ");
				else 
						Console.Write(letras[i] + " ");
			}

			if (y == false)
			{
				intentos--;
				Console.WriteLine("\n\nLetra incorrecta, te quedan {0} intentos", intentos);
				Console.Write(" ┌───┐");

				switch (intentos)
				{
					case 5: Console.Write("\n │   O\n │\n |\n │"); break;
					case 4: Console.Write("\n │   O\n │  /\n |\n │"); break;
					case 3: Console.Write("\n │   O\n │  /| \n |\n │"); break;
					case 2: Console.Write("\n │   O\n │  /|\\ \n |  \n │"); break;
					case 1: Console.Write("\n │   O\n │  /|\\ \n |  / \n │"); break;
					case 0: Console.Write("\n │   O\n │  /|\\ \n |  / \\ \n │"); break;	
				}
				Console.WriteLine("\n ┴───────   ");
			}
			y = false;	

			if (contador == palabra.Length) 
			{
				fin = true; 
				Console.WriteLine("\n¡¡FELICIDADES!! Has acertado la palabra.");
			}

			if (intentos == 0) 
			{
				fin = true;
				Console.WriteLine("  R.I.P. La palabra era: {0}", palabra);
			}
		}
		while (fin == false);
	}
}