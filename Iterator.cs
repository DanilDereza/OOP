using System;
using System.Collections.Generic;

namespace Iterator
{
	public interface List<T>
	{
		public void add(T element);
		public void put(T element, int position);
		public void remove(int position);
		public int find(T element);
		public T get(int index);
		public void print();
	}
	public interface Iterator<T>
	{
		bool MoveNext();
	}
	public class ArrayIterator<T> : Iterator<T>
	{
		ArrayList<T> array;
		int position = -1;
		public ArrayIterator(ArrayList<T> array)
		{
			this.array = array;
		}
		public bool MoveNext()
		{
			position++;
			return position < array.Size();
		}
		public T Current => array.get(position);
	}
	public class ArrayList<T> : List<T>
	{
		private T[] arr;
		private int DEFAULT_ARRAYLIST_SIZE = 10;
		private int size;
		private int max_len;
		public ArrayList()
		{
			this.size = 0;
			this.arr = new T[DEFAULT_ARRAYLIST_SIZE];
			this.max_len = DEFAULT_ARRAYLIST_SIZE;
		}
		public ArrayList(int n)
		{
			this.size = 0;
			arr = new T[n];
			this.max_len = n;
		}
		public int Size()
		{
			return this.size;
		}
		public ArrayIterator<T> GetEnumerator()
		{
			return new ArrayIterator<T>(this);
		}
		public void add(T element)
		{
			if (this.size < this.max_len)
			{
				this.arr[this.size] = element;
				this.size++;
			}
			else
			{
				this.max_len = 2 * this.max_len;
				T[] tmp = new T[this.max_len];
				for (int i = 0; i < this.size; ++i)
				{
					tmp[i] = this.arr[i];
				}
				tmp[this.size] = element;
				this.size++;
				this.arr = tmp;
			}
		}
		public void put(T element, int position)
		{
			if (position >= 0 && position < this.max_len)
			{
				this.arr[position] = element;
			}
			else
			{
				Console.WriteLine("The position doesn't fit the size");
			}
		}
		public void remove(int position)
		{
			if (position >= 0 && position < this.size)
			{
				T[] tmp = new T[this.max_len];
				for (int i = 0; i < this.size; ++i)
				{
					if (i < position)
					{
						tmp[i] = arr[i];
					}
					else if (i == position)
					{
						continue;
					}
					else
					{
						tmp[--i] = arr[i];
					}
					this.arr = tmp;
					this.size--;
				}
			}
			else
			{
				Console.WriteLine("The position doesn't fit the size");
			}
		}
		public int find(T element)
		{
			for (int i = 0; i < this.size; ++i)
			{
				if (this.arr[i].Equals(element))
				{
					return i;
				}
			}
			return -1;
		}
		public T get(int index)
		{
			return this.arr[index];
		}
		public void print()
		{
			for (int i = 0; i < this.size; ++i)
			{
				Console.WriteLine(this.arr[i] + " ");
			}
			Console.WriteLine();
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			ArrayList<int> arr = new ArrayList<int>();
			arr.add(1);
			arr.add(2);
			arr.add(3);
			arr.add(4);
			arr.add(5);
			arr.add(6);
			arr.add(7);
			arr.add(8);
			arr.add(9);
			arr.add(10);
			foreach(int el in arr)
			{
				Console.WriteLine(el);
			}
		}
	}
}
