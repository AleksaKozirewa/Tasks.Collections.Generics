using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CollectionsTask1
{
    public class OneWayListTest
    {
        [Theory]
        [InlineData(new[] { 1, 2, 3, 4, 5 })]
        [InlineData(new int[0])]
        [InlineData(new[] { 1 })]
        public void ListShouldBeConvertedToArray(int[] input)
        {
            OneWayList<int> list = new OneWayList<int>(input);
            var array = list.ConvertToArray();
            Assert.Equal(input, array);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3 }, 1, new[] { 2, 3 })]
        [InlineData(new[] { 1, 2, 3 }, 2, new[] { 1, 3 })]
        [InlineData(new[] { 1, 2, 3 }, 3, new[] { 1, 2 })]
        [InlineData(new int[0], 0, new int[0])]
        [InlineData(new[] { 1, 2, 3 }, 4, new[] { 1, 2, 3 })]
        public void ShouldRemoveElementAtList(int[] input, int value, int[] expected)
        {
            OneWayList<int> list = new OneWayList<int>(input);
            list.Remove(value);
            var array = list.ToArray();
            Assert.Equal(expected, array);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3 }, 0, new[] { 2, 3 })]
        [InlineData(new[] { 1, 2, 3 }, 1, new[] { 1, 3 })]
        [InlineData(new[] { 1, 2, 3 }, 2, new[] { 1, 2 })]
        [InlineData(new int[0], 0, new int[0])]
        [InlineData(new[] { 1, 2, 3 }, 4, new[] { 1, 2, 3 })]
        public void ShouldRemoveElementAtListAtSomePosition(int[] input, int index, int[] expected)
        {
            OneWayList<int> list = new OneWayList<int>(input);
            list.RemoveAt(index);
            var array = list.ToArray();
            Assert.Equal(expected, array);

        }

        [Theory]
        [InlineData(new[] { 1, 2, 3 }, 1, 1, new[] { 1, 1, 2, 3 })]
        [InlineData(new[] { 1, 2, 3 }, 2, 3, new[] { 1, 2, 3, 3 })]
        [InlineData(new int[0], 0, 0, new int[] { 0 })]
        [InlineData(new[] { 1, 2, 3 }, 3, 4, new[] { 1, 2, 3, 4 })]
        [InlineData(new[] { 1 }, 0, 2, new[] { 2, 1 })]
        public void ShouldAddElementAtListAtSomePosition(int[] input, int index, int value, int[] expected)
        {
            OneWayList<int> list = new OneWayList<int>(input);
            list.AddAt(value, index);
            var array = list.ToArray();
            Assert.Equal(expected, array);
        }

        [Theory]
        [InlineData(new[] {5, 3}, 0, 2, new[] {2, 3})]
        public void ShouldSetElementByUsingIndexing(int [] input, int index, int value, int [] expected)
        {
            OneWayList<int> list = new OneWayList<int>(input);
            list[index] = value;
            var array = list.ToArray();
            Assert.Equal(expected, array);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 5, 4, 3, 2, 1 })]
        [InlineData(new[] { 1, 2, 3 }, new[] { 3, 2, 1 })]
        [InlineData(new[] { 1 }, new[] { 1 })]
        [InlineData(new int[0], new int[0])]
        public void ListShouldBeReversed(int[] input, int[] expected)
        {
            OneWayList<int> list = new OneWayList<int>(input);
            list.Reverse();
            var array = list.ToArray();
            Assert.Equal(expected, array);
        }

        [Theory]
        [InlineData(new[] { 5, 3, 2, 4, 1 }, new[] { 1, 2, 3, 4, 5 })]
        [InlineData(new[] { 5, 3 }, new[] { 3, 5 })]
        [InlineData(new[] { 5 }, new[] { 5 })]
        [InlineData(new int[0], new int[0])]
        public void ListShouldBeSorted(int[] input, int[] expected)
        {
            OneWayList<int> list = new OneWayList<int>(input);
            list.Sort();
            var array = list.ToArray();
            Assert.Equal(expected, array);
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3 }, 1, 2)]
        [InlineData(new[] { 1, 2, 3 }, 2, 3)]
        [InlineData(new[] { 1, 2, 3 }, 0, 1)]
        [InlineData(new[] { 1 }, 0, 1)]
        public void ShouldGetElementByValidIndex(int[] arr, int index, int value)
        {
            OneWayList<int> list = new OneWayList<int>(arr);
            var expectedValue = list.GetElementByIndex(index);
            Assert.Equal(expectedValue, value);
        }
    }
}
