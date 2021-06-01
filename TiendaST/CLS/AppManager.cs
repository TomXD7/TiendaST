using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TiendaST.GUI;

namespace TiendaST.CLS
{
    class AppManager : ApplicationContext
    {
        private Boolean SplashScreen()
        {
            Boolean Resultado = true;
            Splash f = new Splash();
            f.ShowDialog();
            return Resultado;
        }

        private Boolean LoginScreen()
        {
            Boolean Resultado = true;
            Login f = new Login();
            f.ShowDialog();
            Resultado = f.Validado;
            return Resultado;
        }

        public AppManager()
        {
            if (SplashScreen())
            {
                if (LoginScreen())
                {
                    Principal f = new Principal();
                    f.ShowDialog();
                    
                }
            }
        }
    }
}
