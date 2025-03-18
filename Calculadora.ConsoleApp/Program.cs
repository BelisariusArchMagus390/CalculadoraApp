using static System.Net.Mime.MediaTypeNames;

namespace Calculadora.ConsoleApp
{
    internal class Program
    {
        // variáveis globais
        static string[,] operacoes = new string[50,6];
        static int cont = 0;

        static float soma(float primeiroNumero, float segundoNumero)
        {
            return primeiroNumero + segundoNumero;
        }

        static float subtracao(float primeiroNumero, float segundoNumero)
        {
            return primeiroNumero - segundoNumero;
        }

        static float multiplicacao(float primeiroNumero, float segundoNumero)
        {
            return primeiroNumero * segundoNumero;
        }

        static float divisao(float primeiroNumero, float segundoNumero)
        {
            return primeiroNumero / segundoNumero;
        }
        // entrada de dados
        static float[] numeros()
        {
            Console.WriteLine("\n---------------------------------------------");
            Console.Write("\nDigite o primeiro número: ");
            float primeiroNumero = entradaNumeroFloat();

            Console.Write("\nDigite o segundo número: ");
            float segundoNumero = entradaNumeroFloat();
            Console.WriteLine("---------------------------------------------");
            

            float[] num = [primeiroNumero, segundoNumero];

            return num;
        }
        // verifica se é um float
        static float entradaNumeroFloat()
        {
            string strNumero = Console.ReadLine();
            float numeroFloat;

            bool permissao = false;

            Console.WriteLine();
            // verifica se é um número float
            while (permissao == false)
            {
                if (float.TryParse(strNumero, out numeroFloat))
                {
                    break;
                }
                else
                {
                    Console.Write("Entrada inváliada! Favor digite um número: ");
                    strNumero = Console.ReadLine();
                }
            }

            numeroFloat = Convert.ToSingle(strNumero);

            return numeroFloat;
        }
        // verifica se é um int
        static int entradaNumeroInt()
        {
            string strNumero = Console.ReadLine();
            int numeroInt;

            bool permissao = false;

            Console.WriteLine();
            // verifica se é um número inteiro
            while (permissao == false)
            {
                if (int.TryParse(strNumero, out numeroInt))
                {
                    break;
                }
                else
                {
                    Console.Write("Entrada inváliada! Favor digite um número: ");
                    strNumero = Console.ReadLine();
                }
            }

            numeroInt = Convert.ToInt32(strNumero);

            return numeroInt;
        }
        // cria a tabuada
        static void tabuada(float numeroTabuada, int limiteTabuada)
        {
            for (int contador = 1; contador <= limiteTabuada; contador++)
            {
                float resultadoTabuada = numeroTabuada * contador;
                Console.WriteLine($"{numeroTabuada} x {contador} = {resultadoTabuada}");
            }
        }
        // entrada de dados da tabuada
        static void mostrarTabuada()
        {
            Console.WriteLine("\n---------------------------------------------");
            Console.WriteLine("Tabuada");
            Console.WriteLine("---------------------------------------------");

            Console.Write("\nDigite o número que deseja ver a sua tabuda: ");
            float numeroTabuada = entradaNumeroFloat();
            Console.Write("\nDigite o número que definirá o limite da tabuada (apenas números inteiros): ");
            int limiteTabuada = entradaNumeroInt();

            Console.WriteLine();

            string numeroTabuadaStr = Convert.ToString(numeroTabuada);
            string limiteTabuadaStr = Convert.ToString(limiteTabuada);

            operacoes[cont, 0] = numeroTabuadaStr;
            operacoes[cont, 1] = "tabuada";
            operacoes[cont, 2] = limiteTabuadaStr;
            operacoes[cont, 3] = "0";
            operacoes[cont, 4] = "true";

            tabuada(numeroTabuada, limiteTabuada);
        }

