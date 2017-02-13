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

        //ShrinkFactor we'll shrink the array by this factor every time the length 
        //of the buffer is _buffer.Length/ShrinkFactor, this should be diferent from GrowFactor
        protected const int ShrinkFactor = 3;

        //Initial size of the buffer
        protected const int DefaultSize = 5;
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
        /// Inserts the item in the array at the given index
        /// </summary>
        /// <param name="index">Index</param>
        /// <param name="item">Item to insert</param>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public void InsertAt(int index, T item)
        {
            if (_length > 0)
            {
                CheckIndex(index);
            }

            _length++;
            EnsureCapacity();

            //Move the rest of the items upwards starting from the end to the index O(n)
            for (int i = _length - 1; i > index; i--)
            {
                _buffer[i] = _buffer[i-1];
            }

            _buffer[index] = item;
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
            //buffer and starting from the index we've just "removed" we move the rest of
            //the items one position to the left in the buffer.
            //For instance, if we have the buffer [0,1,2,3,4,5,0,0,0...] in this case
            //if whe remove 3 (index 3) then the new buffer would be [0,1,2,4,5,0,0,0...]
            for (int i = index; i < _length; i++)
            {
                _buffer[i] = _buffer[i + 1];
            }

            Shrink();

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
        /// <param name="force">Force</param>
        protected void EnsureCapacity(bool force = false)
        {
            //If the Length is above the buffer length, expand the buffer by the GrowFactor
            //and copy all of the data to the new buffer, this operation is O(n)
            if (_length >= _buffer.Length || force)
            {
                T[] newBuffer = new T[_length * GrowFactor];

                for (int i = 0; i < _length; i++)
                {
                    newBuffer[i] = _buffer[i];
                }

                //I don't know how the .NET GC works but it should release this memory 
                //in the next swap because we've lost the reference
                _buffer = newBuffer;
            }
        }

        /// <summary>
        /// Shrink the buffer when the virtual length be less than 
        /// _buffer.Length/ShrinkFactor to free unused memory.
        /// </summary>
        protected void Shrink()
        {
            if (_length <= (_buffer.Length / ShrinkFactor))
            {
                EnsureCapacity(true);
            }
        }
    }
}
