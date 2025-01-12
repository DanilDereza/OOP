using System;
using System.Collections.Generic;

namespace Generic_Lists
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
			if(position >= 0 && position < this.size)
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


	public class LinkedList<T> : List<T>
	{
		private class Node<Y>
		{
			public Node<Y> previous;
			public Node<Y> next;
			public Y value;
		}
		private Node<T> head;
		private Node<T> tail;
		private int size;
		public LinkedList()
		{
			this.head = null;
			this.tail = null;
		}

		public void add(T element)
		{
			Node<T> node = new Node<T>();
			node.value = element;
			if (this.size == 0)
			{
				this.head = node;
				node.previous = null;
				node.next = null;
			}
			else
			{
				this.tail.next = node;
				node.previous = this.tail;
				node.next = null;
			}
			this.tail = node;
			this.size++;
		}

		public void put(T element, int position)
		{
			if (position >= 0 && position < this.size)
			{
				Node<T> node = new Node<T>();
				node.value = element;
				int index = 0;
				for (Node<T> i = this.head; i != null; i = i.next)
				{
					if (position == 0)
					{
						i.previous = node;
						node.next = i;
						node.previous = null;
						this.head = node;
						break;
					}
					else if (position == this.size - 1)
					{
						i.next = node;
						node.previous = i;
						node.next = null;
						this.tail = node;
						break;
					}
					else if (index == position)
					{
						node.previous.next = node;
						node.previous = i.previous;
						node.next = i;
						i.previous = node;
						break;
					}
					++index;
				}
				this.size++;
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
				int index = 0;
				for (Node<T> i = this.head; i != null; i = i.next)
				{
					if (position == 0 && position == this.size - 1)
					{
						this.tail = null;
						this.head = null;
						break;
					}
					else if (position == 0)
					{
						i.next.previous = null;
						this.head = i.next;
						break;
					}
					else if (position == this.size - 1)
					{
						i.previous.next = null;
						this.tail = i.previous;
						break;
					}
					else if (index == position)
					{
						i.previous.next = i.next;
						i.next.previous = i.previous;
						break;
					}
					++index;
				}
				this.size++;
			}
			else
			{
				Console.WriteLine("The position doesn't fit the size");
			}
		}

		public int find(T element)
		{
			int index = 0;
			for (Node<T> i = this.head; i != null; i = i.next)
			{
				if (i.value.Equals(element))
				{
					return index;
				}
				++index;
			}
			return -1;
		}

		public T get(int index)
		{
			int j = 0;
			for(Node<T> i = this.head; i != null; i = i.next)
			{
				if(j == index)
				{
					return i.value;
				}
				++j;
			}
			return this.tail.value;
		}

		public void print()
		{
			for(Node<T> i = this.head; i != null; i = i.next)
			{
				Console.WriteLine(i.value + " ");
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
			arr.add(9);
			arr.add(8);
			arr.add(7);
			arr.print();
			arr.put(11, 2);
			arr.print();
			arr.remove(1);
			arr.print();
			arr.remove(10);
			Console.WriteLine(arr.get(3));
			Console.WriteLine(arr.find(10));
			LinkedList<int> li_arr = new LinkedList<int>();
			li_arr.add(2);
			li_arr.add(0);
			li_arr.add(2);
			li_arr.add(2);
			li_arr.print();
			li_arr.remove(0);
			li_arr.print();
			li_arr.put(100, 10);
			Console.WriteLine(li_arr.get(1));
			Console.WriteLine(li_arr.find(2));
		}
	}
}
