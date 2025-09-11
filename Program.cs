using System.ComponentModel;
using System.Reflection;
using System.Transactions;

public class Node<T>
{
    public T data { get; set; }// 노드에 들어갈 데이터
    public Node<T> Next { get; set; } // 노드에 들어갈 다음 노드를 가리킴
    public Node(T data) // 생성자 데이터를 넣고 다음은 아직 모르니 null
    {
        this.data = data;
        this.Next = null;
    }
}
public class LinkedList<T>
{
    private Node<T> head;
    public void add(Node<T> newNode)
    {
        if (head == null) // 리스트에 아무것도 없으면 이게 헤드
        {
            head = newNode;
        }
        else
        {
            Node<T> current = head; // 처음부터 다음 노드로 이동
            while (current != null && current.Next != null) // current가 유효한 노드이고 current.Next가 null이 아니면
            {
                current = current.Next; //current는 다음 노드로 이동 , 반복하며 마지막 노드까지 도달
            }
            current.Next = newNode;// 마지막 노드 다음에 새로운 노드 연결
        }
    }
    public void afteradd(Node<T> current, Node<T> newNode) // 중간 삽입 함수
    {
        if (head == null || current == null || newNode == null)
        {
            throw new InvalidOperationException();
        }
        newNode.Next = current.Next;
        current.Next = newNode;
    }
    public void removeNode(Node<T> removeNode)
    {
        if (head == null || removeNode == null)
        {
            throw new InvalidOperationException();
        }
        if (head == removeNode)
        {
            head = head.Next;
            removeNode = null;
        }
        Node<T> current = head;
        while (current != null && current.Next != removeNode)
        {
            current = current.Next;
        }
        if (current != null)
        {
            current.Next = removeNode.Next;
            removeNode = null;
        }

    }
    public Node<T> getNode(int index)
    {
        if (head == null)
        {
            throw new InvalidOperationException();
        }
        Node<T> current = head;
        for (int i = 0; i < index && current != null; i++)
        {
            current = current.Next;
        }
        return current;
    }
    public int Count()
    {
        int count = 0;
        Node<T> current = head;
        while (current != null)
        {
            count++;
            current = current.Next;

        }
        return count;
    }
    public void PrintList()
    {
        Node<T> current = head;
        while (current != null)
        {
            Console.WriteLine(current.data);
            current = current.Next;

        }
    }

}
public class linkedlist
{
    static void Main(String[] args)
    {
        LinkedList<int> mylist = new LinkedList<int>();
        mylist.add(new Node<int>(10));
        mylist.add(new Node<int>(20));
        mylist.add(new Node<int>(30));
        Node<int> nodeToafteradd = mylist.getNode(1);
        mylist.afteradd(nodeToafteradd, new Node<int>(25));
        Console.WriteLine(mylist.Count());
        mylist.PrintList();
        Node<int> nodeToRemove = mylist.getNode(2);
        mylist.removeNode(nodeToRemove);
         mylist.PrintList();


    }
}