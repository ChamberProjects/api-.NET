namespace ApiBurggers.Services;
using ApiBurggers.Models;

public static class BurgerService
{   
    static List<Burger> Burgers { get; }
    static int nextId = 3;
    static BurgerService()
    { 
        Burgers = new List<Burger>
        {
            new Burger { Id = 1, Name = "Pineapple", IsGlutenFree = false },
            new Burger { Id = 2, Name = "Veggie", IsGlutenFree = true },
            new Burger { Id = 3,  Name = "apple", IsGlutenFree = false}
        };

    }

    public static List<Burger> GetAll() => Burgers;
    public static Burger? Get(int id) => Burgers.FirstOrDefault(p => p.Id == id);

    public static void Add(Burger burger)
    {
        burger.Id = nextId++;
        Burgers.Add(burger);
    }

    public static void Delete(int id)
    {
        var burger = Get(id);
        if (burger is null)
            return;

        Burgers.Remove(burger);
    }

    public static void Update(Burger burger)
    {
        var index = Burgers.FindIndex(p => p.Id == burger.Id);
        if (index == -1)
            return;

        Burgers[index] = burger;
    }
}

