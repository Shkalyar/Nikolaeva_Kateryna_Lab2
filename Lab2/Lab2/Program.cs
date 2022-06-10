using System;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Planet[] planets =
            {
                new Planet("Меркурій"),
                new Planet("Венера"),
                new Planet("Земля", "Луна"),
                new Planet("Марс"),
                new Planet("Юпітер"),
                new Planet("Сатурн", "Іо"),
                new Planet("Уран"),
                new Planet("Нептун"),
            };
            Star star = new Star("Сонце");

            StarSystem starSystem = new StarSystem(planets, star);
            starSystem.planets_in_system();
            starSystem.star_name();
            starSystem.add_planet(new Planet("Плутон"));
            starSystem.planets_in_system();

            Console.ReadLine();
        }
    }

    class Planet
    {
        public string Name { get; private set; }
        public Satellite satellite { get; private set; }

        private static int planetsCount;

        public Planet(string name, string satellite="нема супутникiв")
        {
            Name = name;
            this.satellite = new Satellite(satellite);

            planetsCount++;
        }
        public static int planets_amount()
        {
            return planetsCount;
        }
    }

    class Star
    {  
        public string Name { get; private set; }
        public Star(string name)
        {
            Name = name;
        }
    }

    class Satellite
    {
        public string Name { get; private set; }
        public Satellite(string name)
        {
            Name = name;
        }
    }

    class StarSystem
    {
        private Planet[] planets;
        public Star star { get; private set; }

        public StarSystem(Planet[] planets, Star star)
        {
            this.planets = planets;
            this.star=star;
        }

        public void planets_in_system()
        {
            Console.WriteLine("Кiлькiсть планет у зорянiй системi: "+planets.Length);
        }
        public void star_name()
        {
            Console.WriteLine("Назва зiрки: " + star.Name);
        }

        public void add_planet(Planet planet)
        {
            Array.Resize(ref planets, planets.Length+1);
            planets[planets.Length - 1] = planet;

            Console.WriteLine("Планета " + planet.Name + " була додана до зоряної системи");
        }
    }

}
