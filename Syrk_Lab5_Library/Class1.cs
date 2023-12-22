using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Syrk_Lab5_Library
{
    public class CarPart
    {

    }

    public class Engine:CarPart
    {
        public bool power;
        public string name;
        public int maxSpeed;

        public Engine(string code, int maxSpeed)
        {
            this.name = code;
            this.maxSpeed = maxSpeed;
        }
    }

    public class FuelTank : CarPart
    {
        public string fuelType;
        public int capacity;
        public double curentFuel;

        public FuelTank(string fuelType, int capacity)
        {
            this.fuelType = fuelType;
            this.capacity = capacity;
            curentFuel = capacity;
        }
    }

    public class Wheels : CarPart
    {
        public string wheelType;

        public Wheels(string wheelType)
        {
            this.wheelType = wheelType;
        }
    }

    public class Interior : CarPart
    {
        public string chairType;

        public Interior(string chairType)
        {
            this.chairType = chairType;
        }
    }

    public interface IAutomobileControllable
    {
        void ShowStats();
        void InstalPart(CarPart part);
        void StartEngine();
        void ShutEngine();
        void Refuel();
        void Drive();

        //☖

    }

    public class Car:IAutomobileControllable
    {
        public int year;
        public string name;
        public double mileage=0;
        public double usageTime = 0;

        public double maxSpeed;
        public double maxFuel;

        bool engineWorking = false;
        public double curentFuel;

        Engine engine;
        FuelTank fuelTank;
        Wheels wheels;
        Interior interior;

        public Car(string name, int year)
        {
            this.name=name;
            this.year = year;
        }

        public void ShowStats()
        {
            Console.WriteLine($"\nИнформация об автомобиле:\n" +
                $"Название: {name}\n" +
                $"Год выпуска: {year}\n" +
                $"Пробег: {mileage} км.\n" +
                $"Время эксплуатации: {usageTime} ч.");
            Console.Write("Двигатель: ");
            if (engine != null) 
            {
                Console.WriteLine($"{engine.name}\n" +
                $"Макс. скорость: {engine.maxSpeed} км/ч");
            }
            else
            {
                Console.WriteLine("Отсутствует\n" +
                    "Макс. скорость: 0 км/ч");
            }

            if (fuelTank != null)
            {
                Console.WriteLine($"Тип топлива: {fuelTank.fuelType}\n" +
                    $"Вместительность бензобака: {fuelTank.capacity}\n" +
                    $"Топлива в баке: {fuelTank.curentFuel}");
            }
            else
            {
                Console.WriteLine("Бензобак отсутствует");
            }

            if (wheels != null)
            {
                Console.WriteLine($"Тип резины: {wheels.wheelType}");
            }
            else
            {
                Console.WriteLine("Покрышки отсутствуют");
            }

            if (interior != null)
            {
                Console.WriteLine($"Чехлы в салоне: {interior.chairType}");
            }
            else
            {
                Console.WriteLine("Чехлы отсутсвуют");
            }
        }

        public void InstalPart(CarPart part)
        {
            if (part is Engine)
            {
                this.engine = (Engine)part;
                Console.WriteLine($"Установлен двигатель {engine.name}");
            }
            else if (part is FuelTank)
            {
                this.fuelTank = (FuelTank)part;
                Console.WriteLine($"Установлен бензобак с типом топлива {fuelTank.fuelType}");
            }
            else if (part is Wheels)
            {
                this.wheels = (Wheels)part;
                Console.WriteLine($"Установлены покрышки {wheels.wheelType}");
            }
            else if (part is Interior)
            {
                this.interior = (Interior)part;
                Console.WriteLine($"Установлены покрышки {interior.chairType}");
            }
        }
       
        public void StartEngine()
        {
            if (engine!=null)
            {
                engine.power = true;
                Console.WriteLine("Двигатель запущен");
            }
            else
                Console.WriteLine("Двигатель отсутствует");
        }

        public void ShutEngine()
        {
            if (engine != null)
            {
                engine.power = false;
                Console.WriteLine("Двигатель заглушен");
            }
            else
                Console.WriteLine("Двигатель отсутствует");
        }

        public void Refuel()
        {
            if (fuelTank!=null)
            {
                fuelTank.curentFuel = fuelTank.capacity;
                Console.WriteLine("Автомобиль заправлен");
            }
            else
            {
                Console.WriteLine("Бензобак отсутствует");
            }
        }

        public void Drive()
        {
            if (engine != null &&
                fuelTank != null &&
                wheels != null&&
                engine.power)
            {
                System.Random random = new System.Random();

                int distance = random.Next(20, fuelTank.capacity*2);
                double time = distance / engine.maxSpeed;
                double newCurentFuel=fuelTank.curentFuel-distance/2;

                if (newCurentFuel >= 0)
                {
                    Console.Clear();
                    Console.Write("☖...☖\n" +
                        "A   B");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.Write("☖v..☖\n" +
                        "A   B");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.Write("☖.v.☖\n" +
                        "A   B");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.Write("☖..v☖\n" +
                        "A   B");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.Write("☖...☖\n" +
                        "A   B\n");
                    Thread.Sleep(1000);


                    Console.Write($"Пройдено {distance} км. за {time} ч.");
                    

                    mileage += distance;
                    usageTime += time;
                    fuelTank.curentFuel = newCurentFuel;
                }
                else
                {
                    Console.WriteLine($"В баке недостаточно топлива, чтобы проехать {distance} км.");
                }
            }
            else
            {
                Console.WriteLine("\n Невозможно ехать: ");
                if (engine == null)
                    Console.WriteLine("Отсутствует двигатель");
                if (fuelTank == null)
                    Console.WriteLine("Отсутствует топливный бак");
                if (wheels == null)
                    Console.WriteLine("Отсутствуют покрышки");
                if (!engine.power)
                    Console.WriteLine("Двигатель заглушен");
            }
        }
    } 
}
