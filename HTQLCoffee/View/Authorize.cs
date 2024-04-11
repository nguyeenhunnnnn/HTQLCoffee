using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTQLCoffee
{
        internal class Authorize
        {
            private static Authorize instance;
            private string quyen;
            private int iMaNV;

            private Authorize() { }
            public string Role
            {

                set
                {
                    this.quyen = value;
                }
        }
            

            public int MaNV
            {
                get
                {
                    return this.iMaNV;
                }
                set
                {
                    this.iMaNV = value;
                }
            }


            public void clearSession()
            {
                instance = null;
                this.quyen = null;
                this.iMaNV = 0;
            }

            public static Authorize Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new Authorize();
                    }
                    return instance;
                }
                set { instance = value; }
            }

            //public bool isCheckRole(List<String> roles)
            //{
            //    if (roles.Contains(this.quyen))
            //    {
            //        return true;
            //    }
            //    return false;
            //}

            public void saveSession(string role, int iMaNV)
            {
                this.quyen = role;
                this.iMaNV = iMaNV;
            }
        }
    }
