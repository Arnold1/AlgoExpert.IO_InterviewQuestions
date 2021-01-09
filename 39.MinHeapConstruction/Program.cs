using System;
using System.Collections.Generic;

namespace _39.MinHeapConstruction
{
    class Program
    {
        static void Main(string[] args)
        {
			List<int> array = new List<int> { 66, 23, 88, 12, 8, 55, 56, 57, 99, 5 };
			MinHeap heap = new MinHeap(array);
            Console.WriteLine("Hello World!");
        }
    }

    public class MinHeap
    {
		public List<int> heap = new List<int>();

		public MinHeap(List<int> array)
		{
			heap = BuildHeap(array);
		}

		public List<int> BuildHeap(List<int> array)
		{
			int firstParentIdx = (array.Count - 2) / 2;
			for(int currentIdx = firstParentIdx; currentIdx >=0; currentIdx--)
            {
				SiftDown(currentIdx, array.Count - 1, array);
            }
			return array;
		}

		public void SiftDown(int currentIdx, int endIdx, List<int> heap)
		{
			int childOneIdx = currentIdx * 2 + 1;
			
			while(childOneIdx <= endIdx)
            {
				int childTwoIdx = currentIdx * 2 + 2 <=
				endIdx ? currentIdx * 2 + 2 : -1;
				int idxToSwap;
				if(childTwoIdx != -1 && heap[childTwoIdx] < heap[childOneIdx])
                {
					idxToSwap = childTwoIdx;
                }
                else
                {
					idxToSwap = childOneIdx;
                }
				if(heap[idxToSwap] < heap[currentIdx])
                {
					Swap(currentIdx, idxToSwap, heap);
					currentIdx = idxToSwap;
					childOneIdx = currentIdx * 2 + 1;
                }
                else
                {
					return;
                }
			}

		}

		public void SiftUp(int currentIdx, List<int> heap)
		{
			int parentIdx = (currentIdx - 1) / 2;
			while(currentIdx > 0 && heap[currentIdx] < heap[parentIdx])
            {
				Swap(currentIdx, parentIdx, heap);
				currentIdx = parentIdx;
				parentIdx = (currentIdx - 1) / 2;
            }
		}

		public int Peek()
		{
			return heap[0];
		}

		public int Remove()
		{
			Swap(0, heap.Count - 1, heap);
			int valueToRemove = heap[heap.Count - 1];
			heap.RemoveAt(heap.Count - 1);
			SiftDown(0, heap.Count - 1, heap);
			return valueToRemove;
		}

		public void Insert(int value)
		{
			this.heap.Add(value);
			this.SiftUp(heap.Count - 1, heap);
		}

		public void Swap(int i, int j, List<int> heap)
        {
			var temp = heap[i];
			heap[i] = heap[j];
			heap[j] = temp;
        }
	}

}

// Sift Up and Down Time O(Log N)

// Build Heap O(N)
