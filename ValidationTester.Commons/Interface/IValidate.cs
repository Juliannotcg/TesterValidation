using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationTester.Commons.Interface
{
    interface IValidate
    {
        List<string> Notificacoes { get; }
        void Validar();
    }
}
