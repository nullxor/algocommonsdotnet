using System;

namespace AlgoCommonsDotNet.DataStructures.Generic.Lists
{
    /// <summary>
    /// In computer science, a dynamic array, growable array, resizable array, dynamic table,
    /// mutable array, or array list is a random access, variable-size list data structure that
    /// allows elements to be added or removed. It is supplied with standard libraries in many
    /// modern mainstream programming languages. From Wikipedia.
    /// </summary>
    public class DynamicArray<T>
    {
        //GrowFactor we'll resize the array by this factor every time the buffer is full
        protected const int GrowFactor = 2;

        //Initial size of the buffer
        protected const int DefaultSize = 20;
        protected T[] _buffer;

        //Real length of the array 
        //It's O(1) because we'll update the Length when adding or removing items
        protected int _length;
        public int Length { get { return _length; } }

        /// <summary>
        /// Default constructor
        /// </summary>
        public DynamicArray()
        {
            Init();
        }

        /// <summary>
        /// Build the dynamic array based on the given array
        /// </summary>
        public DynamicArray(T[] array)
        {
            Init();

            for (int i = 0; i < array.Length; i++)
            {
                Add(array[i]);
            }
        }

        /// <summary>
        /// Add a new item to the array
        /// </summary>
        /// <param name="item">Item to add</param>
        public void Add(T item)
        {
            //Prevent overflow
            EnsureCapacity();

            //Add the new item to the buffer and increment the Length
            //The operation is amortized O(1) because most of the time it's O(1)
            //It is only O(n) when the buffer is full
            _buffer[_length++] = item;
        }

        /// <summary>
        /// Returns the item based on the given index
        /// </summary>
        /// <param name="index">Index</param>
        /// <returns>Item</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public T this[int index]
        {
            get
            {
                CheckIndex(index);

                return _buffer[index];
            }
            set
            {
                _buffer[index] = value;
            }
        }

        /// <summary>
        /// Removes the item based on the given index
        /// </summary>
        /// <param name="index">Index</param>
        /// <returns>Removed item</returns>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public T RemoveAt(int index)
        {
            CheckIndex(index);

            T result = _buffer[index];
            _length--;

            //We don't really remove the item from memory, we just erase it from the
            //buffer and starting from the index we've just "removed" we move the items
            //one position to the left in the buffer.
            //For instance, if we have the buffer [0,1,2,3,4,5,0,0,0...] in this case
            //if whe remove 3 (index 3) then the new buffer would be [0,1,2,4,5,0,0,0...]
            for (int i = index; i < _length; i++)
            {
                _buffer[i] = _buffer[i + 1];
            }
            
            return result;
        }

        /// <summary>
        /// Initialize the buffer and the inner length
        /// </summary>
        protected void Init()
        {
            _buffer = new T[DefaultSize];
            _length = 0;
        }

        /// <summary>
        /// Check if the index is legal
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        protected void CheckIndex(int index)
        {
            if (index >= _length)
            {
                throw new IndexOutOfRangeException();
            }
        }

        /// <summary>
        /// Ensure that the buffer has enough capacity to save new data
        /// </summary>
        protected void EnsureCapacity()
        {
            //If the Length is above the buffer length, expand the buffer by the GrowFactor
            //and copy all of the data to the new buffer, this operation is O(n)
            if (_length >= _buffer.Length)
            {
                T[] newBuffer = new T[_length * GrowFactor];

                for (int i = 0; i < _buffer.Length; i++)
                {
                    newBuffer[i] = _buffer[i];
                }

                //I don't know how the .NET GC works but it should release this memory 
                //in the next swap because we've lost the reference
                _buffer = newBuffer;
            }
        }
    }
}
