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
            // TODO: Implement!
            return null!;
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
            // TODO: Implement
            return null!;
        }

        public int CountUsers()
        {
            // TODO: Implement
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