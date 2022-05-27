using ProyectoFinalCulebrita.ClaseCulebra;
using ProyectoFinalCulebrita.Estructura;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Threading;
using ProyectoFinalCulebrita.Modificado;

namespace ProyectoFinalCulebrita
{
    class Program
    {

        //convertirlo en un programa orietado a objetos
        //emitir beep cuando coma la comida
        //incrementar la velocidad conforme vaya avanzando

        //modificar el uso de queue y reemplazarlo con la estructura de cola vista en clase
        //colalinal arreglo
        //cola arraylist
        //cola lista enlazada

        // explicar qué pasa al alterar cada una de las lineas marcadas con las preguntas
        // se aprecia si pueden cambiar las reglas del juego o si le agrega cosas extra

        internal enum Direction { Abajo, Izquierda, Derecha, Arriba }


        static void Main()
        {
            //StartGame();
            StartGameColaCircular();
            
        }

        private static void StartGame()
        {
            var soundPlyaer = new SoundPlayer(@"C:\Users\click\Downloads\coinMarioBross (mp3cut.net).wav");
            int punteo = 0; // Variable para el punteo 
            int velocidad = 115; //Variable para la velocidad
            var posicionComida = Point.Empty; // pocicion para la comida
            var pantalla = new Size(80, 30); //el tamaño de la pantalla
            var snake = new Queue<Point>(); //la culebrita
            var longitudSnake = 8; // lo largo de la culebrita para empezar el juego
            var posicionInicio = new Point(0, 18); // Inicio
            var direccion = Direction.Izquierda; // direccion que tomara la culebrita


            var objSnake = new JuegoSnake(pantalla, snake, posicionInicio);
            var objPantalla = new WindowSnake(pantalla, punteo);

            objPantalla.dibujaPantalla();
            objPantalla.mostrarPunteo(punteo);

            while (objSnake.MoverLaCulebrita(posicionInicio, longitudSnake))
            {
                Thread.Sleep(velocidad);
                direccion = (Direction)objSnake.ObtieneDireccion((JuegoSnake.Direction)direccion);
                posicionInicio = objSnake.ObtieneSiguienteDireccion((JuegoSnake.Direction)direccion, posicionInicio);

                if (posicionInicio.Equals(posicionComida))
                {
                    soundPlyaer.Play();
                    posicionComida = Point.Empty;
                    longitudSnake++; //modificar estos valores y ver qué pasa
                    punteo += 10; //modificar estos valores y ver qué pasa
                   
                    // el sirve para ver la velocidad de la culebrita
                    if (punteo >= 10 && velocidad >= 1)
                    {
                        velocidad -= 3;
                    }
                    objPantalla.mostrarPunteo(punteo);

                }
                if (posicionComida == Point.Empty)
                {
                    posicionComida = objSnake.MostrarComida();
                }
            }
            int uno = 1;
            Console.ResetColor();
            Console.SetCursorPosition(pantalla.Width / 2 - 4, pantalla.Height / 2);
            Console.Write("Fin del Juego.");
            Thread.Sleep(2000);
            Console.ReadKey();

        }
       


    }//end class
    
}