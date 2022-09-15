using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


// Conversor de Floar para Binario IEEE-754
class Conversor
{
    //Recebendo Valor 
    static void Main(string[] args)
    {
        Console.Write("Digite um Valor com Ponto Flutuante: ");
        float valor = float.Parse(Console.ReadLine());

        Console.Write("Valor digitado em Binario: ");
        sinal(valor);
        expoente(valor);
        mantissa(valor);
        
    }
    public const int constante = 127;
   

    //Cálculo do expoente
    public static void expoente(float valor)
    {
        if(valor < 0)
            valor -= valor;
        int inteiro = Convert.ToInt32(Math.Truncate(Math.Log(valor, 2)));
        Console.Write(" {0} ", Convert.ToString(inteiro + constante, 2));
    }

    //Método de cálculo da mantissa
    public static void mantissa(float valor)
    {
        int parteInteira = (int)valor;
        Single pontoFlutuante = valor - parteInteira;
        ArrayList value = new ArrayList();

        int padrao = 1;
        int mascara = 1;
        int parteInteira_copia = parteInteira;
        while ((parteInteira_copia >>= 1) > 1)
        {
            padrao++;
            mascara <<= 1;
        }
        for (int i = 0; i < padrao; i++)
        {
            value.Add(((parteInteira & mascara) == mascara) ? 1 : 0);
            parteInteira <<= 1;
            Console.Write("{0}", value[i]);
        }

        int valorInteiro;

        for (int i = padrao; i < 23; i++)
        {
            Single resultado = pontoFlutuante * 2;
            valorInteiro = (int)resultado;
            value.Add(valorInteiro);
            pontoFlutuante = resultado - valorInteiro;
            Console.Write("{0}", value[i]);
        }
        Console.WriteLine();
    }

    //Sinal
    public static void sinal(float valor)
    {
        if (valor > 0)
            Console.Write("0");
        else
            Console.Write("1");
    }

    //Chamando a Conversão
    public void conversao(float valor)
    {
        sinal(valor);
        expoente(valor);
        mantissa(valor);
    }
}