using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalCulebrita.Estructura
{
    public class ColaLineal<Point>
    {
        protected int fin;
        private static int MAXTM = 200;
        protected int frente;
        protected Object[] listaCola;

        public ColaLineal()
        {
            this.frente = 0;
            this.fin = 0;
            this.listaCola = new Object[MAXTM];
        }
        //Hace la insercion de los datos ahora con el if lo que hace es verificar
        //Este array cuando esta lleno vuelve a final el tamaño
        //Localiza la posición y vuelve asignar uno nuevo
        public void Insert(Point element)
        {
            if (!(fin == MAXTM))
            {
                this.listaCola[fin] = element;
                fin++;
            }
            if (fin == MAXTM) fin = 0;
        }

        //Este metodo retorna el punto que se ha elminado
        //Los saca nulos los datps cuando se incrementa
        //Cuando esta al frente se vuelve a iniciar a 0 de nuevo para seguir dando los datos
        public Point Quitar()
        {
            if (fin != frente)
            {
                var eliminado = listaCola[frente];
                listaCola[frente] = null;
                frente++;
                if (frente == MAXTM) frente = 0;
                return (Point)eliminado;
            }

            return default(Point);
        }

        //Retorna el ultimo elemento
        public Point Last()
        {
            //el ultimo elemnto los datos se insertan al final
            return (Point)listaCola[frente];
        }

        //Este metodo recibe los datos tipo point y va coomparandp si hay iguales
        //Luego si el array obtiene los datos los retorna en true
        public bool Any(Point p)
        {
            var encontrado = !(frente == fin);
            if (encontrado) return true;
            foreach (Object o in listaCola)
            {
                if (o != null)
                {
                    encontrado = (o.Equals(p)) ? true : false;
                }
            }
            return encontrado;
        }

        // toma en cuenta los datos quw ingresan en el arrays
        public int Count()
        {
            int count = 0;
            foreach (Object o in listaCola)
            {
                if (o != null) count++;
            }
            return count;
        }

        //retorna si el arrays esta vacio
    //y si hay coincidencia retorna el true
        public bool All(Point p)
        {
            var encontrado = (frente == fin);
            if (encontrado) return true;

            foreach (Object o in listaCola)
            {
                if (o != null)
                {
                    encontrado = (o.Equals(p)) ? true : false;
                }
            }
            return encontrado;
        }
    }
}
