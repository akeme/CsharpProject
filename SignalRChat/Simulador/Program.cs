using System;

namespace Simulador
{
    class Program
    {
        public int id { get; set; }
        public int reading { get; set; }
        public bool statusR { get; set; }
        public static bool Status { get; private set; }

        public static void Main()
        {
            int opcao;

            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine("\nTestando...\n");
            Console.WriteLine("digite 1 ou 2");

            opcao = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("voce escolheu {0}", opcao);
            if (opcao == 1)
            {
                Status = false;


            }
            else
            {
                Status = true;
            }
            Leitura(Status);



        }


        public static int Leitura(bool Status)
        {
            //SetTimer();

            DateTime date1 = new DateTime(2020, 04, 22, 0, 0, 0);
            DateTime date2 = DateTime.Now;

            System.TimeSpan diff10 = date2.Subtract(date1);



            int leitura = 0;
            leitura += Convert.ToInt32(diff10.TotalSeconds);
            Console.WriteLine("a diferença é {0}", diff10.TotalSeconds);


            if (!Status)
            {
                date1 = DateTime.Now;
                Console.WriteLine("a leitura atual é {0}", leitura);
                Console.WriteLine("o inicio é {0}", date1);

                return leitura;



            }

            else
            {
                Console.WriteLine("a leitura é {0}", leitura);
                Console.WriteLine("o inicio é {0}", date1);


                return leitura;
            }


        }

    }
}
