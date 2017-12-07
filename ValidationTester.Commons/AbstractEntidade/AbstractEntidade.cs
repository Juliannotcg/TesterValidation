using System;
using System.Collections.Generic;
using System.Text;
using ValidationTester.Commons.Interface;

namespace ValidationTester.Commons.AbstractEntidade
{
    public abstract class AbstractEntidade: IValidate
    {
        public List<string> Notificacoes { get; private set; } = new List<string>();
        public abstract void Validar();
    }
}
