using System;

namespace SimuladorApp
{
    public class Simulador
    {
        public int Id { get; set; }
        public int Reading { get; set; }
        public bool StatusR { get; set; }
        public static bool Status { get; private set; }
        enum Request
        {
            Reading,
            CortaReliga,
            EquipamentId
        }


        public static int Leitura(bool status)
        {
            DateTime date1 = new DateTime(2020, 04, 22, 0, 0, 0);
            DateTime date2 = DateTime.Now;

            System.TimeSpan diff10 = date2.Subtract(date1);



            int leitura = 0;
            leitura += Convert.ToInt32(diff10.TotalSeconds);
            Console.WriteLine("a diferença é {0}", diff10.TotalSeconds);
            return leitura;

        }

        public static bool OpcaoConv(int opcao)
        {

            Console.WriteLine("voce escolheu {0}", opcao);
            if (opcao == 1)
            {
                Status = false;
                return false;


            }
            else
            {
                Status = true;
                return true;
            }

        }

        public static DateTime StatusSet(bool Status)
        {

            DateTime date1 = new DateTime(2020, 04, 22, 0, 0, 0);
            DateTime date2 = DateTime.Now;

            if (!Status)
            {
                date1 = DateTime.Now;
                //   Console.WriteLine("a leitura atual é {0}", leitura);
                // Console.WriteLine("o inicio é {0}", date1);

                // return leitura;
                return date2;



            }

            else
            {
                // Console.WriteLine("a leitura é {0}", leitura);
                // Console.WriteLine("o inicio é {0}", date1);


                //  return leitura;
                return date1;
            }


        }

    }
}
