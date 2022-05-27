using ProyectoFinalCulebrita.Estructura;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalCulebrita.Modificado
{
    //son Variables 
    Size pantalla;
    ListaEnlazada<Point> snake;
    Point puntoInicio;

    
    public enum Direction { Abajo, Izquierda, Derecha, Arriba }

    //este metodo crea la serpiente
    public ListaEncs(Size tmPantalla, ListaEnlazada<Point> snk, Point pocisionInicio)
    {
        this.pantalla = tmPantalla;
        this.snake = snk;
        this.puntoInicio = pocisionInicio;
        this.snake.Insertar(puntoInicio);
    }



    public Point ObtieneSiguienteDireccion(Direction direction, Point currentPosition)
    {
        //REpresenta las coordenadas ordenadas
        Point siguienteDireccion = new Point(currentPosition.X, currentPosition.Y);
        switch (direction)
        {
            case Direction.Arriba:
                siguienteDireccion.Y--;
                break;
            case Direction.Izquierda:
                siguienteDireccion.X--;
                break;
            case Direction.Abajo:
                siguienteDireccion.Y++;
                break;
            case Direction.Derecha:
                siguienteDireccion.X++;
                break;
        }
        return siguienteDireccion;
    }

    public Direction ObtieneDireccion(Direction direccionAcutal)
    {
        //Obtiene el dato que indica que esta disponible
        if (!Console.KeyAvailable) return direccionAcutal;

        //Este metodo hace que el programam que al presionar una tecla evite la pantalla
        var tecla = Console.ReadKey(true).Key;
        switch (tecla)
        {
            case ConsoleKey.DownArrow:
                if (direccionAcutal != Direction.Arriba)
                    direccionAcutal = Direction.Abajo;
                break;
            case ConsoleKey.LeftArrow:
                if (direccionAcutal != Direction.Derecha)
                    direccionAcutal = Direction.Izquierda;
                break;
            case ConsoleKey.RightArrow:
                if (direccionAcutal != Direction.Izquierda)
                    direccionAcutal = Direction.Derecha;
                break;
            case ConsoleKey.UpArrow:
                if (direccionAcutal != Direction.Abajo)
                    direccionAcutal = Direction.Arriba;
                break;
        }
        return direccionAcutal;
    }

    public bool MoverLaCulebrita(Point posiciónObjetivo,
        int longitudCulebra)
    {
        var lastPoint = snake.Last();

        //Compara la ultima posicion a ver si es igual
        if (lastPoint.Equals(posiciónObjetivo)) return true;

        // verifica si el elemto cumple las condiciones de los datos y si no existe ninguna coincidencia
        //pero el signo de admiracion cabia el valor depende de lo llegue del metodo
        if (!snake.Any((posiciónObjetivo))) return false;

        //  hace que la culebrita no salga de la pantalla y retorna el false
        if (posiciónObjetivo.X < 0 || posiciónObjetivo.X >= pantalla.Width
                || posiciónObjetivo.Y < 0 || posiciónObjetivo.Y >= pantalla.Height)
        {
            return false;
        }

        Console.BackgroundColor = ConsoleColor.Green;
        Console.SetCursorPosition(lastPoint.X + 1, lastPoint.Y + 1);
        Console.WriteLine(" ");

        snake.Insertar(posiciónObjetivo);

        Console.BackgroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(posiciónObjetivo.X + 1, posiciónObjetivo.Y + 1);
        Console.Write(" ");

        // hace el conteo d las intersecciones
        var cont = snake.Count();
        if (cont > longitudCulebra)
        {
            //mueve el nodo 
            var removePoint = snake.Eliminar();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(removePoint.X + 1, removePoint.Y + 1);
            Console.Write(" ");
        }
        return true;
    }

    public Point MostrarComida()
    {
        var lugarComida = Point.Empty;
        var cabezaCulebra = snake.Last();
        var rnd = new Random();
        do
        {
            var x = rnd.Next(0, pantalla.Width - 1);
            var y = rnd.Next(0, pantalla.Height - 1);

            //Verifica que sea diferente las coordenadas 
            //la suma se realiza con valor
            //y si no cumple el if e vuelve reiniciar
            if (!snake.All(new Point(x, y))
                && Math.Abs(x - cabezaCulebra.X) + Math.Abs(y - cabezaCulebra.Y) > 8)
            {
                lugarComida = new Point(x, y);
            }

        } while (lugarComida == Point.Empty);

        Console.BackgroundColor = ConsoleColor.Blue;
        Console.SetCursorPosition(lugarComida.X + 1, lugarComida.Y + 1);
        Console.Write(" ");

        return lugarComida;
    }
}

