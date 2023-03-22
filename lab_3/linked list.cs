namespace lab_3;

public class linked_list
{
    public class KeyValuePair
    {
        public string Key { get; }

        public string Value { get; }

        public KeyValuePair(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }

    public class LinkedListNode
    {
        public KeyValuePair Pair { get; }
        
        public LinkedListNode Next { get; set; }

        public LinkedListNode(KeyValuePair pair, LinkedListNode next = null)
        {
            Pair = pair;
            Next = next;
        }
    }
    public class LinkedList
    {
        private LinkedListNode _first;
        private LinkedListNode _last;

        public void Add(KeyValuePair pair)
        {
            LinkedListNode node = new LinkedListNode(pair);
            if (_first == null)
            {
                _first = node;
                _last = node;
            }
            else
            {
                _last.Next = node;
                _last = node;
            }
        }

        public void RemoveByKey(string key)
        {
            // remove pair with provided key
        }

        /*public KeyValuePair GetItemWithKey(string key)
        {
            // get pair with provided key, return null if not found
        } */
    }
}