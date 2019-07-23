/*
 * Juego del gato
 * Fecha: 23/07/2019
 * Programado totalmente por: Pablo Alberto Espinoza Ruiz
 * Uso únicamente para fines educativos.
 */
using System;

namespace Juego
{
    class Program
    {
        static string[] jugadores = new string[2];
        static int[,] tablero = {
            {0,0,0},
            {0,0,0},
            {0,0,0}
        };
        static int turno = 0;
        static void Main(string[] args)
        {
            Console.Title = "Juego del gato";
            Console.WriteLine("Juego del gato");
            Nombres();
            // Comienza el juego
            Turnos:
            Console.WriteLine("¡¡TURNO DE {0}!!", jugadores[turno]);
            MostrarTablero();
            ElegirTurno();
            if(VerificarTurno() == false)
            {
                SiguienteTurno();
                Console.Clear();
                goto Turnos;
            } else {
                string reiniciar;
                Console.Write("¿Desea volver a jugar? (SI-NO): ");
                reiniciar = Console.ReadLine().ToUpper();
                if(reiniciar == "SI")
                {
                    ReiniciarTablero();
                    Console.Clear();
                    Console.WriteLine("JUEGO REINICIADO");
                    goto Turnos;
                }
                Console.WriteLine("GRACIAS POR JUGAR AL GATO");
            }
            Console.ReadKey();
        }
        static void Nombres()
        {
            Console.Write("Ingrese el nombre del primer jugador (X): ");
            jugadores[0] = Console.ReadLine();
            Console.Write("Ingrese el nombre del segundo jugador (O): ");
            jugadores[1] = Console.ReadLine();
            Console.Clear();
        }
        static void MostrarTablero()
        {
            Console.WriteLine(" ");
            Console.WriteLine("      ||     ||     ");
            Console.WriteLine("   " + SimboloJugador(tablero[0, 0]) + "  ||  " + SimboloJugador(tablero[0, 1]) + "  ||  " + SimboloJugador(tablero[0, 2]));
            Console.WriteLine("     1||    2||    3");
            Console.WriteLine(" =====++=====++======");
            Console.WriteLine("      ||     ||     ");
            Console.WriteLine("   " + SimboloJugador(tablero[1, 0]) + "  ||  " + SimboloJugador(tablero[1, 1]) + "  ||  " + SimboloJugador(tablero[1, 2]));
            Console.WriteLine("     4||    5||    6");
            Console.WriteLine(" =====++=====++======");
            Console.WriteLine("      ||     ||     ");
            Console.WriteLine("   " + SimboloJugador(tablero[2, 0]) + "  ||  " + SimboloJugador(tablero[2, 1]) + "  ||  " + SimboloJugador(tablero[2, 2]));
            Console.WriteLine("     7||    8||    9");
            Console.WriteLine(" ");
        }
        static void ElegirTurno()
        {
            int posicion;
            PosicionInvalida:
            Console.Write("Ingrese la posición donde deseas marcar: ");
            posicion = int.Parse(Console.ReadLine());
            switch(posicion)
            {
                case 1:
                    if (tablero[0, 0] != 0)
                    {
                        Console.WriteLine("ERROR! Esa posición ya se encuentra ocupada.");
                        goto PosicionInvalida;
                    }
                    tablero[0, 0] = turno + 1;
                    break;
                case 2:
                    if (tablero[0, 1] != 0)
                    {
                        Console.WriteLine("ERROR! Esa posición ya se encuentra ocupada.");
                        goto PosicionInvalida;
                    }
                    tablero[0, 1] = turno + 1;
                    break;
                case 3:
                    if (tablero[0, 2] != 0)
                    {
                        Console.WriteLine("ERROR! Esa posición ya se encuentra ocupada.");
                        goto PosicionInvalida;
                    }
                    tablero[0, 2] = turno + 1;
                    break;
                case 4:
                    if (tablero[1, 0] != 0)
                    {
                        Console.WriteLine("ERROR! Esa posición ya se encuentra ocupada.");
                        goto PosicionInvalida;
                    }
                    tablero[1, 0] = turno + 1;
                    break;
                case 5:
                    if (tablero[1, 1] != 0)
                    {
                        Console.WriteLine("ERROR! Esa posición ya se encuentra ocupada.");
                        goto PosicionInvalida;
                    }
                    tablero[1, 1] = turno + 1;
                    break;
                case 6:
                    if (tablero[1, 2] != 0)
                    {
                        Console.WriteLine("ERROR! Esa posición ya se encuentra ocupada.");
                        goto PosicionInvalida;
                    }
                    tablero[1, 2] = turno + 1;
                    break;
                case 7:
                    if (tablero[2, 0] != 0)
                    {
                        Console.WriteLine("ERROR! Esa posición ya se encuentra ocupada.");
                        goto PosicionInvalida;
                    }
                    tablero[2, 0] = turno + 1;
                    break;
                case 8:
                    if (tablero[2, 1] != 0)
                    {
                        Console.WriteLine("ERROR! Esa posición ya se encuentra ocupada.");
                        goto PosicionInvalida;
                    }
                    tablero[2, 1] = turno + 1;
                    break;
                case 9:
                    if (tablero[2, 2] != 0)
                    {
                        Console.WriteLine("ERROR! Esa posición ya se encuentra ocupada.");
                        goto PosicionInvalida;
                    }
                    tablero[2, 2] = turno + 1;
                    break;
                default:
                    Console.WriteLine("ERROR! Posición invalida.");
                    goto PosicionInvalida;
            }
        }
        static bool VerificarTurno()
        {
            int ganador = 0;
            VerificarVerticales();
            VerificarHorizontales();
            VerificarEsquineado();
            if (ganador != 0)
            {
                Console.Clear();
                MostrarTablero();
                Console.WriteLine("\nGANADOR: {0}", jugadores[ganador - 1]);
                return true;
            }
            if (VerificarLleno() == true)
            {
                Console.Clear();
                MostrarTablero();
                Console.WriteLine("\nDRAW, NO HUBO GANADORES");
                return true;
            }
            void VerificarVerticales()
            {
                for (int fila = 0; fila < 3; fila++)
                {
                    if (tablero[0, fila] != 0 && tablero[0, fila] == tablero[1, fila] && tablero[1, fila] == tablero[2, fila])
                    {
                        ganador = tablero[0, fila];
                    }
                }
            }
            void VerificarHorizontales()
            {
                for (int fila = 0; fila < 3; fila++)
                {
                    if (tablero[fila, 0] != 0 && tablero[fila, 0] == tablero[fila, 1] && tablero[fila, 1] == tablero[fila, 2])
                    {
                        ganador = tablero[fila, 0];
                    }
                }
            }
            void VerificarEsquineado()
            {
                if (tablero[0, 0] != 0 && tablero[0, 0] == tablero[1, 1] && tablero[1, 1] == tablero[2, 2])
                {
                    ganador = tablero[0, 0];
                }
                else if (tablero[2, 0] != 0 && tablero[2, 0] == tablero[1, 1] && tablero[1, 1] == tablero[0, 2])
                {
                    ganador = tablero[2, 0];
                }
            }
            bool VerificarLleno()
            {
                int contador = 0;
                for (int fila = 0; fila < 3; fila++)
                    for (int columna = 0; columna < 3; columna++)
                        if(tablero[fila, columna] != 0)
                            contador++;
                if (contador == 9)
                    return true;
                else
                    return false;
            }
            return false;
        }
        static void SiguienteTurno()
        {
            if (turno == 0)
                turno = 1;
            else
                turno = 0;
        }
        static void ReiniciarTablero()
        {
            for (int fila = 0; fila < 3; fila++)
                for (int columna = 0; columna < 3; columna++)
                    tablero[fila, columna] = 0;
            turno = 0;
            Console.Clear();
            Console.WriteLine("JUEGO REINICIADO");
        }
        static char SimboloJugador(int jugador)
        {
            switch(jugador)
            {
                // Vacio
                case 0:
                    return '_';
                // Jugador 1
                case 1:
                    return 'X';
                // Jugador 2
                case 2:
                    return 'O';
            }
            return '_';
        }
    }
}
