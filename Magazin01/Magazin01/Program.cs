using AutoMagazin.Products;
using System;
// информация о пользователе 
namespace AutoMagazin
{
    class User
    {
        public string Name { get; private set; }
        public string Adress { get; private set; }
        public double Balance { get; private set; }
        public double Spent { get; private set; }

        public User(string name, string adress, int balance, int spent)
        {
            Name = name;
            Adress = adress;
            Balance = balance;
            Spent = spent;
        }
// управление бюджетом 
        public void ReduceBalance(double price)
        {
            Balance -= price;
            Spent += price;
        }
    }
}
namespace AutoMagazin
{
    class Product
    {
        public double Price { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
// система скидок
        public virtual double GetDiscountPrice(User user)
        {
            if (user.Spent < 3000)
            {
                return Price;
            }

            if (user.Spent < 10000)
            {
                return Price * 0.9;
            }

            return Price * 0.8;
        }
    }
}
// информация о совершении покупки
namespace AutoMagazin
{
    class Informer
    {
        public void Buy(User user, Product product)
        {
            double price = product.GetDiscountPrice(user);
            user.ReduceBalance(price);
            Console.WriteLine($"{user.Name} , вы приобрели {product.Name} за {price}. *кидают ключи от машины*");
        }
    }
}
// о покупателе
namespace AutoMagazin
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User(
                "Тимофей",
                "просп. Соколова, 62/186",
                200000,
                550
                );

            Console.WriteLine("Список машин:");

// машина  
            Lexus aLexus = new Lexus(
                "Lexus lx570",
                85000,
                "Япония"
                );
// информация о машине
            Console.WriteLine("Lexus:");

            Console.WriteLine("Модель: " + aLexus.Name);

            Console.WriteLine("Производитель: " + aLexus.Manufacturer);

            Console.WriteLine("Цена: " + aLexus.Price);

            Console.WriteLine(new String('-', 25));


            Lada aLada = new Lada(
                "Lada granta sport",
                90000,
                "Россия"
                );

            Console.WriteLine("Lada:");

            Console.WriteLine("Модель: " + aLada.Name);

            Console.WriteLine("Производитель: " + aLada.Manufacturer);

            Console.WriteLine("Цена: " + aLada.Price);

            Console.WriteLine(new String('-', 25));
            

            Dodge aDodge = new Dodge(
                "Dodge srt charger hellcat",
                97000,
                "США"
                );

            Console.WriteLine("Dodge:");

            Console.WriteLine("Модель: " + aDodge.Name);

            Console.WriteLine("Производитель: " + aDodge.Manufacturer);

            Console.WriteLine("Цена: " + aDodge.Price);

            Console.WriteLine(new String('-', 25));


            Audi aAudi = new Audi(
                "Audi A1",
                79000,
                "Германия"
                );

            Console.WriteLine("Audi:");

            Console.WriteLine("Модель: " + aAudi.Name);

            Console.WriteLine("Производитель: " + aAudi.Manufacturer);

            Console.WriteLine("Цена: " + aAudi.Price);

            Console.WriteLine(new String('-', 25));

            Product[] products = new Product[] {

                aLexus,
                aLada,
                aDodge,
                aAudi,
            };
// работа с покупателем
            Informer informer = new Informer();

            while (true)
            {
                Console.WriteLine();

                Console.WriteLine($"Здравствуйте {user.Name} ваш бюджет {user.Balance}");

                for (int i = 0; i < products.Length; i++)
                {
                    Console.WriteLine($"Автомобиль {i} {products[i].Name} по цене {products[i].Price}");
                }
                Console.WriteLine("Выберете номер автомобиля и нажмите Enter:");

                string str = Console.ReadLine();
                
                int productNumber = Convert.ToInt32(str);

                if (productNumber >= 0 && productNumber < products.Length)
                {

                    if (products[productNumber].Price < user.Balance)
                    {
                        informer.Buy(user, products[productNumber]);
                    }
                    else
                    {
                        Console.WriteLine("У вас недостаточно средств");
                    }

                }
                else
                {
                    Console.WriteLine("Такой машины нет");
                }
            }
        }
    }
}
//автомобили 
namespace AutoMagazin.Products
{
    class Lexus : Product
    {
        public Lexus(string name, int price, string manufacturer)
        {
            Name = name;
            Manufacturer = manufacturer;
            Price = price;
        }
    }
}

namespace AutoMagazin.Products
{
    class Lada : Product
    {
        public Lada(string name, int price, string manufacturer)
        {
            Name = name;
            Manufacturer = manufacturer;
            Price = price;
        }
    }
}

namespace AutoMagazin.Products
{
    class Dodge : Product
    {
        public Dodge(string name, int price, string manufacturer)
        {
            Name = name;
            Manufacturer = manufacturer;
            Price = price;
        }
        public override double GetDiscountPrice(User user)
        {
            return Price / 2;
        }

    }
}

namespace AutoMagazin.Products
{
    class Audi : Product
    {
        public Audi(string name, int price, string manufacturer)
        {
            Name = name;
            Manufacturer = manufacturer;
            Price = price;
        }
    }
}


