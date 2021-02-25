using System;

namespace Lesson_2
{
    class Program
    {
        public class Node
        {
            public int Value { get; set; }
            public Node NextNode { get; set; }
            public Node PrevNode { get; set; }
        }

        //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
        public interface ILinkedList
        {   
            /// <summary>
            /// Возвращает количество элементов в списке
            /// </summary>
            /// <returns></returns>
            int GetCount(); 

            /// <summary>
            /// Добавляет новый элемент списка в конец
            /// </summary>
            /// <param name="value"></param>
            void AddNode(int value);

            /// <summary>
            /// Добавляет новый элемент списка после определённого элемента
            /// </summary>
            /// <param name="node"></param>
            /// <param name="value"></param>
            void AddNodeAfter(Node node, int value);

            /// <summary>
            /// Удаляет элемент по порядковому номеру
            /// </summary>
            /// <param name="index"></param>
            void RemoveNode(int index);

            /// <summary>
            /// Удаляет указанный элемент
            /// </summary>
            /// <param name="node"></param>
            void RemoveNode(Node node);

            /// <summary>
            /// Ищет элемент по его значению
            /// </summary>
            /// <param name="searchValue"></param>
            /// <returns></returns>
            Node FindNode(int searchValue);
        }

        public class LinkedList : ILinkedList
        {
            Node firstNode { get; set; }
            Node lastNode { get; set; }
            int count{ get; set; }

            public int GetCount()
            {
                return count;
            }

            public void AddNode(int value)
            {
                var node = new Node { Value = value };
                
                if (firstNode == null)
                    firstNode = node;
                else
                {
                    lastNode.NextNode = node;
                    node.PrevNode = lastNode;
                }
                lastNode = node;
                count++;
            }

            public void AddNodeAfter(Node node, int value)
            {
                var newNode = new Node { Value = value };
                var nextNode = node.NextNode;
                node.NextNode = newNode;
                newNode.NextNode = nextNode;

                nextNode.PrevNode = newNode;
                newNode.PrevNode = node;
                
                count++;
            }

            public Node FindNode(int searchValue)
            {
                var currentNode = firstNode;

                while (currentNode != null)
                {
                    if (currentNode.Value == searchValue)
                        return currentNode;

                    currentNode = currentNode.NextNode;                    
                }

                return null;
            }            

            public void RemoveNode(int index)
            {
                //НЕ СМОГ РЕАЛИЗОВАТЬ!!! ПОЖАЛУЙСТА обьясните как сделать удаление по индексу
                //откуда взять этот индекс(Понимаю что где то рядом с count)
                //но откуда взять ноду от которой отталкиваться
            }

            public void RemoveNode(Node node)
            {
                if (node != null)
                {
                    if (node.NextNode != null)
                    {
                        node.NextNode.PrevNode = node.PrevNode;
                    }
                    else
                    {
                        lastNode = node.PrevNode;
                    }

                    if (node.PrevNode != null)
                    {
                        node.PrevNode.NextNode = node.NextNode;
                    }
                    else
                    {
                        firstNode = node.NextNode;
                    }
                    count--;                    
                }                
            }           

        }


        static void Main(string[] args)
        {
            #region Задание 1

            // Требуется реализовать класс двусвязного списка и операции вставки, удаления и поиска элемента в нём в соответствии с интерфейсом.

            LinkedList linkedList = new LinkedList();
            linkedList.AddNode(1);
            linkedList.AddNode(2);
            linkedList.AddNode(3);
            linkedList.AddNode(4);
            linkedList.AddNode(5);
            linkedList.AddNode(6);

            linkedList.AddNodeAfter(linkedList.FindNode(3), 10);
            linkedList.AddNodeAfter(linkedList.FindNode(3), 15);
            linkedList.AddNodeAfter(linkedList.FindNode(3), 33);

            linkedList.RemoveNode(linkedList.FindNode(10));
            linkedList.RemoveNode(linkedList.FindNode(1));

            Console.WriteLine($"Кол-во элементов в списке: {linkedList.GetCount()}");            

            Console.WriteLine("Для выхода нажмите любую кнопку");
            Console.ReadKey();
            #endregion

            #region Задание 2

            //Требуется написать функцию бинарного поиска, посчитать его асимптотическую сложность и проверить работоспособность функции.

            /*
            Не понял как сделать бинарный поиск для двусвязного списка, 
            т.к. так же не понимаю откуда брать индексы его элементов и проходить по всем элементам
            */ 

            #endregion
        }

    }
}
