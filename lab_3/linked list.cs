namespace lab_3;

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

public class linked_list
{

    private LinkedListNode _first;
    private LinkedListNode _last;
    private int _pointer;

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
        LinkedListNode current = _first;
        LinkedListNode previous = null;
        
        while (current != null)
        {
            if (current.Pair.Key == key)
            {
                if (previous == null)
                {
                    _first = current.Next; //видалення першого вузла
                }
                else
                {
                    previous.Next = current.Next;// видалення не першого вузла
                }

                if (current == _last)
                {
                    _last = previous; //оновити посилання на останній вузол, якщо необхідно
                }

                break; // вихід із циклу після першого знайденого збігу
            }
            previous = current;
            current = current.Next;// перехід до наступного вузла
        }
    }

    public KeyValuePair? GetItemWithKey(string key)
    {
        LinkedListNode current = _first;
        while (current!=null)
        {
            if (current.Pair.Key == key)
            {
                return current.Pair;// повертає перший знайдений збіг
            }
            current = current.Next;
        }

        return null;
    }
  
}