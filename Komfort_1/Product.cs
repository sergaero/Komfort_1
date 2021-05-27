using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komfort_1
{
    class Product
    {
        //ПОЛЯ
        ulong productID = 0;
        ulong typeID = 0;
        ulong firmID = 0;
        ulong trmarkID = 0;
        string productDateMade = string.Empty;
        double productCost = 0;
        int productNumber = 0;


        //СВОЙСТВА

        //КОНСТРУКТОРЫ
        public Product()
        {
            //
        }

        //МЕТОДЫ

            //добавить продукт
        public void addProduct()
        {

        }

        //удалить
        public string deleteProduct()
        {
            string str = string.Empty;
            return str;
        }

        public string ShowListOfProduct()
        {
            string str = string.Empty;
            return str;
        }

        public string SearchProduct()
        {
            string str = string.Empty;
            return str;
        }

    }
}
