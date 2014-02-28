#include <iostream>

template <class node, class T>
class iterator
{
public:

    iterator(node* n)
    : node_ptr(n)
    {
    }

    node* operator * ()
    {
        return node_ptr->get();
    }

    node* operator -> ()
    {
        return node_ptr->get();
    }

    void operator ++ ()
    {
        node_ptr = node_ptr->next();
    }

    iterator operator ++ (int)
    {
        iterator iter(*this);
        ++(*this);
        return iter;
    }

    bool operator == (iterator const& i)
    {
        return node_ptr == i.node_ptr;
    }

    bool operator != (iterator const& i)
    {
        return !(*this == i);
    }

private:

    node* node_ptr;
};


template <class T>
class element
{
public:

    element * next()
    {
        return next_node;
    }

    element<T>* get()
    {
        return this;
    }

    element(int _priority, T _value)
    {
        priority = _priority;
        value = _value;
        next_node = 0;
    }


	int priority;
	T value;
    element<T> * next_node;

};


template <class T>
class queue
{
    public:
		typedef element<T> node;

		typedef iterator<node, T> iterator;

		 queue()
			 : contanier(0)
		{
		}

        queue (node * cont)
        {
            this->contanier = cont;
            length = 0;
        }


        node peek ()
        {
            node res(this->contanier->priority, this->contanier->value);
            return res;
        }

        int size(){
            return this->length;
        }

        void push (int priority, T value)
        {
            this->length++;
            node *tmp, *new_element, *copy;

            copy = this->contanier;
            tmp = 0;
            bool  flag = true;
            while (copy && flag){
                if  (copy -> priority > priority) {
                    tmp = copy;
                    copy = copy->next_node;
                }
                else
                    flag = false;
            }

            new_element = new   node(priority, value);

            if  (tmp == 0){
                new_element ->next_node = this->contanier;
                this->contanier = new_element;
            }
            else{
                new_element-> next_node = tmp->next_node;
                tmp-> next_node = new_element;
            }
        }

        node pop (){
            this->length--;

            node el(this->contanier->priority, this->contanier->value);
            node *tmp = this->contanier;
            this->contanier = this->contanier->next_node;

            delete tmp;

            return el;
        }

        node * get_head()
        {
            return this->contanier;
        }

        iterator begin()
        {
            return iterator(contanier);
        }

        iterator end()
        {
            return iterator(0);
        }

		private:
            node * contanier;
            int length;

};


int main()
{
	typedef queue<int> int_container;
    int_container q;
    q.push(1, 5);
    q.push(100, 4);
    q.push(2, 6);
    q.push(-1, 0);
    q.push(-2,10);
	element<int> *aa = q.get_head();
	for(int_container::iterator it = q.begin(); it != q.end(); ++it)
    {
		aa = *it;
		std::cout<<aa->priority << " - " << aa->value<<"\n";
    }
    
	system("pause");
    
}
