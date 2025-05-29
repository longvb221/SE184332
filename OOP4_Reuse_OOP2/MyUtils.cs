using OOP2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP4_Reuse_OOP2
{
    public static class MyUtils
    {
        public static int Tuoi(this Employee emp)
        {
            return DateTime.Now.Year - emp.Birthday.Year;
        }

  //viet mot method tra ve thang nay co phai thang sinh nhat ho hay khong
        public static Boolean KiemTraSinhNhat(this Employee emp)
        {
            if (emp.Birthday.Year == DateTime.Now.Year)
            {
                return true;
            }
            else
            {

                return false;
            }


            }



        }
    } 





