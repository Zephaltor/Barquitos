using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class ElementPool<T>
    {
        private Queue<T> _elements;
        private Func<T> _elementGenerator;

        public ElementPool(Func<T> elementGenerator)
        {
            _elements = new Queue<T>();
            _elementGenerator = elementGenerator;
        }

        public T GetEelement()
        {
            T item;

            if (_elements.Count > 0)
            {
                item = _elements.Dequeue();
            }
            else
            {
                item = _elementGenerator();
            }

            return item;
        }

        public void Update()
        {
            Engine.Debug(_elements.Count);
        }

        public void ReleaseObject(T item)
        {
            _elements.Enqueue(item);
        }
    }
}
