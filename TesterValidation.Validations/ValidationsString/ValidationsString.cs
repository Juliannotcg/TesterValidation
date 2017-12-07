using System;
using System.Collections.Generic;
using System.Text;
using TesterValidation.Validations.Validations;

namespace TesterValidation.Validations.ValidationsString
{
    public class ValidationsString
    {
        // Registro

        public static int StringLenghMinim { get { return 3; } }
        public static int StringLenghMax { get { return 255; } }
        public string String { get; set; }


        public void ValidationString()
        {
            //ValidatorGenerals.Tamanho(String, StringLenghMinim, StringLenghMax, () => Notificacoes.Add(string.Format(Erros.TamanhoEntidadeFeminina, "Formalidades Legais", "obito", FormalidadesLegaisTamanhoMinimo, FormalidadesLegaisTamanhoMaximo)));
            //ValidatorGenerals.NaoVazio(String, () => Notificacoes.Add(string.Format(Erros.NaoInformadoEntidadeFeminina, "Formalidades legais", "obito")));

            //if (Notificacoes.Count != 0)
              //  throw new EntidadeInvalidaException(this);
        }
    }
}
