using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CardVaiVoa.RuleDomain
{
    public class CreateCard
    {
        public string CreateCards()
        {
            Random randonNumber = new Random();
            int numberBanc = randonNumber.Next(1000, 9999);
            string numberConvert = numberBanc.ToString();
            int bandeiraNumber = 36;
            string bandeiraConvert = bandeiraNumber.ToString();
            int numberUserCard = randonNumber.Next(100000000, 999999999);
            string numberUserCardConvert = numberUserCard.ToString();
            string numberCard = bandeiraConvert + numberConvert + numberUserCardConvert;



            int totalPositionImpar = 0;
            int totalPositionPar = 0;
            for (int i = 0; i < numberCard.Length; i++)
            {
                int integer = (int)Char.GetNumericValue(numberCard[i]);
                if (i % 2 == 0)
                {
                    int dobro = 2 * integer;
                    if (dobro > 9)
                    {
                        int resto = dobro % 10;
                        totalPositionPar = totalPositionPar + resto + 1;
                    }
                    else
                    {
                        totalPositionPar = totalPositionPar + dobro;
                    }
                    
                }
                else
                {
                    totalPositionImpar = totalPositionImpar + integer;
                }


            }
            int somaImpaPar = (totalPositionPar + totalPositionImpar);
            int digitVerificador;
            int restoImpaPar;
            if (somaImpaPar < 100)
            {
                restoImpaPar = (somaImpaPar % 10);
                digitVerificador = 10 - restoImpaPar;
                if (digitVerificador == 10)
                {
                    digitVerificador = 0;
                }

            }
            else
            {
                digitVerificador = somaImpaPar;
            }



            string verifyNumberString = digitVerificador.ToString();
            return numberCard + verifyNumberString;
        }
    }
}
