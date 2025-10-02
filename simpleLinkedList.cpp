#include <iostream>
using namespace std;
class Node{
    public:
    int data;
    Node* next;
};
Node* insert(Node* head, int data)
{
    Node* newNode = new Node();
    newNode->data =data;
    newNode->next = nullptr;
    if(head==nullptr)
    {
        return newNode;
    }
    Node* temp = head;
    while(temp->next != nullptr){
        temp = temp->next;
    }
    temp->next =newNode;
    return head;
}
Node* deleteNode(Node* head,int key){
    if(head ==nullptr){
        return head;
    }
    else{
        Node* temp = head;
        if(temp->data == key && temp->next != nullptr){
            head = temp->next;
            delete temp;
            return head;
        }
        else if(temp->data ==key &&temp->next ==nullptr){
            delete temp;
            head = nullptr;
            return head;
        }
        while(temp->next != nullptr && temp ->next->data !=key){
            temp = temp->next;
        }
        if(temp->next == nullptr){
            return head;
        }
        Node* nodeToDelete = temp->next;
        temp->next = temp->next->next;
        delete nodeToDelete;
        return head;

    }
}
void printList(Node* head){
    Node* temp = new Node();
    temp = head;
    while(temp != nullptr){
        cout << temp->data <<" ";
        temp = temp->next;
    }
    cout << endl;

}
    int main(){
    Node* head = new Node();
    head = nullptr;
    head = insert(head,1);
    head = insert(head,2);
    head = insert(head,3);
    printList(head);
    head = deleteNode(head,3);
    printList(head);
    return 0;
}