        static void historicoOperacoes()
        {
            Console.WriteLine("\n---------------------------------------------");
            Console.WriteLine("Histório de operações");
            Console.WriteLine("---------------------------------------------\n");

            int tabuadaContador = 1;
            int operacaoContador = 1;

            for (int contador = 0; contador <= 49; contador++)
            {
                if (operacoes[contador, 0] != null)
                {
                    if (operacoes[contador, 4] == "true")
                    {
                        float numeroTabuada = Convert.ToSingle(operacoes[contador, 0]);
                        int limiteTabuada = Convert.ToInt32(operacoes[contador, 2]);

                        Console.WriteLine($"Tabuada {tabuadaContador}: ");

                        tabuada(numeroTabuada, limiteTabuada);

                        Console.WriteLine();

                        tabuadaContador += 1;
                    }
                    else if (operacoes[contador, 4] == "false")
                    {
                        Console.WriteLine($"Operação {operacaoContador}: {operacoes[contador, 0]} {operacoes[contador, 1]} {operacoes[contador, 2]} = {operacoes[contador, 3]}");
                        operacaoContador += 1;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            bool deveExecutar = true;
            

            while (true)
            {
                // declaração de variáveis
                float primeiroNumero = 0;
                float segundoNumero = 0;
                float resultado = 0;
                float[] num = new float[2];

                Console.Clear();
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Calculadora Tabajara 2025");
                Console.WriteLine("---------------------------------------------");

                // Menu
                Console.WriteLine("\n1 - Soma");
                Console.WriteLine("2 - Subtração");
                Console.WriteLine("3 - Multiplicação");
                Console.WriteLine("4 - Divisão");
                Console.WriteLine("5 - Tabuada");
                Console.WriteLine("6 - Histórico de operações");
                Console.WriteLine("7 - Sair");
                Console.WriteLine("\n---------------------------------------------");
                Console.Write("\nDigite uma Opção: ");
                string opcao = Console.ReadLine();

                if ((opcao == "1") ^ (opcao == "2") ^ (opcao == "3") ^ (opcao == "4") ^ (opcao == "7"))
                {
                    num = numeros();
                    primeiroNumero = num[0];
                    segundoNumero = num[1];

                    string primeiroNumeroStr = Convert.ToString(primeiroNumero);
                    string segundoNumeroStr = Convert.ToString(segundoNumero);

                    operacoes[cont, 0] = primeiroNumeroStr;
                    operacoes[cont, 2] = segundoNumeroStr;

                    switch (opcao)
                    {
                        case "1":
                            // soma
                            operacoes[cont, 1] = "+";
                            resultado = soma(primeiroNumero, segundoNumero);
                            break;
                        case "2":
                            // subtração
                            operacoes[cont, 1] = "-";
                            resultado = subtracao(primeiroNumero, segundoNumero);
                            break;
                        case "3":
                            // multiplicação
                            operacoes[cont, 1] = "x";
                            resultado = multiplicacao(primeiroNumero, segundoNumero);
                            break;
                        case "4":
                            // divisão
                            operacoes[cont, 1] = "/";
                            if ((primeiroNumero == 0.0) ^ (segundoNumero == 0.0))
                            {
                                Console.WriteLine("Não pode ser feita uma divisão por 0.");
                            }
                            else
                            {
                                resultado = divisao(primeiroNumero, segundoNumero);
                            }
                            break;
                        case "7":
                            // sair
                            break;
                        default:
                            Console.WriteLine("\n---------------------------------------------");
                            Console.WriteLine("\nEssa opção não existe, favor digitar novamente.");
                            break;
                    }
                }
                else if(opcao == "5"){
                    // tabuada
                    mostrarTabuada();
                }
                else if(opcao == "6")
                {
                    // histórico de operações
                    historicoOperacoes();
                }
                else
                {
                    Console.WriteLine("\n---------------------------------------------");
                    Console.WriteLine("\nEssa opção não existe, favor digitar novamente.");
                }

                if ((opcao == "1") ^ (opcao == "2") ^ (opcao == "3") ^ (opcao == "4"))
                {
                    resultado.ToString("#.##");

                    string resultadoStr = Convert.ToString(resultado);

                    operacoes[cont, 3] = resultadoStr;
                    operacoes[cont, 4] = "false";

                    Console.WriteLine($"\nResultado: {resultado}");
                }

                cont += 1;

                Console.WriteLine("\nAperte Enter para continuar...");

                Console.ReadLine();
            }
        }
    }
}
