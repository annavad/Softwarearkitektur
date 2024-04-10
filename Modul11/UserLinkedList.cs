namespace LinkedList
{
    class Node
    {
        public Node(User data, Node next)
        {
            this.Data = data;
            this.Next = next;
        }
        public User Data;
        public Node Next;
    }

    class UserLinkedList
    {
        private Node first = null!;

        public void AddFirst(User user)
        {
            Node node = new Node(user, first);
            first = node;
        }

        public User RemoveFirst()
        {
            if(first == null)
            {
                return null!;
            }

            User res = first.Data;
            first = first.Next;

            return res;
        }

        public void RemoveUser(User user)
        {
            Node current = first;
            Node previous = null!;
            bool found = false;

            while (!found && current != null)
            {
                if (current.Data.Name == user.Name)
                {
                    found = true;
                    if (current == first)
                    {
                        RemoveFirst();
                    }
                    else
                    {
                        previous.Next = current.Next;
                    }
                }
                else
                {
                    previous = current;
                    current = current.Next;
                }
            }
        }

        public User GetFirst()
        {
            return first.Data;
        }

        public User GetLast()
        {
            if(first == null)
            {
                return null!;
            }

            Node current = first;

            while (current.Next !=null)
            {
                current = current.Next;
            }

            return current.Data;
        }

        public int CountUsers() //ikke færdig
        {
            Node current = first;
            int counter = 0;

            while (current != null)
            return -1;
        }

        public override String ToString()
        {
            Node current = first;
            String result = "";
            while (current != null)
            {
                result += current.Data.Name + ", ";
                current = current.Next;
            }
            return result.Trim();
        }
    }
}