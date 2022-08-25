using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_Tasks.Polymorphism
{
    public class Animal
    {
        public string Color { get; set; }
        public string Type { get; set; }
        public virtual string Voice() => "Default Ses";

    }
    public class Cat : Animal,IRunning
    {
        public void Run()
        {
            //Run
        }

        public override string Voice()
        {
            return "Cat voice";
        }
    }
    public class Dog : Animal
    {
        public override string Voice()
        {
            return "Dog voice";
        }
    }
    public class Bird : Animal
    {
        public override string Voice()
        {
            return "Bird voice";
        }
    }

    public interface IFlying { void Fly(); }
    public interface IRunning{void Run(); }

    //interface

    public interface IRepository
    {
        Task Add();
        Task Delete();
        Task Update();
        Task <IEnumerable<string>> GetAll();
    }

    public interface ICategoryRepository : IRepository {
        Task GetCategory();
    }
    public interface IProductRepository : IRepository { }
    public interface IContactRepository : IRepository { }
    public interface ICustomerRepository : IRepository { }

    



    //miras alina bilir,instance alamazsiniz
    public abstract class BaseEntity
    {
        public   int Id { get; set; }
        //virtual mecbur etmir
        public virtual string Ses() => "";
        //abstract zorunlu edir
        public abstract string Sound();

    }

    public class A : BaseEntity
    {
        public override string Sound()
        {
            throw new NotImplementedException();
        }
    }
    public class B : BaseEntity
    {
        public override string Sound()
        {
            throw new NotImplementedException();
        }
    }
    public class C : BaseEntity
    {
        public override string Sound()
        {
            throw new NotImplementedException();
        }
    }
    public class D : BaseEntity
    {
        public override string Sound()
        {
            throw new NotImplementedException();
        }



    }
}
