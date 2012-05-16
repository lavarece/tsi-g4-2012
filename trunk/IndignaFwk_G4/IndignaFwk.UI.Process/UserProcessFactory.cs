using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IndignaFwk.UI.Process
{
    public class UserProcessFactory
    {
        // SINGLETON
        private UserProcessFactory() { }

        private static UserProcessFactory _instance;

        public static UserProcessFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserProcessFactory();
                }

                return _instance;
            }
        }

        // USER PROCESSES
        private IGrupoUserProcess _grupoUserProcess;

        public IGrupoUserProcess GrupoUserProcess
        {
            get
            {
                if (_grupoUserProcess == null)
                {
                    _grupoUserProcess = new GrupoUserProcess();
                }

                return _grupoUserProcess;
            }
        }
    }
}
