using System;
using System.Collections.Generic;

namespace WorkingWithVisualStudio.Tests
{
    public class Comparer
    {
        public static Comparer<U> Get<U> (Func<U, U, bool> func) => new Comparer<U>(func);
    }

    public class Comparer<T> : Comparer, IEqualityComparer<T>
    {
        // FÄLT av typen Func. Tar två generiska parametrar och returnerar en bool
        private readonly Func<T, T, bool> _comparisonFunction;

        // KONSTURKTOR som tilldelar fältet den func som skickas in konstruktorn
        public Comparer(Func<T, T, bool> func) => _comparisonFunction = func;
        
        // Generisk Metod som anropar vårt fält  med två generiska inparametrar
        public bool Equals(T x, T y) => _comparisonFunction(x, y);

        // Generisk metod
        public int GetHashCode(T obj) => obj.GetHashCode();
    }
}


