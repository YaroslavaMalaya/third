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

public class StringsDictionary
{
    private const int InitialSize = 10;

    private LinkedList<KeyValuePair>[] _buckets = new LinkedList<KeyValuePair>[InitialSize];
    
    public void Add(string key, string value)
    {
        var hash = CalculateHash(key);
        if (_buckets[hash] == null)
        {
            _buckets[hash] = new LinkedList<KeyValuePair>();
        }
        
        _buckets[hash].AddLast(new KeyValuePair(key, value)); //  потім замінити AddLast на наш Add
    }

    public void Remove(string key)
    {
        var hash = CalculateHash(key);
        if (_buckets[hash] == null)
        {
            return;
        }

        var head = _buckets[hash].First;
        while (head != null)
        {
            if (head.Value.Key == key)
            {
                _buckets[hash].Remove(head);
                return;
            }
            head = head.Next;
        }
    }

    public string Get(string key)
    {
        var hash = CalculateHash(key);
        if (_buckets[hash] != null)
        {
            foreach (var element in _buckets[hash])
            {
                if (element.Key == key)
                {
                    return element.Value;
                }
            }
        }
        
        return "This word doesn't exist in the dictionary :(";
    }
    
    private int CalculateHash(string key)
    {
        var number = 1;
        foreach (char element in key)
        {
            //number++;
            number *= element;
        }
        var hash = Int32.Abs(number) % _buckets.Length; // беру по модулю (Abs), бо іноді з мінусом виходить
        return hash;
    }
}